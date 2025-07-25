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

namespace Microsoft.Azure.Commands.Network.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    using Microsoft.Azure.Commands.Network.Bastion;
    using Microsoft.Azure.Commands.Network.Models.Bastion;
    using Microsoft.WindowsAzure.Commands.Common.Attributes;
    using Newtonsoft.Json;

    public class PSBastion : PSTopLevelResource
    {
        public PSBastion()
        {
            Sku = new PSBastionSku();
            ScaleUnit = Constants.MinimumScaleUnits;
            EnableKerberos = false;
            DisableCopyPaste = false;
            EnableTunneling = false;
            EnableIpConnect = false;
            EnableShareableLink = false;
            EnableSessionRecording = false;
        }

        public PSBastion(string name, string rgName, string location, string sku = null)
        {
            Name = name;
            ResourceGroupName = rgName;
            Location = location;
            Sku = new PSBastionSku(sku);
            ScaleUnit = Constants.MinimumScaleUnits;
            EnableKerberos = false;
            DisableCopyPaste = false;
            EnableTunneling = false;
            EnableIpConnect = false;
            EnableShareableLink = false;
            EnableSessionRecording = false;
        }

        public List<PSBastionIPConfiguration> IpConfigurations { get; set; }

        public string DnsName { get; set; }

        public string ProvisioningState { get; set; }

        [Ps1Xml(Label = "Sku Name", Target = ViewControl.List, ScriptBlock = "$_.Sku.Name")]
        [DefaultValue(PSBastionSku.Standard)]
        public PSBastionSku Sku { get; set; }

        [Ps1Xml(Label = "Scale Units", Target = ViewControl.List)]
        [DefaultValue(2)]
        public int? ScaleUnit { get; set; }

        [Ps1Xml(Label = "Kerberos", Target = ViewControl.List)]
        [DefaultValue(false)]
        public bool? EnableKerberos { get; set; }

        [Ps1Xml(Label = "Copy and Paste", Target = ViewControl.List)]
        [DefaultValue(false)]
        public bool? DisableCopyPaste { get; set; }

        [Ps1Xml(Label = "Native Client", Target = ViewControl.List)]
        [DefaultValue(false)]
        public bool? EnableTunneling { get; set; }

        [Ps1Xml(Label = "IP Connect", Target = ViewControl.List)]
        [DefaultValue(false)]
        public bool? EnableIpConnect { get; set; }

        [Ps1Xml(Label = "Shareable Link", Target = ViewControl.List)]
        [DefaultValue(false)]
        public bool? EnableShareableLink { get; set; }

        [Ps1Xml(Label = "Session Recording", Target = ViewControl.List)]
        [DefaultValue(false)]
        public bool? EnableSessionRecording { get; set; }

        [JsonIgnore]
        public string IpConfigurationsText
        {
            get { return JsonConvert.SerializeObject(IpConfigurations, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string SkuText
        {
            get { return JsonConvert.SerializeObject(Sku, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        public void Allocate(PSVirtualNetwork virtualNetwork, PSPublicIpAddress publicIpAddress)
        {
            if (virtualNetwork == null)
            {
                throw new ArgumentNullException(nameof(virtualNetwork), "Virtual Network cannot be null!");
            }

            if (publicIpAddress == null)
            {
                throw new ArgumentNullException(nameof(publicIpAddress), "Public IP Addresses cannot be null or empty!");
            }

            //proper error message 
            PSSubnet BastionSubnet = null;
            try
            {
                BastionSubnet = virtualNetwork.Subnets.Single(subnet => Constants.BastionSubnetName.Equals(subnet.Name, StringComparison.OrdinalIgnoreCase));
            }

            catch (InvalidOperationException)
            {
                throw new ArgumentException($"Virtual Network {virtualNetwork.Name} should contain a Subnet named {Constants.BastionSubnetName}");
            }

            IpConfigurations = new List<PSBastionIPConfiguration>
            {
                new PSBastionIPConfiguration
                {
                    Name = Constants.BastionIpConfigurationName,
                    PublicIpAddress = new PSResourceId { Id = publicIpAddress.Id },
                }
            };

            IpConfigurations[0].Subnet = new PSResourceId { Id = BastionSubnet.Id };
        }

        public void Deallocate()
        {
            IpConfigurations = new List<PSBastionIPConfiguration>();
        }
    }
}
