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

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Firewall.Cmdlet
{
    /// <summary>
    /// Retrieves a list of firewall rule from a Microsoft Azure SQL Database server in the selected subscription.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureSqlDatabaseServerFirewallRule", ConfirmImpact = ConfirmImpact.None)]
    public class GetAzureSqlDatabaseServerFirewallRule : SqlDatabaseCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "SQL Database server name.")]
        [ValidateNotNullOrEmpty]
        public string ServerName
        {
            get;
            set;
        }

        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = "SQL Database server firewall rule name.")]
        [ValidateNotNullOrEmpty]
        public string RuleName
        {
            get;
            set;
        }

        /// <summary>
        /// Retrieves one or more firewall rules on the specified server.
        /// </summary>
        /// <param name="serverName">The name of the server to retrieve firewall rules for.</param>
        /// <param name="ruleName">
        /// The specific name of the rule to retrieve, or <c>null</c> to
        /// retrieve all rules on the specified server.
        /// </param>
        /// <returns>A list of firewall rules on the server.</returns>
        internal IEnumerable<SqlDatabaseServerFirewallRuleContext> GetAzureSqlDatabaseServerFirewallRuleProcess(
            string serverName,
            string ruleName)
        {
            // Get the SQL management client for the current subscription
            SqlManagementClient sqlManagementClient = GetCurrentSqlClient();

            // Retrieve the list of databases
            FirewallRuleListResponse response = sqlManagementClient.FirewallRules.List(serverName);
            IEnumerable<FirewallRule> firewallRules = response.FirewallRules;

            if (!string.IsNullOrEmpty(ruleName))
            {
                // Firewall rule name is specified, find the one
                // with the specified rule name and return that.
                firewallRules = firewallRules.Where(p => p.Name == ruleName);
                if (!firewallRules.Any())
                {
                    throw new ItemNotFoundException(string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.GetAzureSqlDatabaseServerFirewallRuleNotFound,
                        ruleName,
                        serverName));
                }
            }
            else
            {
                // Firewall rule name is not specified, return all
                // firewall rules.
            }

            IEnumerable<SqlDatabaseServerFirewallRuleContext> processResult = firewallRules.Select(p => new SqlDatabaseServerFirewallRuleContext()
            {
                OperationDescription = CommandRuntime.ToString(),
                OperationStatus = Services.Constants.OperationSuccess,
                OperationId = response.RequestId,
                ServerName = serverName,
                RuleName = p.Name,
                StartIpAddress = p.StartIPAddress,
                EndIpAddress = p.EndIPAddress
            });

            return processResult;
        }

        /// <summary>
        /// Process the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                var rules = this.GetAzureSqlDatabaseServerFirewallRuleProcess(this.ServerName, this.RuleName);
                this.WriteObject(rules, true);
            }
            catch (Exception ex)
            {
                this.WriteErrorDetails(ex);
            }
        }
    }
}
