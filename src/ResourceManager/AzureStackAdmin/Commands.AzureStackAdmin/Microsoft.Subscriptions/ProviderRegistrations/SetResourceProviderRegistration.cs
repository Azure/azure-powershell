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
    using System.Management.Automation;
    using Microsoft.WindowsAzure.Commands.Common;
    using Microsoft.AzureStack.Management;
    using Microsoft.AzureStack.Management.Models;

    /// <summary>
    /// Set Resource Provider Registration Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Set, Nouns.ResourceProviderRegistration)]
    [OutputType(typeof(ProviderRegistrationModel))]
    public class SetResourceProviderRegistration : AdminApiCmdlet
    {
        /// <summary>
        /// Gets or sets the provider registration.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNull]
        public ProviderRegistrationModel ProviderRegistration { get; set; }

        /// <summary>
        /// Gets or sets the resource group.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateLength(1, 90)]
        [ValidateNotNull]
        public string ResourceGroup { get; set; }


        /// <summary>
        /// Executes the API call(s) against Azure Resource Management API(s).
        /// </summary>
        protected override object ExecuteCore()
        {
            using (var client = this.GetAzureStackClient())
            {
                var parameters = new ProviderRegistrationCreateOrUpdateParameters()
                    {
                        ProviderRegistration = this.ProviderRegistration
                    };  

                this.WriteVerbose(Resources.AddingResourceProviderRegistration.FormatArgs(parameters.ProviderRegistration.Properties.DisplayName));

                this.ValidatePrerequisites(client, parameters);

                return client.ProviderRegistrations
                    .CreateOrUpdate(this.ResourceGroup, parameters)
                    .ProviderRegistration;
            }
        }

        /// <summary>
        /// Validates the prerequisites.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="parameters">The parameters.</param>
        protected virtual void ValidatePrerequisites(AzureStackClient client, ProviderRegistrationCreateOrUpdateParameters parameters)
        {
            ArgumentValidator.ValidateNotNull("client", client);
            ArgumentValidator.ValidateNotNull("parameters", parameters);

            if (!client.ResourceGroups.List().ResourceGroups.Any(r => string.Equals(r.Name, this.ResourceGroup, StringComparison.OrdinalIgnoreCase)))
            {
                throw new PSInvalidOperationException(Resources.ResourceGroupDoesNotExist.FormatArgs(this.ResourceGroup));
            }

            var providerNamespace = parameters.ProviderRegistration.Properties.Namespace;
            var location = parameters.ProviderRegistration.Properties.ProviderLocation;

            if (!client.ProviderRegistrations.List(this.ResourceGroup).ProviderRegistrations
                .Any(p =>
                    string.Equals(p.Properties.Namespace, providerNamespace, StringComparison.OrdinalIgnoreCase)
                    && string.Equals(p.Properties.ProviderLocation, location, StringComparison.OrdinalIgnoreCase)))
            {
                throw new PSInvalidOperationException(Resources.ProviderRegistrationDoesNotExist.FormatArgs(providerNamespace, location));
            }
        }
    }
}
