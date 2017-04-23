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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.ResourceManager.Common.Serialization
{
    public static class ProfileConverter
    {
        public static IAzureAccount Convert(this LegacyAzureAccount account)
        {
            var result = new AzureAccount();
            result.Id = account.Id;
            result.Type = account.Type;

            foreach (var property in account.Properties)
            {
                result.SetProperty(property.Key, property.Value);
            }

            return result;
        }

        public static IAzureEnvironment Convert(this LegacyAzureEnvironment environment)
        {
            var result = new AzureEnvironment();
            result.Name = environment.Name;
            result.OnPremise = environment.OnPremise;
            foreach (var endpoint in environment.Endpoints)
            {
                result.SetEndpoint(endpoint.Key, endpoint.Value);
            }

            return result;
        }

        public static IAzureSubscription Convert(this LegacyAzureSubscription subscription)
        {
            var result = new AzureSubscription();
            result.Id = subscription.Id.ToString();
            result.Name = subscription.Name;
            result.State = subscription.State;
            result.SetAccount(subscription.Account);
            result.SetEnvironment(subscription.Environment);
            foreach (var property in subscription.Properties)
            {
                result.SetProperty(property.Key, property.Value);
            }

            return result;
        }

        public static IAzureTenant Convert(this LegacyAzureTenant tenant)
        {
            var result = new AzureTenant();
            result.Id = tenant.Id.ToString();
            result.Directory = tenant.Domain;
            return result;
        }

        public static IAzureContext Convert(this LegacyAzureContext context)
        {
            var result = new AzureContext();
            result.Account = context.Account.Convert();
            result.Subscription = context.Subscription.Convert();
            result.Tenant = context.Tenant.Convert();
            result.Environment = context.Environment.Convert();
            result.TokenCache = new AuthenticationStoreTokenCache(new AzureTokenCache { CacheData = context.TokenCache });
            return result;
        }

        public static bool TryConvert(this LegacyAzureRmProfile profile, out AzureRmProfile result)
        {
            result = new AzureRmProfile();
            if (profile != null)
            {
                if (profile.Environments != null)
                {
                    foreach (var environmentKey in profile.Environments.Keys)
                    {
                        result.EnvironmentTable[environmentKey] = profile.Environments[environmentKey].Convert();
                    }
                }

                if (profile.Context != null)
                {
                    result.DefaultContext = profile.Context.Convert();
                }
            }

            return profile != null && profile.Context != null;
            
        }
    }
}
