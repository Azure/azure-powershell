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

using Microsoft.Azure.Commands.Billing.Common;
using System;
using System.Collections.Generic;
using System.Linq;
<<<<<<< HEAD
using ApiInvoice = Microsoft.Azure.Management.Billing.Models.Invoice;
=======
using Microsoft.Azure.Management.Billing.Models;

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

namespace Microsoft.Azure.Commands.Billing.Models
{
    public class PSInvoice
    {
<<<<<<< HEAD
        public string Id { get; private set; }

        public string Name { get; private set; }

        public string Type { get; private set; }

        public DateTime? InvoicePeriodStartDate { get; private set; }

        public DateTime? InvoicePeriodEndDate { get; private set; }
=======
        public PSAmount AmountDue { get; set; }

        public PSAmount AzurePrepaymentApplied { get; set; }

        public PSAmount BilledAmount { get; set; }

        public string BillingProfileId { get; set; }

        public string BillingProfileDisplayName { get; set; }

        public PSAmount CreditAmount { get; set; }

        public IEnumerable<PSInvoiceDocument> Documents { get; set; }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

        public string DownloadUrl { get; set; }

        public DateTime? DownloadUrlExpiry { get; set; }

<<<<<<< HEAD
        public List<string> BillingPeriodNames { get; set; }
=======
        public string DueDate { get; set; }

        public PSAmount FreeAzureCreditApplied { get; set; }

        public DateTime? InvoiceDate { get; set; }

        public DateTime? InvoicePeriodEndDate { get; set; }

        public DateTime? InvoicePeriodStartDate { get; set; }

        public bool? IsMonthlyInvoice { get; set; }

        public string Name { get; set; }

        public string PurchaseOrderNumber { get; set; }

        public string Status { get; set; }

        public string SubscriptionId { get; set; }

        public PSAmount SubTotal { get; set; }

        public PSAmount TaxAmount { get; set; }

        public PSAmount TotalAmount { get; set; }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

        public PSInvoice()
        {
        }

<<<<<<< HEAD
        public PSInvoice(ApiInvoice invoice)
        {
            if (invoice != null)
            {
                this.Id = invoice.Id;
                this.Type = invoice.Type;
                this.Name = invoice.Name;
                this.InvoicePeriodStartDate = invoice.InvoicePeriodStartDate;
                this.InvoicePeriodEndDate = invoice.InvoicePeriodEndDate;
                if (invoice.DownloadUrl != null)
                {
                    this.DownloadUrl = invoice.DownloadUrl.Url;
                    this.DownloadUrlExpiry = invoice.DownloadUrl.ExpiryTime;
                }
                if (invoice.BillingPeriodIds != null)
                {
                    this.BillingPeriodNames = invoice.BillingPeriodIds.Select(x => Utilities.GetResourceNameFromId(x)).ToList();
                }
            }
=======
        public PSInvoice(Invoice invoice)
        {
            AmountDue = invoice.AmountDue?.ToPSAmount();
            AzurePrepaymentApplied = invoice.AzurePrepaymentApplied?.ToPSAmount();
            BilledAmount = invoice.BilledAmount?.ToPSAmount();
            BillingProfileDisplayName = invoice.BillingProfileDisplayName;
            BillingProfileId = invoice.BillingProfileId;
            CreditAmount = invoice.CreditAmount?.ToPSAmount();
            DueDate = invoice.DueDate?.ToString("O");
            FreeAzureCreditApplied = invoice.FreeAzureCreditApplied?.ToPSAmount();
            InvoiceDate = invoice.InvoiceDate;
            InvoicePeriodEndDate = invoice.InvoicePeriodEndDate;
            InvoicePeriodStartDate = invoice.InvoicePeriodStartDate;
            IsMonthlyInvoice = invoice.IsMonthlyInvoice;
            Name = invoice.Name;
            PurchaseOrderNumber = invoice.PurchaseOrderNumber;
            Status = invoice.Status;
            Documents = invoice.Documents.Select(doc => doc.ToPSInvoiceDocument());
            SubTotal = invoice.SubTotal?.ToPSAmount();
            SubscriptionId = invoice.SubscriptionId;
            TaxAmount = invoice.TaxAmount?.ToPSAmount();
            TotalAmount = invoice.TotalAmount?.ToPSAmount();
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }
    }
}
