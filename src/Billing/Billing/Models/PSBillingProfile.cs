// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.Common.Strategies;
using ApiBillingProfile = Microsoft.Azure.Management.Billing.Models.BillingProfile;

namespace Microsoft.Azure.Commands.Billing.Models
{
    public class PSBillingProfile
    {
        public string Id { get; private set; }

        public string Name { get; private set; }

        public string Type { get; private set; }

        public PSAddressDetails BillTo { get; set; }

        public string Currency { get; private set; }

        public string DisplayName { get; private set; }

        public IEnumerable<PSAzurePlan> EnabledAzurePlans { get; private set; }

        public bool? HasReadAccess { get; private set; }

        public string PurchaseOrderNumber { get; private set; }

        public int? InvoiceDay { get; private set; }

        public bool? InvoiceEmailOptIn { get; private set; }
        
        public IEnumerable<PSInvoiceSection> InvoiceSections { get; private set; }

        public string SpendingLimit { get; private set; }

        public string Status { get; private set; }

        public string StatusReasonCode { get; private set; }

        public string SystemId { get; private set; }

        public PSBillingProfile()
        {
        }

        public PSBillingProfile(ApiBillingProfile billingProfile)
        {
            if (billingProfile != null)
            {
                this.Id = billingProfile.Id;
                this.Type = billingProfile.Type;
                this.Name = billingProfile.Name;
                this.Currency = billingProfile.Currency;
                this.DisplayName = billingProfile.DisplayName;
                this.HasReadAccess = billingProfile.HasReadAccess;
                this.PurchaseOrderNumber = billingProfile.PoNumber;
                this.InvoiceDay = billingProfile.InvoiceDay;
                this.InvoiceEmailOptIn = billingProfile.InvoiceEmailOptIn;
                this.SpendingLimit = billingProfile.SpendingLimit;
                this.Status = billingProfile.Status;
                this.StatusReasonCode = billingProfile.StatusReasonCode;
                this.SystemId = billingProfile.SystemId;

                if (billingProfile.BillTo != null)
                {
                    this.BillTo = new PSAddressDetails(billingProfile.BillTo);
                }

                if (billingProfile.EnabledAzurePlans != null && billingProfile.EnabledAzurePlans.Any())
                {
                    this.EnabledAzurePlans =
                        billingProfile.EnabledAzurePlans.Select(azurePlan => new PSAzurePlan(azurePlan));
                }

                if (billingProfile.InvoiceSections?.Value != null && billingProfile.InvoiceSections.Value.Any())
                {
                    this.InvoiceSections =
                        billingProfile.InvoiceSections.Value.Select(invoiceSection => new PSInvoiceSection(invoiceSection));
                }
            }
        }
    }
}
