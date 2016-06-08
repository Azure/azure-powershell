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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Subscriptions.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.ResourceManager.Common
{
    internal static class ModelExtensions
    {
        internal static AzureSubscription ToAzureSubscription(this Subscription other, AzureContext context)
        {
            var subscription = new AzureSubscription();
            subscription.Account = context.Account != null ? context.Account.Id : null;
            subscription.Environment = context.Environment != null ? context.Environment.Name : EnvironmentName.AzureCloud;
            subscription.Id = new Guid(other.SubscriptionId);
            subscription.Name = other.DisplayName;
            subscription.State = other.State;
            subscription.SetProperty(AzureSubscription.Property.Tenants,
                context.Tenant.Id.ToString());
            return subscription;
        }

        public static List<AzureTenant> MergeTenants(
            this AzureAccount account,
            IEnumerable<TenantIdDescription> tenants,
            IAccessToken token)
        {
            List<AzureTenant> result = null;
            if (tenants != null)
            {
                var existingTenants = new List<AzureTenant>();
                account.SetProperty(AzureAccount.Property.Tenants, null);
                tenants.ForEach((t) =>
                {
                    existingTenants.Add(new AzureTenant { Id = new Guid(t.TenantId), Domain = token.GetDomain() });
                    account.SetOrAppendProperty(AzureAccount.Property.Tenants, t.TenantId);
                });

                result = existingTenants;
            }

            return result;
        }
    }
}
