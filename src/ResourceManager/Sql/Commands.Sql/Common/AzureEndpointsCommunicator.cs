﻿// ----------------------------------------------------------------------------------
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
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Sql.Properties;
using Microsoft.Azure.Commands.Sql.Security.Model;
using Microsoft.Azure.Commands.Sql.Security.Services;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.WindowsAzure.Management.Storage;
using Newtonsoft.Json.Linq;

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
        private static StorageManagementClient StorageClient { get; set; }
        
        /// <summary>
        /// Gets or sets the Azure subscription
        /// </summary>
        private static AzureSubscription Subscription {get ; set; }

        /// <summary>
        /// The resources management client used by this communicator
        /// </summary>
        private static ResourceManagementClient ResourcesClient { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public AzureProfile Profile { get; set; }

        /// <summary>
        /// Default Constructor.
        /// </summary>
        /// <param name="profile">The current azure profile</param>
        /// <param name="subscription">The current azure subscription</param>
        public AzureEndpointsCommunicator(AzureProfile profile, AzureSubscription subscription)
        {
            Profile = profile;
            if (subscription != Subscription)
            {
                Subscription = subscription;
                StorageClient = null;
                ResourcesClient = null;
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
            JToken responseDoc = JToken.Parse(responseContent);

            Dictionary<StorageKeyKind, String> result = new Dictionary<StorageKeyKind, String>();
            string primaryKey = (string)responseDoc["primaryKey"];
            string secondaryKey = (string)responseDoc["secondaryKey"];
            if(string.IsNullOrEmpty(primaryKey) || string.IsNullOrEmpty(secondaryKey))
                throw new Exception(); // this is caught by the synced wrapper 
            result.Add(StorageKeyKind.Primary, primaryKey);
            result.Add(StorageKeyKind.Secondary, secondaryKey);
            return result;
        }
        
        /// <summary>
        /// Gets the storage keys for the given storage account. 
        /// </summary>
        public Dictionary<StorageKeyKind, string> GetStorageKeys(string resourceGroupName, string storageAccountName)
        {
            try
            {
                return Task.Factory.StartNew((object epc) =>
                {
                    return ((AzureEndpointsCommunicator)epc).GetStorageKeysAsync(resourceGroupName, storageAccountName);
                }
                , this, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }
            catch
            {
                throw new Exception(string.Format(Resources.StorageAccountNotFound, storageAccountName));
            }
        }

        /// <summary>
        /// Returns the resource group of the provided storage account
        /// </summary>
        public string GetStorageResourceGroup(string storageAccountName)
        {
            ResourceManagementClient resourcesClient = GetCurrentResourcesClient(Profile);
            
            ResourceListResult res = resourcesClient.Resources.List(new ResourceListParameters
                    {
                        ResourceGroupName = null,
                        ResourceType = "Microsoft.ClassicStorage/storageAccounts",
                        TagName = null,
                        TagValue = null
                    });
            var allResources = new List<GenericResourceExtended>(res.Resources);
            
            if (allResources.Count != 0)
            {
                GenericResourceExtended account = allResources.Find(r => r.Name == storageAccountName);
                if (account != null)
                {
                    String resId =  account.Id;
                    String[] segments = resId.Split('/');
                    int indexOfResoureGroup = new List<string>(segments).IndexOf("resourceGroups") +1;
                    return segments[indexOfResoureGroup];
                }     
                else
                {
                    throw new Exception(string.Format(Resources.StorageAccountNotFound, storageAccountName));
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the storage table endpoint the given storage account
        /// </summary>
        public string GetStorageTableEndpoint(AzureProfile profile, string storageAccountName)
        {
            try
            {
                List<Uri> endpoints = new List<Uri>(GetCurrentStorageClient(profile).StorageAccounts.Get(storageAccountName).StorageAccount.Properties.Endpoints);
                return endpoints.Find(u => u.AbsoluteUri.Contains(".table.")).AbsoluteUri;
            }
            catch
            {
                throw new Exception(string.Format(Resources.StorageAccountNotFound, storageAccountName));
            }
        }

        /// <summary>
        /// Lazy creation of a single instance of a storage client
        /// </summary>
        private StorageManagementClient GetCurrentStorageClient(AzureProfile profile)
        {
            if(StorageClient == null)
                StorageClient = AzureSession.ClientFactory.CreateClient<StorageManagementClient>(profile, Subscription, AzureEnvironment.Endpoint.ServiceManagement);
            return StorageClient;
        }

        /// <summary>
        /// Lazy creation of a single instance of a resoures client
        /// </summary>
        private ResourceManagementClient GetCurrentResourcesClient(AzureProfile profile)
        {
            if (ResourcesClient == null)
                ResourcesClient = AzureSession.ClientFactory.CreateClient<ResourceManagementClient>(profile, Subscription, AzureEnvironment.Endpoint.ResourceManager);
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
                SqlClient = AzureSession.ClientFactory.CreateClient<SqlManagementClient>(Profile, Subscription, AzureEnvironment.Endpoint.ResourceManager);
            }
            SqlClient.HttpClient.DefaultRequestHeaders.Remove(Constants.ClientRequestIdHeaderName);
            SqlClient.HttpClient.DefaultRequestHeaders.Add(Constants.ClientRequestIdHeaderName, clientRequestId);
            return SqlClient;
        }
    }
}