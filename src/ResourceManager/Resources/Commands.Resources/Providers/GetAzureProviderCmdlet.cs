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

namespace Microsoft.Azure.Commands.Providers
{
    using System;
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Resources.Models;

    /// <summary>
    /// Get an existing resource.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmResourceProvider", DefaultParameterSetName = GetAzureProviderCmdlet.ListAvailableParameterSet), OutputType(typeof(PSResourceProvider))]
    public class GetAzureProviderCmdlet : ResourcesBaseCmdlet
    {
        /// <summary>
        /// The individual provider parameter set name
        /// </summary>
        public const string IndividualProviderParameterSet = "IndividualProvider";

        /// <summary>
        /// The list parameter set name
        /// </summary>
        public  const string ListAvailableParameterSet = "ListAvailable";

        /// <summary>
        /// Gets or sets the provider namespace
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource provider namespace.", ParameterSetName = GetAzureProviderCmdlet.IndividualProviderParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ProviderNamespace { get; set; }

        /// <summary>
        /// Gets or sets the provider namespace
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "The location to look for provider namespace.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if unregistered providers should be included in the listing
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "When specified, lists all the resource providers available, including those not registered with the current subscription.", ParameterSetName = GetAzureProviderCmdlet.ListAvailableParameterSet)]
        public SwitchParameter ListAvailable { get; set; }

        /// <summary>
        /// Executes the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            WriteWarning("The output object type of this cmdlet will be modified in a future release.");
            var providers = this.ResourcesClient.ListPSResourceProviders(providerName: this.ProviderNamespace, listAvailable: this.ListAvailable, location: this.Location);

            if (!string.IsNullOrEmpty(this.ProviderNamespace))
            {
                var expandedProviders = providers
                    .SelectMany(provider =>
                        provider.ResourceTypes
                            .Select(type =>
                                new PSResourceProvider
                                {
                                    ProviderNamespace = provider.ProviderNamespace,
                                    RegistrationState = provider.RegistrationState,
                                    ResourceTypes = new[]
                                    {
                                        new PSResourceProviderResourceType
                                        {
                                            ResourceTypeName = type.ResourceTypeName,
                                            Locations = type.Locations,
                                            ApiVersions = type.ApiVersions,
                                        }
                                    }
                                }));

                this.WriteObject(expandedProviders, enumerateCollection: true);
            }
            else
            {
                this.WriteObject(providers, enumerateCollection: true);
            }
        }
    }
}