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
using Microsoft.Azure.Commands.Sql.Model;
using Microsoft.Azure.Commands.Sql.Services;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Sql.Service
{
    /// <summary>
    /// Adapter for recommended index operations
    /// </summary>
    public class AzureSqlDatabaseIndexRecommendationAdapter
    {
        /// <summary>
        /// Pending string state constant
        /// </summary>
        private const string Pending = "Pending";

        /// <summary>
        /// Gets or sets the Communicator which has all the needed management clients
        /// </summary>
        private AzureSqlDatabaseIndexRecommendationCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public AzureContext Context { get; set; }

        /// <summary>
        /// Constructs adapter
        /// </summary>
        /// <param name="profile">The current azure profile</param>
        /// <param name="subscription">The current azure subscription</param>
        public AzureSqlDatabaseIndexRecommendationAdapter(AzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlDatabaseIndexRecommendationCommunicator(Context);
        }

        /// <summary>
        /// List index recommendations
        /// </summary>
        /// <param name="resourceGroupName">Resource group name</param>
        /// <param name="serverName">Server name</param>
        /// <param name="databaseName">Database name</param>
        /// <returns></returns>
        public List<IndexRecommendation> ListRecommendedIndexes(string resourceGroupName, string serverName, string databaseName)
        {
            return Communicator.ListRecommendedIndexes(resourceGroupName, serverName, databaseName, Util.GenerateTracingId());
        }

        /// <summary>
        /// Update index recommendation state.
        /// </summary>
        /// <param name="resourceGroupName">Resource group name</param>
        /// <param name="serverName">Server name</param>
        /// <param name="indexRecommendation">Index recommendation</param>
        public void UpdateRecommendationState(string resourceGroupName, string serverName, IndexRecommendation indexRecommendation)
        {
            Communicator.UpdateRecommendedIndexState(resourceGroupName, serverName, indexRecommendation.DatabaseName, indexRecommendation.Schema, indexRecommendation.Table, indexRecommendation.Name, indexRecommendation.State, Util.GenerateTracingId());
        }
    }
}
