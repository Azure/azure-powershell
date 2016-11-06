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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Management.WebSites;
using Microsoft.Azure.Management.WebSites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace Microsoft.Azure.Commands.WebApps.Utilities
{
    public class WebsitesClient
    {
        // Azure SDK requires a request parameter to be specified for a few Backup API calls, but
        // the request is actually optional unless an update is needed
        private static readonly BackupRequest EmptyRequest = new BackupRequest(location: "");

        public Action<string> VerboseLogger { get; set; }

        public Action<string> ErrorLogger { get; set; }

        public Action<string> WarningLogger { get; set; }

        public WebsitesClient(AzureContext context)
        {
            this.WrappedWebsitesClient = AzureSession.ClientFactory.CreateArmClient<WebSiteManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);

        }
        public WebSiteManagementClient WrappedWebsitesClient
        {
            get;
            private set;
        }

        public Site CreateWebApp(string resourceGroupName, string webAppName, string slotName, string location, string serverFarmId, CloningInfo cloningInfo, string aseName, string aseResourceGroupName)
        {
            Site createdWebSite = null;
            string qualifiedSiteName;
            var profile = CreateHostingEnvironmentProfile(resourceGroupName, aseResourceGroupName, aseName);

            if (CmdletHelpers.ShouldUseDeploymentSlot(webAppName, slotName, out qualifiedSiteName))
            {
                createdWebSite = WrappedWebsitesClient.Sites.CreateOrUpdateSiteSlot(
                        resourceGroupName, webAppName, slot: slotName, siteEnvelope:
                        new Site
                        {
                            SiteName = qualifiedSiteName,
                            Location = location,
                            ServerFarmId = serverFarmId,
                            CloningInfo = cloningInfo,
                            HostingEnvironmentProfile = profile
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
                            ServerFarmId = serverFarmId,
                            CloningInfo = cloningInfo,
                            HostingEnvironmentProfile = profile
                        });
            }



            GetWebAppConfiguration(resourceGroupName, webAppName, slotName, createdWebSite);
            return createdWebSite;
        }

        public HostingEnvironmentProfile CreateHostingEnvironmentProfile(string resourceGroupName, string aseResourceGroupName, string aseName)
        {
            if (string.IsNullOrEmpty(aseName))
            {
                return null;
            }

            return CmdletHelpers.CreateHostingEnvironmentProfile(WrappedWebsitesClient.SubscriptionId, resourceGroupName, aseResourceGroupName, aseName);
        }

        public void UpdateWebApp(string resourceGroupName, string location, string webAppName, string slotName, string appServicePlan)
        {
            var webSiteToUpdate = new Site()
            {
                ServerFarmId = appServicePlan,
                Location = location
            };

            string qualifiedSiteName;
            if (CmdletHelpers.ShouldUseDeploymentSlot(webAppName, slotName, out qualifiedSiteName))
            {
                WrappedWebsitesClient.Sites.CreateOrUpdateSiteSlot(resourceGroupName, webAppName, webSiteToUpdate, slotName);
            }
            else
            {
                webSiteToUpdate = WrappedWebsitesClient.Sites.CreateOrUpdateSite(resourceGroupName, webAppName, webSiteToUpdate);
            }
        }

        public void AddCustomHostNames(string resourceGroupName, string location, string webAppName, string[] hostNames)
        {
            var webApp = WrappedWebsitesClient.Sites.GetSite(resourceGroupName, webAppName);
            var currentHostNames = webApp.HostNames;

            // Add new hostnames
            foreach (var hostName in hostNames)
            {
                try
                {
                    if (!currentHostNames.Contains(hostName, StringComparer.OrdinalIgnoreCase))
                    {
                        WrappedWebsitesClient.Sites.CreateOrUpdateSiteHostNameBinding(resourceGroupName, webAppName,
                            hostName, new HostNameBinding
                            {
                                Location = location,
                                SiteName = webAppName,
                                HostNameBindingName = hostName
                            });
                    }
                }
                catch (Exception e)
                {
                    WriteWarning("Could not set custom hostname '{0}'. Details: {1}", hostName, e.ToString());
                }
            }

            // Delete removed hostnames
            foreach (var hostName in currentHostNames)
            {
                try
                {
                    if (!hostNames.Contains(hostName, StringComparer.OrdinalIgnoreCase))
                    {
                        WrappedWebsitesClient.Sites.DeleteSiteHostNameBinding(resourceGroupName, webAppName, hostName);
                    }
                }
                catch (Exception e)
                {
                    WriteWarning("Could not remove custom hostname '{0}'. Details: {1}", hostName, e.ToString());
                }
            }
        }

        public void StartWebApp(string resourceGroupName, string webSiteName, string slotName)
        {
            string qualifiedSiteName;
            if (CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName))
            {
                WrappedWebsitesClient.Sites.StartSiteSlot(resourceGroupName, webSiteName, slotName);
            }
            else
            {
                WrappedWebsitesClient.Sites.StartSite(resourceGroupName, webSiteName);
            }
        }
        public void StopWebApp(string resourceGroupName, string webSiteName, string slotName)
        {
            string qualifiedSiteName;
            if (CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName))
            {
                WrappedWebsitesClient.Sites.StopSiteSlot(resourceGroupName, webSiteName, slotName);
            }
            else
            {
                WrappedWebsitesClient.Sites.StopSite(resourceGroupName, webSiteName);
            }
        }
        public void RestartWebApp(string resourceGroupName, string webSiteName, string slotName)
        {
            string qualifiedSiteName;
            if (CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName))
            {
                WrappedWebsitesClient.Sites.RestartSiteSlot(resourceGroupName, webSiteName, slotName);
            }
            else
            {
                WrappedWebsitesClient.Sites.RestartSite(resourceGroupName, webSiteName);
            }
        }

        public HttpStatusCode RemoveWebApp(string resourceGroupName, string webSiteName, string slotName, bool deleteEmptyServerFarmBydefault, bool deleteMetricsBydefault, bool deleteSlotsBydefault)
        {
            string qualifiedSiteName;
            if (CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName))
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

            site = CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName) ? WrappedWebsitesClient.Sites.GetSiteSlot(resourceGroupName, webSiteName, slotName) : WrappedWebsitesClient.Sites.GetSite(resourceGroupName, webSiteName);

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
            return WrappedWebsitesClient.ServerFarms.GetServerFarmSites(resourceGroupName, appServicePlanName).ToList();
        }

        public string GetWebAppPublishingProfile(string resourceGroupName, string webSiteName, string slotName, string outputFile, string format)
        {
            string qualifiedSiteName;
            var options = new CsmPublishingProfileOptions
            {
                Format = format
            };

            var publishingXml = (CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName) ? WrappedWebsitesClient.Sites.ListSitePublishingProfileXmlSlot(resourceGroupName, webSiteName, options, slotName) : WrappedWebsitesClient.Sites.ListSitePublishingProfileXml(resourceGroupName, webSiteName, options));
            var doc = XDocument.Load(publishingXml, LoadOptions.None);
            doc.Save(outputFile, SaveOptions.OmitDuplicateNamespaces);
            return doc.ToString();
        }

        public string ResetWebAppPublishingCredentials(string resourceGroupName, string webSiteName, string slotName)
        {
            string qualifiedSiteName;
            if (CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName))
            {
                WrappedWebsitesClient.Sites.GenerateNewSitePublishingPasswordSlot(resourceGroupName, webSiteName,
                    slotName);
            }
            else
            {
                WrappedWebsitesClient.Sites.GenerateNewSitePublishingPassword(resourceGroupName, webSiteName);
            }

            var options = new CsmPublishingProfileOptions
            {
                Format = "WebDeploy"
            };

            var publishingXml = (CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName) ? WrappedWebsitesClient.Sites.ListSitePublishingProfileXmlSlot(resourceGroupName, webSiteName, options, slotName) : WrappedWebsitesClient.Sites.ListSitePublishingProfileXml(resourceGroupName, webSiteName, options));
            var doc = XDocument.Load(publishingXml, LoadOptions.None);
            var profile = doc.Root == null ? null : doc.Root.Element("publishData") == null ? null : doc.Root.Element("publishData").Elements("publishProfile")
                .Single(p => p.Attribute("publishMethod").Value == "MSDeploy");
            return profile == null ? null : profile.Attribute("userPWD").Value;
        }

        public IList<ResourceMetric> GetWebAppUsageMetrics(string resourceGroupName, string webSiteName, string slotName, IReadOnlyList<string> metricNames,
    DateTime? startTime, DateTime? endTime, string timeGrain, bool instanceDetails)
        {
            string qualifiedSiteName;
            var usageMetrics = CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName) ?
                WrappedWebsitesClient.Sites.GetSiteMetricsSlot(resourceGroupName, webSiteName, slotName, instanceDetails, CmdletHelpers.BuildMetricFilter(startTime, endTime ?? DateTime.Now, timeGrain, metricNames)) :
                WrappedWebsitesClient.Sites.GetSiteMetrics(resourceGroupName, webSiteName, instanceDetails, CmdletHelpers.BuildMetricFilter(startTime, endTime ?? DateTime.Now, timeGrain, metricNames));
            return usageMetrics.Value;
        }

        public ServerFarmWithRichSku CreateAppServicePlan(string resourceGroupName, string appServicePlanName, string location, string adminSiteName, SkuDescription sku, string aseName = null, string aseResourceGroupName = null)
        {
            var serverFarm = new ServerFarmWithRichSku
            {
                Location = location,
                ServerFarmWithRichSkuName = appServicePlanName,
                Sku = sku,
                AdminSiteName = adminSiteName
            };

            if (!string.IsNullOrEmpty(aseName)
                && !string.IsNullOrEmpty(aseResourceGroupName))
            {
                serverFarm.HostingEnvironmentProfile = new HostingEnvironmentProfile
                {
                    Id = CmdletHelpers.GetApplicationServiceEnvironmentResourceId(WrappedWebsitesClient.SubscriptionId, aseResourceGroupName, aseName),
                    Type = CmdletHelpers.ApplicationServiceEnvironmentResourcesName,
                    Name = aseName
                };
            }

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

        public IList<ResourceMetric> GetAppServicePlanHistoricalUsageMetrics(string resourceGroupName, string appServicePlanName, IReadOnlyList<string> metricNames,
    DateTime? startTime, DateTime? endTime, string timeGrain, bool instanceDetails)
        {
            var response = WrappedWebsitesClient.ServerFarms.GetServerFarmMetrics(resourceGroupName, appServicePlanName, instanceDetails, CmdletHelpers.BuildMetricFilter(startTime, endTime, timeGrain, metricNames));
            return response.Value;
        }

        public void UpdateWebAppConfiguration(string resourceGroupName, string location, string webSiteName, string slotName, SiteConfig siteConfig = null, IDictionary<string, string> appSettings = null, IDictionary<string, ConnStringValueTypePair> connectionStrings = null)
        {
            string qualifiedSiteName;
            var useSlot = CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName);

            if (useSlot)
            {
                if (siteConfig != null)
                {
                    WrappedWebsitesClient.Sites.UpdateSiteConfigSlot(resourceGroupName, webSiteName, siteConfig,
                   slotName);
                }

                if (appSettings != null)
                {
                    WrappedWebsitesClient.Sites.UpdateSiteAppSettingsSlot(resourceGroupName, webSiteName, new StringDictionary { Location = location, Properties = appSettings }, slotName);
                }

                if (connectionStrings != null)
                {
                    WrappedWebsitesClient.Sites.UpdateSiteConnectionStringsSlot(resourceGroupName, webSiteName, new ConnectionStringDictionary { Location = location, Properties = connectionStrings }, slotName);
                }
            }
            else
            {
                if (siteConfig != null)
                {
                    WrappedWebsitesClient.Sites.UpdateSiteConfig(resourceGroupName, webSiteName, siteConfig);
                }

                if (appSettings != null)
                {
                    WrappedWebsitesClient.Sites.UpdateSiteAppSettings(resourceGroupName, webSiteName, new StringDictionary { Location = location, Properties = appSettings });
                }

                if (connectionStrings != null)
                {
                    WrappedWebsitesClient.Sites.UpdateSiteConnectionStrings(resourceGroupName, webSiteName, new ConnectionStringDictionary { Location = location, Properties = connectionStrings });
                }
            }
        }

        private void GetWebAppConfiguration(string resourceGroupName, string webSiteName, string slotName, Site site)
        {
            string qualifiedSiteName;
            var useSlot = CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName);
            site.SiteConfig = useSlot ? WrappedWebsitesClient.Sites.GetSiteConfigSlot(resourceGroupName, webSiteName, slotName) : WrappedWebsitesClient.Sites.GetSiteConfig(resourceGroupName, webSiteName);
            try
            {
                var appSettings = useSlot ? WrappedWebsitesClient.Sites.ListSiteAppSettingsSlot(resourceGroupName, webSiteName, slotName) : WrappedWebsitesClient.Sites.ListSiteAppSettings(resourceGroupName, webSiteName);

                site.SiteConfig.AppSettings = appSettings.Properties.Select(s => new NameValuePair { Name = s.Key, Value = s.Value }).ToList();

                var connectionStrings = useSlot ? WrappedWebsitesClient.Sites.ListSiteConnectionStringsSlot(resourceGroupName, webSiteName, slotName) : WrappedWebsitesClient.Sites.ListSiteConnectionStrings(resourceGroupName, webSiteName);

                site.SiteConfig.ConnectionStrings = connectionStrings.Properties.Select(s => new ConnStringInfo() { Name = s.Key, ConnectionString = s.Value.Value, Type = s.Value.Type }).ToList();
            }
            catch
            {
                //ignore if this call fails as it will for reader RBAC
            }
        }

        public BackupRequest GetWebAppBackupConfiguration(string resourceGroupName, string webSiteName, string slotName)
        {
            string qualifiedSiteName;
            var useSlot = CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName);
            if (useSlot)
            {
                return WrappedWebsitesClient.Sites.GetSiteBackupConfigurationSlot(resourceGroupName, webSiteName, slotName);
            }
            else
            {
                return WrappedWebsitesClient.Sites.GetSiteBackupConfiguration(resourceGroupName,
                    webSiteName);
            }
        }

        public BackupRequest UpdateWebAppBackupConfiguration(string resourceGroupName, string webSiteName,
            string slotName, BackupRequest newSchedule)
        {
            string qualifiedSiteName;
            var useSlot = CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName);
            if (useSlot)
            {
                return WrappedWebsitesClient.Sites.UpdateSiteBackupConfigurationSlot(resourceGroupName,
                    webSiteName, newSchedule, slotName);
            }
            else
            {
                return WrappedWebsitesClient.Sites.UpdateSiteBackupConfiguration(resourceGroupName, webSiteName, newSchedule);
            }
        }

        public BackupItem BackupSite(string resourceGroupName, string webSiteName, string slotName,
            BackupRequest request)
        {
            string qualifiedSiteName;
            var useSlot = CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName);
            if (useSlot)
            {
                var backup = WrappedWebsitesClient.Sites.BackupSiteSlot(resourceGroupName, webSiteName, request, slotName);
                return backup;
            }
            else
            {
                var backup = WrappedWebsitesClient.Sites.BackupSite(resourceGroupName, webSiteName, request);
                return backup;
            }
        }

        public BackupItemCollection ListSiteBackups(string resourceGroupName, string webSiteName, string slotName)
        {
            string qualifiedSiteName;
            var useSlot = CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName);
            if (useSlot)
            {
                return WrappedWebsitesClient.Sites.ListSiteBackupsSlot(resourceGroupName, webSiteName, slotName);
            }
            else
            {
                return WrappedWebsitesClient.Sites.ListSiteBackups(resourceGroupName, webSiteName);
            }
        }

        public BackupItem GetSiteBackupStatus(string resourceGroupName, string webSiteName, string slotName, string backupId)
        {
            string qualifiedSiteName;
            var useSlot = CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName);
            if (useSlot)
            {
                return WrappedWebsitesClient.Sites.GetSiteBackupStatusSecretsSlot(resourceGroupName, webSiteName, backupId, EmptyRequest, slotName);
            }
            else
            {
                return WrappedWebsitesClient.Sites.GetSiteBackupStatusSecrets(resourceGroupName, webSiteName, backupId,
                    EmptyRequest);
            }
        }

        public BackupItem GetSiteBackupStatusSecrets(string resourceGroupName, string webSiteName, string slotName,
            string backupId, BackupRequest request = null)
        {
            string qualifiedSiteName;
            var useSlot = CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName);
            if (useSlot)
            {
                return WrappedWebsitesClient.Sites.GetSiteBackupStatusSecretsSlot(resourceGroupName, webSiteName,
                    backupId, request, slotName);
            }
            else
            {
                return WrappedWebsitesClient.Sites.GetSiteBackupStatusSecrets(resourceGroupName, webSiteName, backupId, request);
            }
        }

        public BackupItem DeleteBackup(string resourceGroupName, string webSiteName, string slotName,
            string backupId)
        {
            string qualifiedSiteName;
            var useSlot = CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName);
            if (useSlot)
            {
                return WrappedWebsitesClient.Sites.DeleteBackupSlot(resourceGroupName, webSiteName, backupId, slotName);
            }
            else
            {
                return WrappedWebsitesClient.Sites.DeleteBackup(resourceGroupName, webSiteName, backupId);
            }
        }

        public RestoreResponse RestoreSite(string resourceGroupName, string webSiteName, string slotName,
            string backupId, RestoreRequest request)
        {
            string qualifiedSiteName;
            var useSlot = CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName);
            if (useSlot)
            {
                return WrappedWebsitesClient.Sites.RestoreSiteSlot(resourceGroupName, webSiteName, backupId, request, slotName);
            }
            else
            {
                return WrappedWebsitesClient.Sites.RestoreSite(resourceGroupName, webSiteName, backupId, request);
            }
        }

        public void RecoverSite(string resourceGroupName, string webSiteName, string slotName,
            CsmSiteRecoveryEntity recoveryEntity)
        {
            string qualifiedSiteName;
            bool useSlot = CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName);
            if (useSlot)
            {
                WrappedWebsitesClient.Sites.RecoverSiteSlot(resourceGroupName, webSiteName, recoveryEntity, slotName);
            }
            else
            {
                WrappedWebsitesClient.Sites.RecoverSite(resourceGroupName, webSiteName, recoveryEntity);
            }
        }

        public Certificate CreateCertificate(string resourceGroupName, string certificateName, Certificate certificate)
        {
            return WrappedWebsitesClient.Certificates.CreateOrUpdateCertificate(resourceGroupName, certificateName, certificate);
        }

        public Certificate GetCertificate(string resourceGroupName, string certificateName)
        {
            return WrappedWebsitesClient.Certificates.GetCertificate(resourceGroupName, certificateName);
        }

        public HttpStatusCode RemoveCertificate(string resourceGroupName, string certificateName)
        {
            WrappedWebsitesClient.Certificates.DeleteCertificate(resourceGroupName, certificateName);
            return HttpStatusCode.OK;
        }

        public Site UpdateHostNameSslState(string resourceGroupName, string webAppName, string slotName, string location, string hostName, SslState sslState, string thumbPrint)
        {
            Site updateWebSite;
            string qualifiedSiteName;

            var shouldUseDeploymentSlot = CmdletHelpers.ShouldUseDeploymentSlot(webAppName, slotName, out qualifiedSiteName);

            var webappWithNewSslBinding = new Site
            {
                HostNameSslStates = new List<HostNameSslState>{new HostNameSslState
                {
                    Name = hostName,
                    Thumbprint = thumbPrint,
                    ToUpdate = true,
                    SslState = sslState
                }},
                Location = location
            };

            if (shouldUseDeploymentSlot)
            {
                updateWebSite = WrappedWebsitesClient.Sites.CreateOrUpdateSiteSlot(
                        resourceGroupName, webAppName, slot: slotName, siteEnvelope:
                        webappWithNewSslBinding);
            }
            else
            {
                updateWebSite = WrappedWebsitesClient.Sites.CreateOrUpdateSite(
                        resourceGroupName, webAppName, siteEnvelope:
                        webappWithNewSslBinding);
            }
            return updateWebSite;
        }

        public SlotConfigNamesResource GetSlotConfigNames(string resourceGroupName, string webSiteName)
        {
            return WrappedWebsitesClient.Sites.GetSlotConfigNames(resourceGroupName, webSiteName);
        }

        public SlotConfigNamesResource SetSlotConfigNames(string resourceGroupName, string webSiteName, IList<string> appSettingNames, IList<string> connectionStringNames)
        {
            var slotConfigNames = GetSlotConfigNames(resourceGroupName, webSiteName);
            if(appSettingNames != null)
            {
                slotConfigNames.AppSettingNames = appSettingNames;
            }

            if(connectionStringNames != null)
            {
                slotConfigNames.ConnectionStringNames = connectionStringNames;
            }

            return WrappedWebsitesClient.Sites.UpdateSlotConfigNames(resourceGroupName, webSiteName, slotConfigNames);
        }

        public void SwapSlot(string resourceGroupName, string webSiteName, string sourceSlotName, string destinationSlotName, bool? preserveVnet)
        {
            var csmSlotEntity = new CsmSlotEntity { TargetSlot = destinationSlotName, PreserveVnet = preserveVnet };

            WrappedWebsitesClient.Sites.SwapSlotsSlot(
                resourceGroupName,
                webSiteName,
                csmSlotEntity,
                sourceSlotName);
        }

        public void SwapSlotWithPreviewApplySlotConfig(string resourceGroupName, string webSiteName, string sourceSlotName, string destinationSlotName, bool? preserveVnet)
        {
            var csmSlotEntity = new CsmSlotEntity { TargetSlot = destinationSlotName, PreserveVnet = preserveVnet };

            WrappedWebsitesClient.Sites.ApplySlotConfigSlot(
                resourceGroupName,
                webSiteName,
                csmSlotEntity,
                sourceSlotName);
        }

        public void SwapSlotWithPreviewResetSlotSwap(string resourceGroupName, string webSiteName, string sourceSlotName)
        {
            WrappedWebsitesClient.Sites.ResetSlotConfigSlot(
                resourceGroupName,
                webSiteName,
                sourceSlotName);
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
