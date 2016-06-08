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
using System.Globalization;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Properties;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Common;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Server;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Database.Cmdlet
{
    /// <summary>
    /// Update settings for an existing Microsoft Azure SQL Database in the given server context.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureSqlDatabase", SupportsShouldProcess = true,
        ConfirmImpact = ConfirmImpact.Medium)]
    public class SetAzureSqlDatabase : AzureSMCmdlet
    {
        #region Parameter sets

        /// <summary>
        /// Parameter set name for updating by name with a connection context
        /// </summary>
        internal const string ByNameWithConnectionContext =
            "ByNameWithConnectionContext";

        /// <summary>
        /// Parameter set name for updating by name using azure subscription
        /// </summary>
        internal const string ByNameWithServerName =
            "ByNameWithServerName";

        /// <summary>
        /// Parameter set name for updating by input object with a connection context
        /// </summary>
        internal const string ByObjectWithConnectionContext =
            "ByObjectWithConnectionContext";

        /// <summary>
        /// Parameter set name for updating by input object with a azure subscription
        /// </summary>
        internal const string ByObjectWithServerName =
            "ByObjectWithServerName";

        #endregion

        #region Parameters

        /// <summary>
        /// Gets or sets the server connection context.
        /// </summary>
        [Alias("Context")]
        [Parameter(Mandatory = true, Position = 0,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ByNameWithConnectionContext,
            HelpMessage = "The connection context to the specified server.")]
        [Parameter(Mandatory = true, Position = 0,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ByObjectWithConnectionContext,
            HelpMessage = "The connection context to the specified server.")]
        [ValidateNotNull]
        public IServerDataServiceContext ConnectionContext { get; set; }

        /// <summary>
        /// Gets or sets the name of the server to connect to
        /// </summary>
        [Parameter(Mandatory = true, Position = 0,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ByNameWithServerName,
            HelpMessage = "The name of the server to connect to")]
        [Parameter(Mandatory = true, Position = 0,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ByObjectWithServerName,
            HelpMessage = "The name of the server to connect to")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the database.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1,
            ParameterSetName = ByObjectWithConnectionContext,
            ValueFromPipeline = true)]
        [Parameter(Mandatory = true, Position = 1,
            ParameterSetName = ByObjectWithServerName,
            ValueFromPipeline = true)]
        [ValidateNotNull]
        public Services.Server.Database Database { get; set; }

        /// <summary>
        /// Gets or sets the database name.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1,
            ParameterSetName = ByNameWithConnectionContext)]
        [Parameter(Mandatory = true, Position = 1,
            ParameterSetName = ByNameWithServerName)]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the new name for the database.
        /// </summary>
        [Alias("NewName")]
        [Parameter(Mandatory = false, HelpMessage = "The new name for the database.")]
        [ValidateNotNullOrEmpty]
        public string NewDatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the new Edition value for the database.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The new edition for the database.")]
        public DatabaseEdition Edition { get; set; }

        /// <summary>
        /// Gets or sets the new maximum size for the database in GB.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The new maximum size for the database in GB." +
            "This is not to be used in conjunction with MaxSizeBytes.")]
        public int MaxSizeGB { get; set; }

        /// <summary>
        /// Gets or sets the new maximum size for the database in bytes.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The new maximum size for the database in Bytes." +
            "This is not to be used in conjunction with MaxSizeGB.")]
        public long MaxSizeBytes { get; set; }

        /// <summary>
        /// Gets or sets the new ServiceObjective for this database.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The new ServiceObjective for the database.")]
        [ValidateNotNull]
        public ServiceObjective ServiceObjective { get; set; }

        /// <summary>
        /// Gets or sets the switch to output the target object to the pipeline.
        /// </summary>
        [Parameter(HelpMessage = "Pass through the input object to the output pipeline")]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Gets or sets the switch to not confirm on the altering of the database.
        /// </summary>
        [Parameter(HelpMessage = "Do not confirm on the altering of the database")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Gets or sets the switch to wait for the operation to complete on the server before returning
        /// </summary>
        [Parameter(HelpMessage = "Wait for the update operation to complete (synchronously)")]
        public SwitchParameter Sync { get; set; }

        #endregion

        /// <summary>
        /// Process the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            // Obtain the database name from the given parameters.
            string databaseName = null;
            if (this.MyInvocation.BoundParameters.ContainsKey("Database"))
            {
                databaseName = this.Database.Name;
            }
            else if (this.MyInvocation.BoundParameters.ContainsKey("DatabaseName"))
            {
                databaseName = this.DatabaseName;
            }

            // Obtain the name of the server 
            string serverName = null;
            if (this.MyInvocation.BoundParameters.ContainsKey("ServerName"))
            {
                serverName = this.ServerName;
            }
            else
            {
                serverName = this.ConnectionContext.ServerName;
            }

            // Determine the max size of the db
            int? maxSizeGb = null;
            if (this.MyInvocation.BoundParameters.ContainsKey("MaxSizeGB"))
            {
                maxSizeGb = this.MaxSizeGB;
            }

            long? maxSizeBytes = null;
            if (this.MyInvocation.BoundParameters.ContainsKey("MaxSizeBytes"))
            {
                maxSizeBytes = this.MaxSizeBytes;
            }

            // Determine the edition for the db
            DatabaseEdition? edition = null;
            if (this.MyInvocation.BoundParameters.ContainsKey("Edition"))
            {
                edition = this.Edition;
            }

            string actionDescription = string.Format(
                CultureInfo.InvariantCulture,
                Resources.SetAzureSqlDatabaseDescription,
                serverName,
                databaseName);

            string actionWarning = string.Format(
                CultureInfo.InvariantCulture,
                Resources.SetAzureSqlDatabaseWarning,
                serverName,
                databaseName);

            this.WriteVerbose(actionDescription);

            // Do nothing if force is not specified and user cancelled the operation
            if (!this.Force.IsPresent &&
                !this.ShouldProcess(actionDescription, actionWarning, Resources.ShouldProcessCaption))
            {
                return;
            }

            // If service objective is specified, ask the user to confirm the change
            if (!this.Force.IsPresent &&
                this.ServiceObjective != null)
            {
                string serviceObjectiveWarning = string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.SetAzureSqlDatabaseServiceObjectiveWarning,
                    serverName,
                    databaseName);
                if (!this.ShouldContinue(
                    serviceObjectiveWarning,
                    Resources.ShouldProcessCaption))
                {
                    return;
                }
            }

            switch (this.ParameterSetName)
            {
                case ByNameWithConnectionContext:
                case ByObjectWithConnectionContext:
                    this.ProcessWithConnectionContext(databaseName, maxSizeGb, maxSizeBytes, edition);
                    break;

                case ByNameWithServerName:
                case ByObjectWithServerName:
                    this.ProcessWithServerName(databaseName, maxSizeGb, maxSizeBytes, edition);
                    break;
            }
        }

        /// <summary>
        /// Process the request using a temporary connection context using certificate authentication
        /// </summary>
        /// <param name="databaseName">The name of the database to update</param>
        /// <param name="maxSizeGb">the new size for the database or null</param>
        /// <param name="maxSizeBytes"></param>
        /// <param name="edition">the new edition for the database or null</param>
        private void ProcessWithServerName(string databaseName, int? maxSizeGb, long? maxSizeBytes, DatabaseEdition? edition)
        {
            Func<string> GetClientRequestId = () => string.Empty;
            try
            {
                // Get the current subscription data.
                AzureSubscription subscription = Profile.Context.Subscription;

                // Create a temporary context
                ServerDataServiceCertAuth context =
                    ServerDataServiceCertAuth.Create(this.ServerName, Profile, subscription);

                GetClientRequestId = () => context.ClientRequestId;

                // Remove the database with the specified name
                Services.Server.Database database = context.UpdateDatabase(
                    databaseName,
                    this.NewDatabaseName,
                    maxSizeGb,
                    maxSizeBytes,
                    edition,
                    this.ServiceObjective);

                if (this.Sync.IsPresent)
                {
                    // Wait for the operation to complete on the server.
                    database = CmdletCommon.WaitForDatabaseOperation(this, context, database, this.DatabaseName, false);
                }

                // Update the passed in database object
                if (this.MyInvocation.BoundParameters.ContainsKey("Database"))
                {
                    this.Database.CopyFields(database);
                    database = this.Database;
                }

                // If PassThru was specified, write back the updated object to the pipeline
                if (this.PassThru.IsPresent)
                {
                    this.WriteObject(database);
                }
            }
            catch (Exception ex)
            {
                SqlDatabaseExceptionHandler.WriteErrorDetails(
                    this,
                    GetClientRequestId(),
                    ex);
            }
        }

        /// <summary>
        /// process the request using the connection context.
        /// </summary>
        /// <param name="databaseName">the name of the database to alter</param>
        /// <param name="maxSizeGb">the new maximum size for the database</param>
        /// <param name="maxSizeBytes"></param>
        /// <param name="edition">the new edition for the database</param>
        private void ProcessWithConnectionContext(string databaseName, int? maxSizeGb, long? maxSizeBytes, DatabaseEdition? edition)
        {
            try
            {
                // Update the database with the specified name
                Services.Server.Database database = this.ConnectionContext.UpdateDatabase(
                    databaseName,
                    this.NewDatabaseName,
                    maxSizeGb,
                    maxSizeBytes,
                    edition,
                    this.ServiceObjective);

                if (this.Sync.IsPresent)
                {
                    // Wait for the operation to complete on the server.
                    database = CmdletCommon.WaitForDatabaseOperation(this, this.ConnectionContext, database, this.DatabaseName, false);
                }

                // If PassThru was specified, write back the updated object to the pipeline
                if (this.PassThru.IsPresent)
                {
                    this.WriteObject(database);
                }

                if (this.ConnectionContext.GetType() == typeof(ServerDataServiceCertAuth))
                {
                    if (this.MyInvocation.BoundParameters.ContainsKey("Database"))
                    {
                        this.Database.CopyFields(database);
                    }
                }
            }
            catch (Exception ex)
            {
                SqlDatabaseExceptionHandler.WriteErrorDetails(
                    this,
                    this.ConnectionContext.ClientRequestId,
                    ex);
            }
        }
    }
}
