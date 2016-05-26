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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Properties;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Common;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Server;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Database.Cmdlet
{
    /// <summary>
    /// Creates a new Microsoft Azure SQL Databases in the given server context.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureSqlDatabase", SupportsShouldProcess = true,
        ConfirmImpact = ConfirmImpact.Low)]
    public class NewAzureSqlDatabase : AzureSMCmdlet
    {
        #region Parameter Sets

        /// <summary>
        /// The name of the parameter set for connection with a connection context
        /// </summary>
        internal const string ByConnectionContext =
            "ByConnectionContext";

        /// <summary>
        /// The name of the parameter set for connecting with an azure subscription
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
            HelpMessage = "The connection context to the specified server.")]
        [ValidateNotNull]
        public IServerDataServiceContext ConnectionContext { get; set; }

        /// <summary>
        /// Gets or sets the name of the server to connect to
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true,
            ParameterSetName = ByServerName,
            HelpMessage = "The name of the server to connect to using the current subscription")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the database name.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1,
            HelpMessage = "The name of the new database.")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the collation for the newly created database.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Collation for the newly created database.")]
        [ValidateNotNullOrEmpty]
        public string Collation { get; set; }

        /// <summary>
        /// Gets or sets the edition for the newly created database.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The edition for the database.")]
        public DatabaseEdition Edition { get; set; }

        /// <summary>
        /// Gets or sets the new ServiceObjective for this database.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The new ServiceObjective for the database.")]
        [ValidateNotNull]
        public ServiceObjective ServiceObjective { get; set; }

        /// <summary>
        /// Gets or sets the maximum size of the newly created database in GB.  Not to be used
        /// in conjunction with MaxSizeBytes.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The maximum size for the database in GB.  Not to " +
            "be used together with MaxSizeBytes")]
        public int MaxSizeGB { get; set; }

        /// <summary>
        /// Gets or sets the maximum size of the newly created database in Bytes.  Not to be used
        /// in conjunction with MaxSizeGB
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The maximum size for the database in Bytes.  Not to " +
            "be used together with MaxSizeGB")]
        public long MaxSizeBytes { get; set; }

        /// <summary>
        /// Gets or sets the switch to not confirm on the creation of the database.
        /// </summary>
        [Parameter(HelpMessage = "Do not confirm on the creation of the database")]
        public SwitchParameter Force { get; set; }

        #endregion

        /// <summary>
        /// Process the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            // Do nothing if force is not specified and user cancelled the operation
            if (!this.Force.IsPresent &&
                !this.ShouldProcess(
                Resources.NewAzureSqlDatabaseDescription,
                Resources.NewAzureSqlDatabaseWarning,
                Resources.ShouldProcessCaption))
            {
                return;
            }

            // Determine the max size for the Database or null
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

            switch (this.ParameterSetName)
            {
                case ByConnectionContext:
                    this.ProcessWithConnectionContext(maxSizeGb, maxSizeBytes);
                    break;
                case ByServerName:
                    this.ProcessWithServerName(maxSizeGb, maxSizeBytes);
                    break;
            }
        }

        /// <summary>
        /// Process the request using the server name
        /// </summary>
        /// <param name="maxSizeGb">the maximum size of the database</param>
        /// <param name="maxSizeBytes"></param>
        private void ProcessWithServerName(int? maxSizeGb, long? maxSizeBytes)
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

                Services.Server.Database response = context.CreateNewDatabase(
                    this.DatabaseName,
                    maxSizeGb,
                    maxSizeBytes,
                    this.Collation,
                    this.Edition,
                    this.ServiceObjective);
                
                response = CmdletCommon.WaitForDatabaseOperation(this, context, response, this.DatabaseName, true);

                // Retrieve the database with the specified name
                this.WriteObject(response);
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
        /// Process the request using the connection context.
        /// </summary>
        /// <param name="maxSizeGb">the maximum size for the new database</param>
        /// <param name="maxSizeBytes"></param>
        private void ProcessWithConnectionContext(int? maxSizeGb, long? maxSizeBytes)
        {
            try
            {
                Services.Server.Database database = this.ConnectionContext.CreateNewDatabase(
                    this.DatabaseName,
                    maxSizeGb,
                    maxSizeBytes,
                    this.Collation,
                    this.Edition,
                    this.ServiceObjective);

                database = CmdletCommon.WaitForDatabaseOperation(this, this.ConnectionContext, database, this.DatabaseName, true);

                this.WriteObject(database, true);
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
