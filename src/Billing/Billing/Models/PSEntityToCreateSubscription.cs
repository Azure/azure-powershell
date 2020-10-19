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
using ApiInvoiceSectionWithCreateSubPermission = Microsoft.Azure.Management.Billing.Models.InvoiceSectionWithCreateSubPermission;

namespace Microsoft.Azure.Commands.Billing.Models
{
    public class PSEntityToCreateSubscription
    {
        public IEnumerable<PSAzurePlan> EnabledAzurePlans { get; private set; }

        public string BillingProfileId { get; private set; }

        public string BillingProfileDisplayName { get; private set; }
        
        public string BillingProfileStatus { get; private set; }

        public string BillingProfileStatusReasonCode { get; private set; }

        public string BillingProfileSpendingLimit { get; private set; }

        public string BillingProfileSystemId { get; private set; }

        public string InvoiceSectionId { get; private set; }

        public string InvoiceSectionDisplayName { get; private set; }

        public string InvoiceSectionSystemId { get; private set; }

        public PSEntityToCreateSubscription()
        {
        }

        public PSEntityToCreateSubscription(ApiInvoiceSectionWithCreateSubPermission entityToCreateSubscription)
        {
            if (entityToCreateSubscription != null)
            {
                this.BillingProfileId = entityToCreateSubscription.BillingProfileId;
                this.BillingProfileDisplayName = entityToCreateSubscription.BillingProfileDisplayName;
                this.BillingProfileStatus = entityToCreateSubscription.BillingProfileStatus;
                this.BillingProfileStatusReasonCode = entityToCreateSubscription.BillingProfileStatusReasonCode;
                this.BillingProfileSpendingLimit = entityToCreateSubscription.BillingProfileSpendingLimit;
                this.BillingProfileSystemId = entityToCreateSubscription.BillingProfileSystemId;
                this.InvoiceSectionId = entityToCreateSubscription.InvoiceSectionId;
                this.InvoiceSectionDisplayName = entityToCreateSubscription.InvoiceSectionDisplayName;
                this.InvoiceSectionSystemId = entityToCreateSubscription.InvoiceSectionSystemId;

                if (entityToCreateSubscription.EnabledAzurePlans != null && entityToCreateSubscription.EnabledAzurePlans.Any())
                {
                    this.EnabledAzurePlans =
                        entityToCreateSubscription.EnabledAzurePlans.Select(azurePlan => new PSAzurePlan(azurePlan));
                }
            }
        }
    }
}
