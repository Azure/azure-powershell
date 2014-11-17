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
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Model;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Properties;
using Microsoft.WindowsAzure.Management.Sql;
using Microsoft.WindowsAzure.Management.Sql.Models;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Server.Cmdlet
{
    /// <summary>
    /// Retrieves a list of Microsoft Azure SQL Database servers in the selected subscription.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureSqlDatabaseServer", ConfirmImpact = ConfirmImpact.None)]
    public class GetAzureSqlDatabaseServer : SqlDatabaseCmdletBase
    {
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true,
            HelpMessage = "SQL Database server name.")]
        [ValidateNotNullOrEmpty]
        public string ServerName
        {
            get;
            set;
        }

        /// <summary>
        /// Retrieves one or more servers in the current subscription.
        /// </summary>
        /// <param name="serverName">
        /// The specific name of the server to retrieve, or <c>null</c> to
        /// retrieve all servers in the current subscription.
        /// </param>
        /// <returns>A list of servers in the subscription.</returns>
        internal IEnumerable<SqlDatabaseServerContext> GetAzureSqlDatabaseServersProcess(string serverName)
        {
            // Get the SQL management client for the current subscription
            SqlManagementClient sqlManagementClient = GetCurrentSqlClient();

            // Retrieve the list of servers
            ServerListResponse response = sqlManagementClient.Servers.List();
            IEnumerable<Management.Sql.Models.Server> servers = response.Servers;
            if (!string.IsNullOrEmpty(serverName))
            {
                // Server name is specified, find the one with the
                // specified rule name and return that.
                servers = response.Servers.Where(s => s.Name == serverName);
                if (!servers.Any())
                {
                    throw new ItemNotFoundException(string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.GetAzureSqlDatabaseServerNotFound,
                        serverName));
                }
            }
            else
            {
                // Server name is not specified, return all servers
                // in the subscription.
            }

            // Construct the result
            IEnumerable<SqlDatabaseServerContext> processResult = servers.Select(server => new SqlDatabaseServerContext
            {
                OperationStatus = Services.Constants.OperationSuccess,
                OperationDescription = CommandRuntime.ToString(),
                OperationId = response.RequestId,
                ServerName = server.Name,
                Location = server.Location,
                Version = server.Version,
                AdministratorLogin = server.AdministratorUserName,
                State = server.State,
            });

            return processResult;
        }

        /// <summary>
        /// Execute the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                var servers = this.GetAzureSqlDatabaseServersProcess(this.ServerName);
                this.WriteObject(servers, true);
            }
            catch (Exception ex)
            {
                this.WriteErrorDetails(ex);
            }
        }
    }
}