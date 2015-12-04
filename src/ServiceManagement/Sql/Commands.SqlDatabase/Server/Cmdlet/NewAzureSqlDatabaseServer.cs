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

using Hyak.Common.TransientFaultHandling;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Model;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Properties;
using Microsoft.WindowsAzure.Management.Sql;
using Microsoft.WindowsAzure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Server.Cmdlet
{

    /// <summary>
    /// Creates a new Microsoft Azure SQL Database server in the selected subscription.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureSqlDatabaseServer", SupportsShouldProcess = true,
        ConfirmImpact = ConfirmImpact.Low)]
    public class NewAzureSqlDatabaseServer : SqlDatabaseCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true,
            HelpMessage = "Administrator login name for the new SQL Database server.")]
        [ValidateNotNullOrEmpty]
        public string AdministratorLogin
        {
            get;
            set;
        }

        [Parameter(Mandatory = true,
            HelpMessage = "Administrator login password for the new SQL Database server.")]
        [ValidateNotNullOrEmpty]
        public string AdministratorLoginPassword
        {
            get;
            set;
        }

        [Parameter(Mandatory = true,
            HelpMessage = "Location in which to create the new SQL Database server.")]
        [ValidateNotNullOrEmpty]
        public string Location
        {
            get;
            set;
        }

        [Parameter(Mandatory = false,
            HelpMessage = "The version for the server that will be created.")]
        public float Version
        {
            get;
            set;
        }

        [Parameter(HelpMessage = "Do not confirm on the creation of the server")]
        public SwitchParameter Force
        {
            get;
            set;
        }

        /// <summary>
        /// Creates a new server in the current subscription.
        /// </summary>
        /// <param name="adminLogin">
        /// The administrator login name for the new server.
        /// </param>
        /// <param name="adminLoginPassword">
        /// The administrator login password for the new server.
        /// </param>
        /// <param name="location">
        /// The location in which to create the new server.
        /// </param>
        /// <returns>The context to the newly created server.</returns>
        internal SqlDatabaseServerContext NewAzureSqlDatabaseServerProcess(
            string adminLogin,
            string adminLoginPassword,
            string location,
            float? version)
        {
            // Do nothing if force is not specified and user cancelled the operation
            if (!Force.IsPresent &&
                !ShouldProcess(
                    Resources.NewAzureSqlDatabaseServerDescription,
                    Resources.NewAzureSqlDatabaseServerWarning,
                    Resources.ShouldProcessCaption))
            {
                return null;
            }

            // Get the SQL management client for the current subscription
            SqlManagementClient sqlManagementClient = GetCurrentSqlClient();

            // Set the retry policty to not retry attempts.
            sqlManagementClient.SetRetryPolicy(new RetryPolicy(new DefaultHttpErrorDetectionStrategy(), 0));

            // Issue the create server request
            ServerCreateResponse response = sqlManagementClient.Servers.Create(
                new ServerCreateParameters()
                {
                    Location = location,
                    AdministratorUserName = adminLogin,
                    AdministratorPassword = adminLoginPassword,
                    Version = version.HasValue ? version.Value.ToString("F1", CultureInfo.InvariantCulture) : null
                });

            var newServer = sqlManagementClient.Servers.List().Servers.Where(s => s.Name == response.ServerName).FirstOrDefault();

            if (newServer == null)
            {
                throw new ItemNotFoundException(string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.CreateServerServerNotFound,
                    response.ServerName));
            }

            SqlDatabaseServerContext operationContext = new SqlDatabaseServerContext()
            {
                OperationStatus = Services.Constants.OperationSuccess,
                OperationDescription = CommandRuntime.ToString(),
                OperationId = response.RequestId,
                ServerName = newServer.Name,
                Location = location,
                AdministratorLogin = adminLogin,
                State = newServer.State,
                Version = newServer.Version
            };

            return operationContext;
        }

        /// <summary>
        /// Execute the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                // Get the version from the command line
                float? version = null;
                if (this.MyInvocation.BoundParameters.ContainsKey("Version"))
                {
                    version = this.Version;
                }

                SqlDatabaseServerContext context = this.NewAzureSqlDatabaseServerProcess(
                    this.AdministratorLogin,
                    this.AdministratorLoginPassword,
                    this.Location,
                    version);

                if (context != null)
                {
                    WriteObject(context, true);
                }
            }
            catch (Exception ex)
            {
                this.WriteErrorDetails(ex);
            }
        }
    }
}
