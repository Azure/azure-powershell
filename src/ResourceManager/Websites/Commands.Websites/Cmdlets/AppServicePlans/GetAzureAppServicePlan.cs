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


using Microsoft.Azure.Commands.WebApps.Models;
using Microsoft.Azure.Management.WebSites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using PSResourceManagerModels = Microsoft.Azure.Commands.Resources.Models;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.AppServicePlans
{
    /// <summary>
    /// this commandlet will let you Get an Azure App Service Plan using ARM APIs
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmAppServicePlan"), OutputType(typeof(ServerFarmWithRichSku), typeof(ServerFarmCollection))]
    public class GetAppServicePlanCmdlet : WebAppBaseClientCmdLet
    {
        private const string ParameterSet1 = "S1";
        private const string ParameterSet2 = "S2";

        [Parameter(ParameterSetName = ParameterSet1, Position = 0, Mandatory = false, HelpMessage = "The name of the resource group.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSet1, Position = 1, Mandatory = false, HelpMessage = "The name of the app service plan.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }


        [Parameter(ParameterSetName = ParameterSet2, Position = 0, Mandatory = true, HelpMessage = "The location of the app service plan.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case ParameterSet1:
                    if (!string.IsNullOrEmpty(ResourceGroupName) && !string.IsNullOrEmpty(Name))
                    {
                        GetAppServicePlan();
                    }
                    else if (!string.IsNullOrEmpty(ResourceGroupName))
                    {
                        GetByResourceGroup();
                    }
                    else if (!string.IsNullOrEmpty(Name))
                    {
                        GetByAppServicePlanName();
                    }
                    else
                    {
                        GetBySubscription();
                    }
                    break;
                case ParameterSet2:
                    GetByLocation();
                    break;
            }
        }

        private void GetAppServicePlan()
        {
            WriteObject(WebsitesClient.GetAppServicePlan(ResourceGroupName, Name), true);
        }

        private void GetByAppServicePlanName()
        {
            const string progressDescriptionFormat = "Progress: {0}/{1} app service plans processed.";
            var progressRecord = new ProgressRecord(1, string.Format("Get app service plans with name '{0}'", Name), "Progress:");

            WriteProgress(progressRecord);

            var serverFarmResources = this.ResourcesClient.FilterPSResources(new PSResourceManagerModels.BasePSResourceParameters()
            {
                ResourceType = "Microsoft.Web/ServerFarms"
            }).Where(sf => string.Equals(sf.Name, Name, StringComparison.OrdinalIgnoreCase)).ToArray();

            var list = new List<ServerFarmWithRichSku>();
            for (var i = 0; i < serverFarmResources.Length; i++)
            {
                var sf = serverFarmResources[i];
                try
                {
                    var result = WebsitesClient.GetAppServicePlan(sf.ResourceGroupName, sf.Name);
                    if (result != null)
                    {
                        list.Add(result);
                    }
                }
                catch (Exception e)
                {
                    WriteExceptionError(e);
                }

                progressRecord.StatusDescription = string.Format(progressDescriptionFormat, i + 1, serverFarmResources.Length);
                progressRecord.PercentComplete = (100 * (i + 1)) / serverFarmResources.Length;
                WriteProgress(progressRecord);
            }

            WriteObject(list, true);
        }

        private void GetByResourceGroup()
        {
            WriteObject(WebsitesClient.ListAppServicePlans(ResourceGroupName).Value, true);
        }

        private void GetBySubscription()
        {
            const string progressDescriptionFormat = "Progress: {0}/{1} resource groups processed.";
            const string progressCurrentOperationFormat = "Getting app service plans for resource group '{0}'";
            var progressRecord = new ProgressRecord(1, "Get app service plans from all resource groups", "Progress:")
            {
                CurrentOperation = "Getting all subscription resource groups ..."
            };

            WriteProgress(progressRecord);

            var resourceGroups = this.ResourcesClient.FilterPSResources(new PSResourceManagerModels.BasePSResourceParameters()
            {
                ResourceType = "Microsoft.Web/ServerFarms"
            }).Select(sf => sf.ResourceGroupName).Distinct(StringComparer.OrdinalIgnoreCase).ToArray();

            var list = new List<ServerFarmWithRichSku>();


            for (var i = 0; i < resourceGroups.Length; i++)
            {
                var rg = resourceGroups[i];
                try
                {
                    var result = WebsitesClient.ListAppServicePlans(rg);
                    if (result != null && result.Value != null)
                    {
                        list.AddRange(result.Value);
                    }
                }
                catch (Exception e)
                {
                    WriteExceptionError(e);
                }

                progressRecord.CurrentOperation = string.Format(progressCurrentOperationFormat, rg);
                progressRecord.StatusDescription = string.Format(progressDescriptionFormat, i + 1, resourceGroups.Length);
                progressRecord.PercentComplete = (100 * (i + 1)) / resourceGroups.Length;
                WriteProgress(progressRecord);
            }

            WriteObject(list, true);
        }

        private void GetByLocation()
        {
            const string progressDescriptionFormat = "Progress: {0}/{1} app service plans processed.";
            var progressRecord = new ProgressRecord(1, string.Format("Get app service plans at location '{0}'", Location), "Progress:");

            WriteProgress(progressRecord);

            var serverFarmResources = this.ResourcesClient.FilterPSResources(new PSResourceManagerModels.BasePSResourceParameters()
            {
                ResourceType = "Microsoft.Web/ServerFarms"
            }).Where(sf => string.Equals(sf.Location, Location.Replace(" ", string.Empty), StringComparison.OrdinalIgnoreCase)).ToArray();

            var list = new List<ServerFarmWithRichSku>();
            for (var i = 0; i < serverFarmResources.Length; i++)
            {
                var sf = serverFarmResources[i];
                try
                {
                    var result = WebsitesClient.GetAppServicePlan(sf.ResourceGroupName, sf.Name);
                    if (result != null)
                    {
                        list.Add(result);
                    }
                }
                catch (Exception e)
                {
                    WriteExceptionError(e);
                }

                progressRecord.StatusDescription = string.Format(progressDescriptionFormat, i + 1, serverFarmResources.Length);
                progressRecord.PercentComplete = (100 * (i + 1)) / serverFarmResources.Length;
                WriteProgress(progressRecord);
            }

            WriteObject(list, true);
        }
    }
}

