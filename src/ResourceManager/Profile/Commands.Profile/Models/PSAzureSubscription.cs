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
using Microsoft.Azure.Commands.Common.Authentication.Utilities;
using System;

namespace Microsoft.Azure.Commands.Profile.Models
{
    /// <summary>
    /// Azure subscription details.
    /// </summary>
    public class PSAzureSubscription
    {
        /// <summary>
        /// Convert between formats of AzureSubscription information.
        /// </summary>
        /// <param name="other">The subscription to convert.</param>
        /// <returns>The converted subscription.</returns>
        public static implicit operator PSAzureSubscription(AzureSubscription other)
        {
            if (other == null)
            {
                return null;
            }

            var subscription = new PSAzureSubscription
            {
                SubscriptionId = other.Id.ToString(),
                SubscriptionName = other.Name,
                State = other.State,
                TenantId = other.IsPropertySet(AzureSubscription.Property.Tenants) ?
                other.GetProperty(AzureSubscription.Property.Tenants) : null
            };

            if (other.IsPropertySet(AzureSubscription.Property.StorageAccount))
            {
                subscription.CurrentStorageAccount = other.GetProperty(AzureSubscription.Property.StorageAccount);
                subscription.CurrentStorageAccountName = GetAccountName(subscription.CurrentStorageAccount);
            }

            return subscription;
        }

        /// <summary>
        /// Convert between formats of AzureSubscription information.
        /// </summary>
        /// <param name="other">The subscription to convert.</param>
        /// <returns>The converted subscription.</returns>
        public static implicit operator AzureSubscription(PSAzureSubscription other)
        {
            if (other == null)
            {
                return null;
            }

            var result = new AzureSubscription
            {
                Name = other.SubscriptionName
            };

            if (other.SubscriptionId != null)
            {
                Guid subscriptionId;
                if (Guid.TryParse(other.SubscriptionId, out subscriptionId))
                {
                    result.Id = subscriptionId;
                }
            }

            if (other.TenantId != null)
            {
                result.Properties.SetProperty(AzureSubscription.Property.Tenants, other.TenantId);
            }

            if (other.CurrentStorageAccount != null)
            {
                result.Properties.SetProperty(AzureSubscription.Property.StorageAccount, other.CurrentStorageAccount);
            }

            if (other.State != null)
            {
                result.State = other.State;
            }

            return result;
        }

        /// <summary>
        /// The subscription id.
        /// </summary>
        public string SubscriptionId { get; set; }

        /// <summary>
        /// The name of the subscription.
        /// </summary>
        public string SubscriptionName { get; set; }

        /// <summary>
        /// Gets or sets subscription State
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// The tenant home for the subscription.
        /// </summary>
        public string TenantId { get; set; }

        public string CurrentStorageAccountName { get; set; }

        internal string CurrentStorageAccount { get; set; }

        public override string ToString()
        {
            return this.SubscriptionId;
        }

        public static string GetAccountName(string connectionString)
        {
            var result = connectionString;
            if (!string.IsNullOrWhiteSpace(result))
            {
                try
                {
                    var pairs = result.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var pair in pairs)
                    {
                        var sides = pair.Split(new char[] { '=' }, 2, StringSplitOptions.RemoveEmptyEntries);
                        if (string.Equals("AccountName", sides[0].Trim(), StringComparison.OrdinalIgnoreCase))
                        {
                            result = sides[1].Trim();
                            break;
                        }
                    }
                }
                catch
                {
                    // if there are any errors, return the unchanged account name
                }
            }

            return result;
        }
    }
}
