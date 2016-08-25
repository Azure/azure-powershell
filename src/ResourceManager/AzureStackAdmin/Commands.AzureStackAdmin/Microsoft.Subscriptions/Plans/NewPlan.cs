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
    using System.Linq;
    using System.Management.Automation;

    /// <summary>
    /// New Plan cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.New, Nouns.Plan, DefaultParameterSetName = CommonPSConst.ParameterSet.ByProperty)]
    [OutputType(typeof(AdminPlanModel))]
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
        /// Gets or sets the state of the offer.
        /// </summary>
        [Parameter]
        public AccessibilityState State { get; set; }

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
        [ValidateLength(1, 128)]
        [ValidateNotNull]
        public string ResourceGroup { get; set; }

        /// <summary>
        /// Gets or sets the subscription id.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false)]
        [ValidateGuidNotEmpty]
        public Guid SubscriptionId { get; set; }

        /// <summary>
        /// Executes the API call(s) against Azure Resource Management API(s).
        /// </summary>
        protected override object ExecuteCore()
        {
            this.WriteVerbose(Resources.CreatingNewPlan.FormatArgs(this.Name, this.ResourceGroup));
            using (var client = this.GetAzureStackClient(this.SubscriptionId))
            {
                // Ensure the resource group is created
                client.ResourceGroups.CreateOrUpdate(new ResourceGroupCreateOrUpdateParameters()
                {
                    ResourceGroup = new ResourceGroupDefinition()
                    {
                        Location = this.ArmLocation,
                        Name = this.ResourceGroup,
                    }
                });

                // TODO - determine what properties are needed
                var parameters = new ManagedPlanCreateOrUpdateParameters()
                {
                    Plan = new AdminPlanModel()
                    {
                        Name = this.Name,
                        Location = this.ArmLocation,
                        Properties = new AdminPlanDefinition()
                        {
                            Name = this.Name,
                            DisplayName = this.DisplayName,
                            State = this.State,
                            ServiceQuotas = new ServiceQuotaDefinition[0],
                        }
                    }
                };

                if (client.ManagedPlans.List(this.ResourceGroup, includeDetails: false).Plans
                    .Any(p => string.Equals(p.Properties.Name, parameters.Plan.Properties.Name, StringComparison.OrdinalIgnoreCase)))
                {
                    throw new PSInvalidOperationException(Resources.ManagedPlanAlreadyExists.FormatArgs(parameters.Plan.Properties.Name, this.ResourceGroup));
                }

                return client.ManagedPlans.CreateOrUpdate(this.ResourceGroup, parameters).Plan;
            }
        }
    }
}
