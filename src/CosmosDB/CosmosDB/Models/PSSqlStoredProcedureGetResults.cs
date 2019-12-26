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

namespace Microsoft.Azure.Commands.CosmosDB.Models
{
    using System;
    using Microsoft.Azure.Management.CosmosDB.Models;

    public class PSSqlStoredProcedureGetResults 
    {
        public PSSqlStoredProcedureGetResults()
        {
        }        
        
        public PSSqlStoredProcedureGetResults(SqlStoredProcedureGetResults sqlStoredProcedureGetResults)
        {
            Name = sqlStoredProcedureGetResults.Name;
            Id = sqlStoredProcedureGetResults.Id;
            SqlStoredProcedureGetResultsId = sqlStoredProcedureGetResults.SqlStoredProcedureGetResultsId;
            Body = sqlStoredProcedureGetResults.Body;
            _rid = sqlStoredProcedureGetResults._rid;
            _ts = sqlStoredProcedureGetResults._ts;
            _etag = sqlStoredProcedureGetResults._etag;
        }

        /// <summary>
        /// Gets or sets Name the Cosmos DB SQL storedProcedure
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Id of the Cosmos DB SQL storedProcedure
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets name of the Cosmos DB SQL storedProcedure
        /// </summary>
        public string SqlStoredProcedureGetResultsId { get; set; }

        /// <summary>
        /// Gets or sets body of the Stored Procedure
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Gets a system generated property. A unique identifier.
        /// </summary>
        public string _rid { get; set; }

        /// <summary>
        /// Gets a system generated property that denotes the last updated
        /// timestamp of the resource.
        /// </summary>
        public object _ts { get; set; }

        /// <summary>
        /// Gets a system generated property representing the resource etag
        /// required for optimistic concurrency control.
        /// </summary>
        public string _etag { get; set; }
    }
}
