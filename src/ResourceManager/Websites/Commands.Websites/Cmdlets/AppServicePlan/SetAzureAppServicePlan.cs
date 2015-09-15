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

using System.Management.Automation;
using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.Azure.Commands.WebApp.Utilities;

namespace Microsoft.Azure.Commands.WebApp.Cmdlets.AppServicePlan
{
    /// <summary>
    /// this commandlet will let you set Azure App Service Plan using ARM APIs
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureAppServicePlan"), OutputType(typeof(WebHostingPlanCreateOrUpdateResponse))]
    public class SetAzureAppServicePlanCmdlet : AppServicePlanBaseCmdlet
    {

        [Parameter(Position = 2, Mandatory = true, HelpMessage = "The location of the app service plan.")]
        [ValidateNotNullOrEmptyAttribute]
        public string Location { get; set; }
        
        [Parameter(Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The Sku of the app service plan eg: free, shared, basic, standard.")]
        [ValidateSet("Free", "Shared", "Basic", "Standard", "Premium", IgnoreCase = true)]
        [ValidateNotNullOrEmptyAttribute]
        public string Sku { get; set; }

        [Parameter(Position = 4, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Number of Workers to be allocated.")]
        [ValidateNotNullOrEmptyAttribute]
        public int NumberofWorkers { get; set; }

        [Parameter(Position = 5, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The size of he workers: eg Small, Medium, Large")]
        [ValidateNotNullOrEmptyAttribute]
        [ValidateSet("Small", "Medium", "Large", IgnoreCase = true)]
        public string WorkerSize { get; set; }

        public override void ExecuteCmdlet()
        {
            //for now not asking admin site name need to implement in future
            string adminSiteName = null;

            //if Sku is not specified assume default to be Standard
            SkuOptions skuInput = SkuOptions.Standard;

            //if workerSize is not specified assume default to be small
            WorkerSizeOptions workerSizeInput = WorkerSizeOptions.Small;

            //if NumberofWorkers is not specified assume default to be 1
            if (NumberofWorkers == 0)
                NumberofWorkers = 1;


            if (WorkerSize != null)
            {
                switch (WorkerSize.ToUpper())
                {
                    case "SMALL":
                        workerSizeInput = WorkerSizeOptions.Small;
                        break;
                    case "MEDIUM":
                        workerSizeInput = WorkerSizeOptions.Medium;
                        break;
                    case "LARGE":
                        workerSizeInput = WorkerSizeOptions.Large;
                        break;
                    default:
                        workerSizeInput = WorkerSizeOptions.Large;
                        break;
                }
            }

            if (Sku != null)
            {
                switch (Sku.ToUpper())
                {
                    case "FREE":
                        skuInput = SkuOptions.Free;
                        break;
                    case "SHARED":
                        skuInput = SkuOptions.Shared;
                        break;
                    case "BASIC":
                        skuInput = SkuOptions.Basic;
                        break;
                    case "PREMIUM":
                        skuInput = SkuOptions.Premium;
                        break;
                    default:
                        skuInput = SkuOptions.Standard;
                        break;
                }
            }

            WriteObject(WebsitesClient.CreateAppServicePlan(ResourceGroupName, Name, Location, adminSiteName, NumberofWorkers, skuInput, workerSizeInput));

        }

    }
}