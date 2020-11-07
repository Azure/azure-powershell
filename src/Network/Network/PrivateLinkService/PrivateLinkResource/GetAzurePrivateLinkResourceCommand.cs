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
using Microsoft.Azure.Commands.Network.PrivateLinkService.PrivateLinkServiceProvider;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PrivateLinkResource", DefaultParameterSetName = "ByPrivateLinkResourceId"), OutputType(typeof(PSPrivateLinkResource))]
    public class GetAzurePrivateLinkResourceCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = "ByPrivateLinkResourceId",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string PrivateLinkResourceId { get; set; }

        public override void Execute()
        {
            base.Execute();

            var resourceIdentifier = new ResourceIdentifier(this.PrivateLinkResourceId);
            string ResourceGroupName = resourceIdentifier.ResourceGroupName;
            string Name = resourceIdentifier.ResourceName;
            string ResourceType = resourceIdentifier.ResourceType;

            IPrivateLinkProvider provider = PrivateLinkProviderFactory.CreatePrivateLinkProvder(this, resourceIdentifier.Subscription, ResourceType);
            if (provider == null)
            {
                throw new ArgumentException(string.Format(Properties.Resources.InvalidResourceId, this.PrivateLinkResourceId));
            }
            
            var plrs = provider.ListPrivateLinkResource(ResourceGroupName, Name);
            WriteObject(plrs, true);

        }
    }
}
