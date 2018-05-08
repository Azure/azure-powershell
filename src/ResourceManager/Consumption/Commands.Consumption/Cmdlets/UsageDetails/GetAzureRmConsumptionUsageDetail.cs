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
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.Consumption.Cmdlets.UsageDetails
{
    [Cmdlet(VerbsCommon.Get, "AzureRmConsumptionUsageDetail", DefaultParameterSetName = Constants.ParameterSetNames.SubscriptionItemParameterSet), OutputType(typeof(List<PSUsageDetail>))]
    public class GetAzureRmConsumptionUsageDetail : AzureConsumptionCmdletBase
    {
        const int MaxNumberToFetch = 1000;

        [Parameter(Mandatory = false, HelpMessage = "Name of a specific billing period to get the usage details that associate with.")]
        [ValidateNotNullOrEmpty]
        public string BillingPeriodName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Expand the usages based on MeterDetails, or AdditionalInfo.")]
        [ValidateNotNull]
        public string Expand { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Include meter details in the usages.")]
        public SwitchParameter IncludeMeterDetails { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Include additional properties in the usages.")]
        public SwitchParameter IncludeAdditionalProperties { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The start date (in UTC) of the usages to filter.")]
        [ValidateNotNull]
        public DateTime? StartDate { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The end date (in UTC) of the usages to filter.")]
        [ValidateNotNull]
        public DateTime? EndDate { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The resource group of the usages to filter.")]
        [ValidateNotNull]
        public string ResourceGroup { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The instance name of the usages to filter.")]
        [ValidateNotNull]
        public string InstanceName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The instance id of the usages to filter.")]
        [ValidateNotNull]
        public string InstanceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The tag of the usages to filter.")]
        [ValidateNotNull]
        public string Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Determine the maximum number of records to return.")]
        [ValidateNotNull]
        public int? MaxCount { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Determine the maximum number of records to return.")]
        [ValidateNotNull]
        public int? Top { get; set; }

        [CmdletParameterBreakingChange("InvoiceName", ChangeDescription = "InvoiceName is being deprecated without being replaced.")]
        [Parameter(Mandatory = false, HelpMessage = "Name of a specific invoice to get the usage details that associate with.")]
        [ValidateNotNullOrEmpty]
        public string InvoiceName { get; set; }

        public override void ExecuteCmdlet()
        {
            var expand = default(string);
            if (!string.IsNullOrWhiteSpace(this.Expand) &&
                 this.Expand.Equals(Constants.Expands.MeterDetails, StringComparison.InvariantCultureIgnoreCase) ||
                this.IncludeMeterDetails.IsPresent)
            {
                expand = "properties/meterDetails";
            }
            if (!string.IsNullOrWhiteSpace(this.Expand) &&
                this.Expand.Equals(Constants.Expands.AdditionalInfo, StringComparison.InvariantCultureIgnoreCase) ||
                this.IncludeAdditionalProperties.IsPresent)
            {
                if (expand == default(string))
                {
                    expand = "properties/additionalProperties";
                }
                else
                {
                    expand = string.Concat(expand, " and ", "properties/additionalProperties");
                }
            }

            string filter = null;
          
            if (this.StartDate.HasValue)
            {
                var from = this.StartDate.Value.Date;
                string fromFilter = "properties/usageStart ge " + "'" + from.ToString(Constants.Formats.DateTimeParameterFormat) + "'";
                filter = fromFilter;
            }            

            if (this.EndDate.HasValue)
            {
                var to = this.EndDate.Value.Date;
                string toFilter = "properties/usageEnd le " + "'" + to.ToString(Constants.Formats.DateTimeParameterFormat) + "'";
                if (string.IsNullOrWhiteSpace(filter))
                {
                    filter = toFilter;
                }
                else
                {
                    filter = string.Concat(filter, " and ", toFilter);
                }
            }

            if (!string.IsNullOrWhiteSpace(this.ResourceGroup))
            {
                string resourceGroupFilter = "properties/resourceGroup eq " + "'" + this.ResourceGroup + "'";
                if (string.IsNullOrWhiteSpace(filter))
                {
                    filter = resourceGroupFilter;
                }
                else
                {
                    filter = string.Concat(filter, " and ", resourceGroupFilter);
                }
            }

            
            if (!string.IsNullOrWhiteSpace(this.InstanceName))
            {
                string instanceNameFilter = "properties/instanceName eq " + "'" + this.InstanceName + "'";
                if (string.IsNullOrWhiteSpace(filter))
                {
                    filter = instanceNameFilter;
                }
                else
                {
                    filter = string.Concat(filter, " and ", instanceNameFilter);
                }
            }

            if (!string.IsNullOrWhiteSpace(this.InstanceId))
            {
                string instanceIdFilter = "properties/instanceId eq " + "'" + this.InstanceId + "'";
                if (string.IsNullOrWhiteSpace(filter))
                {
                    filter = instanceIdFilter;
                }
                else
                {
                    filter = string.Concat(filter, " and ", instanceIdFilter);
                }
            }

            if (!string.IsNullOrWhiteSpace(this.Tag))
            {
                string tagsFilter = "properties/tags eq " + "'" + this.Tag + "'";
                if (string.IsNullOrWhiteSpace(filter))
                {
                    filter = tagsFilter;
                }
                else
                {
                    filter = string.Concat(filter, " and ", tagsFilter);
                }
            }

            int numberToFetch = MaxNumberToFetch;
            if (this.Top.HasValue && this.Top.Value < numberToFetch)
            {
                numberToFetch = this.Top.Value;
            }
            if (this.MaxCount.HasValue && this.MaxCount.Value < numberToFetch)
            {
                numberToFetch = this.MaxCount.Value;
            }

            IPage<UsageDetail> usageDetails = null;         
            try
            {
                if (!string.IsNullOrWhiteSpace(this.BillingPeriodName))
                {
                    usageDetails = ConsumptionManagementClient.UsageDetails.ListByBillingPeriod(BillingPeriodName,
                        expand, filter, default(string), numberToFetch);
                }
                else
                {
                    usageDetails = ConsumptionManagementClient.UsageDetails.List(expand, filter, default(string), numberToFetch);
                }                
            }
            catch (ErrorResponseException e)
            {
                WriteWarning(e.Body.Error.Message);
            }

            if (usageDetails != null)
            {
                WriteObject(usageDetails.Select(x => new PSUsageDetail(x)), true);
            }            
        }
    }
}
