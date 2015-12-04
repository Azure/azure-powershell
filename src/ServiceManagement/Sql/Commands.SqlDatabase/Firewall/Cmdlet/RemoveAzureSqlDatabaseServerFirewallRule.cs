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

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Firewall.Cmdlet
{
    /// <summary>
    /// Deletes a firewall rule from a Microsoft Azure SQL Database server in the selected subscription.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureSqlDatabaseServerFirewallRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    public class RemoveAzureSqlDatabaseServerFirewallRule : SqlDatabaseCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "SQL Database server name.")]
        [ValidateNotNullOrEmpty]
        public string ServerName
        {
            get;
            set;
        }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "SQL Database server firewall rule name.")]
        [ValidateNotNullOrEmpty]
        public string RuleName
        {
            get;
            set;
        }

        [Parameter(HelpMessage = "Do not confirm on the creation of the firewall rule")]
        public SwitchParameter Force
        {
            get;
            set;
        }

        /// <summary>
        /// Removes a new firewall rule on the specified server.
        /// </summary>
        /// <param name="serverName">
        /// The name of the server containing the firewall rule.
        /// </param>
        /// <param name="ruleName">
        /// The name of the firewall rule to remove.
        /// </param>
        /// <returns>The context to this operation.</returns>
        internal SqlDatabaseServerOperationContext RemoveAzureSqlDatabaseServerFirewallRuleProcess(string serverName, string ruleName)
        {
            // Do nothing if force is not specified and user cancelled the operation
            if (!Force.IsPresent &&
                !ShouldProcess(
                    string.Format(CultureInfo.InvariantCulture, Resources.RemoveAzureSqlDatabaseServerFirewallRuleDescription, ruleName, serverName),
                    string.Format(CultureInfo.InvariantCulture, Resources.RemoveAzureSqlDatabaseServerFirewallRuleWarning, ruleName, serverName),
                    Resources.ShouldProcessCaption))
            {
                return null;
            }

            // Get the SQL management client for the current subscription
            SqlManagementClient sqlManagementClient = GetCurrentSqlClient();

            // Delete the specified firewall rule.
            AzureOperationResponse response = sqlManagementClient.FirewallRules.Delete(serverName, ruleName);

            SqlDatabaseServerOperationContext operationContext = new SqlDatabaseServerOperationContext()
            {
                OperationStatus = Services.Constants.OperationSuccess,
                OperationDescription = CommandRuntime.ToString(),
                OperationId = response.RequestId,
                ServerName = serverName
            };

            return operationContext;
        }

        /// <summary>
        /// Process the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                this.RemoveAzureSqlDatabaseServerFirewallRuleProcess(this.ServerName, this.RuleName);
            }
            catch (Exception ex)
            {
                this.WriteErrorDetails(ex);
            }
        }
    }
}
