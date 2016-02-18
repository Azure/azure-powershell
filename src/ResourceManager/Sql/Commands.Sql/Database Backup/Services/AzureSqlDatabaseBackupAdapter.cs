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
using System.Globalization;
using System.Linq;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Backup.Model;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.Database.Model;
using Microsoft.Azure.Commands.Sql.Database.Services;
using Microsoft.Azure.Commands.Sql.ElasticPool.Services;
using Microsoft.Azure.Commands.Sql.Properties;
using Microsoft.Azure.Commands.Sql.Server.Adapter;
using Microsoft.Azure.Commands.Sql.Services;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;

namespace Microsoft.Azure.Commands.Sql.Backup.Services
{
    /// <summary>
    /// Adapter for database backup operations
    /// </summary>
    public class AzureSqlDatabaseBackupAdapter
    {
        /// <summary>
        /// Gets or sets the AzureSqlDatabaseBackupCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlDatabaseBackupCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public AzureContext Context { get; set; }

        /// <summary>
        /// Gets or sets the Azure Subscription
        /// </summary>
        private AzureSubscription _subscription { get; set; }

        /// <summary>
        /// Constructs a database backup adapter
        /// </summary>
        /// <param name="profile">The current azure profile</param>
        /// <param name="subscription">The current azure subscription</param>
        public AzureSqlDatabaseBackupAdapter(AzureContext context)
        {
            Context = context;
            _subscription = context.Subscription;
            Communicator = new AzureSqlDatabaseBackupCommunicator(Context);
        }

        /// <summary>
        /// Lists the restore points for a given Sql Azure Database.
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure SQL Server</param>
        /// <param name="databaseName">The name of the Azure SQL database</param>
        /// <returns>List of restore points</returns>
        internal IEnumerable<AzureSqlDatabaseRestorePointModel> ListRestorePoints(string resourceGroup, string serverName, string databaseName)
        {
            var resp = Communicator.ListRestorePoints(resourceGroup, serverName, databaseName, Util.GenerateTracingId());
            return resp.Select((restorePoint) =>
            {
                return new AzureSqlDatabaseRestorePointModel()
                {
                    ResourceGroupName = resourceGroup,
                    ServerName = serverName,
                    DatabaseName = databaseName,
                    Location = restorePoint.Location,
                    RestorePointType = restorePoint.Properties.RestorePointType,
                    RestorePointCreationDate = restorePoint.Properties.RestorePointCreationDate,
                    EarliestRestoreDate = restorePoint.Properties.EarliestRestoreDate
                }; 
            }).ToList();
        }
    }
}
