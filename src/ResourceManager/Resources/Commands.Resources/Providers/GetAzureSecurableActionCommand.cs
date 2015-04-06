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
        private const string WildCardCharacter = "*";
        private const string Operations = "operations";
        // Stores a mapping of provider names and the api version of that provider's operations endpoint
        private Dictionary<string, string> resourceProvidersWithOperationsApi = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

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
            Dictionary<string, string> resourceProvidersWithOperationsApi = GetResourceProvidersWithOperationsSupport();

            if (ActionString.Contains(WildCardCharacter))
            {
                operationsToDisplay = this.ProcessProviderOperationsWithWildCard(ActionString, resourceProvidersWithOperationsApi);
            }
            else
            {
                operationsToDisplay = this.ProcessProviderOperationsWithoutWildCard(ActionString, resourceProvidersWithOperationsApi);
            }

            this.WriteObject(operationsToDisplay, enumerateCollection:true);
        }
        
        private Dictionary<string,string> GetResourceProvidersWithOperationsSupport()
        {
            PSResourceProvider[] allProviders = this.ResourcesClient.ListPSResourceProviders(listAvailable: true);

            Dictionary<string, string> providersSupportingOperations = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
            PSResourceProviderResourceType[] providerResourceTypes = null;

            foreach (PSResourceProvider provider in allProviders)
            {
                providerResourceTypes = provider.ResourceTypes;
                if (providerResourceTypes != null && providerResourceTypes.Any())
                {
                    PSResourceProviderResourceType operationsResourceType = providerResourceTypes.Where(r => r!= null && r.ResourceTypeName == Operations).FirstOrDefault();
                    if (operationsResourceType != null && 
                        operationsResourceType.ApiVersions != null && 
                        operationsResourceType.ApiVersions.Any() && 
                        !string.IsNullOrEmpty(operationsResourceType.ApiVersions.First()))
                    {
                        // To avoid error if some provider is present more than once (which is likely a bug)
                        if (!providersSupportingOperations.ContainsKey(provider.ProviderNamespace))
                        {
                            providersSupportingOperations.Add(provider.ProviderNamespace, operationsResourceType.ApiVersions.First());
                        }
                    }
                }
            }

            return providersSupportingOperations;
        }

        private List<PSResourceProviderOperation> ProcessProviderOperationsWithWildCard(string actionString, Dictionary<string, string> resourceProvidersWithOperationsApi)
        {
            Dictionary<string, string> resourceProvidersToQuery = FilterResourceProvidersToQueryForOperations(actionString, resourceProvidersWithOperationsApi);
            
            List<PSResourceProviderOperation> operationsToDisplay = new List<PSResourceProviderOperation>();
            if (resourceProvidersToQuery.Count() > 0)
            {
                // Get all operations exposed by all providers that we want to query
                IList<PSResourceProviderOperation> allResourceProviderOperations = this.ResourcesClient.ListPSProviderOperations(resourceProvidersToQuery);

                // Filter the list of all operation names to what matches the wildcard
                WildcardOptions options = WildcardOptions.IgnoreCase | WildcardOptions.Compiled;
                WildcardPattern wildcard = new WildcardPattern(actionString, options);

                foreach (PSResourceProviderOperation operation in allResourceProviderOperations)
                {
                    if (wildcard.IsMatch(operation.OperationName))
                    {
                        operationsToDisplay.Add(operation);
                    }
                }
            }
            
            return operationsToDisplay;
        }

        private Dictionary<string, string> FilterResourceProvidersToQueryForOperations(string actionString, Dictionary<string, string> resourceProvidersWithOperationsApi)
        {
            Dictionary<string, string> resourceProvidersToQuery = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
             
            string nonWildCardPrefix = GetNonWildcardPrefix(actionString);

            if (string.IsNullOrEmpty(nonWildCardPrefix))
            {
                // 'Get-AzureSecurableAction *' or 'Get-AzureSecurableAction */virtualmachines/*'
                resourceProvidersToQuery = resourceProvidersWithOperationsApi;
            }
            else
            {
                // Some string exists before the wild card character - potentially the full name of the provider.
                string providerFullName = GetResourceProviderFullName(nonWildCardPrefix);

                if (!string.IsNullOrEmpty(providerFullName))
                {
                    if (resourceProvidersWithOperationsApi.ContainsKey(providerFullName))
                    {
                        // We have the full name of the provider and it supports the operations api - so it can be queried
                        resourceProvidersToQuery.Add(providerFullName, resourceProvidersWithOperationsApi[providerFullName]);
                    }
                }
                else
                {
                    // We have only a partial name of the provider, say Microsoft.*/* or Microsoft.*/*/read. 
                    // To keep it simple, query all providers that work
                    resourceProvidersToQuery = resourceProvidersWithOperationsApi;
                }
            }

            return resourceProvidersToQuery;
        }

        private List<PSResourceProviderOperation> ProcessProviderOperationsWithoutWildCard(string actionString, Dictionary<string, string> resourceProvidersWithOperationsApi)
        {
            Dictionary<string, string> resourceProvidersToQuery = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
            string providerFullName = GetResourceProviderFullName(actionString);
            
            if (!string.IsNullOrEmpty(providerFullName) && resourceProvidersWithOperationsApi.ContainsKey(providerFullName))
            {
                // We have the full name of the provider and it supports the operations api - so it can be queried
                resourceProvidersToQuery.Add(providerFullName, resourceProvidersWithOperationsApi[providerFullName]);
            }

            List<PSResourceProviderOperation> operationsToDisplay = new List<PSResourceProviderOperation>();

            if(resourceProvidersToQuery.Count() > 0)
            {
                // Get all operations exposed by this single provider and find the one (it may be a bug if there are more than one, but do not error on that) 
                // where the name matches the actionstring input
                IList<PSResourceProviderOperation> allResourceProviderOperations = this.ResourcesClient.ListPSProviderOperations(resourceProvidersToQuery);
                operationsToDisplay.AddRange(allResourceProviderOperations.Where(op => string.Equals(op.OperationName, actionString, StringComparison.InvariantCultureIgnoreCase)));
            }

            return operationsToDisplay;
        }

        private string GetResourceProviderFullName(string nonWildCardPrefix)
        {
            string providerFullName = string.Empty;
            
            int index = nonWildCardPrefix.IndexOf("/", 0);
            if(index > 0)
            {
                providerFullName = nonWildCardPrefix.Substring(0, index);
            }

            return providerFullName;
        }

        private static string GetNonWildcardPrefix(string actionString)
        {
            for (int index = 0; index < actionString.Length; index++)
            {
                if (string.Equals(WildCardCharacter, actionString[index].ToString()))
                {
                    return actionString.Substring(0, index);
                }
            }

            return actionString;
        }
    }
}