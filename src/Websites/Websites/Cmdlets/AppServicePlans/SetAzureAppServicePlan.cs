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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.WebSites.Models;
using System.Management.Automation;
using System.Text.RegularExpressions;
using Microsoft.Azure.Commands.WebApps.Models.WebApp;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.AppServicePlans
{
    /// <summary>
    /// this commandlet will let you set Azure App Service Plan using ARM APIs
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AppServicePlan"), OutputType(typeof(PSAppServicePlan))]
    public class SetAzureAppServicePlanCmdlet : AppServicePlanBaseCmdlet
    {
        [Parameter(ParameterSetName = ParameterSet1Name, Position = 2, Mandatory = false, HelpMessage = "The name of the admin web app")]
        [ValidateNotNullOrEmpty]
        public string AdminSiteName { get; set; }

        [Parameter(ParameterSetName = ParameterSet1Name, Position = 3, Mandatory = false, HelpMessage = "The App Service plan tier. Allowed values are [Free|Shared|Basic|Standard|Premium|PremiumV2|PremiumV3]")]
        [PSArgumentCompleter("Free", "Shared", "Basic", "Standard", "Premium", "PremiumV2", "PremiumV3", "Isolated")]
        public string Tier { get; set; }

        [Parameter(ParameterSetName = ParameterSet1Name, Position = 4, Mandatory = false, HelpMessage = "Number of Workers to be allocated.")]
        public int NumberofWorkers { get; set; }

        [Parameter(ParameterSetName = ParameterSet1Name, Position = 5, Mandatory = false, HelpMessage = "Size of workers to be allocated. Allowed values are [Small|Medium|Large|ExtraLarge]")]
        [PSArgumentCompleter("Small", "Medium", "Large", "ExtraLarge")]
        public string WorkerSize { get; set; }

        [Parameter(ParameterSetName = ParameterSet1Name, Mandatory = false, HelpMessage = "Whether or not to enable Per Site Scaling")]
        [ValidateNotNullOrEmpty]
        public bool PerSiteScaling { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }
        [Parameter(ParameterSetName = ParameterSet1Name, Mandatory = false, HelpMessage = "Tags are name/value pairs that enable you to categorize resources")]
        public Hashtable Tag { get; set; }
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            switch (ParameterSetName)
            {
                case ParameterSet1Name:
                    AppServicePlan = new PSAppServicePlan(WebsitesClient.GetAppServicePlan(ResourceGroupName, Name));
                    AppServicePlan.Sku.Tier = string.IsNullOrWhiteSpace(Tier) ? AppServicePlan.Sku.Tier : Tier;
                    AppServicePlan.Sku.Capacity = NumberofWorkers > 0 ? NumberofWorkers : AppServicePlan.Sku.Capacity;
                    int workerSizeAsNumber = 0;
                    int.TryParse(Regex.Match(AppServicePlan.Sku.Name, @"\d+").Value, out workerSizeAsNumber);
                    AppServicePlan.Sku.Name = string.IsNullOrWhiteSpace(WorkerSize) ? CmdletHelpers.GetSkuName(AppServicePlan.Sku.Tier, workerSizeAsNumber) : CmdletHelpers.GetSkuName(AppServicePlan.Sku.Tier, WorkerSize);
                    AppServicePlan.PerSiteScaling = PerSiteScaling;
                    AppServicePlan.Tags = (IDictionary<string, string>)CmdletHelpers.ConvertToStringDictionary(Tag);
                    break;
            }

            // Fix Server Farm SKU description
            AppServicePlan.Sku.Size = AppServicePlan.Sku.Name;
            AppServicePlan.Sku.Family = AppServicePlan.Sku.Name.Substring(0, 1);

            WriteObject(new PSAppServicePlan(WebsitesClient.CreateOrUpdateAppServicePlan(ResourceGroupName, Name, AppServicePlan)), true);
        }
    }
}
