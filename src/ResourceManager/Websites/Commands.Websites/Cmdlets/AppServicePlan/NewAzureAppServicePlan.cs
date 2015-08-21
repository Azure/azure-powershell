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
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.Azure.Commands.WebApp;
using Microsoft.Azure.Management.WebSites;
using System.Net.Http;
using System.Threading;
using System.Net;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.WebApp.Utilities;

namespace Microsoft.Azure.Commands.WebApp.Cmdlets.AppServicePlan
{
    /// <summary>
    /// this commandlet will let you create a new Azure App service Plan using ARM APIs
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureAppServicePlan"), OutputType(typeof(ServerFarmWithRichSku))]
    public class NewAzureAppServicePlanCmdlet : AppServicePlanBaseCmdlet
    {

        [Parameter(Position = 2, Mandatory = true, HelpMessage = "The location of the app service plan.")]
        [ValidateNotNullOrEmptyAttribute]
        public string Location { get; set; }
        
        [Parameter(Position = 3, Mandatory = false, HelpMessage = "The Sku of the Webhosting plan.")]
        [ValidateNotNullOrEmptyAttribute]
        public SkuDescription Sku { get; set; }

        [Parameter(Position = 4, Mandatory = false, HelpMessage = "Number of Workers to be allocated.")]
        [ValidateNotNullOrEmptyAttribute]
        public int NumberofWorkers { get; set; }

        public override void ExecuteCmdlet()
        {
            WriteObject(WebsitesClient.CreateAppServicePlan(ResourceGroupName, Name, Location, null, Sku.Name, Sku.Tier, Sku.Capacity));
        }

    }
}
