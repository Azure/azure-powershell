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
using Microsoft.Azure.Commands.Profile.Common;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Profile.Models
{
    /// <summary>
    /// The context for connecting cmdlets in the current session to Azure.
    /// </summary>
    public class PSAzureContext : IAzureContext
    {
        /// <summary>
        /// Convert between implementations of the current connection context for Azure.
        /// </summary>
        /// <param name="context">The connection context to convert.</param>
        /// <returns>The converted context.</returns>
        public static implicit operator PSAzureContext(AzureContext context)
        {
            if (context == null)
            {
                return null;
            }

            return new PSAzureContext(context);
        }

        /// <summary>
        /// Convert between implementations of the current connection context for Azure.
        /// </summary>
        /// <param name="context">The connection context to convert.</param>
        /// <returns>The converted context.</returns>
        public static implicit operator AzureContext(PSAzureContext context)
        {
            if (context == null)
            {
                return null;
            }

            AzureContext result = null;
            if (context.Subscription == null)
            {
                result = new AzureContext(
                      context.Account,
                      context.Environment,
                      context.Tenant);
            }
            else
            {
                result = new AzureContext(
                      context.Subscription,
                      context.Account,
                      context.Environment,
                      context.Tenant);
            }

            result.TokenCache = context.TokenCache;
            result.VersionProfile = context.VersionProfile;
            result.CopyPropertiesFrom(context);
            return result;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public PSAzureContext()
        {
        }

        /// <summary>
        /// Copy Constructor
        /// </summary>
        /// <param name="context"></param>
        public PSAzureContext(IAzureContext context)
        {
            if (context != null)
            {
                Account = context.Account == null ? null : new PSAzureRmAccount(context.Account);
                Environment = context.Environment == null ? null : new PSAzureEnvironment(context.Environment);
                Subscription = context.Subscription == null ? null : new PSAzureSubscription(context.Subscription);
                Tenant = context.Tenant == null ? null : new PSAzureTenant(context.Tenant);
                TokenCache = context.TokenCache;
                this.VersionProfile = context.VersionProfile;
                this.CopyPropertiesFrom(context);
            }
        }

        /// <summary>
        /// Convert a context from a PSObject
        /// </summary>
        /// <param name="other"></param>
        public PSAzureContext(PSObject other)
        {
            if (other == null || other.Properties == null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            PSObject property;
            if (other.TryGetProperty(nameof(Account), out property))
            {
                Account = new PSAzureRmAccount(property);
            }
            if (other.TryGetProperty(nameof(Environment), out property))
            {
                Environment = new PSAzureEnvironment(property);
            }
            if (other.TryGetProperty(nameof(Subscription), out property))
            {
                Subscription = new PSAzureSubscription(property);
            }
            if (other.TryGetProperty(nameof(Tenant), out property))
            {
                Tenant = new PSAzureTenant(property);
            }
            if (other.TryGetProperty(nameof(TokenCache), out property))
            {
                AzureTokenCache cache = new AzureTokenCache();
                cache.Populate(property);
                TokenCache = new AuthenticationStoreTokenCache(cache);
            }

            VersionProfile = other.GetProperty<string>(nameof(VersionProfile));
            this.PopulateExtensions(other);
        }

        /// <summary>
        /// The name of the context. The context may be selected by name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The account used to connect to Azure.
        /// </summary>
        public IAzureAccount Account { get; set; }

        /// <summary>
        /// The endpoint and connection metadata for the targeted instance of the Azure cloud.
        /// </summary>
        public IAzureEnvironment Environment { get; set; }

        /// <summary>
        /// The subscription targeted in Azure.
        /// </summary>
        public IAzureSubscription Subscription { get; set; }

        /// <summary>
        /// The targeted tenant in Azure.
        /// </summary>
        public IAzureTenant Tenant { get; set; }

        public IAzureTokenCache TokenCache { get; set; }

        public string VersionProfile { get; set; }

        public IDictionary<string, string> ExtendedProperties { get; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
    }
}
