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

using Azure.Core;

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System.Linq;

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Profile.ContextSelectStrategy
{
    /// <summary>
    /// Select the first found subscription in the first found home tenant
    /// If no subscription found for the given tenant,
    /// Continue to look for matched subscripitons until one subscription is retrived
    /// </summary>
    public class AutomaticContextSelectStrategy : ContextSelectStrategy
    {
        IAzureTenant Tenant;
        IList<IAzureSubscription> Subscriptions;

        public AutomaticContextSelectStrategy(Action<string> OutputAction)
        {
        }

        public override IAzureContext GetDefaultContext(IAzureAccount account, IAzureEnvironment environment)
        {
            throw new NotImplementedException();
        }

        public override (IAzureTenant, IAzureSubscription) GetDefaultTenantAndSubscription()
        {
            if (Subscriptions.Count() > 1)
            {
                OutputAction(string.Format(
                        "TenantId '{0}' contains more than one active subscription. First one will be selected for further use. " +
                        "To select another subscription, use Set-AzContext.", Tenant.Id));

                OutputAction(
                    "To override which subscription Connect-AzAccount selects by default, " +
                    "use `Update-AzConfig -DefaultSubscriptionForLogin 00000000-0000-0000-0000-000000000000`. " +
                    "Go to https://go.microsoft.com/fwlink/?linkid=2200610 for more information.");
            }
            return (Tenant, Subscriptions?.First());
        }
    }
}
