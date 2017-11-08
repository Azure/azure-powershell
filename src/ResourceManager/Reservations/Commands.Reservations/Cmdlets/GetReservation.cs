using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Reservations.Common;
using Microsoft.Azure.Management.Reservations.Models;
using Microsoft.Azure.Commands.Reservations.Models;
using System.Management.Automation;
using Microsoft.Azure.Management.Reservations;

namespace Microsoft.Azure.Commands.Reservations.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "AzureRmReservation", DefaultParameterSetName = Constants.ParameterSetNames.CommandParameterSet), OutputType(typeof(PSReservationPage), typeof(PSReservation))]
    public class GetReservation : AzureReservationsCmdletBase
    {
        [Parameter(ParameterSetName = Constants.ParameterSetNames.CommandParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string ReservationOrderId { get; set; }

        [Parameter(ParameterSetName = Constants.ParameterSetNames.CommandParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = false)]
        public string ReservationId { get; set; }

        [Parameter(ParameterSetName = Constants.ParameterSetNames.ObjectParameterSet,
            Mandatory = false,
            ValueFromPipeline = true)]
        [ValidateNotNull]
        public PSReservationOrder ReservationOrder { get; set; }

        [Parameter(ParameterSetName = Constants.ParameterSetNames.PageObjectParameterSet,
            Mandatory = false,
            ValueFromPipeline = true)]
        [ValidateNotNull]
        public PSReservationOrderPage ReservationOrderPage { get; set; }

        private void PageResults()
        {
            var response = new PSReservationPage(AzureReservationAPIClient.Reservation.List(ReservationOrderId));
            WriteObject(response, true);
            while (response.NextPageLink != null)
            {
                response = new PSReservationPage(AzureReservationAPIClient.Reservation.ListNext(response.NextPageLink));
                WriteObject(response, true);
            }
        }
        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(Constants.ParameterSetNames.CommandParameterSet))
            {
                if (ReservationId != null)
                {
                    var response = new PSReservation(AzureReservationAPIClient.Reservation.Get(ReservationId, ReservationOrderId));
                    WriteObject(response);
                }
                else
                {
                    PageResults();
                }
            }
            else if (ParameterSetName.Equals(Constants.ParameterSetNames.ObjectParameterSet))
            {
                if (ReservationOrder != null)
                {
                    ReservationOrderId = ReservationOrder.Name;
                    PageResults();
                }
            }
            else if (ParameterSetName.Equals(Constants.ParameterSetNames.PageObjectParameterSet))
            {
                if (ReservationOrderPage != null)
                {
                    foreach (PSReservationOrder ReservationOrder in ReservationOrderPage)
                    {
                        ReservationOrderId = ReservationOrder.Name;
                        PageResults();
                    }
                    while (ReservationOrderPage.NextPageLink != null)
                    {
                        ReservationOrderPage =
                            new PSReservationOrderPage(
                                AzureReservationAPIClient.ReservationOrder.ListNext(ReservationOrderPage.NextPageLink));
                        foreach (PSReservationOrder ReservationOrder in ReservationOrderPage)
                        {
                            ReservationOrderId = ReservationOrder.Name;
                            PageResults();
                        }
                    }
                }
            }
        }
    }
}
