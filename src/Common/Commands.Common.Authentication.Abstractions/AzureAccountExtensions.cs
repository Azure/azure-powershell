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
    public static class AzureAccountExtensions
    {
        public static string GetPropertyKey(AccountProperty property)
        {
            string key = null;
            switch (property)
            {
                case AccountProperty.AccessToken:
                    key = "AccessToken";
                    break;
                case AccountProperty.CertificateThumbprint:
                    key = "CertificateThumbprint";
                    break;
                case AccountProperty.Subscriptions:
                    key = "Subscriptions";
                    break;
                case AccountProperty.Tenants:
                    key = "Tenants";
                    break;
            }

            return key;
        }

        public static string GetAccessToken(this IAzureAccount account)
        {
            return account.GetProperty(AccountProperty.AccessToken);
        }

        public static void SetAccessToken(this IAzureAccount account, string token)
        {
            account.SetProperty(AccountProperty.AccessToken, token);
        }

        public static string GetThumbPrinnt(this IAzureAccount account)
        {
            return account.GetProperty(AccountProperty.CertificateThumbprint);
        }

        public static void SetThumbprint(this IAzureAccount account, string thumbprint)
        {
            account.SetProperty(AccountProperty.CertificateThumbprint, thumbprint);
        }

        public static string[] GetSubscriptions(this IAzureAccount account)
        {
            return account.GetPropertyAsArray(AccountProperty.Subscriptions);
        }

        public static void SetSubscriptions(this IAzureAccount account, params string[] subscriptions)
        {
            account.SetProperty(AccountProperty.Subscriptions, subscriptions);
        }


        public static string GetProperty(this IAzureAccount account, AccountProperty property)
        {
            return account.GetProperty(GetPropertyKey(property));
        }

        public static string GetProperty(this IAzureAccount account, string propertyKey)
        {
            string result = null;
            if (propertyKey != null && account.ExtendedProperties.ContainsKey(propertyKey))
            {
                result = account.ExtendedProperties[propertyKey];
            }

            return result;
        }


        public static string[] GetPropertyAsArray(this IAzureAccount account, AccountProperty property)
        {
            return account.GetPropertyAsArray(GetPropertyKey(property));
        }

        public static string[] GetPropertyAsArray(this IAzureAccount account, string propertyKey)
        {
            string[] result = null;
            if (propertyKey != null && account.ExtendedProperties.ContainsKey(propertyKey))
            {
                result = account.ExtendedProperties.GetPropertyAsArray(propertyKey);
            }

            return result;
        }


        public static void SetProperty(this IAzureAccount account, AccountProperty property, params string[] values)
        {
                account.SetProperty(GetPropertyKey(property), values);
        }

        public static void SetProperty(this IAzureAccount account, string propertyKey, params string[] values)
        {
            if (propertyKey != null)
            {
                account.ExtendedProperties.SetProperty(propertyKey, values);
            }
        }

        public static void SetOrAppendProperty(this IAzureAccount account, AccountProperty property, params string[] values)
        {
                account.SetOrAppendProperty(GetPropertyKey(property), values);
        }

        public static void SetOrAppendProperty(this IAzureAccount account, string propertyKey, params string[] values)
        {
            if (propertyKey != null)
            {
                account.ExtendedProperties.SetOrAppendProperty(propertyKey, values);
            }
        }

        public static bool IsPropertySet(this IAzureAccount account, AccountProperty property)
        {
            return account.IsPropertySet(GetPropertyKey(property));
        }

        public static bool IsPropertySet(this IAzureAccount account, string propertyKey)
        {
            bool result = false;
            if (propertyKey != null)
            {
                result = account.ExtendedProperties.IsPropertySet(propertyKey);
            }

            return result;
        }


        public static List<AzureSubscription> GetSubscriptions(this IAzureAccount account, IAzureContextContainer profile)
        {
            string[] subscriptions = new string[0];
            List<AzureSubscription> subscriptionsList = new List<AzureSubscription>();
            if (account.IsPropertySet(AccountProperty.Subscriptions))
            {
                subscriptions = account.GetPropertyAsArray(AccountProperty.Subscriptions);
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

        public static bool HasSubscription(this IAzureAccount account, Guid subscriptionId)
        {
            bool exists = false;
            string subscriptions = account.GetProperty(AccountProperty.Subscriptions);

            if (!string.IsNullOrEmpty(subscriptions))
            {
                exists = subscriptions.Contains(subscriptionId.ToString());
            }

            return exists;
        }

        public static void SetSubscriptions(this IAzureAccount account, List<AzureSubscription> subscriptions)
        {
            account.SetProperty(AccountProperty.Subscriptions, subscriptions.Select(s => s.Id.ToString()).ToArray());
        }

        public static void RemoveSubscription(this IAzureAccount account, Guid id)
        {
            if (account.HasSubscription(id))
            {
                var remainingSubscriptions = account.GetPropertyAsArray(AccountProperty.Subscriptions).Where(s => s != id.ToString()).ToArray();

                if (remainingSubscriptions.Any())
                {
                    account.SetProperty(AccountProperty.Subscriptions, string.Join(",", remainingSubscriptions));
                }
                else
                {
                    account.ExtendedProperties.Remove(GetPropertyKey(AccountProperty.Subscriptions));
                }
            }
        }
    }
}
