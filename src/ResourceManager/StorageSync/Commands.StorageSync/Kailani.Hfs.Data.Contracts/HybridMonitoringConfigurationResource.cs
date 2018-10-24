// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HybridMonitoringConfigurationResource.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Kailani.Hfs.V1.Data.Contracts.ResourceEntity
{
    using Newtonsoft.Json;
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Comments are redundant.")]
    public class HybridMonitoringConfigurationResource
    {
        public HybridMonitoringConfigurationResource()
        {
        }

        public HybridMonitoringConfigurationResource(string id, string config, string configVersion)
        {
            this.AgentConfiguration = config;
            this.ConfigurationVersion = configVersion;
        }

        public HybridMonitoringConfigurationResource(HybridMonitoringConfigurationResource resource)
        {
            this.AgentConfiguration = resource.AgentConfiguration;
            this.ConfigurationVersion = resource.ConfigurationVersion;
        }

        [JsonProperty(PropertyName = "agentConfiguration", Required = Required.Default)]
        public string AgentConfiguration { get; set; }

        [JsonProperty(PropertyName = "configurationVersion", Required = Required.Default)]
        public string ConfigurationVersion { get; set; }

        public string DisplayName
        {
            get
            {
                return "HybridMonitoringConfiguration";
            }
        }
    }
}