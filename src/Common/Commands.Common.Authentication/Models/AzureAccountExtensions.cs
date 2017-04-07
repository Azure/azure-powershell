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
using Microsoft.Azure.Commands.Common.Authentication.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Microsoft.Azure.Commands.Common.Authentication.Models
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
        public static string GetProperty(this IAzureAccount account, AccountProperty property)
        {
            string result = null;
            string propertyKey = GetPropertyKey(property);
            if (propertyKey != null && account.ExtendedProperties.ContainsKey(propertyKey))
            {
                result = account.ExtendedProperties[propertyKey];
            }

            return result;
        }

        public static string[] GetPropertyAsArray(this IAzureAccount account, AccountProperty property)
        {
            string[] result = null;
            string propertyKey = GetPropertyKey(property);
            if (propertyKey != null && account.ExtendedProperties.ContainsKey(propertyKey))
            {
                result = account.ExtendedProperties.GetPropertyAsArray(propertyKey);
            }

            return result;
        }

        public static void SetProperty(this IAzureAccount account, AccountProperty property, params string[] values)
        {
            string propertyKey = GetPropertyKey(property);
            if (propertyKey != null)
            {
                account.ExtendedProperties.SetProperty(propertyKey, values);
            }
        }

        public static void SetOrAppendProperty(this IAzureAccount account, AccountProperty property, params string[] values)
        {
            string propertyKey = GetPropertyKey(property);
            if (propertyKey != null)
            {
                account.ExtendedProperties.SetOrAppendProperty(propertyKey, values);
            }
        }

        public static bool IsPropertySet(this IAzureAccount account, AccountProperty property)
        {
            bool result = false;
            string propertyKey = GetPropertyKey(property);
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
                try
                {
                    Guid subscriptionId = new Guid(subscription);
                    Debug.Assert(profile.Subscriptions.ContainsKey(subscriptionId));
                    subscriptionsList.Add(profile.Subscriptions[subscriptionId]);
                }
                catch
                {
                    // Skip
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
                var remainingSubscriptions = GetPropertyAsArray(AccountProperty.Subscriptions).Where(s => s != id.ToString()).ToArray();

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
