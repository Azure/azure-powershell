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


using Microsoft.Azure.Commerce.UsageAggregates;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;

namespace Microsoft.Azure.Commands.UsageAggregates
{
    using Commerce.UsageAggregates.Models;
    using WindowsAzure.Commands.Utilities.Common;
    using System;
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.Get, "UsageAggregates"), OutputType(typeof(UsageAggregationGetResponse))]
    public class GetUsageAggregatesCommand : AzurePSCmdlet
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "The start of the time range to retrieve data for.")]
        public DateTime ReportedStartTime { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "The end of the time range to retrieve data for.")]
        public DateTime ReportedEndTime { get; set; }

        private AggregationGranularity aggregationGranularity = AggregationGranularity.Daily;
        [Parameter(Mandatory = false, HelpMessage = "Value is either daily (default) or hourly to tell the API how to return the results grouped by day or hour.")]
        public AggregationGranularity AggregationGranularity { 
            get { return aggregationGranularity; } 
            set { aggregationGranularity = value;}
        }

        private bool showDetails = true;
        [Parameter(Mandatory = false, HelpMessage = "When set to true (default), the aggregates are broken down into the instance metadata which is more granular.")]
        public bool ShowDetails {
            get { return showDetails; }
            set { showDetails = value; }
        }

        [Parameter(Mandatory = false, HelpMessage = "Retrieved from previous calls, this is the bookmark used for progress when the responses are paged.")]
        public string ContinuationToken { get; set; }

        private UsageAggregationManagementClient theClient;
        public override void ExecuteCmdlet()
        {
            if (theClient == null)
            {
                theClient = AzureSession.ClientFactory.CreateClient<UsageAggregationManagementClient>(Profile,
                    Profile.Context.Subscription, AzureEnvironment.Endpoint.ResourceManager);
            }

            UsageAggregationGetResponse aggregations = theClient.UsageAggregates.Get(ReportedStartTime,
                ReportedEndTime, AggregationGranularity, ShowDetails,
                ContinuationToken);

            WriteObject(aggregations);
        }

    }
}
