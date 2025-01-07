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

using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.Network.Models.NetworkManager;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManager", SupportsShouldProcess = true), OutputType(typeof(PSNetworkManager))]
    public class NewAzNetworkManagerCommand : NetworkManagerBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
         Mandatory = true,
         ValueFromPipelineByPropertyName = true,
         HelpMessage = "location.")]
        [LocationCompleter("Microsoft.Network/networkManagers")]
        [ValidateNotNullOrEmpty]
        public virtual string Location { get; set; }

        [Parameter(
         Mandatory = false,
         ValueFromPipelineByPropertyName = true,
         HelpMessage = "Description.")]
        public virtual string Description { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Network Manager Scope")]
        public PSNetworkManagerScopes NetworkManagerScope { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Network Manager Scope Access. Valid values include 'SecurityAdmin' and 'Connectivity'.")]
        public NetworkManagerScopeAccessType[] NetworkManagerScopeAccess { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public enum NetworkManagerScopeAccessType
        {
            SecurityAdmin,
            Connectivity,
            Routing,
            SecurityUser
        }

        public override void Execute()
        {
            base.Execute();
            var present = this.IsNetworkManagerPresent(this.ResourceGroupName, this.Name);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
                () =>
                {
                    var networkManager = this.CreateNetworkManager();
                    WriteObject(networkManager);
                },
                () => present);
        }

        private PSNetworkManager CreateNetworkManager()
        {
            var networkManager = new PSNetworkManager();
            networkManager.Name = this.Name;
            networkManager.Location = this.Location;
            networkManager.NetworkManagerScopes = this.NetworkManagerScope;

            networkManager.NetworkManagerScopeAccesses = new List<string>();
            if (this.NetworkManagerScopeAccess != null)
            {
                foreach (NetworkManagerScopeAccessType accessType in this.NetworkManagerScopeAccess)
                {
                    networkManager.NetworkManagerScopeAccesses.Add(accessType.ToString());
                }
            }
            if (!string.IsNullOrEmpty(this.Description))
            {
                networkManager.Description = this.Description;
            }

            // Map to the sdk object
            var networkManagerModel = NetworkResourceManagerProfile.Mapper.Map<MNM.NetworkManager>(networkManager);
            this.NullifyNetworkManagerIfAbsent(networkManagerModel);
            networkManagerModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

            // Execute the Create Network call
            this.NetworkManagerClient.CreateOrUpdate(this.ResourceGroupName, this.Name, networkManagerModel);
            var psNetworkManager = this.GetNetworkManager(this.ResourceGroupName, this.Name);
            return psNetworkManager;
        }
    }
}