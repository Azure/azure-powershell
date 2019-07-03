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

namespace Microsoft.Azure.Commands.StorageSync.InternalObjects
{
    using Newtonsoft.Json;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Class HybridMonitoringConfigurationResource.
    /// </summary>
    public class HybridMonitoringConfigurationResource
    {
        /// <summary>
        /// Gets or sets the agent configuration.
        /// </summary>
        /// <value>The agent configuration.</value>
        [JsonProperty(PropertyName = "agentConfiguration", Required = Required.Default)]
        public string AgentConfiguration { get; set; }

        /// <summary>
        /// Gets or sets the configuration version.
        /// </summary>
        /// <value>The configuration version.</value>
        [JsonProperty(PropertyName = "configurationVersion", Required = Required.Default)]
        public string ConfigurationVersion { get; set; }
    }
}