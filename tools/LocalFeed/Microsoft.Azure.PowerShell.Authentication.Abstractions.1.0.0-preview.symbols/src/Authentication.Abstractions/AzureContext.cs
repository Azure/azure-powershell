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

using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Common.Authentication.Abstractions
{
    /// <summary>
    /// The current target of azure cmdlets, including the account, tenant, subscription and service-specific data
    /// </summary>
    [Serializable]
    public class AzureContext : IAzureContext
    {
        /// <summary>
        /// Create a new AzureContext with no data
        /// </summary>
        public AzureContext() : this(null, null, null, null, null)
        {

        }

        /// <summary>
        /// Creates new instance of AzureContext.
        /// </summary>
        /// <param name="subscription">The azure subscription object</param>
        /// <param name="account">The azure account object</param>
        /// <param name="environment">The azure environment object</param>
        public AzureContext(IAzureSubscription subscription, IAzureAccount account, IAzureEnvironment environment)
            : this(subscription, account, environment, null)
        {

        }

        /// <summary>
        /// Creates new instance of AzureContext.
        /// </summary>
        /// <param name="account">The azure account object</param>
        /// <param name="environment">The azure environment object</param>
        /// <param name="tenant">The azure tenant object</param>
        public AzureContext(IAzureAccount account, IAzureEnvironment environment, IAzureTenant tenant)
            : this(null, account, environment, tenant)
        {

        }

        /// <summary>
        /// Creates new instance of AzureContext.
        /// </summary>
        /// <param name="subscription">The azure subscription object</param>
        /// <param name="account">The azure account object</param>
        /// <param name="environment">The azure environment object</param>
        /// <param name="tenant">The azure tenant object</param>
        [JsonConstructor]
        public AzureContext(IAzureSubscription subscription, IAzureAccount account, IAzureEnvironment environment, IAzureTenant tenant) 
            : this(subscription, account, environment, tenant, null)
        {
        }

        /// <summary>
        /// Creates new instance of AzureContext.
        /// </summary>
        /// <param name="subscription">The azure subscription object</param>
        /// <param name="account">The azure account object</param>
        /// <param name="environment">The azure environment object</param>
        /// <param name="tenant">The azure tenant object</param>
        public AzureContext(IAzureSubscription subscription, IAzureAccount account, IAzureEnvironment environment, IAzureTenant tenant, byte[] tokens)
        {
            Subscription = subscription;
            Account = account;
            Environment = environment;
            Tenant = tenant;
            TokenCache = new AzureTokenCache();
            TokenCache.CacheData = tokens;
        }

        /// <summary>
        /// The current account
        /// </summary>
        public IAzureAccount Account { get; set; }

        /// <summary>
        /// The target tenant
        /// </summary>
        public IAzureTenant Tenant { get; set; }

        /// <summary>
        /// The target subscription
        /// </summary>
        public IAzureSubscription Subscription { get; set; }

        /// <summary>
        /// The target environment
        /// </summary>
        public IAzureEnvironment Environment { get; set; }

        /// <summary>
        /// The current version profile for cmdlets
        /// </summary>
        public string VersionProfile { get; set; }

        /// <summary>
        /// The token store
        /// </summary>
        public IAzureTokenCache TokenCache { get; set; }

        /// <summary>
        /// Additional service-specific context
        /// </summary>
        public IDictionary<string, string> ExtendedProperties { get; } = new ConcurrentDictionary<string, string>(StringComparer.OrdinalIgnoreCase);
    }
}
