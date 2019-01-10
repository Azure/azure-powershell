﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.DataLakeAnalytics.Models;
using Microsoft.Azure.Commands.DataLakeAnalytics.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataLakeAnalytics
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataLakeAnalyticsFirewallRule", SupportsShouldProcess = true), OutputType(typeof(DataLakeAnalyticsFirewallRule))]
    [Alias("Set-AdlAnalyticsFirewallRule")]
    public class SetAzureRmDataLakeAnalyticsFirewallRule : DataLakeAnalyticsCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "The Data Lake Analytics account to update the firewall rule in")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = true,
            HelpMessage = "The name of the firewall rule.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, Mandatory = false,
            HelpMessage = "The start of the valid ip range for the firewall rule")]
        [ValidateNotNullOrEmpty]
        public string StartIpAddress { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 3, Mandatory = false,
            HelpMessage = "The end of the valid ip range for the firewall rule")]
        [ValidateNotNullOrEmpty]
        public string EndIpAddress { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage = "Name of resource group under which want to retrieve the account.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        public override void ExecuteCmdlet()
        {
            // get the current firewall rule
            var rule = DataLakeAnalyticsClient.GetFirewallRule(ResourceGroupName, Account, Name);
            if (rule == null)
            {
                throw new PSInvalidOperationException(string.Format(Resources.FirewallRuleNotFound, Name));
            }

            var endIp = EndIpAddress ?? rule.EndIpAddress;
            var startIp = StartIpAddress ?? rule.StartIpAddress;
            ConfirmAction(
                string.Format(Resources.SetDataLakeFirewallRule, Name),
                Name,
                () =>
                    WriteObject(new DataLakeAnalyticsFirewallRule(DataLakeAnalyticsClient.AddOrUpdateFirewallRule(
                        ResourceGroupName, Account, Name, startIp, endIp, this)))
            );
        }
    }
}
