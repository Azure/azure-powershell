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

using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Common.Authentication.Abstractions
{
    /// <summary>
    /// Additional methods for accounts
    /// </summary>
    public static class AzureAccountExtensions
    {
        /// <summary>
        /// Get the Access Token property for the account, if it exists
        /// </summary>
        /// <param name="account">The account</param>
        /// <returns>The access token for the account, or null if there is none</returns>
        public static string GetAccessToken(this IAzureAccount account)
        {
            return account.GetProperty(AzureAccount.Property.AccessToken);
        }

        /// <summary>
        /// Set the access token for the account
        /// </summary>
        /// <param name="account">The account to change</param>
        /// <param name="token">The account access token</param>
        public static void SetAccessToken(this IAzureAccount account, string token)
        {
            account.SetProperty(AzureAccount.Property.AccessToken, token);
        }

        /// <summary>
        /// Get the certificate thumbprint for the account
        /// </summary>
        /// <param name="account">The account to check</param>
        /// <returns>The certificate thumbprint, or null if no certificate is set</returns>
        public static string GetThumbprint(this IAzureAccount account)
        {
            return account.GetProperty(AzureAccount.Property.CertificateThumbprint);
        }

        /// <summary>
        /// Set the certificate thumbprint for the account
        /// </summary>
        /// <param name="account">The account to change</param>
        /// <param name="thumbprint">The thumbprint of the accoutn credential certificate</param>
        public static void SetThumbprint(this IAzureAccount account, string thumbprint)
        {
            account.SetProperty(AzureAccount.Property.CertificateThumbprint, thumbprint);
        }

        /// <summary>
        /// Get the set of subscriptiosn associated with the account
        /// </summary>
        /// <param name="account">The account to check</param>
        /// <returns>The set of subscriptions associated with the account</returns>
        public static string[] GetSubscriptions(this IAzureAccount account)
        {
            return account.GetPropertyAsArray(AzureAccount.Property.Subscriptions);
        }

        /// <summary>
        /// Set the subscriptiosn associated with the account
        /// </summary>
        /// <param name="account">The account to change</param>
        /// <param name="subscriptions">The subscriptions to add to the account</param>
        public static void SetSubscriptions(this IAzureAccount account, params string[] subscriptions)
        {
            account.SetProperty(AzureAccount.Property.Subscriptions, subscriptions);
        }

        /// <summary>
        /// Get the tenants this account has access to
        /// </summary>
        /// <param name="account">The accoutn to check</param>
        /// <returns>The set of tenants the accoutn has access to</returns>
        public static string[] GetTenants(this IAzureAccount account)
        {
            return account.GetPropertyAsArray(AzureAccount.Property.Tenants);
        }

        /// <summary>
        /// Set the tenants the accoutn has access to
        /// </summary>
        /// <param name="account">The account to change</param>
        /// <param name="tenants">The set of tenants the account has access to</param>
        public static void SetTenants(this IAzureAccount account, params string[] tenants)
        {
            account.SetProperty(AzureAccount.Property.Tenants, tenants);
        }

        /// <summary>
        /// Get the list of subscriptions associated with the given account
        /// </summary>
        /// <param name="account">The account to look for</param>
        /// <param name="profile">The profile to search</param>
        /// <returns>A list of subscriptions available to the given account</returns>
        public static List<IAzureSubscription> GetSubscriptions(this IAzureAccount account, IAzureContextContainer profile)
        {
            string[] subscriptions = new string[0];
            List<IAzureSubscription> subscriptionsList = new List<IAzureSubscription>();
            if (account.IsPropertySet(AzureAccount.Property.Subscriptions))
            {
                subscriptions = account.GetSubscriptions();
            }

            foreach (var subscription in subscriptions)
            {
                var foundSubscription = profile.Subscriptions.FirstOrDefault((s) => string.Equals(s.Id, subscription, StringComparison.OrdinalIgnoreCase));
                if (foundSubscription != null)
                {
                    subscriptionsList.Add(foundSubscription);
                }
            }

            return subscriptionsList;
        }

        /// <summary>
        /// Determine if the given account has access to the given subscription
        /// </summary>
        /// <param name="account">The account to look in</param>
        /// <param name="subscriptionId">The subscription to check for</param>
        /// <returns>True if the account has access to the subscription, otherwise false</returns>
        public static bool HasSubscription(this IAzureAccount account, Guid subscriptionId)
        {
            bool exists = false;
            var subscriptions = account.GetPropertyAsArray(AzureAccount.Property.Subscriptions);

            if (subscriptions != null && subscriptions.Length > 0)
            {
                exists = subscriptions.Contains(subscriptionId.ToString(), StringComparer.OrdinalIgnoreCase);
            }

            return exists;
        }

        /// <summary>
        /// Set the subscriptiosn available to the given account
        /// </summary>
        /// <param name="account">The account to change</param>
        /// <param name="subscriptions">The subscriptions to replace the current subscription list in the account</param>
        public static void SetSubscriptions(this IAzureAccount account, List<IAzureSubscription> subscriptions)
        {
            account.SetSubscriptions(subscriptions.Select(s => s.Id.ToString()).ToArray());
        }

        /// <summary>
        /// Remove the given subscription from the given account
        /// </summary>
        /// <param name="account">The account to check</param>
        /// <param name="id">The id of the subscription to remove</param>
        public static void RemoveSubscription(this IAzureAccount account, Guid id)
        {
            if (account.HasSubscription(id))
            {
                var remainingSubscriptions = account.GetSubscriptions().Where(s => new Guid(s) != id).ToArray();

                if (remainingSubscriptions.Any())
                {
                    account.SetSubscriptions(remainingSubscriptions);
                }
                else
                {
                    account.ExtendedProperties.Remove(AzureAccount.Property.Subscriptions);
                }
            }
        }

        /// <summary>
        /// Copy account properties from the given account
        /// </summary>
        /// <param name="account">The account to copy to (target)</param>
        /// <param name="other">The account to copy from (source)</param>
        public static void CopyFrom(this IAzureAccount account, IAzureAccount source)
        {
            if (account != null && source != null)
            {
                account.Credential = source.Credential;
                account.Id = source.Id;
                account.Type = source.Type;
                foreach (var item in source.TenantMap)
                {
                    account.TenantMap[item.Key] = item.Value;
                }

                account.CopyPropertiesFrom(source);
            }
        }

        /// <summary>
        /// Update non-null non-identity account properties from the given account
        /// </summary>
        /// <param name="account">The account to copy to (target)</param>
        /// <param name="other">The account to copy from (source)</param>
        public static void Update(this IAzureAccount account, IAzureAccount source)
        {
            if (account != null && source != null)
            {
                account.Credential = source.Credential ?? account.Credential;
                foreach (var item in source.TenantMap)
                {
                    account.TenantMap[item.Key] = item.Value;
                }

                account.UpdateProperties(source);
            }
        }
    }
}
