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
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Common;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Server;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Database.Cmdlet
{
    /// <summary>
    /// Issues a new restore request for the specified live or dropped Microsoft Azure SQL Database.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "AzureSqlDatabaseRestore", ConfirmImpact = ConfirmImpact.Low)]
    public class StartAzureSqlDatabaseRestore : AzureSMCmdlet
    {
        #region Parameter Sets

        /// <summary>
        /// The parameter set string for providing a source Database object
        /// </summary>
        internal const string BySourceDatabaseObject =
            "BySourceDatabaseObject";

        /// <summary>
        /// The parameter set string for providing a source RestorableDroppedDatabase object
        /// </summary>
        internal const string BySourceRestorableDroppedDatabaseObject =
            "BySourceRestorableDroppedDatabaseObject";

        /// <summary>
        /// The parameter set string for providing a source database name
        /// </summary>
        internal const string BySourceDatabaseName =
            "BySourceDatabaseName";

        /// <summary>
        /// The parameter set string for providing a source database name
        /// </summary>
        internal const string BySourceRestorableDroppedDatabaseName =
            "BySourceRestorableDroppedDatabaseName";

        #endregion

        #region Parameters

        /// <summary>
        /// Gets or sets the name of the server where the source database is running, or the name of the server where the database was running before it was deleted.
        /// </summary>
        [Parameter(Mandatory = false, Position = 0,
            ParameterSetName = BySourceDatabaseObject,
            HelpMessage = "The name of the server where the source database is running, or the name of the server where the database was running before it was deleted.")]
        [Parameter(Mandatory = false, Position = 0,
            ParameterSetName = BySourceRestorableDroppedDatabaseObject,
            HelpMessage = "The name of the server where the source database is running, or the name of the server where the database was running before it was deleted.")]
        [Parameter(Mandatory = true, Position = 0,
            ParameterSetName = BySourceDatabaseName,
            HelpMessage = "The name of the server where the source database is running, or the name of the server where the database was running before it was deleted.")]
        [Parameter(Mandatory = true, Position = 0,
            ParameterSetName = BySourceRestorableDroppedDatabaseName,
            HelpMessage = "The name of the server where the source database is running, or the name of the server where the database was running before it was deleted.")]
        [ValidateNotNullOrEmpty]
        public string SourceServerName { get; set; }

        /// <summary>
        /// Gets or sets the database object for the database to restore.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1,
            ValueFromPipeline = true,
            ParameterSetName = BySourceDatabaseObject,
            HelpMessage = "The database object representing the database to restore.")]
        [ValidateNotNull]
        public Services.Server.Database SourceDatabase { get; set; }

        /// <summary>
        /// Gets or sets the database object for the dropped database to restore.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1,
            ValueFromPipeline = true,
            ParameterSetName = BySourceRestorableDroppedDatabaseObject,
            HelpMessage = "The database object representing the dropped database to restore.")]
        [ValidateNotNull]
        public RestorableDroppedDatabase SourceRestorableDroppedDatabase { get; set; }

        /// <summary>
        /// Gets or sets the name of the database to restore.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1,
            ParameterSetName = BySourceDatabaseName,
            HelpMessage = "The name of the database to restore.")]
        [Parameter(Mandatory = true, Position = 1,
            ParameterSetName = BySourceRestorableDroppedDatabaseName,
            HelpMessage = "The name of the database to restore.")]
        [ValidateNotNullOrEmpty]
        public string SourceDatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the deletion date of the source restorable dropped database.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2,
            ParameterSetName = BySourceRestorableDroppedDatabaseName,
            HelpMessage = "The deletion date of the source restorable dropped database.")]
        public DateTime SourceDatabaseDeletionDate { get; set; }

        /// <summary>
        /// Gets or sets the name of the server that will host the restored database. If unspecified, the current server will host the restored database.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The name of the server that will host the restored database. If unspecified, the current server will host the restored database.")]
        [ValidateNotNullOrEmpty]
        public string TargetServerName { get; set; }

        /// <summary>
        /// Gets or sets whether the source is a live or dropped database
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = BySourceRestorableDroppedDatabaseName,
            HelpMessage = "Specify this switch to restore a restorable dropped database.")]
        public SwitchParameter RestorableDropped { get; set; }

        /// <summary>
        /// Gets or sets the name of the target database.
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The name of the target database.")]
        [ValidateNotNullOrEmpty]
        public string TargetDatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the point in time to restore to.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The point in time to restore to.")]
        public DateTime? PointInTime { get; set; }

        #endregion

        /// <summary>
        /// Execute the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            // Obtain the name of the source database / source restorable dropped database from the parameters
            this.SourceDatabaseName =
                this.SourceDatabase != null ? this.SourceDatabase.Name :
                this.SourceRestorableDroppedDatabase != null ? this.SourceRestorableDroppedDatabase.Name :
                this.SourceDatabaseName;

            // Obtain the deletion date of the source restorable dropped database from the parameters
            DateTime? sourceDatabaseDeletionDate = null;
            if (this.SourceRestorableDroppedDatabase != null)
            {
                sourceDatabaseDeletionDate = this.SourceRestorableDroppedDatabase.DeletionDate;
            }
            else if (this.RestorableDropped.IsPresent)
            {
                sourceDatabaseDeletionDate = this.SourceDatabaseDeletionDate;
            }

            // Normalize the deletion date and point in time to UTC, if given
            if (sourceDatabaseDeletionDate != null)
            {
                sourceDatabaseDeletionDate = CmdletCommon.NormalizeToUtc(sourceDatabaseDeletionDate.Value);
            }

            if (this.PointInTime != null)
            {
                this.PointInTime = CmdletCommon.NormalizeToUtc(this.PointInTime.Value);
            }

            IServerDataServiceContext connectionContext = null;

            // If a database object was piped in, use its connection context...
            if (this.SourceDatabase != null)
            {
                connectionContext = this.SourceDatabase.Context;
            }
            else if (this.SourceRestorableDroppedDatabase != null)
            {
                connectionContext = this.SourceRestorableDroppedDatabase.Context;
            }

            // ... but only if it's a cert auth context. Otherwise, create a cert auth context using this.ServerName or the server name of the SQL auth context.
            if (!(connectionContext is ServerDataServiceCertAuth))
            {
                string serverName = this.SourceServerName ?? connectionContext.ServerName;

                connectionContext = ServerDataServiceCertAuth.Create(serverName, Profile, Profile.Context.Subscription);
            }

            string clientRequestId = connectionContext.ClientRequestId;

            try
            {
                RestoreDatabaseOperation operation = connectionContext.RestoreDatabase(
                    this.SourceDatabaseName,
                    sourceDatabaseDeletionDate,
                    this.TargetServerName,
                    this.TargetDatabaseName,
                    this.PointInTime);

                this.WriteObject(operation);
            }
            catch (Exception ex)
            {
                SqlDatabaseExceptionHandler.WriteErrorDetails(
                    this,
                    clientRequestId,
                    ex);
            }
        }
    }
}
