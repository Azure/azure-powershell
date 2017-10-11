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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataLakeAnalytics
{
    [Cmdlet(VerbsCommon.Get, "AzureRmDataLakeAnalyticsFirewallRule"), OutputType(typeof(DataLakeAnalyticsFirewallRule), typeof(IList<DataLakeAnalyticsFirewallRule>))]
    [Alias("Get-AdlAnalyticsFirewallRule")]
    public class GetAzureRmDataLakeAnalyticsFirewallRule : DataLakeAnalyticsCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "The Data Lake Analytics account to get the firewall rule from")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = false,
            HelpMessage = "The name of the firewall rule.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 2,
            ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage = "Name of resource group under which want to retrieve the account.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        public override void ExecuteCmdlet()
        {
            if (string.IsNullOrEmpty(Name))
            {
                WriteObject(DataLakeAnalyticsClient.ListFirewallRules(ResourceGroupName, Account)
                    .Select(element => new DataLakeAnalyticsFirewallRule(element))
                    .ToList(), true);
            }
            else
            {
                WriteObject(new DataLakeAnalyticsFirewallRule(DataLakeAnalyticsClient.GetFirewallRule(ResourceGroupName, Account, Name)));
            }
        }
    }
}