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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Management.WebSites;
using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Microsoft.Azure.Commands.WebApps.Utilities
{
    public class WebsitesClient
    {
        // Azure SDK requires a request parameter to be specified for a few Backup API calls, but
        // the request is actually optional unless an update is needed
        private static readonly BackupRequest EmptyRequest = new BackupRequest();

        public Action<string> VerboseLogger { get; set; }

        public Action<string> ErrorLogger { get; set; }

        public Action<string> WarningLogger { get; set; }

        public WebsitesClient(IAzureContext context)
        {
            this.WrappedWebsitesClient = AzureSession.Instance.ClientFactory.CreateArmClient<WebSiteManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);

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
                createdWebSite = WrappedWebsitesClient.WebApps.CreateOrUpdateSlot(
                        resourceGroupName, webAppName, slot: slotName, siteEnvelope:
                        new Site
                        {
                            Location = location,
                            ServerFarmId = serverFarmId,
                            CloningInfo = cloningInfo,
                            HostingEnvironmentProfile = profile
                        });
            }
            else
            {
                createdWebSite = WrappedWebsitesClient.WebApps().CreateOrUpdate(
                        resourceGroupName, webAppName, siteEnvelope:
                        new Site
                        {
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

        public void UpdateWebApp(string resourceGroupName, string location, string webAppName, string slotName, string appServicePlan, Site siteEnvelope =null)
        {
            var webSiteToUpdate = new Site()
            {
                ServerFarmId = appServicePlan,
                Location = location,
                Tags = siteEnvelope?.Tags
            };

            if (siteEnvelope!=null)
            {
                webSiteToUpdate = siteEnvelope;
            }

            string qualifiedSiteName;
            if (CmdletHelpers.ShouldUseDeploymentSlot(webAppName, slotName, out qualifiedSiteName))
            {
                WrappedWebsitesClient.WebApps().CreateOrUpdateSlot(resourceGroupName, webAppName, webSiteToUpdate, slotName);
            }
            else
            {
                webSiteToUpdate = WrappedWebsitesClient.WebApps().CreateOrUpdate(resourceGroupName, webAppName, webSiteToUpdate);
            }
        }

        public void AddCustomHostNames(string resourceGroupName, string location, string webAppName, string[] hostNames)
        {
            var webApp = WrappedWebsitesClient.WebApps().Get(resourceGroupName, webAppName);
            var currentHostNames = webApp.HostNames;

            // Add new hostnames
            foreach (var hostName in hostNames)
            {
                try
                {
                    if (!currentHostNames.Contains(hostName, StringComparer.OrdinalIgnoreCase))
                    {
                        WrappedWebsitesClient.WebApps().CreateOrUpdateHostNameBinding(resourceGroupName, webAppName,
                            hostName, new HostNameBinding
                            {
                                SiteName = webAppName,
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
                        WrappedWebsitesClient.WebApps().DeleteHostNameBinding(resourceGroupName, webAppName, hostName);
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
                WrappedWebsitesClient.WebApps().StartSlot(resourceGroupName, webSiteName, slotName);
            }
            else
            {
                WrappedWebsitesClient.WebApps().Start(resourceGroupName, webSiteName);
            }
        }
        public void StopWebApp(string resourceGroupName, string webSiteName, string slotName)
        {
            string qualifiedSiteName;
            if (CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName))
            {
                WrappedWebsitesClient.WebApps().StopSlot(resourceGroupName, webSiteName, slotName);
            }
            else
            {
                WrappedWebsitesClient.WebApps().Stop(resourceGroupName, webSiteName);
            }
        }
        public void RestartWebApp(string resourceGroupName, string webSiteName, string slotName)
        {
            string qualifiedSiteName;
            if (CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName))
            {
                WrappedWebsitesClient.WebApps().RestartSlot(resourceGroupName, webSiteName, slotName);
            }
            else
            {
                WrappedWebsitesClient.WebApps().Restart(resourceGroupName, webSiteName);
            }
        }

        public HttpStatusCode RemoveWebApp(string resourceGroupName, string webSiteName, string slotName, bool deleteEmptyServerFarmBydefault, bool deleteMetricsBydefault, bool deleteSlotsBydefault)
        {
            string qualifiedSiteName;
            if (CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName))
            {
                WrappedWebsitesClient.WebApps().DeleteSlot(resourceGroupName, webSiteName, slotName, deleteMetrics: deleteMetricsBydefault, deleteEmptyServerFarm: deleteEmptyServerFarmBydefault);
            }
            else
            {
                WrappedWebsitesClient.WebApps().Delete(resourceGroupName, webSiteName, deleteMetrics: deleteMetricsBydefault, deleteEmptyServerFarm: deleteEmptyServerFarmBydefault);
            }

            return HttpStatusCode.OK;
        }

        public Site GetWebApp(string resourceGroupName, string webSiteName, string slotName)
        {
            Site site = null;
            string qualifiedSiteName;

            site = CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName) ?
                WrappedWebsitesClient.WebApps().GetSlot(resourceGroupName, webSiteName, slotName) :
                WrappedWebsitesClient.WebApps().Get(resourceGroupName, webSiteName);

            GetWebAppConfiguration(resourceGroupName, webSiteName, slotName, site);

            return site;
        }

        public bool WebAppExists(string resourceGroupName, string webSiteName, string slotName)
        {
            Site site = null;
            string qualifiedSiteName;

            site = CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName) ?
                WrappedWebsitesClient.WebApps().GetSlot(resourceGroupName, webSiteName, slotName) :
                WrappedWebsitesClient.WebApps().Get(resourceGroupName, webSiteName);

            return site != null;
        }

        public IEnumerable<Site> ListWebApps(string resourceGroupName, string webSiteName)
        {
            var sites = !string.IsNullOrWhiteSpace(webSiteName) ?
                WrappedWebsitesClient.WebApps().ListSlots(resourceGroupName, webSiteName) :
                WrappedWebsitesClient.WebApps().ListByResourceGroup(resourceGroupName);
            return sites;
        }

        public IList<Site> ListWebAppsForAppServicePlan(string resourceGroupName, string appServicePlanName)
        {
            return WrappedWebsitesClient.AppServicePlans().ListWebApps(resourceGroupName, appServicePlanName).ToList();
        }

        public string GetWebAppPublishingProfile(string resourceGroupName, string webSiteName, string slotName, string outputFile, string format, bool? includeDRTEndpoint)
        {
            string qualifiedSiteName;
            var options = new CsmPublishingProfileOptions
            {
                Format = format,
                IncludeDisasterRecoveryEndpoints = includeDRTEndpoint
            };

            var publishingXml = (CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName) ? 
                WrappedWebsitesClient.WebApps().ListPublishingProfileXmlWithSecretsSlot(resourceGroupName, webSiteName, options, slotName) : 
                WrappedWebsitesClient.WebApps().ListPublishingProfileXmlWithSecrets(resourceGroupName, webSiteName, options));
            var doc = XDocument.Load(publishingXml, LoadOptions.None);
            if (outputFile != null)
            {
                doc.Save(outputFile, SaveOptions.OmitDuplicateNamespaces);
            }
            return doc.ToString();
        }

        public User GetPublishingCredentials(string resourceGroupName, string webSiteName, string slotName = null)
        {
            string qualifiedSiteName;
            return CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName) ?
               WrappedWebsitesClient.WebApps().ListPublishingCredentialsSlot(resourceGroupName, webSiteName, slotName)
               : WrappedWebsitesClient.WebApps().ListPublishingCredentials(resourceGroupName, webSiteName);
        }

        public string ResetWebAppPublishingCredentials(string resourceGroupName, string webSiteName, string slotName)
        {
            string qualifiedSiteName;
            if (CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName))
            {
                WrappedWebsitesClient.WebApps().GenerateNewSitePublishingPasswordSlot(resourceGroupName, webSiteName,
                    slotName);
            }
            else
            {
                WrappedWebsitesClient.WebApps().GenerateNewSitePublishingPassword(resourceGroupName, webSiteName);
            }

            var options = new CsmPublishingProfileOptions
            {
                Format = "WebDeploy"
            };

            var publishingXml = (CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName) ? 
                WrappedWebsitesClient.WebApps().ListPublishingProfileXmlWithSecretsSlot(resourceGroupName, webSiteName, options, slotName) : 
                WrappedWebsitesClient.WebApps().ListPublishingProfileXmlWithSecrets(resourceGroupName, webSiteName, options));
            var doc = XDocument.Load(publishingXml, LoadOptions.None);
            var profile = doc.Root == null ? null : doc.Root.Element("publishData") == null ? null : doc.Root.Element("publishData").Elements("publishProfile")
                .Single(p => p.Attribute("publishMethod").Value == "MSDeploy");
            return profile == null ? null : profile.Attribute("userPWD").Value;
        }

        public void RunWebAppContainerPSSessionScript(PSCmdlet cmdlet, string resourceGroupName, string webSiteName, string slotName = null, bool newPSSession = false)
        {
            Version psCurrentVersion = GetPsVersion(cmdlet);
            Version psCore = new Version(6, 0);

            if (psCurrentVersion.CompareTo(psCore) < 0)
            {
                // Running on PowerShell 5.1. Assume Windows.

                // Validate if WSMAN Basic Authentication is enabled
                bool isBasicAuthEnabled = ExecuteScriptAndGetVariableAsBool(cmdlet, "${0} = (Get-Item WSMAN:\\LocalHost\\Client\\Auth\\Basic -ErrorAction SilentlyContinue).Value", false);

                if (!isBasicAuthEnabled)
                {
                    // Ask user to enable basic auth
                    WriteWarning(Properties.Resources.EnterCotnainerPSSessionBasicAuthWarning);
                    return;
                }

                // Validate if we can connect given the existing TrustedHosts
                string defaultTrustedHostsScriptResult = "<empty or non-existent>";
                string trustedHostsScriptResult = ExecuteScriptAndGetVariable(cmdlet, "${0} = (Get-Item WSMAN:\\LocalHost\\Client\\TrustedHosts -ErrorAction SilentlyContinue).Value", defaultTrustedHostsScriptResult);

                Regex expression = new Regex(@"^\*$|((^\*|^" + (string.IsNullOrWhiteSpace(slotName)? webSiteName : webSiteName + "-" + slotName) + ").azurewebsites.net)");

                if (trustedHostsScriptResult.Split(',').Where(h=>expression.IsMatch(h)).Count() < 1)
                {
                    WriteWarning(string.Format(Properties.Resources.EnterContainerPSSessionFormatForTrustedHostsWarning, string.IsNullOrWhiteSpace(trustedHostsScriptResult) ? defaultTrustedHostsScriptResult: trustedHostsScriptResult) + 
                        Environment.NewLine +
                        Environment.NewLine +
                        string.Format(@Properties.Resources.EnterContainerPSSessionFormatForTrustedHostsSuggestion,
                        string.IsNullOrWhiteSpace(trustedHostsScriptResult) ? string.Empty : trustedHostsScriptResult + ",",
                        (string.IsNullOrWhiteSpace(slotName) ? webSiteName : webSiteName + "-" + slotName)));

                    return;
                }
            }

            Site site = GetWebApp(resourceGroupName, webSiteName, slotName);
            User user = GetPublishingCredentials(resourceGroupName, webSiteName, slotName);
            const string webAppContainerPSSessionVarPrefix = "webAppPSSession";
            string publishingUserName = user.PublishingUserName.Length <= 20 ? user.PublishingUserName : user.PublishingUserName.Substring(0, 20);

            string psSessionScript = string.Format("${3}User = '{0}' \n${3}Password = ConvertTo-SecureString -String '{1}' -AsPlainText -Force \n" +
                "${3}Credential = New-Object -TypeName PSCredential -ArgumentList ${3}User, ${3}Password\n" +
                (newPSSession ? "${3}NewPsSession = New-PSSession" : "Enter-PSSession") + " -ConnectionUri https://{2}/WSMAN -Authentication Basic -Credential ${3}Credential \n",
                publishingUserName, user.PublishingPassword, site.DefaultHostName, webAppContainerPSSessionVarPrefix);

            cmdlet.ExecuteScript<object>(psSessionScript);
            if (newPSSession)
            {
                cmdlet.WriteObject(cmdlet.GetVariableValue(string.Format("{0}NewPsSession", webAppContainerPSSessionVarPrefix)));
            }
            cmdlet.ExecuteScript<object>(string.Format("Clear-Variable {0}*", webAppContainerPSSessionVarPrefix)); //Clearing session variable
        }

        private Version GetPsVersion(PSCmdlet cmdlet)
        {
            string psVersionVariable = ExecuteScriptAndGetVariable(cmdlet, "${0} = $PSVersionTable.PSVersion", string.Empty);
            Version psEnvironmentVersion = new Version(5, 1);
            Version.TryParse(psVersionVariable, out psEnvironmentVersion);
            return psEnvironmentVersion;
        }

        private bool ExecuteScriptAndGetVariableAsBool(PSCmdlet cmdlet, string scriptFormatString, bool defaultValue)
        {
            string scriptResult = ExecuteScriptAndGetVariable(cmdlet, scriptFormatString, bool.FalseString);
            bool returnValue = defaultValue;
            bool.TryParse(scriptResult, out returnValue);
            return returnValue;
        }

        private string ExecuteScriptAndGetVariable(PSCmdlet cmdlet,  string scriptFormatString, string defaultValue)
        {
            string outputVariable = "outputVariable";
            cmdlet.ExecuteScript<object>(string.Format(scriptFormatString, outputVariable));
            var output = cmdlet.GetVariableValue(outputVariable, defaultValue);
            return output.ToString();
        }

        public IEnumerable<ResourceMetric> GetWebAppUsageMetrics(string resourceGroupName, 
            string webSiteName, 
            string slotName, 
            IReadOnlyList<string> metricNames,
            DateTime? startTime, 
            DateTime? endTime, 
            string timeGrain, 
            bool instanceDetails)
        {
            string qualifiedSiteName;
            var usageMetrics = CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName) ?
                WrappedWebsitesClient.WebApps().ListMetricsSlot(resourceGroupName, webSiteName, slotName, instanceDetails, CmdletHelpers.BuildMetricFilter(startTime, endTime ?? DateTime.Now, timeGrain, metricNames)) :
                WrappedWebsitesClient.WebApps().ListMetrics(resourceGroupName, webSiteName, instanceDetails, CmdletHelpers.BuildMetricFilter(startTime, endTime ?? DateTime.Now, timeGrain, metricNames));
            return usageMetrics;
        }

        public AppServicePlan CreateOrUpdateAppServicePlan(string resourceGroupName, string appServicePlanName, AppServicePlan appServicePlan, string aseName = null, string aseResourceGroupName = null)
        {
            if (!string.IsNullOrEmpty(aseName)
                && !string.IsNullOrEmpty(aseResourceGroupName))
            {
                appServicePlan.HostingEnvironmentProfile = new HostingEnvironmentProfile(
				id: CmdletHelpers.GetApplicationServiceEnvironmentResourceId(WrappedWebsitesClient.SubscriptionId, aseResourceGroupName, aseName),
                    name: aseName,
                    type: CmdletHelpers.ApplicationServiceEnvironmentResourcesName);
            }

            return WrappedWebsitesClient.AppServicePlans().CreateOrUpdate(resourceGroupName, appServicePlanName, appServicePlan);
        }

        public HttpStatusCode RemoveAppServicePlan(string resourceGroupName, string appServicePlanName)
        {
            WrappedWebsitesClient.AppServicePlans().Delete(resourceGroupName, appServicePlanName);
            return HttpStatusCode.OK;
        }

        public AppServicePlan GetAppServicePlan(string resourceGroupName, string appServicePlanName)
        {
            return WrappedWebsitesClient.AppServicePlans().Get(resourceGroupName, appServicePlanName);
        }

        public IList<AppServicePlan> ListAppServicePlans(string resourceGroupName)
        {
            return WrappedWebsitesClient.AppServicePlans().ListByResourceGroup(resourceGroupName).ToList();
        }

        public IEnumerable<ResourceMetric> GetAppServicePlanHistoricalUsageMetrics(
            string resourceGroupName, 
            string appServicePlanName, 
            IReadOnlyList<string> metricNames,
            DateTime? startTime, 
            DateTime? endTime, 
            string timeGrain, 
            bool instanceDetails)
        {
            var response = WrappedWebsitesClient.AppServicePlans().ListMetrics(
                resourceGroupName, 
                appServicePlanName, 
                instanceDetails, 
                CmdletHelpers.BuildMetricFilter(startTime, endTime, timeGrain, metricNames));
            return response;
        }

        public void UpdateWebAppConfiguration(string resourceGroupName, string location, string webSiteName, string slotName, SiteConfig siteConfig = null, IDictionary<string, string> appSettings = null, IDictionary<string, ConnStringValueTypePair> connectionStrings = null, AzureStoragePropertyDictionaryResource azureStorageSettings = null)
        {
            string qualifiedSiteName;
            var useSlot = CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName);

            if (useSlot)
            {
                if (siteConfig != null)
                {
                    WrappedWebsitesClient.WebApps().UpdateConfigurationSlot(
                        resourceGroupName, 
                        webSiteName, 
                        siteConfig.ConvertToSiteConfigResource(),
                        slotName);
                }

                if (appSettings != null)
                {
                    WrappedWebsitesClient.WebApps().UpdateApplicationSettingsSlot(
                        resourceGroupName, 
                        webSiteName, 
                        new StringDictionary { Properties = appSettings }, 
                        slotName);
                }

                if (connectionStrings != null)
                {
                    WrappedWebsitesClient.WebApps().UpdateConnectionStringsSlot(
                        resourceGroupName, 
                        webSiteName, 
                        new ConnectionStringDictionary { Properties = connectionStrings }, 
                        slotName);
                }

                if (azureStorageSettings != null)
                {
                    WrappedWebsitesClient.WebApps().UpdateAzureStorageAccountsSlot(
                        resourceGroupName,
                        webSiteName,
                        azureStorageSettings,
                        slotName);
                }
            }
            else
            {
                if (siteConfig != null)
                {
                    WrappedWebsitesClient.WebApps().UpdateConfiguration(resourceGroupName, webSiteName, siteConfig.ConvertToSiteConfigResource());
                }

                if (appSettings != null)
                {
                    WrappedWebsitesClient.WebApps().UpdateApplicationSettings(
                        resourceGroupName, 
                        webSiteName, 
                        new StringDictionary { Properties = appSettings });
                }

                if (connectionStrings != null)
                {
                    WrappedWebsitesClient.WebApps().UpdateConnectionStrings(
                        resourceGroupName, 
                        webSiteName, 
                        new ConnectionStringDictionary { Properties = connectionStrings });
                }

                if (azureStorageSettings != null)
                {
                    WrappedWebsitesClient.WebApps().UpdateAzureStorageAccounts(
                        resourceGroupName,
                        webSiteName,
                        azureStorageSettings);
                }
            }
        }

        private void GetWebAppConfiguration(string resourceGroupName, string webSiteName, string slotName, Site site)
        {
            string qualifiedSiteName;
            var useSlot = CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName);
            site.SiteConfig = (useSlot ? 
                WrappedWebsitesClient.WebApps().GetConfigurationSlot(resourceGroupName, webSiteName, slotName) :
                WrappedWebsitesClient.WebApps().GetConfiguration(resourceGroupName, webSiteName)).ConvertToSiteConfig();
            try
            {
                var appSettings = useSlot ? 
                    WrappedWebsitesClient.WebApps().ListApplicationSettingsSlot(resourceGroupName, webSiteName, slotName) :
                    WrappedWebsitesClient.WebApps().ListApplicationSettings(resourceGroupName, webSiteName);

                site.SiteConfig.AppSettings = appSettings.Properties.Select(s => new NameValuePair { Name = s.Key, Value = s.Value }).ToList();

                var connectionStrings = useSlot ? 
                    WrappedWebsitesClient.WebApps().ListConnectionStringsSlot(resourceGroupName, webSiteName, slotName) : 
                    WrappedWebsitesClient.WebApps().ListConnectionStrings(resourceGroupName, webSiteName);

                site.SiteConfig.ConnectionStrings = connectionStrings
                    .Properties
                    .Select(s => new ConnStringInfo()
                    {
                        Name = s.Key,
                        ConnectionString = s.Value.Value,
                        Type = s.Value.Type
                    }).ToList();

                var azureStorageAccounts = useSlot ?
                    WrappedWebsitesClient.WebApps().ListAzureStorageAccountsSlot(resourceGroupName, webSiteName, slotName) :
                    WrappedWebsitesClient.WebApps().ListAzureStorageAccounts(resourceGroupName, webSiteName);

                site.SiteConfig.AzureStorageAccounts = azureStorageAccounts.Properties;
            }
            catch
            {
                //ignore if this call fails as it will for reader RBAC
            }
        }

        public IPage<SiteConfigurationSnapshotInfo> GetWebAppConfigurationSnapshots(string resourceGroupName, string webSiteName, string slotName)
        {
            string qualifiedSiteName;
            var useSlot = CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName);
            if (useSlot)
            {
                return WrappedWebsitesClient.WebApps.ListConfigurationSnapshotInfoSlot(resourceGroupName, webSiteName, slotName);
            }
            else
            {

                return WrappedWebsitesClient.WebApps.ListConfigurationSnapshotInfo(resourceGroupName, webSiteName);
            }
        }

        public BackupRequest GetWebAppBackupConfiguration(string resourceGroupName, string webSiteName, string slotName)
        {
            string qualifiedSiteName;
            var useSlot = CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName);
            if (useSlot)
            {
                return WrappedWebsitesClient.WebApps()
                    .GetBackupConfigurationSlot(resourceGroupName, webSiteName, slotName);
            }
            else
            {
                return WrappedWebsitesClient.WebApps()
                    .GetBackupConfiguration(resourceGroupName, webSiteName);
            }
        }

        public BackupRequest UpdateWebAppBackupConfiguration(string resourceGroupName, string webSiteName,
            string slotName, BackupRequest newSchedule)
        {
            string qualifiedSiteName;
            var useSlot = CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName);
            if (useSlot)
            {
                return WrappedWebsitesClient.WebApps().UpdateBackupConfigurationSlot(
                    resourceGroupName,
                    webSiteName, 
                    newSchedule,
                    slotName);
            }
            else
            {
                return WrappedWebsitesClient.WebApps().UpdateBackupConfiguration(
                    resourceGroupName, 
                    webSiteName, 
                    newSchedule);
            }
        }

        public BackupItem BackupSite(string resourceGroupName, string webSiteName, string slotName,
            BackupRequest request)
        {
            string qualifiedSiteName;
            var useSlot = CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName);
            if (useSlot)
            {
                var backup = WrappedWebsitesClient.WebApps().BackupSlot(resourceGroupName, webSiteName, request, slotName);
                return backup;
            }
            else
            {
                var backup = WrappedWebsitesClient.WebApps().Backup(resourceGroupName, webSiteName, request);
                return backup;
            }
        }

        public IList<BackupItem> ListSiteBackups(string resourceGroupName, string webSiteName, string slotName)
        {
            string qualifiedSiteName;
            var useSlot = CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName);
            if (useSlot)
            {
                return WrappedWebsitesClient.WebApps().ListBackupsSlot(resourceGroupName, webSiteName, slotName).ToList();
            }
            else
            {
                return WrappedWebsitesClient.WebApps().ListBackups(resourceGroupName, webSiteName).ToList();
            }
        }

        public BackupItem GetSiteBackupStatus(string resourceGroupName, string webSiteName, string slotName, string backupId)
        {
            string qualifiedSiteName;
            var useSlot = CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName);
            if (useSlot)
            {
                return WrappedWebsitesClient.WebApps().GetBackupStatusSlot(
                    resourceGroupName, 
                    webSiteName, 
                    backupId, 
                    slotName);
            }
            else
            {
                return WrappedWebsitesClient.WebApps().GetBackupStatus(
                    resourceGroupName, 
                    webSiteName, 
                    backupId);
            }
        }

        public BackupItem GetSiteBackupStatusSecrets(string resourceGroupName, string webSiteName, string slotName,
            string backupId)
        {
            string qualifiedSiteName;
            var useSlot = CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName);
            if (useSlot)
            {
                return WrappedWebsitesClient.WebApps().GetBackupStatusSlot(resourceGroupName, webSiteName,
                    backupId, slotName);
            }
            else
            {
                return WrappedWebsitesClient.WebApps().GetBackupStatus(resourceGroupName, webSiteName, backupId);
            }
        }

        public BackupItem DeleteBackup(string resourceGroupName, string webSiteName, string slotName,
            string backupId)
        {
            string qualifiedSiteName;
            var useSlot = CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName);
            if (useSlot)
            {
                var retValue = WrappedWebsitesClient.WebApps().GetBackupStatusSlot(
                    resourceGroupName, 
                    webSiteName, 
                    backupId, 
                    slotName);
                WrappedWebsitesClient.WebApps().DeleteBackupSlot(resourceGroupName, webSiteName, backupId, slotName);
                return retValue;
            }
            else
            {
                var retValue = WrappedWebsitesClient.WebApps().GetBackupStatus(
                    resourceGroupName,
                    webSiteName,
                    backupId);
                WrappedWebsitesClient.WebApps().DeleteBackup(resourceGroupName, webSiteName, backupId);
                return retValue;
            }
        }

        public void RestoreSite(string resourceGroupName, string webSiteName, string slotName,
            string backupId, RestoreRequest request)
        {
            string qualifiedSiteName;
            var useSlot = CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName);
            if (useSlot)
            {
                WrappedWebsitesClient.WebApps().RestoreSlot(
                    resourceGroupName, 
                    webSiteName, 
                    backupId, 
                    request, 
                    slotName);
            }
            else
            {
                WrappedWebsitesClient.WebApps().Restore(resourceGroupName, webSiteName, backupId, request);
            }
        }

        public IList<Snapshot> GetSiteSnapshots(string resourceGroupName, string webSiteName, string slotName)
        {
            string qualifiedSiteName;
            bool useSlot = CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName);
            if (useSlot)
            {
                return WrappedWebsitesClient.WebApps.ListSnapshotsSlot(resourceGroupName, webSiteName, slotName).ToList();
            }
            else
            {
                return WrappedWebsitesClient.WebApps.ListSnapshots(resourceGroupName, webSiteName).ToList();
            }
        }

        public void RestoreSnapshot(string resourceGroupName, string webSiteName, string slotName,
            SnapshotRestoreRequest restoreReq)
        {
            string qualifiedSiteName;
            bool useSlot = CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName);
            if (useSlot)
            {
                WrappedWebsitesClient.WebApps().RestoreSnapshotSlot(resourceGroupName, webSiteName, restoreReq, slotName);
            }
            else
            {
                WrappedWebsitesClient.WebApps().RestoreSnapshot(resourceGroupName, webSiteName, restoreReq);
            }
        }

        public IList<DeletedSite> GetDeletedSites()
        {
            return WrappedWebsitesClient.DeletedWebApps().List().ToList();
        }

        public void RestoreDeletedWebApp(string resourceGroupName, string webSiteName, string slotName,
            DeletedAppRestoreRequest restoreReq)
        {
            string qualifiedSiteName;
            bool useSlot = CmdletHelpers.ShouldUseDeploymentSlot(webSiteName, slotName, out qualifiedSiteName);
            if (useSlot)
            {
                WrappedWebsitesClient.WebApps().BeginRestoreFromDeletedAppSlot(resourceGroupName, webSiteName, restoreReq, slotName);
            }
            else
            {
                WrappedWebsitesClient.WebApps().BeginRestoreFromDeletedApp(resourceGroupName, webSiteName, restoreReq);
            }
        }

        public Certificate CreateCertificate(string resourceGroupName, string certificateName, Certificate certificate)
        {
            return WrappedWebsitesClient.Certificates()
                .CreateOrUpdate(resourceGroupName, certificateName, certificate);
        }

        public Certificate GetCertificate(string resourceGroupName, string certificateName)
        {
            return WrappedWebsitesClient.Certificates().Get(resourceGroupName, certificateName);
        }

        public HttpStatusCode RemoveCertificate(string resourceGroupName, string certificateName)
        {
            WrappedWebsitesClient.Certificates().Delete(resourceGroupName, certificateName);
            return HttpStatusCode.OK;
        }

        public Site UpdateHostNameSslState(string resourceGroupName, string webAppName, string slotName, string location, string hostName, SslState sslState, string thumbPrint)
        {
            Site updateWebSite;
            string qualifiedSiteName;

            var shouldUseDeploymentSlot = CmdletHelpers.ShouldUseDeploymentSlot(webAppName, slotName, out qualifiedSiteName);
            var webapp = GetWebApp(resourceGroupName, webAppName, slotName);

            var webappWithNewSslBinding = new Site
            {
                HostNameSslStates = new List<HostNameSslState>{new HostNameSslState
                {
                    Name = hostName,
                    Thumbprint = thumbPrint,
                    ToUpdate = true,
                    SslState = sslState
                }},
                Location = location,
                Tags = webapp?.Tags
            };

            if (shouldUseDeploymentSlot)
            {
                updateWebSite = WrappedWebsitesClient.WebApps().CreateOrUpdateSlot(
                        resourceGroupName, webAppName, slot: slotName, siteEnvelope:
                        webappWithNewSslBinding);
            }
            else
            {
                updateWebSite = WrappedWebsitesClient.WebApps().CreateOrUpdate(
                        resourceGroupName, webAppName, siteEnvelope:
                        webappWithNewSslBinding);
            }
            return updateWebSite;
        }

        public SlotConfigNamesResource GetSlotConfigNames(string resourceGroupName, string webSiteName)
        {
            return WrappedWebsitesClient.WebApps().ListSlotConfigurationNames(resourceGroupName, webSiteName);
        }

        public SlotConfigNamesResource SetSlotConfigNames(
            string resourceGroupName, 
            string webSiteName, 
            IList<string> appSettingNames, 
            IList<string> connectionStringNames)
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

            return WrappedWebsitesClient.WebApps().UpdateSlotConfigurationNames(resourceGroupName, webSiteName, slotConfigNames);
        }

        public void SwapSlot(
            string resourceGroupName, 
            string webSiteName, 
            string sourceSlotName, 
            string destinationSlotName, 
            bool? preserveVnet)
        {
            var csmSlotEntity = new CsmSlotEntity { TargetSlot = destinationSlotName };

            if(preserveVnet.HasValue)
            {
                csmSlotEntity.PreserveVnet = preserveVnet.Value;
            }

            WrappedWebsitesClient.WebApps().SwapSlotSlot(
                resourceGroupName,
                webSiteName,
                csmSlotEntity,
                sourceSlotName);
        }

        public void SwapSlotWithPreviewApplySlotConfig(string resourceGroupName, string webSiteName, string sourceSlotName, string destinationSlotName, bool? preserveVnet)
        {
            var csmSlotEntity = new CsmSlotEntity { TargetSlot = destinationSlotName};

            if (preserveVnet.HasValue)
            {
                csmSlotEntity.PreserveVnet = preserveVnet.Value;
            }

            WrappedWebsitesClient.WebApps().ApplySlotConfigurationSlot(
                resourceGroupName,
                webSiteName,
                csmSlotEntity,
                sourceSlotName);
        }

        public void SwapSlotWithPreviewResetSlotSwap(string resourceGroupName, string webSiteName, string sourceSlotName)
        {
            WrappedWebsitesClient.WebApps().ResetSlotConfigurationSlot(
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
