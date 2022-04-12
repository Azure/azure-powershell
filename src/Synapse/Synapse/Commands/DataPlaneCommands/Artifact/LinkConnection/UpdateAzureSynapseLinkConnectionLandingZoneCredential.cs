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

using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsData.Update, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.LinkConnectionLandingZoneCredential,
        DefaultParameterSetName = UpdateByName, SupportsShouldProcess = true)]
    [OutputType(typeof(void))]
    public class UpdateAzureSynapseLinkConnectionLandingZoneCredential : SynapseArtifactsCmdletBase
    {
        private const string UpdateByName = "UpdateByName";
        private const string UpdateByObject = "UpdateByObject";
        private const string UpdateByInputObject = "UpdateByInputObject";

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = UpdateByName,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = UpdateByObject,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceObject)]
        [ValidateNotNull]
        public PSSynapseWorkspace WorkspaceObject { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = UpdateByInputObject,
            Mandatory = true, HelpMessage = HelpMessages.LinkConnectionObject)]
        [ValidateNotNull]
        public PSLinkConnectionResource InputObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = UpdateByName,
            Mandatory = true, HelpMessage = HelpMessages.LinkConnectionName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = UpdateByObject,
            Mandatory = true, HelpMessage = HelpMessages.LinkConnectionName)]
        public string LinkConnectionName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, Mandatory = true, HelpMessage = HelpMessages.SasToken)]
        [ValidateNotNullOrEmpty]
        public SecureString SasToken { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.WorkspaceObject))
            {
                this.WorkspaceName = this.WorkspaceObject.Name;
            }

            if (this.IsParameterBound(c => c.InputObject))
            {
                this.WorkspaceName = this.InputObject.WorkspaceName;
                this.LinkConnectionName = this.InputObject.Name;
            }

            var updateLandingZoneCredential = new UpdateLandingZoneCredential();
            updateLandingZoneCredential.SasToken = this.SasToken;

            if (this.ShouldProcess(this.WorkspaceName, String.Format(Resources.UpdatingLinkConnectionLandingZoneCredential, this.LinkConnectionName, this.WorkspaceName)))
            {
                SynapseAnalyticsClient.UpdateLandingZoneCredential(this.LinkConnectionName, updateLandingZoneCredential);
            }
        }
    }
}
