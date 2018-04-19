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
        public Guid ReservationOrderId { get; set; }

        [Parameter(ParameterSetName = Constants.ParameterSetNames.CommandParameterSet, 
            Mandatory = true)]
        [ValidateNotNull]
        [ValidateCount (2, 2)]
        public Guid[] ReservationId { get; set; }

        [Parameter(ParameterSetName = Constants.ParameterSetNames.ObjectParameterSet,
            Mandatory = true)]
        [ValidateNotNull]
        [ValidateCount(2, 2)]
        public PSReservation[] Reservation { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(Constants.ParameterSetNames.ObjectParameterSet))
            {
                ReservationOrderId = new Guid(Reservation[0].Name.Split('/')[0]);
                ReservationId = Reservation.Select(x => x.Name.Split('/')[1]).Select(x => new Guid(x)).ToArray();
            }

            var resourceInfo = $"Reservation {ReservationId[0]} and {ReservationId[1]} in order {ReservationOrderId}";
            if (ShouldProcess(resourceInfo, "Merge"))
            {
                MergeRequest Merge = new MergeRequest(ListOfResourceId());
                var response = AzureReservationAPIClient.Reservation.Merge(ReservationOrderId.ToString(), Merge).Select(x => new PSReservation(x));
                WriteObject(response, true);
            }
        }

        private List<string> ListOfResourceId()
        {
            return ReservationId.Select(x => CreateResourceId(ReservationOrderId, x)).ToList();
        }

        private string CreateResourceId(Guid reservationOrderId, Guid reservationId)
        {
            return string.Format("/providers/Microsoft.Capacity/reservationOrders/{0}/reservations/{1}", reservationOrderId, reservationId);
        }
    }
}