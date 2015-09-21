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


using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.WebApp.Utilities;
using Microsoft.Azure.Management.WebSites.Models;
using PSResourceManagerModels = Microsoft.Azure.Commands.Resources.Models;

namespace Microsoft.Azure.Commands.WebApp.Cmdlets.AppServicePlan
{
    /// <summary>
    /// this commandlet will let you Get an Azure App Service Plan using ARM APIs
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRMAppServicePlan"), OutputType(typeof(ServerFarmWithRichSku), typeof(ServerFarmCollection))]
    public class GetAppServicePlanCmdlet : WebHostingPlanBaseNotMandatoryCmdlet
    {
        protected override void ProcessRecord()
        {
            if (!string.IsNullOrEmpty(ResourceGroup) && !string.IsNullOrEmpty(Name))
            {
                GetByWebHostingPlan();
            }
            else if (!string.IsNullOrEmpty(ResourceGroup))
            {
                GetByResourceGroup();
            }
            else
            {
                GetBySubscription();
            }
        }

        private void GetByWebHostingPlan()
        {
            WriteObject(WebsitesClient.GetAppServicePlan(ResourceGroup, Name));
        }

        private void GetByResourceGroup()
        {
            WriteObject(WebsitesClient.ListAppServicePlan(ResourceGroup));
        }

        private void GetBySubscription()
        {
            var resourceGroups = this.ResourcesClient.FilterPSResources(new PSResourceManagerModels.BasePSResourceParameters()
                {
                    ResourceType = "Microsoft.Web/ServerFarms"
                }).Select(sf => sf.ResourceGroupName);

            var list = new List<ServerFarmWithRichSku>();
            foreach (var rg in resourceGroups)
            {
                var result = WebsitesClient.ListAppServicePlan(rg) == null ? null : WebsitesClient.ListAppServicePlan(rg).Value;
                if (result != null)
                {
                    list.AddRange(result);
                }
            }

            WriteObject(new ServerFarmCollection() { Value = list } );
        }
    }
}

