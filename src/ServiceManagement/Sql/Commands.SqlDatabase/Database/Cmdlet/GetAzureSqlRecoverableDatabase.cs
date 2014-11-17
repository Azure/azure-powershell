// ----------------------------------------------------------------------------------
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
using System.Management.Automation;
using Microsoft.WindowsAzure.Management.Sql;
using Microsoft.WindowsAzure.Management.Sql.Models;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Database.Cmdlet
{
    /// <summary>
    /// Retrieves a list of restorable dropped Microsoft Azure SQL Databases in the given server context.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureSqlRecoverableDatabase", ConfirmImpact = ConfirmImpact.None, DefaultParameterSetName = AllDatabasesOnGivenServer)]
    public class GetAzureSqlRecoverableDatabase : SqlDatabaseCmdletBase
    {
        #region Parameter sets

        /// <summary>
        /// The parameter set for getting all databases on the given source server.
        /// </summary>
        internal const string AllDatabasesOnGivenServer = "AllDatabasesOnGivenServer";

        /// <summary>
        /// The parameter set for getting the given database on the given source server.
        /// </summary>
        internal const string GivenDatabaseOnGivenServer = "GivenDatabaseOnGivenServer";

        /// <summary>
        /// The parameter set for refreshing the given database object.
        /// </summary>
        internal const string GivenDatabaseObject = "GivenDatabaseObject";

        #endregion

        #region Parameters

        /// <summary>
        /// Gets or sets the name of the server that contained the database to retrieve. If not specified, defaults to TargetServerName.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = AllDatabasesOnGivenServer,
            HelpMessage = "The name of the server on which the database was hosted.")]
        [Parameter(Mandatory = true,
            ParameterSetName = GivenDatabaseOnGivenServer,
            HelpMessage = "The name of the server on which the database was hosted.")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the database to retrieve.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = GivenDatabaseOnGivenServer,
            HelpMessage = "The name of the database.")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the RecoverableDatabase object to refresh.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = GivenDatabaseObject,
            HelpMessage = "The RecoverableDatabase object to refresh.")]
        [ValidateNotNull]
        public RecoverableDatabase Database { get; set; }

        #endregion

        /// <summary>
        /// Process the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            // Obtain the source server and database name from the given parameters.
            var serverName =
                this.Database != null ? this.Database.ServerName :
                this.ServerName;

            var databaseName =
                this.Database != null ? this.Database.Name :
                this.DatabaseName;

            // Get the SQL management client for the current subscription
            SqlManagementClient sqlManagementClient = GetCurrentSqlClient();

            try
            {
                if (databaseName != null)
                {
                    // Retrieve the database with the specified name
                    RecoverableDatabaseGetResponse response = sqlManagementClient.RecoverableDatabases.Get(serverName, databaseName);
                    this.WriteObject(response.Database);
                }
                else
                {
                    // No name specified, retrieve all databases in the server
                    RecoverableDatabaseListResponse response = sqlManagementClient.RecoverableDatabases.List(serverName);
                    this.WriteObject(response.Databases, true);
                }
            }
            catch (Exception ex)
            {
                this.WriteErrorDetails(ex);
            }
        }
    }
}
