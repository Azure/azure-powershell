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

namespace Microsoft.Azure.Commands.Billing.Cmdlets.BillingPeriods
{
    [Cmdlet(VerbsCommon.Get, "AzureRmBillingPeriod", DefaultParameterSetName = Constants.ParameterSetNames.ListParameterSet), OutputType(typeof(List<PSBillingPeriod>), typeof(PSBillingPeriod))]
    public class GetAzureRmBillingPeriod : AzureBillingCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "Name of a specific billing period to get.", ParameterSetName = Constants.ParameterSetNames.SingleItemParameterSet)]
        [ValidateNotNullOrEmpty]
        public List<string> Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Determine the maximum number of records to return.", ParameterSetName = Constants.ParameterSetNames.ListParameterSet)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int? MaxCount { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(Constants.ParameterSetNames.ListParameterSet))
            {
                try
                {
                    WriteObject(BillingManagementClient.BillingPeriods.List(top: MaxCount).Select(x => new PSBillingPeriod(x)), true);
                }
                catch (ErrorResponseException error)
                {
                    WriteWarning(error.Body.Error.Message);
                }
                return;
            }

            if (ParameterSetName.Equals(Constants.ParameterSetNames.SingleItemParameterSet))
            {
                foreach (var billingPeriodName in Name)
                {
                    try
                    {
                        var billingPeriod = new PSBillingPeriod(BillingManagementClient.BillingPeriods.Get(billingPeriodName));
                        WriteObject(billingPeriod);
                    }
                    catch (ErrorResponseException error)
                    {
                        WriteWarning(billingPeriodName + ": " + error.Body.Error.Message);
                        // continue with the next
                    }
                }
            }
        }
    }
}
