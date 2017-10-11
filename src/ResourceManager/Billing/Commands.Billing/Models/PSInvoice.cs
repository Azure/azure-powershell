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
using ApiInvoice = Microsoft.Azure.Management.Billing.Models.Invoice;

namespace Microsoft.Azure.Commands.Billing.Models
{
    public class PSInvoice
    {
        public string Id { get; private set; }

        public string Name { get; private set; }

        public string Type { get; private set; }

        public DateTime? InvoicePeriodStartDate { get; private set; }

        public DateTime? InvoicePeriodEndDate { get; private set; }

        public string DownloadUrl { get; set; }

        public DateTime? DownloadUrlExpiry { get; set; }

        public List<string> BillingPeriodNames { get; set; }

        public PSInvoice()
        {
        }

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
        }
    }
}
