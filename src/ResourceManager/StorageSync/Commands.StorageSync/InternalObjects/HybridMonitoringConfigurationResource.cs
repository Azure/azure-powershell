// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HybridMonitoringConfigurationResource.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Microsoft.Azure.Commands.StorageSync.InternalObjects
{
    using Newtonsoft.Json;
    using System.Diagnostics.CodeAnalysis;

    public class HybridMonitoringConfigurationResource
    {
        [JsonProperty(PropertyName = "agentConfiguration", Required = Required.Default)]
        public string AgentConfiguration { get; set; }

        [JsonProperty(PropertyName = "configurationVersion", Required = Required.Default)]
        public string ConfigurationVersion { get; set; }
    }
}