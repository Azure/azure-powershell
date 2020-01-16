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
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Commands.CosmosDB.Helpers;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBVirtualNetworkRule"), OutputType(typeof(PSVirtualNetworkRule))]
    public class NewAzCosmosDBVirtualNetworkRule : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = Constants.VirtualNetworkRuleIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.IgnoreMissingVNetServiceEndpointHelpMessage)]
        public bool? IgnoreMissingVNetServiceEndpoint { get; set; }

        public override void ExecuteCmdlet()
        {
            PSVirtualNetworkRule virtualNetworkRule = new PSVirtualNetworkRule
            {
                Id = Id,
                IgnoreMissingVNetServiceEndpoint = IgnoreMissingVNetServiceEndpoint
            };

            WriteObject(virtualNetworkRule);
            return;
        }
    }
}
