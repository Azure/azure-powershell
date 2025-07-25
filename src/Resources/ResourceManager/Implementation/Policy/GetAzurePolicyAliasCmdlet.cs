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
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.ResourceManager;
    using Microsoft.Azure.Management.ResourceManager.Models;

    /// <summary>
    /// Get an existing resource.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, AzureRMConstants.AzureRMPrefix + "PolicyAlias"), OutputType(typeof(PsResourceProviderAlias))]
    public class GetAzurePolicyAlias : ResourceManagerCmdletBaseWithApiVersion
    {
        /// <summary>
        /// Gets or sets the provider namespace match string
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "Limits the output to items whose namespace matches this value.")]
        [Alias("Name", "Namespace")]
        [ValidateNotNullOrEmpty]
        public string NamespaceMatch { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the resource type match string
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "Limits the output to items whose resource type matches this value.")]
        [Alias("ResourceType", "Resource")]
        [ValidateNotNullOrEmpty]
        public string ResourceTypeMatch { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the alias match string
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "Includes in the output items with aliases whose name matches this value.")]
        [Alias("Alias")]
        [ValidateNotNullOrEmpty]
        public string AliasMatch { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the alias path match string
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "Includes in the output items with aliases containing a path that matches this value.")]
        [Alias("Path")]
        [ValidateNotNullOrEmpty]
        public string PathMatch { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the api version match string
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "Includes in the output items whose resource types or aliases have a matching api version.")]
        [ValidateNotNullOrEmpty]
        public string ApiVersionMatch { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the alias match string
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "Includes in the output items whose resource types have a matching location.")]
        [Alias("Location")]
        [ValidateNotNullOrEmpty]
        [LocationCompleter("Microsoft.Resources/resourceGroups")]
        public string LocationMatch { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets list available flag
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = false, HelpMessage = "Includes in the output matching items with and without aliases.")]
        [Alias("ShowAll")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter ListAvailable { get; set; }

        /// <summary>
        /// Executes the cmdlet
        /// </summary>
        protected override void OnProcessRecord()
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

        private bool IsStringMatch(string input, string match)
        {
            return input.IndexOf(match, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private bool IsMatch(string input, string match)
        {
            return string.IsNullOrEmpty(match) || this.IsStringMatch(input, match);
        }

        private IEnumerable<Provider> GetProvider(string namespaceMatch)
        {
            try
            {
                var tempResult = this.ResourceManagerSdkClient.ResourceManagementClient.Providers.GetAtTenantScope(resourceProviderNamespace: namespaceMatch, expand: "resourceTypes/aliases");
                return Enumerable.Repeat(tempResult, 1);
            }
            catch (Exception)
            {
            }

            return Enumerable.Empty<Provider>();
        }

        private IEnumerable<Provider> GetAllProviders()
        {
            var returnList = new List<Provider>();
            var tempResult = this.ResourceManagerSdkClient.ResourceManagementClient.Providers.ListAtTenantScope(expand: "resourceTypes/aliases");
            returnList.AddRange(tempResult);

            while (!string.IsNullOrWhiteSpace(tempResult.NextPageLink))
            {
                tempResult = this.ResourceManagerSdkClient.ResourceManagementClient.Providers.ListAtTenantScopeNext(tempResult.NextPageLink);
                returnList.AddRange(tempResult);
            }

            return returnList;
        }

        private IEnumerable<Provider> GetMatchingProviders(IEnumerable<Provider> input, string namespaceMatch, string resourceTypeMatch)
        {
            // Filter the list of all providers to what matches on namespace and resource type
            return input.Where(item => this.IsMatch(item.NamespaceProperty, namespaceMatch) && item.ResourceTypes.Any(r => IsMatch(r.ResourceType, resourceTypeMatch)));
        }

        private bool FilterFunction(ProviderResourceType providerResourceType, bool listAvailable, string resourceTypesMatch, string aliasMatch, string pathMatch, string apiVersionMatch, string locationMatch)
        {
            return
                // if resource type match was provided, the resource type name must match
                (string.IsNullOrEmpty(resourceTypesMatch) || this.IsStringMatch(providerResourceType.ResourceType, resourceTypesMatch)) &&

                // include everything remaining if list available switch is provided
                (listAvailable ||

                 // otherwise just those with aliases that match the rest of the parameters
                 providerResourceType.Aliases.Coalesce().Any() &&

                 // if no match strings provided, include everything
                 (string.IsNullOrEmpty(locationMatch) && string.IsNullOrEmpty(aliasMatch) && string.IsNullOrEmpty(pathMatch) && string.IsNullOrEmpty(apiVersionMatch) ||

                  // if location match was provided, include those with matching location
                  !string.IsNullOrEmpty(locationMatch) && providerResourceType.Locations.Coalesce().Any(l => this.IsStringMatch(l, locationMatch)) ||

                  // if API match was provided, include those with matching resource type API version
                  !string.IsNullOrEmpty(apiVersionMatch) && providerResourceType.ApiVersions.Coalesce().Any(v => this.IsStringMatch(v, apiVersionMatch)) ||

                  // if alias match was provided, include those with matching alias name
                  !string.IsNullOrEmpty(aliasMatch) && providerResourceType.Aliases.Coalesce().Any(a => this.IsStringMatch(a.Name, aliasMatch)) ||

                  // if alias path match was provided, includes those with matching path
                  !string.IsNullOrEmpty(pathMatch) && providerResourceType.Aliases.Coalesce().Any(a => a.Paths.Coalesce().Any(p => this.IsStringMatch(p.Path, pathMatch))) ||

                  // if API version match was provided, also include those with matching alias API version
                  !string.IsNullOrEmpty(apiVersionMatch) && providerResourceType.Aliases.Coalesce().Any(a => a.Paths.Coalesce().Any(p => p.ApiVersions.Coalesce().Any(v => this.IsStringMatch(v, apiVersionMatch))))));
        }

        private IEnumerable<PsResourceProviderAlias> GetProviderResourceTypes(bool listAvailable, string namespaceMatch, string resourceTypeMatch, string aliasMatch, string pathMatch, string apiVersionMatch, string locationMatch)
        {
            IEnumerable<Provider> providers = Enumerable.Empty<Provider>();
            if (!string.IsNullOrEmpty(NamespaceMatch))
            {
                providers = this.GetProvider(namespaceMatch);
            }
            if (!providers.Any())
            {
                providers = this.GetAllProviders();
            }

            var matchingProviders = this.GetMatchingProviders(providers, namespaceMatch, resourceTypeMatch);
            var rv = new List<PsResourceProviderAlias>();
            foreach (var provider in matchingProviders)
            {
                var match = provider.ResourceTypes.Where(r => this.FilterFunction(r, listAvailable, resourceTypeMatch, aliasMatch, pathMatch, apiVersionMatch, locationMatch));
                rv.AddRange(match.Select(t => new PsResourceProviderAlias { Aliases = t.Aliases, ApiVersions = t.ApiVersions, Locations = t.Locations, Namespace = provider.NamespaceProperty, ResourceType = t.ResourceType }));
            }

            return rv;
        }
    }
}