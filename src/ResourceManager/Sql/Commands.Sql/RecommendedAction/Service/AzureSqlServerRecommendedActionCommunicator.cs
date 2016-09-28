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

using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Sql.RecommendedAction.Service
{
    /// <summary>
    /// This class is responsible for all the REST communication with the server recommended action REST endpoints
    /// </summary>
    public class AzureSqlServerRecommendedActionCommunicator : AzureSqlRecommendedActionCommunicatorBase
    {
        /// <summary>
        /// Creates a communicator for Azure Sql Server Recommended Actions
        /// </summary>
        public AzureSqlServerRecommendedActionCommunicator(AzureContext context) : base(context)
        {
        }

        /// <summary>
        /// Gets the Azure Sql Server Recommended Action
        /// </summary>
        public Management.Sql.Models.RecommendedAction Get(string resourceGroupName, string serverName, string advisorName, string recommendedActionName, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).ServerRecommendedActions.Get(resourceGroupName, serverName, advisorName, recommendedActionName).RecommendedAction;
        }

        /// <summary>
        /// Lists Azure Sql Server Recommended Actions
        /// </summary> 
        public IList<Management.Sql.Models.RecommendedAction> List(string resourceGroupName, string serverName, string advisorName, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).ServerRecommendedActions.List(resourceGroupName, serverName, advisorName).RecommendedActions;
        }

        /// <summary>
        /// Update Recommended Action State
        /// </summary>
        public Management.Sql.Models.RecommendedAction UpdateState(string resourceGroupName, string serverName, string advisorName, string recommendedActionName, string newStateValue, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).ServerRecommendedActions.Update(resourceGroupName, serverName, advisorName, recommendedActionName,
                    new RecommendedActionUpdateParameters
                    {
                        Properties = new RecommendedActionUpdateProperties()
                        {
                            State = new RecommendedActionUpdateStateInfo()
                            {
                                CurrentValue = newStateValue
                            }
                        }
                    }).RecommendedAction;
        }
    }
}
