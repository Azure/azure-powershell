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

namespace Microsoft.Azure.Commands.Resources
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Resources.Models;

    /// <summary>
    /// Get an existing resource.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureSecurableAction"), OutputType(typeof(PSResourceProviderOperation))]
    public class GetAzureSecurableActionCommand : ResourcesBaseCmdlet
    {
        /// <summary>
        /// A string that indicates the value of the resource type name for the RP's operations api
        /// </summary>
        private const string Operations = "operations";

        private const string WildCardCharacter = "*";

        /// <summary>
        /// Gets or sets the provider namespace
        /// </summary>
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = false, ValueFromPipeline = true, HelpMessage = "The action string.")]
        [ValidateNotNullOrEmpty]
        public string ActionString { get; set; }

        /// <summary>
        /// Executes the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            List<PSResourceProviderOperation> operationsToDisplay;
            Dictionary<string, string> resourceProvidersWithOperationsApi = this.GetResourceProvidersWithOperationsSupport();

            if (this.ActionString.Contains(WildCardCharacter))
            {
                operationsToDisplay = this.ProcessProviderOperationsWithWildCard(ActionString, resourceProvidersWithOperationsApi);
            }
            else
            {
                operationsToDisplay = this.ProcessProviderOperationsWithoutWildCard(ActionString, resourceProvidersWithOperationsApi);
            }

            this.WriteObject(operationsToDisplay, enumerateCollection: true);
        }

        /// <summary>
        /// Get a mapping of Resource providers that support the operations API (/operations) to the operations api-version supported for that RP 
        /// (Current logic is to sort the 'api-versions' list and choose the max value to store)
        /// </summary>
        private Dictionary<string, string> GetResourceProvidersWithOperationsSupport()
        {
            PSResourceProvider[] allProviders = this.ResourcesClient.ListPSResourceProviders(listAvailable: true);

            Dictionary<string, string> providersSupportingOperations = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
            PSResourceProviderResourceType[] providerResourceTypes = null;

            foreach (PSResourceProvider provider in allProviders)
            {
                providerResourceTypes = provider.ResourceTypes;
                if (providerResourceTypes != null && providerResourceTypes.Any())
                {
                    PSResourceProviderResourceType operationsResourceType = providerResourceTypes.Where(r => r != null && r.ResourceTypeName == GetAzureSecurableActionCommand.Operations).FirstOrDefault();
                    if (operationsResourceType != null &&
                        operationsResourceType.ApiVersions != null &&
                        operationsResourceType.ApiVersions.Any())
                    {
                        providersSupportingOperations.Add(provider.ProviderNamespace, operationsResourceType.ApiVersions.OrderBy(o => o).Last());
                    }
                }
            }

            return providersSupportingOperations;
        }

        /// <summary>
        /// Get a list of Provider operations in the case that the Actionstring input contains a wildcard
        /// </summary>
        private List<PSResourceProviderOperation> ProcessProviderOperationsWithWildCard(string actionString, Dictionary<string, string> resourceProvidersWithOperationsApi)
        {
            Dictionary<string, string> resourceProvidersToQuery = GetAzureSecurableActionCommand.FilterResourceProvidersToQueryForOperations(actionString, resourceProvidersWithOperationsApi);
            
            // Filter the list of all operation names to what matches the wildcard
            WildcardPattern wildcard = new WildcardPattern(actionString, WildcardOptions.IgnoreCase | WildcardOptions.Compiled);

            IList<ResourceIdentity> resourceidentities = new List<ResourceIdentity>();
            foreach (KeyValuePair<string, string> kvp in resourceProvidersToQuery)
            {
                ResourceIdentity identity = new ResourceIdentity()
                {
                    ResourceName = string.Empty,
                    ResourceType = "operations",
                    ResourceProviderNamespace = kvp.Key,
                    ResourceProviderApiVersion = kvp.Value
                };

                resourceidentities.Add(identity);
            }

            return this.ResourcesClient.ListPSProviderOperations(resourceidentities).Where(operation => wildcard.IsMatch(operation.OperationName)).ToList();
        }

        /// <summary>
        /// Filters the list of resource providers that support operations api to return a list of those providers that match the action string input
        /// </summary>
        private static Dictionary<string, string> FilterResourceProvidersToQueryForOperations(string actionString, Dictionary<string, string> resourceProvidersWithOperationsApi)
        {
            Dictionary<string, string> resourceProvidersToQuery = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
             
            string nonWildCardPrefix = GetAzureSecurableActionCommand.GetNonWildcardPrefix(actionString);

            if (string.IsNullOrWhiteSpace(nonWildCardPrefix))
            {
                // 'Get-AzureSecurableAction *' or 'Get-AzureSecurableAction */virtualmachines/*'
                resourceProvidersToQuery = resourceProvidersWithOperationsApi;
            }
            else
            {
                // Some string exists before the wild card character - potentially the full name of the provider.
                string providerFullName = GetAzureSecurableActionCommand.GetResourceProviderFullName(nonWildCardPrefix);

                if (!string.IsNullOrWhiteSpace(providerFullName))
                {
                    string apiVersion;
                    if (resourceProvidersWithOperationsApi.TryGetValue(providerFullName, out apiVersion))
                    {
                        // We have the full name of the provider and it supports the operations api - so it can be queried
                        resourceProvidersToQuery.Add(providerFullName, apiVersion);
                    }
                }
                else
                {
                    // We have only a partial name of the provider, say Microsoft.*/* or Microsoft.*/*/read. 
                    resourceProvidersToQuery = resourceProvidersWithOperationsApi
                        .Where(kvp => kvp.Key.StartsWith(nonWildCardPrefix, StringComparison.InvariantCultureIgnoreCase))
                        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                }
            }

            return resourceProvidersToQuery;
        }

        /// <summary>
        /// Gets a list of Provider operations in the case that the Actionstring input does not contain a wildcard
        /// </summary>
        private List<PSResourceProviderOperation> ProcessProviderOperationsWithoutWildCard(string actionString, Dictionary<string, string> resourceProvidersWithOperationsApi)
        {
            Dictionary<string, string> resourceProvidersToQuery = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
            string providerFullName = GetAzureSecurableActionCommand.GetResourceProviderFullName(actionString);

            string apiVersion;
            if (resourceProvidersWithOperationsApi.TryGetValue(providerFullName, out apiVersion))
            {
                // We have the full name of the provider and it supports the operations api - so it can be queried
                resourceProvidersToQuery.Add(providerFullName, apiVersion);
            }

            List<PSResourceProviderOperation> operationsToDisplay = new List<PSResourceProviderOperation>();

            if(resourceProvidersToQuery.Count() > 0)
            {
                // Get all operations exposed by this single provider and find the one where the name matches the actionstring input
                 ResourceIdentity identity = new ResourceIdentity()
                {
                    ResourceName = string.Empty,
                    ResourceType = "operations",
                    ResourceProviderNamespace = resourceProvidersToQuery.Single().Key,
                    ResourceProviderApiVersion = resourceProvidersToQuery.Single().Value
                };

                IList<PSResourceProviderOperation> allResourceProviderOperations = this.ResourcesClient.ListPSProviderOperations(new List<ResourceIdentity>() { identity });
                operationsToDisplay.AddRange(allResourceProviderOperations.Where(op => string.Equals(op.OperationName, actionString, StringComparison.InvariantCultureIgnoreCase)));
            }

            return operationsToDisplay;
        }

        /// <summary>
        /// Extracts the resource provider's full name - i.e portion of the non-wildcard prefix before the '/'
        /// Returns null if the nonWildCardPrefix does not contain a '/'
        /// </summary>
        private static string GetResourceProviderFullName(string nonWildCardPrefix)
        {
            int index = nonWildCardPrefix.IndexOf("/", 0);
            return index > 0 ? nonWildCardPrefix.Substring(0, index) : string.Empty;
        }

        /// <summary>
        /// Extracts the portion of the actionstring before the first wildcard character (*)
        /// </summary>
        private static string GetNonWildcardPrefix(string actionString)
        {
            int index = actionString.IndexOf(WildCardCharacter);
            return index >= 0 ? actionString.Substring(0, index) : actionString;
        }
    }
}