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
    using Microsoft.Azure.Management.Advisor.Models;

    /// <summary>
    /// PS object for Advisor SDK ConfigurationData
    /// </summary>
    public class PsAzureAdvisorConfigurationData
    {
        /// <summary>
        ///  Gets or sets the resource Id of the configuration resource.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the configuration resource.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the list of property name/value pairs.
        /// </summary>
        public PsAzureAdvisorConfigurationProperties Properties { get; set; }

        /// <summary>
        /// Gets or sets the type of the configuration resource.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Parse the configData into PsObject
        /// </summary>
        /// <param name="configData">ConfigData to be converted</param>
        /// <returns>PsAzureAdvisorConfigurationData generated</returns>
        internal static PsAzureAdvisorConfigurationData GetFromConfigurationData(ConfigData configData)
        {
            if (configData == null)
            {
                return null;
            }

            return new PsAzureAdvisorConfigurationData()
            {
                Id = configData.Id,
                Name = configData.Name,
                Properties = PsAzureAdvisorConfigurationProperties.GetFromConfigurationProperties(configData.Properties),
                Type = configData.Type,
            };
        }

        /// <summary>
        /// Parse a list of configData to a list of equivalent PSObject.
        /// </summary>
        /// <param name="configDataList">List of ConfigData to be converted.</param>
        /// <returns>List of PsAzureAdvisorConfigurationData generated.</returns>
        internal static List<PsAzureAdvisorConfigurationData> GetFromConfigurationData(IEnumerable<ConfigData> configDataList)
        {
            List<PsAzureAdvisorConfigurationData> returnList = new List<PsAzureAdvisorConfigurationData>();

            foreach (ConfigData configDataEntry in configDataList)
            {
                returnList.Add(GetFromConfigurationData(configDataEntry));
            }

            return returnList;
        }
    }
}