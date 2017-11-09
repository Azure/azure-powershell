using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.Reservations.Common;
using Microsoft.Azure.Management.Reservations.Models;
using System.Management.Automation;
using Microsoft.Azure.Management.Reservations;
using Microsoft.Azure.Commands.Reservations.Models;

namespace Microsoft.Azure.Commands.Reservations.Cmdlets
{
    [Cmdlet(VerbsData.Merge, "AzureRmReservation", DefaultParameterSetName = Constants.ParameterSetNames.CommandParameterSet, SupportsShouldProcess = true), OutputType(typeof(List<PSReservation>))]
    public class MergeReservation : AzureReservationsCmdletBase
    {
        [Parameter(ParameterSetName = Constants.ParameterSetNames.CommandParameterSet, 
            Mandatory = true)]
        [ValidateNotNull]
        public string ReservationOrderId { get; set; }

        [Parameter(ParameterSetName = Constants.ParameterSetNames.CommandParameterSet, 
            Mandatory = true)]
        [ValidateNotNull]
        [ValidateCount (2, 2)]
        public string[] ReservationId { get; set; }

        [Parameter(ParameterSetName = Constants.ParameterSetNames.ObjectParameterSet,
            Mandatory = true)]
        [ValidateNotNull]
        [ValidateCount(2, 2)]
        public PSReservation[] Reservation { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(Constants.ParameterSetNames.ObjectParameterSet))
            {
                ReservationOrderId = Reservation[0].Name.Split('/')[0];
                ReservationId = Reservation.Select(x => x.Name.Split('/')[1]).ToArray();
            }

            var resourceInfo = $"Reservation {ReservationId[0]} and {ReservationId[1]} in order {ReservationOrderId}";
            if (ShouldProcess(resourceInfo, "Merge"))
            {
                MergeRequest Merge = new MergeRequest(ListOfResourceId());
                var response = AzureReservationAPIClient.Reservation.Merge(ReservationOrderId, Merge).Select(x => new PSReservation(x));
                WriteObject(response, true);
            }
        }

        private List<string> ListOfResourceId()
        {
            return ReservationId.Select(x => CreateResourceId(ReservationOrderId, x)).ToList();
        }

        private string CreateResourceId(string ReservationOrderId, string ReservationId)
        {
            return string.Format("/providers/Microsoft.Capacity/reservationOrders/{0}/reservations/{1}", ReservationOrderId, ReservationId);
        }
    }
}