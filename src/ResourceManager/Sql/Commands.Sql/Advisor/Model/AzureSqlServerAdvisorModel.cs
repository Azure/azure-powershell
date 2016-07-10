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

using Microsoft.Azure.Management.Sql.Models;

namespace Microsoft.Azure.Commands.Sql.Advisor.Model
{
    /// <summary>
    /// Represents an Azure Sql Server Advisor
    /// </summary>
    public class AzureSqlServerAdvisorModel : AdvisorProperties
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
        /// Gets or sets the name of the advisor.
        /// </summary>
        public string AdvisorName { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public AzureSqlServerAdvisorModel()
        {
        }

        /// <summary>
        /// Construct AzureSqlDatabaseAdvisorModel from Management.Sql.Models.Advisor object
        /// </summary>
        /// <param name="resourceGroupName">Resource group</param>
        /// <param name="serverName">Server name</param>
        /// <param name="advisor">Advisor object</param>
        public AzureSqlServerAdvisorModel(string resourceGroupName, string serverName, Management.Sql.Models.Advisor advisor) 
        {
            ResourceGroupName = resourceGroupName;
            ServerName = serverName;

            AdvisorName = advisor.Name;
            AdvisorStatus = advisor.Properties.AdvisorStatus;
            RecommendationsStatus = advisor.Properties.RecommendationsStatus;
            AutoExecuteStatus = advisor.Properties.AutoExecuteStatus;
            AutoExecuteStatusInheritedFrom = advisor.Properties.AutoExecuteStatusInheritedFrom;
            LastChecked = advisor.Properties.LastChecked;
            RecommendedActions = advisor.Properties.RecommendedActions;
        }
    }
}
