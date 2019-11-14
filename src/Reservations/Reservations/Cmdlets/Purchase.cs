using System;
using Microsoft.Azure.Commands.Reservations.Common;
using System.Management.Automation;
using Microsoft.Azure.Management.Reservations;
using Microsoft.Azure.Commands.Reservations.Models;
using Microsoft.Azure.Management.Reservations.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Reservations.Cmdlets
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PurchaseReservationOrder"), OutputType(typeof(ReservationOrderResponse))]
    public class Purchase : AzureReservationsCmdletBase
    {
        [Parameter(Mandatory = true)]
        [ValidateNotNull]
        public string ReservationOrderId { get; set; }

        [Parameter(Mandatory = true)]
        [PSArgumentCompleter("VirtualMachines", "SqlDatabases", "SuseLinux", "CosmosDb")]
        [ValidateNotNullOrEmpty]
        public string ReservedResourceType { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Sku { get; set; }

        [Parameter(Mandatory = true)]
        [LocationCompleter("Microsoft.Capacity/catalogs")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string BillingScopeId { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Term { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string BillingPlan { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNull]
        public int? Quantity { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNull]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = true)]
        [PSArgumentCompleter("Single", "Shared")]
        [ValidateNotNullOrEmpty]
        public string AppliedScopeType { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNull]
        public IList<string> AppliedScopes { get; set; }

        public bool? Renew { get; set; }

        public PurchaseRequestPropertiesReservedResourceProperties ReservedResourceProperties { get; set; }

        public override void ExecuteCmdlet()
        {
            var skuN = new SkuName(Sku);
            PurchaseRequest PurchaseRequest = new PurchaseRequest();
            PurchaseRequest.Location = Location;
            PurchaseRequest.Quantity = Quantity;
            PurchaseRequest.Renew = Renew;
            PurchaseRequest.Term = Term;
            PurchaseRequest.AppliedScopeType = AppliedScopeType;
            PurchaseRequest.AppliedScopes = AppliedScopes;
            PurchaseRequest.BillingScopeId = BillingScopeId;
            PurchaseRequest.BillingPlan = BillingPlan;
            PurchaseRequest.DisplayName = DisplayName;
            PurchaseRequest.Sku = skuN;
            PurchaseRequest.ReservedResourceProperties = ReservedResourceProperties;
            PurchaseRequest.ReservedResourceType = ReservedResourceType;

            var response = AzureReservationAPIClient.ReservationOrder.Purchase(ReservationOrderId, PurchaseRequest);
            WriteObject(response);
        }
    }
}
