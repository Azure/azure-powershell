﻿using System;
using Microsoft.Azure.Commands.Reservations.Common;
using System.Management.Automation;
using Microsoft.Azure.Management.Reservations;
using Microsoft.Azure.Commands.Reservations.Models;
using Microsoft.Azure.Management.Reservations.Models;

namespace Microsoft.Azure.Commands.Reservations.Cmdlets
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ReservationOrder"), OutputType(typeof(PSReservationOrderPage), typeof(PSReservationOrder))]
    public class GetReservationOrder : AzureReservationsCmdletBase
    {
        [Parameter(Mandatory = false)]
        [ValidateNotNull]
        public Guid ReservationOrderId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ReservationOrderId != default(Guid))
            {
                var response = new PSReservationOrder(AzureReservationAPIClient.ReservationOrder.Get(ReservationOrderId.ToString()));
                WriteObject(response);
            }
            else
            {
                var response = new PSReservationOrderPage(AzureReservationAPIClient.ReservationOrder.List());
                WriteObject(response, true);
                while (response.NextPageLink != null)
                {
                    response = new PSReservationOrderPage(AzureReservationAPIClient.ReservationOrder.ListNext(response.NextPageLink));
                    WriteObject(response, true);
                }
            }
        }
    }
}
