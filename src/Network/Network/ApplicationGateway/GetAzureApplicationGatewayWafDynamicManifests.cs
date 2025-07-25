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
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApplicationGatewayWafDynamicManifest"), OutputType(typeof(PSApplicationGatewayWafDynamicManifests))]
    public class GetAzureApplicationGatewayWafDynamicManifests : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The location.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            var wafDynamicManifests = this.NetworkClient.NetworkManagementClient.ApplicationGatewayWafDynamicManifests.Get(Location);
            PSApplicationGatewayWafDynamicManifests pswafDynamicManifests;
            var wafDynamicManifest = wafDynamicManifests.First();
            pswafDynamicManifests = NetworkResourceManagerProfile.Mapper.Map<PSApplicationGatewayWafDynamicManifests>(wafDynamicManifest);
            pswafDynamicManifests.DefaultRuleSetVersion = wafDynamicManifest.RuleSetVersion;
            pswafDynamicManifests.DefaultRuleSetType = wafDynamicManifest.RuleSetType;
            WriteObject(pswafDynamicManifests);
        }
    }
}