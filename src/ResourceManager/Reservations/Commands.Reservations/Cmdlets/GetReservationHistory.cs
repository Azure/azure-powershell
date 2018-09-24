﻿using System;
using System.Collections.Generic;
using Microsoft.Azure.Commands.Reservations.Common;
using Microsoft.Azure.Management.Reservations.Models;
using System.Management.Automation;
using Microsoft.Azure.Management.Reservations;
using Microsoft.Azure.Commands.Reservations.Models;

namespace Microsoft.Azure.Commands.Reservations.Cmdlets
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ReservationHistory", DefaultParameterSetName = Constants.ParameterSetNames.CommandParameterSet), OutputType(typeof(PSReservationPage))]
    public class GetReservationHistory : AzureReservationsCmdletBase
    {
        [Parameter(ParameterSetName = Constants.ParameterSetNames.CommandParameterSet, 
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public Guid ReservationOrderId { get; set; }

        [Parameter(ParameterSetName = Constants.ParameterSetNames.CommandParameterSet, 
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public Guid ReservationId { get; set; }

        [Parameter(ParameterSetName = Constants.ParameterSetNames.ObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNull]
        public PSReservation Reservation { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(Constants.ParameterSetNames.ObjectParameterSet))
            {
                string[] name = Reservation.Name.Split('/');
                ReservationOrderId = new Guid(name[0]);
                ReservationId = new Guid(name[1]);
            }

            var response = new PSReservationPage(AzureReservationAPIClient.Reservation.ListRevisions(ReservationId.ToString(), ReservationOrderId.ToString()));
            WriteObject(response, true);
            while (response.NextPageLink != null)
            {
                response = new PSReservationPage(AzureReservationAPIClient.Reservation.ListNext(response.NextPageLink));
                WriteObject(response, true);
            }
        }
    }
}
