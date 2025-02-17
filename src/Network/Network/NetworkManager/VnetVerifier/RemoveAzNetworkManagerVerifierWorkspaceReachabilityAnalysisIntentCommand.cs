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

using Microsoft.Azure.Commands.Network.Models.NetworkManager;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerVerifierWorkspaceReachabilityAnalysisIntent", SupportsShouldProcess = true, DefaultParameterSetName = DeleteByNameParameterSet), OutputType(typeof(bool))]
    public class RemoveAzNetworkManagerVerifierWorkspaceReachabilityAnalysisIntentCommand : ReachabilityAnalysisIntentBaseCmdlet
    {
        private const string DeleteByNameParameterSet = "ByName";
        private const string DeleteByResourceIdParameterSet = "ByResourceId";
        private const string DeleteByInputObjectParameterSet = "ByInputObject";

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.",
           ParameterSetName = DeleteByNameParameterSet)]
        [ResourceNameCompleter("Microsoft.Network/NetworkManagers/verifierWorkspaces/reachabilityAnalysisIntents", "ResourceGroupName", "NetworkManagerName", "VerifierWorkspaceName")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The network manager name.",
           ParameterSetName = DeleteByNameParameterSet)]
        [ResourceNameCompleter("Microsoft.Network/NetworkManagers", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public virtual string NetworkManagerName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.",
           ParameterSetName = DeleteByNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The verifier workspace name.",
           ParameterSetName = DeleteByNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string VerifierWorkspaceName { get; set; }
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The network manager verifier workspace intent resource.",
            ParameterSetName = DeleteByInputObjectParameterSet)]
        [ValidateNotNull]
        public PSReachabilityAnalysisIntent InputObject { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource id.",
            ParameterSetName = DeleteByResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            if (ParameterSetName.Equals(DeleteByResourceIdParameterSet, StringComparison.OrdinalIgnoreCase))
            {
                this.PopulateResourceInfoFromId(this.ResourceId);
            }
            else if (ParameterSetName.Equals(DeleteByInputObjectParameterSet, StringComparison.OrdinalIgnoreCase))
            {
                this.PopulateResourceInfoFromId(this.InputObject.Id);
            }
            base.Execute();
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.RemovingResource, Name),
                Properties.Resources.RemoveResourceMessage,
                Name,
                () =>
                {
                    this.ReachabilityAnalysisIntentClient.Delete(this.ResourceGroupName, this.NetworkManagerName, this.VerifierWorkspaceName, this.Name);
                    if (PassThru.IsPresent)
                    {
                        WriteObject(true);
                    }
                });
        }
        private void PopulateResourceInfoFromId(string id)
        {
            var parsedResourceId = new ResourceIdentifier(id);
            this.ResourceGroupName = parsedResourceId.ResourceGroupName;
            this.Name = parsedResourceId.ResourceName;

            var segments = parsedResourceId.ParentResource.Split('/');
            if (segments.Length < 4)
            {
                throw new PSArgumentException("Invalid format. Ensure the ResourceId or Input Object is in the correct format.");
            }
            this.NetworkManagerName = segments[1];
            this.VerifierWorkspaceName = segments[3];
        }
    }
}