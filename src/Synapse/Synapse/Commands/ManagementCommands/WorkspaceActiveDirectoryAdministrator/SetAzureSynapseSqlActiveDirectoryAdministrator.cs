// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.Sql + SynapseConstants.ActiveDirectoryAdministrator,
        DefaultParameterSetName = SetByNameAndDisplayNameParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSWorkspaceAadAdminInfo))]
    public class SetAzureSynapseSqlActiveDirectoryAdministrator : SynapseManagementCmdletBase
    {
        private const string SetByNameAndDisplayNameParameterSet = "SetByNameAndDisplayNameParameterSet";
        private const string SetByInputObjectAndDisplayNameParameterSet = "SetByInputObjectAndDisplayNameParameterSet";
        private const string SetByResourceIdAndDisplayNameParameterSet = "SetByResourceIdAndDisplayNameParameterSet";
        private const string SetByNameAndObjectIdParameterSet = "SetByNameAndObjectIdParameterSet";
        private const string SetByInputObjectAndObjectIdParameterSet = "SetByInputObjectAndObjectIdParameterSet";
        private const string SetByResourceIdAndObjectIdParameterSet = "SetByResourceIdAndObjectIdParameterSet";

        [Parameter(ParameterSetName = SetByNameAndDisplayNameParameterSet, Mandatory = false,
            HelpMessage = HelpMessages.ResourceGroupName)]
        [Parameter(ParameterSetName = SetByNameAndObjectIdParameterSet, Mandatory = false,
            HelpMessage = HelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = SetByNameAndDisplayNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [Parameter(ParameterSetName = SetByNameAndObjectIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = SetByInputObjectAndDisplayNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [Parameter(ValueFromPipeline = true, ParameterSetName = SetByInputObjectAndObjectIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace InputObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByResourceIdAndDisplayNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceResourceId)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByResourceIdAndObjectIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByNameAndDisplayNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.DisplayName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByInputObjectAndDisplayNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.DisplayName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByResourceIdAndDisplayNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.DisplayName)]
        [ValidateNotNullOrEmpty()]
        public string DisplayName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByNameAndObjectIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.ObjectId)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByInputObjectAndObjectIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.ObjectId)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = SetByResourceIdAndObjectIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.ObjectId)]
        [ValidateNotNullOrEmpty()]
        public Guid ObjectId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.AsJob)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.InputObject))
            {
                var resourceIdentifier = new ResourceIdentifier(this.InputObject.Id);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.WorkspaceName = this.InputObject.Name;
            }

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.WorkspaceName = resourceIdentifier.ResourceName;
            }

            if (string.IsNullOrEmpty(this.ResourceGroupName))
            {
                this.ResourceGroupName = this.SynapseAnalyticsClient.GetResourceGroupByWorkspaceName(this.WorkspaceName);
            }

            if (this.ShouldProcess(this.WorkspaceName, string.Format(Resources.SettingSqlActiveDirectoryAdministrator, this.WorkspaceName)))
            {
                var result = new PSWorkspaceAadAdminInfo(SynapseAnalyticsClient.CreateOrUpdateSqlActiveDirectoryAdministrators(this.ResourceGroupName, this.WorkspaceName, this.DisplayName, this.ObjectId),
                    this.ResourceGroupName, this.WorkspaceName);
                WriteObject(result);
            }
        }
    }
}
