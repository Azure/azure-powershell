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
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.Billing.Cmdlets.BillingAccounts
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "BillingAccount", DefaultParameterSetName = Constants.ParameterSetNames.ListParameterSet), OutputType(typeof(PSBillingAccount))]
    public class GetAzureRmBillingAccount : AzureBillingCmdletBase
    {
        private const string AddressExpand = "address";

        const string BillingProfilesExpand = "billingProfiles";

        const string InvoiceSectionsExpand = "billingProfiles/invoiceSections";
        
        [Parameter(Mandatory = true, HelpMessage = "Name of a specific billing account to get.", ParameterSetName = Constants.ParameterSetNames.SingleItemParameterSet)]
        [ValidateNotNullOrEmpty]
        public List<string> Name { get; set; }
        
        [Parameter(Mandatory = false, HelpMessage = "Populate the address for this billing accounts.", ParameterSetName = Constants.ParameterSetNames.ListParameterSet)]
        public SwitchParameter PopulateAddress { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Expand the billing profiles under the billing accounts.", ParameterSetName = Constants.ParameterSetNames.ListParameterSet)]
        public SwitchParameter ExpandBillingProfiles { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Expand the billing profiles and invoice sections under the billing profiles.", ParameterSetName = Constants.ParameterSetNames.ListParameterSet)]
        public SwitchParameter ExpandInvoiceSections { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {

                var expand = this.ExpandBillingProfiles.IsPresent ? BillingProfilesExpand : null;

                expand += this.ExpandInvoiceSections.IsPresent ? string.IsNullOrWhiteSpace(expand) ? InvoiceSectionsExpand : "," + InvoiceSectionsExpand : null;

                expand += this.PopulateAddress.IsPresent ? string.IsNullOrWhiteSpace(expand) ? AddressExpand : "," + AddressExpand : null;

                if (ParameterSetName.Equals(Constants.ParameterSetNames.ListParameterSet))
                {
                    WriteObject(BillingManagementClient.BillingAccounts.List(expand).Value.Select(x => new PSBillingAccount(x)), true);
                    return;
                }

                if (ParameterSetName.Equals(Constants.ParameterSetNames.SingleItemParameterSet))
                {
                    foreach (var billingAccountName in Name)
                    {
                        try
                        {
                            var billingAccount = new PSBillingAccount(BillingManagementClient.BillingAccounts.Get(billingAccountName));
                            WriteObject(billingAccount);
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
