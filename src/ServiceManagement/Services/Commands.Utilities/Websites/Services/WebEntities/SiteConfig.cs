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
using System.Runtime.Serialization;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.DeploymentEntities;
using Microsoft.WindowsAzure.Management.WebSites.Models;

namespace Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.WebEntities
{
    public interface ISiteConfig
    {
        int? NumberOfWorkers { get; set; }

        string[] DefaultDocuments { get; set; }

        string NetFrameworkVersion { get; set; }

        string PhpVersion { get; set; }

        bool? RequestTracingEnabled { get; set; }

        bool? HttpLoggingEnabled { get; set; }

        bool? DetailedErrorLoggingEnabled { get; set; }

        Hashtable AppSettings { get; set; }

        List<NameValuePair> Metadata { get; set; }

        ConnStringPropertyBag ConnectionStrings { get; set; }

        HandlerMapping[] HandlerMappings { get; set; }

        bool? AzureDriveTraceEnabled { get; set; }

        LogEntryType AzureDriveTraceLevel { get; set; }

        bool? AzureTableTraceEnabled { get; set; }

        LogEntryType AzureTableTraceLevel { get; set; }

        bool? AzureBlobTraceEnabled { get; set; }

        LogEntryType AzureBlobTraceLevel { get; set; }

        ManagedPipelineMode? ManagedPipelineMode { get; set; }

        bool? WebSocketsEnabled { get; set; }

        bool? RemoteDebuggingEnabled { get; set; }

        string RemoteDebuggingVersion { get; set; }

        List<RoutingRule> RoutingRules { get; set; }

        bool? Use32BitWorkerProcess { get; set; }

        string AutoSwapSlotName { get; set; }
    }

    public class SiteWithConfig : ISite, ISiteConfig
    {
        private Site Site { get; set; }

        private SiteConfig SiteConfig { get; set; }

        private DiagnosticsSettings DiagnosticsSettings { get; set; }

        public WebsiteInstance[] Instances { get; set; }

        public SiteWithConfig()
        {
            Site = new Site();
            SiteConfig = new SiteConfig();
            AppSettings = new Hashtable();
            DiagnosticsSettings = new DiagnosticsSettings();
            Instances = new WebsiteInstance[0];
        }

        public SiteWithConfig(Site site, SiteConfig siteConfig)
        {
            Site = site;
            SiteConfig = siteConfig;
            AppSettings = new Hashtable();
            DiagnosticsSettings = new DiagnosticsSettings();
            Instances = new WebsiteInstance[0];

            if (SiteConfig.AppSettings != null)
            {
                foreach (var setting in SiteConfig.AppSettings)
                {
                    AppSettings[setting.Name] = setting.Value;
                }
            }
        }

        public SiteWithConfig(Site site, SiteConfig siteConfig, DiagnosticsSettings diagnosticsSettings, WebsiteInstance[] instances) :
            this(site, siteConfig)
        {
            DiagnosticsSettings = diagnosticsSettings;
            Instances = instances;
        }

        public SiteConfig GetSiteConfig()
        {
            if (AppSettings != null)
            {
                SiteConfig.AppSettings = new List<NameValuePair>();
                foreach (var setting in AppSettings.Keys)
                {
                    SiteConfig.AppSettings.Add(new NameValuePair
                    {
                        Name = (string)setting,
                        Value = (string)AppSettings[setting]
                    });
                }
            }

            return SiteConfig;
        }

        public Site GetSite()
        {
            return Site;
        }

        public int? NumberOfWorkers
        {
            get { return SiteConfig.NumberOfWorkers; }
            set { SiteConfig.NumberOfWorkers = value; }
        }

        public string[] DefaultDocuments
        {
            get { return SiteConfig.DefaultDocuments; }
            set { SiteConfig.DefaultDocuments = value; }
        }

        public string NetFrameworkVersion
        {
            get { return SiteConfig.NetFrameworkVersion; }
            set { SiteConfig.NetFrameworkVersion = value; }
        }

        public string PhpVersion
        {
            get { return SiteConfig.PhpVersion; }
            set { SiteConfig.PhpVersion = value; }
        }

        public bool? RequestTracingEnabled
        {
            get { return SiteConfig.RequestTracingEnabled; }
            set { SiteConfig.RequestTracingEnabled = value; }
        }

