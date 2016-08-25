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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Auditing.Model;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Storage;
using Microsoft.WindowsAzure.Management.Storage;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Sql.Common
{
    /// <summary>
    /// This class is responsible for all the REST communication with the management libraries
    /// </summary>
    public class AzureEndpointsCommunicator
    {
        /// <summary>
        /// The Sql management client used by this communicator
        /// </summary>
        private static SqlManagementClient SqlClient { get; set; }

        /// <summary>
        ///  The storage management client used by this communicator
        /// </summary>
        private static Microsoft.WindowsAzure.Management.Storage.StorageManagementClient StorageClient { get; set; }

        private static Microsoft.Azure.Management.Storage.StorageManagementClient StorageV2Client { get; set; }

        /// <summary>
        /// Gets or sets the Azure subscription
        /// </summary>
        private static AzureSubscription Subscription { get; set; }

        /// <summary>
        /// The resources management client used by this communicator
        /// </summary>
        private static ResourceManagementClient ResourcesClient { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public AzureContext Context { get; set; }

        /// <summary>
        /// Default Constructor.
        /// </summary>
        /// <param name="context">The Azure context</param>
        public AzureEndpointsCommunicator(AzureContext context)
        {
            Context = context;
            if (context.Subscription != Subscription)
            {
                Subscription = context.Subscription;
                StorageClient = null;
                ResourcesClient = null;
                StorageV2Client = null;
            }
        }

        /// <summary>
        /// Provides the storage keys for the storage account within the given resource group
        /// </summary>
        /// <returns>A dictionary with two entries, one for each possible key type with the appropriate key</returns>
        public async Task<Dictionary<StorageKeyKind, string>> GetStorageKeysAsync(string resourceGroupName, string storageAccountName)
        {
            SqlManagementClient client = GetCurrentSqlClient("none");

            string url = "https://management.azure.com";
            url = url + "/subscriptions/" + (client.Credentials.SubscriptionId != null ? client.Credentials.SubscriptionId.Trim() : "");
            url = url + "/resourceGroups/" + resourceGroupName;
            url = url + "/providers/Microsoft.ClassicStorage/storageAccounts/" + storageAccountName;
            url = url + "/listKeys?api-version=2014-06-01";

            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Post;
            httpRequest.RequestUri = new Uri(url);

            await client.Credentials.ProcessHttpRequestAsync(httpRequest, CancellationToken.None).ConfigureAwait(false);
            HttpResponseMessage httpResponse = await client.HttpClient.SendAsync(httpRequest, CancellationToken.None).ConfigureAwait(false);
            string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            Dictionary<StorageKeyKind, string> result = new Dictionary<StorageKeyKind, string>();
            try
            {
                JToken responseDoc = JToken.Parse(responseContent);
                string primaryKey = (string)responseDoc["primaryKey"];
                string secondaryKey = (string)responseDoc["secondaryKey"];
                if (string.IsNullOrEmpty(primaryKey) || string.IsNullOrEmpty(secondaryKey))
                    throw new Exception(); // this is caught by the synced wrapper 
                result.Add(StorageKeyKind.Primary, primaryKey);
                result.Add(StorageKeyKind.Secondary, secondaryKey);
                return result;
            }
            catch
            {
                try
                {
                    return GetV2Keys(resourceGroupName, storageAccountName);
                }
                catch
                {
                    throw;
                }
            }
        }

        private Dictionary<StorageKeyKind, string> GetV2Keys(string resourceGroupName, string storageAccountName)
        {
            Microsoft.Azure.Management.Storage.StorageManagementClient storageClient = GetCurrentStorageV2Client(Context);
            var r = storageClient.StorageAccounts.ListKeys(resourceGroupName, storageAccountName);
            string k1 = r.StorageAccountKeys.Key1;
            string k2 = r.StorageAccountKeys.Key2;
            Dictionary<StorageKeyKind, String> result = new Dictionary<StorageKeyKind, String>();
            result.Add(StorageKeyKind.Primary, k1);
            result.Add(StorageKeyKind.Secondary, k2);
            return result;
        }

        /// <summary>
        /// Gets the storage keys for the given storage account. 
        /// </summary>
        public Dictionary<StorageKeyKind, string> GetStorageKeys(string resourceGroupName, string storageAccountName)
        {
            try
            {
                return Task.Factory.StartNew((object epc) => (((AzureEndpointsCommunicator)epc).GetStorageKeysAsync(resourceGroupName, storageAccountName)),
                                                        this, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }
            catch
            {
                throw new Exception(string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.StorageAccountNotFound, storageAccountName));
            }
        }

        /// <summary>
        /// Returns the resource group of the provided storage account
        /// </summary>
        public string GetStorageResourceGroup(string storageAccountName)
        {
            ResourceManagementClient resourcesClient = GetCurrentResourcesClient(Context);
            Func<string, string> getResourceGroupName =
            resourceType =>
            {
                ResourceListResult res = resourcesClient.Resources.List(new ResourceListParameters
                {
                    ResourceGroupName = null,
                    ResourceType = resourceType,
                    TagName = null,
                    TagValue = null
                });
                var allResources = new List<GenericResourceExtended>(res.Resources);
                GenericResourceExtended account = allResources.Find(r => r.Name == storageAccountName);
                if (account != null)
                {
                    String resId = account.Id;
                    String[] segments = resId.Split('/');
                    int indexOfResoureGroup = new List<string>(segments).IndexOf("resourceGroups") + 1;
                    return segments[indexOfResoureGroup];
                }
                else
                {
                    throw new Exception(string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.StorageAccountNotFound, storageAccountName));
                }
            };
            try
            {
                return getResourceGroupName("Microsoft.ClassicStorage/storageAccounts");
            }
            catch
            {
                return getResourceGroupName("Microsoft.Storage/storageAccounts");
            }
        }

        public Dictionary<StorageKeyKind, string> GetStorageKeys(string storageName)
        {
            var resourceGroup = GetStorageResourceGroup(storageName);
            return GetStorageKeys(resourceGroup, storageName);
        }

        /// <summary>
        /// Lazy creation of a single instance of a storage client
        /// </summary>
        private Microsoft.WindowsAzure.Management.Storage.StorageManagementClient GetCurrentStorageClient(AzureContext context)
        {
            if (StorageClient == null)
                StorageClient = AzureSession.ClientFactory.CreateClient<Microsoft.WindowsAzure.Management.Storage.StorageManagementClient>(Context, AzureEnvironment.Endpoint.ServiceManagement);
            return StorageClient;
        }

        /// <summary>
        /// Lazy creation of a single instance of a storage client
        /// </summary>
        private Microsoft.Azure.Management.Storage.StorageManagementClient GetCurrentStorageV2Client(AzureContext context)
        {
            if (StorageV2Client == null)
                StorageV2Client = AzureSession.ClientFactory.CreateClient<Microsoft.Azure.Management.Storage.StorageManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            return StorageV2Client;
        }

        /// <summary>
        /// Lazy creation of a single instance of a resoures client
        /// </summary>
        private ResourceManagementClient GetCurrentResourcesClient(AzureContext context)
        {
            if (ResourcesClient == null)
                ResourcesClient = AzureSession.ClientFactory.CreateClient<ResourceManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            return ResourcesClient;
        }

        /// <summary>
        /// Retrieve the SQL Management client for the currently selected subscription, adding the session and request
        /// id tracing headers for the current cmdlet invocation.
        /// </summary>
        /// <returns>The SQL Management client for the currently selected subscription.</returns>
        private SqlManagementClient GetCurrentSqlClient(String clientRequestId)
        {
            // Get the SQL management client for the current subscription
            if (SqlClient == null)
            {
                SqlClient = AzureSession.ClientFactory.CreateClient<SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            }
            SqlClient.HttpClient.DefaultRequestHeaders.Remove(Constants.ClientRequestIdHeaderName);
            SqlClient.HttpClient.DefaultRequestHeaders.Add(Constants.ClientRequestIdHeaderName, clientRequestId);
            return SqlClient;
        }
    }
}