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
using Microsoft.Azure.Commands.Common.Resources;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using Microsoft.Azure.Management.WebSites.Models;
using Newtonsoft.Json;


namespace Microsoft.Azure.Commands.Websites.Models.WebApp
{
    public class PSSiteConfig : PSFlattenedResource
    {
        public static implicit operator PSSiteConfig(SiteConfig config)
        {
            return config == null ? null : new PSSiteConfig(config);
        }

        public PSSiteConfig()
        {
        }

        protected PSSiteConfig(SiteConfig config) : base(config)
        {
            AlwaysOn = config.AlwaysOn;
            ApiDefinition = config.ApiDefinition;
            AppSettings = config.AppSettings;
            AutoHealEnabled = config.AutoHealEnabled;
            AutoHealRules = config.AutoHealRules;
            AutoSwapSlotName = config.AutoSwapSlotName;
            ConnectionStrings = config.ConnectionStrings;
            Cors = config.Cors;
            DefaultDocuments = config.DefaultDocuments;
            DetailedErrorLoggingEnabled = config.DetailedErrorLoggingEnabled;
            DocumentRoot = config.DocumentRoot;
            Experiments = config.Experiments;
            HandlerMappings = config.HandlerMappings;
            HttpLoggingEnabled = config.HttpLoggingEnabled;
            JavaContainer = config.JavaContainer;
            JavaContainerVersion = config.JavaContainerVersion;
            JavaVersion = config.JavaVersion;
            Limits = config.Limits;
            LoadBalancing = config.LoadBalancing;
            LogsDirectorySizeLimit = config.LogsDirectorySizeLimit;
            ManagedPipelineMode = config.ManagedPipelineMode;
            Metadata = config.Metadata;
            NetFrameworkVersion = config.NetFrameworkVersion;
            NumberOfWorkers = config.NumberOfWorkers;
            PhpVersion = config.PhpVersion;
            PublishingPassword = config.PublishingPassword;
            PublishingUsername = config.PublishingUsername;
            PythonVersion = config.PythonVersion;
            RemoteDebuggingEnabled = config.RemoteDebuggingEnabled;
            RemoteDebuggingVersion = config.RemoteDebuggingVersion;
            RequestTracingEnabled = config.RequestTracingEnabled;
            RequestTracingExpirationTime = config.RequestTracingExpirationTime;
            ScmType = config.ScmType;
            TracingOptions = config.TracingOptions;
            Use32BitWorkerProcess = config.Use32BitWorkerProcess;
            VirtualApplications = config.VirtualApplications;
            VnetName = config.VnetName;
            WebSocketsEnabled = config.WebSocketsEnabled;
        }

        /// <summary>
        /// Number of workers
        /// </summary>
        public int? NumberOfWorkers { get; set; }

        /// <summary>
        /// Default documents
        /// </summary>
        public IList<string> DefaultDocuments { get; set; }

        /// <summary>
        /// Net Framework Version
        /// </summary>
        public string NetFrameworkVersion { get; set; }

        /// <summary>
        /// Version of PHP
        /// </summary>
        public string PhpVersion { get; set; }

        /// <summary>
        /// Version of Python
        /// </summary>
        public string PythonVersion { get; set; }

        /// <summary>
        /// Enable request tracing
        /// </summary>
        public bool? RequestTracingEnabled { get; set; }

        /// <summary>
        /// Request tracing expiration time
        /// </summary>
        public DateTime? RequestTracingExpirationTime { get; set; }

        /// <summary>
        /// Remote Debugging Enabled
        /// </summary>
        public bool? RemoteDebuggingEnabled { get; set; }

        /// <summary>
        /// Remote Debugging Version
        /// </summary>
        public string RemoteDebuggingVersion { get; set; }

        /// <summary>
        /// HTTP logging Enabled
        /// </summary>
        public bool? HttpLoggingEnabled { get; set; }

        /// <summary>
        /// HTTP Logs Directory size limit
        /// </summary>
        public int? LogsDirectorySizeLimit { get; set; }

        /// <summary>
        /// Detailed error logging enabled
        /// </summary>
        public bool? DetailedErrorLoggingEnabled { get; set; }

        /// <summary>
        /// Publishing user name
        /// </summary>
        public string PublishingUsername { get; set; }

        /// <summary>
        /// Publishing password
        /// </summary>
        public string PublishingPassword { get; set; }

        /// <summary>
        /// Application Settings
        /// </summary>
        public IList<NameValuePair> AppSettings { get; set; }

        /// <summary>
        /// Site Metadata
        /// </summary>
        public IList<NameValuePair> Metadata { get; set; }

        /// <summary>
        /// Connection strings
        /// </summary>
        public IList<ConnStringInfo> ConnectionStrings { get; set; }

        /// <summary>
        /// Handler mappings
        /// </summary>
        public IList<HandlerMapping> HandlerMappings { get; set; }

        /// <summary>
        /// Document root
        /// </summary>
        public string DocumentRoot { get; set; }

        /// <summary>
        /// SCM type
        /// </summary>
        public string ScmType { get; set; }

        /// <summary>
        /// Use 32 bit worker process
        /// </summary>
        public bool? Use32BitWorkerProcess { get; set; }

        /// <summary>
        /// Web socket enabled.
        /// </summary>
        public bool? WebSocketsEnabled { get; set; }

        /// <summary>
        /// Always On
        /// </summary>
        public bool? AlwaysOn { get; set; }

        /// <summary>
        /// Java version
        /// </summary>
        public string JavaVersion { get; set; }

        /// <summary>
        /// Java container
        /// </summary>
        public string JavaContainer { get; set; }

        /// <summary>
        /// Java container version
        /// </summary>
        public string JavaContainerVersion { get; set; }

        /// <summary>
        /// Managed pipeline mode. Possible values for this property include:
        /// 'Integrated', 'Classic'.
        /// </summary>
        public ManagedPipelineMode? ManagedPipelineMode { get; set; }

        /// <summary>
        /// Virtual applications
        /// </summary>
        public IList<VirtualApplication> VirtualApplications { get; set; }

        /// <summary>
        /// Site load balancing. Possible values for this property include:
        /// 'WeightedRoundRobin', 'LeastRequests', 'LeastResponseTime',
        /// 'WeightedTotalTraffic', 'RequestHash'.
        /// </summary>
        public SiteLoadBalancing? LoadBalancing { get; set; }

        /// <summary>
        /// This is work around for polymophic types
        /// </summary>
        public Experiments Experiments { get; set; }

        /// <summary>
        /// Site limits
        /// </summary>
        public SiteLimits Limits { get; set; }

        /// <summary>
        /// Auto heal enabled
        /// </summary>
        public bool? AutoHealEnabled { get; set; }

        /// <summary>
        /// Auto heal rules
        /// </summary>
        public AutoHealRules AutoHealRules { get; set; }

        /// <summary>
        /// Tracing options
        /// </summary>
        public string TracingOptions { get; set; }

        /// <summary>
        /// Vnet name
        /// </summary>
        public string VnetName { get; set; }

        /// <summary>
        /// Cross-Origin Resource Sharing (CORS) settings.
        /// </summary>
        public CorsSettings Cors { get; set; }

        /// <summary>
        /// Information about the formal API definition for the web app.
        /// </summary>
        public ApiDefinitionInfo ApiDefinition { get; set; }

        /// <summary>
        /// Auto swap slot name
        /// </summary>
        public string AutoSwapSlotName { get; set; }
    }
}
