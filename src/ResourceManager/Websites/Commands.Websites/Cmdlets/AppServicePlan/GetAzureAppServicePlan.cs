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
    /// this commandlet will let you Get an Azure App Service Plan using ARM APIs
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureAppServicePlan"), OutputType(typeof(WebHostingPlanGetResponse), typeof(WebHostingPlanListResponse))]
    public class GetAppServicePlanCmdlet : WebHostingPlanBaseNotMandatoryCmdlet
    {
        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(ResourceGroupName) && !string.IsNullOrEmpty(Name))
            {
                GetByWebHostingPlan();
            }
            else if (!string.IsNullOrEmpty(ResourceGroupName))
            {
                GetByResourceGroup();
            }

        }

        private void GetByWebHostingPlan()
        {
            WriteObject(WebsitesClient.GetAppServicePlan(ResourceGroupName, Name));
        }

        private void GetByResourceGroup()
        {
            WriteObject(WebsitesClient.ListAppServicePlan(ResourceGroupName));
        }
    }
}

