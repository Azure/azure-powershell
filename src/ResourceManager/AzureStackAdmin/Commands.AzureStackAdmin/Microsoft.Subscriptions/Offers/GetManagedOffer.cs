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
    [Cmdlet(VerbsCommon.Get, Nouns.ManagedOffer)]
    [OutputType(typeof(AdminOfferModel))]
    public class GetManagedOffer : AdminApiCmdlet
    {
        /// <summary>
        /// Gets or sets the Offer name used in the Admin get flow.
        /// </summary>
        [ValidateLength(1, 128)]
        [ValidateNotNull]
        [Parameter]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the resource group.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateLength(1, 90)]
        [ValidateNotNull]
        [Alias("ResourceGroup")]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Executes the API call(s) against Azure Resource Management API(s).
        /// </summary>
        protected override void ExecuteCore()
        {
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
    }
}
