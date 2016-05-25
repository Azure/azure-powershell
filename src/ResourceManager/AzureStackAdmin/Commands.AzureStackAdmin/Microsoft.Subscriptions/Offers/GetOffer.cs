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
    /// Get Offer cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Nouns.Offer, DefaultParameterSetName = "TenantList")]
    [OutputType(typeof(OfferDefinition))]
    [OutputType(typeof(AdminOfferModel))]
    public class GetOffer : AdminApiCmdlet
    {
        /// <summary>
        /// Gets or sets the offer identifier used in the tenant get flow.
        /// </summary>
        [Parameter(ParameterSetName = "TenantGet", Mandatory = true)]
        [ValidateLength(1, 128)]
        [ValidateNotNull]
        public string OfferId { get; set; }

        /// <summary>
        /// Gets or sets the provider name.
        /// </summary>
        [Parameter(ParameterSetName = "TenantList")]
        [ValidateNotNull]
        public string Provider { get; set; }

        /// <summary>
        /// Gets or sets the Offer name used in the Admin get flow.
        /// </summary>
        [Parameter(ParameterSetName = "Admin")]
        [ValidateLength(1, 128)]
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
        /// Gets or sets a switch indicating whether to return managed offers.
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
                        this.WriteVerbose(Resources.ListingManagedOffers.FormatArgs(this.ResourceGroup));
                        return client.ManagedOffers.List(this.ResourceGroup, includeDetails: true).Offers;
                    }
                    else
                    {
                        this.WriteVerbose(Resources.GettingManagedOffer.FormatArgs(this.Name, this.ResourceGroup));
                        return client.ManagedOffers.Get(this.ResourceGroup, this.Name).Offer;
                    }
                }
            }
            else
            {
                using (var client = this.GetAzureStackClient())
                {
                    if (string.IsNullOrEmpty(this.OfferId))
                    {
                        if (string.IsNullOrEmpty(this.Provider))
                        {
                            this.WriteVerbose(Resources.ListingOffers.FormatArgs("<root>"));
                            return client.Offers.ListUnderRootProvider().Offers;
                        }
                        else
                        {
                            this.WriteVerbose(Resources.ListingOffers.FormatArgs(this.Provider));
                            return client.Offers.List(this.Provider).Offers;
                        }
                    }
                    else
                    {
                        this.WriteVerbose(Resources.GettingOffer.FormatArgs(this.OfferId));
                        return client.Offers.Get(this.OfferId).Offer;
                    }
                }
            }
        }
    }
}
