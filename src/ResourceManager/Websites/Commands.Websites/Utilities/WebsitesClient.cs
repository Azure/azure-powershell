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
using System.Net;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Management.WebSites;
using Microsoft.Azure.Management.WebSites.Models;

namespace Microsoft.Azure.Commands.WebApps.Utilities
{
    public class WebsitesClient
    {
        public Action<string> VerboseLogger { get; set; }

        public Action<string> ErrorLogger { get; set; }

        public Action<string> WarningLogger { get; set; }

        private static readonly Regex AppWithSlotNameRegex = new Regex(@"^(?<siteName>[^\(]+)\((?<slotName>[^\)]+)\)$");

        private static readonly Regex WebAppResourceIdRegex =
            new Regex(@"^\/subscriptions\/(?<subscriptionName>[^\/]+)\/resourceGroups\/(?<resourceGroupName>[^\/]+)\/providers\/Microsoft.Web\/sites\/(?<siteName>[^\/]+)$", RegexOptions.IgnoreCase);

        private static readonly Regex WebAppSlotResourceIdRegex =
           new Regex(@"^\/subscriptions\/(?<subscriptionName>[^\/]+)\/resourceGroups\/(?<resourceGroupName>[^\/]+)\/providers\/Microsoft.Web\/sites\/(?<siteName>[^\/]+)\/slots\/(?<slotName>[^\/]+)$", RegexOptions.IgnoreCase);
        
        private static readonly Regex AppServicePlanResourceIdRegex =
           new Regex(@"^\/subscriptions\/(?<subscriptionName>[^\/]+)\/resourceGroups\/(?<resourceGroupName>[^\/]+)\/providers\/Microsoft.Web\/serverFarms\/(?<serverFarmName>[^\/]+)$", RegexOptions.IgnoreCase);

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

        public Site CreateWebApp(string resourceGroupName, string webAppName, string slotName, string location, string serverFarmId, CloningInfo cloningInfo)
        {
            Site createdWebSite = null;
            string qualifiedSiteName;
            if (ShouldUseDeploymentSlot(webAppName, slotName, out qualifiedSiteName))
            {
                createdWebSite = WrappedWebsitesClient.Sites.CreateOrUpdateSiteSlot(
                        resourceGroupName, webAppName, slot: slotName, siteEnvelope:
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
                        resourceGroupName, webAppName, siteEnvelope:
                        new Site
                        {
                            SiteName = qualifiedSiteName,
                            Location = location,
                            ServerFarmId = serverFarmId
                        });
            }

            GetWebAppConfiguration(resourceGroupName, webAppName, slotName, createdWebSite);
            return createdWebSite;
        }

        public void UpdateWebApp(string resourceGroupName, string webAppName, string slotName, string appServicePlan)
        {
            var webSiteToUpdate = new Site()
            {
                ServerFarmId = appServicePlan
            };

            string qualifiedSiteName;
            if (ShouldUseDeploymentSlot(webAppName, slotName, out qualifiedSiteName))
            {
                WrappedWebsitesClient.Sites.CreateOrUpdateSiteSlot(resourceGroupName, webAppName, webSiteToUpdate, slotName);
            }
            else
            {
                webSiteToUpdate = WrappedWebsitesClient.Sites.CreateOrUpdateSite(resourceGroupName, webAppName, webSiteToUpdate);
            }
        }

        public void AddCustomHostNames(string resourceGroupName, string webAppName, string[] hostNames)
        {
            foreach (var hostName in hostNames)
            {
                try
                {
                    WrappedWebsitesClient.Sites.CreateOrUpdateSiteHostNameBinding(resourceGroupName, webAppName, hostName, null);
                }
                catch (Exception e)
                {
                    WriteWarning("Could not set custom hostname '{0}'. Details: {1}", hostName, e.ToString());
                }
            }
        }

