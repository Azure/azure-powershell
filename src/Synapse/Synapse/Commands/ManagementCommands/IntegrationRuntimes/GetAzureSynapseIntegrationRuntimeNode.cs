using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.IntegrationRuntime + SynapseConstants.Node,
           DefaultParameterSetName = GetByNameParameterSet)]
    [OutputType(typeof(PSManagedIntegrationRuntimeNode), typeof(PSSelfHostedIntegrationRuntimeNode))]
    public class GetAzureSynapseIntegrationRuntimeNode : SynapseManagementCmdletBase
    {
        private const string GetByNameParameterSet = "GetByNameParameterSet";
        private const string GetByParentObjectParameterSet = "GetByParentObjectParameterSet";
        private const string GetByResourceIdParameterSet = "GetByResourceIdParameterSet";
        private const string GetByInputObjectParameterSet = "GetByInputObjectParameterSet";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.IntegrationRuntimeName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.IntegrationRuntimeName)]
        [ResourceNameCompleter(
            ResourceTypes.IntegrationRuntime,
            nameof(ResourceGroupName),
            nameof(WorkspaceName))]
        [ValidateNotNullOrEmpty]
        public string IntegrationRuntimeName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = GetByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = GetByResourceIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.IntegrationRuntimeResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = GetByInputObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.IntegrationRuntimeObject)]
        [ValidateNotNull]
        public PSIntegrationRuntime InputObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true, HelpMessage = HelpMessages.IntegrationRuntimeNodeName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeNodeIpAddress)]
        public SwitchParameter IpAddress { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.WorkspaceName = resourceIdentifier.ParentResource;
                this.WorkspaceName = this.WorkspaceName.Substring(this.WorkspaceName.LastIndexOf('/') + 1);
                this.Name = resourceIdentifier.ResourceName;
            }

            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.ResourceGroupName = new ResourceIdentifier(this.WorkspaceObject.Id).ResourceGroupName;
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            if (this.IsParameterBound(c => c.InputObject))
            {
                this.ResourceGroupName = InputObject.ResourceGroupName;
                this.WorkspaceName = InputObject.WorkspaceName;
                this.Name = InputObject.Name;
            }

            var status = SynapseAnalyticsClient.GetIntegrationRuntimeStatusAsync(ResourceGroupName, WorkspaceName,
                IntegrationRuntimeName).ConfigureAwait(false).GetAwaiter().GetResult();

            var managedStatus = status as PSManagedIntegrationRuntimeStatus;
            if (managedStatus != null)
            {
                if (IpAddress.IsPresent)
                {
                    ThrowTerminatingError
                        (new ErrorRecord(
                            new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                                "The SSIS-Azure integration runtime does not support getting IP address of node.")),
                            string.Empty,
                            ErrorCategory.ObjectNotFound,
                            null));
                }

                var node = managedStatus.Nodes.FirstOrDefault(n => n.NodeId == Name);
                if (node == null)
                {
                    ThrowTerminatingError
                        (new ErrorRecord(
                            new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                                "The node with node ID {0} in integration runtime {1} was not found.", Name, IntegrationRuntimeName)),
                            string.Empty,
                            ErrorCategory.ObjectNotFound,
                            null));
                }

                WriteObject(new PSManagedIntegrationRuntimeNode(ResourceGroupName, WorkspaceName, IntegrationRuntimeName, Name, node));
            }

            var selfHostedStatus = status as PSSelfHostedIntegrationRuntimeStatus;
            if (selfHostedStatus != null)
            {
                var node = selfHostedStatus.Nodes.FirstOrDefault(n => n.NodeName == Name);
                if (node == null)
                {
                    ThrowTerminatingError
                        (new ErrorRecord(
                            new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                                "The node with node name {0} in integration runtime {1} was not found.", Name, IntegrationRuntimeName)),
                            string.Empty,
                            ErrorCategory.ObjectNotFound,
                            null));
                }

                string ipAddress = null;
                if (IpAddress.IsPresent)
                {
                    var ip = SynapseAnalyticsClient.GetIntegrationRuntimeNodeIpAsync(
                        ResourceGroupName,
                        WorkspaceName,
                        IntegrationRuntimeName,
                        Name).ConfigureAwait(false).GetAwaiter().GetResult();
                    ipAddress = ip.Body.IpAddress;
                }

                WriteObject(new PSSelfHostedIntegrationRuntimeNode(ResourceGroupName, WorkspaceName, IntegrationRuntimeName, Name, node, ipAddress));
            }
        }
    }
}
