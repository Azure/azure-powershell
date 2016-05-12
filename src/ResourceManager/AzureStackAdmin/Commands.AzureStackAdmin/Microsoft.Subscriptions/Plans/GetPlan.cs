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
    using Microsoft.AzureStack.Management;
    using Microsoft.AzureStack.Management.Models;
    using Microsoft.WindowsAzure.Commands.Common;
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Get Plan cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Nouns.Plan, DefaultParameterSetName = "TenantList")]
    [OutputType(typeof(AdminPlanModel))]
    ////[OutputType(typeof(PlanDefinition))]
    public class GetPlan : AdminApiCmdlet
    {
        /// <summary>
        /// Gets or sets the Offer name.
        /// </summary>
        [Parameter(ParameterSetName = "TenantGet", Mandatory = true)]
        [Parameter(ParameterSetName = "Admin")]
        [ValidateNotNull]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the resource group.
        /// </summary>
        [Parameter(ParameterSetName = "Admin", Mandatory = true)]
        [ValidateLength(1, 128)]
        [ValidateNotNull]
        public string ResourceGroup { get; set; }

        /// <summary>
        /// Gets or sets the subscription id.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = "Admin", Mandatory = false)]
        [ValidateGuidNotEmpty]
        public Guid SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets a switch indicating whether to return managed plans.
        /// </summary>
        [Parameter(ParameterSetName = "Admin", Mandatory = true)]
        public SwitchParameter Managed { get; set; }

        /// <summary>
        /// Executes the API call(s) against Azure Resource Management API(s).
        /// </summary>
        protected override object ExecuteCore()
        {
            if (this.Managed.IsPresent)
            {
                using (var client = this.GetAzureStackClient(this.SubscriptionId))
                {
                    if (string.IsNullOrEmpty(this.Name))
                    {
                        this.WriteVerbose(Resources.ListingManagedPlans.FormatArgs(this.ResourceGroup));
                        return client.ManagedPlans.List(this.ResourceGroup, includeDetails: true).Plans;
                    }
                    else
                    {
                        this.WriteVerbose(Resources.GettingManagedPlan.FormatArgs(this.Name, this.ResourceGroup));
                        return client.ManagedPlans.Get(this.ResourceGroup, this.Name).Plan;
                    }
                }
            }
            else
            {
                throw new PSNotSupportedException("This API is not supported at this time. Please use the -Managed switch to get managed plans.");

                ////using (var client = this.GetAzureStackClient())
                ////{
                ////    if (string.IsNullOrEmpty(this.Name))
                ////    {
                ////        this.WriteVerbose(Resources.ListingPlans);
                ////        return client.Plans.List(includeDetails: true).Plans;
                ////    }
                ////    else
                ////    {
                ////        this.WriteVerbose(Resources.GettingPlan.FormatArgs(this.Name));
                ////        return client.Plans.Get(this.Name).Plan;
                ////    }
                ////}
            }
        }
    }
}
