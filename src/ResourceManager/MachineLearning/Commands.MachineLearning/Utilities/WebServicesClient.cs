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
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using Microsoft.Azure.Management.MachineLearning.WebServices;
using Microsoft.Azure.Management.MachineLearning.WebServices.Models;
using APIClient = Microsoft.Azure.Management.MachineLearning.WebServices.AzureMLWebServicesManagementClient;

namespace Microsoft.Azure.Commands.MachineLearning.Utilities
{
    public class WebServicesClient
    {
        private const int AsyncOperationPollingIntervalSeconds = 5;

        private readonly APIClient apiClient;

        public WebServicesClient(AzureContext context)
        {
            this.apiClient = AzureSession.ClientFactory.CreateArmClient<APIClient>(context, AzureEnvironment.Endpoint.ResourceManager);
            this.apiClient.LongRunningOperationRetryTimeout = WebServicesClient.AsyncOperationPollingIntervalSeconds;
        }

        public Action<string> VerboseLogger { get; set; }

        public Action<string> ErrorLogger { get; set; }

        public Action<string> WarningLogger { get; set; }

        public string GetAvailableOperations()
        {
            var result = apiClient.GetOperationsAsync().Result;
            return result.ToString();
        }

        public WebService CreateAzureMlWebService(string subscriptionId, string resourceGroupName, string location, string webServiceName, WebService serviceDefinition)
        {
            this.apiClient.SubscriptionId = subscriptionId;
            serviceDefinition.Name = webServiceName;
            serviceDefinition.Location = location;

            return this.apiClient.WebServices.CreateOrUpdateWebService(serviceDefinition, resourceGroupName, webServiceName);
        }

        public WebService UpdateAzureMlWebService(string subscriptionId, string resourceGroupName, string webServiceName, WebService serviceDefinition)
        {
            this.apiClient.SubscriptionId = subscriptionId;
            return this.apiClient.WebServices.PatchWebService(serviceDefinition, resourceGroupName, webServiceName);
        }

        public void DeleteAzureMlWebService(string subscriptionId, string resourceGroupName, string webServiceName)
        {
            this.apiClient.SubscriptionId = subscriptionId;
            this.apiClient.WebServices.RemoveWebService(resourceGroupName, webServiceName);
        }

        public WebService GetAzureMlWebService(string subscriptionId, string resourceGroupName, string webServiceName)
        {
            this.apiClient.SubscriptionId = subscriptionId;
            return this.apiClient.WebServices.GetWebService(resourceGroupName, webServiceName);
        }

        public WebServiceKeys GetAzureMlWebServiceKeys(string subscriptionId, string resourceGroupName, string webServiceName)
        {
            this.apiClient.SubscriptionId = subscriptionId;
            return this.apiClient.WebServices.GetWebServiceKeys(resourceGroupName, webServiceName);
        }

        public async Task<ResponseWithContinuation<WebService[]>> GetAzureMlWebServicesBySubscriptionAndGroupAsync(string subscriptionId, string resourceGroupName, string nextLink, CancellationToken? cancellationToken)
        {
            this.apiClient.SubscriptionId = subscriptionId;
            string skipToken = WebServicesClient.GetSkipTokenFromLink(nextLink);
            var cancellationTokenParam = cancellationToken ?? CancellationToken.None;
            var paginatedResponse = await this.apiClient.WebServices.GetWebServicesInResourceGroupAsync(resourceGroupName, skipToken, cancellationTokenParam).ConfigureAwait(false);
            return new ResponseWithContinuation<WebService[]>
            {
                Value = paginatedResponse.Value.ToArray(),
                NextLink = paginatedResponse.NextLink
            };
        }

        public async Task<ResponseWithContinuation<WebService[]>> GetAzureMlWebServicesBySubscriptionAsync(string subscriptionId, string nextLink, CancellationToken? cancellationToken)
        {
            this.apiClient.SubscriptionId = subscriptionId;
            string skipToken = WebServicesClient.GetSkipTokenFromLink(nextLink);
            var cancellationTokenParam = cancellationToken ?? CancellationToken.None;

            var paginatedResponse = await this.apiClient.WebServices.GetWebServicesInSubscriptionAsync(skipToken, cancellationTokenParam).ConfigureAwait(false);

            return new ResponseWithContinuation<WebService[]>
            {
                Value = paginatedResponse.Value.ToArray(),
                NextLink = paginatedResponse.NextLink
            };
        }
        
        private static string GetSkipTokenFromLink(string nextLink)
        {
            string skipToken = null;
            if (!string.IsNullOrWhiteSpace(nextLink))
            {
                var linkAsUri = new Uri(nextLink, UriKind.Absolute);
                var queryParameters = HttpUtility.ParseQueryString(linkAsUri.Query);
                skipToken = (queryParameters.GetValues("$skiptoken") ?? Enumerable.Empty<string>()).FirstOrDefault();
            }

            return skipToken;
        }
    }
}
