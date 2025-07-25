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

namespace Microsoft.Azure.Commands.TestFx
{
    public static class TestModelExtensions
    {
        /// <summary>
        /// Check that the extended properties in the two models are equal
        /// </summary>
        /// <param name="model">This model</param>
        /// <param name="other">The model being comparied to this model</param>
        /// <returns>true if the models are equal, or false otherwise</returns>
        public static bool CheckExtensionsEqual(this IExtensibleModel model, IExtensibleModel other)
        {
            return model != null && other != null && CheckEquality(model.ExtendedProperties, other.ExtendedProperties);
        }

        /// <summary>
        /// Check if this tenant equals another tenant
        /// </summary>
        /// <param name="baseTenant">The base tenant to compare</param>
        /// <param name="other">The tenant to compare it with</param>
        /// <returns>true if the tenants are equal, otherwise false</returns>
        public static bool IsEqual(this IAzureTenant baseTenant, IAzureTenant other)
        {
            return (baseTenant == null && other == null) || (baseTenant.CheckExtensionsEqual(other)
                && string.Equals(baseTenant.Id, other.Id, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Check if this account equals another account
        /// </summary>
        /// <param name="baseAccount">The base account for comparison</param>
        /// <param name="other">The accoutn to compare to</param>
        /// <returns>true if the elements of both accounts are equal, otherwise false</returns>
        public static bool IsEqual(this IAzureAccount baseAccount, IAzureAccount other)
        {
            return (baseAccount == null && other == null) || (baseAccount.CheckExtensionsEqual(other)
                && string.Equals(baseAccount.Credential, other.Credential, StringComparison.OrdinalIgnoreCase)
                && string.Equals(baseAccount.Id, other.Id, StringComparison.OrdinalIgnoreCase)
                && string.Equals(baseAccount.Type, other.Type, StringComparison.OrdinalIgnoreCase)
                && CheckEquality(baseAccount.TenantMap, other.TenantMap));
        }

        /// <summary>
        /// Check if this subscription equals another subscription
        /// </summary>
        /// <param name="baseSub">The base subscription for comparison</param>
        /// <param name="other">The subscription to compare to</param>
        /// <returns>True if the elements of both subscriptiosn are equal, otherwise false</returns>
        public static bool IsEqual(this IAzureSubscription baseSub, IAzureSubscription other)
        {
            return (baseSub == null && other == null) || (baseSub.CheckExtensionsEqual(other)
                && string.Equals(baseSub.Id, other.Id, StringComparison.OrdinalIgnoreCase)
                && string.Equals(baseSub.Name, other.Name, StringComparison.OrdinalIgnoreCase)
                && string.Equals(baseSub.State, other.State, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Check if this environment equals another environment
        /// </summary>
        /// <param name="environment">this environment</param>
        /// <param name="other">The environment to compare to</param>
        /// <returns>Treu fi the elements of the environment are equal, otherwise false</returns>
        public static bool IsEqual(this IAzureEnvironment environment, IAzureEnvironment other)
        {
            return (environment == null && other == null)
                || environment.CheckExtensionsEqual(other);
        }

        /// <summary>
        /// Check if this context equals another context
        /// </summary>
        /// <param name="context">The base context</param>
        /// <param name="other">The context to compare with</param>
        /// <returns>True if the elements of the contexts are equal, otherwise false</returns>
        public static bool IsEqual(this IAzureContext context, IAzureContext other)
        {
            return (context == null && other == null)
                || (context.CheckExtensionsEqual(other)
                && context.Account.IsEqual(other.Account)
                && context.Environment.IsEqual(other.Environment)
                && context.Subscription.IsEqual(other.Subscription)
                && context.Tenant.IsEqual(other.Tenant)
                && string.Equals(context.VersionProfile, other.VersionProfile, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Check if two token caches are equal
        /// </summary>
        /// <param name="cache">The base cache</param>
        /// <param name="other">The cache to compare with</param>
        /// <returns>True if the two caches contain the same data, otherwise false</returns>
        public static bool IsEqual(this IAzureTokenCache cache, IAzureTokenCache other)
        {
            bool result = (cache == null && other == null) || (cache != null && cache.CacheData == null && other != null && other.CacheData == null);
            if (cache != null && other != null && cache.CacheData != null && other.CacheData != null && cache.CacheData.Length == other.CacheData.Length)
            {
                result = true;
                for (int i = 0; i < cache.CacheData.Length; ++i)
                {
                    if (cache.CacheData[i] != other.CacheData[i])
                    {
                        result = false;
                    }
                }
            }

            return result;
        }

        static bool CheckEquality(IDictionary<string, string> current, IDictionary<string, string> other)
        {
            bool result = false;
            if (current == null && other == null)
            {
                result = true;
            }
            else if (current != null && other != null && current.Count == other.Count)
            {
                result = true;
                foreach (var pair in current)
                {
                    if (!(other.ContainsKey(pair.Key)
                        && string.Equals(pair.Value, other[pair.Key], StringComparison.OrdinalIgnoreCase)))
                    {
                        result = false;
                    }
                }
            }

            return result;
        }
    }
}
