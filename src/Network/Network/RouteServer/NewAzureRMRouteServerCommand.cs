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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RouteServer", SupportsShouldProcess = true, DefaultParameterSetName = RouteServerParameterSetNames.ByRouteServerName), OutputType(typeof(PSRouteServer))]
    public partial class NewAzureRmRouteServer : RouteServerBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group name of the route server.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the route server.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string RouteServerName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The subnet where the route server is hosted.")]
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
                this.NetworkClient.NetworkManagementClient.VirtualHubs.Get(this.ResourceGroupName, this.RouteServerName);
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
                throw new PSArgumentException(string.Format(Properties.Resources.ResourceAlreadyPresentInResourceGroup, this.RouteServerName, this.ResourceGroupName));
            }


            ConfirmAction(
                Properties.Resources.CreatingResourceMessage,
                RouteServerName,
                () =>
                {
                    WriteVerbose(String.Format(Properties.Resources.CreatingLongRunningOperationMessage, this.ResourceGroupName, this.RouteServerName));
                    PSVirtualHub virtualHub = new PSVirtualHub
                    {
                        ResourceGroupName = this.ResourceGroupName,
                        Name = this.RouteServerName,
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

                    this.NetworkClient.NetworkManagementClient.VirtualHubs.CreateOrUpdate(this.ResourceGroupName, this.RouteServerName, virtualHubModel);
                    this.NetworkClient.NetworkManagementClient.VirtualHubIpConfiguration.CreateOrUpdate(this.ResourceGroupName, this.RouteServerName, ipConfigName, ipconfig);
                    virtualHubModel = this.NetworkClient.NetworkManagementClient.VirtualHubs.Get(this.ResourceGroupName, this.RouteServerName);

                    virtualHub = NetworkResourceManagerProfile.Mapper.Map<PSVirtualHub>(virtualHubModel);
                    virtualHub.ResourceGroupName = this.ResourceGroupName;
                    AddIpConfigurtaionToPSVirtualHub(virtualHub, this.ResourceGroupName, this.RouteServerName, ipConfigName);

                    var routeServerModel = new PSRouteServer(virtualHub);
                    routeServerModel.Tag = TagsConversionHelper.CreateTagHashtable(virtualHubModel.Tags);
                    WriteObject(routeServerModel, true);
                });

        }
    }
}