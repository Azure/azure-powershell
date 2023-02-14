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
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using System.Linq;
using System;
using System.Text;

namespace Microsoft.Azure.Commands.Compute
{
    public static class AzureContextAdapterExtensions
    {
        /// <summary>
        /// Get the current storage account.
        /// </summary>
        /// <param name="context">The current Azure context.</param>
        /// <param name="provider"></param>
        /// <returns>The current storage account, or null, if no current storage account is set.</returns>
        public static CloudStorageAccount GetCurrentStorageAccount(this IAzureContext context, IStorageServiceProvider provider)
        {
            if (context != null)
            {
                var storageConnectionString = context.GetCurrentStorageAccountConnectionString();
                try
                {
                    return
                        CloudStorageAccount.Parse(storageConnectionString);
                }
                catch
                {
                    var service = provider.GetStorageService(storageConnectionString, null);
                    return service.GetCloudStorageAccount();
                }
            }

            return null;
        }

        /// <summary>
        /// Get a CloudStorageAccount client for the storage account represented by this context
        /// </summary>
        /// <param name="context">The storage context for the storage account</param>
        /// <returns>A CloudStorageAccount client for storage data plane tasks</returns>
        public static CloudStorageAccount GetCloudStorageAccount(this IStorageContext context)
        {
            CloudStorageAccount result = null;
            CloudStorageAccount.TryParse(context.ConnectionString, out result);
            return result;
        }

        /// <summary>
        /// Get a CloudStorageAccount client for the storage account represented by this service
        /// </summary>
        /// <param name="service">The storage service</param>
        /// <returns>A CloudStorageAccount client for storage data plane tasks</returns>
        public static CloudStorageAccount GetCloudStorageAccount(this IStorageService service)
        {
            return new CloudStorageAccount(new StorageCredentials(service.Name, service.AuthenticationKeys.First()),
                new StorageUri(service.BlobEndpoint), new StorageUri(service.QueueEndpoint),
                new StorageUri(service.TableEndpoint), new StorageUri(service.FileEndpoint));
        }

        /// <summary>
        /// Get a storage context client for the storage account represented by this service
        /// </summary>
        /// <param name="service">The storage service</param>
        /// <returns>A CloudStorageAccount client for storage data plane tasks</returns>
        public static IStorageContext GetStorageContext(this IStorageService service)
        {
            return new AzureStorageContext(new CloudStorageAccount(new StorageCredentials(service.Name, service.AuthenticationKeys.First()),
                new StorageUri(service.BlobEndpoint), new StorageUri(service.QueueEndpoint),
                new StorageUri(service.TableEndpoint), new StorageUri(service.FileEndpoint)));
        }


        /// <summary>
        /// Get a CloudStorageAccount client for the given storage service using the given storage service provider
        /// </summary>
        /// <param name="provider">The storage service provider to retrieve storage service details</param>
        /// <param name="accountName">The storage accoutn name</param>
        /// <param name="resourceGroupName"></param>
        /// <returns>A CloudStorageAccount client for storage data plane tasks</returns>
        public static CloudStorageAccount GetCloudStorageAccount(this IStorageServiceProvider provider, string accountName, string resourceGroupName = null)
        {
#if DEBUG
            if (TestMockSupport.RunningMocked)
            {
                return new CloudStorageAccount(new StorageCredentials(accountName,
                    Convert.ToBase64String(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString()))), true);
            }
#endif
            return provider.GetStorageService(accountName, resourceGroupName).GetCloudStorageAccount();
        }



        /// <summary>
        /// Get a CloudStorageAccount client for the current storage service using the given storage service provider
        /// </summary>
        /// <param name="context">The current Azure context.</param>
        /// <param name="provider">The storage service provider to retrieve storage service details</param>
        /// <returns>A CloudStorageAccount client for storage data plane tasks</returns>
        public static CloudStorageAccount GetCloudStorageAccount(this IAzureContext context, IStorageServiceProvider provider)
        {
            CloudStorageAccount account;
            var storageConnectionString = context.GetCurrentStorageAccountConnectionString();
            if (!CloudStorageAccount.TryParse(storageConnectionString, out account))
            {
                if (null == provider)
                {
                    throw new ArgumentNullException("provider");
                }

                account = provider.GetCloudStorageAccount(storageConnectionString);
            }

            return account;
        }

    }
}
