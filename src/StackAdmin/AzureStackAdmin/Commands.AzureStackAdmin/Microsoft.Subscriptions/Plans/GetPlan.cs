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
    using System.Management.Automation;
    using Microsoft.AzureStack.Management;
    using Microsoft.AzureStack.Management.Models;

    /// <summary>
    /// Get Plan cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Nouns.Plan)]
    [OutputType(typeof(AdminPlanModel))]
    [Alias("Get-AzureRmPlan")]
    public class GetPlan : AdminApiCmdlet
    {
        /// <summary>
        /// Gets or sets the Plan name.
        /// </summary>
        [Parameter]
        [ValidateNotNull]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the resource group.
        /// </summary>
        [ValidateLength(1, 90)]
        [ValidateNotNull]
        [Parameter(Mandatory = true)]
        [Alias("ResourceGroup")]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets a switch indicating whether to return managed plans.
        /// Plan is exposed only to the service admin now. This parameter will be deprecated
        /// </summary>
        [Parameter]
        public SwitchParameter Managed { get; set; }

        /// <summary>
        /// Executes the API call(s) against Azure Resource Management API(s).
        /// </summary>
        protected override void ExecuteCore()
        {
            if (this.MyInvocation.InvocationName.Equals("Get-AzureRmPlan", StringComparison.OrdinalIgnoreCase))
            {
                this.WriteWarning("Alias Get-AzureRmPlan will be deprecated in a future release. Please use the cmdlet name Get-AzsPlan instead");
            }

            if (this.Managed.IsPresent)
            {
                this.WriteWarning("The parameter Managed will be deprecated in a future release. This parameter is not being used and there is no need to specify");
            }

            using (var client = this.GetAzureStackClient())
            {
                if (string.IsNullOrEmpty(this.Name))
                {
                    this.WriteVerbose(Resources.ListingPlans.FormatArgs(this.ResourceGroupName));
                    var result = client.ManagedPlans.List(this.ResourceGroupName, includeDetails: true).Plans;
                    WriteObject(result, enumerateCollection: true);
                }
                else
                {
                    this.WriteVerbose(Resources.GettingPlan.FormatArgs(this.Name, this.ResourceGroupName));
                    var result = client.ManagedPlans.Get(this.ResourceGroupName, this.Name).Plan;
                    WriteObject(result);
                }
            }
        }
    }
}
