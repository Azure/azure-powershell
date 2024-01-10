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

using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    public class AzureApplicationGatewaySkuBase : NetworkBaseCmdlet
    {
        [Parameter(
               Mandatory = true,
               HelpMessage = "The name of the SKU")]
        [ValidateSet("Standard_Small", "Standard_Medium", "Standard_Large", "WAF_Medium", "WAF_Large", "Standard_v2", "WAF_v2", "Basic", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
               Mandatory = true,
               HelpMessage = "Application gateway tier")]
        [ValidateSet("Standard", "WAF", "Standard_v2", "WAF_v2", "Basic", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string Tier { get; set; }

        [Parameter(
               HelpMessage = "Application gateway instance count")]
        [ValidateNotNullOrEmpty]
        public int? Capacity { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
        }
    }
}
