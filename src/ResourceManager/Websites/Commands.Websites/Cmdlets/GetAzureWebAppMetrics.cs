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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.Azure.Commands.WebApp;
using Microsoft.Azure.Management.WebSites;
using System.Net.Http;
using System.Threading;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Net;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.WebApp.Utilities;

namespace Microsoft.Azure.Commands.WebApp.Cmdlets
{
    /// <summary>
    /// this commandlet will let you get Azure Web App metrics using ARM APIs
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureWebAppMetrics"), OutputType(typeof(WebSiteGetUsageMetricsResponse))]
    public class GetAzureWebAppMetricsCmdlet : WebAppBaseSlotCmdlet
    {              
        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "List of metrics names to retrieve.")]
        [ValidateNotNullOrEmpty]
        public string [] Metrics { get; set; }
        
        [Parameter(Position = 3, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Granularity.")]
        [ValidateSet("Minutes", "Hours", "Days", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string Granularity { get; set; }

        [Parameter(Position = 4, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The start time.")]
        [ValidateNotNullOrEmpty]
        public DateTime? StartDate { get; set; }

        [Parameter(Position = 5, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The end time.")]
        public DateTime? EndDate { get; set; }
        
        [Parameter(Position = 6, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Include details for each server instance in the web hosting plan.")]
        public SwitchParameter InstanceDetails { get; set; }

        [Parameter(Position = 7, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Time grain for the metrics. Supported values are PT1M (per minute), PT1H (per hour), P1D (per day).")]
        [ValidateSet("PT1M", "PT1H", "P1D", IgnoreCase = true)]
        public string TimeGrain { get; set; }


        public override void ExecuteCmdlet()
        {
            WebSiteGetHistoricalUsageMetricsResponse response = WebsitesClient.GetWebAppUsageMetrics(ResourceGroupName, Name, SlotName, Metrics, StartDate, EndDate, TimeGrain, InstanceDetails);
            foreach (var metricResponse in response.UsageMetrics)
            {
                WriteObject(metricResponse, true);
            }
        }
    }
}
