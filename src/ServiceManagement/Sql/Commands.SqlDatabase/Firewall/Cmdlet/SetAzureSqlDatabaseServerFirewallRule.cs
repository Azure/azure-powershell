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

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Firewall.Cmdlet
{
    /// <summary>
    /// Update an existing firewall rule for a Microsoft Azure SQL Database server in the selected subscription.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureSqlDatabaseServerFirewallRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Low)]
    public class SetAzureSqlDatabaseServerFirewallRule : SqlDatabaseCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "SQL Database server name.")]
        [ValidateNotNullOrEmpty]
        public string ServerName
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "SQL Database server firewall rule name.")]
        [ValidateNotNullOrEmpty]
        public string RuleName
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, HelpMessage = "Start of the IP Range.", ParameterSetName = "IpRange")]
        [ValidateNotNullOrEmpty]
        public string StartIpAddress
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, HelpMessage = "End of the IP Range.", ParameterSetName = "IpRange")]
        [ValidateNotNullOrEmpty]
        public string EndIpAddress
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
        /// Updates a firewall rule on the specified server.
        /// </summary>
        /// <param name="serverName">The name of the server containing the firewall rule.</param>
        /// <param name="ruleName">The name of the firewall rule to update.</param>
        /// <param name="startIpAddress">The starting IP address for the firewall rule.</param>
        /// <param name="endIpAddress">The ending IP address for the firewall rule.</param>
        /// <returns>The updated firewall rule.</returns>
        internal SqlDatabaseServerFirewallRuleContext SetAzureSqlDatabaseServerFirewallRuleProcess(
            string serverName,
            string ruleName,
            string startIpAddress,
            string endIpAddress)
        {
            // Do nothing if force is not specified and user cancelled the operation
            if (!Force.IsPresent &&
                !ShouldProcess(
                    string.Format(CultureInfo.InvariantCulture, Resources.SetAzureSqlDatabaseServerFirewallRuleDescription, ruleName, serverName),
                    string.Format(CultureInfo.InvariantCulture, Resources.SetAzureSqlDatabaseServerFirewallRuleWarning, ruleName, serverName),
                    Resources.ShouldProcessCaption))
            {
                return null;
            }

            // Get the SQL management client for the current subscription
            SqlManagementClient sqlManagementClient = GetCurrentSqlClient();

            // Update the specified firewall rule
            FirewallRuleUpdateResponse response = sqlManagementClient.FirewallRules.Update(
                serverName,
                ruleName,
                new FirewallRuleUpdateParameters()
                {
                    Name = ruleName,
                    StartIPAddress = startIpAddress,
                    EndIPAddress = endIpAddress,
                });

            SqlDatabaseServerFirewallRuleContext operationContext = new SqlDatabaseServerFirewallRuleContext()
            {
                OperationDescription = CommandRuntime.ToString(),
                OperationStatus = Services.Constants.OperationSuccess,
                OperationId = response.RequestId,
                ServerName = serverName,
                RuleName = ruleName,
                StartIpAddress = response.FirewallRule.StartIPAddress,
                EndIpAddress = response.FirewallRule.EndIPAddress
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
                SqlDatabaseServerFirewallRuleContext context = this.SetAzureSqlDatabaseServerFirewallRuleProcess(
                    this.ServerName,
                    this.RuleName,
                    this.StartIpAddress,
                    this.EndIpAddress);

                this.WriteObject(context, true);
            }
            catch (Exception ex)
            {
                this.WriteErrorDetails(ex);
            }
        }
    }
}
