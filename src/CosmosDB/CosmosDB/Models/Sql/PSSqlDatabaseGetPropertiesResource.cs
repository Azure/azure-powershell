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
    using Microsoft.Azure.Management.CosmosDB.Models;

    public class PSSqlDatabaseGetPropertiesResource 
    {
        public PSSqlDatabaseGetPropertiesResource()
        {
        }        
        
        public PSSqlDatabaseGetPropertiesResource(SqlDatabaseGetPropertiesResource sqlDatabaseGetPropertiesResource)
        {
            if (sqlDatabaseGetPropertiesResource == null)
            {
                return;
            }

            Id = sqlDatabaseGetPropertiesResource.Id;
            _rid = sqlDatabaseGetPropertiesResource._rid;
            _ts = sqlDatabaseGetPropertiesResource._ts;
            _etag = sqlDatabaseGetPropertiesResource._etag;
            _colls = sqlDatabaseGetPropertiesResource._colls;
            _users = sqlDatabaseGetPropertiesResource._users;
        }


        //
        // Summary:
        //     Gets or sets name of the Cosmos DB SQL database
        public string Id { get; set; }
        //
        // Summary:
        //     Gets a system generated property. A unique identifier.
        public string _rid { get; set; }
        //
        // Summary:
        //     Gets a system generated property that denotes the last updated timestamp of the
        //     resource.
        public object _ts { get; set; }
        //
        // Summary:
        //     Gets a system generated property representing the resource etag required for
        //     optimistic concurrency control.
        public string _etag { get; set; }
        //
        // Summary:
        //     Gets or sets a system generated property that specified the addressable path
        //     of the collections resource.
        public string _colls { get; set; }
        //
        // Summary:
        //     Gets or sets a system generated property that specifies the addressable path
        //     of the users resource.
        public string _users { get; set; }

    }
}
