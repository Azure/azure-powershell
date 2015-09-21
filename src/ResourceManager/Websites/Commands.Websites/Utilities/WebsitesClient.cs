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
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Threading;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Commands;
using Microsoft.Azure.Management.WebSites;
using System.Net;
using Hyak.Common;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Management.WebSites.Models;

namespace Microsoft.Azure.Commands.WebApp.Utilities
{
    public class WebsitesClient
    {
        public Action<string> VerboseLogger { get; set; }

        public WebsitesClient(AzureContext context)
        {
            this.WrappedWebsitesClient = AzureSession.ClientFactory.CreateClient<WebSiteManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);

        }
        public WebSiteManagementClient WrappedWebsitesClient
        {
            get;
            private set;
        }

        public WebSite CreateWebsite(string resourceGroupName, string webSiteName, string slotName, string location, string webHostingPlan)
        {
            string webSiteSlotName = webSiteName;
            if (string.IsNullOrEmpty(slotName) == false)
            {
                webSiteSlotName = string.Concat(webSiteName, "/", slotName);

            }
           
            var createdWebSite = WrappedWebsitesClient.WebSites.CreateOrUpdate(
                        resourceGroupName, webSiteName, slotName,
                        new WebSiteCreateOrUpdateParameters
                        {
                            WebSite = new WebSiteBase
                            {
                                Name = webSiteSlotName,
                                Location = location,
                                Properties = new WebSiteBaseProperties(webHostingPlan)
                            }
                        });
            createdWebSite.WebSite.Properties.SiteConfig = new WebSiteConfiguration()
            {
                AppSettings = new Dictionary<string, string>(),
                ConnectionStrings = new List<ConnectionStringInfo>(),
                Metadata = new Dictionary<string, string>()
            };
            createdWebSite.WebSite.Properties.SiteConfig = GetWebSiteConfiguration(resourceGroupName, webSiteName, slotName);
            return createdWebSite.WebSite;
        }

        public System.Net.HttpStatusCode StartWebsite(string resourceGroupName, string webSiteName, string slotName)
        {
                 var startedWebsite =  WrappedWebsitesClient.WebSites.Start(resourceGroupName, webSiteName, slotName);
                 return startedWebsite.StatusCode;
        }
        public System.Net.HttpStatusCode StopWebsite(string resourceGroupName, string webSiteName, string slotName)
        {
            var stoppedWebsite = WrappedWebsitesClient.WebSites.Stop(resourceGroupName, webSiteName, slotName);
            return stoppedWebsite.StatusCode;
        }
        public System.Net.HttpStatusCode RestartWebsite(string resourceGroupName, string webSiteName, string slotName)
        {
            var restartedWebsite = WrappedWebsitesClient.WebSites.Restart(resourceGroupName, webSiteName, slotName);
            return restartedWebsite.StatusCode;
        }

        public System.Net.HttpStatusCode RemoveWebsite(string resourceGroupName, string webSiteName, string slotName, bool deleteEmptyServerFarmBydefault, bool deleteMetricsBydefault, bool deleteSlotsBydefault)
        {
            WebSiteDeleteParameters webSiteDelParams = new WebSiteDeleteParameters(deleteEmptyServerFarmBydefault, deleteMetricsBydefault, deleteSlotsBydefault);
            
            var removedWebsite = WrappedWebsitesClient.WebSites.Delete(resourceGroupName, webSiteName, slotName, webSiteDelParams);
            return removedWebsite.StatusCode;
        }

        public WebSite GetWebsite(string resourceGroupName, string webSiteName, string slotName)
        {
            WebSiteGetParameters webSiteGetParams = new WebSiteGetParameters();
            var getWebsite = WrappedWebsitesClient.WebSites.Get(resourceGroupName, webSiteName, slotName, webSiteGetParams);
            getWebsite.WebSite.Properties.SiteConfig = new WebSiteConfiguration()
            {
                AppSettings = new Dictionary<string, string>(),
                ConnectionStrings = new List<ConnectionStringInfo>(),
                Metadata = new Dictionary<string, string>()
            };
            getWebsite.WebSite.Properties.SiteConfig = GetWebSiteConfiguration(resourceGroupName, webSiteName, slotName);                   
            return getWebsite.WebSite;
        }

        public WebSiteGetPublishProfileResponse GetWebsitePublishingProfile(string resourceGroupName, string webSiteName, string slotName)
        {
            var pubCreds = WrappedWebsitesClient.WebSites.GetPublishProfile(resourceGroupName, webSiteName, slotName);
            return pubCreds;
        }

        public WebSiteGetHistoricalUsageMetricsResponse GetWebAppUsageMetrics(string resourceGroupName, string webSiteName, string slotName,  IList<string> metricNames,
    DateTime? startTime, DateTime? endTime, string timeGrain, bool instanceDetails)
        {
            WebSiteGetHistoricalUsageMetricsParameters parameters = new WebSiteGetHistoricalUsageMetricsParameters();
            parameters.MetricNames = metricNames;
            parameters.IncludeInstanceBreakdown = instanceDetails;
            parameters.EndTime = endTime;
            parameters.StartTime = startTime;
            parameters.TimeGrain = timeGrain;
            var usageMetrics = WrappedWebsitesClient.WebSites.GetHistoricalUsageMetrics(resourceGroupName, webSiteName, slotName,parameters);
            return usageMetrics;
        }

