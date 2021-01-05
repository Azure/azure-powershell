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

namespace Microsoft.Azure.Commands.Billing.Cmdlets.BillingProfiles
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "BillingProfile", DefaultParameterSetName = Constants.ParameterSetNames.ListParameterSet), OutputType(typeof(PSBillingProfile))]
    public class GetAzureRmBillingProfile : AzureBillingCmdletBase
    {
        const string EnabledAzurePlansExpand = "enabledAzurePlans";

        const string InvoiceSectionsExpand = "invoiceSections";
        
        [Parameter(Mandatory = true, HelpMessage = "Name of a specific billing account to get.", ParameterSetName = Constants.ParameterSetNames.SingleItemParameterSet)]
        [ValidateNotNullOrEmpty]
        public List<string> Name { get; set; }

        [Parameter(Mandatory = true, Position = 0, HelpMessage = "Name of the billing account to get billing profiles under it.")]
        [ValidateNotNullOrEmpty]
        public string BillingAccountName { get; set; }
        
        [Parameter(Mandatory = false, HelpMessage = "Expand the invoice sections under the billing profiles.")]
        public SwitchParameter ExpandInvoiceSection { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                var expand = this.ExpandInvoiceSection.IsPresent ? InvoiceSectionsExpand : null;
                
                if (ParameterSetName.Equals(Constants.ParameterSetNames.ListParameterSet))
                {
                    WriteObject(
                        string.IsNullOrWhiteSpace(expand)
                            ? BillingManagementClient.BillingProfiles.ListByBillingAccount(BillingAccountName).Select(x => new PSBillingProfile(x))
                            : BillingManagementClient.BillingProfiles.ListByBillingAccount(BillingAccountName, expand)
                                .Select(x => new PSBillingProfile(x)), true);
                    return;
                }

                if (ParameterSetName.Equals(Constants.ParameterSetNames.SingleItemParameterSet))
                {
                    foreach (var billingProfileName in Name)
                    {
                        try
                        {
                            var billingProfile = new PSBillingProfile(string.IsNullOrWhiteSpace(expand)
                                ? BillingManagementClient.BillingProfiles.Get(BillingAccountName, billingProfileName)
                                : BillingManagementClient.BillingProfiles.Get(BillingAccountName, billingProfileName, expand));
                            WriteObject(billingProfile);
                        }
                        catch (ErrorResponseException error)
                        {
                            WriteWarning(billingProfileName + ": " + error.Body.Error.Message);
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
