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
using Microsoft.WindowsAzure.Commands.SqlDatabase.Model;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Properties;
using Microsoft.WindowsAzure.Management.Sql;
using Microsoft.WindowsAzure.Management.Sql.Models;
using Microsoft.Azure;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Server.Cmdlet
{
    /// <summary>
    /// Update settings for an existing Microsoft Azure SQL Database server in the selected subscription.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureSqlDatabaseServer", SupportsShouldProcess = true,
        ConfirmImpact = ConfirmImpact.Medium)]
    public class SetAzureSqlDatabaseServer : SqlDatabaseCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "SQL Database server name.")]
        [ValidateNotNullOrEmpty]
        public string ServerName
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "ResetServerAdminPassword", HelpMessage = "SQL Database administrator login password.")]
        [ValidateNotNullOrEmpty]
        public string AdminPassword
        {
            get;
            set;
        }

        [Parameter(HelpMessage = "Do not confirm on the change of administrator login password for the server")]
        public SwitchParameter Force
        {
            get;
            set;
        }

        /// <summary>
        /// Resets the administrator password for an existing server in the
        /// current subscription.
        /// </summary>
        /// <param name="serverName">
        /// The name of the server for which to reset the password.
        /// </param>
        /// <param name="newPassword">
        /// The new password for the server.
        /// </param>
        /// <returns>The context to this operation.</returns>
        internal SqlDatabaseServerOperationContext ResetAzureSqlDatabaseServerAdminPasswordProcess(string serverName, string newPassword)
        {
            // Do nothing if force is not specified and user cancelled the operation
            if (!Force.IsPresent &&
                !ShouldProcess(
                    string.Format(CultureInfo.InvariantCulture, Resources.SetAzureSqlDatabaseServerAdminPasswordDescription, serverName),
                    string.Format(CultureInfo.InvariantCulture, Resources.SetAzureSqlDatabaseServerAdminPasswordWarning, serverName),
                    Resources.ShouldProcessCaption))
            {
                return null;
            }

            // Get the SQL management client for the current subscription
            SqlManagementClient sqlManagementClient = GetCurrentSqlClient();

            // Issue the change admin password request
            AzureOperationResponse response = sqlManagementClient.Servers.ChangeAdministratorPassword(
                serverName, 
                new ServerChangeAdministratorPasswordParameters()
                {
                    NewPassword = newPassword
                });

            SqlDatabaseServerOperationContext operationContext = new SqlDatabaseServerOperationContext()
            {
                OperationStatus = Services.Constants.OperationSuccess,
                OperationDescription = CommandRuntime.ToString(),
                OperationId = response.RequestId,
                ServerName = serverName,
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
                object operationContext = this.ResetAzureSqlDatabaseServerAdminPasswordProcess(this.ServerName, this.AdminPassword);
            }
            catch (Exception ex)
            {
                this.WriteErrorDetails(ex);
            }
        }
    }
}
