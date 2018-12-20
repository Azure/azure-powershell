using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.Reservations.Common;
using Microsoft.Azure.Commands.Reservations.Models;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Reservations;

namespace Microsoft.Azure.Commands.Reservations.Cmdlets
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ReservationCatalog"), OutputType(typeof(PSCatalog))]
    public class GetCatalog : AzureReservationsCmdletBase
    {
        [Parameter(Mandatory = false)]
        [ValidateNotNull]
        public Guid SubscriptionId { get; set; }

        [Parameter(Mandatory = true)]
        [PSArgumentCompleter("VirtualMachines", "SqlDatabases", "SuseLinux", "CosmosDb")]
        [ValidateNotNullOrEmpty]
        public string ReservedResourceType { get; set; }

        [Parameter(Mandatory = false)]
        [LocationCompleter("Microsoft.Capacity/catalogs")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        public override void ExecuteCmdlet()
        {
            if (SubscriptionId != default(Guid))
            {
                var response = AzureReservationAPIClient
                    .GetCatalog(SubscriptionId.ToString(), ReservedResourceType, Location)
                    .Select(x => new PSCatalog(x));
                WriteObject(response, true);
            }
            else
            {
                var response = AzureReservationAPIClient
                    .GetCatalog(DefaultContext.Subscription.Id, ReservedResourceType, Location)
                    .Select(x => new PSCatalog(x));
                WriteObject(response, true);
            }
        }
    }
}
