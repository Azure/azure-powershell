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
using System.Linq;

namespace Microsoft.Azure.Commands.Common.Authentication.Abstractions
{
    public static class AzureContextExtensions
    {
        /// <summary>
        /// Check for an environment within the given container
        /// </summary>
        /// <param name="container">The container to check</param>
        /// <param name="name">The name of the environment</param>
        /// <returns>True if the environment exists in the container, otherwise false</returns>
        public static bool HasEnvironment(this IAzureContextContainer container, string name)
        {
            return container.Environments.Any((e) => string.Equals(e.Name, name, StringComparison.CurrentCultureIgnoreCase));
        }

        /// <summary>
        /// Return the given environment from the given context container
        /// </summary>
        /// <param name="container">The container to search</param>
        /// <param name="name">The name of the environment</param>
        /// <returns>The environment, or null if no such environment exists in the container</returns>
        public static IAzureEnvironment GetEnvironment(this IAzureContextContainer container, string name)
        {
            return container.Environments.FirstOrDefault((e) => string.Equals(e.Name, name, StringComparison.CurrentCultureIgnoreCase));
        }

        /// <summary>
        /// Check if a subscription with the given name exists in the container
        /// </summary>
        /// <param name="container">The container to search</param>
        /// <param name="subscriptionName">The name of the subscription to search for</param>
        /// <returns>True if a subscription with that name exists, false otherwise</returns>
        public static bool HasSubscriptionName(this IAzureContextContainer container, string subscriptionName)
        {
            return container.Subscriptions.Any((s) => string.Equals(s.Name, subscriptionName, StringComparison.CurrentCultureIgnoreCase));
        }

        /// <summary>
        /// Check if a subscription with the given id exists in the container
        /// </summary>
        /// <param name="container">The container to search</param>
        /// <param name="id">The id of the subscription to search for</param>
        /// <returns>True if a subscription with that id exists, false otherwise</returns>
        public static bool HasSubscriptionId(this IAzureContextContainer container, string id)
        {
            return container.Subscriptions.Any((s) => string.Equals(s.Id, id, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Check if a subscription with the given id exists in the container
        /// </summary>
        /// <param name="container">The container to search</param>
        /// <param name="id">The id of the subscription to search for</param>
        /// <returns>True if a subscription with that id exists, false otherwise</returns>
        public static bool HasSubscriptionId(this IAzureContextContainer container, Guid id)
        {
            return container.Subscriptions.Any((s) => s.GetId() == id);
        }

        /// <summary>
        /// Return the subscription with the given name (if it exists) from the container
        /// </summary>
        /// <param name="container">The container to search</param>
        /// <param name="subscriptionName">The name of the subscription to search for</param>
        /// <returns>The subscription with the given name, if it exists, null otherwise</returns>
        public static IAzureSubscription GetSubscriptionByName(this IAzureContextContainer container, string subscriptionName)
        {
            return container.Subscriptions.FirstOrDefault((s) => string.Equals(s.Name, subscriptionName, StringComparison.CurrentCultureIgnoreCase));
        }

        /// <summary>
        /// Return the subscription with the given id if it exists in the container
        /// </summary>
        /// <param name="container">The container to search</param>
        /// <param name="id">The id of the subscription to search for</param>
        /// <returns>True if a subscription with that id exists, false otherwise</returns>
        public static IAzureSubscription GetSubscriptionById(this IAzureContextContainer container, string id)
        {
            return container.Subscriptions.FirstOrDefault((s) => string.Equals(s.Id, id, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Return the subscription with the given id if it exists in the container
        /// </summary>
        /// <param name="container">The container to search</param>
        /// <param name="id">The id of the subscription to search for</param>
        /// <returns>True if a subscription with that id exists, false otherwise</returns>
        public static IAzureSubscription GetSubscriptionById(this IAzureContextContainer container, Guid id)
        {
            return container.Subscriptions.FirstOrDefault((s) => s.GetId() == id);
        }

        /// <summary>
        /// Check if an account with the given displayable id exists in the container
        /// </summary>
        /// <param name="container">The container to search</param>
        /// <param name="account">The displayable id of the account to search for</param>
        /// <returns>True if the account exists, otherwise false</returns>
        public static bool HasAccount(this IAzureContextContainer container, string account)
        {
            return container.Accounts.Any((a) => string.Equals(a.Id, account, StringComparison.CurrentCultureIgnoreCase));
        }

        /// <summary>
        /// Return the account with the given displayable id if it exists in the container
        /// </summary>
        /// <param name="container">The container to search</param>
        /// <param name="account">The displayable id of the account to search for</param>
        /// <returns>The account if it exists, otherwise null</returns>
        public static IAzureAccount GetAccount(this IAzureContextContainer container, string account)
        {
            return container.Accounts.FirstOrDefault((a) => string.Equals(a.Id, account, StringComparison.CurrentCultureIgnoreCase));
        }

        /// <summary>
        /// Update the properties of the context
        /// </summary>
        /// <param name="context">The context to update</param>
        /// <param name="other">The context to update from</param>
        public static void Update(this IAzureContext context, IAzureContext other)
        {
            if (context != null && other != null)
            {
                context.Account.Update(other.Account);
                context.Subscription.Update(other.Subscription);
                context.Tenant.Update(other.Tenant);
                context.UpdateProperties(other);
            }
        }
    }
}
