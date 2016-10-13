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
    /// this commandlet will let you create a new Azure App service Plan using ARM APIs
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmAppServicePlan"), OutputType(typeof(ServerFarmWithRichSku))]
    public class NewAzureAppServicePlanCmdlet : AppServicePlanBaseCmdlet
    {
        [Parameter(Position = 2, Mandatory = true, HelpMessage = "The location of the app service plan.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Position = 3, Mandatory = false, HelpMessage = "The App Service plan tier. Allowed values are [Free|Shared|Basic|Standard|Premium]")]
        [ValidateSet("Free", "Shared", "Basic", "Standard", "Premium", IgnoreCase = true)]
        public string Tier { get; set; }

        [Parameter(Position = 4, Mandatory = false, HelpMessage = "Number of Workers to be allocated.")]
        [ValidateNotNullOrEmpty]
        public int NumberofWorkers { get; set; }

        [Parameter(Position = 5, Mandatory = false, HelpMessage = "Size of workers to be allocated. Allowed values are [Small|Medium|Large|ExtraLarge]")]
        [ValidateSet("Small", "Medium", "Large", "ExtraLarge", IgnoreCase = true)]
        public string WorkerSize { get; set; }

        [Parameter(Position = 6, Mandatory = false, HelpMessage = "Name of application service environment")]
        [ValidateNotNullOrEmpty]
        public string AseName { get; set; }

        [Parameter(Position = 7, Mandatory = false, HelpMessage = "Name of the application service environment resource group")]
        [ValidateNotNullOrEmpty]
        public string AseResourceGroupName { get; set; }

        public override void ExecuteCmdlet()
        {
            if (string.IsNullOrWhiteSpace(Tier))
            {
                Tier = "Free";
            }

            if (string.IsNullOrWhiteSpace(WorkerSize))
            {
                WorkerSize = "Small";
            }

            var aseResourceGroupName = AseResourceGroupName;

            if (!string.IsNullOrEmpty(AseName)
                && string.IsNullOrEmpty(aseResourceGroupName))
            {
                aseResourceGroupName = ResourceGroupName;
            }

            var capacity = NumberofWorkers < 1 ? 1 : NumberofWorkers;
            var skuName = CmdletHelpers.GetSkuName(Tier, WorkerSize);

            var sku = new SkuDescription
            {
                Tier = Tier,
                Name = skuName,
                Capacity = capacity
            };

            WriteObject(WebsitesClient.CreateAppServicePlan(ResourceGroupName, Name, Location, null, sku, AseName, aseResourceGroupName), true);
        }
    }
}
