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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SecurityPartnerProvider", DefaultParameterSetName = SecurityPartnerProviderParameterSetName.ByName), OutputType(typeof(PSSecurityPartnerProvider))]
    public class GetAzureSecurityPartnerProviderCommand : SecurityPartnerProviderBaseCmdlet
    {

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.", ParameterSetName = SecurityPartnerProviderParameterSetName.ByName)]
        [ResourceNameCompleter("Microsoft.Network/securityPartnerProviders", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.", ParameterSetName = SecurityPartnerProviderParameterSetName.ByName)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource Id.", ParameterSetName = SecurityPartnerProviderParameterSetName.ByResourceId)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            if (this.IsParameterBound(c => c.Name))
            {
                var securityPartnerProvider = this.GetSecurityPartnerProvider(this.ResourceGroupName, this.Name);
                WriteObject(securityPartnerProvider);
            }
            else if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceInfo = new ResourceIdentifier(ResourceId);
                ResourceGroupName = resourceInfo.ResourceGroupName;
                Name = resourceInfo.ResourceName;

                var securityPartnerProvider = this.GetSecurityPartnerProvider(this.ResourceGroupName, this.Name);
                WriteObject(securityPartnerProvider);
            }
            else
            {
                IPage<SecurityPartnerProvider> secutiyPartnerProviderPage = ShouldListBySubscription(ResourceGroupName, Name)
                    ? this.SecurityPartnerProviderClient.List()
                    : this.SecurityPartnerProviderClient.ListByResourceGroup(this.ResourceGroupName);

                // Get all resources by polling on next page link
                var securityPartnerProviderResponseList = ListNextLink<SecurityPartnerProvider>.GetAllResourcesByPollingNextLink(secutiyPartnerProviderPage, this.SecurityPartnerProviderClient.ListNext);

                var psSecurityPartnerProviders = securityPartnerProviderResponseList.Select(securityPartnerProvider =>
                {
                    var psSecurityPartnerProvider = this.ToPsSecurityPartnerProvider(securityPartnerProvider);
                    psSecurityPartnerProvider.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(securityPartnerProvider.Id);
                    return psSecurityPartnerProvider;
                }).ToList();

                WriteObject(TopLevelWildcardFilter(ResourceGroupName, Name, psSecurityPartnerProviders), true);
            }
        }
    }
}
