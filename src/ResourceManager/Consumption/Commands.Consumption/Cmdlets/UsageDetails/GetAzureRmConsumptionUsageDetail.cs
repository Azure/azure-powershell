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

using Microsoft.Azure.Commands.Consumption.Common;
using Microsoft.Azure.Commands.Consumption.Models;
using Microsoft.Azure.Management.Consumption;
using Microsoft.Azure.Management.Consumption.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Consumption.Cmdlets.UsageDetails
{
    [Cmdlet(VerbsCommon.Get, "AzureRmConsumptionUsageDetail", DefaultParameterSetName = Constants.ParameterSetNames.SubscriptionItemParameterSet), OutputType(typeof(List<PSUsageDetail>))]
    public class GetAzureRmConsumptionUsageDetail : AzureConsumptionCmdletBase
    {
        const int MaxNumberToFetch = 1000;

        [Parameter(Mandatory = true, HelpMessage = "Name of a specific invoice to get the usage details that associate with.", ParameterSetName = Constants.ParameterSetNames.InvoiceItemParameterSet)]
        [ValidateNotNullOrEmpty]
        public string InvoiceName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Name of a specific billing period to get the usage details that associate with.", ParameterSetName = Constants.ParameterSetNames.BillingPeriodItemParameterSet)]
        [ValidateNotNullOrEmpty]
        public string BillingPeriodName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Determine the maximum number of records to return.")]
        [ValidateNotNull]
        public int? MaxCount { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Include meter details in the usages.")]
        public SwitchParameter IncludeMeterDetails { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Include additional properties in the usages.")]
        public SwitchParameter IncludeAdditionalProperties { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The start date (in UTC) of the usages.")]
        [ValidateNotNull]
        public DateTime? StartDate { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The end date (in UTC) of the usages.")]
        [ValidateNotNull]
        public DateTime? EndDate { get; set; }

        public override void ExecuteCmdlet()
        {
            string expand = null;
            List<string> expandProperties = new List<string>();
            if (this.IncludeMeterDetails.IsPresent)
            {
                expandProperties.Add(Constants.Expands.MeterDetails);
            }
            if (this.IncludeAdditionalProperties.IsPresent)
            {
                expandProperties.Add(Constants.Expands.AdditionalProperties);
            }
            if (expandProperties.Count > 0)
            {
                expand = string.Join(",", expandProperties);
            }

            string filter = null;
            if (this.StartDate.HasValue)
            {
                // query is on usageEnd, which is always the 23:59:59 of the day
                var from = this.StartDate.Value.Date.AddDays(1).AddSeconds(-1);
                filter = "usageEnd ge " + from.ToString(Constants.Formats.DateTimeParameterFormat);
            }
            if (this.EndDate.HasValue)
            {
                var to = this.EndDate.Value.Date.AddDays(1).AddSeconds(-1);
                var toFilter = "usageEnd le " + to.ToString(Constants.Formats.DateTimeParameterFormat);
                if (!string.IsNullOrWhiteSpace(filter))
                {
                    filter = string.Concat(filter, " and ", toFilter);
                }
                else
                {
                    filter = toFilter;
                }
            }

            string scope = null;

            if (ParameterSetName.Equals(Constants.ParameterSetNames.BillingPeriodItemParameterSet))
            {
                scope = string.Format(Constants.Formats.BillingPeriodScopeFormat, ConsumptionManagementClient.SubscriptionId, this.BillingPeriodName);
            }
            else if (ParameterSetName.Equals(Constants.ParameterSetNames.InvoiceItemParameterSet))
            {
                scope = string.Format(Constants.Formats.InvoiceScopeFormat, ConsumptionManagementClient.SubscriptionId, this.InvoiceName);
            }
            else
            {
                scope = string.Format(Constants.Formats.SubscriptionScopeFormat, ConsumptionManagementClient.SubscriptionId);
            }
            int count = 0;
            string continuationToken = null;
            IPage<UsageDetail> usageDetails;
            do
            {
                int? numberToFetch = null;
                if (this.MaxCount.HasValue)
                {
                    numberToFetch = this.MaxCount.Value - count;
                    if (numberToFetch > MaxNumberToFetch)
                    {
                        numberToFetch = MaxNumberToFetch;
                    }
                }

                try
                {
                    usageDetails = ConsumptionManagementClient.UsageDetails.List(scope, expand, filter, continuationToken, numberToFetch);
                }
                catch (ErrorResponseException e)
                {
                    WriteWarning(e.Body.Error.Message);
                    break;
                }

                if (usageDetails != null)
                {
                    count += usageDetails.Count();
                    WriteObject(usageDetails.Select(x => new PSUsageDetail(x)), true);
                    continuationToken = Utilities.ExtractContinuationToken(usageDetails.NextPageLink);
                }
                else
                {
                    continuationToken = null;
                }
            }
            while (!string.IsNullOrWhiteSpace(continuationToken) && (!this.MaxCount.HasValue || count < this.MaxCount.Value));
        }
    }
}
