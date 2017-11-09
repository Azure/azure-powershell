using System;
using System.Collections.Generic;
using Microsoft.Azure.Commands.Reservations.Common;
using Microsoft.Azure.Management.Reservations.Models;
using Microsoft.Azure.Commands.Reservations.Models;
using System.Management.Automation;
using Newtonsoft.Json;
using Microsoft.Azure.Management.Reservations;

namespace Microsoft.Azure.Commands.Reservations.Cmdlets
{
    [Cmdlet(VerbsData.Update, "AzureRmReservation", DefaultParameterSetName = Constants.ParameterSetNames.CommandParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSReservation))]
    public class PatchReservation : AzureReservationsCmdletBase
    {
        [Parameter(ParameterSetName = Constants.ParameterSetNames.CommandParameterSet,
            Mandatory = true)]
        [ValidateNotNull]
        public string ReservationOrderId { get; set; }

        [Parameter(ParameterSetName = Constants.ParameterSetNames.CommandParameterSet,
            Mandatory = true)]
        [ValidateNotNull]
        public string ReservationId { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNull]
        [ValidateSet ("Single", "Shared")]
        public string AppliedScopeType { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNull]
        public string AppliedScope { get; set; }

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
                ReservationOrderId = name[0];
                ReservationId = name[1];
            }

            var resourceInfo = $"Reservation {ReservationId} in order {ReservationOrderId}";
            if (ShouldProcess(resourceInfo, "Update"))
            {
                
                Patch Patch;
                if (AppliedScope != null)
                {
                    Patch = new Patch(AppliedScopeType, new List<string>() { AppliedScope });
                }
                else
                {
                    Patch = new Patch(AppliedScopeType);
                }
                var response = new PSReservation(AzureReservationAPIClient.Reservation.Update(ReservationOrderId, ReservationId, Patch));
                WriteObject(response);
            }
        }
    }
}