        public bool? HttpLoggingEnabled
        {
            get { return SiteConfig.HttpLoggingEnabled; }
            set { SiteConfig.HttpLoggingEnabled = value; }
        }

        public bool? DetailedErrorLoggingEnabled
        {
            get { return SiteConfig.DetailedErrorLoggingEnabled; }
            set { SiteConfig.DetailedErrorLoggingEnabled = value; }
        }

        public string PublishingUsername
        {
            get { return SiteConfig.PublishingUsername; }
            set { SiteConfig.PublishingUsername = value; }
        }

        public string PublishingPassword
        {
            get { return SiteConfig.PublishingPassword; }
            set { SiteConfig.PublishingPassword = value; }
        }

        public Hashtable AppSettings { get; set; }

        public List<NameValuePair> Metadata
        {
            get { return SiteConfig.Metadata; }
            set { SiteConfig.Metadata = value; }
        }

        public ConnStringPropertyBag ConnectionStrings
        {
            get { return SiteConfig.ConnectionStrings; }
            set { SiteConfig.ConnectionStrings = value; }
        }

        public HandlerMapping[] HandlerMappings
        {
            get { return SiteConfig.HandlerMappings; }
            set { SiteConfig.HandlerMappings = value; }
        }

        public string Name
        {
            get { return Site.Name; }
            set { Site.Name = value; }
        }

        public string State
        {
            get { return Site.State; }
            set { Site.State = value; }
        }

        public string[] HostNames
        {
            get { return Site.HostNames; }
            set { Site.HostNames = value; }
        }

        public string WebSpace
        {
            get { return Site.WebSpace; }
            set { Site.WebSpace = value; }
        }

        public Uri SelfLink
        {
            get { return Site.SelfLink; }
            set { Site.SelfLink = value; }
        }

        public string RepositorySiteName
        {
            get { return Site.RepositorySiteName; }
            set { Site.RepositorySiteName = value; }
        }

        public SkuOptions? Sku
        {
            get { return Site.Sku; }
            set { Site.Sku = value; }
        }

        public UsageState UsageState
        {
            get { return Site.UsageState; }
            set { Site.UsageState = value; }
        }

        public bool? Enabled
        {
            get { return Site.Enabled; }
            set { Site.Enabled = value; }
        }

        public bool? AdminEnabled
        {
            get { return Site.AdminEnabled; }
            set { Site.AdminEnabled = value; }
        }

        public string[] EnabledHostNames
        {
            get { return Site.EnabledHostNames; }
            set { Site.EnabledHostNames = value; }
        }

        public SiteProperties SiteProperties
        {
            get { return Site.SiteProperties; }
            set { Site.SiteProperties = value; }
        }

        public SiteAvailabilityState AvailabilityState
        {
            get { return Site.AvailabilityState; }
            set { Site.AvailabilityState = value; }
        }

        public HostNameSslStates HostNameSslStates
        {
            get { return Site.HostNameSslStates; }
            set { Site.HostNameSslStates = value; }
        }

        public bool? AzureDriveTraceEnabled
        {
            get { return DiagnosticsSettings.AzureDriveTraceEnabled; }
            set { DiagnosticsSettings.AzureDriveTraceEnabled = value; }
        }

        public LogEntryType AzureDriveTraceLevel
        {
            get { return DiagnosticsSettings.AzureDriveTraceLevel; }
            set { DiagnosticsSettings.AzureDriveTraceLevel = value; }
        }

        public bool? AzureTableTraceEnabled
        {
            get { return DiagnosticsSettings.AzureTableTraceEnabled; }
            set { DiagnosticsSettings.AzureTableTraceEnabled = value; }
        }

        public LogEntryType AzureTableTraceLevel
        {
            get { return DiagnosticsSettings.AzureTableTraceLevel; }
            set { DiagnosticsSettings.AzureTableTraceLevel = value; }
        }

        public bool? AzureBlobTraceEnabled
        {
            get { return DiagnosticsSettings.AzureBlobTraceEnabled; }
            set { DiagnosticsSettings.AzureBlobTraceEnabled = value; }
        }

