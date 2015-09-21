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

using Microsoft.WindowsAzure.Commands.RemoteApp;
using Microsoft.WindowsAzure.Management.RemoteApp;
using Microsoft.WindowsAzure.Management.RemoteApp.Models;
using System;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Management.RemoteApp.Cmdlets
{

    [Cmdlet(VerbsCommon.Get, "AzureRemoteAppCollectionUsageSummary"), OutputType(typeof(BillingUsageSummary))]
    public class GetAzureRemoteAppCollectionUsageSummary : RdsCmdlet
    {
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "RemoteApp collection name")]
        [ValidatePattern(NameValidatorString)]
        [Alias("Name")]
        public string CollectionName { get; set; }

        [Parameter(Mandatory = false,
            Position = 1,
            HelpMessage = "Number of the month (MM) to report usage")]
        [ValidatePattern(TwoDigitMonthPattern)]
        public string UsageMonth { get; set; }

        [Parameter(Mandatory = false,
            Position = 2,
            HelpMessage = "Year (YYYY) to report usage")]
        [ValidatePattern(FullYearPattern)]
        public string UsageYear { get; set; }

        public override void ExecuteCmdlet()
        {
            DateTime today = DateTime.Now;

            if (String.IsNullOrWhiteSpace(UsageMonth))
            {
                UsageMonth = today.Month.ToString();
            }

            if (String.IsNullOrWhiteSpace(UsageYear))
            {
                UsageYear = today.Year.ToString();
            }

            CollectionUsageSummaryListResult usageSummary = CallClient(() => Client.Collections.GetUsageSummary(CollectionName, UsageYear, UsageMonth), Client.Collections);

            if (usageSummary != null)
            {
                if (usageSummary.UsageSummaryList.Count > 0)
                {
                    WriteObject(usageSummary.UsageSummaryList, true);
                }
                else
                {
                    WriteVerboseWithTimestamp(Commands_RemoteApp.UseageNotFound);
                }
            }
        }
    }
}
