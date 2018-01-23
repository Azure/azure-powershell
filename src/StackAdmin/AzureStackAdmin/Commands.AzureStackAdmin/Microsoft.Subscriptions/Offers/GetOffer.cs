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
    using System.Management.Automation;
    using Microsoft.AzureStack.Management;
    using Microsoft.AzureStack.Management.Models;

    /// <summary>
    /// Get Offer cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Nouns.Offer, DefaultParameterSetName = "TenantList")]
    [OutputType(typeof(OfferDefinition))]
    [OutputType(typeof(AdminOfferModel))]
    [Alias("Get-AzureRmOffer")]
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
        [ValidateLength(1, 90)]
        [ValidateNotNull]
        [Alias("ResourceGroup")]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets a switch indicating whether to return managed offers.
        /// </summary>
        [Parameter(ParameterSetName = "Admin", Mandatory = true)]
        public SwitchParameter Managed { get; set; }

        /// <summary>
        /// Executes the API call(s) against Azure Resource Management API(s).
        /// </summary>
        protected override void ExecuteCore()
        {
            // note: this command should be deprecated
            WriteWarning("Get-AzureRmOffer cmdlet will be deprecated and moved to a different module in a future release.");

            if (this.Managed.IsPresent)
            {
                 this.WriteWarning("The switch parameter Managed will be deprecated in a future release. Please use the cmdlet Get-AzsManagedOffer instead");

                using (var client = this.GetAzureStackClient())
                {
                    if (string.IsNullOrEmpty(this.Name))
                    {
                        this.WriteVerbose(Resources.ListingManagedOffers.FormatArgs(this.ResourceGroupName));
                        var result = client.ManagedOffers.List(this.ResourceGroupName, includeDetails: true).Offers;
                        WriteObject(result, enumerateCollection: true);
                    }
                    else
                    {
                        this.WriteVerbose(Resources.GettingManagedOffer.FormatArgs(this.Name, this.ResourceGroupName));
                        var result = client.ManagedOffers.Get(this.ResourceGroupName, this.Name).Offer;
                        WriteObject(result);
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
                            var result = client.Offers.ListUnderRootProvider().Offers;
                            WriteObject(result, enumerateCollection:true);
                        }
                        else
                        {
                            this.WriteVerbose(Resources.ListingOffers.FormatArgs(this.Provider));
                            var result = client.Offers.List(this.Provider).Offers;
                            WriteObject(result, enumerateCollection:true);
                        }
                    }
                    else
                    {
                        this.WriteVerbose(Resources.GettingOffer.FormatArgs(this.OfferId));
                        var result = client.Offers.Get(this.OfferId).Offer;
                        WriteObject(result);
                    }
                }
            }
        }
    }
}
