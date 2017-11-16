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
    /// Get Resource Provider Manifest Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Nouns.ResourceProviderManifest)]
    [OutputType(typeof(ProviderRegistrationModel))]
    [Alias("Get-AzureRmResourceProviderRegistration")]
    public class GetResourceProviderManifest : AdminApiCmdlet
    {
        /// <summary>
        /// Gets or sets the resource provider registration name.
        /// </summary>
        [Parameter]
        [ValidateLength(1, 128)]
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
            if (this.MyInvocation.InvocationName.Equals("Get-AzureRmResourceProviderRegistration", StringComparison.OrdinalIgnoreCase))
            {
                this.WriteWarning("Alias Get-AzureRmResourceProviderRegistration will be deprecated in a future release. Please use the cmdlet Get-AzsResourceProviderManifest instead");
            }

            using (var client = this.GetAzureStackClient())
            {
                if (string.IsNullOrEmpty(this.Name))
                {
                    this.WriteVerbose(Resources.ListingResourceProviderManifests);
                    var result = client.ProviderRegistrations.List(this.ResourceGroupName).ProviderRegistrations;
                    WriteObject(result, enumerateCollection: true);
                }
                else
                {
                    this.WriteVerbose(Resources.GettingResourceProviderManifest.FormatArgs(this.Name));
                    var result = client.ProviderRegistrations.Get(this.ResourceGroupName, this.Name).ProviderRegistration;
                    WriteObject(result);
                }
            }
        }
    }
}
