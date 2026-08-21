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

using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System.Collections.Generic;
using System.Management.Automation;
using CNM = Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ExpressRouteLagLink"), OutputType(typeof(PSExpressRouteLagLink))]
    public partial class GetAzureRmExpressRouteLagLink : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group name of the express route LAG.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the express route LAG.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ExpressRouteLagName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the express route LAG link.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Name { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (!string.IsNullOrEmpty(this.Name) && !WildcardPattern.ContainsWildcardCharacters(this.Name))
            {
                var vLink = this.NetworkClient.NetworkManagementClient.ExpressRouteLags.LinksGet(this.ResourceGroupName, this.ExpressRouteLagName, this.Name);
                var psLink = NetworkResourceManagerProfile.Mapper.Map<CNM.PSExpressRouteLagLink>(vLink);
                WriteObject(psLink);
            }
            else
            {
                IPage<ExpressRouteLagLink> vLinkPage = this.NetworkClient.NetworkManagementClient.ExpressRouteLags.LinksList(this.ResourceGroupName, this.ExpressRouteLagName);
                var vLinkList = ListNextLink<ExpressRouteLagLink>.GetAllResourcesByPollingNextLink(vLinkPage,
                    this.NetworkClient.NetworkManagementClient.ExpressRouteLags.LinksListNext);
                List<PSExpressRouteLagLink> psLinkList = new List<PSExpressRouteLagLink>();
                foreach (var vLink in vLinkList)
                {
                    var psLink = NetworkResourceManagerProfile.Mapper.Map<CNM.PSExpressRouteLagLink>(vLink);
                    psLinkList.Add(psLink);
                }

                if (!string.IsNullOrEmpty(this.Name))
                {
                    WildcardPattern pattern = new WildcardPattern(this.Name, WildcardOptions.IgnoreCase);
                    psLinkList = psLinkList.FindAll(link => pattern.IsMatch(link.Name));
                }

                WriteObject(psLinkList, true);
            }
        }
    }
}
