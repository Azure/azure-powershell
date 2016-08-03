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
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, "AzureRmExpressRouteCircuit", SupportsShouldProcess = true),
        OutputType(typeof(PSExpressRouteCircuit))]
    public class NewAzureExpressRouteCircuitCommand : ExpressRouteCircuitBaseCmdlet
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
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
         Mandatory = true,
         ValueFromPipelineByPropertyName = true,
         HelpMessage = "location.")]
        [ValidateNotNullOrEmpty]
        public virtual string Location { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true)]
        [ValidateSet(
            MNM.ExpressRouteCircuitSkuTier.Standard,
            MNM.ExpressRouteCircuitSkuTier.Premium,
            IgnoreCase = true)]
        public string SkuTier { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true)]
        [ValidateSet(
            MNM.ExpressRouteCircuitSkuFamily.MeteredData,
            MNM.ExpressRouteCircuitSkuFamily.UnlimitedData,
            IgnoreCase = true)]
        public string SkuFamily { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        public string ServiceProviderName { get; set; }

        [Parameter(
             Mandatory = true,
             ValueFromPipelineByPropertyName = true)]
        public string PeeringLocation { get; set; }

        [Parameter(
             Mandatory = true,
             ValueFromPipelineByPropertyName = true)]
        public int BandwidthInMbps { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public List<PSPeering> Peering { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public List<PSExpressRouteCircuitAuthorization> Authorization { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public bool? AllowClassicOperations { get; set; }


        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overrite a resource")]
        public SwitchParameter Force { get; set; }

        public override void Execute()
        {
            WriteWarning("The output object type of this cmdlet will be modified in a future release.");
            var present = this.IsExpressRouteCircuitPresent(this.ResourceGroupName, this.Name);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
                () =>
                {
                    var expressRouteCircuit = CreateExpressRouteCircuit();
                    WriteObject(expressRouteCircuit);
                },
                () => present);

        }

        private PSExpressRouteCircuit CreateExpressRouteCircuit()
        {
            base.Execute();
            var circuit = new PSExpressRouteCircuit();
            circuit.Name = this.Name;
            circuit.ResourceGroupName = this.ResourceGroupName;
            circuit.Location = this.Location;

            // Construct sku
            if (!string.IsNullOrEmpty(this.SkuTier))
            {
                circuit.Sku = new PSExpressRouteCircuitSku();
                circuit.Sku.Tier = this.SkuTier;
                circuit.Sku.Family = this.SkuFamily;
                circuit.Sku.Name = this.SkuTier + "_" + this.SkuFamily;
            }

            // construct the service provider properties
            if (!string.IsNullOrEmpty(this.ServiceProviderName))
            {
                circuit.ServiceProviderProperties = new PSServiceProviderProperties();
                circuit.ServiceProviderProperties.ServiceProviderName = this.ServiceProviderName;
                circuit.ServiceProviderProperties.PeeringLocation = this.PeeringLocation;
                circuit.ServiceProviderProperties.BandwidthInMbps = this.BandwidthInMbps;
            }

            circuit.Peerings = this.Peering;
            circuit.Authorizations = this.Authorization;
            circuit.AllowClassicOperations = this.AllowClassicOperations;

            // Map to the sdk object
            var circuitModel = Mapper.Map<MNM.ExpressRouteCircuit>(circuit);
            circuitModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

            // Execute the Create ExpressRouteCircuit call
            this.ExpressRouteCircuitClient.CreateOrUpdate(this.ResourceGroupName, this.Name, circuitModel);

            var getExpressRouteCircuit = this.GetExpressRouteCircuit(this.ResourceGroupName, this.Name);
            return getExpressRouteCircuit;
        }
    }
}
