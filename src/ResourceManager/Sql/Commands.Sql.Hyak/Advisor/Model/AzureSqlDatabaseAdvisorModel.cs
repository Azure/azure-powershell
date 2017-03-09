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

namespace Microsoft.Azure.Commands.Sql.Advisor.Model
{
    /// <summary>
    /// Represents an Azure Sql Database Advisor
    /// </summary>
    public class AzureSqlDatabaseAdvisorModel : AzureSqlServerAdvisorModel
    {
        /// <summary>
        /// Gets or sets the name of the database
        /// </summary>
        public string DatabaseName { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public AzureSqlDatabaseAdvisorModel()
        {
        }

        /// <summary>
        /// Construct AzureSqlDatabaseAdvisorModel from Management.Sql.Models.Advisor object
        /// </summary>
        /// <param name="resourceGroupName">Resource group</param>
        /// <param name="serverName">Server name</param>
        /// <param name="databaseName">Database name</param>
        /// <param name="advisor">Advisor object</param>
        public AzureSqlDatabaseAdvisorModel(string resourceGroupName, string serverName, string databaseName, Management.Sql.Models.Advisor advisor)
        : base(resourceGroupName, serverName, advisor)
        {
            DatabaseName = databaseName;
        }
    }
}
