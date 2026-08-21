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
//
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Xml.Linq;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.AppService;
using Azure.ResourceManager.AppService.Models;
using Azure.ResourceManager.Resources;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.WebApps.Models;
using Microsoft.Azure.Commands.WebApps.Models.WebApp;
using Microsoft.Azure.Management.WebSites.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ArmCsmSlotEntity = Azure.ResourceManager.AppService.Models.CsmSlotEntity;
using CloningInfo = Microsoft.Azure.Management.WebSites.Models.CloningInfo;
using ConnStringValueTypePair =
    Microsoft.Azure.Management.WebSites.Models.ConnStringValueTypePair;
using CompatAppServiceEnvironmentResource =
    Microsoft.Azure.Management.WebSites.Models.AppServiceEnvironmentResource;
using CompatSlotConfigNamesResource =
    Microsoft.Azure.Management.WebSites.Models.SlotConfigNamesResource;
using HostingEnvironmentProfile =
    Microsoft.Azure.Management.WebSites.Models.HostingEnvironmentProfile;
using HostNameSslState =
    Microsoft.Azure.Management.WebSites.Models.HostNameSslState;
using SiteConfigurationSnapshotInfo =
    Microsoft.Azure.Management.WebSites.Models.SiteConfigurationSnapshotInfo;
using SnapshotRestoreRequest =
    Microsoft.Azure.Management.WebSites.Models.SnapshotRestoreRequest;

namespace Microsoft.Azure.Commands.WebApps.Utilities
{
    public partial class WebsitesClient
    {
        public const string ApiVersion = "2025-05-01";

        private static readonly WebAppBackupInfo EmptyBackupInfo = new WebAppBackupInfo();
        private readonly TokenCredential tokenCredential;
        private readonly HttpClient httpClient;
        private readonly Uri resourceManagerEndpoint;
        private readonly string subscriptionId;

        public Action<string> VerboseLogger { get; set; }

        public Action<string> ErrorLogger { get; set; }

        public Action<string> WarningLogger { get; set; }

        public WebsitesClient(IAzureContext context)
        {
            if (context?.Subscription == null)
            {
                throw new InvalidOperationException("An active Azure subscription is required.");
            }

            subscriptionId = context.Subscription.Id;
            string endpoint = context.Environment.GetEndpoint(
                AzureEnvironment.Endpoint.ResourceManager);
            string audience = context.Environment.GetTokenAudience(
                AzureEnvironment.Endpoint.ResourceManager);
            resourceManagerEndpoint = new Uri(
                endpoint.EndsWith("/", StringComparison.Ordinal)
                    ? endpoint
                    : endpoint + "/");
            var appServiceTokenCredential =
                new AppServiceTokenCredential(context, audience);
            tokenCredential = appServiceTokenCredential;
            httpClient = CreateHttpClient(
                endpoint,
                appServiceTokenCredential);
            var options = new ArmClientOptions
            {
                Environment = new ArmEnvironment(resourceManagerEndpoint, audience),
                Transport = new HttpClientTransport(httpClient)
            };
            WrappedWebsitesClient = new ArmClient(
                tokenCredential,
                subscriptionId,
                options);
        }

        public ArmClient WrappedWebsitesClient { get; }

        public bool IsWebAppNameAvailable(string name)
        {
            var content = new AppServiceNameAvailabilityContent(
                name,
                new CheckNameResourceType("Site"));
            return GetSubscription()
                .CheckAppServiceNameAvailability(content)
                .Value
                .IsNameAvailable != false;
        }

        public Site CreateWebApp(
            string resourceGroupName,
            string webAppName,
            string slotName,
            string location,
            string serverFarmId,
            CloningInfo cloningInfo,
            string aseName,
            string aseResourceGroupName,
            IDictionary<string, string> tags = null,
            ManagedServiceIdentity sourceIdentity = null,
            SiteConfig siteConfig = null)
        {
            var site = new Site
            {
                Location = location,
                ServerFarmId = serverFarmId,
                CloningInfo = cloningInfo,
                HostingEnvironmentProfile = CreateHostingEnvironmentProfile(
                    resourceGroupName,
                    aseResourceGroupName,
                    aseName),
                Tags = tags,
                Identity = sourceIdentity,
                SiteConfig = siteConfig
            };

            WebSiteData createdData;
            if (ShouldUseSlot(webAppName, slotName))
            {
                createdData = GetSiteResource(resourceGroupName, webAppName)
                    .GetWebSiteSlots()
                    .CreateOrUpdate(
                        WaitUntil.Completed,
                        slotName,
                        AppServiceModelConverter.ToWebSiteData(site))
                    .Value
                    .Data;
            }
            else
            {
                createdData = GetResourceGroup(resourceGroupName)
                    .GetWebSites()
                    .CreateOrUpdate(
                        WaitUntil.Completed,
                        webAppName,
                        AppServiceModelConverter.ToWebSiteData(site))
                    .Value
                    .Data;
            }

            Site createdSite = AppServiceModelConverter.FromWebSiteData(createdData);
            GetWebAppConfiguration(
                resourceGroupName,
                webAppName,
                slotName,
                createdSite);
            return createdSite;
        }

        public HostingEnvironmentProfile CreateHostingEnvironmentProfile(
            string resourceGroupName,
            string aseResourceGroupName,
            string aseName)
        {
            if (string.IsNullOrEmpty(aseName))
            {
                return null;
            }

            return CmdletHelpers.CreateHostingEnvironmentProfile(
                subscriptionId,
                resourceGroupName,
                aseResourceGroupName,
                aseName);
        }

