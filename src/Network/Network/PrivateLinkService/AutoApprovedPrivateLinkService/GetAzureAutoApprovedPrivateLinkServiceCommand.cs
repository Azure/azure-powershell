// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.Azure;
using CNM = Microsoft.Azure.Commands.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AutoApprovedPrivateLinkService"), OutputType(typeof(PSAutoApprovedPrivateLinkService))]
    public class GetAzureAutoApprovedPrivateLinkServiceCommand : PrivateLinkServiceBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The location.",
            ValueFromPipelineByPropertyName = true)]
        [LocationCompleter("Microsoft.Network/locations/autoApprovedPrivateLinkServices")]
        [ValidateNotNullOrEmpty]
        public virtual string Location { get; set; }

        [Parameter(
          Mandatory = false,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string ResourceGroupName { get; set; }

        public override void Execute()
        {
            base.Execute();

            IPage<AutoApprovedPrivateLinkService> autoApprovedPrivateLinkServiceList = null;

            if (!string.IsNullOrEmpty(ResourceGroupName))
            {
                autoApprovedPrivateLinkServiceList = this.PrivateLinkServiceClient.ListAutoApprovedPrivateLinkServicesByResourceGroup(this.Location, this.ResourceGroupName);
            }
            else
            {
                autoApprovedPrivateLinkServiceList = this.PrivateLinkServiceClient.ListAutoApprovedPrivateLinkServices(this.Location);
            }

            List<PSAutoApprovedPrivateLinkService> psLists = new List<PSAutoApprovedPrivateLinkService>();
            foreach(var autoApprovedPrivateLinkService in autoApprovedPrivateLinkServiceList)
            {
                psLists.Add(NetworkResourceManagerProfile.Mapper.Map<PSAutoApprovedPrivateLinkService>(autoApprovedPrivateLinkService));
            }

            WriteObject(psLists, true);
        }
    }
}
