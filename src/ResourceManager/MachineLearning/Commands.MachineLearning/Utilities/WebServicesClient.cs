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
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Management.MachineLearning.WebServices;
using Microsoft.Azure.Management.MachineLearning.WebServices.Models;
using APIClient = Microsoft.Azure.Management.MachineLearning.
                    WebServices.AzureMLWebServicesManagementClient;

namespace Microsoft.Azure.Commands.MachineLearning.Utilities
{
    public class WebServicesClient
    {
        private const int AsyncOperationPollingIntervalSeconds = 5;

        private readonly APIClient apiClient;

        public WebServicesClient(AzureContext context)
        {
            this.apiClient = AzureSession.ClientFactory.
                                            CreateArmClient<APIClient>(
                                                context, 
                                                AzureEnvironment.Endpoint.ResourceManager);
            this.apiClient.LongRunningOperationRetryTimeout = 
                    WebServicesClient.AsyncOperationPollingIntervalSeconds;
        }

        public Action<string> VerboseLogger { get; set; }

        public Action<string> ErrorLogger { get; set; }

        public Action<string> WarningLogger { get; set; }

        public WebService CreateAzureMlWebService(
                            string resourceGroupName, 
                            string location, 
                            string webServiceName, 
                            WebService serviceDefinition)
        {
            serviceDefinition.Name = webServiceName;
            serviceDefinition.Location = location;

            return this.apiClient.WebServices.CreateOrUpdateWithRequestId(
                                                serviceDefinition, 
                                                resourceGroupName, 
                                                webServiceName);
        }

        public WebService UpdateAzureMlWebService(
                            string resourceGroupName, 
                            string webServiceName, 
                            WebService serviceDefinition)
        {
            return this.apiClient.WebServices.PatchWithRequestId(
                                                serviceDefinition, 
                                                resourceGroupName, 
                                                webServiceName);
        }

        public void DeleteAzureMlWebService(
                        string resourceGroupName, 
                        string webServiceName)
        {
            this.apiClient.WebServices.RemoveWithRequestId(resourceGroupName, webServiceName);
        }

        public WebService GetAzureMlWebService(
                            string resourceGroupName, 
                            string webServiceName)
        {
            return this.apiClient.WebServices.Get(resourceGroupName, webServiceName);
        }

        public WebServiceKeys GetAzureMlWebServiceKeys(
                                string resourceGroupName, string webServiceName)
        {
            return this.apiClient.WebServices.ListKeys(resourceGroupName, webServiceName);
        }

        public async Task<IList<WebService>> 
                        GetAzureMlWebServicesBySubscriptionAndGroupAsync(
                                                    string resourceGroupName, 
                                                    string nextLink, 
                                                    CancellationToken? cancellationToken)
        {
            string skipToken = WebServicesClient.GetSkipTokenFromLink(nextLink);
            var cancellationTokenParam = cancellationToken ?? CancellationToken.None;
            var paginatedResponse = await this.apiClient.WebServices.ListInResourceGroupAsync(
                                                                        resourceGroupName, 
                                                                        skipToken, 
                                                                        cancellationTokenParam).ConfigureAwait(false);

            return paginatedResponse.Value;
        }

        public async Task<IList<WebService>> 
                        GetAzureMlWebServicesBySubscriptionAsync(
                                                    string nextLink, 
                                                    CancellationToken? cancellationToken)
        {
            string skipToken = WebServicesClient.GetSkipTokenFromLink(nextLink);
            var cancellationTokenParam = cancellationToken ?? CancellationToken.None;

            var paginatedResponse = 
                    await this.apiClient.WebServices.ListAsync(
                                                        skipToken, 
                                                        cancellationTokenParam).ConfigureAwait(false);

            return paginatedResponse.Value;
        }
        
        private static string GetSkipTokenFromLink(string nextLink)
        {
            string skipToken = null;
            if (!string.IsNullOrWhiteSpace(nextLink))
            {
                var linkAsUri = new Uri(nextLink, UriKind.Absolute);
                var queryParameters = HttpUtility.ParseQueryString(linkAsUri.Query);
                skipToken = (queryParameters.GetValues("$skiptoken") ?? 
                                                Enumerable.Empty<string>()).FirstOrDefault();
            }

            return skipToken;
        }
    }
}