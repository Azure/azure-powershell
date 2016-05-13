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
    /// Resource Provider Registration Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Nouns.ResourceProviderRegistration)]
    [OutputType(typeof(ProviderRegistrationModel))]
    public class GetResourceProviderRegistration : AdminApiCmdlet
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
        [ValidateLength(1, 128)]
        [ValidateNotNull]
        public string ResourceGroup { get; set; }

        /// <summary>
        /// Gets or sets the subscription id.
        /// </summary>
        [Parameter(Mandatory = false)]
        [ValidateNotNull]
        [ValidateGuidNotEmpty]
        public Guid SubscriptionId { get; set; }

        /// <summary>
        /// Executes the API call(s) against Azure Resource Management API(s).
        /// </summary>
        protected override object ExecuteCore()
        {
            using (var client = this.GetAzureStackClient(this.SubscriptionId))
            {
                if (string.IsNullOrEmpty(this.Name))
                {
                    this.WriteVerbose(Resources.ListingResourceProviderRegistration);
                    return client.ProviderRegistrations.List(this.ResourceGroup).ProviderRegistrations;
                }
                else
                {
                    this.WriteVerbose(Resources.GettingResourceProviderRegistration.FormatArgs(this.Name));
                    return client.ProviderRegistrations.Get(this.ResourceGroup, this.Name).ProviderRegistration;
                }
            }
        }
    }
}
