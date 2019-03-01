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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApplicationGatewaySku"), OutputType(typeof(PSApplicationGateway))]
    public class UpdateAzureApplicationGatewaySkuCommand : AzureApplicationGatewaySkuBase
    {
        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The applicationGateway")]
        public PSApplicationGateway ApplicationGateway { get; set; }

        [Parameter(
               Mandatory = false,
               HelpMessage = "The name of the SKU")]
        [ValidateSet("Standard_Small", "Standard_Medium", "Standard_Large", "WAF_Medium", "WAF_Large", "Standard_v2", "WAF_v2", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public override string Name { get; set; }

        [Parameter(
               Mandatory = false,
               HelpMessage = "Application gateway tier")]
        [ValidateSet("Standard", "WAF", "Standard_v2", "WAF_v2", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public override string Tier { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (!string.IsNullOrEmpty(this.Name))
            {
                this.ApplicationGateway.Sku.Name = this.Name;
            }

            if (!string.IsNullOrEmpty(this.Name))
            {
                this.ApplicationGateway.Sku.Tier = this.Tier;
            }

            if (MyInvocation.BoundParameters.ContainsKey(nameof(this.Capacity)))
            {
                this.ApplicationGateway.Sku.Capacity = this.Capacity;
            }

            WriteObject(this.ApplicationGateway);
        }
    }
}
