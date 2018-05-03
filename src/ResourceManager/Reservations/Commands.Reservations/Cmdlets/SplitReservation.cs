using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Reservations.Common;
using Microsoft.Azure.Management.Reservations.Models;
using System.Management.Automation;
using Microsoft.Azure.Management.Reservations;
using Microsoft.Azure.Commands.Reservations.Models;

namespace Microsoft.Azure.Commands.Reservations.Cmdlets
{
    [Cmdlet(VerbsCommon.Split, "AzureRmReservation", DefaultParameterSetName = Constants.ParameterSetNames.CommandParameterSet, SupportsShouldProcess = true), OutputType(typeof(List<PSReservation>))]
    public class SplitReservation : AzureReservationsCmdletBase
    {
        [Parameter(ParameterSetName = Constants.ParameterSetNames.CommandParameterSet,
            Mandatory = true)]
        [ValidateNotNull]
        public Guid ReservationOrderId { get; set; }

        [Parameter(ParameterSetName = Constants.ParameterSetNames.CommandParameterSet,
            Mandatory = true)]
        [ValidateNotNull]
        public Guid ReservationId { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNull]
        [ValidateCount (2, 2)]
        public int[] Quantity { get; set; }

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

            var resourceInfo = $"Reservation {ReservationId} in order {ReservationOrderId}";
            if (ShouldProcess(resourceInfo, "Split"))
            {
                var quantityParameter = Quantity.Select(q => (int?) q).ToList();
                SplitRequest Split = new SplitRequest(
                    quantityParameter,
                    CreateResourceId(ReservationOrderId, ReservationId)
                );
                var response = AzureReservationAPIClient.Reservation.Split(ReservationOrderId.ToString(), Split).Select(x => new PSReservation(x)).ToList();
                WriteObject(response, true);
            }

        }

        private string CreateResourceId(Guid reservationOrderId, Guid reservationId)
        {
            return string.Format("/providers/Microsoft.Capacity/reservationOrders/{0}/reservations/{1}", reservationOrderId, reservationId);
        }
    }
}