        public void UpdateWebApp(
            string resourceGroupName,
            string location,
            string webAppName,
            string slotName,
            string appServicePlan,
            Site siteEnvelope = null,
            string appServicePlanRg = null)
        {
            var webSiteToUpdate = siteEnvelope ?? new Site
            {
                Location = location,
                ServerFarmId = appServicePlan
            };

            if (webSiteToUpdate is PSSite psSite)
            {
                psSite.VnetInfo = null;
            }

            if (!string.IsNullOrEmpty(appServicePlan))
            {
                webSiteToUpdate.ServerFarmId = ResolveAppServicePlanId(
                    subscriptionId,
                    appServicePlanRg,
                    appServicePlan);
            }

            if (ShouldUseSlot(webAppName, slotName))
            {
                GetSiteResource(resourceGroupName, webAppName)
                    .GetWebSiteSlots()
                    .CreateOrUpdate(
                        WaitUntil.Completed,
                        slotName,
                        AppServiceModelConverter.ToWebSiteData(webSiteToUpdate));
            }
            else
            {
                GetResourceGroup(resourceGroupName)
                    .GetWebSites()
                    .CreateOrUpdate(
                        WaitUntil.Completed,
                        webAppName,
                        AppServiceModelConverter.ToWebSiteData(webSiteToUpdate));
            }
        }

