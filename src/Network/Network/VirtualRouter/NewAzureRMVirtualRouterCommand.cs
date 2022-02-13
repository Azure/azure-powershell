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

using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using System.Net;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;
using System.Linq;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.Network
{
    [CmdletDeprecation(ReplacementCmdletName = "New-AzRouteServer")]
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualRouter", SupportsShouldProcess = true, DefaultParameterSetName = VirtualRouterParameterSetNames.ByVirtualRouterName), OutputType(typeof(PSVirtualRouter))]
    public partial class NewAzureRmVirtualRouter : VirtualRouterBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group name of the virtual router.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the virtual router.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The subnet where the virtual router is hosted.")]
        [ValidateNotNullOrEmpty]
        public string HostedSubnet { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The location.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable which represents resource tags.",
            ValueFromPipelineByPropertyName = true)]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            
            var present = true;
            try
            {
                this.NetworkClient.NetworkManagementClient.VirtualHubs.Get(this.ResourceGroupName, this.Name);
            }
            catch (Exception ex)
            {
                if (ex is Microsoft.Azure.Management.Network.Models.ErrorException || ex is Rest.Azure.CloudException)
                {
                    // Resource is not present
                    present = false;
                }
                else
                {
                    throw;
                }
            }

            if (present)
            {
                throw new PSArgumentException(string.Format(Properties.Resources.ResourceAlreadyPresentInResourceGroup, this.Name, this.ResourceGroupName));
            }
            

            ConfirmAction(
                Properties.Resources.CreatingResourceMessage,
                Name,
                () =>
                {
                    WriteVerbose(String.Format(Properties.Resources.CreatingLongRunningOperationMessage, this.ResourceGroupName, this.Name));
                    PSVirtualHub virtualHub = new PSVirtualHub
                    {
                        ResourceGroupName = this.ResourceGroupName,
                        Name = this.Name,
                        Location = this.Location
                    };

                    virtualHub.RouteTables = new List<PSVirtualHubRouteTable>();
                    string ipConfigName = "ipconfig1";
                    HubIpConfiguration ipconfig = new HubIpConfiguration
                    {
                        Subnet = new Subnet() { Id = this.HostedSubnet }
                    };

                    var virtualHubModel = NetworkResourceManagerProfile.Mapper.Map<MNM.VirtualHub>(virtualHub);
                    virtualHubModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);
                    virtualHubModel.Sku = "Standard";

                    this.NetworkClient.NetworkManagementClient.VirtualHubs.CreateOrUpdate(this.ResourceGroupName, this.Name, virtualHubModel);
                    this.NetworkClient.NetworkManagementClient.VirtualHubIpConfiguration.CreateOrUpdate(this.ResourceGroupName, this.Name, ipConfigName, ipconfig);
                    virtualHubModel = this.NetworkClient.NetworkManagementClient.VirtualHubs.Get(this.ResourceGroupName, this.Name);

                    virtualHub = NetworkResourceManagerProfile.Mapper.Map<PSVirtualHub>(virtualHubModel);
                    virtualHub.ResourceGroupName = this.ResourceGroupName;
                    AddIpConfigurtaionToPSVirtualHub(virtualHub, this.ResourceGroupName, this.Name, ipConfigName);
                   
                    var virtualRouter = new PSVirtualRouter(virtualHub);
                    virtualRouter.Tag = TagsConversionHelper.CreateTagHashtable(virtualHubModel.Tags);
                    WriteObject(virtualRouter, true);
                });

        }
    }
}