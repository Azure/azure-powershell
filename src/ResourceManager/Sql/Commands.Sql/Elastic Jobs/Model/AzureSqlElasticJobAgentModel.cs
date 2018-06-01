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

using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Sql.ElasticJobs.Model
{
    /// <summary>
    /// Represents the core properties of an Azure Elastic Job Agent model
    /// </summary>
    public class AzureSqlElasticJobAgentModel : AzureSqlElasticJobsBaseModel
    {
        /// <summary>
        /// Gets or sets the database name for the sql database agent name.
        /// </summary>
        public string DatabaseName { get; set; }

        /// <summary>
        ///  The SQL Database Agent Control Database Id
        /// </summary>
        public string DatabaseId { get; set; }

        /// <summary>
        /// Gets or sets the agent's number of workers.
        /// </summary>
        public int? WorkerCount { get; set; }

        /// <summary>
        /// Gets or sets the agent's state.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the location the elastic job agent is in
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the tags associated with the server.
        /// </summary>
        public Dictionary<string, string> Tags { get; set; }
    }
}