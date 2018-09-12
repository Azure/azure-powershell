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

using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirewallFqdnTag"), OutputType(typeof(PSAzureFirewallFqdnTag), typeof(IEnumerable<PSAzureFirewallFqdnTag>))]
    public class GetAzureFirewallFqdnTagCommand : NetworkBaseCmdlet
    {
        private IAzureFirewallFqdnTagsOperations AzureFirewallFqdnTagClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.AzureFirewallFqdnTags;
            }
        }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            IPage<AzureFirewallFqdnTag> azureFirewallFqdnTagPage = this.AzureFirewallFqdnTagClient.ListAll();

            // Get all resources by polling on next page link
            var azfwFqdnTagsResponseLIst = ListNextLink<AzureFirewallFqdnTag>.GetAllResourcesByPollingNextLink(azureFirewallFqdnTagPage, this.AzureFirewallFqdnTagClient.ListAllNext);

            var psAzureFirewallFqdnTags = azfwFqdnTagsResponseLIst.Select(ToPsAzureFirewallFqdnTag).ToList();

            WriteObject(psAzureFirewallFqdnTags, true);
        }

        public PSAzureFirewallFqdnTag ToPsAzureFirewallFqdnTag(AzureFirewallFqdnTag fqdnTag)
        {
            var azfwFqdnTag = NetworkResourceManagerProfile.Mapper.Map<PSAzureFirewallFqdnTag>(fqdnTag);

            azfwFqdnTag.Tag = TagsConversionHelper.CreateTagHashtable(fqdnTag.Tags);

            return azfwFqdnTag;
        }
    }
}
