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
    using System.Collections.Generic;
    using Microsoft.Azure.Management.CosmosDB.Fluent.Models;

    public class PSSqlDatabase : PSResource
    {
        public PSSqlDatabase()
        {
        }        
        
        public String Id { get; set; }

        public PSSqlDatabase(SqlDatabaseInner sqlDatabaseInner)
        {
            SqlDatabaseId = sqlDatabaseInner.SqlDatabaseId;
            _rid = sqlDatabaseInner._rid;
            _ts = sqlDatabaseInner._ts;
            _etag = sqlDatabaseInner._etag;
            _colls = sqlDatabaseInner._colls;
            _users = sqlDatabaseInner._users;

        }

        public string SqlDatabaseId { get; set; }

        public string _rid { get; set; }

        public object _ts { get; set; }

        public string _etag { get; set; }

        public string _colls { get; set; }
 
        public string _users { get; set; }

    }
}
