using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Synapse.Models;
using Microsoft.Rest.Serialization;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsData.Update, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.IntegrationRuntime,
        DefaultParameterSetName = UpdateByNameParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSSelfHostedIntegrationRuntimeStatus))]
    public class UpdateAzureSynapseIntegrationRuntime : SynapseManagementCmdletBase
    {
        private const string UpdateByNameParameterSet = "UpdateByNameParameterSet";
        private const string UpdateByParentObjectParameterSet = "UpdateByParentObjectParameterSet";
        private const string UpdateByResourceIdParameterSet = "UpdateByResourceIdParameterSet";
        private const string UpdateByInputObjectParameterSet = "UpdateByInputObjectParameterSet";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = UpdateByNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = UpdateByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = UpdateByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.IntegrationRuntimeName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = UpdateByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.IntegrationRuntimeName)]
        [ResourceNameCompleter(
            ResourceTypes.IntegrationRuntime,
            nameof(ResourceGroupName),
            nameof(WorkspaceName))]
        [ValidateNotNullOrEmpty]
        public string IntegrationRuntimeName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = UpdateByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = UpdateByResourceIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.IntegrationRuntimeResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = UpdateByInputObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.IntegrationRuntimeObject)]
        [ValidateNotNull]
        public PSIntegrationRuntime InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeAutoUpdate)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(SynapseConstants.IntegrationRuntimeAutoUpdateEnabled, 
            SynapseConstants.IntegrationRuntimeAutoUpdateDisabled,
            IgnoreCase = true)]
        public string AutoUpdate { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.IntegrationRuntimeAutoUpdateTime)]
        [ValidateNotNull]
        public TimeSpan? AutoUpdateDelayOffset { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.WorkspaceName = resourceIdentifier.ParentResource;
                this.WorkspaceName = this.WorkspaceName.Substring(this.WorkspaceName.LastIndexOf('/') + 1);
                this.IntegrationRuntimeName = resourceIdentifier.ResourceName;
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
                this.IntegrationRuntimeName = InputObject.Name;
            }

            if (AutoUpdate == null && !AutoUpdateDelayOffset.HasValue)
            {
                throw new PSArgumentException("No valid parameters.");
            }

            IntegrationRuntimeResource resource = SynapseAnalyticsClient.GetIntegrationRuntimeAsync(
                    ResourceGroupName,
                    WorkspaceName,
                    IntegrationRuntimeName).ConfigureAwait(true).GetAwaiter().GetResult().IntegrationRuntime;
            WriteVerbose("Got integration runtime");

            Action updateIntegrationRuntime = () =>
            {
                var request = new UpdateIntegrationRuntimeRequest();
                if (!string.IsNullOrEmpty(AutoUpdate))
                {
                    request.AutoUpdate = AutoUpdate;
                }
                WriteVerbose("Handled AutoUpdate");

                if (AutoUpdateDelayOffset.HasValue)
                {
                    request.UpdateDelayOffset = SafeJsonConvert.SerializeObject(
                        AutoUpdateDelayOffset.Value,
                        SynapseAnalyticsClient.GetSerializationSettings());

                    WriteVerbose(request.UpdateDelayOffset);
                }

                WriteVerbose("Handled AutoUpdateDelayOffset");
                WriteObject(SynapseAnalyticsClient.UpdateIntegrationRuntimeAsync(ResourceGroupName,
                    WorkspaceName,
                    IntegrationRuntimeName,
                    resource,
                    request).ConfigureAwait(false).GetAwaiter().GetResult());
            };

            ConfirmAction(
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.UpdatingIntegrationRuntime,
                    IntegrationRuntimeName,
                    WorkspaceName),
                IntegrationRuntimeName,
                updateIntegrationRuntime);
        }
    }
}
