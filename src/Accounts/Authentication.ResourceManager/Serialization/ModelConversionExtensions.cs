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
using Microsoft.Azure.Commands.Common.Serialization;

namespace Microsoft.Azure.Commands.ResourceManager.Common.Serialization
{
    public static class ModelConversionExtensions
    {
        /// <summary>
        /// Convert the legacy representation of a tenant to the new one
        /// </summary>
        /// <param name="tenant">The legacy tenant to convert</param>
        /// <returns>A new tenant with data copied from the old tenant</returns>
        public static IAzureTenant Convert(this LegacyAzureTenant tenant)
        {
            var result = new AzureTenant();
            result.Id = tenant.Id.ToString();
            result.Directory = tenant.Domain;
            return result;
        }

        /// <summary>
        /// Convert the legacy representation fo a context to the new one
        /// </summary>
        /// <param name="context">The Context to convert</param>
        /// <returns>A new context, with data copied from the old context</returns>
        public static IAzureContext Convert(this LegacyAzureContext context)
        {
            var result = new AzureContext();
            result.Account = context.Account.Convert();
            result.Subscription = context.Subscription.Convert();
            result.Tenant = context.Tenant.Convert();
            result.Environment = context.Environment.Convert();
            var cache = AzureSession.Instance.TokenCache;
            if ( context.TokenCache != null && context.TokenCache.Length > 0)
            {
                cache.CacheData = context.TokenCache;
            }

            result.TokenCache = cache;
            return result;
        }

        /// <summary>
        /// Try to convert a legacy profile
        /// </summary>
        /// <param name="profile">The legacy profile to convert</param>
        /// <param name="result">The new profile, with data copied form the old</param>
        /// <returns>True if the conversion was successful, false if not</returns>
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
