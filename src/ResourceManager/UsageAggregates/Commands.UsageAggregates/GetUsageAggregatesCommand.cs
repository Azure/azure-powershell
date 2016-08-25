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


using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commerce.UsageAggregates;

namespace Microsoft.Azure.Commands.UsageAggregates
{
    using Commerce.UsageAggregates.Models;
    using ResourceManager.Common;
    using System;
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.Get, "UsageAggregates"), OutputType(typeof(UsageAggregationGetResponse))]
    public class GetUsageAggregatesCommand : AzureRMCmdlet
    {
        private UsageAggregationManagementClient _theClient;
        private AggregationGranularity _aggregationGranularity = AggregationGranularity.Daily;
        private bool _showDetails = true;

        [Parameter(Mandatory = true, HelpMessage = "The start of the time range to retrieve data for.")]
        public DateTime ReportedStartTime { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The end of the time range to retrieve data for.")]
        public DateTime ReportedEndTime { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Value is either daily (default) or hourly to tell the API how to return the results grouped by day or hour.")]
        public AggregationGranularity AggregationGranularity
        {
            get { return _aggregationGranularity; }
            set { _aggregationGranularity = value; }
        }

        [Parameter(Mandatory = false, HelpMessage = "When set to true (default), the aggregates are broken down into the instance metadata which is more granular.")]
        public bool ShowDetails
        {
            get { return _showDetails; }
            set { _showDetails = value; }
        }

        [Parameter(Mandatory = false, HelpMessage = "Retrieved from previous calls, this is the bookmark used for progress when the responses are paged.")]
        public string ContinuationToken { get; set; }

        public override void ExecuteCmdlet()
        {
            if (_theClient == null)
            {
                _theClient = AzureSession.ClientFactory.CreateClient<UsageAggregationManagementClient>(DefaultProfile.Context,
                    AzureEnvironment.Endpoint.ResourceManager);
            }

            UsageAggregationGetResponse aggregations = _theClient.UsageAggregates.Get(ReportedStartTime,
                ReportedEndTime, AggregationGranularity, ShowDetails,
                ContinuationToken);

            WriteObject(aggregations);
        }

    }
}
