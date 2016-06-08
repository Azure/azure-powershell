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
    /// Resource Provider Registration Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Set, Nouns.ResourceProviderRegistration, DefaultParameterSetName = CommonPSConst.ParameterSet.ByProperty)]
    [OutputType(typeof(ProviderRegistrationModel))]
    public class SetResourceProviderRegistration : AdminApiCmdlet
    {
        /// <summary>
        /// Gets or sets the provider registration.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = CommonPSConst.ParameterSet.ByObject)]
        [ValidateNotNull]
        public ProviderRegistrationModel ProviderRegistration { get; set; }

        /// <summary>
        /// Gets or sets the resource manager location.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNull]
        public string ArmLocation { get; set; } // TODO - use API to get CSM location?

        /// <summary>
        /// Gets or sets the resource provider registration name.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = CommonPSConst.ParameterSet.ByProperty)]
        [ValidateLength(1, 128)]
        [ValidateNotNull]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the resource group.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = CommonPSConst.ParameterSet.ByProperty)]
        [ValidateLength(1, 128)]
        [ValidateNotNull]
        public string ResourceGroup { get; set; }

        /// <summary>
        /// Gets or sets the subscription id.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = CommonPSConst.ParameterSet.ByProperty)]
        [ValidateNotNull]
        [ValidateGuidNotEmpty]
        public Guid SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the resource provider registration display name.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = CommonPSConst.ParameterSet.ByProperty)]
        [ValidateLength(1, 128)]
        [ValidateNotNull]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the resource provider registration location (region).
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = CommonPSConst.ParameterSet.ByProperty)]
        [ValidateNotNull]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the resource provider registration manifest endpoint.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = CommonPSConst.ParameterSet.ByProperty)]
        [ValidateAbsoluteUri]
        [ValidateNotNull]
        public Uri ManifestEndpoint { get; set; }

        /// <summary>
        /// Gets or sets the resource provider registration user name.
        /// </summary>
        [Parameter(ParameterSetName = CommonPSConst.ParameterSet.ByProperty)]
        [ValidateNotNull]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the resource provider registration password.
        /// </summary>
        [Parameter(ParameterSetName = CommonPSConst.ParameterSet.ByProperty)]
        [ValidateNotNull]
        public string Password { get; set; }

        /// <summary>
        /// Executes the API call(s) against Azure Resource Management API(s).
        /// </summary>
        protected override object ExecuteCore()
        {
            using (var client = this.GetAzureStackClient(this.SubscriptionId))
            {
                var parameters = new ProviderRegistrationCreateOrUpdateParameters()
                {
                    ProviderRegistration = this.ProviderRegistration ?? new ProviderRegistrationModel()
                    {
                        Name = this.Name,
                        Location = this.ArmLocation,
                        Properties = new ProviderRegistrationDefinition()
                        {
                            Name = this.Name,
                            DisplayName = this.DisplayName,
                            Enabled = true,
                            Location = this.Location,
                            ManifestEndpoint = new ResourceProviderEndpoint()
                            {
                                EndpointUri = this.ManifestEndpoint.AbsoluteUri,
                                AuthenticationUsername = this.UserName,
                                AuthenticationPassword = this.Password,
                            }
                        }
                    }
                };

                this.WriteVerbose(Resources.AddingResourceProviderRegistration.FormatArgs(parameters.ProviderRegistration.Properties.Name));

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

            var name = parameters.ProviderRegistration.Properties.Name;
            var location = parameters.ProviderRegistration.Properties.Location;

            if (!client.ProviderRegistrations.List(this.ResourceGroup).ProviderRegistrations
                .Any(p =>
                    string.Equals(p.Properties.Manifest.Namespace, name, StringComparison.OrdinalIgnoreCase)
                    && string.Equals(p.Properties.Location, location, StringComparison.OrdinalIgnoreCase)))
            {
                throw new PSInvalidOperationException(Resources.ProviderRegistrationDoesNotExist.FormatArgs(name, location));
            }
        }
    }
}
