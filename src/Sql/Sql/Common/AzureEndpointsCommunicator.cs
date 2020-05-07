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
using Microsoft.Azure.Commands.Sql.DataClassification.Services;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.Azure.Management.Storage.Version2017_10_01;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private static StorageManagementClient StorageV2Client { get; set; }

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
            if (context?.Subscription != Subscription)
            {
                Subscription = context?.Subscription;
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
        public static StorageManagementClient GetStorageV2Client(IAzureContext context)
        {
            // TODO: Remove IfDef
#if NETSTANDARD
            return AzureSession.Instance.ClientFactory.CreateArmClient<StorageManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
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
            var client = GetCurrentStorageV2Client();

            var url = Context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager).ToString();
            if (!url.EndsWith("/"))
            {
                url = url + "/";
            }
            // TODO: Remove IfDef
#if NETSTANDARD
            url = url + "subscriptions/" + (client.SubscriptionId != null ? client.SubscriptionId.Trim() : "");
#else
            url = url + "subscriptions/" + (client.Credentials.SubscriptionId != null ? client.Credentials.SubscriptionId.Trim() : "");
#endif
            url = url + "/resourceGroups/" + resourceGroupName;
            url = url + "/providers/Microsoft.ClassicStorage/storageAccounts/" + storageAccountName;
            url = url + "/listKeys?api-version=2014-06-01";

            var httpRequest = new HttpRequestMessage { Method = HttpMethod.Post, RequestUri = new Uri(url) };

            await client.Credentials.ProcessHttpRequestAsync(httpRequest, CancellationToken.None).ConfigureAwait(false);
            var httpResponse = await client.HttpClient.SendAsync(httpRequest, CancellationToken.None).ConfigureAwait(false);
            var responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            var result = new Dictionary<StorageKeyKind, string>();
            try
            {
                var responseDoc = JToken.Parse(responseContent);
                var primaryKey = (string)responseDoc["primaryKey"];
                var secondaryKey = (string)responseDoc["secondaryKey"];
                if (string.IsNullOrEmpty(primaryKey) || string.IsNullOrEmpty(secondaryKey))
                {
                    throw new Exception(); // this is caught by the synced wrapper
                }

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
            var storageClient = GetCurrentStorageV2Client();
            var r = storageClient.StorageAccounts.ListKeys(resourceGroupName, storageAccountName);
            // TODO: Remove IfDef
#if NETSTANDARD
            var k1 = r.Keys[0].Value;
            var k2 = r.Keys[1].Value;
#else
            string k1 = r.StorageAccountKeys.Key1;
            string k2 = r.StorageAccountKeys.Key2;
#endif
            var result = new Dictionary<StorageKeyKind, String>
            {
                {StorageKeyKind.Primary, k1}, {StorageKeyKind.Secondary, k2}
            };
            return result;
        }

        /// <summary>
        /// Gets the storage keys for the given storage account.
        /// </summary>
        public Dictionary<StorageKeyKind, string> GetStorageKeys(string resourceGroupName, string storageAccountName)
        {
            try
            {
                return GetStorageKeysAsync(resourceGroupName, storageAccountName).GetAwaiter().GetResult();
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
            var resourcesClient = GetCurrentResourcesClient(Context);

            foreach (var storageAccountType in new[] { StorageAccountType.ClassicStorage, StorageAccountType.Storage })
            {
                var resourceGroup = GetStorageResourceGroup(
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

        private static string GetStorageResourceGroup(
            ResourceManagementClient resourcesClient,
            string storageAccountName,
            string resourceType)
        {
            var query = new Rest.Azure.OData.ODataQuery<GenericResourceFilter>(r => r.ResourceType == resourceType);
            var res = resourcesClient.Resources.List(query);
            var allResources = new List<GenericResource>(res);
            var account = allResources.Find(r => r.Name == storageAccountName);
            if (account == null)
            {
                return null;
            }

            var resId = account.Id;
            var segments = resId.Split('/');
            var indexOfResourceGroup = new List<string>(segments).IndexOf("resourceGroups") + 1;
            return segments[indexOfResourceGroup];
        }

        public Dictionary<StorageKeyKind, string> GetStorageKeys(string storageName)
        {
            var resourceGroup = GetStorageResourceGroup(storageName);
            return GetStorageKeys(resourceGroup, storageName);
        }

        /// <summary>
        /// Lazy creation of a single instance of a storage client
        /// </summary>
        private StorageManagementClient GetCurrentStorageV2Client()
        {
            return StorageV2Client ?? (StorageV2Client = GetStorageV2Client(Context));
        }

        /// <summary>
        /// Lazy creation of a single instance of a resources client
        /// </summary>
        private ResourceManagementClient GetCurrentResourcesClient(IAzureContext context)
        {
            return ResourcesClient ?? (ResourcesClient =
                       AzureSession.Instance.ClientFactory.CreateArmClient<ResourceManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager));
        }

        /// <summary>
        /// Retrieves storage account keys.
        /// </summary>
        /// <param name="storageAccountId">Storage account id</param>
        /// <returns>Dictionary containing storage keys</returns>
        internal async Task<Dictionary<StorageKeyKind, string>> RetrieveStorageKeysAsync(string storageAccountId)
        {
            var isClassicStorage = IsClassicStorage(storageAccountId);

            // Build a URI for calling corresponding REST-API
            //
            var uriBuilder = new StringBuilder(Context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager).ToString());
            uriBuilder.AppendFormat("{0}/listKeys?api-version={1}",
                storageAccountId,
                isClassicStorage ? ClassicStorageListKeysApiVersion : NonClassicStorageListKeysApiVersion);

            // Define an exception to be thrown on failure.
            //
            var exception = new Exception(string.Format(Properties.Resources.RetrievingStorageAccountKeysFailed, storageAccountId));

            // Call the URI and get storage account keys.
            //
            var storageAccountKeysResponse = await SendAsync(uriBuilder.ToString(), HttpMethod.Post, exception);

            // Extract keys out of response.
            //
            var storageAccountKeys = new Dictionary<StorageKeyKind, string>();
            string primaryKey;
            string secondaryKey;
            if (isClassicStorage)
            {
                primaryKey = (string)storageAccountKeysResponse[PrimaryKey];
                secondaryKey = (string)storageAccountKeysResponse[SecondaryKey];
            }
            else
            {
                var storageAccountKeysArray = (JArray)storageAccountKeysResponse["keys"];
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
        internal async Task<string> RetrieveStorageAccountIdAsync(Guid storageAccountSubscriptionId, string storageAccountName)
        {
            // Build a URI for calling corresponding REST-API.
            //
            var uriBuilder = new StringBuilder(Context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager).ToString());
            uriBuilder.AppendFormat("/resources?api-version=2018-05-01&$filter=(subscriptionId%20eq%20'{0}')%20and%20((resourceType%20eq%20'microsoft.storage/storageaccounts')%20or%20(resourceType%20eq%20'microsoft.classicstorage/storageaccounts'))%20and%20(name%20eq%20'{1}')",
                storageAccountSubscriptionId,
                storageAccountName);

            var nextLink = uriBuilder.ToString();
            string id = null;
            while (!string.IsNullOrEmpty(nextLink))
            {
                JToken response = await SendAsync(nextLink, HttpMethod.Get, new Exception(string.Format(Properties.Resources.RetrievingStorageAccountIdUnderSubscriptionFailed, storageAccountName, storageAccountSubscriptionId)));
                var valuesArray = (JArray)response["value"];
                if (valuesArray.HasValues)
                {
                    var idValueToken = valuesArray[0];
                    id = (string)idValueToken["id"];
                    if (string.IsNullOrEmpty(id))
                    {
                        throw new Exception(string.Format(Properties.Resources.RetrievingStorageAccountIdUnderSubscriptionFailed, storageAccountName, storageAccountSubscriptionId));
                    }
                }
                nextLink = (string)response["nextLink"];
            }

            if (string.IsNullOrEmpty(id))
            {
                throw new Exception(string.Format(Properties.Resources.StorageAccountNotFound, storageAccountName));
            }

            return id;
        }

        internal async Task<InformationProtectionPolicy> RetrieveInformationProtectionPolicyAsync(Guid tenantId)
        {
            string endpoint = Context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager).ToString();
            string uri = $"{endpoint}providers/Microsoft.Management/managementGroups/{tenantId}/providers/Microsoft.Security/informationprotectionpolicies/effective?api-version=2017-08-01-preview";
            Exception exception = new Exception(
                string.Format(Properties.Resources.DataClassificationFailedToRetrieveInformationProtectionPolicy,
                tenantId));
            JToken policyToken = await SendAsync(uri, HttpMethod.Get, exception);
            return InformationProtectionPolicy.ToInformationProtectionPolicy(policyToken);
        }

        internal void AssignRoleForServerIdentityOnStorageIfNotAssigned(string storageAccountResourceId, Guid principalId, Guid roleAssignmentId)
        {
            if (IsRoleAssignedForServerIdentitiyOnStorage(storageAccountResourceId, principalId))
            {
                return;
            }

            roleAssignmentId = roleAssignmentId == default(Guid) ? Guid.NewGuid() : roleAssignmentId;
            Uri endpoint = Context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager);
            string uri = $"{endpoint}/{storageAccountResourceId}/providers/Microsoft.Authorization/roleAssignments/{roleAssignmentId}?api-version=2018-01-01-preview";

            string roleDefinitionId = $"/subscriptions/{GetStorageAccountSubscription(storageAccountResourceId)}/providers/Microsoft.Authorization/roleDefinitions/{StorageBlobDataContributorId}";
            string content = $"{{\"properties\": {{ \"roleDefinitionId\": \"{roleDefinitionId}\", \"principalId\": \"{principalId}\", \"principalType\": \"ServicePrincipal\"}}}}";

            int numberOfTries = 20;
            const int SecondsToWaitBetweenTries = 20;
            var client = GetCurrentResourcesClient(Context);
            HttpResponseMessage response = null;
            bool isARetry = false;
            System.Net.HttpStatusCode responseStatusCode;
            string responseContent = null;
            do
            {
                if (isARetry)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(SecondsToWaitBetweenTries));
                }

                HttpRequestMessage httpRequest = new HttpRequestMessage
                {
                    Method = HttpMethod.Put,
                    RequestUri = new Uri(uri),
                    Content = new StringContent(content, Encoding.UTF8, "application/json")
                };
                client.Credentials.ProcessHttpRequestAsync(httpRequest, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
                response = client.HttpClient.SendAsync(httpRequest, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    return;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    throw new Exception(string.Format(Properties.Resources.AddingStorageBlobDataContributorRoleForStorageAccountIsForbidden, storageAccountResourceId));
                }

                responseStatusCode = response.StatusCode;
                responseContent = response.Content.ReadAsStringAsync().Result;
                numberOfTries--;
                isARetry = true;
            } while (numberOfTries > 0);

            throw new Exception(string.Format(Properties.Resources.FailedToAddRoleAssignmentForStorageAccount, storageAccountResourceId, responseStatusCode.ToString(), responseContent));
        }

        private bool IsRoleAssignedForServerIdentitiyOnStorage(string storageAccountResourceId, Guid principalId)
        {
            Uri endpoint = Context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager);
            string uri = $"{endpoint}/{storageAccountResourceId}/providers/Microsoft.Authorization/roleAssignments/?api-version=2018-01-01-preview&$filter=assignedTo('{principalId}')";
            JToken roleDefinitionsToken = SendAsync(uri, HttpMethod.Get,
                new Exception(string.Format(Properties.Resources.FailedToGetRoleAssignmentsForStorageAccount, storageAccountResourceId))).Result;
            try
            {
                JArray roleDefinitionsArray = (JArray)roleDefinitionsToken["value"];
                return roleDefinitionsArray.Any((token =>
                {
                    JToken roleDefinitionId = token["properties"]["roleDefinitionId"];
                    return roleDefinitionId != null && roleDefinitionId.ToString().Contains(StorageBlobDataContributorId);
                }));
            }
            catch (Exception) { }

            return false;
        }

        internal bool IsStorageAccountInVNet(string storageAccountResourceId)
        {
            if (IsClassicStorage(storageAccountResourceId))
            {
                return false;
            }

            string uri = $"{Context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager).ToString()}{storageAccountResourceId}?api-version=2019-06-01";
            Exception exception = new Exception(
                string.Format(Properties.Resources.RetrievingStorageAccountPropertiesFailed,
                storageAccountResourceId));
            JToken storageAccountPropertiesToken = SendAsync(uri, HttpMethod.Get, exception).Result;
            return GetNetworkAclsDefaultAction(storageAccountPropertiesToken, exception).Equals("Deny");
        }

        /// <summary>
        /// Deploys an ARM template at resource group level
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="deploymentName">The deployment name</param>
        /// <param name="deployment">The deployment</param>
        public void DeployArmTemplate(string resourceGroupName, string deploymentName, Deployment deployment)
        {
            GetCurrentResourcesClient(Context).Deployments.BeginCreateOrUpdate(resourceGroupName, deploymentName, deployment);

            WaitForDeployment(resourceGroupName, deploymentName);
        }

        /// <summary>
        /// Waits for ARM template deployment to finish
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="deploymentName">The deployment name</param>
        private void WaitForDeployment(string resourceGroupName, string deploymentName)
        {
            DeploymentExtended deployment;
            string[] status = { "Canceled", "Succeeded", "Failed" };

            // Poll deployment state and deployment operations after RetryAfter.
            // If no RetryAfter provided: In phase one, poll every 5 seconds. Phase one
            // takes 400 seconds. In phase two, poll every 60 seconds.
            const int counterUnit = 1000;
            int step = 5;
            int phaseOne = 400;

            do
            {
                TestMockSupport.Delay(step * counterUnit);

                if (phaseOne > 0)
                {
                    phaseOne -= step;
                }

                var getDeploymentTask = GetCurrentResourcesClient(Context).Deployments.GetWithHttpMessagesAsync(resourceGroupName, deploymentName);

                using (var getResult = getDeploymentTask.ConfigureAwait(false).GetAwaiter().GetResult())
                {
                    deployment = getResult.Body;
                    var response = getResult.Response;
                    if (response != null && response.Headers.RetryAfter != null && response.Headers.RetryAfter.Delta.HasValue)
                    {
                        step = response.Headers.RetryAfter.Delta.Value.Seconds;
                    }
                    else
                    {
                        step = phaseOne > 0 ? 5 : 60;
                    }
                }
            } while (!status.Any(s => s.Equals(deployment.Properties.ProvisioningState, StringComparison.OrdinalIgnoreCase)));
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
            var client = GetCurrentResourcesClient(Context);
            var httpRequest = new HttpRequestMessage { Method = method, RequestUri = new Uri(url) };
            await client.Credentials.ProcessHttpRequestAsync(httpRequest, CancellationToken.None).ConfigureAwait(false);
            var httpResponse = await client.HttpClient.SendAsync(httpRequest, CancellationToken.None).ConfigureAwait(false);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw exceptionToThrowOnFailure;
            }

            return JToken.Parse(await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        private string GetNetworkAclsDefaultAction(JToken storageAccountPropertiesToken, Exception exceptionToThrowOnFailure)
        {
            JToken value;
            try
            {
                value = storageAccountPropertiesToken["properties"]["networkAcls"]["defaultAction"];
            }
            catch (Exception)
            {
                throw exceptionToThrowOnFailure;
            }

            return value?.ToString();
        }

        private static bool IsClassicStorage(string storageAccountResourceId)
        {
            return storageAccountResourceId.Contains("Microsoft.ClassicStorage/storageAccounts");
        }

        private static string GetStorageAccountSubscription(string storageAccountResourceId)
        {
            const string separator = "subscriptions/";
            int subscriptionStartIndex = storageAccountResourceId.IndexOf(separator) + separator.Length;
            return storageAccountResourceId.Substring(subscriptionStartIndex, Guid.Empty.ToString().Length);
        }

        /// <summary>
        /// Version of classic storage listKeys REST-API.
        /// </summary>
        private const string ClassicStorageListKeysApiVersion = "2016-11-01";

        /// <summary>
        /// Version of non classic storage listKeys REST-API.
        /// </summary>
        private const string NonClassicStorageListKeysApiVersion = "2017-06-01";

        private const string PrimaryKey = "primaryKey";

        private const string SecondaryKey = "secondaryKey";

        private const string StorageBlobDataContributorId = "ba92f5b4-2d11-453d-a403-e96b0029c9fe";
    }
}
