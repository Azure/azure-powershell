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

namespace Microsoft.Azure.Commands.Sql.RecommendedAction.Model
{
    /// <summary>
    /// Represents an Azure Sql Server Recommended Action
    /// </summary>
    public class AzureSqlServerRecommendedActionModel : RecommendedActionProperties
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
        /// Gets or sets the name of the recommended action.
        /// </summary>
        public string RecommendedActionName { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public AzureSqlServerRecommendedActionModel()
        {
        }

        /// <summary>
        /// Construct AzureSqlServerRecommendedActionModel from Management.Sql.Models.Recommended Action object
        /// </summary>
        /// <param name="resourceGroupName">Resource group</param>
        /// <param name="serverName">Server name</param>
        /// <param name="advisorName">Advisor name</param>
        /// <param name="recommendedAction">Recommended Action object</param>
        public AzureSqlServerRecommendedActionModel(string resourceGroupName, string serverName, string advisorName, Management.Sql.Models.RecommendedAction recommendedAction) 
        {
            ResourceGroupName = resourceGroupName;
            ServerName = serverName;
            AdvisorName = advisorName;

            RecommendedActionName = recommendedAction.Name;
            RecommendationReason = recommendedAction.Properties.RecommendationReason;
            ValidSince = recommendedAction.Properties.ValidSince;
            LastRefresh = recommendedAction.Properties.LastRefresh;
            State = recommendedAction.Properties.State;
            IsExecutableAction = recommendedAction.Properties.IsExecutableAction;
            IsRevertableAction = recommendedAction.Properties.IsRevertableAction;
            IsArchivedAction = recommendedAction.Properties.IsArchivedAction;
            ExecuteActionStartTime = recommendedAction.Properties.ExecuteActionStartTime;
            ExecuteActionDuration = recommendedAction.Properties.ExecuteActionDuration;
            RevertActionStartTime = recommendedAction.Properties.RevertActionStartTime;
            RevertActionDuration = recommendedAction.Properties.RevertActionDuration;
            ExecuteActionInitiatedBy = recommendedAction.Properties.ExecuteActionInitiatedBy;
            ExecuteActionInitiatedTime = recommendedAction.Properties.ExecuteActionInitiatedTime;
            RevertActionInitiatedBy = recommendedAction.Properties.RevertActionInitiatedBy;
            RevertActionInitiatedTime = recommendedAction.Properties.RevertActionInitiatedTime;
            Score = recommendedAction.Properties.Score;
            ImplementationDetails = recommendedAction.Properties.ImplementationDetails;
            ErrorDetails = recommendedAction.Properties.ErrorDetails;
            EstimatedImpact = recommendedAction.Properties.EstimatedImpact;
            ObservedImpact = recommendedAction.Properties.ObservedImpact;
            TimeSeries = recommendedAction.Properties.TimeSeries;
            LinkedObjects = recommendedAction.Properties.LinkedObjects;
            Details = recommendedAction.Properties.Details;
        }
    }
}
