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

using Microsoft.WindowsAzure.Commands.Common.Attributes;

namespace Microsoft.Azure.Management.CosmosDB.Models
{
    public class PSRestorableSqlDatabaseGetResult
    {
        public PSRestorableSqlDatabaseGetResult()
        {
        }

        public PSRestorableSqlDatabaseGetResult(RestorableSqlDatabaseGetResult restorableSqlDatabaseGetResult)
        {
            if (restorableSqlDatabaseGetResult == null)
            {
                return;
            }

            Name = restorableSqlDatabaseGetResult.Name;
            Id = restorableSqlDatabaseGetResult.Id;
            Type = restorableSqlDatabaseGetResult.Type;
            this._rid = restorableSqlDatabaseGetResult.Resource._rid;
            OperationType = restorableSqlDatabaseGetResult.Resource.OperationType;
            EventTimestamp = restorableSqlDatabaseGetResult.Resource.EventTimestamp;
            OwnerId = restorableSqlDatabaseGetResult.Resource.OwnerId;
            OwnerResourceId = restorableSqlDatabaseGetResult.Resource.OwnerResourceId;
            Database = new PSRestorableSqlDatabasePropertiesResourceDatabase(restorableSqlDatabaseGetResult.Resource.Database);
        }

        /// <summary>
        /// Gets or sets Name of the Cosmos DB Sql database
        /// </summary>
        [Ps1Xml(Label = "Name", Target = ViewControl.List)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Id of the Cosmos DB Sql database
        /// </summary>
        [Ps1Xml(Label = "Id", Target = ViewControl.List)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets Type of the Cosmos DB resource
        /// </summary>
        [Ps1Xml(Label = "Type", Target = ViewControl.List)]
        public string Type { get; set; }

        /// <summary>
        /// Gets a system generated property. A unique identifier.
        /// </summary>
        [Ps1Xml(Label = "_rid", Target = ViewControl.List)]
        public string _rid { get; private set; }

        /// <summary>
        /// Gets the operation type of this database event. Possible values
        /// include: 'Create', 'Replace', 'Delete', 'SystemOperation'
        /// </summary>
        [Ps1Xml(Label = "OperationType", Target = ViewControl.List)]
        public string OperationType { get; private set; }

        /// <summary>
        /// Gets the timestamp of this database event.
        /// </summary>
        [Ps1Xml(Label = "EventTimestamp", Target = ViewControl.List)]
        public string EventTimestamp { get; private set; }

        /// <summary>
        /// Gets the name of this restorable SQL database.
        /// </summary>
        [Ps1Xml(Label = "OwnerId", Target = ViewControl.List)]
        public string OwnerId { get; private set; }

        /// <summary>
        /// Gets the resource Id of this restorable SQL database.
        /// </summary>
        [Ps1Xml(Label = "OwnerResourceId", Target = ViewControl.List)]
        public string OwnerResourceId { get; private set; }

        /// <summary>
        /// Gets the database properties of the restorable SQL database
        /// </summary>
        [Ps1Xml(Label = "Database", Target = ViewControl.List)]
        public PSRestorableSqlDatabasePropertiesResourceDatabase Database { get; set; }
    }
}
