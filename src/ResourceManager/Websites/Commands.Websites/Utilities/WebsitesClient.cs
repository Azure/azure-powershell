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
using System.Xml;
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
            this.WrappedWebsitesClient = AzureSession.ClientFactory.CreateArmClient<WebSiteManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);

        }
        public WebSiteManagementClient WrappedWebsitesClient
        {
            get;
            private set;
        }

        public Site CreateWebsite(string resourceGroupName, string webSiteName, string slotName, string location, string serverFarmId)
        {
            Site createdWebSite = null;
            string qualifiedSiteName;
            if (ShouldSlotInterfaceBeUsed(webSiteName, slotName, out qualifiedSiteName))
            {
                createdWebSite = WrappedWebsitesClient.Sites.CreateOrUpdateSiteSlot(
                        resourceGroupName, webSiteName, slot: slotName, siteEnvelope:
                        new Site
                        {
                            SiteName = qualifiedSiteName,
                            Location = location,
                            ServerFarmId = serverFarmId
                        });
            }
            else
            {
                createdWebSite = WrappedWebsitesClient.Sites.CreateOrUpdateSite(
                        resourceGroupName, webSiteName, siteEnvelope:
                        new Site
                        {
                            SiteName = qualifiedSiteName,
                            Location = location,
                            ServerFarmId = serverFarmId
                        });
            }

            GetWebSiteConfiguration(resourceGroupName, webSiteName, slotName, createdWebSite);
            return createdWebSite;
        }

        public HttpStatusCode StartWebsite(string resourceGroupName, string webSiteName, string slotName)
        {
            string qualifiedSiteName;
            if (ShouldSlotInterfaceBeUsed(webSiteName, slotName, out qualifiedSiteName))
            {
                WrappedWebsitesClient.Sites.StartSiteSlot(resourceGroupName, webSiteName, slotName);
            }
            else
            {
                WrappedWebsitesClient.Sites.StartSite(resourceGroupName, webSiteName);
            }

            return HttpStatusCode.OK;
        }
        public HttpStatusCode StopWebsite(string resourceGroupName, string webSiteName, string slotName)
        {
            string qualifiedSiteName;
            if (ShouldSlotInterfaceBeUsed(webSiteName, slotName, out qualifiedSiteName))
            {
                WrappedWebsitesClient.Sites.StopSiteSlot(resourceGroupName, webSiteName, slotName);
            }
            else
            {
                WrappedWebsitesClient.Sites.StopSite(resourceGroupName, webSiteName);
            }
            return HttpStatusCode.OK;
        }
        public HttpStatusCode RestartWebsite(string resourceGroupName, string webSiteName, string slotName)
        {
            string qualifiedSiteName;
            if (ShouldSlotInterfaceBeUsed(webSiteName, slotName, out qualifiedSiteName))
            {
                WrappedWebsitesClient.Sites.RestartSiteSlot(resourceGroupName, webSiteName, slotName);
            }
            else
            {
                WrappedWebsitesClient.Sites.RestartSite(resourceGroupName, webSiteName);
            }

            return HttpStatusCode.OK;
        }

        public HttpStatusCode RemoveWebsite(string resourceGroupName, string webSiteName, string slotName, bool deleteEmptyServerFarmBydefault, bool deleteMetricsBydefault, bool deleteSlotsBydefault)
        {
            string qualifiedSiteName;
            if (ShouldSlotInterfaceBeUsed(webSiteName, slotName, out qualifiedSiteName))
            {
                WrappedWebsitesClient.Sites.DeleteSiteSlot(resourceGroupName, webSiteName, slotName, deleteMetrics: deleteMetricsBydefault.ToString(), deleteEmptyServerFarm: deleteEmptyServerFarmBydefault.ToString(), deleteAllSlots: deleteSlotsBydefault.ToString());
            }
            else
            {
                WrappedWebsitesClient.Sites.DeleteSite(resourceGroupName, webSiteName, deleteMetrics: deleteMetricsBydefault.ToString(), deleteEmptyServerFarm: deleteEmptyServerFarmBydefault.ToString(), deleteAllSlots: deleteSlotsBydefault.ToString());
            }

            return HttpStatusCode.OK;
        }

        public Site GetWebsite(string resourceGroupName, string webSiteName, string slotName)
        {
            Site site = null; 
            string qualifiedSiteName;
            
            site = ShouldSlotInterfaceBeUsed(webSiteName, slotName, out qualifiedSiteName) ? WrappedWebsitesClient.Sites.GetSiteSlot(resourceGroupName, webSiteName, slotName) : WrappedWebsitesClient.Sites.GetSite(resourceGroupName, webSiteName);

            GetWebSiteConfiguration(resourceGroupName, webSiteName, slotName, site);

            return site;
        }

        public XmlElement GetWebsitePublishingProfile(string resourceGroupName, string webSiteName, string slotName)
        {
            string qualifiedSiteName;
            var publishingXml = (ShouldSlotInterfaceBeUsed(webSiteName, slotName, out qualifiedSiteName) ? WrappedWebsitesClient.Sites.ListSiteSlotPublishingProfileXml(resourceGroupName, webSiteName, null, slotName) : WrappedWebsitesClient.Sites.ListSitePublishingProfileXml(resourceGroupName, webSiteName, null)) as XmlElement;

            return publishingXml;
        }

        public MetricResponseCollection GetWebAppUsageMetrics(string resourceGroupName, string webSiteName, string slotName, IList<string> metricNames,
    DateTime? startTime, DateTime? endTime, string timeGrain, bool instanceDetails)
        {
            string qualifiedSiteName;
            var usageMetrics = ShouldSlotInterfaceBeUsed(webSiteName, slotName, out qualifiedSiteName) ?
                WrappedWebsitesClient.Sites.GetSiteSlotMetrics(resourceGroupName, webSiteName, slotName, string.Join(",", metricNames), startTime.ToString(), endTime.ToString(), timeGrain, instanceDetails): 
                WrappedWebsitesClient.Sites.GetSiteMetrics(resourceGroupName, webSiteName, string.Join(",", metricNames), startTime.ToString(), endTime.ToString(), timeGrain, instanceDetails);
            return usageMetrics;
        }

        public ServerFarmWithRichSku CreateAppServicePlan(string resourceGroupName, string appServicePlanName, string location, string adminSiteName, string sku, string tier, int? capacity)
        {
            var serverFarm = new ServerFarmWithRichSku
            {
                Location = location,
                ServerFarmWithRichSkuName = appServicePlanName,
                Sku = new SkuDescription
                {
                    Name = sku, 
                    Tier = tier,
                    Capacity = capacity
                },
                AdminSiteName = adminSiteName
            };

            return WrappedWebsitesClient.ServerFarms.CreateOrUpdateServerFarm(resourceGroupName, appServicePlanName, serverFarm);
        }

        public HttpStatusCode RemoveAppServicePlan(string resourceGroupName, string appServicePlanName)
        {
            WrappedWebsitesClient.ServerFarms.DeleteServerFarm(resourceGroupName, appServicePlanName);
            return HttpStatusCode.OK;
        }

        public ServerFarmWithRichSku GetAppServicePlan(string resourceGroupName, string appServicePlanName)
        {
            return WrappedWebsitesClient.ServerFarms.GetServerFarm(resourceGroupName, appServicePlanName);
        }

        public ServerFarmCollection ListAppServicePlan(string resourceGroupName)
        {
            return WrappedWebsitesClient.ServerFarms.GetServerFarms(resourceGroupName);
        }

        public MetricResponseCollection GetAppServicePlanHistoricalUsageMetrics(string resourceGroupName, string appServicePlanName, IList<string> metricNames,
    DateTime? startTime, DateTime? endTime, string timeGrain, bool instanceDetails)
        {
            var response = WrappedWebsitesClient.ServerFarms.GetServerFarmMetrics(resourceGroupName, appServicePlanName, string.Join(",", metricNames), startTime.ToString(), endTime.ToString(), timeGrain, instanceDetails);
            return response;
        }

        private void GetWebSiteConfiguration(string resourceGroupName, string webSiteName, string slotName, Site site)
        {
            try
            {
                if (site.SiteConfig == null)
                {
                    site.SiteConfig = new SiteConfig();
                }

                string qualifiedSiteName;
                var appSettings = ShouldSlotInterfaceBeUsed(webSiteName, slotName, out qualifiedSiteName) ? WrappedWebsitesClient.Sites.ListSiteSlotAppSettings(resourceGroupName, webSiteName, slotName): WrappedWebsitesClient.Sites.ListSiteAppSettings(resourceGroupName, webSiteName);
                
                site.SiteConfig.AppSettings = appSettings.Select(s => new NameValuePair{ Name = s.Key, Value = s.Value}).ToList();

                var connectionStrings = ShouldSlotInterfaceBeUsed(webSiteName, slotName, out qualifiedSiteName) ? WrappedWebsitesClient.Sites.ListSiteSlotConnectionStrings(resourceGroupName, webSiteName, slotName) : WrappedWebsitesClient.Sites.ListSiteConnectionStrings(resourceGroupName, webSiteName);

                site.SiteConfig.ConnectionStrings = connectionStrings.Select(s => new ConnStringInfo() { Name = s.Key, ConnectionString = s.Value.Value, Type = s.Value.Type }).ToList();
            }
            catch
            {
                //ignore if this call fails as it will for reader RBAC
            }
        }

        private bool ShouldSlotInterfaceBeUsed(string webSiteName, string slotName, out string qualifiedSiteName)
        {
            bool result = false;
            qualifiedSiteName = webSiteName;
            var siteNamePattern = "{0}({1})";
            if (!string.IsNullOrEmpty(slotName) && !string.Equals(slotName, "Production", StringComparison.OrdinalIgnoreCase))
            {
                result = true;
                qualifiedSiteName = string.Format(siteNamePattern, webSiteName, slotName);
            }

            return result;
        }
    }
}
