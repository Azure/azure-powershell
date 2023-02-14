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
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerConnectivityConfiguration", SupportsShouldProcess = true), OutputType(typeof(PSNetworkManagerConnectivityConfiguration))]
    public class NewAzNetworkManagerConnectivityConfigurationCommand : NetworkManagerConnectivityConfigurationBaseCmdlet
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
           HelpMessage = "The network manager name.")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string NetworkManagerName { get; set; }

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
           HelpMessage = "Connectivity Group.")]
        public PSNetworkManagerConnectivityGroupItem[] AppliesToGroup { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Connectivity Topology. Valid values include 'HubAndSpoke' and 'Mesh'.")]
        [ValidateSet("HubAndSpoke", "Mesh", IgnoreCase = true)]
        public string ConnectivityTopology { get; set; }

        [Parameter(
         Mandatory = false,
         ValueFromPipelineByPropertyName = true,
         HelpMessage = "Description.")]
        public virtual string Description { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Hub Id list.")]
        public PSNetworkManagerHub[] Hub { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "DeleteExistingPeering Flag.")]
        public SwitchParameter DeleteExistingPeering { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "IsGlobal Flag.")]
        public SwitchParameter IsGlobal { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            var present = this.IsNetworkManagerConnectivityConfigurationPresent(this.ResourceGroupName, this.NetworkManagerName, this.Name);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
                () =>
                {
                    var networkManagerConnectivityConfiguration = this.CreateNetworkManagerConnectivityConfiguration();
                    WriteObject(networkManagerConnectivityConfiguration);
                },
                () => present);
        }

        private PSNetworkManagerConnectivityConfiguration CreateNetworkManagerConnectivityConfiguration()
        {
            var mncc = new PSNetworkManagerConnectivityConfiguration();
            mncc.Name = this.Name;
            mncc.ConnectivityTopology = this.ConnectivityTopology;

            if(this.ConnectivityTopology == "HubAndSpoke")
            {
                if (this.Hub != null)
                {
                    mncc.Hubs = this.Hub.ToList();
                }
                else
                {
                    throw new ArgumentException(string.Format(Microsoft.Azure.Commands.Network.Properties.Resources.HubRequiredForHubAndSpokeTopology));
                }
            }

            if(this.DeleteExistingPeering)
            {
                mncc.DeleteExistingPeering = "True";
            }
            else
            {
                mncc.DeleteExistingPeering = "False";
            }

            if (this.IsGlobal)
            {
                mncc.IsGlobal = "True";
            }
            else
            {
                mncc.IsGlobal = "False";
            }

            if (!string.IsNullOrEmpty(this.Description))
            {
                mncc.Description = this.Description;
            }


            mncc.AppliesToGroups = this.AppliesToGroup.ToList();

            // Map to the sdk object
            var mnccModel = NetworkResourceManagerProfile.Mapper.Map<MNM.ConnectivityConfiguration>(mncc);
            this.NullifyNetworkManagerConnectivityConfigurationIfAbsent(mnccModel);

            // Execute the Create NetworkConnectivityGroup call
            this.NetworkManagerConnectivityConfigurationClient.CreateOrUpdate(mnccModel, this.ResourceGroupName, this.NetworkManagerName, this.Name);
            var psNetworkManagerConnectivityConfiguration = this.GetNetworkManagerConnectivityConfiguration(this.ResourceGroupName, this.NetworkManagerName, this.Name);
            return psNetworkManagerConnectivityConfiguration;
        }
    }
}
