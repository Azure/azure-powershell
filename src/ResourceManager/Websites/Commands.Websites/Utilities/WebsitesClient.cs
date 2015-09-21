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
using System.IO;
using System.Linq;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.WebSites;
using Microsoft.Azure.Management.WebSites.Models;
using System.Net;
using System.Xml.Linq;
using Microsoft.PowerShell;

namespace Microsoft.Azure.Commands.WebApp.Utilities
{
    public class WebsitesClient
    {
        public Action<string> VerboseLogger { get; set; }

        private static readonly Dictionary<string, int> WorkerSizes = new Dictionary<string, int> (StringComparer.OrdinalIgnoreCase) { { "Small", 1 }, { "Medium", 2 }, { "Large", 3 }, { "ExtraLarge", 4 } };

        public WebsitesClient(AzureContext context)
        {
            this.WrappedWebsitesClient = AzureSession.ClientFactory.CreateArmClient<WebSiteManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);

        }
        public WebSiteManagementClient WrappedWebsitesClient
        {
            get;
            private set;
        }

        public Site CreateWebsite(string resourceGroupName, string webSiteName, string slotName, string location, string serverFarmId, CloningInfo cloningInfo)
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
                            ServerFarmId = serverFarmId,
                            CloningInfo =  cloningInfo
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

        public string GetWebsitePublishingProfile(string resourceGroupName, string webSiteName, string slotName, string outputFile, string format)
        {
            string qualifiedSiteName;
            var options = new CsmPublishingProfileOptions
            {
                Format = format
            };

            var publishingXml = (ShouldSlotInterfaceBeUsed(webSiteName, slotName, out qualifiedSiteName) ? WrappedWebsitesClient.Sites.ListSitePublishingProfileXmlSlot(resourceGroupName, webSiteName, options, slotName) : WrappedWebsitesClient.Sites.ListSitePublishingProfileXml(resourceGroupName, webSiteName, options));
             var doc = XDocument.Load(publishingXml, LoadOptions.None);
             doc.Save(outputFile, SaveOptions.OmitDuplicateNamespaces);
            return doc.ToString();
        }

        public XDocument GetWebAppUsageMetrics(string resourceGroupName, string webSiteName, string slotName, IReadOnlyList<string> metricNames,
    DateTime? startTime, DateTime? endTime, string timeGrain, bool instanceDetails)
        {
            string qualifiedSiteName;
            var usageMetrics = ShouldSlotInterfaceBeUsed(webSiteName, slotName, out qualifiedSiteName) ?
                WrappedWebsitesClient.Sites.GetSiteMetricsSlot(resourceGroupName, webSiteName, slotName, instanceDetails, BuildMetricFilter(startTime, endTime, timeGrain, metricNames)) :
                WrappedWebsitesClient.Sites.GetSiteMetrics(resourceGroupName, webSiteName, instanceDetails, BuildMetricFilter(startTime, endTime, timeGrain, metricNames));
            return XDocument.Load(usageMetrics, LoadOptions.None);
        }

        public ServerFarmWithRichSku CreateAppServicePlan(string resourceGroupName, string appServicePlanName, string location, string adminSiteName, SkuDescription sku)
        {
            var serverFarm = new ServerFarmWithRichSku
            {
                Location = location,
                ServerFarmWithRichSkuName = appServicePlanName,
                Sku = sku,
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

        public MetricResponseCollection GetAppServicePlanHistoricalUsageMetrics(string resourceGroupName, string appServicePlanName, IReadOnlyList<string> metricNames,
    DateTime? startTime, DateTime? endTime, string timeGrain, bool instanceDetails)
        {
            var response = WrappedWebsitesClient.ServerFarms.GetServerFarmMetrics(resourceGroupName, appServicePlanName, instanceDetails, BuildMetricFilter(startTime, endTime, timeGrain, metricNames));
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
                var appSettings = ShouldSlotInterfaceBeUsed(webSiteName, slotName, out qualifiedSiteName) ? WrappedWebsitesClient.Sites.ListSiteAppSettingsSlot(resourceGroupName, webSiteName, slotName): WrappedWebsitesClient.Sites.ListSiteAppSettings(resourceGroupName, webSiteName);
                
                site.SiteConfig.AppSettings = appSettings.Properties.Select(s => new NameValuePair{ Name = s.Key, Value = s.Value}).ToList();

                var connectionStrings = ShouldSlotInterfaceBeUsed(webSiteName, slotName, out qualifiedSiteName) ? WrappedWebsitesClient.Sites.ListSiteConnectionStringsSlot(resourceGroupName, webSiteName, slotName) : WrappedWebsitesClient.Sites.ListSiteConnectionStrings(resourceGroupName, webSiteName);

                site.SiteConfig.ConnectionStrings = connectionStrings.Properties.Select(s => new ConnStringInfo() { Name = s.Key, ConnectionString = s.Value.Value, Type = s.Value.Type }).ToList();
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

        private static string BuildMetricFilter(DateTime? startTime, DateTime? endTime, string timeGrain, IReadOnlyList<string> metricNames)
        {
            var dateTimeFormat = "yyyy-MM-ddTHH:mm:ssZ";
            var filter = "";
            if (metricNames != null && metricNames.Count > 0)
            {
                if (metricNames.Count == 1)
                {
                    filter = "name.value eq '" + metricNames[0] + "'";
                }
                else
                {
                    filter = "(name.value eq '" + string.Join("' or name.value eq '", metricNames) + "')";
                }
            }

            if (startTime.HasValue)
            {
                filter += string.Format("and startTime eq {0}", startTime.Value.ToString(dateTimeFormat));
            }

            if (endTime.HasValue)
            {
                filter += string.Format("and endTime eq {0}", endTime.Value.ToString(dateTimeFormat));
            }

            if (endTime.HasValue)
            {
                filter += string.Format("and timeGrain eq duration'{0}'", timeGrain);
            }

            return filter;
        }

        internal static string GetSkuName(string tier, int workerSize)
        {
            string sku;
            if (string.Equals("Shared", tier, StringComparison.OrdinalIgnoreCase))
            {
                sku = "D";
            }
            else
            {
                sku = string.Empty + tier[0];
            }

            sku += workerSize;
            return sku;
        }

        internal static string GetSkuName(string tier, string workerSize)
        {
            string sku;
            if (string.Equals("Shared", tier, StringComparison.OrdinalIgnoreCase))
            {
                sku = "D";
            }
            else
            {
                sku = string.Empty + tier[0];
            }

            sku += WorkerSizes[workerSize];
            return sku;
        }       
    }
}
