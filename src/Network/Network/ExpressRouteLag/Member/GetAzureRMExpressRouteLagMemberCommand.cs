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
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ExpressRouteLagMember"), OutputType(typeof(PSExpressRouteLagMember))]
    public partial class GetAzureRmExpressRouteLagMember : NetworkBaseCmdlet
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

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the express route LAG link.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string LinkName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the express route LAG member.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Name { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (!string.IsNullOrEmpty(this.Name) && !WildcardPattern.ContainsWildcardCharacters(this.Name))
            {
                var vMember = this.NetworkClient.NetworkManagementClient.ExpressRouteLags.MembersGet(this.ResourceGroupName, this.ExpressRouteLagName, this.LinkName, this.Name);
                var psMember = NetworkResourceManagerProfile.Mapper.Map<CNM.PSExpressRouteLagMember>(vMember);
                WriteObject(psMember);
            }
            else
            {
                IPage<ExpressRouteLagMember> vMemberPage = this.NetworkClient.NetworkManagementClient.ExpressRouteLags.MembersList(this.ResourceGroupName, this.ExpressRouteLagName, this.LinkName);
                var vMemberList = ListNextLink<ExpressRouteLagMember>.GetAllResourcesByPollingNextLink(vMemberPage,
                    this.NetworkClient.NetworkManagementClient.ExpressRouteLags.MembersListNext);
                List<PSExpressRouteLagMember> psMemberList = new List<PSExpressRouteLagMember>();
                foreach (var vMember in vMemberList)
                {
                    var psMember = NetworkResourceManagerProfile.Mapper.Map<CNM.PSExpressRouteLagMember>(vMember);
                    psMemberList.Add(psMember);
                }

                if (!string.IsNullOrEmpty(this.Name))
                {
                    WildcardPattern pattern = new WildcardPattern(this.Name, WildcardOptions.IgnoreCase);
                    psMemberList = psMemberList.FindAll(member => pattern.IsMatch(member.Name));
                }

                WriteObject(psMemberList, true);
            }
        }
    }
}
