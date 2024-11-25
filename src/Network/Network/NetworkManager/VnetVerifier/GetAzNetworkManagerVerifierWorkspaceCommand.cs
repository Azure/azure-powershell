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

using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Network.Models.NetworkManager;
using System;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerVerifierWorkspace", DefaultParameterSetName = ListParameterSet), OutputType(typeof(PSVerifierWorkspace))]
    public class GetAzNetworkManagerVerifierWorkspaceCommand : VerifierWorkspaceBaseCmdlet
    {
        private const string ListParameterSet = "ByList";
        private const string GetByNameParameterSet = "ByName";
        private const string GetByResourceIdParameterSet = "ByResourceId";

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = false,
           HelpMessage = "The resource name.",
           ParameterSetName = GetByNameParameterSet)]
        [ResourceNameCompleter("Microsoft.Network/networkManagers/verifierWorkspaces", "ResourceGroupName", "NetworkManagerName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string Name { get; set; }

        [Parameter(
             Mandatory = true,
             ParameterSetName = GetByNameParameterSet,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "The network manager name.")]
        [Parameter(
             Mandatory = true,
             ParameterSetName = ListParameterSet,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "The network manager name.")]
        [ResourceNameCompleter("Microsoft.Network/networkManagers", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string NetworkManagerName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = GetByNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = ListParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = GetByResourceIdParameterSet,
            HelpMessage = "The network verifier workspace id.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [Alias("VerifierWorkspaceId")]
        public string ResourceId { get; set; }

        public override void Execute()
        {
            base.Execute();

            try
            {
                if (this.ParameterSetName == GetByResourceIdParameterSet)
                {
                    ProcessByResourceId();
                }
                else if (this.ParameterSetName == GetByNameParameterSet)
                {
                    ProcessByName(expand: true);
                }
                else if (this.ParameterSetName == ListParameterSet)
                {
                    ProcessByName(expand: false);
                }
            }
            catch (Exception ex)
            {
                throw new PSInvalidOperationException($"An error occurred while executing the cmdlet: {ex.Message}", ex);
            }
        }

        private void ProcessByResourceId()
        {
            if (string.IsNullOrEmpty(this.ResourceId))
            {
                throw new PSArgumentNullException(nameof(this.ResourceId), "ResourceId cannot be null or empty.");
            }

            try
            {
                var parsedResourceId = new ResourceIdentifier(this.ResourceId);

                // Validate the format of the ResourceId
                var segments = parsedResourceId.ParentResource.Split('/');
                if (segments.Length < 2)
                {
                    throw new PSArgumentException("Invalid ResourceId format. Ensure the ResourceId is in the correct format.");
                }

                this.Name = parsedResourceId.ResourceName;
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.NetworkManagerName = segments[1];

                var verifierWorkspace = this.GetVerifierWorkspace(this.ResourceGroupName, this.NetworkManagerName, this.Name);
                WriteObject(verifierWorkspace);
            }
            catch (Exception ex)
            {
                throw new PSArgumentException($"Failed to parse ResourceId: {ex.Message}", nameof(this.ResourceId));
            }
        }

        private void ProcessByName(bool expand)
        {
            if (expand)
            {
                var verifierWorkspace = this.GetVerifierWorkspace(this.ResourceGroupName, this.NetworkManagerName, this.Name);
                verifierWorkspace.ResourceGroupName = this.ResourceGroupName;
                verifierWorkspace.NetworkManagerName = this.NetworkManagerName;
                WriteObject(verifierWorkspace);
            }
            else
            {
                ProcessAll();
            }
        }
        public void ProcessAll()
        {
            
                IPage<Management.Network.Models.VerifierWorkspace> verifierWorkspacePage;
                verifierWorkspacePage = this.VerifierWorkspaceClient.List(this.ResourceGroupName, this.NetworkManagerName);

                // Get all resources by polling on next page link
                var verifierWorkspaceList = ListNextLink<VerifierWorkspace>.GetAllResourcesByPollingNextLink(verifierWorkspacePage, this.VerifierWorkspaceClient.ListNext);

                var psVerifierWorkspaceList = new List<PSVerifierWorkspace>();

                foreach (var verifierWorkspace in verifierWorkspaceList)
                {
                    var psVerifierWorkspace = this.ToPsVerifierWorkspace(verifierWorkspace);
                    psVerifierWorkspace.ResourceGroupName = this.ResourceGroupName;
                    psVerifierWorkspace.NetworkManagerName = this.NetworkManagerName;
                    psVerifierWorkspaceList.Add(psVerifierWorkspace);
                }

                WriteObject(psVerifierWorkspaceList);
        }        
    }
}