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
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;

    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.ResourceManager;
    using Microsoft.Azure.Management.ResourceManager.Models;

    /// <summary>
    /// Get an existing resource.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmPolicyAliases"), OutputType(typeof(PsResourceProviderAlias))]
    [Alias("Get-AzureRmPolicyAliases")]
    public class GetAzurePolicyAliases : ResourceManagerCmdletBase
    {
        /// <summary>
        /// Gets or sets the provider namespace match string
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "The namespace match value.")]
        [Alias("Name", "Namespace")]
        [ValidateNotNullOrEmpty]
        public string NamespaceMatch { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the resource type match string
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "The resource type match value.")]
        [Alias("ResourceType", "Resource")]
        [ValidateNotNullOrEmpty]
        public string ResourceTypeMatch { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the alias match string
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "The alias match value.")]
        [Alias("Alias")]
        [ValidateNotNullOrEmpty]
        public string AliasMatch { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the alias path match string
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "The alias path match value.")]
        [Alias("Path")]
        [ValidateNotNullOrEmpty]
        public string PathMatch { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the api version match string
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "The alias api version match value.")]
        [ValidateNotNullOrEmpty]
        public string ApiVersionMatch { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the alias match string
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "The location match value.")]
        [Alias("Location")]
        [ValidateNotNullOrEmpty]
        [LocationCompleter("Microsoft.Resources/resourceGroups")]
        public string LocationMatch { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets list available flag
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "Switch that causes output to include resource types with no aliases.")]
        [Alias("ShowAll")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter ListAvailable { get; set; }

        /// <summary>
        /// Gets or sets the resource provider input collection (e.g. from Get-AzureRmResourceProvider)
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, ValueFromPipeline = true, HelpMessage = "Set of resource providers to examine.")]
        [ValidateNotNullOrEmpty]
        public PSResourceProvider[] InputObject { get; set; }

        /// <summary>
        /// Executes the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            // remove leading and trailing whitespace
            this.NamespaceMatch = this.NamespaceMatch?.Trim() ?? string.Empty;
            this.ResourceTypeMatch = this.ResourceTypeMatch?.Trim() ?? string.Empty;
            this.AliasMatch = this.AliasMatch?.Trim() ?? string.Empty;
            this.PathMatch = this.PathMatch?.Trim() ?? String.Empty;
            this.ApiVersionMatch = this.ApiVersionMatch?.Trim() ?? string.Empty;
            this.LocationMatch = this.LocationMatch?.Trim() ?? string.Empty;

            var resourceTypes = this.GetProviderResourceTypes(this.ListAvailable, this.NamespaceMatch, this.ResourceTypeMatch, this.AliasMatch, this.PathMatch, this.ApiVersionMatch, this.LocationMatch);
            this.WriteObject(resourceTypes, enumerateCollection: true);
        }

        private bool IsMatch(string input, string match)
        {
            return input.IndexOf(match, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private IEnumerable<Provider> GetAllProviders()
        {
            return this.ResourceManagerSdkClient.ResourceManagementClient.Providers.List(expand: "resourceTypes/aliases");
        }

        private IEnumerable<Provider> GetProviders(IEnumerable<Provider> input, string namespaceMatch)
        {
            // Filter the list of all operation names to what matches the wildcard
            return input.Where(item => string.IsNullOrEmpty(namespaceMatch) || this.IsMatch(item.NamespaceProperty, namespaceMatch));
        }

        private IEnumerable<Provider> GetProviders(IEnumerable<Provider> inputEnumerable, IEnumerable<string> namespaceMatches)
        {
            // Filter the list of all operation names to what matches the wildcard
            var input = inputEnumerable.ToList();
            foreach (var match in namespaceMatches)
            {
                yield return input.First(item => this.IsMatch(item.NamespaceProperty, match));
            }
        }

        private bool FilterFunction(ProviderResourceType providerResourceType, bool listAvailable, string resourceTypesMatch, string aliasMatch, string pathMatch, string apiVersionMatch, string locationMatch)
        {
            return
                // include everything if list available switch is provided
                listAvailable ||

                // otherwise perform full matching logic
                providerResourceType.Aliases.Coalesce().Any() &&

                // if no match strings provided, match everything
                (string.IsNullOrEmpty(resourceTypesMatch) && string.IsNullOrEmpty(locationMatch) && string.IsNullOrEmpty(aliasMatch) && string.IsNullOrEmpty(pathMatch) && string.IsNullOrEmpty(apiVersionMatch) ||

                 // if resource type match was provided, match resource type
                 !string.IsNullOrEmpty(resourceTypesMatch) && this.IsMatch(providerResourceType.ResourceType, resourceTypesMatch) ||

                 // if location match was provided, match location
                 !string.IsNullOrEmpty(locationMatch) && providerResourceType.Locations.Coalesce().Any(l => this.IsMatch(l, locationMatch)) ||

                 // if API match was provided, match resource type API version
                 !string.IsNullOrEmpty(apiVersionMatch) && providerResourceType.ApiVersions.Coalesce().Any(v => this.IsMatch(v, apiVersionMatch)) ||

                 // if alias match was provided, match alias name
                 !string.IsNullOrEmpty(aliasMatch) && providerResourceType.Aliases.Coalesce().Any(a => this.IsMatch(a.Name, aliasMatch)) ||

                 // if alias path match was provided, match alias name
                 !string.IsNullOrEmpty(pathMatch) && providerResourceType.Aliases.Coalesce().Any(a => a.Paths.Any(p => this.IsMatch(p.Path, pathMatch))) ||

                 // if API version match was provided, match resource type API version or alias API version
                 !string.IsNullOrEmpty(apiVersionMatch) && providerResourceType.Aliases.Coalesce().Any(a => a.Paths.Coalesce().Any(p => p.ApiVersions.Coalesce().Any(v => this.IsMatch(v, apiVersionMatch)))));
        }

        private IEnumerable<PsResourceProviderAlias> GetProviderResourceTypes(bool listAvailable, string namespaceMatch, string resourceTypeMatch, string aliasMatch, string pathMatch, string apiVersionMatch, string locationMatch)
        {
            var allProviders = this.GetProviders(this.GetAllProviders(), namespaceMatch);
            var rv = new List<PsResourceProviderAlias>();
            var providers = this.InputObject == null ? this.GetProviders(allProviders, namespaceMatch) : this.GetProviders(allProviders, this.InputObject.Select(o => o.ProviderNamespace));
            foreach (var provider in providers)
            {
                var match = provider.ResourceTypes.Where(r => this.FilterFunction(r, listAvailable, resourceTypeMatch, aliasMatch, pathMatch, apiVersionMatch, locationMatch));
                rv.AddRange(match.Select(t => new PsResourceProviderAlias {Aliases = t.Aliases, ApiVersions = t.ApiVersions, Locations = t.Locations, Namespace = provider.NamespaceProperty, ResourceType = t.ResourceType}));
            }

            return rv;
        }
    }
}