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
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Linq;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkVirtualApplianceSku"), OutputType(typeof(PSNetworkVirtualApplianceSku))]
    public class GetVirtualApplianceSkuCommand : VirtualApplianceSkuBaseCmdlet
    {
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = "The Sku name.",
            ParameterSetName = "ResourceName")]
        [ValidateNotNullOrEmpty]
        public virtual string SkuName  { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (ShouldGetByName(this.SkuName))
            {
                var sku = this.GetVirtualApplianceSku(this.SkuName);
                WriteObject(sku);
            }
            else
            {
                IPage<NetworkVirtualApplianceSku> skuPage;
                skuPage = this.VirtualApplianceSkusClient.List();
                // Get all resources by polling on next page link
                var skuList = ListNextLink<NetworkVirtualApplianceSku>.GetAllResourcesByPollingNextLink(skuPage, this.VirtualApplianceSkusClient.ListNext);
                var psSkus = new List<PSNetworkVirtualApplianceSku>();
                foreach (var sku in skuList)
                {
                    var psSku = this.ToPsNetworkVirtualApplianceSku(sku);
                    psSkus.Add(psSku);
                }
                WriteObject(Filter(this.SkuName, psSkus), true);
            }
        }

        private bool ShouldGetByName(string name)
        {
            return !string.IsNullOrEmpty(name) && !WildcardPattern.ContainsWildcardCharacters(name);
        }

        private List<PSNetworkVirtualApplianceSku> Filter(string skuname, List<PSNetworkVirtualApplianceSku> resources)
        {
            if (!string.IsNullOrEmpty(skuname))
            {
                WildcardPattern pattern = new WildcardPattern(skuname, WildcardOptions.IgnoreCase);
                var tmp = resources.Where(p => pattern.IsMatch(p.Vendor)).ToList();
                return tmp;
            }
            return resources;
        }
    }
}
