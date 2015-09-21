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
using Microsoft.Azure.Commands.WebApp.Utilities;
using Microsoft.Azure.Commands.Websites.Validations;
using Microsoft.Azure.Management.WebSites.Models;

namespace Microsoft.Azure.Commands.WebApp.Cmdlets.AppServicePlan
{
    /// <summary>
    /// this commandlet will let you set Azure App Service Plan using ARM APIs
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRMAppServicePlan"), OutputType(typeof(ServerFarmWithRichSku))]
    public class SetAzureAppServicePlanCmdlet : AppServicePlanBaseCmdlet
    {
        private const string RolledOutServerFarmParameterSetName = "RolledOutServerFarm";
        private const string ServerFarmObjectParameterSetName = "ServerFarmObject";

        [Parameter(ParameterSetName = RolledOutServerFarmParameterSetName, Position = 2, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the admin web app")]
        [ValidateNotNullOrEmpty]
        public string AdminSiteName { get; set; }

        [Parameter(ParameterSetName = RolledOutServerFarmParameterSetName, Position = 3, Mandatory = false, HelpMessage = "The App Service plan tier. Allowed values are [Free|Shared|Basic|Standard|Premium]")]
        [ValidateSet("Free", "Shared", "Basic", "Standard", "Premium", IgnoreCase = true)]
        public string Tier { get; set; }

        [Parameter(ParameterSetName = RolledOutServerFarmParameterSetName, Position = 4, Mandatory = false, HelpMessage = "Number of Workers to be allocated.")]
        public int NumberofWorkers { get; set; }

        [Parameter(ParameterSetName = RolledOutServerFarmParameterSetName, Position = 5, Mandatory = false, HelpMessage = "Size of workers to be allocated. Allowed values are [Small|Medium|Large|ExtraLarge]")]
        [ValidateSet("Small", "Medium", "Large", "ExtraLarge", IgnoreCase = true)]
        public string WorkerSize { get; set; }

        [Parameter(ParameterSetName = ServerFarmObjectParameterSetName, Position = 2, Mandatory = false, ValueFromPipeline = true, HelpMessage = "The rich sku format of the app service plan. This sup")]
        [ValidateServerFarm]
        public ServerFarmWithRichSku ServerFarm { get; set; }

        protected override void ProcessRecord()
        {
            switch (ParameterSetName)
            {
                case RolledOutServerFarmParameterSetName:
                    ServerFarm = WebsitesClient.GetAppServicePlan(ResourceGroup, Name);
                    ServerFarm.Sku.Tier = string.IsNullOrWhiteSpace(Tier) ? ServerFarm.Sku.Tier : Tier;
                    ServerFarm.Sku.Capacity = NumberofWorkers > 0 ? NumberofWorkers : ServerFarm.Sku.Capacity;
                    var workerSizeAsNumber = int.Parse(ServerFarm.Sku.Name.Substring(1, ServerFarm.Sku.Name.Length - 1));
                    ServerFarm.Sku.Name = string.IsNullOrWhiteSpace(WorkerSize) ? WebsitesClient.GetSkuName(ServerFarm.Sku.Tier, workerSizeAsNumber) : WebsitesClient.GetSkuName(ServerFarm.Sku.Tier, WorkerSize);
                    break;
            }

            // Fix Server Farm SKU description
            ServerFarm.Sku.Size = ServerFarm.Sku.Name;
            ServerFarm.Sku.Family = ServerFarm.Sku.Name.Substring(0, 1);

            WriteObject(WebsitesClient.CreateAppServicePlan(ResourceGroup, Name, ServerFarm.Location, AdminSiteName, ServerFarm.Sku), true);
        }
    }
}