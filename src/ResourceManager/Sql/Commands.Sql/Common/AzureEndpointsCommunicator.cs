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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Sql.Auditing.Model;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.Azure.Management.Storage;
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
        ///  The storage management client used by this communicator
        /// </summary>
        private static Microsoft.Azure.Management.Storage.StorageManagementClient StorageV2Client { get; set; }

        /// <summary>
        /// Gets or sets the Azure subscription
        /// </summary>
        private static IAzureSubscription Subscription { get; set; }

        /// <summary>
        /// The resources management client used by this communicator
        /// </summary>
        private static ResourceManagementClient ResourcesClient { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Default Constructor.
        /// </summary>
        /// <param name="context">The Azure context</param>
        public AzureEndpointsCommunicator(IAzureContext context)
        {
            Context = context;
            if (context.Subscription != Subscription)
            {
                Subscription = context.Subscription;
                ResourcesClient = null;
                StorageV2Client = null;
            }
        }

        private static class StorageAccountType
        {
            public const string ClassicStorage = "Microsoft.ClassicStorage/storageAccounts";
            public const string Storage = "Microsoft.Storage/storageAccounts";
        }

        /// <summary>
        /// Provides the storage keys for the storage account within the given resource group
        /// </summary>
        /// <returns>A dictionary with two entries, one for each possible key type with the appropriate key</returns>
        public async Task<Dictionary<StorageKeyKind, string>> GetStorageKeysAsync(string resourceGroupName, string storageAccountName)
        {
            Management.Storage.StorageManagementClient client = GetCurrentStorageV2Client(Context);

            string url = Context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager).ToString();
            if (!url.EndsWith("/"))
            {
                url = url + "/";
            }

#if NETSTANDARD
            url = url + "subscriptions/" + (client.SubscriptionId != null ? client.SubscriptionId.Trim() : "");
#else
            url = url + "subscriptions/" + (client.Credentials.SubscriptionId != null ? client.Credentials.SubscriptionId.Trim() : "");
#endif
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
                return GetV2Keys(resourceGroupName, storageAccountName);
            }
        }

        private Dictionary<StorageKeyKind, string> GetV2Keys(string resourceGroupName, string storageAccountName)
        {
            Microsoft.Azure.Management.Storage.StorageManagementClient storageClient = GetCurrentStorageV2Client(Context);
            var r = storageClient.StorageAccounts.ListKeys(resourceGroupName, storageAccountName);
#if NETSTANDARD
            string k1 = r.Keys[0].Value;
            string k2 = r.Keys[1].Value;
#else
            string k1 = r.StorageAccountKeys.Key1;
            string k2 = r.StorageAccountKeys.Key2;
#endif
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
                return this.GetStorageKeysAsync(resourceGroupName, storageAccountName).GetAwaiter().GetResult();
            }
            catch (Exception e)
            {
                throw new Exception(string.Format(Properties.Resources.StorageAccountNotFound, storageAccountName), e);
            }
        }

        /// <summary>
        /// Returns the resource group of the provided storage account
        /// </summary>
        public string GetStorageResourceGroup(string storageAccountName)
        {
            ResourceManagementClient resourcesClient = GetCurrentResourcesClient(Context);

            foreach (string storageAccountType in new[] { StorageAccountType.ClassicStorage, StorageAccountType.Storage })
            {
                string resourceGroup = GetStorageResourceGroup(
                    resourcesClient,
                    storageAccountName,
                    storageAccountType);

                if (resourceGroup != null)
                {
                    return resourceGroup;
                }
            }

            throw new Exception(string.Format(Properties.Resources.StorageAccountNotFound, storageAccountName));
        }

        private string GetStorageResourceGroup(
            ResourceManagementClient resourcesClient,
            string storageAccountName,
            string resourceType)
        {
            var query = new Rest.Azure.OData.ODataQuery<GenericResourceFilter>(r => r.ResourceType == resourceType);
            Rest.Azure.IPage<GenericResource> res = resourcesClient.Resources.List(query);
            var allResources = new List<GenericResource>(res);
            GenericResource account = allResources.Find(r => r.Name == storageAccountName);
            if (account != null)
            {
                string resId = account.Id;
                string[] segments = resId.Split('/');
                int indexOfResoureGroup = new List<string>(segments).IndexOf("resourceGroups") + 1;
                return segments[indexOfResoureGroup];
            }
            else
            {
                return null;
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
        private Microsoft.Azure.Management.Storage.StorageManagementClient GetCurrentStorageV2Client(IAzureContext context)
        {
            if (StorageV2Client == null)
            {
#if NETSTANDARD
                StorageV2Client = AzureSession.Instance.ClientFactory.CreateArmClient<Microsoft.Azure.Management.Storage.StorageManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
#else
                StorageV2Client = AzureSession.Instance.ClientFactory.CreateClient<Microsoft.Azure.Management.Storage.StorageManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
#endif
            }
            return StorageV2Client;
        }

        /// <summary>
        /// Lazy creation of a single instance of a resoures client
        /// </summary>
        private ResourceManagementClient GetCurrentResourcesClient(IAzureContext context)
        {
            if (ResourcesClient == null)
            {
                ResourcesClient = AzureSession.Instance.ClientFactory.CreateArmClient<ResourceManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            }
            return ResourcesClient;
        }
    }
}
