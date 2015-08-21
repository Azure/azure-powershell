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
    [Cmdlet(VerbsCommon.Set, "AzureAppServicePlan"), OutputType(typeof(ServerFarmWithRichSku))]
    public class SetAzureAppServicePlanCmdlet : AppServicePlanBaseCmdlet
    {

        [Parameter(Position = 2, Mandatory = true, HelpMessage = "The location of the app service plan.")]
        [ValidateNotNullOrEmptyAttribute]
        public string Location { get; set; }
        
        [Parameter(Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The Sku of the app service plan")]
        [ValidateNotNullOrEmptyAttribute]
        public SkuDescription Sku { get; set; }

        [Parameter(Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the admin web app")]
        [ValidateNotNullOrEmptyAttribute]
        public string AdminSiteName { get; set; }

        public override void ExecuteCmdlet()
        {
            WriteObject(WebsitesClient.CreateAppServicePlan(ResourceGroupName, Name, Location, AdminSiteName, Sku.Name, Sku.Tier, Sku.Capacity));

        }

    }
}