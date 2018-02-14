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

using Microsoft.Azure.Commands.DataLakeAnalytics.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.DataLake.Analytics.Models;
using System;
using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataLakeAnalytics
{
    [Cmdlet(VerbsCommon.Set, "AzureRmDataLakeAnalyticsAccount"), OutputType(typeof(PSDataLakeAnalyticsAccount))]
    [Alias("Set-AdlAnalyticsAccount")]
    public class SetAzureDataLakeAnalyticsAccount : DataLakeAnalyticsCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "Name of the account.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = false,
            HelpMessage =
                "A string,string dictionary of tags associated with this account that should replace the current set of tags"
            )]
        [Obsolete("Set-AzureRmDataLakeAnalyticsAccount: -Tags will be removed in favor of -Tag in an upcoming breaking change release.  Please start using the -Tag parameter to avoid breaking scripts.")]
        [Alias("Tags")]
        [ValidateNotNull]
        public Hashtable Tag { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, Mandatory = false,
            HelpMessage = "Name of resource group under which you want to update the account.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage = "The maximum supported analytics units for this account.")]
        [ValidateNotNull]
        [ValidateRange(1, int.MaxValue)]
        [Alias("MaxDegreeOfParallelism")]
        public int? MaxAnalyticsUnits { get; set; }
        
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage = "The maximum supported jobs running under the account at the same time.")]
        [ValidateNotNull]
        [ValidateRange(1, int.MaxValue)]
        public int? MaxJobCount { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage = "The number of days that job metadata is retained.")]
        [ValidateNotNull]
        [ValidateRange(1, 180)]
        public int? QueryStoreRetention { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage = "The desired commitment tier for this account to use.")]
        [ValidateNotNull]
        public TierType? Tier { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage = "Optionally enable/disable existing firewall rules.")]
        [ValidateNotNull]
        public FirewallState? FirewallState { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage = "Optionally allow/block Azure originating IPs through the firewall.")]
        [ValidateNotNull]
        public FirewallAllowAzureIpsState? AllowAzureIpState { get; set; }

        public override void ExecuteCmdlet()
        {
            if (string.IsNullOrEmpty(ResourceGroupName))
            {
                ResourceGroupName = DataLakeAnalyticsClient.GetResourceGroupByAccountName(Name);
            }

            var account = DataLakeAnalyticsClient.GetAccount(ResourceGroupName, Name);
            if (!FirewallState.HasValue)
            {
                FirewallState = account.FirewallState;
            }

            if (AllowAzureIpState.HasValue && FirewallState.Value == Management.DataLake.Analytics.Models.FirewallState.Disabled)
            {
                WriteWarning(string.Format(Properties.Resources.FirewallDisabledWarning, Name));
            }

            WriteObject(
                new PSDataLakeAnalyticsAccount(
                    DataLakeAnalyticsClient.CreateOrUpdateAccount(
                        ResourceGroupName,
                        Name,
                        null,
                        null,
                        null,
                        null,
                        Tag,
                        MaxAnalyticsUnits,
                        MaxJobCount,
                        QueryStoreRetention,
                        Tier,
                        FirewallState,
                        AllowAzureIpState)));
        }
    }
}
