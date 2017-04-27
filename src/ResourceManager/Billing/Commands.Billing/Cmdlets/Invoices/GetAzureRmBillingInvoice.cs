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
using Microsoft.Azure.Commands.Billing.Properties;
using Microsoft.Azure.Management.Billing;
using Microsoft.Azure.Management.Billing.Models;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Billing.Cmdlets.Invoices
{
    [Cmdlet(VerbsCommon.Get, "AzureRmBillingInvoice", DefaultParameterSetName = Constants.ParameterSetNames.ListParameterSet), OutputType(typeof(List<PSInvoice>), typeof(PSInvoice))]
    public class GetAzureRmBillingInvoice : AzureBillingCmdletBase
    {
        const string DownloadUrlExpand = "downloadUrl";

        [Parameter(Mandatory = true, HelpMessage = "Get the latest invoice.", ParameterSetName = Constants.ParameterSetNames.LatestItemParameterSet)]
        public SwitchParameter Latest { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Name of a specific invoice to get.", ParameterSetName = Constants.ParameterSetNames.SingleItemParameterSet)]
        [ValidateNotNullOrEmpty]
        public List<string> Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Determine the maximum number of records to return.", ParameterSetName = Constants.ParameterSetNames.ListParameterSet)]
        [ValidateNotNull]
        public int? MaxCount { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Generate the download url of the invoices.", ParameterSetName = Constants.ParameterSetNames.ListParameterSet)]
        public SwitchParameter GenerateDownloadUrl { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                if (ParameterSetName.Equals(Constants.ParameterSetNames.ListParameterSet))
                {
                    string expand = this.GenerateDownloadUrl.IsPresent ? DownloadUrlExpand : null;

                    if (MaxCount.HasValue && (MaxCount.Value > 100 || MaxCount.Value < 1))
                    {
                        throw new PSArgumentException(Resources.MaxCountExceedRangeError);
                    }

                    WriteObject(BillingManagementClient.Invoices.List(expand, null, null, MaxCount).Select(x => new PSInvoice(x)), true);
                    return;
                }

                if (ParameterSetName.Equals(Constants.ParameterSetNames.LatestItemParameterSet))
                {
                    Invoice invoice = BillingManagementClient.Invoices.GetLatest();
                    WriteObject(new PSInvoice(invoice));
                }
                else if (ParameterSetName.Equals(Constants.ParameterSetNames.SingleItemParameterSet))
                {
                    foreach (var invoiceName in Name)
                    {
                        try
                        {
                            var invoice = new PSInvoice(BillingManagementClient.Invoices.Get(invoiceName));
                            WriteObject(invoice);
                        }
                        catch (ErrorResponseException error)
                        {
                            WriteWarning(invoiceName + ": " + error.Body.Error.Message);
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
