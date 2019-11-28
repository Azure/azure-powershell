using Microsoft.Azure.Commands.Reservations.Common;
using System.Management.Automation;
using Microsoft.Azure.Management.Reservations;
using Microsoft.Azure.Management.Reservations.Models;
using System.Collections.Generic;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Reservations.Custom;

namespace Microsoft.Azure.Commands.Reservations.Cmdlets
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ReservationQuote"), OutputType(typeof(CalculatePriceResponse))]
    public class Calculate : AzureReservationsCmdletBase
    {
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
            PurchaseRequestPropertiesReservedResourceProperties resourceProperties = new PurchaseRequestPropertiesReservedResourceProperties(InstanceFlexibility);
            PurchaseRequest PurchaseRequest = new PurchaseRequest();

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

            var response = AzureReservationAPIClient.ReservationOrder.Calculate(PurchaseRequest);
            var prop = new PSCalculatePriceResponseProperties(response.Properties);
            WriteObject(prop);
        }
    }
}
