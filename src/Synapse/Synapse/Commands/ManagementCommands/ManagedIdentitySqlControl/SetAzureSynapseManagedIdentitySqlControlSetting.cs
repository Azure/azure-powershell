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
using Microsoft.Azure.Commands.Synapse.Models.ManagedIdentitySqlControl;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.ManagedIdentitySqlControlSetting,
        DefaultParameterSetName = ByNameParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSManagedIdentitySqlControlSettingsModel))]
    public class SetAzureSynapseManagedIdentitySqlControlSetting : SynapseManagementCmdletBase
    {
        private const string ByNameParameterSet = "ByNameParameterSet";
        private const string ByParentObjectParameterSet = "ByParentObjectParameterSet";
        private const string ByResourceIdParameterSet = "ByResourceIdParameterSet";

        [Parameter(ParameterSetName = ByNameParameterSet, Mandatory = false,
            HelpMessage = HelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ByNameParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = ByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = ByResourceIdParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessages.EnableManagedIdentitySqlControlSetting)]
        public bool Enabled { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                var resourceIdentifier = new ResourceIdentifier(this.WorkspaceObject.Id);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.WorkspaceName = resourceIdentifier.ResourceName;
            }

            ConfirmAction(
                string.Format(Resources.UpdatingManagedIdentity, this.WorkspaceName),
                this.WorkspaceName,
                () =>
                {
                    var desiredState = Enabled ? ManagedIdentitySqlControlSettingsState.Enabled : ManagedIdentitySqlControlSettingsState.Disabled;
                    var result = new PSManagedIdentitySqlControlSettingsModel(SynapseAnalyticsClient.UpdateManagedIdentitySqlControlSetting(this.ResourceGroupName, this.WorkspaceName, desiredState));
                    WriteObject(result);
                });
        }
    }
}
