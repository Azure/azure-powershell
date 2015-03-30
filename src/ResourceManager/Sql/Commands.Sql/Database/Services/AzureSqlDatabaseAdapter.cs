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

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.Database.Model;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;

namespace Microsoft.Azure.Commands.Sql.Database.Services
{
    /// <summary>
    /// Adapter for database operations
    /// </summary>
    public class AzureSqlDatabaseAdapter
    {
        private AzureEndpointsCommunicator AzureCommunicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public AzureProfile Profile { get; set; }

        /// <summary>
        /// Constructs a database adapter
        /// </summary>
        /// <param name="profile">The current azure profile</param>
        /// <param name="subscription">The current azure subscription</param>
        public AzureSqlDatabaseAdapter(AzureProfile Profile, AzureSubscription subscription)
        {
            this.Profile = Profile;
            AzureCommunicator = new AzureEndpointsCommunicator(Profile, subscription);
        }

        internal AzureSqlDatabaseModel GetDatabase(string resourceGroupName, string serverName, string databaseName)
        {
            SqlManagementClient client = AzureCommunicator.GetCurrentSqlClient(Guid.NewGuid().ToString());

            DatabaseGetResponse resp = client.Databases.Get(resourceGroupName, serverName, databaseName);
            return CreateDatabaseModelFromResponse(resp.Database);
        }

        internal ICollection<AzureSqlDatabaseModel> ListDatabases(string resourceGroupName, string serverName)
        {
            SqlManagementClient client = AzureCommunicator.GetCurrentSqlClient(Guid.NewGuid().ToString());

            DatabaseListResponse resp = client.Databases.List(resourceGroupName, serverName);

            return resp.Databases.Select((db) =>
            {
                return CreateDatabaseModelFromResponse(db);
            }).ToList();
        }

        internal AzureSqlDatabaseModel UpsertDatabase(string resourceGroupName, string serverName, AzureSqlDatabaseModel model)
        {
            SqlManagementClient client = AzureCommunicator.GetCurrentSqlClient(Guid.NewGuid().ToString());

            DatabaseCreateOrUpdateResponse response = client.Databases.CreateOrUpdate(resourceGroupName, serverName, model.DatabaseName, new DatabaseCreateOrUpdateParameters()
            {
                Properties = new DatabaseCreateOrUpdateProperties()
                {
                    Collation = model.CollationName,
                    Edition = model.Edition.ToString(),
                    MaxSizeBytes = model.MaxSizeBytes,
                    RequestedServiceObjectiveId = model.RequestedServiceObjectiveId
                }
            });

            return CreateDatabaseModelFromResponse(response.Database);
        }

        /// <summary>
        /// Deletes a server
        /// </summary>
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="serverName">The name of the server to delete</param>
        public void RemoveDatabase(string resourceGroupName, string serverName, string databaseName)
        {
            SqlManagementClient client = AzureCommunicator.GetCurrentSqlClient(Guid.NewGuid().ToString());

            client.Databases.Delete(resourceGroupName, serverName, databaseName);
        }

        /// <summary>
        /// Converts the response from the service to a powershell database object
        /// </summary>
        /// <param name="database">The service response</param>
        /// <returns>The converted model</returns>
        private AzureSqlDatabaseModel CreateDatabaseModelFromResponse(Management.Sql.Models.Database database)
        {
            AzureSqlDatabaseModel model = new AzureSqlDatabaseModel();
            Guid id = Guid.Empty;
            DatabaseEdition edition = DatabaseEdition.None;

            model.CollationName = database.Properties.Collation;
            model.CreationDate = database.Properties.CreationDate;
            model.CurrentServiceLevelObjectiveName = database.Properties.ServiceObjective;
            model.MaxSizeBytes = database.Properties.MaxSizeBytes;
            model.DatabaseName = database.Name;
            model.Status = database.Properties.Status;
            model.Tags = database.Tags as Dictionary<string, string>;
            
            Guid.TryParse(database.Properties.CurrentServiceObjectiveId, out id);
            model.CurrentServiceObjectiveId = id;
            
            Guid.TryParse(database.Properties.DatabaseId, out id);
            model.DatabaseId = id;

            Enum.TryParse<DatabaseEdition>(database.Properties.Edition, true, out edition);
            model.Edition = edition;

            Guid.TryParse(database.Properties.RequestedServiceObjectiveId, out id);
            model.RequestedServiceObjectiveId = id;

            return model;
        }
    }
}
