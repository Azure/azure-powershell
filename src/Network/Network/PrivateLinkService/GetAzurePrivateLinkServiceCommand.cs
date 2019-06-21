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
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PrivateLinkService", DefaultParameterSetName = "NoExpand"), OutputType(typeof(PSPrivateLinkService))]
    public class GetAzurePrivateLinkService : PrivateLinkServiceBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.",
            ParameterSetName = "NoExpand")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource name.",
           ParameterSetName = "Expand")]
        [ResourceNameCompleter("Microsoft.Network/privateLinkServices", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.",
            ParameterSetName = "NoExpand")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.",
           ParameterSetName = "Expand")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource reference to be expanded.",
            ParameterSetName = "Expand")]
        [ValidateNotNullOrEmpty]
        public string ExpandResource { get; set; }

        public override void Execute()
        {
            base.Execute();
            if(ShouldGetByName(ResourceGroupName, Name))
            {
                var pls = this.GetPrivateLinkService(this.ResourceGroupName, this.Name, this.ExpandResource);
                WriteObject(pls);
            }
            else 
            {
                IPage<PrivateLinkService> plsPage;
                if (ShouldListByResourceGroup(ResourceGroupName, Name))
                {
                    plsPage = this.PrivateLinkServiceClient.List(this.ResourceGroupName);
                }
                else
                {
                    plsPage = this.PrivateLinkServiceClient.ListBySubscription();
                }


                var plsList = ListNextLink<PrivateLinkService>.GetAllResourcesByPollingNextLink(plsPage, this.PrivateLinkServiceClient.ListNext);
                var psPLSs = new List<PSPrivateLinkService>();
                foreach (var pls in plsList)
                {
                    var psPls = this.ToPsPrivateLinkService(pls);
                    psPls.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(pls.Id);
                    psPLSs.Add(psPls);
                }

                WriteObject(TopLevelWildcardFilter(ResourceGroupName, Name, psPLSs), true);
            }
        }
    }
}
