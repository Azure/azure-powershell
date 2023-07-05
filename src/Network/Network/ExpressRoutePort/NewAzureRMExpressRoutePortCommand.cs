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

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ExpressRoutePort", SupportsShouldProcess = true, DefaultParameterSetName = ResourceNameParameterSet), OutputType(typeof(PSExpressRoutePort))]
    public partial class NewAzureRmExpressRoutePort : NetworkBaseCmdlet
    {
        private const string ResourceIdParameterSet = "ResourceIdParameterSet";
        private const string ResourceNameParameterSet = "ResourceNameParameterSet";

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            Mandatory = true,
            HelpMessage = "ResourceId of the express route port.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            ParameterSetName = ResourceNameParameterSet,
            Mandatory = true,
            HelpMessage = "The resource group name of the express route port.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            ParameterSetName = ResourceNameParameterSet,
            Mandatory = true,
            HelpMessage = "The name of the express route port.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the peering location that the ExpressRoutePort is mapped to physically.",
            ValueFromPipelineByPropertyName = true)]
        public string PeeringLocation { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Bandwidth of procured ports in Gbps",
            ValueFromPipelineByPropertyName = true)]
        public int BandwidthInGbps { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Encapsulation method on physical ports.",
            ValueFromPipelineByPropertyName = true)]
        [PSArgumentCompleter(
            "Dot1Q",
            "QinQ"
        )]
        public string Encapsulation { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The location.",
            ValueFromPipelineByPropertyName = true)]
        [LocationCompleter("Microsoft.Network/expressRoutePorts")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable which represents resource tags.",
            ValueFromPipelineByPropertyName = true)]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The set of physical links of the ExpressRoutePort resource",
            ValueFromPipelineByPropertyName = true)]
        public PSExpressRouteLink[] Link { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "User Assigned Identity for reading MacSec configuration")]
        public PSManagedServiceIdentity Identity { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The Billing Model of the ExpressRoutePort resource.",
            ValueFromPipelineByPropertyName = true)]
        [PSArgumentCompleter(
            "MeteredData",
            "UnlimitedData"
        )]
        public string BillingType { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (string.Equals(this.ParameterSetName, ResourceIdParameterSet, StringComparison.OrdinalIgnoreCase))
            {
                var resourceInfo = new ResourceIdentifier(ResourceId);
                ResourceGroupName = resourceInfo.ResourceGroupName;
                Name = resourceInfo.ResourceName;
            }

            var vExpressRoutePort = new PSExpressRoutePort
            {
                PeeringLocation = this.PeeringLocation,
                BandwidthInGbps = this.BandwidthInGbps,
                Encapsulation = this.Encapsulation,
                Location = this.Location,
                Links = this.Link?.ToList(),
                BillingType = this.BillingType
            };

            if (this.Identity != null)
            {
                vExpressRoutePort.Identity = this.Identity;
            }

            var vExpressRoutePortModel = NetworkResourceManagerProfile.Mapper.Map<MNM.ExpressRoutePort>(vExpressRoutePort);
            vExpressRoutePortModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);
            var present = true;
            try
            {
                this.NetworkClient.NetworkManagementClient.ExpressRoutePorts.Get(this.ResourceGroupName, this.Name);
            }
            catch (Microsoft.Rest.Azure.CloudException exception)
            {
                if (exception.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    // Resource is not present
                    present = false;
                }
                else
                {
                    throw;
                }
            }

            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
            () =>
            {
                this.NetworkClient.NetworkManagementClient.ExpressRoutePorts.CreateOrUpdate(this.ResourceGroupName, this.Name, vExpressRoutePortModel);
                var getExpressRoutePort = this.NetworkClient.NetworkManagementClient.ExpressRoutePorts.Get(this.ResourceGroupName, this.Name);
                var psExpressRoutePort = NetworkResourceManagerProfile.Mapper.Map<PSExpressRoutePort>(getExpressRoutePort);
                psExpressRoutePort.ResourceGroupName = this.ResourceGroupName;
                psExpressRoutePort.Tag = TagsConversionHelper.CreateTagHashtable(getExpressRoutePort.Tags);
                WriteObject(psExpressRoutePort, true);
            },
            () => present);

        }
    }
}
