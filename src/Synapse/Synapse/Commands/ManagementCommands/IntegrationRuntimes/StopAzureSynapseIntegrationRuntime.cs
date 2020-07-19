using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Management.Automation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsLifecycle.Stop, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.IntegrationRuntime,
        DefaultParameterSetName = StopByNameParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(void))]
    public class StopAzureSynapseIntegrationRuntime : SynapseManagementCmdletBase
    {
        private const string StopByNameParameterSet = "StopByNameParameterSet";
        private const string StopByParentObjectParameterSet = "StopByParentObjectParameterSet";
        private const string StopByResourceIdParameterSet = "StopByResourceIdParameterSet";
        private const string StopByInputObjectParameterSet = "StopByInputObjectParameterSet";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = StopByNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = StopByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = StopByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.IntegrationRuntimeName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = StopByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.IntegrationRuntimeName)]
        [ResourceNameCompleter(
            ResourceTypes.IntegrationRuntime,
            nameof(ResourceGroupName),
            nameof(WorkspaceName))]
        [Alias(SynapseConstants.IntegrationRuntimeName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = StopByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = StopByResourceIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.IntegrationRuntimeResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = StopByInputObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.IntegrationRuntimeObject)]
        [ValidateNotNull]
        public PSIntegrationRuntime InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.DontAskConfirmation)]
        public SwitchParameter Force { get; set; }

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

            Action stopIntegrationRuntime = () =>
            {
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                var task = Task.Run(() =>
                {
                    SynapseAnalyticsClient.StopIntegrationRuntimeAsync(
                        ResourceGroupName,
                        WorkspaceName,
                        Name).ConfigureAwait(true).GetAwaiter().GetResult();
                }, cancellationTokenSource.Token);

                UpdateProgress(task, new ProgressRecord(1, "Stop", "Stopping Progress"));
            };

            ConfirmAction(
                Force.IsPresent,
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IntegrationRuntimeExists,
                    Name,
                    WorkspaceName),
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.StoppingIntegrationRuntime,
                    Name,
                    WorkspaceName),
                Name,
                stopIntegrationRuntime,
                () => SynapseAnalyticsClient.CheckIntegrationRuntimeExistsAsync(
                    ResourceGroupName,
                    WorkspaceName,
                    Name).ConfigureAwait(true).GetAwaiter().GetResult());
        }
    }
}
