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

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Database.Cmdlet
{
    using DatabaseCopyModel = Model.DatabaseCopy;
    using Microsoft.Azure.Commands.Common.Authentication;

    /// <summary>
    /// Retrieves a list of all ongoing Microsoft Azure SQL Database copy operations in the given
    /// server context.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureSqlDatabaseCopy", ConfirmImpact = ConfirmImpact.None,
        DefaultParameterSetName = "ByServerNameOnly")]
    public class GetAzureSqlDatabaseCopy : AzureSMCmdlet
    {
        #region Parameter Sets

        internal const string ByInputObject = "ByInputObject";

        internal const string ByDatabase = "ByDatabase";

        internal const string ByServerNameOnly = "ByServerNameOnly";

        #endregion

        #region Parameters

        /// <summary>
        /// Gets or sets the server upon which to operate
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the server to operate on.")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the sql database copy object to refresh.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ByInputObject,
            ValueFromPipeline = true, HelpMessage = "The database copy operation to refresh.")]
        [ValidateNotNull]
        public DatabaseCopyModel DatabaseCopy { get; set; }

        /// <summary>
        /// Database to filter copies by.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ByDatabase,
            ValueFromPipeline = true, HelpMessage = "The database object for the copy operation.")]
        [ValidateNotNull]
        public Services.Server.Database Database { get; set; }

        /// <summary>
        /// Name of a database to filter copies by.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ParameterSetName = ByServerNameOnly,
            HelpMessage = "The name of the database for the copy operation.")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the name of the partner server.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = ByDatabase,
            HelpMessage = "The name of the partner server")]
        [Parameter(Mandatory = false, ParameterSetName = ByServerNameOnly,
            HelpMessage = "The name of the partner server")]
        [ValidateNotNullOrEmpty]
        public string PartnerServer { get; set; }

        /// <summary>
        /// Gets or sets the name of the partner database.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = ByDatabase,
            HelpMessage = "The name of the partner database")]
        [Parameter(Mandatory = false, ParameterSetName = ByServerNameOnly,
            HelpMessage = "The name of the partner database")]
        [ValidateNotNullOrEmpty]
        public string PartnerDatabase { get; set; }

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

            try
            {
                if (this.MyInvocation.BoundParameters.ContainsKey("DatabaseCopy"))
                {
                    // Refresh the specified database copy object
                    this.WriteObject(context.GetDatabaseCopy(this.DatabaseCopy), true);
                }
                else
                {
                    // Retrieve all database copy object with matching parameters
                    DatabaseCopyModel[] copies = context.GetDatabaseCopy(
                        databaseName,
                        this.PartnerServer,
                        this.PartnerDatabase);
                    this.WriteObject(copies, true);
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
