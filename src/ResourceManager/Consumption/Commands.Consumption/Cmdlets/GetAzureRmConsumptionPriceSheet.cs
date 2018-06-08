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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Consumption.Common;
using Microsoft.Azure.Commands.Consumption.Models;
using Microsoft.Azure.Management.Consumption;
using Microsoft.Azure.Management.Consumption.Models;

namespace Microsoft.Azure.Commands.Consumption.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "AzureRmConsumptionPriceSheet"), OutputType(typeof(PSPriceSheet))]
    public class GetAzureRmConsumptionPriceSheet : AzureConsumptionCmdletBase
    {
        private const int MaxNumberToFetch = 1000;

        [Parameter(Mandatory = false, HelpMessage = "Name of a specific billing period to get the price sheets that associate with.")]
        [ValidateNotNullOrEmpty]
        public string BillingPeriodName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Expand the price sheets based on MeterDetails.")]
        public SwitchParameter ExpandMeterDetail { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Determine the maximum number of records to return.")]
        [ValidateNotNullOrEmpty]
        [ValidateRange(1, 1000)]
        public int? Top { get; set; }

        public override void ExecuteCmdlet()
        {
            var expand = default(string);
            if (this.ExpandMeterDetail.IsPresent)
            {
                expand = "properties/meterDetails";
            }

            int numberToFetch = MaxNumberToFetch;
            if (this.Top.HasValue)
            {
                numberToFetch = this.Top.Value;
            }

            PriceSheetResult priceSheet = null;
            PSPriceSheet result = new PSPriceSheet();            
            
            try
            {
                string skipToken = null;
                string nextLink = null;
                if (!string.IsNullOrWhiteSpace(this.BillingPeriodName))
                {
                    do
                    {
                        priceSheet = ConsumptionManagementClient.PriceSheet.GetByBillingPeriod(this.BillingPeriodName,
                            expand, skipToken, numberToFetch);
                        UpdateResult(result, priceSheet);
                        nextLink = priceSheet?.NextLink;
                        if (!string.IsNullOrWhiteSpace(nextLink))
                        {
                            skipToken =
                                nextLink.Substring(
                                    nextLink.LastIndexOf("skiptoken", StringComparison.InvariantCultureIgnoreCase) + 10);
                            skipToken = skipToken.Substring(0, 12);
                        }                                                                  
                    } while (!this.Top.HasValue && !string.IsNullOrWhiteSpace(nextLink));                    
                }
                else
                {
                    do
                    {
                        priceSheet = ConsumptionManagementClient.PriceSheet.Get(expand, skipToken, numberToFetch);
                        UpdateResult(result, priceSheet);
                        nextLink = priceSheet?.NextLink;
                        if (!string.IsNullOrWhiteSpace(nextLink))
                        {
                            skipToken =
                                nextLink.Substring(
                                    nextLink.LastIndexOf("skiptoken", StringComparison.InvariantCultureIgnoreCase) + 10);
                            skipToken = skipToken.Substring(0, 12);
                        }                                               
                    } while (!this.Top.HasValue && !string.IsNullOrWhiteSpace(nextLink));
                }
            }
            catch (ErrorResponseException e)
            {
                WriteExceptionError(e);
            }

            WriteObject(result);
        }

        private void UpdateResult(PSPriceSheet result, PriceSheetResult priceSheet)
        {
            if (priceSheet != null)
            {
                result.Id = priceSheet.Id;
                result.Name = priceSheet.Name;
                result.Tag = priceSheet.Tags;
                result.Type = priceSheet.Type;
                result.PriceSheets.AddRange(priceSheet.Pricesheets.Select(x => new PSPriceSheetProperty(x)));
            }
        }
    }
}
