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

namespace Microsoft.Azure.Commands.Marketplace.Cmdlets
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Marketplace.Models;
    using Microsoft.Azure.Commands.Marketplace.Models.PrivateStore;
    using Microsoft.Azure.Commands.Marketplace.Utilities;
    using Microsoft.Azure.Management.Marketplace;


    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "MarketplacePrivateStore"), OutputType(typeof(PSPrivateStore))]
    public class GetAzMarketplacePrivateStore : ResourceMarketplaceBaseCmdlet
    {
        public override void ExecuteCmdlet()
        {
            var privateStores = ResourceMarketplaceClient.PrivateStore.List();
            if (privateStores == null || !privateStores.Any())
            {
                WriteObject(new List<PSPrivateStore>(), true);
                return;
            }

            var psPrivateStores = privateStores.Select(ps => ps.ToPSPrivateStore()).ToList();
            WriteObject(psPrivateStores, true);
        }
    }
}
