using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    public abstract class ExpressRouteCrossConnectionMigrationBaseCmdlet : ExpressRouteCrossConnectionBaseCmdlet
    {
        [Parameter(Mandatory = true, ParameterSetName = ParameterSetNames.ByName, HelpMessage = "The cross-connection name.")]
        [ResourceNameCompleter("Microsoft.Network/expressRouteCrossConnections", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ParameterSetNames.ByName, HelpMessage = "The resource group containing the cross-connection.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ParameterSetNames.ByInputObject, ValueFromPipeline = true, HelpMessage = "The cross-connection to migrate.")]
        [Alias("ExpressRouteCrossConnection")]
        [ValidateNotNullOrEmpty]
        public PSExpressRouteCrossConnection InputObject { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ParameterSetNames.ByResourceId, ValueFromPipelineByPropertyName = true, HelpMessage = "The cross-connection resource ID in the current subscription.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(HelpMessage = "Run the command in the background.")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            string resourceId = null;
            if (ParameterSetName == ParameterSetNames.ByInputObject)
            {
                resourceId = InputObject.Id;
                if (string.IsNullOrWhiteSpace(resourceId))
                {
                    throw new PSArgumentException("InputObject must contain a cross-connection resource ID.", nameof(InputObject));
                }
            }
            else if (ParameterSetName == ParameterSetNames.ByResourceId)
            {
                resourceId = ResourceId;
            }

            if (resourceId != null)
            {
                var identifier = new ResourceIdentifier(resourceId);
                var expectedId = $"/subscriptions/{identifier.Subscription}/resourceGroups/{identifier.ResourceGroupName}/providers/Microsoft.Network/expressRouteCrossConnections/{identifier.ResourceName}";
                if (string.IsNullOrWhiteSpace(identifier.Subscription) ||
                    string.IsNullOrWhiteSpace(identifier.ResourceGroupName) ||
                    string.IsNullOrWhiteSpace(identifier.ResourceName) ||
                    !string.Equals(resourceId, expectedId, StringComparison.OrdinalIgnoreCase))
                {
                    throw new PSArgumentException("Specify a Microsoft.Network/expressRouteCrossConnections resource ID.", nameof(ResourceId));
                }

                if (!string.Equals(identifier.Subscription, DefaultProfile.DefaultContext.Subscription.Id, StringComparison.OrdinalIgnoreCase))
                {
                    throw new PSArgumentException("The cross-connection subscription must match the current Azure context.", nameof(ResourceId));
                }

                Name = identifier.ResourceName;
                ResourceGroupName = identifier.ResourceGroupName;
            }
        }

        protected IList<PortMapping> ToPortMappings(PSExpressRouteCrossConnectionPortMapping[] mappings)
        {
            if (mappings == null)
            {
                return null;
            }

            var result = new List<PortMapping>();
            foreach (var mapping in mappings)
            {
                if (mapping == null || string.IsNullOrWhiteSpace(mapping.SourcePortId) || string.IsNullOrWhiteSpace(mapping.TargetPortId))
                {
                    throw new PSArgumentException("Each target port mapping must contain nonempty SourcePortId and TargetPortId values.", "TargetPortMapping");
                }

                result.Add(NetworkResourceManagerProfile.Mapper.Map<PortMapping>(mapping));
            }

            return result;
        }
    }

    public abstract class ExpressRouteCrossConnectionMigrationDiagnosticBaseCmdlet : ExpressRouteCrossConnectionMigrationBaseCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The target peering location to validate or check.")]
        [ValidateNotNullOrEmpty]
        public string TargetPeeringLocation { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The source-to-target port mappings created with New-AzExpressRouteCrossConnectionPortMapping.")]
        [ValidateNotNullOrEmpty]
        public PSExpressRouteCrossConnectionPortMapping[] TargetPortMapping { get; set; }

        protected MigrateExpressRouteCircuitValidateAndHealthCheckRequest CreateRequest()
        {
            return new MigrateExpressRouteCircuitValidateAndHealthCheckRequest(TargetPeeringLocation, ToPortMappings(TargetPortMapping));
        }
    }

    public abstract class ExpressRouteCrossConnectionMigrationActionBaseCmdlet : ExpressRouteCrossConnectionMigrationBaseCmdlet
    {
        [Parameter(HelpMessage = "The target peering location for this migration action.")]
        [ValidateNotNullOrEmpty]
        public string TargetPeeringLocation { get; set; }

        [Parameter(HelpMessage = "The source-to-target port mappings created with New-AzExpressRouteCrossConnectionPortMapping.")]
        [ValidateNotNullOrEmpty]
        public PSExpressRouteCrossConnectionPortMapping[] TargetPortMapping { get; set; }

        protected virtual string MigrationPortId => null;

        protected abstract MigrateExpressRouteCircuitHealthCheckResponse SendMigrationRequest(MigrateExpressRouteCircuitRequest request);

        public override void Execute()
        {
            base.Execute();
            var request = new MigrateExpressRouteCircuitRequest(TargetPeeringLocation, ToPortMappings(TargetPortMapping), MigrationPortId);
            var target = $"{ResourceGroupName}/{Name}";
            if (!string.IsNullOrEmpty(MigrationPortId))
            {
                target += $" (port {MigrationPortId})";
            }

            if (ShouldProcess(target))
            {
                var result = SendMigrationRequest(request);
                WriteObject(NetworkResourceManagerProfile.Mapper.Map<PSExpressRouteCircuitMigrationResult>(result));
            }
        }
    }

    public abstract class ExpressRouteCrossConnectionMigrationPortActionBaseCmdlet : ExpressRouteCrossConnectionMigrationActionBaseCmdlet
    {
        [Parameter(HelpMessage = "The provider port identifier for this migration action.")]
        [ValidateNotNullOrEmpty]
        public string PortId { get; set; }

        protected override string MigrationPortId => PortId;
    }
}