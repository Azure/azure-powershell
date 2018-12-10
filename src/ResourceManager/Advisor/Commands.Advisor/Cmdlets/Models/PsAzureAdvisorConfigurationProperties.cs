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

namespace Microsoft.Azure.Commands.Advisor.Cmdlets.Models
{
    using System.Collections.Generic;
    using System.Text;
    using Management.Advisor.Models;

    /// <summary>
    /// PS object for Advisor SDK ConfigurationProperties
    /// </summary>
    public class PsAzureAdvisorConfigurationProperties
    {
        /// <summary>
        /// Gets or sets additional properties from the message are deserialized this collection
        /// </summary>
        public IDictionary<string, object> AdditionalProperties { get; set; }

        /// <summary>
        /// Gets or sets exclude the resource from Advisor evaluations. Valid values: False, (default) or True.
        /// </summary>
        public bool? Exclude { get; set; }

        /// <summary>
        /// Gets or sets minimum percentage threshold for Advisor low CPU utilization evaluation. Valid only for subscriptions. Valid values: 5 (default), 10, 15 or 20.
        /// </summary>
        public string LowCpuThreshold { get; set; }

        /// <summary>
        /// Parse ConfigDataProperties to equivalent PSObject
        /// </summary>
        /// <param name="configDataProperties">ConfigDataProperties to be parsed</param>
        /// <returns>Equivalent PsAzureAdvisorConfigurationProperties</returns>
        internal static PsAzureAdvisorConfigurationProperties GetFromConfigurationProperties(ConfigDataProperties configDataProperties)
        {
            if (configDataProperties == null)
            {
                return null;
            }

            return new PsAzureAdvisorConfigurationProperties()
            {
                AdditionalProperties = configDataProperties.AdditionalProperties,
                Exclude = configDataProperties.Exclude,
                LowCpuThreshold = configDataProperties.LowCpuThreshold,
            };
        }
    }
}