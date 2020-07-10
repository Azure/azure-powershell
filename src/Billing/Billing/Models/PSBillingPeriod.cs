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
using ApiBillingPeriod = Microsoft.Azure.Management.Billing.Models.BillingPeriod;

namespace Microsoft.Azure.Commands.Billing.Models
{
    public class PSBillingPeriod
    {
        public string Id { get; private set; }

        public string Name { get; private set; }

        public string Type { get; private set; }

        public DateTime? BillingPeriodStartDate { get; private set; }

        public DateTime? BillingPeriodEndDate { get; private set; }

        public List<string> InvoiceNames { get; set; }

        public PSBillingPeriod()
        {
        }

        public PSBillingPeriod(ApiBillingPeriod billingPeriod)
        {
            if (billingPeriod != null)
            {
                this.Id = billingPeriod.Id;
                this.Type = billingPeriod.Type;
                this.Name = billingPeriod.Name;
                this.BillingPeriodStartDate = billingPeriod.BillingPeriodStartDate;
                this.BillingPeriodEndDate = billingPeriod.BillingPeriodEndDate;
                if (billingPeriod.InvoiceIds != null)
                {
                    this.InvoiceNames = billingPeriod.InvoiceIds.Select(x => Utilities.GetResourceNameFromId(x)).ToList();
                }
            }
        }
    }
}
