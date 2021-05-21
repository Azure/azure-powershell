﻿using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Models.WorkspaceKey;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse.Commands
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.WorkspaceKey, DefaultParameterSetName = GetByNameParameterSet)]
    [OutputType(typeof(PSWorkspaceKey))]
    public class GetAzureSynapseWorkspaceKey : SynapseManagementCmdletBase
    {
        private const string GetByNameParameterSet = "GetByNameParameterSet";
        private const string GetByParentObjectParameterSet = "GetByParentObjectParameterSet";
        private const string GetByResourceIdParameterSet = "GetByResourceIdParameterSet";

        [Parameter(Mandatory = false, ParameterSetName = GetByNameParameterSet,
            HelpMessage = HelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = GetByNameParameterSet,
            HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = GetByNameParameterSet, HelpMessage = HelpMessages.EncryptionKeyName)]
        [Parameter(Mandatory = false, ParameterSetName = GetByParentObjectParameterSet, HelpMessage = HelpMessages.EncryptionKeyName)]
        [Alias(nameof(SynapseConstants.KeyName))]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = GetByParentObjectParameterSet, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = false, ParameterSetName = GetByResourceIdParameterSet, HelpMessage = HelpMessages.KeyResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

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

            if (!string.IsNullOrEmpty(this.Name))
            {
                var result = new PSWorkspaceKey(this.SynapseAnalyticsClient.GetKey(this.ResourceGroupName, this.WorkspaceName, this.Name));
                WriteObject(result);
            }
            else
            {
                var result = this.SynapseAnalyticsClient.ListKeys(this.ResourceGroupName, this.WorkspaceName).Select(r => new PSWorkspaceKey(r));
                WriteObject(result, true);
            }
        }
    }
}
