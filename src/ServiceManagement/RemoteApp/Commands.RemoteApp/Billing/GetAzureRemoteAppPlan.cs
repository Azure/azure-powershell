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

using Microsoft.WindowsAzure.Commands.RemoteApp;
using Microsoft.WindowsAzure.Management.RemoteApp;
using Microsoft.WindowsAzure.Management.RemoteApp.Models;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Management.RemoteApp.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "AzureRemoteAppPlan"), OutputType(typeof(BillingPlan))]
    public class GetAzureRemoteAppPlan : RdsCmdlet
    {
        public override void ExecuteCmdlet()
        {
            ListBillingPlansResult billingPlans = CallClient(() => Client.Account.ListBillingPlans(), Client.Account);

            if (billingPlans.PlanList.Count > 0)
            {
                WriteObject(billingPlans.PlanList, true);
            }
            else
            {
                WriteVerboseWithTimestamp(Commands_RemoteApp.NoPlansFoundMessage);
            }
        }
    }
}
