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
using Microsoft.Azure;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Server.Cmdlet
{
    /// <summary>
    /// Removes an existing Microsoft Azure SQL Database server in the selected subscription.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureSqlDatabaseServer", SupportsShouldProcess = true,
        ConfirmImpact = ConfirmImpact.High)]
    public class RemoveAzureSqlDatabaseServer : SqlDatabaseCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "SQL Database server name.")]
        [ValidateNotNullOrEmpty]
        public string ServerName
        {
            get;
            set;
        }

        [Parameter(HelpMessage = "Do not confirm on the deletion of the server")]
        public SwitchParameter Force
        {
            get;
            set;
        }

        /// <summary>
        /// Removes an existing server in the current subscription.
        /// </summary>
        /// <param name="serverName">The name of the server to remove.</param>
        /// <returns>The context to this operation.</returns>
        internal SqlDatabaseServerOperationContext RemoveAzureSqlDatabaseServerProcess(string serverName)
        {
            // Do nothing if force is not specified and user cancelled the operation
            if (!Force.IsPresent &&
                !ShouldProcess(
                    string.Format(CultureInfo.InvariantCulture, Resources.RemoveAzureSqlDatabaseServerDescription, serverName),
                    string.Format(CultureInfo.InvariantCulture, Resources.RemoveAzureSqlDatabaseServerWarning, serverName),
                    Resources.ShouldProcessCaption))
            {
                return null;
            }

            // Get the SQL management client for the current subscription
            SqlManagementClient sqlManagementClient = GetCurrentSqlClient();

            // Issue the delete server request
            AzureOperationResponse response = sqlManagementClient.Servers.Delete(serverName);
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
                this.RemoveAzureSqlDatabaseServerProcess(this.ServerName);
            }
            catch (Exception ex)
            {
                this.WriteErrorDetails(ex);
            }
        }
    }
}
