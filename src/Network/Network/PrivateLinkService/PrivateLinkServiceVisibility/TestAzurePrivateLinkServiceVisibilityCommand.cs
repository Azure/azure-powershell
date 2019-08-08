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
using CNM = Microsoft.Azure.Commands.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Test", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PrivateLinkServiceVisibility"), OutputType(typeof(bool))]
    public class TestAzurePrivateLinkServiceVisibilityCommand : PrivateLinkServiceBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The location.",
            ValueFromPipelineByPropertyName = true)]
        [LocationCompleter("Microsoft.Network/locations/checkPrivateLinkServiceVisibility")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
          Mandatory = false,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
           Mandatory = true,
           HelpMessage = "The alias of private link service.",
           ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public string PrivateLinkServiceAlias { get; set; }

        public override void Execute()
        {
            base.Execute();

            var request = new Management.Network.Models.CheckPrivateLinkServiceVisibilityRequest();
            request.PrivateLinkServiceAlias = PrivateLinkServiceAlias;

            PrivateLinkServiceVisibility ret = null;
            if(!string.IsNullOrEmpty(ResourceGroupName))
            {
                ret = this.PrivateLinkServiceClient.CheckPrivateLinkServiceVisibilityByResourceGroup(this.Location, this.ResourceGroupName, request);
            }
            else
            {
                ret = this.PrivateLinkServiceClient.CheckPrivateLinkServiceVisibility(this.Location, request);
            }

            WriteObject(ret.Visible);
        }

    }
}
