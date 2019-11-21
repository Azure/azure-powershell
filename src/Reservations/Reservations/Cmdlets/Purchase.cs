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
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Reservation", SupportsShouldProcess = true), OutputType(typeof(ReservationOrderResponse))]
    public class Purchase : AzureReservationsCmdletBase
    {
        [Parameter(Mandatory = true)]
        [ValidateNotNull]
        public string ReservationOrderId { get; set; }

        [Parameter(Mandatory = true)]
        [PSArgumentCompleter("VirtualMachines", "SqlDatabases", "SuseLinux", "CosmosDb", "RedHat", "SqlDataWarehouse", "VMwareCloudSimple", "RedHatOsa")]
        [ValidateNotNullOrEmpty]
        public string ReservedResourceType { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Sku { get; set; }

        [Parameter(Mandatory = false)]
        [LocationCompleter("Microsoft.Capacity/catalogs")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string BillingScopeId { get; set; }

        [Parameter(Mandatory = true)]
        [PSArgumentCompleter("P1Y", "P3Y")]
        [ValidateNotNullOrEmpty]
        public string Term { get; set; }

        [Parameter(Mandatory = false)]
        [PSArgumentCompleter("Upfront", "Monthly")]
        [ValidateNotNullOrEmpty]
        public string BillingPlan { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNull]
        public int? Quantity { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNull]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = true)]
        [PSArgumentCompleter("Single", "Shared")]
        [ValidateNotNullOrEmpty]
        public string AppliedScopeType { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNull]
        public string AppliedScope { get; set; }

        [Parameter(Mandatory = false)]
        public bool? Renew { get; set; }

        [Parameter(Mandatory = false)]
        public string InstanceFlexibility { get; set; }

        public override void ExecuteCmdlet()
        {
            var skuN = new SkuName(Sku);
            PurchaseRequest PurchaseRequest = new PurchaseRequest();
            PurchaseRequestPropertiesReservedResourceProperties resourceProperties = new PurchaseRequestPropertiesReservedResourceProperties(InstanceFlexibility);
            PurchaseRequest.Location = Location;
            PurchaseRequest.Quantity = Quantity;
            PurchaseRequest.Renew = Renew;
            PurchaseRequest.Term = Term;
            PurchaseRequest.AppliedScopeType = AppliedScopeType;

            if (AppliedScope != null)
            {
                PurchaseRequest.AppliedScopes = new List<string>() { AppliedScope };
            }
            PurchaseRequest.BillingScopeId = BillingScopeId;
            PurchaseRequest.BillingPlan = BillingPlan;
            PurchaseRequest.DisplayName = DisplayName;
            PurchaseRequest.Sku = skuN;
            PurchaseRequest.ReservedResourceProperties = resourceProperties;
            PurchaseRequest.ReservedResourceType = ReservedResourceType;

            var resourceInfo = $"Reservation order {ReservationOrderId}";
            if (ShouldProcess(resourceInfo, "Purchase"))
            {
                var response = AzureReservationAPIClient.ReservationOrder.Purchase(ReservationOrderId, PurchaseRequest);
                WriteObject(response);
            }
        }
    }
}
