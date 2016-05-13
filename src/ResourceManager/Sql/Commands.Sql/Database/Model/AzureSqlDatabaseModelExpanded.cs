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


namespace Microsoft.Azure.Commands.Sql.Database.Model
{
    /// <summary>
    /// Represents an Azure Sql Database
    /// </summary>
    public class AzureSqlDatabaseModelExpanded : AzureSqlDatabaseModel
    {
        /// <summary>
        /// Service tier advisor for this database
        /// </summary>
        public Management.Sql.Models.ServiceTierAdvisorProperties ServiceTierAdvisor { get; set; }

        /// <summary>
        /// Construct AzureSqlDatabaseModelExpanded from Management.Sql.Models.Database object
        /// </summary>
        /// <param name="resourceGroup">Resource group</param>
        /// <param name="serverName">Server name</param>
        /// <param name="database">Database object</param>
        public AzureSqlDatabaseModelExpanded(string resourceGroup, string serverName, Management.Sql.Models.Database database) : base(resourceGroup, serverName, database)
        {
            if (database.Properties.ServiceTierAdvisors != null
                && database.Properties.ServiceTierAdvisors.Count > 0)
            {
                ServiceTierAdvisor = database.Properties.ServiceTierAdvisors[0].Properties;
            }
        }
    }
}
