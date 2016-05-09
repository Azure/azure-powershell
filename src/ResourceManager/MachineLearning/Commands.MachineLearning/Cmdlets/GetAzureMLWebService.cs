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
using System.Management.Automation;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using Microsoft.Azure.Management.MachineLearning.WebServices.Models;

namespace Microsoft.Azure.Commands.MachineLearning
{
    [Cmdlet(VerbsCommon.Get, WebServicesCmdletBase.CommandletSuffix)]
    public class GetAzureMLWebService : WebServicesCmdletBase
    {
        private const string GetMlWebServiceByNameGroupParameterSet = "Get an Azure ML web service resource details by name and group.";
        private const string GetMlWebServicesByGroupParameterSet = "Get the paginated list of Azure ML web service resources within a resource group.";
        private const string GetMlWebServicesInSubscriptionParameterSet = "Get the paginated list of Azure ML web service resources within the current subscription.";

        [Parameter(ParameterSetName = GetAzureMLWebService.GetMlWebServiceByNameGroupParameterSet, Mandatory = true, HelpMessage = "The name of the resource group for the Azure ML web service.")]
        [Parameter(ParameterSetName = GetAzureMLWebService.GetMlWebServicesByGroupParameterSet, Mandatory = true, HelpMessage = "The name of the resource group for the Azure ML web services.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = GetAzureMLWebService.GetMlWebServiceByNameGroupParameterSet, Mandatory = true, HelpMessage = "The name of the web service.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = GetAzureMLWebService.GetMlWebServicesByGroupParameterSet, Mandatory = true, HelpMessage = "When specified, ensures that the query is run against a paginated list of services instead of a resource.")]
        [Parameter(ParameterSetName = GetAzureMLWebService.GetMlWebServicesInSubscriptionParameterSet, Mandatory = true, HelpMessage = "When specified, ensures that the query is run against a paginated list of services instead of a resource.")]
        public SwitchParameter IsCollection { get; set; }

        protected override void RunCmdlet()
        {
            // If this is a simple get web service by name operation, resolve it as such
            if (string.Equals(this.ParameterSetName, GetAzureMLWebService.GetMlWebServiceByNameGroupParameterSet, StringComparison.OrdinalIgnoreCase))
            {
                WebService service = this.WebServicesClient.GetAzureMlWebService(this.SubscriptionId, this.ResourceGroupName, this.Name);
                this.WriteObject(service);
            }
            else
            {
                // This is a collection of web services get call, so determine which flavor it is
                Func<Task<ResponseWithContinuation<WebService[]>>> getFirstServicesPageCall = () => this.WebServicesClient.GetAzureMlWebServicesBySubscriptionAsync(this.SubscriptionId, null, this.CancellationToken);
                Func<string, Task<ResponseWithContinuation<WebService[]>>> getNextPageCall = nextLink => this.WebServicesClient.GetAzureMlWebServicesBySubscriptionAsync(this.SubscriptionId, nextLink, this.CancellationToken);
                if (this.ResourceGroupName != null)
                {
                    // This is a call for resource retrieval within a resource group
                    getFirstServicesPageCall = () => this.WebServicesClient.GetAzureMlWebServicesBySubscriptionAndGroupAsync(this.SubscriptionId, this.ResourceGroupName, null, this.CancellationToken);
                    getNextPageCall = nextLink => this.WebServicesClient.GetAzureMlWebServicesBySubscriptionAndGroupAsync(this.SubscriptionId, this.ResourceGroupName, nextLink, this.CancellationToken);
                }

                PaginatedResponseHelper.ForEach<WebService>(
                    getFirstPage: getFirstServicesPageCall,
                    getNextPage: getNextPageCall,
                    cancellationToken: this.CancellationToken,
                    action: webServices =>
                    {
                        foreach (var service in webServices)
                        {
                            this.WriteObject(service, true);
                        }
                    });
            }
        }
    }
}
