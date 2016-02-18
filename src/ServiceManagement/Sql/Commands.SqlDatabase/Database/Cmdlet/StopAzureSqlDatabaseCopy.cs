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
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Properties;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Common;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Server;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Database.Cmdlet
{
    using DatabaseCopyModel = Model.DatabaseCopy;
    using Microsoft.Azure.Commands.Common.Authentication;

    /// <summary>
    /// Stop an ongoing copy operation for a Microsoft Azure SQL Database in the given server context.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Stop, "AzureSqlDatabaseCopy", SupportsShouldProcess = true,
        ConfirmImpact = ConfirmImpact.Medium)]
    public class StopAzureSqlDatabaseCopy : AzureSMCmdlet
    {
        #region ParameterSetNames

        internal const string ByInputObject = "ByInputObject";

        internal const string ByDatabase = "ByDatabase";

        internal const string ByDatabaseName = "ByDatabaseName";

        #endregion

        #region Parameters

        /// <summary>
        /// Gets or sets the name of the server upon which to operate
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the server to operate on.")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the sql database copy object.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ByInputObject,
            ValueFromPipeline = true, HelpMessage = "The database copy operation to stop.")]
        [ValidateNotNull]
        public DatabaseCopyModel DatabaseCopy { get; set; }

        /// <summary>
        /// Gets or sets the database object to refresh.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ByDatabase,
            ValueFromPipeline = true, HelpMessage = "The database object to stop a copy from or to.")]
        [ValidateNotNull]
        public Services.Server.Database Database { get; set; }

        /// <summary>
        /// Gets or sets the name of the database to retrieve.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ByDatabaseName,
            HelpMessage = "The name of the database to stop copy.")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the name of the partner server.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = ByDatabase,
            HelpMessage = "The name of the partner server")]
        [Parameter(Mandatory = false, ParameterSetName = ByDatabaseName,
            HelpMessage = "The name of the partner server")]
        [ValidateNotNullOrEmpty]
        public string PartnerServer { get; set; }

        /// <summary>
        /// Gets or sets the name of the partner database.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = ByDatabase,
            HelpMessage = "The name of the partner database")]
        [Parameter(Mandatory = false, ParameterSetName = ByDatabaseName,
            HelpMessage = "The name of the partner database")]
        [ValidateNotNullOrEmpty]
        public string PartnerDatabase { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to forcefully terminate the copy.
        /// </summary>
        [Parameter(HelpMessage = "Forcefully terminate the copy operation.")]
        public SwitchParameter ForcedTermination { get; set; }

        /// <summary>
        /// Gets or sets the switch to not confirm on the termination of the database copy.
        /// </summary>
        [Parameter(HelpMessage = "Do not confirm on the termination of the database copy")]
        public SwitchParameter Force { get; set; }

        #endregion

        /// <summary>
        /// Execute the command.
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

            // Use the provided ServerDataServiceContext or create one from the
            // provided ServerName and the active subscription.
            IServerDataServiceContext context = ServerDataServiceCertAuth.Create(this.ServerName,
                Profile,
                Profile.Context.Subscription);

            DatabaseCopyModel databaseCopy;
            if (this.MyInvocation.BoundParameters.ContainsKey("DatabaseCopy"))
            {
                // Refreshes the given copy object
                databaseCopy = context.GetDatabaseCopy(this.DatabaseCopy);
            }
            else
            {
                // Retrieve all database copy object with matching parameters
                DatabaseCopyModel[] copies = context.GetDatabaseCopy(
                        databaseName,
                        this.PartnerServer,
                        this.PartnerDatabase);
                if (copies.Length == 0)
                {
                    throw new ApplicationException(Resources.DatabaseCopyNotFoundGeneric);
                }
                else if (copies.Length > 1)
                {
                    throw new ApplicationException(Resources.MoreThanOneDatabaseCopyFound);
                }

                databaseCopy = copies.Single();
            }

            // Do nothing if force is not specified and user cancelled the operation
            string actionDescription = string.Format(
                CultureInfo.InvariantCulture,
                Resources.StopAzureSqlDatabaseCopyDescription,
                databaseCopy.SourceServerName,
                databaseCopy.SourceDatabaseName,
                databaseCopy.DestinationServerName,
                databaseCopy.DestinationDatabaseName);
            string actionWarning = string.Format(
                CultureInfo.InvariantCulture,
                Resources.StopAzureSqlDatabaseCopyWarning,
                databaseCopy.SourceServerName,
                databaseCopy.SourceDatabaseName,
                databaseCopy.DestinationServerName,
                databaseCopy.DestinationDatabaseName);
            this.WriteVerbose(actionDescription);
            if (!this.Force.IsPresent &&
                !this.ShouldProcess(
                    actionDescription,
                    actionWarning,
                    Resources.ShouldProcessCaption))
            {
                return;
            }

            try
            {
                // Stop the specified database copy
                context.StopDatabaseCopy(
                    databaseCopy,
                    this.ForcedTermination.IsPresent);
            }
            catch (Exception ex)
            {
                SqlDatabaseExceptionHandler.WriteErrorDetails(
                    this,
                    context.ClientRequestId,
                    ex);
            }
        }
    }
}
