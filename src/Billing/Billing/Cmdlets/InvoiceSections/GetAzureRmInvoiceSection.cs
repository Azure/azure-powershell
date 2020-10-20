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

namespace Microsoft.Azure.Commands.Billing.Cmdlets.InvoiceSections
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "InvoiceSection", DefaultParameterSetName = Constants.ParameterSetNames.ListParameterSet), OutputType(typeof(PSInvoiceSection))]
    public class GetAzureRmInvoiceSection : AzureBillingCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "Name of a specific billing account to get.", ParameterSetName = Constants.ParameterSetNames.SingleItemParameterSet)]
        [ValidateNotNullOrEmpty]
        public List<string> Name { get; set; }

        [Parameter(Mandatory = true, Position = 0, HelpMessage = "Name of the billing account.")]
        [ValidateNotNullOrEmpty]
        public string BillingAccountName { get; set; }

        [Parameter(Mandatory = true, Position = 0, HelpMessage = "Name of the billing profile to get invoice sections under it.")]
        [ValidateNotNullOrEmpty]
        public string BillingProfileName { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                if (ParameterSetName.Equals(Constants.ParameterSetNames.ListParameterSet))
                {
                    WriteObject(
                        BillingManagementClient.InvoiceSections
                            .ListByBillingProfile(BillingAccountName, BillingProfileName)
                            .Select(x => new PSInvoiceSection(x)), true);
                    return;
                }

                if (ParameterSetName.Equals(Constants.ParameterSetNames.SingleItemParameterSet))
                {
                    foreach (var invoiceSectionName in Name)
                    {
                        try
                        {
                            var invoiceSection = new PSInvoiceSection(BillingManagementClient.InvoiceSections.Get(BillingAccountName, BillingProfileName, invoiceSectionName));
                            WriteObject(invoiceSection);
                        }
                        catch (ErrorResponseException error)
                        {
                            WriteWarning(invoiceSectionName + ": " + error.Body.Error.Message);
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
