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

namespace Microsoft.Azure.Management.CosmosDB.Models
{
    public class PSRestorableSqlDatabasePropertiesResourceDatabase
    {
        public PSRestorableSqlDatabasePropertiesResourceDatabase()
        {
        }

        public PSRestorableSqlDatabasePropertiesResourceDatabase(RestorableSqlDatabasePropertiesResourceDatabase restorableSqlDatabasePropertiesResourceDatabase)
        {
            if (restorableSqlDatabasePropertiesResourceDatabase == null)
            {
                return;
            }

            Id = restorableSqlDatabasePropertiesResourceDatabase.Id;
            this._rid = restorableSqlDatabasePropertiesResourceDatabase.Rid;
            this._ts = restorableSqlDatabasePropertiesResourceDatabase.Ts;
            this._etag = restorableSqlDatabasePropertiesResourceDatabase.Etag;
            this._colls = restorableSqlDatabasePropertiesResourceDatabase.Colls;
            this._users = restorableSqlDatabasePropertiesResourceDatabase.Users;
            this._self = restorableSqlDatabasePropertiesResourceDatabase.Self;
        }

        /// <summary>
        /// Gets or sets name of the Cosmos DB SQL database
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets a system generated property. A unique identifier.
        /// </summary>
        public string _rid { get; private set; }

        /// <summary>
        /// Gets a system generated property that denotes the last updated
        /// timestamp of the resource.
        /// </summary>
        public object _ts { get; private set; }

        /// <summary>
        /// Gets a system generated property representing the resource etag
        /// required for optimistic concurrency control.
        /// </summary>
        public string _etag { get; private set; }

        /// <summary>
        /// Gets a system generated property that specified the addressable
        /// path of the collections resource.
        /// </summary>
        public string _colls { get; private set; }

        /// <summary>
        /// Gets a system generated property that specifies the addressable
        /// path of the users resource.
        /// </summary>
        public string _users { get; private set; }

        /// <summary>
        /// Gets a system generated property that specifies the addressable
        /// path of the database resource.
        /// </summary>
        public string _self { get; private set; }
    }
}
