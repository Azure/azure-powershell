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

namespace Microsoft.Azure.Commands.Consumption.Cmdlets.Reservation
{
    [Cmdlet(VerbsCommon.Get, "AzureRmConsumptionReservationSummary")]
    [OutputType(typeof(PSReservationSummary))]
    public class GetAzureRmConsumptionReservationSummary : AzureConsumptionCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "The time grain of the reservation summaryy, can be daily or monthly.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet("daily", "monthly")]
        public string Grain { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The identifier of a reservation purchase.")]
        [ValidateNotNullOrEmpty]
        public string ReservationOrderId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The identifier of a reservation within a reservation order.")]
        [ValidateNotNullOrEmpty]
        public string ReservationId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The start data (YYYY-MM-DD in UTC) of the reservation summary, required only for daily grain.")]
        [ValidateNotNullOrEmpty]
        public DateTime? StartDate { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The end data (YYYY-MM-DD in UTC) of the reservation summary, required only for daily grain.")]
        [ValidateNotNullOrEmpty]
        public DateTime? EndDate { get; set; }                            

        public override void ExecuteCmdlet()
        {
            string filter = null;
            if (this.Grain.Equals("daily", StringComparison.CurrentCultureIgnoreCase))
            {
                var from = this.StartDate?.ToString(Constants.Formats.DateTimeParameterFormat);
                var to = this.EndDate?.ToString(Constants.Formats.DateTimeParameterFormat);
                if (from != null && to != null)
                {
                    filter = "properties/UsageDate ge " + from + " AND properties/UsageDate le " + to;
                }                
            }

            IPage<ReservationSummaries> reservationSummaries = null;
            try
            {
                if (!string.IsNullOrWhiteSpace(this.ReservationId))
                {
                    reservationSummaries =
                        ConsumptionManagementClient.ReservationsSummaries.ListByReservationOrderAndReservation(
                            ReservationOrderId, ReservationId, Grain, filter);
                }
                else
                {
                    reservationSummaries =
                        ConsumptionManagementClient.ReservationsSummaries.ListByReservationOrder(ReservationOrderId,
                            Grain, filter);
                }
            }
            catch (ErrorResponseException e)
            {
                WriteExceptionError(e);
            }

            if (reservationSummaries != null)
            {
                WriteObject(reservationSummaries.Select(x => new PSReservationSummary(x)), true);
            }
        }
    }
}
