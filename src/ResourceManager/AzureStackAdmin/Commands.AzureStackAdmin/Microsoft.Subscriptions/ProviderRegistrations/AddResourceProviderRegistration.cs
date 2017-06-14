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

    /// <summary>
    /// Add Resource Provider Manifest Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Add, Nouns.ResourceProviderManifest, DefaultParameterSetName = "MultipleExtensions", SupportsShouldProcess = true)]
    [OutputType(typeof(ProviderRegistrationModel))]
    [Alias("Add-AzureRmResourceProviderRegistration")]
    public class AddResourceProviderManifest : AdminApiCmdlet
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
        [Alias("ResourceGroup")]
        public string ResourceGroupName { get; set; }

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
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ResourceManagerType ResourceManagerType { get; set; }

        /// <summary>
        /// Gets or sets the resource provider registration display name.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateLength(1, 128)]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

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
        /// Gets or sets the resource provider registration display name.
        /// </summary>
        [ValidateNotNullOrEmpty]
        [Parameter]
        public string Signature { get; set; }

        /// <summary>
        /// Executes the API call(s) against Azure Resource Management API(s).
        /// </summary>
        protected override void ExecuteCore()
        {
            if (ShouldProcess(this.Name, VerbsCommon.Add))
            {
                using (var client = this.GetAzureStackClient())
                {
                    if (this.MyInvocation.InvocationName.Equals("Add-AzureRmResourceProviderRegistration",
                        StringComparison.OrdinalIgnoreCase))
                    {
                        this.WriteWarning(
                            "Alias Add-AzureRmResourceProviderRegistration will be deprecated in a future release. Please use the cmdlet Add-AzsResourceProviderManifest instead");
                    }

                    ProviderRegistrationCreateOrUpdateParameters registrationParams = null;
                    // Todo: Remove the parameter sets in the next major release
                    if (this.ParameterSetName.Equals("SingleExtension", StringComparison.OrdinalIgnoreCase))
                    {
                        WriteWarning(
                            "ExtensionName and ExtensionUri parameters will be deprecated in a future release, Use the Extensions parameter to specify the extesnions registration as a json string");
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
                                    RoutingResourceManagerType = this.ResourceManagerType,
                                    Enabled = true,
                                    ProviderLocation = this.ProviderLocation,
                                    // Todo: Remove this HACK, hardcoded versions to have backward compatibility 
                                    ExtensionCollection = new ExtensionCollectionDefinition()
                                    {
                                        Version = "0.1.0.0",
                                        Extensions = new ExtensionDefinition[]
                                        {
                                            new ExtensionDefinition()
                                            {
                                                Name = this.ExtensionName,
                                                Uri = (this.ExtensionUri == null) ? null : this.ExtensionUri.AbsoluteUri
                                            }
                                        }
                                    },
                                    ResourceTypes = this.ResourceTypes.FromJson<List<ResourceType>>(),
                                    Signature = this.Signature
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
                                    ExtensionCollection =
                                        (this.Extensions == null)
                                            ? null
                                            : this.Extensions.FromJson<ExtensionCollectionDefinition>(),
                                    ResourceTypes = this.ResourceTypes.FromJson<List<ResourceType>>(),
                                    Signature = this.Signature
                                }
                            }
                        };
                    }

                    this.WriteVerbose(
                        Resources.AddingResourceProviderManifest.FormatArgs(
                            registrationParams.ProviderRegistration.Properties.DisplayName));

                    this.ValidatePrerequisites(client, registrationParams);

                    var result = client.ProviderRegistrations
                        .CreateOrUpdate(this.ResourceGroupName, registrationParams)
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
        }
    }
}
