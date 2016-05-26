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

using Microsoft.Azure.Commands.Common.Authentication.Models;

namespace Microsoft.Azure.Commands.Profile.Models
{
    /// <summary>
    /// The context for connecting cmdlets in the current session to Azure.
    /// </summary>
    public class PSAzureContext
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
            return new PSAzureContext
            {
                Account = context.Account,
                Environment = context.Environment,
                Subscription = context.Subscription,
                Tenant = context.Tenant,
                TokenCache = context.TokenCache
            };
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
            return result;
        }

        /// <summary>
        /// The account used to connect to Azure.
        /// </summary>
        public PSAzureRmAccount Account { get; set; }

        /// <summary>
        /// The endpoint and connection metadata for the targeted instance of the Azure cloud.
        /// </summary>
        public PSAzureEnvironment Environment { get; set; }

        /// <summary>
        /// The subscription targeted in Azure.
        /// </summary>
        public PSAzureSubscription Subscription { get; set; }

        /// <summary>
        /// The targeted tenant in Azure.
        /// </summary>
        public PSAzureTenant Tenant { get; set; }

        private byte[] TokenCache { get; set; }
    }
}
