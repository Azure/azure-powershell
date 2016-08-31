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

namespace Microsoft.Azure.Commands.Sql.Advisor.Service
{
    /// <summary>
    /// This class is responsible for all the REST communication with the Elastic Pool advisor REST endpoints
    /// </summary>
    public class AzureSqlElasticPoolAdvisorCommunicator : AzureSqlAdvisorCommunicatorBase
    {

        /// <summary>
        /// Creates a communicator for Azure Sql Elastic Pool Advisors
        /// </summary>
        public AzureSqlElasticPoolAdvisorCommunicator(AzureContext context) : base(context)
        {
        }

        /// <summary>
        /// Gets the Azure Sql Elastic Pool Advisor
        /// </summary>
        public Management.Sql.Models.Advisor Get(string resourceGroupName, string serverName, string elasticPoolName, string advisorName, bool expandRecommendedActions, string clientRequestId)
        {
            string expand = expandRecommendedActions ? ExpandKey : null;
            return GetCurrentSqlClient(clientRequestId).ElasticPoolAdvisors.Get(resourceGroupName, serverName, elasticPoolName, advisorName, expand).Advisor;
        }

        /// <summary>
        /// Lists Azure Sql Elastic Pool Advisors
        /// </summary>
        public IList<Management.Sql.Models.Advisor> List(string resourceGroupName, string serverName, string elasticPoolName, bool expandRecommendedActions, string clientRequestId)
        {
            string expand = expandRecommendedActions ? ExpandKey : null;
            return GetCurrentSqlClient(clientRequestId).ElasticPoolAdvisors.List(resourceGroupName, serverName, elasticPoolName, expand).Advisors;
        }

        /// <summary>
        /// Update Advisor Auto Execute Status
        /// </summary>
        public Management.Sql.Models.Advisor UpdateAutoExecuteStatus(string resourceGroupName, string serverName, string elasticPoolName, string advisorName, string autoExecuteStatus, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).ElasticPoolAdvisors.Update(resourceGroupName, serverName, elasticPoolName, advisorName,
                    new AdvisorUpdateParameters
                    {
                        Properties = new AdvisorUpdateProperties()
                        {
                            AutoExecuteStatus = autoExecuteStatus
                        }
                    }).Advisor;
        }
    }
}
