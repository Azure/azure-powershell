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

using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.Rest;
using Microsoft.Rest.Azure.OData;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using RestAzureNS = Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS
{
    public partial class ServiceClientAdapter
    {
        /// <summary>
        /// Get azure resource
        /// </summary>
        /// <param name="resourceId">Resource id of the Azure resource to get</param>
        /// <returns>Generic resource returned from the service</returns>
        public GenericResource GetAzureResource(string resourceId)
        {
            GenericResource resource = RMAdapter.Client.Resources.GetByIdWithHttpMessagesAsync(
                resourceId,
                "2015-06-15", 
                null,
                cancellationToken: RMAdapter.CmdletCancellationToken).Result.Body;
            return resource;
        }

        /// <summary>
        /// Get storage accounts according to the query params
        /// </summary>
        /// <param name="storageAccountName">Name of the container to unregister</param>
        /// <param name="subscriptionId"></param>
        /// <returns>Generic resource returned from the service</returns>
        public GenericResource GetStorageAccountResource(string storageAccountName, string subscriptionId = null)
        {
            List<GenericResource> storageAccounts = null;
            GenericResource storageAccount = null;
            storageAccountName = storageAccountName.ToLower();
            ODataQuery<GenericResourceFilter> getItemQueryParams =
                new ODataQuery<GenericResourceFilter>(q =>
                q.ResourceType == "Microsoft.ClassicStorage/storageAccounts");

            // switch subscription context 
            string subscriptionContext = RMAdapter.Client.SubscriptionId;
            RMAdapter.Client.SubscriptionId = (subscriptionId != null)? subscriptionId: RMAdapter.Client.SubscriptionId;

            Func<RestAzureNS.IPage<GenericResource>> listAsync =
            () => RMAdapter.Client.Resources.ListWithHttpMessagesAsync(
                getItemQueryParams,
                cancellationToken: RMAdapter.CmdletCancellationToken).Result.Body;

            Func<string, RestAzureNS.IPage<GenericResource>> listNextAsync =
                nextLink => RMAdapter.Client.Resources.ListNextWithHttpMessagesAsync(
                    nextLink,
                    cancellationToken: RMAdapter.CmdletCancellationToken).Result.Body;

            storageAccounts = HelperUtils.GetPagedRMList(listAsync, listNextAsync);
            storageAccount = storageAccounts.Find(account =>
                string.Compare(account.Name, storageAccountName) == 0);

            if (storageAccount == null)
            {
                getItemQueryParams = new ODataQuery<GenericResourceFilter>(q =>
                q.ResourceType == "Microsoft.Storage/storageAccounts");
                listAsync = () => RMAdapter.Client.Resources.ListWithHttpMessagesAsync(
                    getItemQueryParams,
                    cancellationToken: RMAdapter.CmdletCancellationToken).Result.Body;

                listNextAsync = nextLink => RMAdapter.Client.Resources.ListNextWithHttpMessagesAsync(
                    nextLink,
                    cancellationToken: RMAdapter.CmdletCancellationToken).Result.Body;

                storageAccounts = HelperUtils.GetPagedRMList(listAsync, listNextAsync);
                storageAccount = storageAccounts.Find(account =>
                    string.Compare(account.Name, storageAccountName) == 0);
            }

            RMAdapter.Client.SubscriptionId = subscriptionContext;

            return storageAccount;
        }

        /// <summary>
        /// Gets the VM as a generic resource in the given subscription. Used to validate a
        /// cross-subscription (CSB) VM's existence and region before enabling backup, since discovery
        /// does not run cross-subscription.
        /// </summary>
        /// <param name="vmName">Name of the virtual machine</param>
        /// <param name="vmResourceGroupName">Resource group of the virtual machine</param>
        /// <param name="subscriptionId">Subscription the virtual machine resides in</param>
        /// <returns>Generic resource returned from the service</returns>
        public GenericResource GetVmResource(string vmName, string vmResourceGroupName, string subscriptionId)
        {
            string vmResourceId = string.Format(
                "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Compute/virtualMachines/{2}",
                subscriptionId, vmResourceGroupName, vmName);

            string requestUri = string.Format(
                "{0}{1}?api-version=2023-03-01",
                RMAdapter.Client.BaseUri.AbsoluteUri.TrimEnd('/'),
                vmResourceId);

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri))
            {
                if (RMAdapter.Client.GenerateClientRequestId.HasValue &&
                    RMAdapter.Client.GenerateClientRequestId.Value)
                {
                    request.Headers.TryAddWithoutValidation(
                        "x-ms-client-request-id", Guid.NewGuid().ToString());
                }

                if (!string.IsNullOrEmpty(RMAdapter.Client.AcceptLanguage))
                {
                    request.Headers.TryAddWithoutValidation(
                        "accept-language", RMAdapter.Client.AcceptLanguage);
                }

                if (RMAdapter.Client.Credentials != null)
                {
                    RMAdapter.Client.Credentials.ProcessHttpRequestAsync(
                        request,
                        RMAdapter.CmdletCancellationToken).GetAwaiter().GetResult();
                }

                using (HttpResponseMessage response = RMAdapter.Client.HttpClient.SendAsync(
                    request,
                    RMAdapter.CmdletCancellationToken).GetAwaiter().GetResult())
                {
                    string responseContent = response.Content.ReadAsStringAsync()
                        .GetAwaiter().GetResult();

                    if (!response.IsSuccessStatusCode)
                    {
                        RestAzureNS.CloudError errorBody = null;
                        try
                        {
                            errorBody = SafeJsonConvert.DeserializeObject<RestAzureNS.CloudError>(
                                responseContent,
                                RMAdapter.Client.DeserializationSettings);
                        }
                        catch (Newtonsoft.Json.JsonException)
                        {
                        }

                        string errorMessage = errorBody != null &&
                            !string.IsNullOrEmpty(errorBody.Message)
                                ? errorBody.Message
                                : string.Format(
                                    "Operation returned an invalid status code '{0}'",
                                    response.StatusCode);

                        RestAzureNS.CloudException exception =
                            new RestAzureNS.CloudException(errorMessage)
                            {
                                Body = errorBody,
                                Request = new HttpRequestMessageWrapper(request, null),
                                Response = new HttpResponseMessageWrapper(response, responseContent)
                            };

                        throw exception;
                    }

                    return DeserializeVmResource(responseContent);
                }
            }
        }

        internal static GenericResource DeserializeVmResource(string responseContent)
        {
            JObject resource = JObject.Parse(responseContent);

            return new GenericResource(
                resource.Value<string>("id"),
                resource.Value<string>("name"),
                resource.Value<string>("type"),
                resource.Value<string>("location"));
        }
    }
}