        public HttpStatusCode StartWebApp(string resourceGroupName, string webSiteName, string slotName)
        {
            string qualifiedSiteName;
            if (ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName))
            {
                WrappedWebsitesClient.Sites.StartSiteSlot(resourceGroupName, webSiteName, slotName);
            }
            else
            {
                WrappedWebsitesClient.Sites.StartSite(resourceGroupName, webSiteName);
            }

            return HttpStatusCode.OK;
        }
        public HttpStatusCode StopWebApp(string resourceGroupName, string webSiteName, string slotName)
        {
            string qualifiedSiteName;
            if (ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName))
            {
                WrappedWebsitesClient.Sites.StopSiteSlot(resourceGroupName, webSiteName, slotName);
            }
            else
            {
                WrappedWebsitesClient.Sites.StopSite(resourceGroupName, webSiteName);
            }
            return HttpStatusCode.OK;
        }
        public HttpStatusCode RestartWebApp(string resourceGroupName, string webSiteName, string slotName)
        {
            string qualifiedSiteName;
            if (ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName))
            {
                WrappedWebsitesClient.Sites.RestartSiteSlot(resourceGroupName, webSiteName, slotName);
            }
            else
            {
                WrappedWebsitesClient.Sites.RestartSite(resourceGroupName, webSiteName);
            }

            return HttpStatusCode.OK;
        }

        public HttpStatusCode RemoveWebApp(string resourceGroupName, string webSiteName, string slotName, bool deleteEmptyServerFarmBydefault, bool deleteMetricsBydefault, bool deleteSlotsBydefault)
        {
            string qualifiedSiteName;
            if (ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName))
            {
                WrappedWebsitesClient.Sites.DeleteSiteSlot(resourceGroupName, webSiteName, slotName, deleteMetrics: deleteMetricsBydefault.ToString(), deleteEmptyServerFarm: deleteEmptyServerFarmBydefault.ToString(), deleteAllSlots: deleteSlotsBydefault.ToString());
            }
            else
            {
                WrappedWebsitesClient.Sites.DeleteSite(resourceGroupName, webSiteName, deleteMetrics: deleteMetricsBydefault.ToString(), deleteEmptyServerFarm: deleteEmptyServerFarmBydefault.ToString(), deleteAllSlots: deleteSlotsBydefault.ToString());
            }

            return HttpStatusCode.OK;
        }

        public Site GetWebApp(string resourceGroupName, string webSiteName, string slotName)
        {
            Site site = null; 
            string qualifiedSiteName;
            
            site = ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName) ? WrappedWebsitesClient.Sites.GetSiteSlot(resourceGroupName, webSiteName, slotName) : WrappedWebsitesClient.Sites.GetSite(resourceGroupName, webSiteName);

            GetWebAppConfiguration(resourceGroupName, webSiteName, slotName, site);

            return site;
        }

        public IList<Site> ListWebApps(string resourceGroupName, string webSiteName)
        {
            SiteCollection sites = null;
            sites = !string.IsNullOrWhiteSpace(webSiteName) ? WrappedWebsitesClient.Sites.GetSiteSlots(resourceGroupName, webSiteName) : WrappedWebsitesClient.Sites.GetSites(resourceGroupName);

            return sites.Value;
        }

        public IList<Site> ListWebAppsForAppServicePlan(string resourceGroupName, string appServicePlanName)
        {
            return WrappedWebsitesClient.ServerFarms.GetServerFarmSites(resourceGroupName, appServicePlanName).Value;
        }

        public string GetWebAppPublishingProfile(string resourceGroupName, string webSiteName, string slotName, string outputFile, string format)
        {
            string qualifiedSiteName;
            var options = new CsmPublishingProfileOptions
            {
                Format = format
            };

            var publishingXml = (ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName) ? WrappedWebsitesClient.Sites.ListSitePublishingProfileXmlSlot(resourceGroupName, webSiteName, options, slotName) : WrappedWebsitesClient.Sites.ListSitePublishingProfileXml(resourceGroupName, webSiteName, options));
             var doc = XDocument.Load(publishingXml, LoadOptions.None);
             doc.Save(outputFile, SaveOptions.OmitDuplicateNamespaces);
            return doc.ToString();
        }

        public HttpStatusCode ResetWebAppPublishingCredentials(string resourceGroupName, string webSiteName, string slotName)
        {
            string qualifiedSiteName;
            if(ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName))
            {
                WrappedWebsitesClient.Sites.GenerateNewSitePublishingPasswordSlot(resourceGroupName, webSiteName,
                    slotName);
            }
            else
            {
                WrappedWebsitesClient.Sites.GenerateNewSitePublishingPassword(resourceGroupName, webSiteName);
            }

            return HttpStatusCode.OK;
        }

        public ResourceMetricCollection GetWebAppUsageMetrics(string resourceGroupName, string webSiteName, string slotName, IReadOnlyList<string> metricNames,
    DateTime? startTime, DateTime? endTime, string timeGrain, bool instanceDetails)
        {
            string qualifiedSiteName;
            var usageMetrics = ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName) ?
                WrappedWebsitesClient.Sites.GetSiteMetricsSlot(resourceGroupName, webSiteName, slotName, instanceDetails, BuildMetricFilter(startTime, endTime ?? DateTime.Now, timeGrain, metricNames)) :
                WrappedWebsitesClient.Sites.GetSiteMetrics(resourceGroupName, webSiteName, instanceDetails, BuildMetricFilter(startTime, endTime ?? DateTime.Now, timeGrain, metricNames));
            return usageMetrics;
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

        public ServerFarmCollection ListAppServicePlans(string resourceGroupName)
        {
            return WrappedWebsitesClient.ServerFarms.GetServerFarms(resourceGroupName);
        }

        public ResourceMetricCollection GetAppServicePlanHistoricalUsageMetrics(string resourceGroupName, string appServicePlanName, IReadOnlyList<string> metricNames,
    DateTime? startTime, DateTime? endTime, string timeGrain, bool instanceDetails)
        {
            var response = WrappedWebsitesClient.ServerFarms.GetServerFarmMetrics(resourceGroupName, appServicePlanName, instanceDetails, BuildMetricFilter(startTime, endTime, timeGrain, metricNames));
            return response;
        }

        public void UpdateWebAppConfiguration(string resourceGroupName, string webSiteName, string slotName, SiteConfig siteConfig, IDictionary<string, string> appSettings = null, IDictionary<string, ConnStringValueTypePair> connectionStrings = null)
        {
            string qualifiedSiteName;
            var useSlot = ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName);

            if (useSlot)
            {
                WrappedWebsitesClient.Sites.UpdateSiteConfigSlot(resourceGroupName, webSiteName, siteConfig,
                    slotName);
                if (appSettings != null)
                {
                    WrappedWebsitesClient.Sites.UpdateSiteAppSettingsSlot(resourceGroupName, webSiteName, new StringDictionary {Properties = appSettings}, slotName);
                }

                if (connectionStrings != null)
                {
                    WrappedWebsitesClient.Sites.UpdateSiteConnectionStringsSlot(resourceGroupName, webSiteName, new ConnectionStringDictionary { Properties = connectionStrings }, slotName);
                }
            }
            else
            {
                WrappedWebsitesClient.Sites.UpdateSiteConfig(resourceGroupName, webSiteName, siteConfig);
                if (appSettings != null)
                {
                    WrappedWebsitesClient.Sites.UpdateSiteAppSettings(resourceGroupName, webSiteName, new StringDictionary { Properties = appSettings });
                }

                if (connectionStrings != null)
                {
                    WrappedWebsitesClient.Sites.UpdateSiteConnectionStrings(resourceGroupName, webSiteName, new ConnectionStringDictionary { Properties = connectionStrings });
                }
            }
        }

        private void GetWebAppConfiguration(string resourceGroupName, string webSiteName, string slotName, Site site)
        {
            string qualifiedSiteName;
            var useSlot = ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName);
            site.SiteConfig = useSlot ? WrappedWebsitesClient.Sites.GetSiteConfigSlot(resourceGroupName, webSiteName, slotName) : WrappedWebsitesClient.Sites.GetSiteConfig(resourceGroupName, webSiteName);
            try
            {
                var appSettings = useSlot ? WrappedWebsitesClient.Sites.ListSiteAppSettingsSlot(resourceGroupName, webSiteName, slotName) : WrappedWebsitesClient.Sites.ListSiteAppSettings(resourceGroupName, webSiteName);
                
                site.SiteConfig.AppSettings = appSettings.Properties.Select(s => new NameValuePair{ Name = s.Key, Value = s.Value}).ToList();

                var connectionStrings = useSlot ? WrappedWebsitesClient.Sites.ListSiteConnectionStringsSlot(resourceGroupName, webSiteName, slotName) : WrappedWebsitesClient.Sites.ListSiteConnectionStrings(resourceGroupName, webSiteName);

                site.SiteConfig.ConnectionStrings = connectionStrings.Properties.Select(s => new ConnStringInfo() { Name = s.Key, ConnectionString = s.Value.Value, Type = s.Value.Type }).ToList();
            }
            catch
            {
                //ignore if this call fails as it will for reader RBAC
            }
        }

        private bool ShouldUseDeploymentSlot(string webSiteName, string slotName, out string qualifiedSiteName)
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

            if (!string.IsNullOrWhiteSpace(timeGrain))
            {
                filter += string.Format("and timeGrain eq duration'{0}'", timeGrain);
            }

            return filter;
        }

        internal static bool TryParseWebAppMetadataFromResourceId(string resourceId, out string resourceGroupName,
            out string webAppName, out string slotName)
        {
            var match = WebAppSlotResourceIdRegex.Match(resourceId);
            if (match.Success)
            {
                resourceGroupName = match.Groups["resourceGroupName"].Value;
                webAppName = match.Groups["siteName"].Value;
                slotName = match.Groups["slotName"].Value;

                return true;
            }

            match = WebAppResourceIdRegex.Match(resourceId);
            if (match.Success)
            {
                resourceGroupName = match.Groups["resourceGroupName"].Value;
                webAppName = match.Groups["siteName"].Value;
                slotName = null;

                return true;
            }

            resourceGroupName = null;
            webAppName = null;
            slotName = null;

            return false;
        }

        internal static bool TryParseAppServicePlanMetadataFromResourceId(string resourceId, out string resourceGroupName,
            out string appServicePlanName)
        {
            var match = AppServicePlanResourceIdRegex.Match(resourceId);
            if (match.Success)
            {
                resourceGroupName = match.Groups["resourceGroupName"].Value;
                appServicePlanName = match.Groups["serverFarmName"].Value;

                return true;
            }

            resourceGroupName = null;
            appServicePlanName = null;

            return false;
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

        internal static bool IsDeploymentSlot(string name)
        {
            return AppWithSlotNameRegex.IsMatch(name);
        }

        internal static bool TryParseAppAndSlotNames(string name, out string webAppName, out string slotName)
        {
            var match = AppWithSlotNameRegex.Match(name);
            if (match.Success)
            {
                webAppName = match.Groups["siteName"].Value;
                slotName = match.Groups["slotName"].Value;
                return true;
            }

            webAppName = name;
            slotName = null;
            
            return false;
        }

        private void WriteVerbose(string verboseFormat, params object[] args)
        {
            if (VerboseLogger != null)
            {
                VerboseLogger(string.Format(verboseFormat, args));
            }
        }

        private void WriteWarning(string warningFormat, params object[] args)
        {
            if (WarningLogger != null)
            {
                WarningLogger(string.Format(warningFormat, args));
            }
        }

        private void WriteError(string errorFormat, params object[] args)
        {
            if (ErrorLogger != null)
            {
                ErrorLogger(string.Format(errorFormat, args));
            }
        }
    }
}
