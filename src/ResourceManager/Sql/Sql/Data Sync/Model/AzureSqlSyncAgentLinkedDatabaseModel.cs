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

using Microsoft.Azure.Management.Sql.LegacySdk.Models;

namespace Microsoft.Azure.Commands.Sql.DataSync.Model
{
    /// <summary>
    /// The base class that defines the core properties of a data masking rule
    /// </summary>
    public class AzureSqlSyncAgentLinkedDatabaseModel
    {
        /// <summary>
        /// Gets or sets the server name of the database
        /// </summary>
        public string SeverName { get; set; }

        /// <summary>
        /// Gets or sets the database ID
        /// </summary>
        public string DatabaseId { get; set; }

        /// <summary>
        /// Gets or sets the database name
        /// </summary>
        public string DatabaseName { get; set; }    

        /// <summary>
        /// Gets or sets the type of database
        /// </summary>
        public string DatabaseType { get; set; }

        /// <summary>
        /// Gets or sets the description of database
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the username of the database
        /// </summary>
        public string UserName { get; set; }

        public AzureSqlSyncAgentLinkedDatabaseModel()
        {

        }

        public AzureSqlSyncAgentLinkedDatabaseModel(SyncAgentLinkedDatabase db)
        {
            DatabaseId = db.Properties.DatabaseId;
            SeverName = db.Properties.SeverName;
            DatabaseName = db.Properties.DatabaseName;
            DatabaseType = db.Properties.DatabaseType;
            UserName = db.Properties.UserName;
            Description = db.Properties.Description;
        }
    }
}
