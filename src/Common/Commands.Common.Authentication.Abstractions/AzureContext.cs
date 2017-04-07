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
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Common.Authentication.Abstractions
{
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
        public AzureContext(AzureSubscription subscription, AzureAccount account, AzureEnvironment environment)
            : this(subscription, account, environment, null)
        {

        }

        /// <summary>
        /// Creates new instance of AzureContext.
        /// </summary>
        /// <param name="account">The azure account object</param>
        /// <param name="environment">The azure environment object</param>
        /// <param name="tenant">The azure tenant object</param>
        public AzureContext(AzureAccount account, AzureEnvironment environment, AzureTenant tenant)
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
        public AzureContext(AzureSubscription subscription, AzureAccount account, AzureEnvironment environment, AzureTenant tenant) 
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
        public AzureContext(AzureSubscription subscription, AzureAccount account, AzureEnvironment environment, AzureTenant tenant, byte[] tokens)
        {
            Subscription = subscription;
            Account = account;
            Environment = environment;
            Tenant = tenant;
            TokenCache = new AuthenticationStore();
            TokenCache.CacheData = tokens;
        }



        public AzureAccount Account { get; set; }

        public AzureTenant Tenant { get; set; }

        public AzureSubscription Subscription { get; set; }

        public AzureEnvironment Environment { get; set; }

        public string VersionProfile { get; set; }

        public AuthenticationStore TokenCache { get; set; }

        public IDictionary<string, string> ExtendedProperties { get; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
    }
}
