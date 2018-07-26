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
using System.Text;
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
        /// Lazy creation of a single instance of a storage client
        /// </summary>
        public static Microsoft.Azure.Management.Storage.StorageManagementClient GetStorageV2Client(IAzureContext context)
        {
#if NETSTANDARD
            return AzureSession.Instance.ClientFactory.CreateArmClient<Microsoft.Azure.Management.Storage.StorageManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
#else
            return AzureSession.Instance.ClientFactory.CreateClient<Microsoft.Azure.Management.Storage.StorageManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
#endif
        }

        /// <summary>
        /// Provides the storage keys for the storage account within the given resource group
        /// </summary>
        /// <returns>A dictionary with two entries, one for each possible key type with the appropriate key</returns>
        public async Task<Dictionary<StorageKeyKind, string>> GetStorageKeysAsync(string resourceGroupName, string storageAccountName)
        {
            Management.Storage.StorageManagementClient client = GetCurrentStorageV2Client();

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
            Microsoft.Azure.Management.Storage.StorageManagementClient storageClient = GetCurrentStorageV2Client();
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
        private Microsoft.Azure.Management.Storage.StorageManagementClient GetCurrentStorageV2Client()
        {
            if (StorageV2Client == null)
            {
                StorageV2Client = GetStorageV2Client(Context);
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

        /// <summary>
        /// Retrieves storage keys.
        /// </summary>
        /// <param name="storageAccountSubscriptionId">Storage account subscription id</param>
        /// <param name="storageAccountName">Storage account name</param>
        /// <returns>Dictionary containing storage keys</returns>
        internal Dictionary<StorageKeyKind, string> RetrieveStorageKeys(Guid storageAccountSubscriptionId, string storageAccountName)
        {
            // Retrieve the id of the storage account.
            //
            string storageAccountId = RetrieveStorageAccountIdAsync(storageAccountSubscriptionId, storageAccountName).GetAwaiter().GetResult();

            // Extract storage account keys. 
            //
            return RetrieveStorageKeysAsync(storageAccountId).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Retrieves storage account keys.
        /// </summary>
        /// <param name="storageAccountId">Storage account id</param>
        /// <returns>Dictionary containing storage keys</returns>
        private async Task<Dictionary<StorageKeyKind, string>> RetrieveStorageKeysAsync(string storageAccountId)
        {
            bool isClassicStorage = storageAccountId.Contains("Microsoft.ClassicStorage/storageAccounts");

            // Build a URI for calling corresponding REST-API
            //
            StringBuilder uriBuilder = new StringBuilder(Context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager).ToString());
            uriBuilder.AppendFormat("{0}/listKeys?api-version={1}",
                storageAccountId,
                isClassicStorage ? ClassicStorageListKeysApiVersion : NonClassicStorageListKeysApiVersion);

            // Define an exception to be thrown on failure.
            //
            Exception exception = new Exception(string.Format(Properties.Resources.RetrievingStorageAccountKeysFailed, storageAccountId));

            // Call the URI and get storage account keys.
            //
            JToken storageAccountKeysResponse = await SendAsync(uriBuilder.ToString(), HttpMethod.Post, exception);

            // Extract keys out of response.
            //
            Dictionary<StorageKeyKind, string> storageAccountKeys = new Dictionary<StorageKeyKind, string>();
            string primaryKey = null;
            string secondaryKey = null;
            if (isClassicStorage)
            {
                primaryKey = (string)storageAccountKeysResponse[PrimaryKey];
                secondaryKey = (string)storageAccountKeysResponse[SecondaryKey];
            }
            else
            {
                JArray storageAccountKeysArray = (JArray)storageAccountKeysResponse["keys"];
                if (storageAccountKeysArray == null)
                {
                    throw exception;
                }

                primaryKey = (string)storageAccountKeysArray[0]["value"];
                secondaryKey = (string)storageAccountKeysArray[1]["value"];
            }

            if (string.IsNullOrEmpty(primaryKey) || string.IsNullOrEmpty(secondaryKey))
            {
                throw exception;
            }

            storageAccountKeys.Add(StorageKeyKind.Primary, primaryKey);
            storageAccountKeys.Add(StorageKeyKind.Secondary, secondaryKey);
            return storageAccountKeys;
        }

        /// <summary>
        /// Retrieves id of a storage account
        /// </summary>
        /// <param name="storageAccountSubscriptionId">Storage account subscription id</param>
        /// <param name="storageAccountName">Storage account name</param>
        /// <returns>Id of the storage account</returns>
        private async Task<string> RetrieveStorageAccountIdAsync(Guid storageAccountSubscriptionId, string storageAccountName)
        {
            // Build a URI for calling corresponding REST-API.
            //
            StringBuilder uriBuilder = new StringBuilder(Context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager).ToString());
            uriBuilder.AppendFormat("/resources?api-version=2018-05-01&$filter=(subscriptionId%20eq%20'{0}')%20and%20((resourceType%20eq%20'microsoft.storage/storageaccounts')%20or%20(resourceType%20eq%20'microsoft.classicstorage/storageaccounts'))%20and%20(name%20eq%20'{1}')",
                storageAccountSubscriptionId,
                storageAccountName);
            string nextLink = uriBuilder.ToString();
            JToken response = null;

            while (!string.IsNullOrEmpty(nextLink))
            {
                response = await SendAsync(nextLink, HttpMethod.Get, new Exception(string.Format(Properties.Resources.RetrievingStorageAccountIdUnderSubscriptionFailed, storageAccountName, storageAccountSubscriptionId)));
                nextLink = (string)response["nextLink"];
            }

            JArray valuesArray = (JArray)response["value"];
            if (!valuesArray.HasValues)
            {
                throw new Exception(string.Format(Properties.Resources.StorageAccountNotFound, storageAccountName));
            }

            JToken idValueToken = valuesArray[0];
            string id = (string)idValueToken["id"];
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception(string.Format(Properties.Resources.RetrievingStorageAccountIdUnderSubscriptionFailed, storageAccountName, storageAccountSubscriptionId));
            }

            return id;
        }

        /// <summary>
        /// Sends an async HTTP request.
        /// </summary>
        /// <param name="url">URL of the request.</param>
        /// <param name="method">Http method.</param>
        /// <param name="exceptionToThrowOnFailure">Exception to be thrown if request did not succeed.</param>
        /// <returns>Response of the request.</returns>
        private async Task<JToken> SendAsync(string url, HttpMethod method, Exception exceptionToThrowOnFailure)
        {
            ResourceManagementClient client = GetCurrentResourcesClient(Context);
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = method;
            httpRequest.RequestUri = new Uri(url);
            await client.Credentials.ProcessHttpRequestAsync(httpRequest, CancellationToken.None).ConfigureAwait(false);
            HttpResponseMessage httpResponse = await client.HttpClient.SendAsync(httpRequest, CancellationToken.None).ConfigureAwait(false);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw exceptionToThrowOnFailure;
            }

            return JToken.Parse(await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
        }
        
        /// <summary>
        /// Verson of classic storage listKeys REST-API.
        /// </summary>
        private const string ClassicStorageListKeysApiVersion = "2016-11-01";
        
        /// <summary>
        /// Verson of non classic storage listKeys REST-API.
        /// </summary>
        private const string NonClassicStorageListKeysApiVersion = "2017-06-01";
        
        private const string PrimaryKey = "primaryKey";
        
        private const string SecondaryKey = "secondaryKey";
    }
}
