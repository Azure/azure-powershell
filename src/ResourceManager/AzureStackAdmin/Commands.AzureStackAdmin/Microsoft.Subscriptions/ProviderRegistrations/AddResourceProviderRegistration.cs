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
    [Cmdlet(VerbsCommon.Add, Nouns.ResourceProviderRegistration, DefaultParameterSetName = "MultipleExtensions")]
    [OutputType(typeof(ProviderRegistrationModel))]
    public class AddResourceProviderRegistration : AdminApiCmdlet
    {
        /// <summary>
        /// Gets or sets the namespace of the resource provider.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateLength(1, 128)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the namespace of the resource provider.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateLength(1, 128)]
        [ValidateNotNullOrEmpty]
        public string Namespace { get; set; }

        /// <summary>
        /// Gets or sets the resource group.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateLength(1, 90)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroup { get; set; }

        // TODO - use API to get ARM location. BUG 8349643
        /// <summary>
        /// Gets or sets the resource manager location.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string ArmLocation { get; set; }

        /// <summary>
        /// Gets or sets the routing resource manager type.
        /// </summary>
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public ResourceManagerType? ResourceManagerType { get; set; }

        /// <summary>
        /// Gets or sets the resource provider registration display name.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateLength(1, 128)]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the subscription id.
        /// </summary>
        [Parameter(Mandatory = false)]
        [ValidateGuidNotEmpty]
        public Guid SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the resource provider registration location (region).
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string ProviderLocation { get; set; }

        /// <summary>
        /// Optional. Gets or sets the name of the extension.
        /// </summary>
        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = "SingleExtension")]
        public string ExtensionName { get; set; }

        /// <summary>
        /// Gets or sets the extension endpoint.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "SingleExtension")]
        [ValidateAbsoluteUri]
        [ValidateNotNullOrEmpty]
        public Uri ExtensionUri { get; set; }

        /// <summary>
        /// Gets or sets the extensions json string.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "MultipleExtensions")]
        [ValidateNotNullOrEmpty]
        public string Extensions { get; set; }

        /// <summary>
        /// Gets or sets the resource type json string.
        /// </summary>
        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true)]
        public string ResourceTypes { get; set; }

        /// <summary>
        /// Executes the API call(s) against Azure Resource Management API(s).
        /// </summary>
        protected override object ExecuteCore()
        {
            using (var client = this.GetAzureStackClient(this.SubscriptionId))
            {
                ProviderRegistrationCreateOrUpdateParameters registrationParams = null;
                if( this.ParameterSetName.Equals("SingleExtension", StringComparison.OrdinalIgnoreCase) )
                { 
                    registrationParams = new ProviderRegistrationCreateOrUpdateParameters()
                    {
                        ProviderRegistration = new ProviderRegistrationModel()
                        {
                            Name = this.Name,
                            Location = this.ArmLocation,
                            Properties = new ManifestPropertiesDefinition()
                            {
                                DisplayName = this.DisplayName,
                                Namespace = this.Namespace,
                                // Note: The default value is set to Admin ARM to have backward compatibility with existing deployment scripts
                                // The default value will get changed to User ARM in future.
                                RoutingResourceManagerType = this.ResourceManagerType,
                                Enabled = true,
                                ProviderLocation = this.ProviderLocation,
                                ExtensionName = this.ExtensionName,
                                ExtensionUri = (this.ExtensionUri == null) ? null : this.ExtensionUri.AbsoluteUri,
                                ResourceTypes = this.ResourceTypes.FromJson<List<ResourceType>>()
                            }
                        }
                    };
                }
                else
                {
                    registrationParams = new ProviderRegistrationCreateOrUpdateParameters()
                    {
                        ProviderRegistration = new ProviderRegistrationModel()
                        {
                            Name = this.Name,
                            Location = this.ArmLocation,
                            Properties = new ManifestPropertiesDefinition()
                            {
                                DisplayName = this.DisplayName,
                                Namespace = this.Namespace,
                                // Note: The default value is set to Admin ARM to have backward compatibility with existing deployment scripts
                                // The default value will get changed to User ARM in future.
                                RoutingResourceManagerType = this.ResourceManagerType,
                                Enabled = true,
                                ProviderLocation = this.ProviderLocation,
                                Extensions = (this.Extensions == null) ? null : this.Extensions.FromJson<List<Extension>>(),
                                ResourceTypes = this.ResourceTypes.FromJson<List<ResourceType>>()
                            }
                        }
                    };
                }
                
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
