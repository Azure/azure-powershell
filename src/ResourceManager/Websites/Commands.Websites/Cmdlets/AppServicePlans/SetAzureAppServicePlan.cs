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

using Microsoft.Azure.Commands.WebApps.Utilities;
using Microsoft.Azure.Management.WebSites.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.AppServicePlans
{
    /// <summary>
    /// this commandlet will let you set Azure App Service Plan using ARM APIs
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmAppServicePlan"), OutputType(typeof(ServerFarmWithRichSku))]
    public class SetAzureAppServicePlanCmdlet : AppServicePlanBaseCmdlet
    {
        [Parameter(ParameterSetName = ParameterSet1Name, Position = 2, Mandatory = false, HelpMessage = "The name of the admin web app")]
        [ValidateNotNullOrEmpty]
        public string AdminSiteName { get; set; }

        [Parameter(ParameterSetName = ParameterSet1Name, Position = 3, Mandatory = false, HelpMessage = "The App Service plan tier. Allowed values are [Free|Shared|Basic|Standard|Premium]")]
        [ValidateSet("Free", "Shared", "Basic", "Standard", "Premium", IgnoreCase = true)]
        public string Tier { get; set; }

        [Parameter(ParameterSetName = ParameterSet1Name, Position = 4, Mandatory = false, HelpMessage = "Number of Workers to be allocated.")]
        public int NumberofWorkers { get; set; }

        [Parameter(ParameterSetName = ParameterSet1Name, Position = 5, Mandatory = false, HelpMessage = "Size of workers to be allocated. Allowed values are [Small|Medium|Large|ExtraLarge]")]
        [ValidateSet("Small", "Medium", "Large", "ExtraLarge", IgnoreCase = true)]
        public string WorkerSize { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            switch (ParameterSetName)
            {
                case ParameterSet1Name:
                    AppServicePlan = WebsitesClient.GetAppServicePlan(ResourceGroupName, Name);
                    AppServicePlan.Sku.Tier = string.IsNullOrWhiteSpace(Tier) ? AppServicePlan.Sku.Tier : Tier;
                    AppServicePlan.Sku.Capacity = NumberofWorkers > 0 ? NumberofWorkers : AppServicePlan.Sku.Capacity;
                    var workerSizeAsNumber = int.Parse(AppServicePlan.Sku.Name.Substring(1, AppServicePlan.Sku.Name.Length - 1));
                    AppServicePlan.Sku.Name = string.IsNullOrWhiteSpace(WorkerSize) ? CmdletHelpers.GetSkuName(AppServicePlan.Sku.Tier, workerSizeAsNumber) : CmdletHelpers.GetSkuName(AppServicePlan.Sku.Tier, WorkerSize);
                    break;
            }

            // Fix Server Farm SKU description
            AppServicePlan.Sku.Size = AppServicePlan.Sku.Name;
            AppServicePlan.Sku.Family = AppServicePlan.Sku.Name.Substring(0, 1);

            WriteObject(WebsitesClient.CreateAppServicePlan(ResourceGroupName, Name, AppServicePlan.Location, AdminSiteName, AppServicePlan.Sku), true);
        }
    }
}