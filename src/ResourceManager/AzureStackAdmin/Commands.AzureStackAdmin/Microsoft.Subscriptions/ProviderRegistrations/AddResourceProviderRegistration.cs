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
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.AzureStack.Commands.Common;
    using Microsoft.AzureStack.Management;
    using Microsoft.AzureStack.Management.Models;
    using Microsoft.WindowsAzure.Commands.Common;

    /// <summary>
    /// Add Resource Provider Registration Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Add, Nouns.ResourceProviderRegistration)]
    [OutputType(typeof(ProviderRegistrationModel))]
    public class AddResourceProviderRegistration : AdminApiCmdlet
    {
        /// <summary>
        /// Gets or sets the namespace of the resource provider.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateLength(1, 128)]
        [ValidateNotNull]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the namespace of the resource provider.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateLength(1, 128)]
        [ValidateNotNull]
        public string Namespace { get; set; }

        /// <summary>
        /// Gets or sets the resource group.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateLength(1, 90)]
        [ValidateNotNull]
        public string ResourceGroup { get; set; }

        // TODO - use API to get CSM location?
        /// <summary>
        /// Gets or sets the resource manager location.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNull]
        public string ArmLocation { get; set; }

        /// <summary>
        /// Gets or sets the resource provider registration display name.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateLength(1, 128)]
        [ValidateNotNull]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the subscription id.
        /// </summary>
        [Parameter(Mandatory = false)]
        [ValidateNotNull]
        [ValidateGuidNotEmpty]
        public Guid SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the resource provider registration location (region).
        /// </summary>
        [Parameter(Mandatory = true)]
        [Parameter(Mandatory = true)]
        [ValidateNotNull]
        public string ProviderLocation { get; set; }

        /// <summary>
        /// Optional. Gets or sets the name of the extension.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNull]
        public string ExtensionName { get; set; }

        /// <summary>
        /// Gets or sets the extension endpoint.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateAbsoluteUri]
        [ValidateNotNull]
        public Uri ExtensionUri { get; set; }

        /// <summary>
        /// Gets or sets the resource type json string.
        /// </summary>
        [ValidateNotNull]
        [Parameter(Mandatory = true)]
        public string ResourceTypes { get; set; }

        /// <summary>
        /// Executes the API call(s) against Azure Resource Management API(s).
        /// </summary>
        protected override object ExecuteCore()
        {
            using (var client = this.GetAzureStackClient(this.SubscriptionId))
            {
                ArgumentValidator.ValidateJson("ResourceTypes", this.ResourceTypes);
                var registrationParams = new ProviderRegistrationCreateOrUpdateParameters()
                {
                    ProviderRegistration = new ProviderRegistrationModel()
                    {
                        Name = this.Name,
                        Location = this.ArmLocation,
                        Properties = new ManifestPropertiesDefinition()
                        {
                            DisplayName = this.DisplayName,
                            Namespace = this.Namespace,
                            Enabled = true,
                            ProviderLocation = this.ProviderLocation,
                            ExtensionName = this.ExtensionName,
                            ExtensionUri = this.ExtensionUri.AbsoluteUri,
                            ResourceTypes = this.ResourceTypes.FromJson<List<ResourceType>>()
                        }
                    }
                };
                
                this.WriteVerbose(Resources.AddingResourceProviderRegistration.FormatArgs(registrationParams.ProviderRegistration.Properties.DisplayName));

                this.ValidatePrerequisites(client, registrationParams);

                return client.ProviderRegistrations
                    .CreateOrUpdate(this.ResourceGroup, registrationParams)
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
        }
    }
}
