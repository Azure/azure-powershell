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


namespace Microsoft.Azure.Commands.Sql.ServerDisasterRecoveryConfiguration.Model
{
    /// <summary>
    /// Represents an Azure Sql Server Disaster Recovery Configuration
    /// </summary>
    public class AzureSqlServerDisasterRecoveryConfigurationModel
    {
        /// <summary>
        /// Gets or sets the name of the resource group
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the server
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the Server Disaster Recovery Configuration
        /// </summary>
        public string ServerDisasterRecoveryConfigurationName { get; set; }

        /// <summary>
        /// Gets or sets the name of the Server Disaster Recovery Virtual Endpoint Name
        /// </summary>
        public string VirtualEndpointName { get; set; }

        /// <summary>
        /// Gets or sets the location of the Server Disaster Recovery Configuration
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the status of the Server Disaster Recovery Configuration
        /// </summary>
        public string AutoFailover { get; set; }

        /// <summary>
        /// Gets or sets the creation date of the Server Disaster Recovery Configuration
        /// </summary>
        public string FailoverPolicy { get; set; }

        /// <summary>
        /// Gets or sets the tags associated with the server.
        /// </summary>
        public string PartnerServerName { get; set; }

        /// <summary>
        /// Gets or sets the tags associated with the server.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Construct AzureSqlServerDisasterRecoveryConfigurationModel
        /// </summary>
        public AzureSqlServerDisasterRecoveryConfigurationModel()
        {
        }

        /// <summary>
        /// Construct AzureSqlServerDisasterRecoveryConfigurationModel from Management.Sql.Models.ServerDisasterRecoveryConfiguration object
        /// </summary>
        /// <param name="resourceGroup">Resource group</param>
        /// <param name="serverName">Server name</param>
        /// <param name="serverDisasterRecoveryConfiguration">ServerDisasterRecoveryConfiguration object</param>
        public AzureSqlServerDisasterRecoveryConfigurationModel(string resourceGroup, string serverName, Management.Sql.Models.ServerDisasterRecoveryConfiguration serverDisasterRecoveryConfiguration)
        {
            ResourceGroupName = resourceGroup;
            ServerName = serverName;

            // Short-term workaround for missing sdrc. Will remove once upstream issues are resolved.
            if (serverDisasterRecoveryConfiguration != null)
            {
                ServerDisasterRecoveryConfigurationName = serverDisasterRecoveryConfiguration.Name;
                VirtualEndpointName = serverDisasterRecoveryConfiguration.Name;
                Location = serverDisasterRecoveryConfiguration.Location;
                PartnerServerName = serverDisasterRecoveryConfiguration.Properties.PartnerLogicalServerName;
                AutoFailover = serverDisasterRecoveryConfiguration.Properties.AutoFailover;
                FailoverPolicy = serverDisasterRecoveryConfiguration.Properties.FailoverPolicy;
                Role = serverDisasterRecoveryConfiguration.Properties.Role;
            }

        }
    }
}
