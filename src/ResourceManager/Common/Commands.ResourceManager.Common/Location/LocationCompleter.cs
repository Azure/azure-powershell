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

namespace Microsoft.Azure.Commands.ResourceManager.Common.Location
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.Azure.Management.Internal.Resources;
    using Microsoft.Azure.Management.Internal.Resources.Utilities;
    using Commands.Common.Authentication.Abstractions;
    using Commands.Common.Authentication;
    using Internal.Subscriptions;
    using Internal.Subscriptions.Models;
    using System.Linq;
    using Management.Internal.Resources.Models;

    /// <summary>
    /// This attribute will allow the user to autocomplete the -Location parameter of a cmdlet with valid locations (as determined by the list of ResourceTypes given)
    /// </summary>
    public class LocationCompleterAttribute : ArgumentCompleterAttribute
    {
        private static Dictionary<string, ICollection<string>> _resourceTypeLocationDictionary = new Dictionary<string, ICollection<string>>(StringComparer.OrdinalIgnoreCase);

        private static readonly object _lock = new object();

        protected static Dictionary<string, ICollection<string>> ResourceTypeLocationDictionary
        {
            get
            {
                lock (_lock)
                {
                    if (_resourceTypeLocationDictionary.Count < 1)
                    {
                        IAzureContext defaultContext = AzureRmProfileProvider.Instance.Profile.DefaultContext;

                        var client = new ResourceManagementClient(
                            defaultContext.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager),
                            AzureSession.Instance.AuthenticationFactory.GetServiceClientCredentials(defaultContext, AzureEnvironment.Endpoint.ResourceManager));
                        client.SubscriptionId = defaultContext.Subscription.Id;
                        var allProviders = client.Providers.List().ToList();

                        _resourceTypeLocationDictionary = CreateLocationDictionary(allProviders);
                    }

                    return _resourceTypeLocationDictionary;
                }
            }
        }

        /// <summary>
        /// Pass in a list of ResourceTypes and this class will provide a list of locations that are common to all ResourceTypes given. This will then be available to the user to tab through.
        /// Example: [Parameter(ParameterSetName = ListByNameInTenantParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = false), LocationCompleter(new string[] { "Microsoft.Batch/operationss" })]
        /// </summary>
        /// <param name="resourceTypes"></param>
        public LocationCompleterAttribute(string[] resourceTypes) : base(CreateScriptBlock(resourceTypes))
        { }

        private static string[] FindLocations(string[] resourceTypes)
        {
            return FindLocations(resourceTypes, ResourceTypeLocationDictionary);
        }

        /// <summary>
        /// Finds all valid Locations for 
        /// </summary>
        /// <param name="resourceTypes"></param>
        /// <param name="resourceTypeLocationDictionary"></param>
        /// <returns></returns>
        public static string[] FindLocations(string[] resourceTypes, Dictionary<string, ICollection<string>> resourceTypeLocationDictionary)
        {
            List<string> validResourceTypes = new List<string>();
            foreach (string resourceType in resourceTypes)
            {
                if (resourceTypeLocationDictionary.ContainsKey(resourceType))
                    validResourceTypes.Add(resourceType);
#if DEBUG
                else throw new Exception("ResourceType name: " + resourceType + " is invalid.");
#endif
            }
            
            string[] distinctLocations;
            if (validResourceTypes.Count > 0)
            {
                distinctLocations = resourceTypeLocationDictionary[validResourceTypes[0]].ToArray();
                foreach (string resourceType in validResourceTypes)
                {
                    distinctLocations = distinctLocations.Intersect(resourceTypeLocationDictionary[resourceType]).ToArray();
                }
            }
#if DEBUG
            else throw new Exception("No valid ResourceType given to LocationCompleter.");

            if (distinctLocations.Length < 1) throw new Exception("No locations exist for all of the given ResourceTypes.");
#endif 
            return distinctLocations;
        }

        /// <summary>
        /// Create a dictionary mapping the ResourceTypes of all providers given to the valid locations available to that ResourceType
        /// </summary>
        /// <param name="allProviders"></param>
        /// <returns></returns>
        public static Dictionary<string, ICollection<string>> CreateLocationDictionary(List<Provider> allProviders)
        {
            Dictionary<string, ICollection<string>> resourceTypeLocationDictionary = new Dictionary<string, ICollection<string>>(StringComparer.OrdinalIgnoreCase);
            
            foreach (var provider in allProviders)
            {
                foreach (var resourceType in provider.ResourceTypes)
                {
                    resourceTypeLocationDictionary.Add(provider.NamespaceProperty + "/" + resourceType.ResourceType, resourceType.Locations);
                }
            }
            return resourceTypeLocationDictionary;
        }

        private static ScriptBlock CreateScriptBlock(string[] resourceTypes)
        {
            string[] locationList = FindLocations(resourceTypes);

            string script =
                "param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)" + Environment.NewLine +
                    "[string[]] $locations = ";

            foreach (string location in locationList)
            {
                const string quote = "\"";
                script += "'" + quote + location + quote + "'" + ",";
            }
            script = script.TrimEnd(',');

            script += Environment.NewLine + "$locations | ForEach-Object { New-Object System.Management.Automation.CompletionResult ($_)}";

            ScriptBlock scriptBlock = ScriptBlock.Create(script);

            return scriptBlock;
        }
    }
}
