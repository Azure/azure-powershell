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
    [Cmdlet(VerbsCommon.Remove, "AzureSqlDatabase", SupportsShouldProcess = true,
        ConfirmImpact = ConfirmImpact.High)]
    public class RemoveAzureSqlDatabase : AzureSMCmdlet
    {
        #region Parameter sets

        /// <summary>
        /// The name of the parameter set for removing a database by name with a connection context
        /// </summary>
        internal const string ByNameWithConnectionContext =
            "ByNameWithConnectionContext";

        /// <summary>
        /// The name of the parameter set for removing a database by name using azure subscription
        /// </summary>
        internal const string ByNameWithServerName =
            "ByNameWithServerName";

        /// <summary>
        /// The name of the parameter set for removing a database by input
        /// object with a connection context
        /// </summary>
        internal const string ByObjectWithConnectionContext =
            "ByObjectWithConnectionContext";

        /// <summary>
        /// The name of the parameter set for removing a database by input
        /// object using azure subscription
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
        [Alias("InputObject")]
        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true, 
            ParameterSetName = ByObjectWithConnectionContext,
            HelpMessage = "The database object you want to remove")]
        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true,
            ParameterSetName = ByObjectWithServerName,
            HelpMessage = "The database object you want to remove")]
        [ValidateNotNull]
        public Services.Server.Database Database { get; set; }

        /// <summary>
        /// Gets or sets the database name.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1,
            ParameterSetName = ByNameWithConnectionContext,
            HelpMessage = "The name of the database to remove")]
        [Parameter(Mandatory = true, Position = 1,
            ParameterSetName = ByNameWithServerName,
            HelpMessage = "The name of the database to remove")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the switch to not confirm on the removal of the database.
        /// </summary>
        [Parameter(HelpMessage = "Do not confirm on the removal of the database")]
        public SwitchParameter Force { get; set; }

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

            // Determine the name of the server we are connecting to
            string serverName = null;
            if (this.MyInvocation.BoundParameters.ContainsKey("ServerName"))
            {
                serverName = this.ServerName;
            }
            else
            {
                serverName = this.ConnectionContext.ServerName;
            }

            string actionDescription = string.Format(
                CultureInfo.InvariantCulture,
                Resources.RemoveAzureSqlDatabaseDescription,
                serverName,
                databaseName);

            string actionWarning = string.Format(
                CultureInfo.InvariantCulture,
                Resources.RemoveAzureSqlDatabaseWarning,
                serverName,
                databaseName);

            this.WriteVerbose(actionDescription);

            // Do nothing if force is not specified and user cancelled the operation
            if (!this.Force.IsPresent &&
                !this.ShouldProcess(
                actionDescription,
                actionWarning, 
                Resources.ShouldProcessCaption))
            {
                return;
            }

            switch (this.ParameterSetName)
            {
                case ByNameWithConnectionContext:
                case ByObjectWithConnectionContext:
                    this.ProcessWithConnectionContext(databaseName);
                    break;

                case ByNameWithServerName:
                case ByObjectWithServerName:
                    this.ProcessWithServerName(databaseName);
                    break;
            }
        }

        /// <summary>
        /// Process the request using a temporary connection context.
        /// </summary>
        /// <param name="databaseName">The name of the database to remove</param>
        private void ProcessWithServerName(string databaseName)
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
                context.RemoveDatabase(databaseName);
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
        /// Process the request with the connection context
        /// </summary>
        /// <param name="databaseName">The name of the database to remove</param>
        private void ProcessWithConnectionContext(string databaseName)
        {
            try
            {
                // Remove the database with the specified name
                this.ConnectionContext.RemoveDatabase(databaseName);
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
