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
using Microsoft.Azure.Commands.Billing.Models;
using Microsoft.Azure.Management.Billing;
using Microsoft.Azure.Management.Billing.Models;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Billing.Cmdlets.BillingAccounts
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "BillingAccount", DefaultParameterSetName = Constants.ParameterSetNames.ListParameterSet), OutputType(typeof(PSBillingAccount))]
    public class GetAzureRmBillingAccount : AzureBillingCmdletBase
    {
        private const string AddressExpand = "soldTo";

        const string BillingProfilesExpand = "billingProfiles";

        const string InvoiceSectionsExpand = "billingProfiles/invoiceSections";
        
        [Parameter(Mandatory = true, HelpMessage = "Name of a specific billing account to get.", ParameterSetName = Constants.ParameterSetNames.SingleItemParameterSet)]
        [ValidateNotNullOrEmpty]
        public List<string> Name { get; set; }
        
        [Parameter(Mandatory = false, HelpMessage = "Populate the address for this billing accounts.")]
        public SwitchParameter IncludeAddress { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Expand the billing profiles under the billing accounts.")]
        public SwitchParameter ExpandBillingProfile { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Expand the billing profiles and invoice sections under the billing profiles.")]
        public SwitchParameter ExpandInvoiceSection { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "List the billing entities like billing profiles, invoice sections, azure plan which are used for creating a subscription.",
            ParameterSetName = Constants.ParameterSetNames.SingleItemParameterSet)]
        public SwitchParameter ListEntitiesToCreateSubscription { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                var expand = this.ExpandBillingProfile.IsPresent ? BillingProfilesExpand : null;

                expand += this.ExpandInvoiceSection.IsPresent ? string.IsNullOrWhiteSpace(expand) ? InvoiceSectionsExpand : "," + InvoiceSectionsExpand : null;

                expand += this.IncludeAddress.IsPresent ? string.IsNullOrWhiteSpace(expand) ? AddressExpand : "," + AddressExpand : null;

                if (ParameterSetName.Equals(Constants.ParameterSetNames.ListParameterSet))
                {
                    WriteObject(
                        string.IsNullOrWhiteSpace(expand)
                            ? BillingManagementClient.BillingAccounts.List().Select(x => new PSBillingAccount(x))
                            : BillingManagementClient.BillingAccounts.List(expand)
                                .Select(x => new PSBillingAccount(x)), true);
                    return;
                }

                if (ParameterSetName.Equals(Constants.ParameterSetNames.SingleItemParameterSet))
                {
                    foreach (var billingAccountName in Name)
                    {
                        try
                        {
                            if (ListEntitiesToCreateSubscription.IsPresent)
                            {
                                var entitiesToCreateSubscription =
                                    BillingManagementClient.BillingAccounts
                                        .ListInvoiceSectionsByCreateSubscriptionPermission(billingAccountName)
                                        .Select(x => new PSEntityToCreateSubscription(x));
                                WriteObject(entitiesToCreateSubscription);
                            }
                            else
                            {
                                var billingAccount = new PSBillingAccount(string.IsNullOrWhiteSpace(expand)
                                    ? BillingManagementClient.BillingAccounts.Get(billingAccountName)
                                    : BillingManagementClient.BillingAccounts.Get(billingAccountName, expand));
                                WriteObject(billingAccount);
                            }
                        }
                        catch (ErrorResponseException error)
                        {
                            WriteWarning(billingAccountName + ": " + error.Body.Error.Message);
                            // continue with the next
                        }
                    }
                }
            }
            catch (ErrorResponseException e)
            {
                WriteWarning(e.Body.Error.Message);
            }
        }
    }
}
