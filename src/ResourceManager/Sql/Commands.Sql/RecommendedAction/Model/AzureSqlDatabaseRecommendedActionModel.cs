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

namespace Microsoft.Azure.Commands.Sql.RecommendedAction.Model
{
    /// <summary>
    /// Represents an Azure Sql Database Recommended Action
    /// </summary>
    public class AzureSqlDatabaseRecommendedActionModel : AzureSqlServerRecommendedActionModel
    {
        /// <summary>
        /// Gets or sets the name of the database
        /// </summary>
        public string DatabaseName { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public AzureSqlDatabaseRecommendedActionModel()
        {
        }

        /// <summary>
        /// Construct AzureSqlDatabaseRecommendedActionModel from Management.Sql.Models.RecommendedAction object
        /// </summary>
        /// <param name="resourceGroupName">Resource group</param>
        /// <param name="serverName">Server name</param>
        /// <param name="databaseName">Database name</param>
        /// <param name="advisorName">Advisor name</param>
        /// <param name="recommendedAction">Recommended Action object</param>
        public AzureSqlDatabaseRecommendedActionModel(string resourceGroupName, string serverName, string databaseName, string advisorName, Management.Sql.Models.RecommendedAction recommendedAction)
        : base(resourceGroupName, serverName, advisorName, recommendedAction)
        {
            DatabaseName = databaseName;
        }
    }
}
