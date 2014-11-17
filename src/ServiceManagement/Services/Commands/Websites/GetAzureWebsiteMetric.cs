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
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.WebEntities;

namespace Microsoft.WindowsAzure.Commands.Websites
{
    /// <summary>
    /// Gets an azure website.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureWebsiteMetric"), OutputType(typeof(IList<MetricResponse>))]
    public class GetAzureWebsiteMetricCommand : WebsiteContextBaseCmdlet
    {
        [Parameter(Position = 2, Mandatory = false, ValueFromPipelineByPropertyName = true, 
            HelpMessage = "List of metrics names to retrieve.")]
        [ValidateNotNullOrEmpty]
        public string[] MetricNames { get; set; }

        [Parameter(Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true, 
            HelpMessage = "The start time.")]
        [ValidateNotNullOrEmpty]
        public DateTime? StartDate { get; set; }

        [Parameter(Position = 4, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The end time.")]
        public DateTime? EndDate { get; set; }

        [Parameter(Position = 5, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Time grain for the metrics. Supported values are PT1M (per minute), PT1H (per hour), P1D (per day).")]
        public string TimeGrain { get; set; }

        [Parameter(Position = 6, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Include details for the server instances in which the site is running.")]
        public SwitchParameter InstanceDetails { get; set; }

        [Parameter(Position = 7, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Flag which specifies if the metrics returned should reflect slot swaps. " +
            "Let's take for example following case: if production slot has hostname www.contos.com and take traffic for 12 hours " +
            "and later is swapped with staging slot. Getting metrics with SlotView=false will reflect the swap - e.g. there will be " +
            "a increase on the staging slot metrics after it goes to production." +
            "If SlotView=true is used it will show the metrics for the www.contoso.com regardless which slot was serving at the moment.")]
        public SwitchParameter SlotView { get; set; }

        public GetAzureWebsiteMetricCommand()
        {
            websiteNameDiscovery = false;
        }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var response = WebsitesClient.GetHistoricalUsageMetrics(Name, Slot, MetricNames, StartDate, EndDate, TimeGrain, InstanceDetails, SlotView);
            foreach (var metricResponse in response)
            {
                WriteObject(metricResponse, true);
            }
        }
    }
}
