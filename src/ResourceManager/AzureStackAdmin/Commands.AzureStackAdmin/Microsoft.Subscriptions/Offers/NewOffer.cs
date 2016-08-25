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
    /// New Offer cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.New, Nouns.Offer)]
    [OutputType(typeof(AdminOfferModel))]
    public class NewOffer : AdminApiCmdlet
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
        /// Gets or sets the base plans.
        /// </summary>
        [Parameter(ValueFromPipeline = true)]
        [ValidateNotNull]
        public AdminPlanModel[] BasePlans { get; set; }

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
        [Parameter(Mandatory = false)]
        [ValidateGuidNotEmpty]
        public Guid SubscriptionId { get; set; }

        /// <summary>
        /// Executes the API call(s) against Azure Resource Management API(s).
        /// </summary>
        protected override object ExecuteCore()
        {
            this.WriteVerbose(Resources.CreatingNewOffer.FormatArgs(this.Name, this.ResourceGroup));
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

                var parameters = new ManagedOfferCreateOrUpdateParameters()
                {
                    Offer = new AdminOfferModel()
                    {
                        Name = this.Name,
                        Location = this.ArmLocation,
                        Properties = new AdminOfferDefinition()
                        {
                            Name = this.Name,
                            DisplayName = this.DisplayName,
                            State = this.State,
                        }
                    }
                };

                if (this.BasePlans != null && this.BasePlans.Length > 0)
                {
                    parameters.Offer.Properties.BasePlans = this.BasePlans.Select(plan => plan.Properties).ToArray();
                }

                if (client.ManagedOffers.List(this.ResourceGroup, includeDetails: false).Offers
                    .Any(offer => string.Equals(offer.Properties.Name, parameters.Offer.Properties.Name, StringComparison.OrdinalIgnoreCase)))
                {
                    throw new PSInvalidOperationException(Resources.ManagedOfferAlreadyExists.FormatArgs(parameters.Offer.Properties.Name, this.ResourceGroup));
                }

                return client.ManagedOffers.CreateOrUpdate(this.ResourceGroup, parameters).Offer;
            }
        }
    }
}
