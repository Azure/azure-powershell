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
    /// Creates a new firewall rule for a Microsoft Azure SQL Database server in the selected subscription.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureSqlDatabaseServerFirewallRule",
        DefaultParameterSetName = IpRangeParameterSet,
        SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Low)]
    public class NewAzureSqlDatabaseServerFirewallRule : SqlDatabaseCmdletBase
    {
        /// <summary>
        /// The default rule name for allowing all Azure services.  This is used when a
        /// rule name is not specified for the AllowAllAzureServicesParameterSet parameter
        /// set
        /// </summary>
        private const string AllowAllAzureServicesRuleName = "AllowAllAzureServices";

        /// <summary>
        /// The special IP for the beginning and ending of the firewall rule that will
        /// allow all azure services to connect to the server.
        /// </summary>
        private const string AllowAzureServicesRuleAddress = "0.0.0.0";

        #region Parameter Sets

        /// <summary>
        /// Parameter set that uses an IP Range
        /// </summary>
        internal const string IpRangeParameterSet = "IpRange";

        /// <summary>
        /// Parameter set for allowing all azure services
        /// </summary>
        internal const string AllowAllAzureServicesParameterSet = "AllowAllAzureServices";

        #endregion

        /// <summary>
        /// Gets or sets the name of the server to connect add the firewall rule to
        /// </summary>
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "SQL Database server name.")]
        [ValidateNotNullOrEmpty]
        public string ServerName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the fire wall rule
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = IpRangeParameterSet,
            HelpMessage = "SQL Database server firewall rule name.")]
        [Parameter(Mandatory = false, ParameterSetName = AllowAllAzureServicesParameterSet,
            HelpMessage = "SQL Database server firewall rule name.")]
        [ValidateNotNullOrEmpty]
        public string RuleName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the starting IP address for the rule
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Start of the IP Range.",
            ParameterSetName = IpRangeParameterSet)]
        [ValidateNotNullOrEmpty]
        public string StartIpAddress
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the ending IP address for the firewall rule
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "End of the IP Range.",
            ParameterSetName = IpRangeParameterSet)]
        [ValidateNotNullOrEmpty]
        public string EndIpAddress
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether or not to allow all Microsoft Azure services to connect
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Allow all Azure services access to the server.",
            ParameterSetName = AllowAllAzureServicesParameterSet)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter AllowAllAzureServices
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether or not to force the operation to proceed.
        /// </summary>
        [Parameter(HelpMessage = "Do not confirm on the creation of the firewall rule")]
        public SwitchParameter Force
        {
            get;
            set;
        }

        /// <summary>
        /// Creates a new firewall rule on the specified server.
        /// </summary>
        /// <param name="parameterSetName">The parameter set for the command.</param>
        /// <param name="serverName">The name of the server in which to create the firewall rule.</param>
        /// <param name="ruleName">The name of the new firewall rule.</param>
        /// <param name="startIpAddress">The starting IP address for the firewall rule.</param>
        /// <param name="endIpAddress">The ending IP address for the firewall rule.</param>
        /// <returns>The context to the newly created firewall rule.</returns>
        internal SqlDatabaseServerFirewallRuleContext NewAzureSqlDatabaseServerFirewallRuleProcess(
            string parameterSetName,
            string serverName,
            string ruleName,
            string startIpAddress,
            string endIpAddress)
        {
            // Get the SQL management client for the current subscription
            SqlManagementClient sqlManagementClient = GetCurrentSqlClient();

            // Create the firewall rule
            FirewallRuleCreateResponse response = sqlManagementClient.FirewallRules.Create(
                serverName,
                new FirewallRuleCreateParameters()
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
                EndIpAddress = response.FirewallRule.EndIPAddress,
            };

            return operationContext;
        }

        /// <summary>
        /// Process the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            // Do nothing if force is not specified and user cancelled the operation
            string verboseDescription = string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.NewAzureSqlDatabaseServerFirewallRuleDescription,
                        this.RuleName,
                        this.ServerName);

            string verboseWarning = string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.NewAzureSqlDatabaseServerFirewallRuleWarning,
                        this.RuleName,
                        this.ServerName);

            if (!this.Force.IsPresent &&
                !this.ShouldProcess(verboseDescription, verboseWarning, Resources.ShouldProcessCaption))
            {
                return;
            }

            try
            {
                SqlDatabaseServerFirewallRuleContext context = null;
                switch (this.ParameterSetName)
                {
                    case IpRangeParameterSet:
                        context = this.NewAzureSqlDatabaseServerFirewallRuleProcess(
                            this.ParameterSetName,
                            this.ServerName,
                            this.RuleName,
                            this.StartIpAddress,
                            this.EndIpAddress);
                        break;

                    case AllowAllAzureServicesParameterSet:
                        // Determine which rule name to use.
                        string ruleName = AllowAllAzureServicesRuleName;
                        if (this.MyInvocation.BoundParameters.ContainsKey("RuleName"))
                        {
                            ruleName = this.RuleName;
                        }

                        // Create the rule
                        context = this.NewAzureSqlDatabaseServerFirewallRuleProcess(
                            this.ParameterSetName,
                            this.ServerName,
                            ruleName,
                            AllowAzureServicesRuleAddress,
                            AllowAzureServicesRuleAddress);
                        break;
                }

                this.WriteObject(context, true);
            }
            catch (Exception ex)
            {
                this.WriteErrorDetails(ex);
            }
        }
    }
}
