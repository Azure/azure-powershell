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
    using Microsoft.WindowsAzure.Commands.Common;
    using System.Management.Automation;
    using Microsoft.AzureStack.Management;
    using Microsoft.AzureStack.Management.Models;

    /// <summary>
    /// New Plan cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.New, Nouns.Plan, SupportsShouldProcess = true)]
    [OutputType(typeof(AdminPlanModel))]
    [Alias("New-AzureRmPlan")]
    public class NewPlan : AdminApiCmdlet
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateLength(1, 128)]
        [ValidateNotNull]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        [Parameter]
        [ValidateLength(1, 128)]
        [ValidateNotNull]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the resource manager location.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNull]
        public string ArmLocation { get; set; } // TODO - use API to get CSM location?

        /// <summary>
        /// Gets or sets the resource group.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateLength(1, 90)]
        [ValidateNotNull]
        [Alias("ResourceGroup")]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the quota ids.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string[] QuotaIds { get; set; }

        /// <summary>
        /// Gets or sets the SKU ids.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string[] SkuIds { get; set; }

        /// <summary>
        /// Executes the API call(s) against Azure Resource Management API(s).
        /// </summary>
        protected override void ExecuteCore()
        {
            if (this.MyInvocation.InvocationName.Equals("New-AzureRmPlan", StringComparison.OrdinalIgnoreCase))
            {
                this.WriteWarning("Alias New-AzureRmPlan will be deprecated in a future release. Please use the cmdlet name New-AzsPlan instead");
            }

            if (ShouldProcess(this.Name, VerbsCommon.New))
            {
                this.WriteVerbose(Resources.CreatingNewPlan.FormatArgs(this.Name, this.ResourceGroupName));
                using (var client = this.GetAzureStackClient())
                {
                    // Ensure the resource group is created
                    client.ResourceGroups.CreateOrUpdate(new ResourceGroupCreateOrUpdateParameters()
                    {
                        ResourceGroup = new ResourceGroupDefinition()
                        {
                            Location = this.ArmLocation,
                            Name = this.ResourceGroupName,
                        }
                    });

                    // TODO - determine what properties are needed
                    var parameters = new ManagedPlanCreateOrUpdateParameters()
                    {
                        Plan = new AdminPlanModel()
                        {
                            Name = this.Name,
                            Location = this.ArmLocation,
                            Properties = new AdminPlanPropertiesDefinition()
                            {
                                Name = this.Name,
                                DisplayName = this.DisplayName,
                                QuotaIds = (this.QuotaIds != null ? this.QuotaIds.ToList() : null),
                                SkuIds = (this.SkuIds != null ? this.SkuIds.ToList() : null)
                            }
                        }
                    };

                    if (QuotaIds == null && SkuIds == null)
                    {
                        throw new PSInvalidOperationException(Resources.QuotaIdOrSkuIdRequired);
                    }

                    if (client.ManagedPlans.List(this.ResourceGroupName, includeDetails: false).Plans
                        .Any(
                            p =>
                                string.Equals(p.Properties.Name, parameters.Plan.Properties.Name,
                                    StringComparison.OrdinalIgnoreCase)))
                    {
                        throw new PSInvalidOperationException(
                            Resources.PlanAlreadyExists.FormatArgs(parameters.Plan.Properties.Name,
                                this.ResourceGroupName));
                    }

                    var result = client.ManagedPlans.CreateOrUpdate(this.ResourceGroupName, parameters).Plan;
                    WriteObject(result);
                }
            }
        }
    }
}