        public WebHostingPlanCreateOrUpdateResponse CreateAppServicePlan(string resourceGroupName, string whpName, string location, string adminSiteName, int numberOfWorkers, SkuOptions sku, WorkerSizeOptions workerSize)
        {
            WebHostingPlanProperties webHostingPlanProperties = new WebHostingPlanProperties();
            webHostingPlanProperties.Sku = sku;
            webHostingPlanProperties.AdminSiteName = adminSiteName;
            webHostingPlanProperties.NumberOfWorkers = numberOfWorkers;
            webHostingPlanProperties.WorkerSize = workerSize;
            WebHostingPlan webHostingPlan = new WebHostingPlan();        
            WebHostingPlanCreateOrUpdateParameters webHostingPlanCreateOrUpdateParameters = new WebHostingPlanCreateOrUpdateParameters(webHostingPlan);
            webHostingPlanCreateOrUpdateParameters.WebHostingPlan.Location = location;
            webHostingPlanCreateOrUpdateParameters.WebHostingPlan.Name = whpName;
            webHostingPlanCreateOrUpdateParameters.WebHostingPlan.Properties = webHostingPlanProperties;

            var createdWHP = WrappedWebsitesClient.WebHostingPlans.CreateOrUpdate(resourceGroupName, webHostingPlanCreateOrUpdateParameters);
            //proper return type need to be discussed
            return createdWHP;
        }

        public AzureOperationResponse RemoveAppServicePlan(string resourceGroupName, string whpName)
        {
            var response = WrappedWebsitesClient.WebHostingPlans.Delete(resourceGroupName, whpName);
            return response;
        }

        public WebHostingPlanGetResponse GetAppServicePlan(string resourceGroupName, string whpName)
        {
            var response = WrappedWebsitesClient.WebHostingPlans.Get(resourceGroupName, whpName);
            return response;
        }

        public WebHostingPlanListResponse ListAppServicePlan(string resourceGroupName)
        {       
            var response = WrappedWebsitesClient.WebHostingPlans.List(resourceGroupName);
            return response;
        }

        public WebHostingPlanGetHistoricalUsageMetricsResponse GetAppServicePlanHistoricalUsageMetrics(string resourceGroupName, string appServicePlanName, IList<string> metricNames,
    DateTime? startTime, DateTime? endTime, string timeGrain, bool instanceDetails)
        {
            WebHostingPlanGetHistoricalUsageMetricsParameters parameters = new WebHostingPlanGetHistoricalUsageMetricsParameters();
            parameters.MetricNames = metricNames;
            parameters.IncludeInstanceBreakdown = instanceDetails;
            parameters.EndTime = endTime;
            parameters.StartTime = startTime;
            parameters.TimeGrain = timeGrain;
            var response = WrappedWebsitesClient.WebHostingPlans.GetHistoricalUsageMetrics(resourceGroupName, appServicePlanName, parameters);
            return response;
        }
        
        private WebSiteConfiguration GetWebSiteConfiguration(string resourceGroupName, string webSiteName, string slotName)
        {
            WebSiteConfiguration siteConfinguration = new WebSiteConfiguration();
            try
            {
                var getAppSettings = WrappedWebsitesClient.WebSites.GetAppSettings(resourceGroupName, webSiteName, slotName);
                //Add websiteApp Settings to the Website object as the Create call will not return them.
                foreach (var appSettingVal in getAppSettings.Resource.Properties.ToList())
                {
                    if (!siteConfinguration.AppSettings.Keys.Contains(appSettingVal.Name))
                        siteConfinguration.AppSettings.Add(appSettingVal.Name, appSettingVal.Value);
                }
                var getConnStrings = WrappedWebsitesClient.WebSites.GetConnectionStrings(resourceGroupName, webSiteName, slotName);
                //Add websiteApp Settings to the Website object as the Create call will not return them.
                foreach (var connSettingVal in getConnStrings.Resource.Properties.ToList())
                {
                    siteConfinguration.ConnectionStrings.Add(connSettingVal);
                }
                var getMetaDataSettings = WrappedWebsitesClient.WebSites.GetAppSettings(resourceGroupName, webSiteName, slotName);
                //Add websiteApp Settings to the Website object as the Create call will not return them.
                foreach (var metadataVal in getMetaDataSettings.Resource.Properties.ToList())
                {
                    if (!siteConfinguration.Metadata.Keys.Contains(metadataVal.Name))
                        siteConfinguration.Metadata.Add(metadataVal.Name, metadataVal.Value);
                }                
            }
            catch
            {
                //ignore if this call fails as it will for reader RBAC
            }
            return siteConfinguration;
        }
    }
}
