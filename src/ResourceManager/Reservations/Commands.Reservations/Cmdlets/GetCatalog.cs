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
    [Cmdlet(VerbsCommon.Get, "AzureRmReservationCatalog"), OutputType(typeof(List<PSCatalog>))]
    public class GetCatalog : AzureReservationsCmdletBase
    {
        [Parameter(Mandatory = false)]
        [ValidateNotNull]
        public string SubscriptionId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (SubscriptionId != null)
            {
                var response = AzureReservationAPIClient.GetCatalog(SubscriptionId).Select(x => new PSCatalog(x));
                WriteObject(response, true);
            }
            else
            {
                var response = AzureReservationAPIClient.GetCatalog(DefaultContext.Subscription.Id).Select(x => new PSCatalog(x));
                WriteObject(response, true);
            }
        }
    }
}
