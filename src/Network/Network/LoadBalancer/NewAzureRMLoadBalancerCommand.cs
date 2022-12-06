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
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using AutoMapper;
using MNM = Microsoft.Azure.Management.Network.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.Network
{
    [GenericBreakingChange("It is recommended to use parameter '-Sku Standard' to create new Load Balancer. Please note that it will become the default behavior for Load Balancer creation in the future.")]
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "LoadBalancer", SupportsShouldProcess = true), OutputType(typeof(PSLoadBalancer))]
    public partial class NewAzureRmLoadBalancer : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group name of the load balancer.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the load balancer.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The location.",
            ValueFromPipelineByPropertyName = true)]
        [LocationCompleter("Microsoft.Network/loadBalancers")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable which represents resource tags.",
            ValueFromPipelineByPropertyName = true)]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Name of a load balancer SKU.",
            ValueFromPipelineByPropertyName = true)]
        [PSArgumentCompleter(
            "Basic",
            "Standard"
        )]
        public string Sku { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Name of a load balancer tier.",
            ValueFromPipelineByPropertyName = true)]
        [PSArgumentCompleter(
            "Regional",
            "Global"
        )]
        public string Tier { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Object representing the frontend IPs to be used for the load balancer",
            ValueFromPipelineByPropertyName = true)]
        public PSFrontendIPConfiguration[] FrontendIpConfiguration { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Collection of backend address pools used by a load balancer",
            ValueFromPipelineByPropertyName = true)]
        public PSBackendAddressPool[] BackendAddressPool { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Object collection representing the load balancing rules Gets the provisioning ",
            ValueFromPipelineByPropertyName = true)]
        public PSLoadBalancingRule[] LoadBalancingRule { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Collection of probe objects used in the load balancer",
            ValueFromPipelineByPropertyName = true)]
        public PSProbe[] Probe { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Collection of inbound NAT Rules used by a load balancer. Defining inbound NAT rules on your load balancer is mutually exclusive with defining an inbound NAT pool. Inbound NAT pools are referenced from virtual machine scale sets. NICs that are associated with individual virtual machines cannot reference an Inbound NAT pool. They have to reference individual inbound NAT rules.",
            ValueFromPipelineByPropertyName = true)]
        public PSInboundNatRule[] InboundNatRule { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Defines an external port range for inbound NAT to a single backend port on NICs associated with a load balancer. Inbound NAT rules are created automatically for each NIC associated with the Load Balancer using an external port from this range. Defining an Inbound NAT pool on your Load Balancer is mutually exclusive with defining inbound Nat rules. Inbound NAT pools are referenced from virtual machine scale sets. NICs that are associated with individual virtual machines cannot reference an inbound NAT pool. They have to reference individual inbound NAT rules.",
            ValueFromPipelineByPropertyName = true)]
        public PSInboundNatPool[] InboundNatPool { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The outbound rules.",
            ValueFromPipelineByPropertyName = true)]
        public PSOutboundRule[] OutboundRule { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The edge zone of the load balancer")]
        public string EdgeZone { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        private bool IsResourceReference(Type t)
        {
            return t.Equals(typeof(PSResourceId)) || t.IsSubclassOf(typeof(PSResourceId));
        }

        private void NormalizeChildIds(object inputItem)
        {
            foreach (var item in inputItem.GetType().GetProperties())
            {
                var value = item.GetValue(inputItem);
                if (value != null && value.ToString() != "null")
                {
                    var valueType = value.GetType();
                    if (item.Name == "Id")
                    {
                        string outValue = value.ToString().Replace(
                            "/resourceGroups/" + Microsoft.Azure.Commands.Network.Properties.Resources.ResourceGroupNotSet,
                            "/resourceGroups/" + this.ResourceGroupName);

                        outValue = outValue.Replace(
                            "/loadBalancers/" + Microsoft.Azure.Commands.Network.Properties.Resources.LoadBalancerNameNotSet,
                            "/loadBalancers/" + this.Name);

                        item.SetValue(inputItem, outValue);
                    }
                    else if (value is IList)
                    {
                        if (IsResourceReference(valueType.GetGenericArguments()[0]))
                        {
                            foreach (var listItem in (IList)value)
                            {
                                NormalizeChildIds(listItem);
                            }
                        }
                    }
                    else if (IsResourceReference(valueType))
                    {
                        NormalizeChildIds(value);
                    }
                }
            }
        }

        public override void Execute()
        {
            base.Execute();

            // Sku
            PSLoadBalancerSku vSku = null;

            if (this.Sku != null)
            {
                if (vSku == null)
                {
                    vSku = new PSLoadBalancerSku();
                }
                vSku.Name = this.Sku;
            }

            // Tier
            if (this.Tier != null)
            {
                if (vSku == null)
                {
                    vSku = new PSLoadBalancerSku();
                }
                vSku.Tier = this.Tier;
            }

            var vLoadBalancer = new PSLoadBalancer
            {
                Location = this.Location,
                FrontendIpConfigurations = this.FrontendIpConfiguration?.ToList(),
                BackendAddressPools = this.BackendAddressPool?.ToList(),
                LoadBalancingRules = this.LoadBalancingRule?.ToList(),
                Probes = this.Probe?.ToList(),
                InboundNatRules = this.InboundNatRule?.ToList(),
                InboundNatPools = this.InboundNatPool?.ToList(),
                OutboundRules = this.OutboundRule?.ToList(),
                Sku = vSku,
                ExtendedLocation = string.IsNullOrEmpty(this.EdgeZone) ? null : new PSExtendedLocation(this.EdgeZone)
            };

            NormalizeChildIds(vLoadBalancer);

            var vLoadBalancerModel = NetworkResourceManagerProfile.Mapper.Map<MNM.LoadBalancer>(vLoadBalancer);
            vLoadBalancerModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);
            var present = true;
            try
            {
                this.NetworkClient.NetworkManagementClient.LoadBalancers.Get(this.ResourceGroupName, this.Name);
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

            List<string> resourceIdsRequiringAuthToken = new List<string>();
            Dictionary<string, List<string>> auxAuthHeader = null;

            // Get aux token for each gateway lb references
            foreach (FrontendIPConfiguration frontend in vLoadBalancerModel.FrontendIPConfigurations)
            {
                if (frontend.GatewayLoadBalancer != null)
                {
                    //Get the aux header for the remote vnet
                    resourceIdsRequiringAuthToken.Add(frontend.GatewayLoadBalancer.Id);
                }
            }

            if (resourceIdsRequiringAuthToken.Count > 0)
            {
                var auxHeaderDictionary = GetAuxilaryAuthHeaderFromResourceIds(resourceIdsRequiringAuthToken);
                if (auxHeaderDictionary != null && auxHeaderDictionary.Count > 0)
                {
                    auxAuthHeader = new Dictionary<string, List<string>>(auxHeaderDictionary);
                }
            }


            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
            () =>
            {
                this.NetworkClient.NetworkManagementClient.LoadBalancers.CreateOrUpdateWithHttpMessagesAsync(this.ResourceGroupName, this.Name, vLoadBalancerModel, auxAuthHeader).GetAwaiter().GetResult();
                var getLoadBalancer = this.NetworkClient.NetworkManagementClient.LoadBalancers.Get(this.ResourceGroupName, this.Name);
                var psLoadBalancer = NetworkResourceManagerProfile.Mapper.Map<PSLoadBalancer>(getLoadBalancer);
                psLoadBalancer.ResourceGroupName = this.ResourceGroupName;
                psLoadBalancer.Tag = TagsConversionHelper.CreateTagHashtable(getLoadBalancer.Tags);
                WriteObject(psLoadBalancer, true);
            },
            () => present);

        }
    }
}
