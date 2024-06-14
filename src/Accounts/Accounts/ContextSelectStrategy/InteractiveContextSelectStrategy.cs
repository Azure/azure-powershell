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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Profile.ContextSelectStrategy
{
    public class InteractiveContextSelectStrategy : ContextSelectStrategy
    {
        IAzureTenant Tenant;
        IList<IAzureSubscription> Subscriptions;

        public InteractiveContextSelectStrategy(IAzureTenant tenant, IList<IAzureSubscription> subscriptions) {
            Tenant = tenant;
            Subscriptions = subscriptions;
        }

        public override IAzureContext GetDefaultContext(IAzureAccount account, IAzureEnvironment environment)
        {
            throw new NotImplementedException();
        }

        public override (IAzureTenant, IAzureSubscription) GetDefaultTenantAndSubscription()
        {
            OutputAction("To override which subscription Connect-AzAccount selects by default, " +
                "use `Update-AzConfig -DefaultSubscriptionForLogin 00000000-0000-0000-0000-000000000000`. " +
                "Go to https://go.microsoft.com/fwlink/?linkid=2200610 for more information.");
            return (Tenant, Subscriptions?.First());
        }
    }
}
