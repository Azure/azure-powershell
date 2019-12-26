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

    public class PSSqlDatabaseGetResults 
    {
        public PSSqlDatabaseGetResults()
        {
        }        
        
        public PSSqlDatabaseGetResults(SqlDatabaseGetResults sqlDatabaseGetResults)
        {
            Name = sqlDatabaseGetResults.Name;
            Id = sqlDatabaseGetResults.Id;
            SqlDatabaseGetResultsId = sqlDatabaseGetResults.SqlDatabaseGetResultsId;
            _rid = sqlDatabaseGetResults._rid;
            _ts = sqlDatabaseGetResults._ts;
            _etag = sqlDatabaseGetResults._etag;
            _colls = sqlDatabaseGetResults._colls;
            _users = sqlDatabaseGetResults._users;
        }

        /// <summary>
        /// Gets or sets Name of the Cosmos DB SQL database
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Id of the Cosmos DB SQL database
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets name of the Cosmos DB SQL database
        /// </summary>
        public string SqlDatabaseGetResultsId { get; set; }

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

        /// <summary>
        /// Gets or sets a system generated property that specified the
        /// addressable path of the collections resource.
        /// </summary>
        public string _colls { get; set; }

        /// <summary>
        /// Gets or sets a system generated property that specifies the
        /// addressable path of the users resource.
        /// </summary>
        public string _users { get; set; }
    }
}
