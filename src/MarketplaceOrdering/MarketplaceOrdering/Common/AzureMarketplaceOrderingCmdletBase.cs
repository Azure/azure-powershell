﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.MarketplaceOrdering;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.MarketplaceOrdering.Common
{
    /// <summary>
    /// Base class of Azure Marketplace Ordering Cmdlet.
    /// </summary>
    public abstract class AzureMarketplaceOrderingCmdletBase : AzureRMCmdlet
    {
        private IMarketplaceOrderingAgreementsClient _marketplaceOrderingAgreementsClient;

        /// <summary>
        /// Gets or sets the Marketplace Ordering client.
        /// </summary>
        public IMarketplaceOrderingAgreementsClient MarketplaceOrderingAgreementsClient
        {
            get
            {
                return _marketplaceOrderingAgreementsClient ??
                       (_marketplaceOrderingAgreementsClient =
                           AzureSession.Instance.ClientFactory.CreateArmClient<MarketplaceOrderingAgreementsClient>(DefaultProfile.DefaultContext,
                               AzureEnvironment.Endpoint.ResourceManager));
            }
            set { _marketplaceOrderingAgreementsClient = value; }
        }
    }
}
