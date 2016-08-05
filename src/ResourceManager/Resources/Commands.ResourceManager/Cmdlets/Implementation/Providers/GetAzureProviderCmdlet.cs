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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    using System;
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkExtensions;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
    using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;

    /// <summary>
    /// Get an existing resource.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmResourceProvider", DefaultParameterSetName = GetAzureProviderCmdlet.ListAvailableParameterSet), OutputType(typeof(PSResourceProvider))]
    public class GetAzureProviderCmdlet : ResourceManagerCmdletBase
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
            var providers = this.ListPSResourceProviders();

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
                                            ZoneMappings = type.ZoneMappings
                                        }
                                    },
                                    ZoneMappings = type.ZoneMappings
                                }));

                this.WriteObject(expandedProviders, enumerateCollection: true);
            }
            else
            {
                this.WriteObject(providers, enumerateCollection: true);
            }
        }

        private PSResourceProvider[] ListPSResourceProviders()
        {
            var allProviders = this.ResourceManagerSdkClient.ListResourceProviders(
                providerName: null,
                listAvailable: true);

            var providers = allProviders;
            if (!string.IsNullOrEmpty(this.ProviderNamespace))
            {
                providers = this.ResourceManagerSdkClient.ListResourceProviders(providerName: this.ProviderNamespace);
            }
            else if (this.ListAvailable == false)
            {
                providers = this.ResourceManagerSdkClient.GetRegisteredProviders(providers);
            }

            if (string.IsNullOrEmpty(this.Location))
            {
                return providers
                    .Select(provider => provider.ToPSResourceProvider())
                    .ToArray();
            }

            var allRPLocations = allProviders
                .SelectMany(provider => provider.ResourceTypes.CoalesceEnumerable().SelectMany(type => type.Locations))
                .Distinct(StringComparer.InvariantCultureIgnoreCase);

            var validLocations = this
                .SubscriptionSdkClient
                .ListLocations(DefaultContext.Subscription.Id.ToString())
                .Select(location => location.DisplayName)
                .Concat(allRPLocations)
                .Distinct(StringComparer.InvariantCultureIgnoreCase);

            if (!validLocations.Any(loc => loc.EqualsAsLocation(this.Location)))
            {
                this.WriteErrorWithTimestamp(ProjectResources.InvalidLocation);
                return new PSResourceProvider[] { };
            }

            foreach (var provider in providers)
            {
                provider.ResourceTypes = provider.ResourceTypes
                    .Where(type => !type.Locations.Any() || type.Locations.Any(loc => loc.EqualsAsLocation(this.Location)))
                    .ToList();
            }

            return providers
                .Where(provider => provider.ResourceTypes.Any())
                .Select(provider => provider.ToPSResourceProvider())
                .ToArray();
        }
    }
}