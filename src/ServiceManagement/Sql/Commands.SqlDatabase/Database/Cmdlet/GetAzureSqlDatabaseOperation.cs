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
    /// Retrieves a list of Microsoft Azure SQL Database's Operations in the given server context.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureSqlDatabaseOperation", ConfirmImpact = ConfirmImpact.None,
        DefaultParameterSetName = ByConnectionContext)]
    public class GetAzureSqlDatabaseOperation : AzureSMCmdlet
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
        /// Gets or sets the server name upon which to operate
        /// </summary>
        [Parameter(Mandatory = true, Position = 0,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ByServerName,
            HelpMessage = "The name of the server to operate on")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the database object to retrieve operations.
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipeline = true, 
            HelpMessage = "The database object to retrieve operations.")]
        [ValidateNotNull]
        public Services.Server.Database Database { get; set; }

        /// <summary>
        /// Gets or sets the name of the database to retrieve operations.
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the database to retrieve operations.")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the name of the database operation Guid to retrieve.
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "The guid of the database operation to retrieve.")]
        [ValidateNotNullOrEmpty]
        public Guid OperationGuid { get; set; }

        #endregion

        /// <summary>
        /// Process the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            ParameterValidation();
            IServerDataServiceContext context = null;
            switch (this.ParameterSetName)
            {
                case ByConnectionContext:
                    context = this.ConnectionContext;
                    break;

                case ByServerName:
                    context = ServerDataServiceCertAuth.Create(this.ServerName, Profile, Profile.Context.Subscription);
                    break;
            }
            ProcessWithContext(context);
        }

        private void ParameterValidation()
        {
            // This is to enforce the mutual exclusivity of the parameters: Database
            // and DatabaseName.  This can't be done with parameter sets without changing
            // existing behaviour of the cmdlet.
            if (this.MyInvocation.BoundParameters.ContainsKey("Database") &&
                this.MyInvocation.BoundParameters.ContainsKey("DatabaseName"))
            {
                this.WriteError(new ErrorRecord(
                    new PSArgumentException(
                        String.Format(Resources.InvalidParameterCombination, "Database", "DatabaseName")),
                    string.Empty,
                    ErrorCategory.InvalidArgument,
                    null));
            }

            // The API doesn't allow supplying a database name and and operation GUID. 
            if (this.MyInvocation.BoundParameters.ContainsKey("DatabaseName") &&
                this.MyInvocation.BoundParameters.ContainsKey("OperationGuid"))
            {
                this.WriteError(new ErrorRecord(
                    new PSArgumentException(
                        String.Format(Resources.InvalidParameterCombination, "DatabaseName", "OperationGuid")),
                    string.Empty,
                    ErrorCategory.InvalidArgument,
                    null));
            }

            // The API doesn't allow supplying a database name and and operation GUID. 
            if (this.MyInvocation.BoundParameters.ContainsKey("Database") &&
                this.MyInvocation.BoundParameters.ContainsKey("OperationGuid"))
            {
                this.WriteError(new ErrorRecord(
                    new PSArgumentException(
                        String.Format(Resources.InvalidParameterCombination, "Database", "OperationGuid")),
                    string.Empty,
                    ErrorCategory.InvalidArgument,
                    null));
            }
        }

        /// <summary>
        /// Process the request using the provided connection context
        /// </summary>
        /// <param name="context"></param>
        private void ProcessWithContext(IServerDataServiceContext context)
        {
            try
            {
                if (this.DatabaseName != null)
                {
                    // Retrieve the operations with the specified database name
                    this.WriteObject(context.GetDatabaseOperations(this.DatabaseName), true);
                }
                else if (this.Database != null)
                {
                    // Retrieve the operations with the database name specified by the database object
                    this.WriteObject(context.GetDatabaseOperations(this.Database.Name), true);
                }
                else if (this.OperationGuid != Guid.Empty)
                {
                    // Retrieve the operation with the operation Guid
                    this.WriteObject(context.GetDatabaseOperation(this.OperationGuid), true);
                }
                else
                {
                    // No name specified, retrieve all database's operations in the server
                    this.WriteObject(context.GetDatabasesOperations(), true);
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