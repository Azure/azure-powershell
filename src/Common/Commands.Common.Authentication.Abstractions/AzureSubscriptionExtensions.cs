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
    public static class AzureSubscriptionExtensions
    {
        public static Guid GetId(this IAzureSubscription subscription)
        {
            return Guid.Parse(subscription.Id);
        }

        public static void SetId(this IAzureSubscription subscription, Guid id)
        {
            subscription.Id = id.ToString();
        }

        public static string GetEnvironment(this IAzureSubscription subscription)
        {
            return subscription.GetProperty(AzureSubscription.Property.Environment);
        }

        public static void SetEnvironment(this IAzureSubscription subscription, string environment)
        {
            subscription.SetProperty(AzureSubscription.Property.Environment, environment);
        }

        public static string GetAccount(this IAzureSubscription subscription)
        {
            return subscription.GetProperty(AzureSubscription.Property.Account);
        }

        public static void SetAccount(this IAzureSubscription subscription, string account)
        {
            subscription.SetProperty(AzureSubscription.Property.Account, account);
        }

        public static string GetStorageAccount(this IAzureSubscription subscription)
        {
            return subscription.GetProperty(AzureSubscription.Property.StorageAccount);
        }

        public static void SetStorageAccount(this IAzureSubscription subscription, string account)
        {
            subscription.SetProperty(AzureSubscription.Property.StorageAccount, account);
        }

        public static bool IsDefault(this IAzureSubscription subscription)
        {
            return subscription.IsPropertySet(AzureSubscription.Property.Default) && 
                string.Equals("True", subscription.GetProperty(AzureSubscription.Property.Default), System.StringComparison.OrdinalIgnoreCase);
        }

        public static void SetDefault(this IAzureSubscription subscription)
        {
            subscription.SetProperty(AzureSubscription.Property.Default, "True");
        }


        public static string GetProperty(this IAzureSubscription subscription, string property)
        {
            return subscription.ExtendedProperties.GetProperty(property);
        }

        public static string[] GetPropertyAsArray(this IAzureSubscription subscription, string property)
        {
            return subscription.ExtendedProperties.GetPropertyAsArray(property);
        }

        public static void SetProperty(this IAzureSubscription subscription, string property, params string[] values)
        {
            subscription.ExtendedProperties.SetProperty(property, values);
        }

        public static void SetOrAppendProperty(this IAzureSubscription subscription, string property, params string[] values)
        {
            subscription.ExtendedProperties.SetOrAppendProperty(property, values);
        }

        public static bool IsPropertySet(this IAzureSubscription subscription, string property)
        {
            return subscription.ExtendedProperties.IsPropertySet(property);
        }
    }
}
