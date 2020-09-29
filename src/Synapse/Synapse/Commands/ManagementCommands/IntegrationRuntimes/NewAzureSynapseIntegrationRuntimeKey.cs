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

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.IntegrationRuntime + SynapseConstants.Key,
        DefaultParameterSetName = NewByNameParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSIntegrationRuntimeKeys))]
    public class NewAzureSynapseIntegrationRuntimeKey : SynapseManagementCmdletBase
    {
        private const string NewByNameParameterSet = "NewByNameParameterSet";
        private const string NewByParentObjectParameterSet = "NewByParentObjectParameterSet";
        private const string NewByResourceIdParameterSet = "NewByResourceIdParameterSet";
        private const string NewByInputObjectParameterSet = "NewByInputObjectParameterSet";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = NewByNameParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = NewByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = NewByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.IntegrationRuntimeName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = NewByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.IntegrationRuntimeName)]
        [ResourceNameCompleter(
            ResourceTypes.IntegrationRuntime,
            nameof(ResourceGroupName),
            nameof(WorkspaceName))]
        [Alias(SynapseConstants.IntegrationRuntimeName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = NewByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = NewByResourceIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.IntegrationRuntimeResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = NewByInputObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.IntegrationRuntimeObject)]
        [ValidateNotNull]
        public PSIntegrationRuntime InputObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true, HelpMessage = HelpMessages.IntegrationRuntimeKeyName)]
        [ValidateNotNullOrEmpty]
        [ValidateSet("AuthKey1", "AuthKey2", IgnoreCase = true)]
        public string KeyName { get; set; }

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

            if (string.IsNullOrWhiteSpace(KeyName))
            {
                throw new PSArgumentNullException("KeyName");
            }

            PSIntegrationRuntimeKeys authKey = null;
            Action regenerateIntegrationRuntimeAuthKey = () =>
            {
                authKey = SynapseAnalyticsClient.RegenerateIntegrationRuntimeAuthKeyAsync(
                    ResourceGroupName,
                    WorkspaceName,
                    Name,
                    KeyName).ConfigureAwait(true).GetAwaiter().GetResult();
            };

            ConfirmAction(
                Force.IsPresent,
                // prompt only if the integration runtime exists
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.ContinueRegenerateAuthKey,
                    KeyName,
                    Name),
                // Process message, 
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.RegenerateAuthKey,
                    KeyName,
                    Name),
                // Target
                Name,
                regenerateIntegrationRuntimeAuthKey,
                () => SynapseAnalyticsClient.CheckIntegrationRuntimeExistsAsync(
                    ResourceGroupName,
                    WorkspaceName,
                    Name).ConfigureAwait(true).GetAwaiter().GetResult());

            WriteObject(authKey);
        }
    }
}
