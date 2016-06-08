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
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Properties;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Common;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Server;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Database.Cmdlet
{
    /// <summary>
    /// Retrieves a list of Microsoft Azure SQL Databases in the given server context.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureSqlDatabase", ConfirmImpact = ConfirmImpact.None,
        DefaultParameterSetName = ByConnectionContext)]
    public class GetAzureSqlDatabase : AzureSMCmdlet
    {
        #region Parameter Sets

        /// <summary>
        /// The parameter set string for connecting with a connection context
        /// </summary>
        internal const string ByConnectionContext =
            "ByConnectionContext";

        /// <summary>
        /// The parameter set string for connecting using azure subscription
        /// </summary>
        internal const string ByServerName =
            "ByServerName";

        #endregion

        #region Parameters

        /// <summary>
        /// Gets or sets the server connection context.
        /// </summary>
        [Alias("Context")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true,
            ParameterSetName = ByConnectionContext,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The connection context to the specified server.")]
        [ValidateNotNull]
        public IServerDataServiceContext ConnectionContext { get; set; }

        /// <summary>
        /// Gets or sets the server object upon which to operate
        /// </summary>
        [Parameter(Mandatory = true, Position = 0,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ByServerName,
            HelpMessage = "The name of the server to operate on")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the database object to refresh.
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipeline = true, HelpMessage = "The database object to refresh.")]
        [ValidateNotNull]
        public Services.Server.Database Database { get; set; }

        /// <summary>
        /// Gets or sets the name of the database to retrieve.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The name of the database to retrieve.")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets whether the commandlet returns live databases or restorable dropped databases.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Return restorable dropped databases instead of live databases.")]
        public SwitchParameter RestorableDropped { get; set; }

        /// <summary>
        /// Gets or sets the restorable dropped database object to refresh.
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipeline = true, HelpMessage = "The database object to refresh.")]
        [ValidateNotNull]
        public RestorableDroppedDatabase RestorableDroppedDatabase { get; set; }

        /// <summary>
        /// Gets or sets the deletion date of the restorable dropped database to retrieve.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The deletion date of the restorable dropped database to retrieve.")]
        [ValidateNotNullOrEmpty]
        public DateTime DatabaseDeletionDate { get; set; }

        #endregion

        #region Parameter names

        private const string DatabaseParameter = "Database";

        private const string RestorableDroppedDatabaseParameter = "RestorableDroppedDatabase";

        private const string RestorableDroppedParameter = "RestorableDropped";

        private const string DatabaseNameParameter = "DatabaseName";

        private const string DatabaseDeletionDateParameter = "DatabaseDeletionDate";

        #endregion

        /// <summary>
        /// Process the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            IServerDataServiceContext context = null;
            switch (this.ParameterSetName)
            {
                case ByConnectionContext:
                    context = this.ConnectionContext;
                    break;

                case ByServerName:
                    context = ServerDataServiceCertAuth.Create(this.ServerName, Profile, Profile.Context.Subscription);
                    break;

                default:
                    throw new NotSupportedException("ParameterSet");
            }

            ProcessWithContext(context);
        }

        /// <summary>
        /// Process the request using the provided connection context
        /// </summary>
        /// <param name="context">The connection context</param>
        private void ProcessWithContext(IServerDataServiceContext context)
        {
            // This is to enforce the mutual exclusivity of the parameters: Database
            // and DatabaseName.  This can't be done with parameter sets without changing
            // existing behaviour of the cmdlet.
            if (
                this.MyInvocation.BoundParameters.ContainsKey(DatabaseParameter) &&
                this.MyInvocation.BoundParameters.ContainsKey(DatabaseNameParameter))
            {
                this.WriteError(new ErrorRecord(
                    new PSArgumentException(
                        string.Format(Resources.InvalidParameterCombination, DatabaseParameter, DatabaseNameParameter)),
                    string.Empty,
                    ErrorCategory.InvalidArgument,
                    null));
            }

            // ... and similarly for RestorableDroppedDatabase and DatabaseName / DatabaseDeletionDate
            if (
                this.MyInvocation.BoundParameters.ContainsKey(RestorableDroppedDatabaseParameter) &&
                this.MyInvocation.BoundParameters.ContainsKey(DatabaseNameParameter))
            {
                this.WriteError(new ErrorRecord(
                    new PSArgumentException(
                        string.Format(Resources.InvalidParameterCombination, RestorableDroppedDatabaseParameter, DatabaseNameParameter)),
                    string.Empty,
                    ErrorCategory.InvalidArgument,
                    null));
            }
            if (
                this.MyInvocation.BoundParameters.ContainsKey(RestorableDroppedDatabaseParameter) &&
                this.MyInvocation.BoundParameters.ContainsKey(DatabaseDeletionDateParameter))
            {
                this.WriteError(new ErrorRecord(
                    new PSArgumentException(
                        string.Format(Resources.InvalidParameterCombination, RestorableDroppedDatabaseParameter, DatabaseDeletionDateParameter)),
                    string.Empty,
                    ErrorCategory.InvalidArgument,
                    null));
            }

            // The DatabaseDeletionDate parameter can only be used if the RestorableDropped switch is also present
            if (!this.RestorableDropped.IsPresent && this.MyInvocation.BoundParameters.ContainsKey(DatabaseDeletionDateParameter))
            {
                throw new PSArgumentException(
                    string.Format(Resources.RestorableDroppedSwitchNotSpecified, DatabaseDeletionDateParameter));
            }

            // The Database parameter can only be used if the RestorableDropped switch is not present
            if (this.RestorableDropped.IsPresent && this.MyInvocation.BoundParameters.ContainsKey(DatabaseParameter))
            {
                throw new PSArgumentException(
                    string.Format(Resources.InvalidParameterCombination, RestorableDroppedParameter, DatabaseParameter));
            }

            // If the RestorableDropped switch is present, then either both the DatabaseName and DatabaseDeletionDate parameters must be present, or neither of them should be present.
            if (
                this.RestorableDropped.IsPresent && (
                    (this.MyInvocation.BoundParameters.ContainsKey(DatabaseNameParameter) && !this.MyInvocation.BoundParameters.ContainsKey(DatabaseDeletionDateParameter)) ||
                    (!this.MyInvocation.BoundParameters.ContainsKey(DatabaseNameParameter) && this.MyInvocation.BoundParameters.ContainsKey(DatabaseDeletionDateParameter))))
            {
                throw new PSArgumentException(Resources.BothDatabaseNameAndDeletionDateNeedToBeSpecified);
            }

            // Obtain the database name from the given parameters.
            string databaseName = null;
            if (this.MyInvocation.BoundParameters.ContainsKey(DatabaseParameter))
            {
                databaseName = this.Database.Name;
            }
            else if (this.MyInvocation.BoundParameters.ContainsKey(RestorableDroppedDatabaseParameter))
            {
                databaseName = this.RestorableDroppedDatabase.Name;
            }
            else if (this.MyInvocation.BoundParameters.ContainsKey(DatabaseNameParameter))
            {
                databaseName = this.DatabaseName;
            }

            DateTime databaseDeletionDate = default(DateTime);
            if (this.MyInvocation.BoundParameters.ContainsKey(RestorableDroppedDatabaseParameter))
            {
                databaseDeletionDate = this.RestorableDroppedDatabase.DeletionDate;
            }
            else if (this.MyInvocation.BoundParameters.ContainsKey(DatabaseDeletionDateParameter))
            {
                databaseDeletionDate = this.DatabaseDeletionDate;
            }
            databaseDeletionDate = CmdletCommon.NormalizeToUtc(databaseDeletionDate);

            try
            {
                if (!this.RestorableDropped.IsPresent && this.RestorableDroppedDatabase == null)
                {
                    // Live databases

                    if (databaseName != null)
                    {
                        // Retrieve the database with the specified name
                        this.WriteObject(context.GetDatabase(databaseName), true);
                    }
                    else
                    {
                        // No name specified, retrieve all databases in the server
                        this.WriteObject(context.GetDatabases(), true);
                    }
                }

                else
                {
                    // Dropped databases

                    if (databaseName != null)
                    {
                        // Retrieve the database with the specified name
                        this.WriteObject(context.GetRestorableDroppedDatabase(databaseName, databaseDeletionDate), true);
                    }
                    else
                    {
                        // No name specified, retrieve all databases in the server
                        this.WriteObject(context.GetRestorableDroppedDatabases(), true);
                    }
                }
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