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
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;
using System.Linq;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ExpressRouteLag", SupportsShouldProcess = true, DefaultParameterSetName = ResourceNameParameterSet), OutputType(typeof(PSExpressRouteLag))]
    public partial class NewAzureRmExpressRouteLag : NetworkBaseCmdlet
    {
        private const string ResourceIdParameterSet = "ResourceIdParameterSet";
        private const string ResourceNameParameterSet = "ResourceNameParameterSet";

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            Mandatory = true,
            HelpMessage = "ResourceId of the express route LAG.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            ParameterSetName = ResourceNameParameterSet,
            Mandatory = true,
            HelpMessage = "The resource group name of the express route LAG.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            ParameterSetName = ResourceNameParameterSet,
            Mandatory = true,
            HelpMessage = "The name of the express route LAG.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the peering location that the ExpressRouteLag is mapped to physically.",
            ValueFromPipelineByPropertyName = true)]
        public string PeeringLocation { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Bandwidth of the ExpressRouteLag in Gbps.",
            ValueFromPipelineByPropertyName = true)]
        public int BandwidthInGbps { get; set; }

        [Parameter(
            Mandatory = false,
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
        [LocationCompleter("Microsoft.Network/expressRouteLags")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The number of ports in the ExpressRouteLag.",
            ValueFromPipelineByPropertyName = true)]
        public int? NumberOfPorts { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The minimum number of active ports required in the ExpressRouteLag.",
            ValueFromPipelineByPropertyName = true)]
        public int? MinimumActivePortsRequired { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The LACP timer for the ExpressRouteLag.",
            ValueFromPipelineByPropertyName = true)]
        [PSArgumentCompleter(
            "Fast",
            "Slow"
        )]
        public string LacpTimer { get; set; }

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

        [Parameter(
           Mandatory = false,
           HelpMessage = "User Assigned Identity for reading MacSec configuration")]
        public PSManagedServiceIdentity Identity { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The Billing Model of the ExpressRouteLag resource.",
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

            var vExpressRouteLag = new PSExpressRouteLag
            {
                PeeringLocation = this.PeeringLocation,
                BandwidthInGbps = this.BandwidthInGbps,
                Encapsulation = this.Encapsulation,
                Location = this.Location,
                NumberOfPorts = this.NumberOfPorts,
                MinimumActivePortsRequired = this.MinimumActivePortsRequired,
                LacpTimer = this.LacpTimer,
                BillingType = this.BillingType
            };

            if (this.Identity != null)
            {
                vExpressRouteLag.Identity = this.Identity;
            }

            var vExpressRouteLagModel = NetworkResourceManagerProfile.Mapper.Map<MNM.ExpressRouteLag>(vExpressRouteLag);
            vExpressRouteLagModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);
            var present = true;
            try
            {
                this.NetworkClient.NetworkManagementClient.ExpressRouteLags.Get(this.ResourceGroupName, this.Name);
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
                this.NetworkClient.NetworkManagementClient.ExpressRouteLags.CreateOrUpdate(this.ResourceGroupName, this.Name, vExpressRouteLagModel);
                var getExpressRouteLag = this.NetworkClient.NetworkManagementClient.ExpressRouteLags.Get(this.ResourceGroupName, this.Name);
                var psExpressRouteLag = NetworkResourceManagerProfile.Mapper.Map<PSExpressRouteLag>(getExpressRouteLag);
                psExpressRouteLag.ResourceGroupName = this.ResourceGroupName;
                psExpressRouteLag.Tag = TagsConversionHelper.CreateTagHashtable(getExpressRouteLag.Tags);
                WriteObject(psExpressRouteLag, true);
            },
            () => present);
        }
    }
}
