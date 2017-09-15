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
    /// Set Resource Provider Manifest Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Set, Nouns.ResourceProviderManifest, SupportsShouldProcess = true)]
    [OutputType(typeof(ProviderRegistrationModel))]
    [Alias("Set-AzureRmResourceProviderRegistration")]
    public class SetResourceProviderManifest : AdminApiCmdlet
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
        [Alias("ResourceGroup")]
        public string ResourceGroupName { get; set; }


        /// <summary>
        /// Executes the API call(s) against Azure Resource Management API(s).
        /// </summary>
        protected override void ExecuteCore()
        {
            if (this.MyInvocation.InvocationName.Equals("Set-AzureRmResourceProviderRegistration", StringComparison.OrdinalIgnoreCase))
            {
                this.WriteWarning("Alias Set-AzureRmResourceProviderRegistration will be deprecated in a future release. Please use the cmdlet Set-AzsResourceProviderManifest instead");
            }

            if (ShouldProcess(this.ProviderRegistration.Name, VerbsCommon.Set))
            {
                using (var client = this.GetAzureStackClient())
                {
                    var parameters = new ProviderRegistrationCreateOrUpdateParameters()
                    {
                        ProviderRegistration = this.ProviderRegistration
                    };

                    this.WriteVerbose(
                        Resources.AddingResourceProviderManifest.FormatArgs(
                            parameters.ProviderRegistration.Properties.DisplayName));

                    this.ValidatePrerequisites(client, parameters);

                    var result = client.ProviderRegistrations
                        .CreateOrUpdate(this.ResourceGroupName, parameters)
                        .ProviderRegistration;
                    WriteObject(result);
                }
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

            if (!client.ResourceGroups.List().ResourceGroups.Any(r => string.Equals(r.Name, this.ResourceGroupName, StringComparison.OrdinalIgnoreCase)))
            {
                throw new PSInvalidOperationException(Resources.ResourceGroupDoesNotExist.FormatArgs(this.ResourceGroupName));
            }

            var providerNamespace = parameters.ProviderRegistration.Properties.Namespace;
            var location = parameters.ProviderRegistration.Properties.ProviderLocation;

            if (!client.ProviderRegistrations.List(this.ResourceGroupName).ProviderRegistrations
                .Any(p =>
                    string.Equals(p.Properties.Namespace, providerNamespace, StringComparison.OrdinalIgnoreCase)
                    && string.Equals(p.Properties.ProviderLocation, location, StringComparison.OrdinalIgnoreCase)))
            {
                throw new PSInvalidOperationException(Resources.ProviderRegistrationDoesNotExist.FormatArgs(providerNamespace, location));
            }
        }
    }
}
