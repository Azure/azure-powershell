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
using System.Management.Automation;
using Microsoft.Azure.Commands.Consumption.Common;
using Microsoft.Azure.Commands.Consumption.Models;
using Microsoft.Azure.Management.Consumption;
using Microsoft.Azure.Management.Consumption.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.Azure.OData;

namespace Microsoft.Azure.Commands.Consumption.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "AzureRmConsumptionMarketplace"), OutputType(typeof(PSMarketplace))]
    public class GetAzureRmConsumptionMarketplace : AzureConsumptionCmdletBase
    {
        private const int MaxNumberToFetch = 1000;

        [Parameter(Mandatory = false, HelpMessage = "Name of a specific billing period to get the marketplace that associate with.")]
        [ValidateNotNullOrEmpty]
        public string BillingPeriodName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The end date (in UTC) of the marketplaces to filter.")]
        [ValidateNotNullOrEmpty]
        public DateTime? EndDate { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The instance id of the marketplaces to filter.")]
        [ValidateNotNullOrEmpty]
        public string InstanceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The instance name of the marketplaces to filter.")]
        [ValidateNotNullOrEmpty]
        public string InstanceName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The resource group of the marketplaces to filter.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroup { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The start date (in UTC) of the marketplaces to filter.")]
        [ValidateNotNullOrEmpty]
        public DateTime? StartDate { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Determine the maximum number of records to return.")]
        [ValidateNotNullOrEmpty]
        [ValidateRange(1, 1000)]
        public int? Top { get; set; }
        

        public override void ExecuteCmdlet()
        {
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

            int numberToFetch = MaxNumberToFetch;
            if (this.Top.HasValue)
            {
                numberToFetch = this.Top.Value;
            }
            
            List<PSMarketplace> result = new List<PSMarketplace>();
            
            try
            {
                IPage<Marketplace> marketplaces = null;
                string nextPageLink = null;

                if (!string.IsNullOrWhiteSpace(this.BillingPeriodName))
                {
                    do
                    {
                        if (!string.IsNullOrWhiteSpace(nextPageLink))
                        {
                            marketplaces = ConsumptionManagementClient.Marketplaces.ListByBillingPeriodNext(nextPageLink);
                            nextPageLink = marketplaces?.NextPageLink;
                        }
                        else
                        {
                            marketplaces =
                                ConsumptionManagementClient.Marketplaces.ListByBillingPeriod(this.BillingPeriodName,
                                    new ODataQuery<Marketplace>
                                    {
                                        Top = numberToFetch,
                                        Filter = filter
                                    });
                            nextPageLink = marketplaces?.NextPageLink;
                        }

                        if (marketplaces != null)
                        {
                            result.AddRange(marketplaces.Select(x => new PSMarketplace(x)));
                        }
                    } while (!this.Top.HasValue && !string.IsNullOrWhiteSpace(nextPageLink));

                    
                }
                else
                {
                    do
                    {
                        if (!string.IsNullOrWhiteSpace(nextPageLink))
                        {
                            marketplaces = ConsumptionManagementClient.Marketplaces.ListNext(nextPageLink);
                            nextPageLink = marketplaces?.NextPageLink;
                        }
                        else
                        {
                            marketplaces =
                                ConsumptionManagementClient.Marketplaces.List(new ODataQuery<Marketplace>
                                {
                                    Top = numberToFetch,
                                    Filter = filter
                                });
                            nextPageLink = marketplaces?.NextPageLink;
                        }

                        if (marketplaces != null)
                        {
                            result.AddRange(marketplaces.Select(x => new PSMarketplace(x)));
                        }
                    } while (!this.Top.HasValue && !string.IsNullOrWhiteSpace(nextPageLink));                  
                }
            }
            catch (ErrorResponseException e)
            {
                WriteExceptionError(e);
            }

            WriteObject(result, true);
        }
    }
}
