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

using Microsoft.Azure.Commands.Sql.Security.Model;
using Microsoft.Azure.Commands.Sql.Services;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Models;
using Microsoft.WindowsAzure.Management.Storage;
using Microsoft.WindowsAzure.Management.Storage.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Sql.Security.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the management libraries
    /// </summary>
    public class EndpointsCommunicator
    {
        private static SqlManagementClient SqlClient { get; set; }
        
        private static StorageManagementClient StorageClient { get; set; }
        
        private static AzureSubscription Subscription {get ; set; }

        private static ResourceManagementClient ResourcesClient { get; set; }
 
        public EndpointsCommunicator(AzureSubscription subscription)
        {
            if (subscription != Subscription)
            {
                Subscription = subscription;
                SqlClient = null;
                StorageClient = null;
                ResourcesClient = null;
            }
        }

        /// <summary>
        /// Gets the database security policy for the given database in the given database server in the given resource group
        /// </summary>
        public DatabaseSecurityPolicy GetDatabaseSecurityPolicy(string resourceGroupName, string serverName, string databaseName, string clientRequestId)
        {
            ISecurityOperations operations = GetCurrentSqlClient(clientRequestId).DatabaseSecurity;
            DatabaseSecurityPolicyGetResponse response = operations.Get(resourceGroupName, serverName, databaseName);
            return response.DatabaseSecurityPolicy;
        }

        /// <summary>
        /// Gets the database server security policy of the given database server in the given resource group
        /// </summary>
        public DatabaseSecurityPolicy GetServerSecurityPolicy(string resourceGroupName, string serverName, string clientRequestId)
        {
            ISecurityOperations operations = GetCurrentSqlClient(clientRequestId).DatabaseSecurity;
            DatabaseSecurityPolicyGetResponse response = operations.Get(resourceGroupName, serverName, Constants.ServerPolicyId);
            return response.DatabaseSecurityPolicy;
        }

        /// <summary>
        /// Sets the database security policy for the given database in the given database server in the given resource group
        /// </summary>
        public void SetDatabaseSecurityPolicy(string resourceGroupName, string serverName, string databaseName, string clientRequestId, DatabaseSecurityPolicyUpdateParameters parameters)
        {
            ISecurityOperations operations = GetCurrentSqlClient(clientRequestId).DatabaseSecurity;
            operations.Update(resourceGroupName, serverName, databaseName, parameters);
        }

        /// <summary>
        /// Sets the database server security policy of the given database server in the given resource group
        /// </summary>
        public void SetServerSecurityPolicy(string resourceGroupName, string serverName,  string clientRequestId, DatabaseSecurityPolicyUpdateParameters parameters)
        {
            ISecurityOperations operations = GetCurrentSqlClient(clientRequestId).DatabaseSecurity;
            operations.Update(resourceGroupName, serverName, Constants.ServerPolicyId, parameters);
        }


        public async Task<Dictionary<Constants.StorageKeyTypes, string>> GetStorageKeysAsync(string resourceGroupName, string storageAccountName)
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

            Dictionary<Constants.StorageKeyTypes, String> result = new Dictionary<Constants.StorageKeyTypes, String>();
            string primaryKey = (string)responseDoc["primaryKey"];
            string secondaryKey = (string)responseDoc["secondaryKey"];
            if(string.IsNullOrEmpty(primaryKey) || string.IsNullOrEmpty(secondaryKey))
                throw new Exception(); // this is caught by the synced wrapper 
            result.Add(Constants.StorageKeyTypes.Primary, primaryKey);
            result.Add(Constants.StorageKeyTypes.Secondary, secondaryKey);
            return result;
        }

        
        /// <summary>
        /// Gets the storage keys for the given storage account. 
        /// </summary>
        public Dictionary<Constants.StorageKeyTypes, string> GetStorageKeys(string resourceGroupName, string storageAccountName)
        {
            try
            {
                return Task.Factory.StartNew((object epc) =>
                {
                    return ((EndpointsCommunicator)epc).GetStorageKeysAsync(resourceGroupName, storageAccountName);
                }
                , this, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }
            catch
            {
                throw new Exception(string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.StorageAccountNotFound, storageAccountName));
            }
        }

        public string GetStorageResourceGroup(string storageAccountName)
        {
            ResourceManagementClient resourcesClient = GetCurrentResourcesClient();
            
            ResourceListResult res = resourcesClient.Resources.List(new ResourceListParameters
                    {
                        ResourceGroupName = null,
                        ResourceType = "Microsoft.ClassicStorage/storageAccounts",
                        TagName = null,
                        TagValue = null
                    });
            List<Resource> allResources = new List<Resource>(res.Resources);
            
            if (allResources.Count != 0)
            {
                Resource account = allResources.Find(r => r.Name == storageAccountName);
                if (account != null)
                {
                    String resId =  account.Id;
                    String[] segments = resId.Split('/');
                    int indexOfResoureGroup = new List<string>(segments).IndexOf("resourceGroups") +1;
                    return segments[indexOfResoureGroup];
                }     
                else
                {
                    throw new Exception(string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.StorageAccountNotFound, storageAccountName));
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the storage table endpoint the given storage account
        /// </summary>
        public string GetStorageTableEndpoint(string storageAccountName)
        {
            try
            {
                List<Uri> endpoints = new List<Uri>(GetCurrentStorageClient().StorageAccounts.Get(storageAccountName).StorageAccount.Properties.Endpoints);
                return endpoints.Find(u => u.AbsoluteUri.Contains(".table.")).AbsoluteUri;
            }
            catch
            {
                throw new Exception(string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.StorageAccountNotFound, storageAccountName));
            }
        }

        private StorageManagementClient GetCurrentStorageClient()
        {
            if(StorageClient == null)
                StorageClient = AzureSession.ClientFactory.CreateClient<StorageManagementClient>(Subscription, AzureEnvironment.Endpoint.ServiceManagement);
            return StorageClient;
        }

        private ResourceManagementClient GetCurrentResourcesClient()
        {
            if (ResourcesClient == null)
                ResourcesClient = AzureSession.ClientFactory.CreateClient<ResourceManagementClient>(Subscription, AzureEnvironment.Endpoint.ResourceManager);
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
                SqlClient = AzureSession.ClientFactory.CreateClient<SqlManagementClient>(Subscription, AzureEnvironment.Endpoint.ResourceManager);
                SqlClient.HttpClient.DefaultRequestHeaders.Add(Constants.ClientSessionIdHeaderName, Util.GenerateTracingId());
            }
            SqlClient.HttpClient.DefaultRequestHeaders.Remove(Constants.ClientRequestIdHeaderName);
            SqlClient.HttpClient.DefaultRequestHeaders.Add(Constants.ClientRequestIdHeaderName, clientRequestId);
            return SqlClient;
        }
    }
}
