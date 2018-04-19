using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.Reservations.Common;
using Microsoft.Azure.Management.Reservations.Models;
using System.Management.Automation;
using Microsoft.Azure.Commands.Reservations.Models;
using Microsoft.Azure.Management.Reservations;

namespace Microsoft.Azure.Commands.Reservations.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "AzureRmReservationOrderId"), OutputType(typeof(AppliedReservations))]
    public class GetReservationOrderId : AzureReservationsCmdletBase
    {

        [Parameter(Mandatory = false)]
        [ValidateNotNull]
        public Guid SubscriptionId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (SubscriptionId != default(Guid))
            {
                var response = new PSAppliedReservationOrderId(AzureReservationAPIClient.GetAppliedReservationList(SubscriptionId.ToString()));
                WriteObject(response);
            }
            else
            {
                var response = new PSAppliedReservationOrderId(AzureReservationAPIClient.GetAppliedReservationList(DefaultContext.Subscription.Id));
                WriteObject(response);
            }
        }
    }
}