        public LogEntryType AzureBlobTraceLevel
        {
            get { return DiagnosticsSettings.AzureBlobTraceLevel; }
            set { DiagnosticsSettings.AzureBlobTraceLevel = value; }
        }

        public ManagedPipelineMode? ManagedPipelineMode
        {
            get { return SiteConfig.ManagedPipelineMode; }
            set { SiteConfig.ManagedPipelineMode = value; }
        }

        public bool? WebSocketsEnabled
        {
            get { return SiteConfig.WebSocketsEnabled; }
            set { SiteConfig.WebSocketsEnabled = value; }
        }

        public bool? RemoteDebuggingEnabled
        {
            get { return SiteConfig.RemoteDebuggingEnabled; }
            set { SiteConfig.RemoteDebuggingEnabled = value; }
        }

        public string RemoteDebuggingVersion
        {
            get { return SiteConfig.RemoteDebuggingVersion; }
            set { SiteConfig.RemoteDebuggingVersion = value; }
        }

        public List<RoutingRule> RoutingRules
        {
            get { return SiteConfig.RoutingRules; }
            set { SiteConfig.RoutingRules = value; }
        }

        public bool? Use32BitWorkerProcess
        {
            get { return SiteConfig.Use32BitWorkerProcess; }
            set { SiteConfig.Use32BitWorkerProcess = value; }
        }

        public string AutoSwapSlotName
        {
            get { return SiteConfig.AutoSwapSlotName; }
            set { SiteConfig.AutoSwapSlotName = value; }
        }

        public IList<string> SlotStickyAppSettingNames
        {
            get { return SiteConfig.SlotStickyAppSettingNames; }
            set { SiteConfig.SlotStickyAppSettingNames = value; }
        }

        public IList<string> SlotStickyConnectionStringNames
        {
            get { return SiteConfig.SlotStickyConnectionStringNames; }
            set { SiteConfig.SlotStickyConnectionStringNames = value; }
        }
    }

    [DataContract(Namespace = UriElements.ServiceNamespace)]
    public class SiteConfig
    {
        [DataMember(IsRequired = false)]
        public int? NumberOfWorkers { get; set; }

        [DataMember(IsRequired = false)]
        public string[] DefaultDocuments { get; set; }

        [DataMember(IsRequired = false)]
        public string NetFrameworkVersion { get; set; }

        [DataMember(IsRequired = false)]
        public string PhpVersion { get; set; }

        [DataMember(IsRequired = false)]
        public bool? RequestTracingEnabled { get; set; }

        [DataMember(IsRequired = false)]
        public bool? HttpLoggingEnabled { get; set; }

        [DataMember(IsRequired = false)]
        public bool? DetailedErrorLoggingEnabled { get; set; }

        [DataMember(IsRequired = false)]
        public string PublishingUsername { get; set; }

        [DataMember(IsRequired = false)]
        [PIIValue]
        public string PublishingPassword { get; set; }

        [DataMember(IsRequired = false)]
        public List<NameValuePair> AppSettings { get; set; }

        [DataMember(IsRequired = false)]
        public List<NameValuePair> Metadata { get; set; }

        [DataMember(IsRequired = false)]
        public ConnStringPropertyBag ConnectionStrings { get; set; }

        [DataMember(IsRequired = false)]
        public HandlerMapping[] HandlerMappings { get; set; }

        [DataMember(IsRequired = false)]
        public ManagedPipelineMode? ManagedPipelineMode { get; set; }

        [DataMember(IsRequired = false)]
        public bool? WebSocketsEnabled { get; set; }

        [DataMember(IsRequired = false)]
        public bool? RemoteDebuggingEnabled { get; set; }

        [DataMember(IsRequired = false)]
        public string RemoteDebuggingVersion { get; set; }

        [DataMember(IsRequired = false)]
        public List<RoutingRule> RoutingRules { get; set; }

        [DataMember(IsRequired = false)]
        public bool? Use32BitWorkerProcess { get; set; }

        [DataMember(IsRequired = false)]
        public string AutoSwapSlotName { get; set; }

        [DataMember(IsRequired = false)]
        public IList<string> SlotStickyAppSettingNames { get; set; }

        [DataMember(IsRequired = false)]
        public IList<string> SlotStickyConnectionStringNames { get; set; }
    }
}