        public void AddCustomHostNames(
            string resourceGroupName,
            string location,
            string webAppName,
            string[] hostNames,
            string slotName = null)
        {
            Site webApp = ShouldUseSlot(webAppName, slotName)
                ? GetWebApp(resourceGroupName, webAppName, slotName)
                : AppServiceModelConverter.FromWebSiteData(
                    GetSiteResource(resourceGroupName, webAppName)
                        .Get()
                        .Value
                        .Data);
            IList<string> currentHostNames = webApp.HostNames ?? new List<string>();

            foreach (string hostName in hostNames)
            {
                try
                {
                    if (currentHostNames.Contains(hostName, StringComparer.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    var binding = new HostNameBindingData { SiteName = webAppName };
                    if (ShouldUseSlot(webAppName, slotName))
                    {
                        GetSlotResource(resourceGroupName, webAppName, slotName)
                            .GetSiteSlotHostNameBindings()
                            .CreateOrUpdate(WaitUntil.Completed, hostName, binding);
                    }
                    else
                    {
                        GetSiteResource(resourceGroupName, webAppName)
                            .GetSiteHostNameBindings()
                            .CreateOrUpdate(WaitUntil.Completed, hostName, binding);
                    }
                }
                catch (RequestFailedException exception)
                {
                    WriteWarning(
                        "Could not set custom hostname '{0}'. Details: {1}",
                        hostName,
                        exception.Message);
                    return;
                }
            }

            foreach (string hostName in currentHostNames)
            {
                if (hostNames.Contains(hostName, StringComparer.OrdinalIgnoreCase))
                {
                    continue;
                }

                try
                {
                    if (ShouldUseSlot(webAppName, slotName))
                    {
                        GetSlotResource(resourceGroupName, webAppName, slotName)
                            .GetSiteSlotHostNameBindings()
                            .Get(hostName)
                            .Value
                            .Delete(WaitUntil.Completed);
                    }
                    else
                    {
                        GetSiteResource(resourceGroupName, webAppName)
                            .GetSiteHostNameBindings()
                            .Get(hostName)
                            .Value
                            .Delete(WaitUntil.Completed);
                    }
                }
                catch (RequestFailedException exception)
                {
                    WriteWarning(
                        "Could not remove custom hostname '{0}'. Details: {1}",
                        hostName,
                        exception.Message);
                }
            }
        }

        public void StartWebApp(
            string resourceGroupName,
            string webSiteName,
            string slotName)
        {
            if (ShouldUseSlot(webSiteName, slotName))
            {
                GetSlotResource(resourceGroupName, webSiteName, slotName).StartSlot();
            }
            else
            {
                GetSiteResource(resourceGroupName, webSiteName).Start();
            }
        }

        public void StopWebApp(
            string resourceGroupName,
            string webSiteName,
            string slotName)
        {
            if (ShouldUseSlot(webSiteName, slotName))
            {
                GetSlotResource(resourceGroupName, webSiteName, slotName).StopSlot();
            }
            else
            {
                GetSiteResource(resourceGroupName, webSiteName).Stop();
            }
        }

        public void RestartWebApp(
            string resourceGroupName,
            string webSiteName,
            string slotName,
            bool softRestart)
        {
            if (ShouldUseSlot(webSiteName, slotName))
            {
                GetSlotResource(resourceGroupName, webSiteName, slotName)
                    .RestartSlot(softRestart);
            }
            else
            {
                GetSiteResource(resourceGroupName, webSiteName).Restart(softRestart);
            }
        }

        public HttpStatusCode RemoveWebApp(
            string resourceGroupName,
            string webSiteName,
            string slotName,
            bool deleteAppServicePlan,
            bool deleteMetricsBydefault,
            bool deleteSlotsBydefault)
        {
            if (ShouldUseSlot(webSiteName, slotName))
            {
                GetSlotResource(resourceGroupName, webSiteName, slotName)
                    .Delete(
                        WaitUntil.Completed,
                        deleteMetricsBydefault,
                        deleteAppServicePlan);
            }
            else
            {
                GetSiteResource(resourceGroupName, webSiteName)
                    .Delete(
                        WaitUntil.Completed,
                        deleteMetricsBydefault,
                        deleteAppServicePlan);
            }

            return HttpStatusCode.OK;
        }

        public PSSite GetWebApp(
            string resourceGroupName,
            string webSiteName,
            string slotName,
            bool ignoreError = true)
        {
            Site site = ShouldUseSlot(webSiteName, slotName)
                ? AppServiceModelConverter.FromWebSiteData(
                    GetSlotResource(resourceGroupName, webSiteName, slotName).Get().Value.Data)
                : AppServiceModelConverter.FromWebSiteData(
                    GetSiteResource(resourceGroupName, webSiteName).Get().Value.Data);

            GetWebAppConfiguration(
                resourceGroupName,
                webSiteName,
                slotName,
                site,
                ignoreError);

            var psSite = new PSSite(site);
            AzureStoragePropertyDictionaryResource storageAccounts =
                GetAzureStorageAccounts(
                    resourceGroupName,
                    webSiteName,
                    slotName,
                    ShouldUseSlot(webSiteName, slotName));
            psSite.AzureStoragePath =
                storageAccounts?.Properties.ConvertToWebAppAzureStorageArray();
            psSite.VnetInfo = ShouldUseSlot(webSiteName, slotName)
                ? GetSlotResource(resourceGroupName, webSiteName, slotName)
                    .GetSiteSlotVirtualNetworkConnections()
                    .GetAll()
                    .Select(item =>
                        AppServiceModelConverter.FromAppServiceVirtualNetworkData(item.Data))
                    .ToList()
                : GetSiteResource(resourceGroupName, webSiteName)
                    .GetSiteVirtualNetworkConnections()
                    .GetAll()
                    .Select(item =>
                        AppServiceModelConverter.FromAppServiceVirtualNetworkData(item.Data))
                    .ToList();
            if (psSite.VnetInfo.Count == 0)
            {
                psSite.VnetInfo = null;
            }

            return psSite;
        }

        public bool WebAppExists(
            string resourceGroupName,
            string webSiteName,
            string slotName)
        {
            return ShouldUseSlot(webSiteName, slotName)
                ? GetSiteResource(resourceGroupName, webSiteName)
                    .GetWebSiteSlots()
                    .Exists(slotName)
                    .Value
                : GetResourceGroup(resourceGroupName)
                    .GetWebSites()
                    .Exists(webSiteName)
                    .Value;
        }

        public IEnumerable<Site> ListWebApps(
            string resourceGroupName,
            string webSiteName)
        {
            return !string.IsNullOrWhiteSpace(webSiteName)
                ? GetSiteResource(resourceGroupName, webSiteName)
                    .GetWebSiteSlots()
                    .GetAll()
                    .Select(item => AppServiceModelConverter.FromWebSiteData(item.Data))
                    .ToList()
                : GetResourceGroup(resourceGroupName)
                    .GetWebSites()
                    .GetAll()
                    .Select(item => AppServiceModelConverter.FromWebSiteData(item.Data))
                    .ToList();
        }

        public IList<Site> ListWebAppsForAppServicePlan(
            string resourceGroupName,
            string appServicePlanName)
        {
            return GetAppServicePlanResource(resourceGroupName, appServicePlanName)
                .GetWebApps()
                .Select(AppServiceModelConverter.FromWebSiteData)
                .ToList();
        }

        public string GetWebAppPublishingProfile(
            string resourceGroupName,
            string webSiteName,
            string slotName,
            string outputFile,
            string format,
            bool? includeDRTEndpoint)
        {
            var options = new CsmPublishingProfile
            {
                Format = ParsePublishingProfileFormat(format),
                IsIncludeDisasterRecoveryEndpoints = includeDRTEndpoint
            };

            Stream publishingXml = ShouldUseSlot(webSiteName, slotName)
                ? GetSlotResource(resourceGroupName, webSiteName, slotName)
                    .GetPublishingProfileXmlWithSecretsSlot(options)
                    .Value
                : GetSiteResource(resourceGroupName, webSiteName)
                    .GetPublishingProfileXmlWithSecrets(options)
                    .Value;
            var document = XDocument.Load(publishingXml, LoadOptions.None);
            if (outputFile != null)
            {
                document.Save(outputFile, SaveOptions.OmitDuplicateNamespaces);
            }
            return document.ToString();
        }

        public User GetPublishingCredentials(
            string resourceGroupName,
            string webSiteName,
            string slotName = null)
        {
            PublishingUserData data = ShouldUseSlot(webSiteName, slotName)
                ? GetSlotResource(resourceGroupName, webSiteName, slotName)
                    .GetPublishingCredentialsSlot(WaitUntil.Completed)
                    .Value
                    .Data
                : GetSiteResource(resourceGroupName, webSiteName)
                    .GetPublishingCredentials(WaitUntil.Completed)
                    .Value
                    .Data;
            return AppServiceModelConverter.FromPublishingUserData(data);
        }

        public string ResetWebAppPublishingCredentials(
            string resourceGroupName,
            string webSiteName,
            string slotName)
        {
            if (ShouldUseSlot(webSiteName, slotName))
            {
                GetSlotResource(resourceGroupName, webSiteName, slotName)
                    .GenerateNewSitePublishingPasswordSlot();
            }
            else
            {
                GetSiteResource(resourceGroupName, webSiteName)
                    .GenerateNewSitePublishingPassword();
            }

            string publishingProfile = GetWebAppPublishingProfile(
                resourceGroupName,
                webSiteName,
                slotName,
                null,
                "WebDeploy",
                null);
            var document = XDocument.Parse(publishingProfile);
            XElement profile = document
                .Descendants("publishProfile")
                .SingleOrDefault(item =>
                    string.Equals(
                        item.Attribute("publishMethod")?.Value,
                        "MSDeploy",
                        StringComparison.OrdinalIgnoreCase));
            return profile?.Attribute("userPWD")?.Value;
        }

        public AppServicePlan CreateOrUpdateAppServicePlan(
            string resourceGroupName,
            string appServicePlanName,
            AppServicePlan appServicePlan,
            string aseName = null,
            string aseResourceGroupName = null)
        {
            if (!string.IsNullOrEmpty(aseName) &&
                !string.IsNullOrEmpty(aseResourceGroupName))
            {
                appServicePlan.HostingEnvironmentProfile =
                    new HostingEnvironmentProfile(
                        CmdletHelpers.GetAppServiceEnvironmentResourceId(
                            subscriptionId,
                            aseResourceGroupName,
                            aseName));
            }

            AppServicePlanData data = GetResourceGroup(resourceGroupName)
                .GetAppServicePlans()
                .CreateOrUpdate(
                    WaitUntil.Completed,
                    appServicePlanName,
                    AppServiceModelConverter.ToAppServicePlanData(appServicePlan))
                .Value
                .Data;
            return AppServiceModelConverter.FromAppServicePlanData(data);
        }

        public AppServicePlan CreateOrUpdateAppServicePlan(
            string resourceGroupName,
            string appServicePlanName,
            AppServicePlan appServicePlan,
            string aseRecourceId)
        {
            if (!string.IsNullOrEmpty(aseRecourceId))
            {
                if (!CmdletHelpers.TryParseAppServiceEnvironmentMetadataFromResourceId(
                        aseRecourceId,
                        out string aseResourceGroupName,
                        out string aseName))
                {
                    throw new ArgumentException("AseResourceId format is invalid");
                }

                appServicePlan.HostingEnvironmentProfile =
                    new HostingEnvironmentProfile(aseRecourceId);
            }

            AppServicePlanData data = GetResourceGroup(resourceGroupName)
                .GetAppServicePlans()
                .CreateOrUpdate(
                    WaitUntil.Completed,
                    appServicePlanName,
                    AppServiceModelConverter.ToAppServicePlanData(appServicePlan))
                .Value
                .Data;
            return AppServiceModelConverter.FromAppServicePlanData(data);
        }

        public HttpStatusCode RemoveAppServicePlan(
            string resourceGroupName,
            string appServicePlanName)
        {
            GetAppServicePlanResource(resourceGroupName, appServicePlanName)
                .Delete(WaitUntil.Completed);
            return HttpStatusCode.OK;
        }

        public AppServicePlan GetAppServicePlan(
            string resourceGroupName,
            string appServicePlanName)
        {
            return AppServiceModelConverter.FromAppServicePlanData(
                GetAppServicePlanResource(resourceGroupName, appServicePlanName)
                    .Get()
                    .Value
                    .Data);
        }

        public IList<AppServicePlan> ListAppServicePlans(string resourceGroupName)
        {
            return GetResourceGroup(resourceGroupName)
                .GetAppServicePlans()
                .GetAll()
                .Select(item =>
                    AppServiceModelConverter.FromAppServicePlanData(item.Data))
                .ToList();
        }

        public void UpdateWebAppConfiguration(
            string resourceGroupName,
            string location,
            string webSiteName,
            string slotName,
            SiteConfig siteConfig = null,
            IDictionary<string, string> appSettings = null,
            IDictionary<string, ConnStringValueTypePair> connectionStrings = null,
            AzureStoragePropertyDictionaryResource azureStorageSettings = null)
        {
            if (ShouldUseSlot(webSiteName, slotName))
            {
                WebSiteSlotResource slot =
                    GetSlotResource(resourceGroupName, webSiteName, slotName);
                if (siteConfig != null)
                {
                    slot.GetWebSiteSlotConfig()
                        .Update(AppServiceModelConverter.ToSiteConfigData(siteConfig));
                }
                if (appSettings != null)
                {
                    slot.UpdateApplicationSettingsSlot(
                        AppServiceModelConverter.ToAppSettings(appSettings));
                }
                if (connectionStrings != null)
                {
                    slot.UpdateConnectionStringsSlot(
                        AppServiceModelConverter.ToConnectionStringDictionary(
                            connectionStrings));
                }
                if (azureStorageSettings != null)
                {
                    slot.UpdateAzureStorageAccountsSlot(
                        AppServiceModelConverter.ToAzureStoragePropertyDictionary(
                            azureStorageSettings));
                }
            }
            else
            {
                WebSiteResource site =
                    GetSiteResource(resourceGroupName, webSiteName);
                if (siteConfig != null)
                {
                    site.GetWebSiteConfig()
                        .Update(AppServiceModelConverter.ToSiteConfigData(siteConfig));
                }
                if (appSettings != null)
                {
                    site.UpdateApplicationSettings(
                        AppServiceModelConverter.ToAppSettings(appSettings));
                }
                if (connectionStrings != null)
                {
                    site.UpdateConnectionStrings(
                        AppServiceModelConverter.ToConnectionStringDictionary(
                            connectionStrings));
                }
                if (azureStorageSettings != null)
                {
                    site.UpdateAzureStorageAccounts(
                        AppServiceModelConverter.ToAzureStoragePropertyDictionary(
                            azureStorageSettings));
                }
            }
        }

        public void GetWebAppConfiguration(
            string resourceGroupName,
            string webSiteName,
            string slotName,
            Site site,
            bool ignoreError = true)
        {
            bool useSlot = ShouldUseSlot(webSiteName, slotName);
            if (useSlot)
            {
                WebSiteSlotResource slot =
                    GetSlotResource(resourceGroupName, webSiteName, slotName);
                site.SiteConfig = AppServiceModelConverter.FromSiteConfigData(
                    slot.GetWebSiteSlotConfig().Get().Value.Data);
                PopulateConfigurationValues(
                    site.SiteConfig,
                    () => slot.GetApplicationSettingsSlot().Value,
                    () => slot.GetConnectionStringsSlot().Value,
                    ignoreError);
            }
            else
            {
                WebSiteResource resource =
                    GetSiteResource(resourceGroupName, webSiteName);
                site.SiteConfig = AppServiceModelConverter.FromSiteConfigData(
                    resource.GetWebSiteConfig().Get().Value.Data);
                PopulateConfigurationValues(
                    site.SiteConfig,
                    () => resource.GetApplicationSettings().Value,
                    () => resource.GetConnectionStrings().Value,
                    ignoreError);
            }
        }

        public AzureStoragePropertyDictionaryResource GetAzureStorageAccounts(
            string resourceGroupName,
            string webSiteName,
            string slotName,
            bool useSlot)
        {
            try
            {
                AzureStoragePropertyDictionary data = useSlot
                    ? GetSlotResource(resourceGroupName, webSiteName, slotName)
                        .GetAzureStorageAccountsSlot()
                        .Value
                    : GetSiteResource(resourceGroupName, webSiteName)
                        .GetAzureStorageAccounts()
                        .Value;
                return AppServiceModelConverter.FromAzureStoragePropertyDictionary(data);
            }
            catch (RequestFailedException exception)
                when (exception.Status == 403 ||
                      exception.Status == 404 ||
                      exception.Status == 409)
            {
                return null;
            }
        }

        public IList<SiteConfigurationSnapshotInfo> GetWebAppConfigurationSnapshots(
            string resourceGroupName,
            string webSiteName,
            string slotName)
        {
            return ShouldUseSlot(webSiteName, slotName)
                ? GetSlotResource(resourceGroupName, webSiteName, slotName)
                    .GetWebSiteSlotConfig()
                    .GetConfigurationSnapshotInfoSlot()
                    .Select(
                        AppServiceModelConverter.FromSiteConfigurationSnapshotInfo)
                    .ToList()
                : GetSiteResource(resourceGroupName, webSiteName)
                    .GetWebSiteConfig()
                    .GetConfigurationSnapshotInfo()
                    .Select(
                        AppServiceModelConverter.FromSiteConfigurationSnapshotInfo)
                    .ToList();
        }

        public BackupRequest GetWebAppBackupConfiguration(
            string resourceGroupName,
            string webSiteName,
            string slotName)
        {
            WebAppBackupInfo info = ShouldUseSlot(webSiteName, slotName)
                ? GetSlotResource(resourceGroupName, webSiteName, slotName)
                    .GetBackupConfigurationSlot()
                    .Value
                : GetSiteResource(resourceGroupName, webSiteName)
                    .GetBackupConfiguration()
                    .Value;
            return AppServiceModelConverter.FromWebAppBackupInfo(info);
        }

        public BackupRequest UpdateWebAppBackupConfiguration(
            string resourceGroupName,
            string webSiteName,
            string slotName,
            BackupRequest newSchedule)
        {
            WebAppBackupInfo info = ShouldUseSlot(webSiteName, slotName)
                ? GetSlotResource(resourceGroupName, webSiteName, slotName)
                    .UpdateBackupConfigurationSlot(
                        AppServiceModelConverter.ToWebAppBackupInfo(newSchedule))
                    .Value
                : GetSiteResource(resourceGroupName, webSiteName)
                    .UpdateBackupConfiguration(
                        AppServiceModelConverter.ToWebAppBackupInfo(newSchedule))
                    .Value;
            return AppServiceModelConverter.FromWebAppBackupInfo(info);
        }

        public BackupItem BackupSite(
            string resourceGroupName,
            string webSiteName,
            string slotName,
            BackupRequest request)
        {
            WebAppBackupData data = ShouldUseSlot(webSiteName, slotName)
                ? GetSlotResource(resourceGroupName, webSiteName, slotName)
                    .BackupSlot(AppServiceModelConverter.ToWebAppBackupInfo(request))
                    .Value
                : GetSiteResource(resourceGroupName, webSiteName)
                    .Backup(AppServiceModelConverter.ToWebAppBackupInfo(request))
                    .Value;
            return AppServiceModelConverter.FromWebAppBackupData(data);
        }

        public IList<BackupItem> ListSiteBackups(
            string resourceGroupName,
            string webSiteName,
            string slotName)
        {
            return ShouldUseSlot(webSiteName, slotName)
                ? GetSlotResource(resourceGroupName, webSiteName, slotName)
                    .GetSiteSlotBackups()
                    .GetAll()
                    .Select(item =>
                        AppServiceModelConverter.FromWebAppBackupData(item.Data))
                    .ToList()
                : GetSiteResource(resourceGroupName, webSiteName)
                    .GetSiteBackups()
                    .GetAll()
                    .Select(item =>
                        AppServiceModelConverter.FromWebAppBackupData(item.Data))
                    .ToList();
        }

        public BackupItem GetSiteBackupStatus(
            string resourceGroupName,
            string webSiteName,
            string slotName,
            string backupId)
        {
            JObject response = SendArmRequest(
                HttpMethod.Get,
                GetSiteBackupPath(
                    resourceGroupName,
                    webSiteName,
                    slotName,
                    backupId));
            return AppServiceModelConverter.FromWebAppBackupJson(response);
        }

        public BackupItem GetSiteBackupStatusSecrets(
            string resourceGroupName,
            string webSiteName,
            string slotName,
            string backupId)
        {
            WebAppBackupData data = ShouldUseSlot(webSiteName, slotName)
                ? GetSlotResource(resourceGroupName, webSiteName, slotName)
                    .GetSiteSlotBackup(backupId)
                    .Value
                    .GetBackupStatusSecretsSlot(EmptyBackupInfo)
                    .Value
                    .Data
                : GetSiteResource(resourceGroupName, webSiteName)
                    .GetSiteBackup(backupId)
                    .Value
                    .GetBackupStatusSecrets(EmptyBackupInfo)
                    .Value
                    .Data;
            return AppServiceModelConverter.FromWebAppBackupData(data);
        }

        public BackupItem DeleteBackup(
            string resourceGroupName,
            string webSiteName,
            string slotName,
            string backupId)
        {
            BackupItem backup =
                GetSiteBackupStatus(resourceGroupName, webSiteName, slotName, backupId);
            if (ShouldUseSlot(webSiteName, slotName))
            {
                GetSlotResource(resourceGroupName, webSiteName, slotName)
                    .GetSiteSlotBackup(backupId)
                    .Value
                    .Delete(WaitUntil.Completed);
            }
            else
            {
                GetSiteResource(resourceGroupName, webSiteName)
                    .GetSiteBackup(backupId)
                    .Value
                    .Delete(WaitUntil.Completed);
            }
            return backup;
        }

        public void RestoreSite(
            string resourceGroupName,
            string webSiteName,
            string slotName,
            string backupId,
            RestoreRequest request)
        {
            RestoreRequestInfo info =
                AppServiceModelConverter.ToRestoreRequestInfo(request);
            RestoreSiteCore(
                WrappedWebsitesClient,
                subscriptionId,
                resourceGroupName,
                webSiteName,
                slotName,
                backupId,
                info);
        }

        internal static void RestoreSiteCore(
            ArmClient client,
            string subscriptionId,
            string resourceGroupName,
            string webSiteName,
            string slotName,
            string backupId,
            RestoreRequestInfo info)
        {
            if (ShouldUseSlot(webSiteName, slotName))
            {
                client.GetSiteSlotBackupResource(
                        SiteSlotBackupResource.CreateResourceIdentifier(
                            subscriptionId,
                            resourceGroupName,
                            webSiteName,
                            slotName,
                            backupId))
                    .RestoreSlot(WaitUntil.Completed, info);
            }
            else
            {
                client.GetSiteBackupResource(
                        SiteBackupResource.CreateResourceIdentifier(
                            subscriptionId,
                            resourceGroupName,
                            webSiteName,
                            backupId))
                    .Restore(WaitUntil.Completed, info);
            }
        }

        public IList<Snapshot> GetSiteSnapshots(
            string resourceGroupName,
            string webSiteName,
            string slotName,
            bool useDrSecondary)
        {
            if (ShouldUseSlot(webSiteName, slotName))
            {
                WebSiteSlotResource slot =
                    GetSlotResource(resourceGroupName, webSiteName, slotName);
                return (useDrSecondary
                        ? slot.GetSlotSnapshotsFromDRSecondary()
                        : slot.GetSlotSnapshots())
                    .Select(AppServiceModelConverter.FromAppSnapshot)
                    .ToList();
            }

            WebSiteResource site = GetSiteResource(resourceGroupName, webSiteName);
            return (useDrSecondary
                    ? site.GetSnapshotsFromDRSecondary()
                    : site.GetSnapshots())
                .Select(AppServiceModelConverter.FromAppSnapshot)
                .ToList();
        }

        public void RestoreSnapshot(
            string resourceGroupName,
            string webSiteName,
            string slotName,
            SnapshotRestoreRequest restoreReq)
        {
            var request =
                AppServiceModelConverter.ToSnapshotRestoreRequest(restoreReq);
            if (ShouldUseSlot(webSiteName, slotName))
            {
                GetSlotResource(resourceGroupName, webSiteName, slotName)
                    .RestoreSnapshotSlot(WaitUntil.Completed, request);
            }
            else
            {
                GetSiteResource(resourceGroupName, webSiteName)
                    .RestoreSnapshot(WaitUntil.Completed, request);
            }
        }

        public IList<DeletedSite> GetDeletedSitesFromLocations(
            IEnumerable<string> locations)
        {
            var deletedSites = new List<DeletedSite>();
            foreach (string location in locations)
            {
                string nextLink =
                    $"subscriptions/{Uri.EscapeDataString(subscriptionId)}" +
                    "/providers/Microsoft.Web/locations/" +
                    $"{Uri.EscapeDataString(location)}/deletedSites" +
                    $"?api-version={ApiVersion}";
                while (!string.IsNullOrEmpty(nextLink))
                {
                    JObject page = SendArmRequest(HttpMethod.Get, nextLink);
                    deletedSites.AddRange(
                        AppServiceModelConverter.FromDeletedSitesJson(page));
                    nextLink = page.Value<string>("nextLink");
                }
            }
            return deletedSites;
        }

        public void RestoreDeletedWebApp(
            string resourceGroupName,
            string webSiteName,
            string slotName,
            DeletedAppRestoreRequest restoreReq)
        {
            DeletedAppRestoreContent content =
                AppServiceModelConverter.ToDeletedAppRestoreContent(restoreReq);
            if (ShouldUseSlot(webSiteName, slotName))
            {
                GetSlotResource(resourceGroupName, webSiteName, slotName)
                    .RestoreFromDeletedAppSlot(WaitUntil.Started, content);
            }
            else
            {
                GetSiteResource(resourceGroupName, webSiteName)
                    .RestoreFromDeletedApp(WaitUntil.Started, content);
            }
        }

        public Certificate CreateCertificate(
            string resourceGroupName,
            string certificateName,
            Certificate certificate)
        {
            bool isManagedCertificate =
                !string.IsNullOrEmpty(certificate.CanonicalName) &&
                certificate.PfxBlob == null &&
                string.IsNullOrEmpty(certificate.KeyVaultId);
            var operation = GetResourceGroup(resourceGroupName)
                .GetAppCertificates()
                .CreateOrUpdate(
                    isManagedCertificate
                        ? WaitUntil.Started
                        : WaitUntil.Completed,
                    certificateName,
                    AppServiceModelConverter.ToAppCertificateData(certificate));
            if (operation.HasCompleted)
            {
                return AppServiceModelConverter.FromAppCertificateData(
                    operation.Value.Data);
            }

            BinaryData responseContent = operation.GetRawResponse().Content;
            return responseContent == null ||
                   responseContent.ToMemory().IsEmpty
                ? certificate
                : AppServiceModelConverter.FromAppCertificateJson(
                    JObject.Parse(responseContent.ToString()));
        }

        public Certificate GetCertificate(
            string resourceGroupName,
            string certificateName)
        {
            JObject response = SendArmRequest(
                HttpMethod.Get,
                $"subscriptions/{Uri.EscapeDataString(subscriptionId)}" +
                $"/resourceGroups/{Uri.EscapeDataString(resourceGroupName)}" +
                "/providers/Microsoft.Web/certificates/" +
                $"{Uri.EscapeDataString(certificateName)}" +
                $"?api-version={ApiVersion}");
            return AppServiceModelConverter.FromAppCertificateJson(response);
        }

        public IEnumerable<Certificate> ListCertificates()
        {
            return GetSubscription()
                .GetAppCertificates()
                .Select(item =>
                    AppServiceModelConverter.FromAppCertificateData(item.Data))
                .ToList();
        }

        public HttpStatusCode RemoveCertificate(
            string resourceGroupName,
            string certificateName)
        {
            WrappedWebsitesClient
                .GetAppCertificateResource(
                    AppCertificateResource.CreateResourceIdentifier(
                        subscriptionId,
                        resourceGroupName,
                        certificateName))
                .Delete(WaitUntil.Completed);
            return HttpStatusCode.OK;
        }

        public Site UpdateHostNameSslState(
            string resourceGroupName,
            string webAppName,
            string slotName,
            string location,
            string hostName,
            SslState sslState,
            string thumbPrint)
        {
            Site webApp = GetWebApp(resourceGroupName, webAppName, slotName);
            if (webApp.HostNameSslStates == null)
            {
                webApp.HostNameSslStates = new List<HostNameSslState>();
            }
            HostNameSslState binding = webApp.HostNameSslStates.FirstOrDefault(
                item => string.Equals(
                    item.Name,
                    hostName,
                    StringComparison.OrdinalIgnoreCase));
            if (binding == null)
            {
                binding = new HostNameSslState { Name = hostName };
                webApp.HostNameSslStates.Add(binding);
            }
            binding.Thumbprint = thumbPrint;
            binding.ToUpdate = true;
            binding.SslState = sslState;

            WebSiteData data;
            if (ShouldUseSlot(webAppName, slotName))
            {
                data = GetSiteResource(resourceGroupName, webAppName)
                    .GetWebSiteSlots()
                    .CreateOrUpdate(
                        WaitUntil.Completed,
                        slotName,
                        AppServiceModelConverter.ToWebSiteData(webApp))
                    .Value
                    .Data;
            }
            else
            {
                data = GetResourceGroup(resourceGroupName)
                    .GetWebSites()
                    .CreateOrUpdate(
                        WaitUntil.Completed,
                        webAppName,
                        AppServiceModelConverter.ToWebSiteData(webApp))
                    .Value
                    .Data;
            }
            return AppServiceModelConverter.FromWebSiteData(data);
        }

        public CompatSlotConfigNamesResource GetSlotConfigNames(
            string resourceGroupName,
            string webSiteName)
        {
            JObject response = SendArmRequest(
                HttpMethod.Get,
                GetSlotConfigNamesPath(resourceGroupName, webSiteName));
            return AppServiceModelConverter.FromSlotConfigNamesJson(response);
        }

        public CompatSlotConfigNamesResource SetSlotConfigNames(
            string resourceGroupName,
            string webSiteName,
            IList<string> appSettingNames,
            IList<string> connectionStringNames)
        {
            CompatSlotConfigNamesResource names =
                GetSlotConfigNames(resourceGroupName, webSiteName);
            if (appSettingNames != null)
            {
                names.AppSettingNames = appSettingNames;
            }
            if (connectionStringNames != null)
            {
                names.ConnectionStringNames = connectionStringNames;
            }

            JObject response = SendArmRequest(
                HttpMethod.Put,
                GetSlotConfigNamesPath(resourceGroupName, webSiteName),
                AppServiceModelConverter.ToSlotConfigNamesJson(names));
            return AppServiceModelConverter.FromSlotConfigNamesJson(response);
        }

        public void SwapSlot(
            string resourceGroupName,
            string webSiteName,
            string sourceSlotName,
            string destinationSlotName,
            bool? preserveVnet)
        {
            GetSlotResource(resourceGroupName, webSiteName, sourceSlotName)
                .SwapSlot(
                    WaitUntil.Completed,
                    new ArmCsmSlotEntity(
                        destinationSlotName,
                        preserveVnet.GetValueOrDefault()));
        }

        public void SwapSlotWithPreviewApplySlotConfig(
            string resourceGroupName,
            string webSiteName,
            string sourceSlotName,
            string destinationSlotName,
            bool? preserveVnet)
        {
            GetSlotResource(resourceGroupName, webSiteName, sourceSlotName)
                .ApplySlotConfigurationSlot(
                    new ArmCsmSlotEntity(
                        destinationSlotName,
                        preserveVnet.GetValueOrDefault()));
        }

        public void SwapSlotWithPreviewResetSlotSwap(
            string resourceGroupName,
            string webSiteName,
            string sourceSlotName)
        {
            GetSlotResource(resourceGroupName, webSiteName, sourceSlotName)
                .ResetSlotConfigurationSlot();
        }

        public IAccessToken GetAccessToken(IAzureContext context)
        {
            string tenant = null;
            if (context.Subscription != null && context.Account != null)
            {
                tenant = context.Subscription
                    .GetPropertyAsArray(AzureSubscription.Property.Tenants)
                    .Intersect(
                        context.Account.GetPropertyAsArray(
                            AzureAccount.Property.Tenants))
                    .FirstOrDefault();
            }
            if (tenant == null &&
                context.Tenant != null &&
                Guid.TryParse(context.Tenant.Id, out Guid tenantId) &&
                tenantId != Guid.Empty)
            {
                tenant = context.Tenant.Id;
            }

            return AzureSession.Instance.AuthenticationFactory.Authenticate(
                context.Account,
                context.Environment,
                tenant,
                null,
                ShowDialog.Never,
                null,
                context.Environment.GetTokenAudience(
                    AzureEnvironment.Endpoint.ResourceManager));
        }

        public CompatAppServiceEnvironmentResource GetAppServiceEnvironment(
            string resourceGroupName,
            string aseName)
        {
            return AppServiceModelConverter.FromAppServiceEnvironmentData(
                GetResourceGroup(resourceGroupName)
                    .GetAppServiceEnvironments()
                    .Get(aseName)
                    .Value
                    .Data);
        }

        public AddressResponse GetAppServiceEnvironmentAddresses(
            string resourceGroupName,
            string aseName)
        {
            return AppServiceModelConverter.FromAppServiceEnvironmentAddressResult(
                GetResourceGroup(resourceGroupName)
                    .GetAppServiceEnvironments()
                    .Get(aseName)
                    .Value
                    .GetVipInfo()
                    .Value);
        }

        public CompatAppServiceEnvironmentResource CreateAppServiceEnvironment(
            string resourceGroupName,
            string aseName,
            CompatAppServiceEnvironmentResource appServiceEnvironment)
        {
            AppServiceEnvironmentData data = GetResourceGroup(resourceGroupName)
                .GetAppServiceEnvironments()
                .CreateOrUpdate(
                    WaitUntil.Completed,
                    aseName,
                    AppServiceModelConverter.ToAppServiceEnvironmentData(
                        appServiceEnvironment))
                .Value
                .Data;
            return AppServiceModelConverter.FromAppServiceEnvironmentData(data);
        }

        public void RemoveAppServiceEnvironment(
            string resourceGroupName,
            string aseName)
        {
            GetResourceGroup(resourceGroupName)
                .GetAppServiceEnvironments()
                .Get(aseName)
                .Value
                .Delete(WaitUntil.Completed);
        }

        private ResourceGroupResource GetResourceGroup(string resourceGroupName)
        {
            return WrappedWebsitesClient.GetResourceGroupResource(
                ResourceGroupResource.CreateResourceIdentifier(
                    subscriptionId,
                    resourceGroupName));
        }

        private SubscriptionResource GetSubscription()
        {
            return WrappedWebsitesClient.GetSubscriptionResource(
                SubscriptionResource.CreateResourceIdentifier(subscriptionId));
        }

        private WebSiteResource GetSiteResource(
            string resourceGroupName,
            string webSiteName)
        {
            return WrappedWebsitesClient.GetWebSiteResource(
                WebSiteResource.CreateResourceIdentifier(
                    subscriptionId,
                    resourceGroupName,
                    webSiteName));
        }

        private WebSiteSlotResource GetSlotResource(
            string resourceGroupName,
            string webSiteName,
            string slotName)
        {
            return WrappedWebsitesClient.GetWebSiteSlotResource(
                WebSiteSlotResource.CreateResourceIdentifier(
                    subscriptionId,
                    resourceGroupName,
                    webSiteName,
                    slotName));
        }

        private AppServicePlanResource GetAppServicePlanResource(
            string resourceGroupName,
            string appServicePlanName)
        {
            return WrappedWebsitesClient.GetAppServicePlanResource(
                AppServicePlanResource.CreateResourceIdentifier(
                    subscriptionId,
                    resourceGroupName,
                    appServicePlanName));
        }

        private string GetSlotConfigNamesPath(
            string resourceGroupName,
            string webSiteName)
        {
            return $"subscriptions/{Uri.EscapeDataString(subscriptionId)}" +
                   $"/resourceGroups/{Uri.EscapeDataString(resourceGroupName)}" +
                   "/providers/Microsoft.Web/sites/" +
                   $"{Uri.EscapeDataString(webSiteName)}/config/slotConfigNames" +
                   $"?api-version={ApiVersion}";
        }

        private string GetSiteBackupPath(
            string resourceGroupName,
            string webSiteName,
            string slotName,
            string backupId)
        {
            string sitePath =
                $"subscriptions/{Uri.EscapeDataString(subscriptionId)}" +
                $"/resourceGroups/{Uri.EscapeDataString(resourceGroupName)}" +
                "/providers/Microsoft.Web/sites/" +
                Uri.EscapeDataString(webSiteName);
            if (ShouldUseSlot(webSiteName, slotName))
            {
                sitePath += $"/slots/{Uri.EscapeDataString(slotName)}";
            }
            return sitePath +
                   $"/backups/{Uri.EscapeDataString(backupId)}" +
                   $"?api-version={ApiVersion}";
        }

        private JObject SendArmRequest(
            HttpMethod method,
            string requestUri,
            JObject content = null)
        {
            Uri uri = Uri.TryCreate(requestUri, UriKind.Absolute, out Uri absoluteUri)
                ? absoluteUri
                : new Uri(resourceManagerEndpoint, requestUri.TrimStart('/'));
            using (var request = new HttpRequestMessage(method, uri))
            {
                AccessToken token = tokenCredential.GetToken(
                    new TokenRequestContext(Array.Empty<string>()),
                    default);
                request.Headers.Authorization =
                    new AuthenticationHeaderValue("Bearer", token.Token);
                request.Headers.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                if (content != null)
                {
                    request.Content = new StringContent(
                        content.ToString(Formatting.None),
                        Encoding.UTF8,
                        "application/json");
                }

                using (HttpResponseMessage response = httpClient
                           .SendAsync(request)
                           .GetAwaiter()
                           .GetResult())
                {
                    string responseBody = response.Content == null
                        ? null
                        : response.Content
                            .ReadAsStringAsync()
                            .GetAwaiter()
                            .GetResult();
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new RequestFailedException(
                            (int)response.StatusCode,
                            string.IsNullOrEmpty(responseBody)
                                ? response.ReasonPhrase
                                : responseBody);
                    }

                    return string.IsNullOrWhiteSpace(responseBody)
                        ? new JObject()
                        : JObject.Parse(responseBody);
                }
            }
        }

        internal static string ResolveAppServicePlanId(
            string subscriptionId,
            string resourceGroupName,
            string appServicePlan)
        {
            if (string.IsNullOrEmpty(resourceGroupName) ||
                appServicePlan.StartsWith("/", StringComparison.Ordinal))
            {
                return appServicePlan;
            }

            return AppServicePlanResource.CreateResourceIdentifier(
                    subscriptionId,
                    resourceGroupName,
                    appServicePlan)
                .ToString();
        }

        private static HttpClient CreateHttpClient(
            string endpoint,
            AppServiceTokenCredential tokenCredential)
        {
            var clientFactory = AzureSession.Instance.ClientFactory;
            HttpMessageHandler pipeline = new HttpClientHandler();
            pipeline = new AppServiceClaimsChallengeHandler(tokenCredential)
            {
                InnerHandler = pipeline
            };
            foreach (DelegatingHandler handler in
                     clientFactory.GetCustomHandlers().Reverse())
            {
                handler.InnerHandler = pipeline;
                pipeline = handler;
            }
            return clientFactory.CreateHttpClient(endpoint, pipeline);
        }

        private static bool ShouldUseSlot(string webSiteName, string slotName)
        {
            return CmdletHelpers.ShouldUseDeploymentSlot(
                webSiteName,
                slotName,
                out string qualifiedSiteName);
        }

        internal static PublishingProfileFormat? ParsePublishingProfileFormat(
            string format)
        {
            if (string.IsNullOrEmpty(format))
            {
                return null;
            }
            return new PublishingProfileFormat(format);
        }

        private static void PopulateConfigurationValues(
            SiteConfig siteConfig,
            Func<AppServiceConfigurationDictionary> getAppSettings,
            Func<ConnectionStringDictionary> getConnectionStrings,
            bool ignoreError)
        {
            try
            {
                AppServiceConfigurationDictionary appSettings = getAppSettings();
                siteConfig.AppSettings = appSettings.Properties
                    .Select(item => new NameValuePair(item.Key, item.Value))
                    .ToList();
                ConnectionStringDictionary connectionStrings = getConnectionStrings();
                siteConfig.ConnectionStrings =
                    AppServiceModelConverter
                        .FromConnectionStringDictionary(connectionStrings)
                        .Values
                        .ToList();
            }
            catch (RequestFailedException) when (ignoreError)
            {
            }
        }

        private void WriteVerbose(string verboseFormat, params object[] args)
        {
            VerboseLogger?.Invoke(string.Format(verboseFormat, args));
        }

        private void WriteWarning(string warningFormat, params object[] args)
        {
            WarningLogger?.Invoke(string.Format(warningFormat, args));
        }

        private void WriteError(string errorFormat, params object[] args)
        {
            ErrorLogger?.Invoke(string.Format(errorFormat, args));
        }
    }
}
