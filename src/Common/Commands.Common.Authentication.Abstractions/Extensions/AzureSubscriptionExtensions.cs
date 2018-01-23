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

namespace Microsoft.Azure.Commands.Common.Authentication.Abstractions
{
    /// <summary>
    /// Convenience methods for subscriptions
    /// </summary>
    public static class AzureSubscriptionExtensions
    {
        /// <summary>
        /// Get the subscription Id as a globally-unique identifier
        /// </summary>
        /// <param name="subscription">The subscription to check</param>
        /// <returns>The globally unique id, if the id is set, otherwise, the enpty Guid</returns>
        public static Guid GetId(this IAzureSubscription subscription)
        {
            return subscription.Id == null? Guid.Empty: new Guid(subscription.Id);
        }

        /// <summary>
        /// Set the subscription to the given globally-unique identifier
        /// </summary>
        /// <param name="subscription">The subscription tos et</param>
        /// <param name="id">The globally unique identifier</param>
        public static void SetId(this IAzureSubscription subscription, Guid id)
        {
            subscription.Id = id.ToString();
        }

        /// <summary>
        /// Get the environment this subscription resides in
        /// </summary>
        /// <param name="subscription">The subscription to check</param>
        /// <returns>The name of the environment contianing the given subscription</returns>
        public static string GetEnvironment(this IAzureSubscription subscription)
        {
            return subscription.GetProperty(AzureSubscription.Property.Environment);
        }

        /// <summary>
        /// Set the environment for the subscription
        /// </summary>
        /// <param name="subscription">The subscription to change</param>
        /// <param name="environment">The environment containing the subscription</param>
        public static void SetEnvironment(this IAzureSubscription subscription, string environment)
        {
            subscription.SetProperty(AzureSubscription.Property.Environment, environment);
        }

        /// <summary>
        /// Get the current account credentials used to access the given subscription
        /// </summary>
        /// <param name="subscription">The subscription to check</param>
        /// <returns>The displayable id of the current account credentials used to access the subscription</returns>
        public static string GetAccount(this IAzureSubscription subscription)
        {
            return subscription.GetProperty(AzureSubscription.Property.Account);
        }

        /// <summary>
        /// Set the account used to access the given subscription
        /// </summary>
        /// <param name="subscription">The subscription to change</param>
        /// <param name="account">The displayable id of the account used to access the subscription</param>
        public static void SetAccount(this IAzureSubscription subscription, string account)
        {
            subscription.SetProperty(AzureSubscription.Property.Account, account);
        }

        /// <summary>
        /// Get the current storage account for the given subscription
        /// </summary>
        /// <param name="subscription">The subscription to check</param>
        /// <returns>The current storage accoutn in the subscription, or null if no current storage account is set</returns>
        public static string GetStorageAccount(this IAzureSubscription subscription)
        {
            return subscription.GetProperty(AzureSubscription.Property.StorageAccount);
        }

        /// <summary>
        /// Set the current storage account for the subscription
        /// </summary>
        /// <param name="subscription">The subscription to change</param>
        /// <param name="account">The connection string for the target storage account</param>
        public static void SetStorageAccount(this IAzureSubscription subscription, string account)
        {
            subscription.SetProperty(AzureSubscription.Property.StorageAccount, account);
        }

        /// <summary>
        /// RDFE only: determines if this subscription is the default
        /// </summary>
        /// <param name="subscription">The subscription to check</param>
        /// <returns>True if it is the default subscription, false otherwise</returns>
        public static bool IsDefault(this IAzureSubscription subscription)
        {
            return subscription.IsPropertySet(AzureSubscription.Property.Default) && 
                string.Equals("True", subscription.GetProperty(AzureSubscription.Property.Default), System.StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Designate the given subscription as the default
        /// </summary>
        /// <param name="subscription">The subscription to change</param>
        public static void SetDefault(this IAzureSubscription subscription)
        {
            subscription.SetProperty(AzureSubscription.Property.Default, "True");
        }

        /// <summary>
        /// Get the tenants associated with this subscription
        /// </summary>
        /// <param name="subscription">The subscription to check</param>
        /// <returns>The list of tenants</returns>
        public static string GetTenant(this IAzureSubscription subscription)
        {
            return subscription.GetProperty(AzureSubscription.Property.Tenants);
        }

        /// <summary>
        /// Set the tenants associated with thsi susbcription
        /// </summary>
        /// <param name="subscription">The subscription to set</param>
        /// <param name="tenants">The tenants associated with the subscription</param>
        public static void SetTenant(this IAzureSubscription subscription, string tenant)
        {
            subscription.SetProperty(AzureSubscription.Property.Tenants, tenant);
        }

        /// <summary>
        /// Copy the properties from the given subscription
        /// </summary>
        /// <param name="subscription"></param>
        /// <param name="other"></param>
        public static void CopyFrom(this IAzureSubscription subscription, IAzureSubscription other)
        {
            if (subscription != null && other != null)
            {
                subscription.Id = other.Id;
                subscription.Name = other.Name;
                subscription.State = other.State;
                subscription.CopyPropertiesFrom(other);
            }
        }

        /// <summary>
        /// Update the non-identity properties from the given subscription
        /// </summary>
        /// <param name="subscription"></param>
        /// <param name="other"></param>
        public static void Update(this IAzureSubscription subscription, IAzureSubscription other)
        {
            if (subscription != null && other != null)
            {
                subscription.Name = other.Name?? subscription.Name;
                subscription.State = other.State?? subscription.State;
                subscription.UpdateProperties(other);
            }
        }
    }
}
