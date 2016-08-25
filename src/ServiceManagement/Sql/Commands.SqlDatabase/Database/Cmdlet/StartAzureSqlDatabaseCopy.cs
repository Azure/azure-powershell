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
using Microsoft.WindowsAzure.Commands.SqlDatabase.Properties;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Common;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Server;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Database.Cmdlet
{
    using DatabaseCopyModel = Model.DatabaseCopy;
    using Microsoft.Azure.Commands.Common.Authentication;

    /// <summary>
    /// Start a copy operation for a Microsoft Azure SQL Database in the given server context.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "AzureSqlDatabaseCopy", SupportsShouldProcess = true,
        ConfirmImpact = ConfirmImpact.Low)]
    public class StartAzureSqlDatabaseCopy : AzureSMCmdlet
    {
        #region ParameterSets

        internal const string ByInputObjectContinuous = "ByInputObjectContinuous";

        internal const string ByDatabaseNameContinuous = "ByDatabaseNameContinuous";

        internal const string ByInputObject = "ByInputObject";

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
        /// Gets or sets the database to copy.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ByInputObject,
            ValueFromPipeline = true, HelpMessage = "The database object to copy.")]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ByInputObjectContinuous,
            ValueFromPipeline = true, HelpMessage = "The database object to copy.")]
        [ValidateNotNull]
        public Services.Server.Database Database { get; set; }

        /// <summary>
        /// Gets or sets the name of the database to copy.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ByDatabaseName,
            HelpMessage = "The name of the database to copy.")]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ByDatabaseNameContinuous,
            HelpMessage = "The name of the database to copy.")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the name of the partner server.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = ByInputObject,
            HelpMessage = "The name of the partner server.")]
        [Parameter(Mandatory = false, ParameterSetName = ByDatabaseName,
            HelpMessage = "The name of the partner server.")]
        [Parameter(Mandatory = true, ParameterSetName = ByInputObjectContinuous,
            HelpMessage = "The name of the partner server.")]
        [Parameter(Mandatory = true, ParameterSetName = ByDatabaseNameContinuous,
            HelpMessage = "The name of the partner server.")]
        [ValidateNotNullOrEmpty]
        public string PartnerServer { get; set; }

        /// <summary>
        /// Gets or sets the name of the partner database.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = ByInputObject,
            HelpMessage = "The name of the partner database.")]
        [Parameter(Mandatory = true, ParameterSetName = ByDatabaseName,
            HelpMessage = "The name of the partner database.")]
        [Parameter(Mandatory = false, ParameterSetName = ByInputObjectContinuous,
            HelpMessage = "The name of the partner database.")]
        [Parameter(Mandatory = false, ParameterSetName = ByDatabaseNameContinuous,
            HelpMessage = "The name of the partner database.")]
        [ValidateNotNullOrEmpty]
        public string PartnerDatabase { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to make this a continuous copy.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = ByInputObjectContinuous,
            HelpMessage = "Whether to make this a continuous copy.")]
        [Parameter(Mandatory = true, ParameterSetName = ByDatabaseNameContinuous,
            HelpMessage = "Whether to make this a continuous copy.")]
        public SwitchParameter ContinuousCopy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this is an offline secondary copy.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = ByInputObjectContinuous,
            HelpMessage = "Whether this is an offline secondary copy.")]
        [Parameter(Mandatory = false, ParameterSetName = ByDatabaseNameContinuous,
            HelpMessage = "Whether this is an offline secondary copy.")]
        public SwitchParameter OfflineSecondary { get; set; }

        /// <summary>
        /// Gets or sets the switch to not confirm on the start of the database copy.
        /// </summary>
        [Parameter(HelpMessage = "Do not confirm on the start of the database copy.")]
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

            string partnerServerName = this.PartnerServer;
            string partnerDatabaseName = this.PartnerDatabase;

            if (this.ContinuousCopy.IsPresent)
            {
                // Default partnerDatabaseName to the only allowed value for continuous copies.
                partnerDatabaseName = partnerDatabaseName ?? databaseName;
            }
            else
            {
                // Default partnerServerName to the only allowed value for normal copies.
                partnerServerName = partnerServerName ?? this.ServerName;
            }

            // Do nothing if force is not specified and user cancelled the operation
            string actionDescription = string.Format(
                CultureInfo.InvariantCulture,
                Resources.StartAzureSqlDatabaseCopyDescription,
                this.ServerName,
                databaseName,
                partnerServerName,
                partnerDatabaseName);
            string actionWarning = string.Format(
                CultureInfo.InvariantCulture,
                Resources.StartAzureSqlDatabaseCopyWarning,
                this.ServerName,
                databaseName,
                partnerServerName,
                partnerDatabaseName);
            this.WriteVerbose(actionDescription);
            if (!this.Force.IsPresent &&
                !this.ShouldProcess(
                    actionDescription,
                    actionWarning,
                    Resources.ShouldProcessCaption))
            {
                return;
            }

            // Use the provided ServerDataServiceContext or create one from the
            // provided ServerName and the active subscription.
            IServerDataServiceContext context = ServerDataServiceCertAuth.Create(this.ServerName,
                Profile,
                Profile.Context.Subscription);

            try
            {
                // Update the database with the specified name
                DatabaseCopyModel databaseCopy = context.StartDatabaseCopy(
                    databaseName,
                    partnerServerName,
                    partnerDatabaseName,
                    this.ContinuousCopy.IsPresent,
                    this.OfflineSecondary.IsPresent);

                this.WriteObject(databaseCopy, true);
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
