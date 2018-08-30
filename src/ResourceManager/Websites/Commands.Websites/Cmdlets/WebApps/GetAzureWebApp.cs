﻿// ----------------------------------------------------------------------------------
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
using Microsoft.Azure.Management.Internal.Resources.Utilities;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

#if NETSTANDARD
using ServerFarmWithRichSku = Microsoft.Azure.Management.WebSites.Models.AppServicePlan;
#endif
namespace Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps
{
    /// <summary>
    /// this commandlet will let you get a new Azure Websites using ARM APIs
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "WebApp")]
    [OutputType(typeof(Site))]
    public class GetAzureWebAppCmdlet : WebAppBaseClientCmdLet
    {
        private const string ParameterSet1 = "S1";
        private const string ParameterSet2 = "S2";
        private const string ParameterSet3 = "S3";

        [Parameter(ParameterSetName = ParameterSet1, Position = 0, Mandatory = false, HelpMessage = "The name of the resource group.", ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSet1, Position = 1, Mandatory = false, HelpMessage = "The name of the web app.", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSet2, Position = 0, Mandatory = true, HelpMessage = "The app service plan. Gets all web apps in specified service plan")]
        [ValidateNotNullOrEmpty]
        public AppServicePlan AppServicePlan { get; set; }

        [Parameter(ParameterSetName = ParameterSet3, Position = 0, Mandatory = true, HelpMessage = "The name of the web app location. Gets all web apps at location")]
        [LocationCompleter("Microsoft.Web/sites")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case ParameterSet1:
                    if (!string.IsNullOrWhiteSpace(ResourceGroupName) && !string.IsNullOrWhiteSpace(Name))
                    {
                        WriteObject(WebsitesClient.GetWebApp(ResourceGroupName, Name, null));
                    }
                    else if (!string.IsNullOrWhiteSpace(ResourceGroupName))
                    {
                        GetByResourceGroup();
                    }
                    else if (!string.IsNullOrWhiteSpace(Name))
                    {
                        GetByWebAppName();
                    }
                    else
                    {
                        GetBySubscription();
                    }
                    break;
                case ParameterSet2:
                    GetByAppServicePlan();
                    break;
                case ParameterSet3:
                    GetByLocation();
                    break;
            }
        }

        private void GetByWebAppName()
        {
            const string progressDescriptionFormat = "Progress: {0}/{1} web apps processed.";
            var progressRecord = new ProgressRecord(1, string.Format("Get web apps with name '{0}'", Name), "Progress:");

            WriteProgress(progressRecord);

            var sites = this.ResourcesClient.ResourceManagementClient.FilterResources(new FilterResourcesOptions()
            {
                ResourceType = "Microsoft.Web/Sites"
            }).Where(s => string.Equals(s.Name, Name, StringComparison.OrdinalIgnoreCase)).ToArray();

            var list = new List<Site>();
            for (var i = 0; i < sites.Length; i++)
            {
                var s = sites[i];
                var result = WebsitesClient.GetWebApp(s.ResourceGroupName, s.Name, null);
                if (result != null)
                {
                    list.Add(result);
                }

                progressRecord.StatusDescription = string.Format(progressDescriptionFormat, i + 1, sites.Length);
                progressRecord.PercentComplete = (100 * (i + 1)) / sites.Length;
                WriteProgress(progressRecord);
            }

            WriteObject(list, true);
        }

        private void GetByResourceGroup()
        {
            var list = new List<Site>();
            try
            {
                var result = WebsitesClient.ListWebApps(ResourceGroupName, null);
                if (result != null)
                {
                    list.AddRange(result);
                }
            }
            catch (Exception e)
            {
                WriteExceptionError(e);
            }

            WriteObject(list, true);
        }

        private void GetBySubscription()
        {
            const string progressDescriptionFormat = "Progress: {0}/{1} resource groups processed.";
            const string progressCurrentOperationFormat = "Getting web apps for resource group '{0}'";
            var progressRecord = new ProgressRecord(1, "Get web apps from all resource groups in subscription", "Progress:")
            {
                CurrentOperation = "Getting all subscription resource groups ..."
            };

            WriteProgress(progressRecord);

            var resourceGroups = this.ResourcesClient.ResourceManagementClient.FilterResources(new FilterResourcesOptions()
            {
                ResourceType = "Microsoft.Web/Sites"
            }).Select(s => s.ResourceGroupName).Distinct(StringComparer.OrdinalIgnoreCase).ToArray();

            var list = new List<Site>();

            for (var i = 0; i < resourceGroups.Length; i++)
            {
                var rg = resourceGroups[i];
                try
                {
                    var result = WebsitesClient.ListWebApps(rg, null);
                    if (result != null)
                    {
                        list.AddRange(result);
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
            const string progressDescriptionFormat = "Progress: {0}/{1} web apps processed.";
            var progressRecord = new ProgressRecord(1, string.Format("Get web apps at location '{0}'", Location), "Progress:");

            WriteProgress(progressRecord);

            var sites = this.ResourcesClient.ResourceManagementClient.FilterResources(new FilterResourcesOptions()
            {
                ResourceType = "Microsoft.Web/Sites"
            }).Where(s => string.Equals(s.Location, Location.Replace(" ", string.Empty), StringComparison.OrdinalIgnoreCase)).ToArray();

            var list = new List<Site>();
            for (var i = 0; i < sites.Length; i++)
            {
                try
                {
                    var sf = sites[i];
                    var result = WebsitesClient.GetWebApp(sf.ResourceGroupName, sf.Name, null);
                    if (result != null)
                    {
                        list.Add(result);
                    }
                }
                catch (Exception e)
                {
                    WriteExceptionError(e);
                }

                progressRecord.StatusDescription = string.Format(progressDescriptionFormat, i + 1, sites.Length);
                progressRecord.PercentComplete = (100 * (i + 1)) / sites.Length;
                WriteProgress(progressRecord);
            }

            WriteObject(list, true);
        }

        private void GetByAppServicePlan()
        {
            WriteObject(WebsitesClient.ListWebAppsForAppServicePlan(AppServicePlan.ResourceGroup,
                AppServicePlan.Name).ToList(), true);
        }
    }
}
