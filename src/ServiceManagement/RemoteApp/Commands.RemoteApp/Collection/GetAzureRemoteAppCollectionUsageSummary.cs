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

using Microsoft.Azure.Management.RemoteApp;
using Microsoft.Azure.Management.RemoteApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Management.RemoteApp.Cmdlets
{

    [Cmdlet(VerbsCommon.Get, "AzureRemoteAppCollectionUsageSummary"), OutputType(typeof(BillingUsageSummary))]
    public class GetAzureRemoteAppCollectionUsageSummary : RdsCmdlet
    {
        [Parameter(Mandatory = true,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "RemoteApp collection name")]
        public string CollectionName { get; set; }

        [Parameter(Mandatory = false,
                   HelpMessage = "Number of the month (MM) to report usage")]
        [ValidatePattern("^(0[1-9]|1[0-2])$")]
        public string UsageMonth { get; set; }

        [Parameter(Mandatory = false,
                   HelpMessage = "Year (YYYY) to report usage")]
        [ValidatePattern(@"^(19|20)\d\d$")]
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
                    WriteVerboseWithTimestamp("No usage found for the requested period.");
                }
            }
        }
    }
}
