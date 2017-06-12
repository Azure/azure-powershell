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

namespace Microsoft.AzureStack.Commands
{
    using System;
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.WindowsAzure.Commands.Common;
    using Microsoft.AzureStack.Management;
    using Microsoft.AzureStack.Management.Models;

    /// <summary>
    /// Set Plan cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Set, Nouns.Plan)]
    [OutputType(typeof(AdminPlanModel))]
    [Alias("Set-AzureRmPlan")]
    public class SetPlan : AdminApiCmdlet
    {
        /// <summary>
        /// Gets or sets the plan.
        /// </summary>
        [Parameter(ValueFromPipeline = true, Mandatory = true)]
        [ValidateNotNull]
        public AdminPlanModel Plan { get; set; }

        /// <summary>
        /// Gets or sets the resource group.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNull]
        [ValidateLength(1, 90)]
        [Alias("ResourceGroup")]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Executes the API call(s) against Azure Resource Management API(s).
        /// </summary>
        protected override object ExecuteCore()
        {
            if (this.MyInvocation.InvocationName.Equals("Set-AzureRMPlan", StringComparison.OrdinalIgnoreCase))
            {
                this.WriteWarning("Alias Set-AzureRMPlan will be deprecated in a future release. Please use the cmdlet name Set-AzSPlan instead");
            }

            using (var client = this.GetAzureStackClient())
            {
                this.WriteVerbose(Resources.UpdatingPlan.FormatArgs(this.Plan.Name, this.ResourceGroupName));
                var parameters = new ManagedPlanCreateOrUpdateParameters(this.Plan);
                return client.ManagedPlans.CreateOrUpdate(this.ResourceGroupName, parameters).Plan;
            }
        }
    }
}
