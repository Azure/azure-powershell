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
using System;

namespace Microsoft.WindowsAzure.Commands.Utilities.Common
{
    public static class AzureContextExtensions
    {
        const string storageFormatTemplate = "{{0}}://{{1}}.{0}.{1}/";
        const string StorageContextConnectionString = "StorageContextConnectionString";

        /// <summary>
        /// Set the current storage account using the given connection string
        /// </summary>
        /// <param name="context">The current context.</param>
        /// <param name="connectionString">The connection string to check.</param>
        public static void SetCurrentStorageAccount(this IAzureContext context, string connectionString)
        {
            if (context.Subscription != null)
            {
                context.Subscription.SetStorageAccount(connectionString);
            }
        }

        /// <summary>
        /// Set the current storageaccount using the given storage context
        /// </summary>
        /// <param name="context">The Azure context to set the current storage account in</param>
        /// <param name="storageContext">The context to set as the current storage context</param>
        public static void SetCurrentStorageAccount(this IAzureContext context, IStorageContext storageContext)
        {
            if (storageContext != null && storageContext.ConnectionString != null)
            {
                context.SetCurrentStorageAccount(storageContext.ConnectionString);
            }
        }

        /// <summary>
        /// Set the current storage account using the given connection string.
        /// </summary>
        /// <param name="context">The current context.</param>
        /// <param name="account">A storage account.</param>
        public static void SetCurrentStorageAccount(this IAzureContext context, IStorageContextProvider account)
        {
            context.SetCurrentStorageAccount(account.Context);
        }

        /// <summary>
        /// Return the connection string for the current storage account from the given context
        /// </summary>
        /// <param name="context">The context to retrieve storage account information from.</param>
        /// <returns>A connection string for the current storage account, or null if no current 
        /// storage account is selected.</returns>
        public static string GetCurrentStorageAccountConnectionString(this IAzureContext context)
        {
            string result = null; 
            if (context.Subscription != null)
            {
                result = context.Subscription.GetStorageAccount();
            }

            return result;
        }


        /// <summary>
        /// Get the endpoint for the blob service for the given storage account in this environment
        /// </summary>
        /// <param name="environment">The environment containing the storage account</param>
        /// <param name="storageAccountName">The name of the storage account</param>
        /// <param name="useHttps">True if https should be use din communicating with the storage service, otherwise false</param>
        /// <returns>The Uri of the blob service for the given service in the given environment</returns>
        public static Uri GetStorageBlobEndpoint(this IAzureEnvironment environment, string storageAccountName, bool useHttps = true)
        {
            return new Uri(string.Format(environment.StorageBlobEndpointFormat(), useHttps ? "https" : "http", storageAccountName));
        }

        /// <summary>
        /// Get the endpoint for the file service for the given storage account in this environment
        /// </summary>
        /// <param name="environment">The environment containing the storage account</param>
        /// <param name="storageAccountName">The name of the storage account</param>
        /// <param name="useHttps">True if https should be use din communicating with the storage service, otherwise false</param>
        /// <returns>The Uri of the file service for the given service in the given environment</returns>
        public static Uri GetStorageFileEndpoint(this IAzureEnvironment environment, string storageAccountName, bool useHttps = true)
        {
            return new Uri(string.Format(environment.StorageFileEndpointFormat(), useHttps ? "https" : "http", storageAccountName));
        }

        /// <summary>
        /// Get the endpoint for the queue service for the given storage account in this environment
        /// </summary>
        /// <param name="environment">The environment containing the storage account</param>
        /// <param name="storageAccountName">The name of the storage account</param>
        /// <param name="useHttps">True if https should be used in communicating with the storage service, otherwise false</param>
        /// <returns>The Uri of the queue service for the given service in the given environment</returns>
        public static Uri GetStorageQueueEndpoint(this IAzureEnvironment environment, string storageAccountName, bool useHttps = true)
        {
            return new Uri(string.Format(environment.StorageQueueEndpointFormat(), useHttps ? "https" : "http", storageAccountName));
        }

        /// <summary>
        /// Get the endpoint for the table service for the given storage account in this environment
        /// </summary>
        /// <param name="environment">The environment containing the storage account</param>
        /// <param name="storageAccountName">The name of the storage account</param>
        /// <param name="useHttps">True if https should be used in communicating with the storage service, otherwise false</param>
        /// <returns>The Uri of the table service for the given service in the given environment</returns>
        public static Uri GetStorageTableEndpoint(this IAzureEnvironment environment, string storageAccountName, bool useHttps = true)
        {
            return new Uri(string.Format(environment.StorageTableEndpointFormat(), useHttps ? "https" : "http", storageAccountName));
        }

        private static string EndpointFormatFor(this IAzureEnvironment environment, string service)
        {
            string suffix = environment.StorageEndpointSuffix;

            if (!string.IsNullOrEmpty(suffix))
            {
                suffix = string.Format(storageFormatTemplate, service, suffix);
            }

            return suffix;
        }

        /// <summary>
        /// The storage service blob endpoint format.
        /// </summary>
        private static string StorageBlobEndpointFormat(this IAzureEnvironment environment)
        {
            return environment.EndpointFormatFor("blob");
        }

        /// <summary>
        /// The storage service queue endpoint format.
        /// </summary>
        private static string StorageQueueEndpointFormat(this IAzureEnvironment environment)
        {
            return environment.EndpointFormatFor("queue");
        }

        /// <summary>
        /// The storage service table endpoint format.
        /// </summary>
        private static string StorageTableEndpointFormat(this IAzureEnvironment environment)
        {
            return environment.EndpointFormatFor("table");
        }

        /// <summary>
        /// The storage service file endpoint format.
        /// </summary>
        private static string StorageFileEndpointFormat(this IAzureEnvironment environment)
        {
            return environment.EndpointFormatFor("file");
        }

    }
}
