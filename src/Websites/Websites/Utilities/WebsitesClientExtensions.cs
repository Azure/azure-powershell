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

using Microsoft.Azure.Management.WebSites;
using Microsoft.Azure.Management.WebSites.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Microsoft.Azure.Management.WebSites
{
    public static class WebsitesClientExtensions
    {
#if !NETSTANDARD
        public static IWebAppsOperations WebApps(this WebSiteManagementClient client)
        {
            return client.WebApps;
        }

        public static IDeletedWebAppsOperations DeletedWebApps(this WebSiteManagementClient client)
        {
            return client.DeletedWebApps;
        }

        public static IAppServicePlansOperations AppServicePlans(this WebSiteManagementClient client)
        {
            return client.AppServicePlans;
        }
         
        public static string ApiVersion(this WebSiteManagementClient client)
        {
            return client.ApiVersion();
        }
        
        public static ICertificatesOperations Certificates(this WebSiteManagementClient client)
        {
            return client.Certificates;
        }

#else
        public static void Save(this System.Xml.Linq.XDocument xdoc, string fileName, System.Xml.Linq.SaveOptions options)
        {
            using (var fileStream = System.IO.File.Create(fileName))
            {
                xdoc.Save(fileStream, options);
            }
        }

        public static IEnumerable<BackupItem> Value(this IEnumerable<BackupItem> backupItems)
        {
            return backupItems;
        }

        public static IEnumerable<ResourceMetric> Value(this IEnumerable<ResourceMetric> resources)
        {
            return resources;
        }

        public static IEnumerable<Site> Value(this IEnumerable<Site> sites)
        {
            return sites;
        }

        public static IEnumerable<AppServicePlan> Value(this IEnumerable<AppServicePlan> plan)
        {
            return plan;
        }

        public static string ApiVersion(this WebSiteManagementClient client)
        {
            return "2016-08-01";
        }

        public static IWebAppsOperations WebApps(this WebSiteManagementClient client)
        {
            return client.WebApps;
        }

        public static Site CreateOrUpdateSiteSlot(this IWebAppsOperations webApp,
            string resourceGroupName, 
            string name, 
            Site siteEnvelope, 
            string slot, 
            bool? skipDnsRegistration = default(bool?), 
            bool? skipCustomDomainVerification = default(bool?), 
            bool? forceDnsRegistration = default(bool?), 
            string ttlInSeconds = null)
        {
            return webApp.CreateOrUpdateSlot(resourceGroupName,
                name,
                siteEnvelope,
                slot,
                skipDnsRegistration,
                skipCustomDomainVerification,
                forceDnsRegistration,
                ttlInSeconds);
        }

        public static Site CreateOrUpdateSite(this IWebAppsOperations webApp,
            string resourceGroupName, 
            string name, 
            Site siteEnvelope, 
            bool? skipDnsRegistration = default(bool?), 
            bool? skipCustomDomainVerification = default(bool?), 
            bool? forceDnsRegistration = default(bool?), 
            string ttlInSeconds = null)
        {
            return webApp.CreateOrUpdate(
                resourceGroupName,
                name,
                siteEnvelope,
                skipDnsRegistration,
                skipCustomDomainVerification,
                forceDnsRegistration,
                ttlInSeconds);
        }

        public static Site GetSiteSlot(this IWebAppsOperations webApp, 
            string resourceGroupName, 
            string name, 
            string slot)
        {
            return webApp.GetSlot(resourceGroupName, name, slot);
        }

        public static Site GetSite(this IWebAppsOperations webApp, string resourceGroupName, string name)
        {
            return webApp.Get(resourceGroupName, name);
        }

        public static IEnumerable<Site> GetSites(this IWebAppsOperations webApp, string resourceGroupName)
        {
            return webApp.ListByResourceGroup(resourceGroupName);
        }

        public static IEnumerable<Site> GetSiteSlots(this IWebAppsOperations webApp,
            string resourceGroupName, string name)
        {
            return webApp.ListSlots(resourceGroupName, name);
        }

        public static HostNameBinding CreateOrUpdateSiteHostNameBinding(this IWebAppsOperations webApp,
            string resourceGroupName, string name, string hostName, HostNameBinding hostNameBinding)
        {
            return webApp.CreateOrUpdateHostNameBinding(resourceGroupName, name, hostName, hostNameBinding);
        }

        public static void DeleteSiteHostNameBinding(this IWebAppsOperations webApp,
            string resourceGroupName, string name, string hostName)
        {
            webApp.DeleteHostNameBinding(resourceGroupName, name, hostName);
        }

        public static void StartSiteSlot(this IWebAppsOperations webApp, 
            string resourceGroupName, 
            string name, 
            string slot)
        {
            webApp.StartSlot(resourceGroupName, name, slot);
        }

        public static void StartSite(this IWebAppsOperations webApp, string resourceGroupName, string name)
        {
            webApp.Start(resourceGroupName, name);
        }
        public static void RestartSiteSlot(this IWebAppsOperations webApp,
            string resourceGroupName,
            string name,
            string slot)
        {
            webApp.RestartSlot(resourceGroupName, name, slot);
        }

        public static void RestartSite(this IWebAppsOperations webApp, string resourceGroupName, string name)
        {
            webApp.Restart(resourceGroupName, name);
        }

        public static void StopSiteSlot(this IWebAppsOperations webApp,
            string resourceGroupName,
            string name,
            string slot)
        {
            webApp.StopSlot(resourceGroupName, name, slot);
        }

        public static void StopSite(this IWebAppsOperations webApp, string resourceGroupName, string name)
        {
            webApp.Stop(resourceGroupName, name);
        }

        public static void DeleteSiteSlot(this IWebAppsOperations webApp,
            string resourceGroupName,
            string name,
            string slot,
            string deleteMetrics = null,
            string deleteEmptyServerFarm = null,
            string deleteAllSlots = null)
        {
            webApp.DeleteSlot(resourceGroupName,
                name,
                slot,
                deleteMetrics.ToNullableBool(),
                deleteEmptyServerFarm.ToNullableBool(),
                deleteAllSlots.ToNullableBool());
        }

        public static void DeleteSite(this IWebAppsOperations webApp,
            string resourceGroupName, 
            string name,
            string deleteMetrics = null,
            string deleteEmptyServerFarm = null,
            string deleteAllSlots = null)
        {
            webApp.Delete(
                resourceGroupName, 
                name,
                deleteMetrics.ToNullableBool(),
                deleteEmptyServerFarm.ToNullableBool(),
                deleteAllSlots.ToNullableBool());
        }

        public static Stream ListSitePublishingProfileXmlSlot(this IWebAppsOperations webApp,
            string resourceGroupName, 
            string name, 
            CsmPublishingProfileOptions publishingProfileOptions, 
            string slot)
        {
            return webApp.ListPublishingProfileXmlWithSecretsSlot(resourceGroupName,
            name,
            publishingProfileOptions,
            slot);
        }

        public static Stream ListSitePublishingProfileXml(this IWebAppsOperations webApp,
            string resourceGroupName, 
            string name, 
            CsmPublishingProfileOptions publishingProfileOptions)
        {
            return webApp.ListPublishingProfileXmlWithSecrets(resourceGroupName, name, publishingProfileOptions);
        }

        public static IEnumerable<ResourceMetric> GetSiteMetrics(this IWebAppsOperations webApp,
            string resourceGroupName, 
            string name, 
            bool? details = default(bool?), 
            string filter = null)
        {
            return webApp.ListMetrics(resourceGroupName, name, details, filter);
        }

        public static IEnumerable<ResourceMetric> GetSiteMetricsSlot(this IWebAppsOperations webApp,
            string resourceGroupName, 
            string name, 
            string slot, 
            bool? details = default(bool?), 
            string filter = null)
        {
            return webApp.ListMetricsSlot(resourceGroupName, name, slot, details, filter);
        }

        public static SiteConfigResource UpdateSiteConfigSlot(this IWebAppsOperations webApp,
            string resourceGroupName, 
            string name, 
            SiteConfigResource siteConfig, 
            string slot)
        {
            return webApp.UpdateConfigurationSlot(resourceGroupName, name, siteConfig, slot);
        }

        public static StringDictionary UpdateSiteAppSettingsSlot(this IWebAppsOperations webApp,
            string resourceGroupName, 
            string name, 
            StringDictionary appSettings, 
            string slot)
        {
            return webApp.UpdateApplicationSettingsSlot(resourceGroupName, name, appSettings, slot);
        }
        
        public static ConnectionStringDictionary UpdateSiteConnectionStringsSlot(this IWebAppsOperations webApp,
            string resourceGroupName, string name, ConnectionStringDictionary connectionStrings, string slot)
        {
            return webApp.UpdateConnectionStringsSlot(resourceGroupName, name, connectionStrings, slot);
        }

        public static SiteConfigResource UpdateSiteConfig(this IWebAppsOperations webApp,
            string resourceGroupName, string name, SiteConfigResource siteConfig)
        {
            return webApp.UpdateConfiguration(resourceGroupName, name, siteConfig);
        }

        public static StringDictionary UpdateSiteAppSettings(this IWebAppsOperations webApp,
            string resourceGroupName, string name, StringDictionary appSettings)
        {
            return webApp.UpdateApplicationSettings(resourceGroupName, name, appSettings);
        }

        public static ConnectionStringDictionary UpdateSiteConnectionStrings(this IWebAppsOperations webApp,
            string resourceGroupName, 
            string name, 
            ConnectionStringDictionary connectionStrings)
        {
            return webApp.UpdateConnectionStrings(resourceGroupName, name, connectionStrings);
        }

        public static SiteConfigResource GetSiteConfigSlot(this IWebAppsOperations webApp,
            string resourceGroupName, string name, string slot)
        {
            return webApp.GetConfigurationSlot(resourceGroupName, name, slot);
        }

        public static SiteConfigResource GetSiteConfig(this IWebAppsOperations webApp,
            string resourceGroupName, string name)
        {
            return webApp.GetConfiguration(resourceGroupName, name);
        }

        public static StringDictionary ListSiteAppSettingsSlot(this IWebAppsOperations webApp,
            string resourceGroupName, string name, string slot)
        {
            return webApp.ListApplicationSettingsSlot(resourceGroupName, name, slot);
        }

        public static StringDictionary ListSiteAppSettings(this IWebAppsOperations webApp,
            string resourceGroupName, string name)
        {
            return webApp.ListApplicationSettings(resourceGroupName, name);
        }

        public static ConnectionStringDictionary ListSiteConnectionStringsSlot(this IWebAppsOperations webApp,
            string resourceGroupName, string name, string slot)
        {
            return webApp.ListConnectionStringsSlot(resourceGroupName, name, slot);
        }

        public static ConnectionStringDictionary ListSiteConnectionStrings(this IWebAppsOperations webApp,
            string resourceGroupName, string name)
        {
            return webApp.ListConnectionStrings(resourceGroupName, name);
        }

        public static BackupRequest GetSiteBackupConfigurationSlot(this IWebAppsOperations webApp,
            string resourceGroupName, string name, string slot)
        {
            return webApp.GetBackupConfigurationSlot(resourceGroupName, name, slot);
        }

        public static BackupRequest GetSiteBackupConfiguration(this IWebAppsOperations webApp,
            string resourceGroupName, string name)
        {
            return webApp.GetBackupConfiguration(resourceGroupName, name);
        }

        public static BackupRequest UpdateSiteBackupConfigurationSlot(this IWebAppsOperations webApp,
            string resourceGroupName, string name, BackupRequest request, string slot)
        {
            return webApp.UpdateBackupConfigurationSlot(resourceGroupName, name, request, slot);
        }

        public static BackupRequest UpdateSiteBackupConfiguration(this IWebAppsOperations webApp,
            string resourceGroupName, string name, BackupRequest request)
        {
            return webApp.UpdateBackupConfiguration(resourceGroupName, name, request);
        }

        public static BackupItem BackupSiteSlot(this IWebAppsOperations webApp,
            string resourceGroupName, string name, BackupRequest request, string slot)
        {
            return webApp.BackupSlot(resourceGroupName, name, request, slot);
        }

        public static BackupItem BackupSite(this IWebAppsOperations webApp,
            string resourceGroupName, string name, BackupRequest request)
        {
            return webApp.Backup(resourceGroupName, name, request);
        }

        public static IEnumerable<BackupItem> ListSiteBackupsSlot(this IWebAppsOperations webApp,
            string resourceGroupName, string name, string slot)
        {
            return webApp.ListBackupsSlot(resourceGroupName, name, slot);
        }

        public static IEnumerable<BackupItem> ListSiteBackups(this IWebAppsOperations webApp,
            string resourceGroupName, string name)
        {
            return webApp.ListBackups(resourceGroupName, name);
        }

        public static BackupItem GetSiteBackupStatusSecretsSlot(this IWebAppsOperations webApp,
            string resourceGroupName, string name, string backupId, BackupRequest EmptyRequest, string slot)
        {
            return webApp.GetBackupStatusSlot(resourceGroupName, name, backupId, slot);
        }

        public static BackupItem GetSiteBackupStatusSlot(this IWebAppsOperations webApp, 
            string resourceGroupName, string name, string backupId, string slot)
        {
            return webApp.GetBackupStatusSlot(resourceGroupName, name, backupId, slot);
        }

        public static BackupItem GetSiteBackupStatus(this IWebAppsOperations webApp,
            string resourceGroupName, string name, string backupId)
        {
            return webApp.GetBackupStatus(resourceGroupName, name, backupId);
        }

        public static BackupItem GetSiteBackupStatusSecrets(this IWebAppsOperations webApp,
            string resourceGroupName, string name, string backupId, BackupRequest EmptyRequest)
        {
            return webApp.GetBackupStatus(resourceGroupName, name, backupId);
        }

        public static RestoreResponse RestoreSiteSlot(this IWebAppsOperations webApp,
            string resourceGroupName, string name, string backupId, RestoreRequest request, string slot)
        {
            return webApp.RestoreSlot(resourceGroupName, name, backupId, request, slot);
        }

        public static RestoreResponse RestoreSite(this IWebAppsOperations webApp,
            string resourceGroupName, string name, string backupId, RestoreRequest request)
        {
            return webApp.Restore(resourceGroupName, name, backupId, request);
        }

        public static SlotConfigNamesResource GetSlotConfigNames(this IWebAppsOperations webApp,
            string resourceGroupName, string name)
        {
            return webApp.ListSlotConfigurationNames(resourceGroupName, name);
        }

        public static SlotConfigNamesResource UpdateSlotConfigNames(this IWebAppsOperations webApp,
            string resourceGroupName, string name, SlotConfigNamesResource slotConfigNames)
        {
            return webApp.UpdateSlotConfigurationNames(resourceGroupName, name, slotConfigNames);
        }

        public static void SwapSlotsSlot(this IWebAppsOperations webApp,
            string resourceGroupName, string name, CsmSlotEntity slotSwapEntity, string slot)
        {
            webApp.SwapSlotSlot(resourceGroupName, name, slotSwapEntity, slot);
        }

        public static void ApplySlotConfigSlot(this IWebAppsOperations webApp,
            string resourceGroupName, string name, CsmSlotEntity slotSwapEntity, string slot)
        {
            webApp.ApplySlotConfigurationSlot(resourceGroupName, name, slotSwapEntity, slot);
        }

        public static void ResetSlotConfigSlot(this IWebAppsOperations webApp,
            string resourceGroupName, string name, string slot)
        {
            webApp.ResetSlotConfigurationSlot(resourceGroupName, name, slot);
        }

        public static IAppServicePlansOperations AppServicePlans(this WebSiteManagementClient client)
        {
            return client.AppServicePlans;
        }

        public static IEnumerable<Site> GetServerFarmSites(this IAppServicePlansOperations serverFarm,
            string resourceGroupName, 
            string name, 
            string skipToken = null, 
            string filter = null, 
            string top = null)
        {
            return serverFarm.ListWebApps(resourceGroupName, name, skipToken, filter, top);
        }

        public static AppServicePlan CreateOrUpdateServerFarm(this IAppServicePlansOperations serverFarm,
            string resourceGroupName, 
            string name, 
            AppServicePlan appServicePlan)
        {
            return serverFarm.CreateOrUpdate(resourceGroupName, name, appServicePlan);
        }

        public static void DeleteServerFarm(this IAppServicePlansOperations serverFarm,
            string resourceGroupName, string name)
        {
            serverFarm.Delete(resourceGroupName, name);
        }

        public static AppServicePlan GetServerFarm(this IAppServicePlansOperations serverFarm,
            string resourceGroupName, string name)
        {
            return serverFarm.Get(resourceGroupName, name);
        }

        public static IEnumerable<AppServicePlan> GetServerFarms(this IAppServicePlansOperations serverFarm,
            string resourceGroupName)
        {
            return serverFarm.ListByResourceGroup(resourceGroupName);
        }

        public static IEnumerable<ResourceMetric> GetServerFarmMetrics(this IAppServicePlansOperations serverFarm,
            string resourceGroupName, string name, bool? details = default(bool?), string filter = null)
        {
            return serverFarm.ListMetrics(resourceGroupName, name, details, filter);
        }

        private static bool? ToNullableBool(this string val)
        {
            if(string.IsNullOrWhiteSpace(val))
            {
                return null;
            }

            bool temp;
            if (bool.TryParse(val, out temp))
                return temp;
            else
                return null;
        }

        public static ICertificatesOperations Certificates(this WebSiteManagementClient client)
        {
            return client.Certificates;
        }

        public static Certificate CreateOrUpdateCertificate(this ICertificatesOperations certificate,
            string resourceGroupName, string name, Certificate certificateEnvelope)
        {
            return certificate.CreateOrUpdate(resourceGroupName, name, certificateEnvelope);
        }

        public static Certificate GetCertificate(this ICertificatesOperations certificate, 
            string resourceGroupName, string certificateName)
        {
            return certificate.Get(resourceGroupName, certificateName);
        }

        public static void DeleteCertificate(this ICertificatesOperations certificate,
            string resourceGroupName, string name)
        {
            certificate.Delete(resourceGroupName, name);
        }
#endif
    }
}