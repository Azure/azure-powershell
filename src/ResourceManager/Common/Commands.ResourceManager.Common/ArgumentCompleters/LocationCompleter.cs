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

namespace Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters
{
    using Commands.Common.Authentication.Abstractions;
    using Commands.Common.Authentication;
    using Internal.Subscriptions;
    using Properties;
    using Management.Internal.Resources.Models;
    using Management.Internal.Resources;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Collections.Concurrent;


    /// <summary>
    /// This attribute will allow the user to autocomplete the -Location parameter of a cmdlet with valid locations (as determined by the list of ResourceTypes given)
    /// </summary>
    public class LocationCompleterAttribute : PSCompleterBaseAttribute
    {
        private static IDictionary<int, IDictionary<string, ICollection<string>>> _resourceTypeLocationDictionary = new ConcurrentDictionary<int, IDictionary<string, ICollection<string>>>();
        private static readonly object _lock = new object();
        private static string[] _resourceTypes;
        private static int _timeout = 3;

        protected static IDictionary<string, ICollection<string>> ResourceTypeLocationDictionary
        {
            get
            {
                lock (_lock)
                {
                    IAzureContext context = AzureRmProfileProvider.Instance.Profile.DefaultContext;
                    var contextHash = HashContext(context);
                    IDictionary<string, ICollection<string>> output;
                    if (!_resourceTypeLocationDictionary.ContainsKey(contextHash))
                    {
                        try
                        {
                            var instance = AzureSession.Instance;
                            IResourceManagementClient client = instance.ClientFactory.CreateCustomArmClient<ResourceManagementClient>(
                                context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager),
                                instance.AuthenticationFactory.GetServiceClientCredentials(context, AzureEnvironment.Endpoint.ResourceManager),
                                instance.ClientFactory.GetCustomHandlers());
                            client.SubscriptionId = context.Subscription.Id;
                            var allProviders = client.Providers.ListAsync();
                            if (allProviders.Wait(TimeSpan.FromSeconds(_timeout)))
                            {
                                if (allProviders.Result != null)
                                {
                                    _resourceTypeLocationDictionary[contextHash] = CreateLocationDictionary(allProviders.Result.ToList());
                                    output = _resourceTypeLocationDictionary[contextHash];
                                }
                                else
                                {
                                    output = CreateLocationDictionary(new List<Provider>());
#if DEBUG
                                    throw new InvalidOperationException("Result from client.Providers is null");
#endif
                                }
                            }
                            else
                            {
                                output = new ConcurrentDictionary<string, ICollection<string>>(StringComparer.OrdinalIgnoreCase);
#if DEBUG
                                throw new InvalidOperationException(Resources.TimeOutForProviderList);
#endif
                            }
                        }
                        catch (Exception ex)
                        {
                            output = new ConcurrentDictionary<string, ICollection<string>>(StringComparer.OrdinalIgnoreCase);
                            if (ex == null) { }
#if DEBUG
                            throw ex;
#endif
                        }
                    }

                    else
                    {
                        output = _resourceTypeLocationDictionary[contextHash];
                    }

                    return output;
                }
            }
        }

        /// <summary>
        /// Pass in a list of ResourceTypes and this class will provide a list of locations that are common to all ResourceTypes given. This will then be available to the user to tab through.
        /// Example: [Parameter(ParameterSetName = ListByNameInTenantParameterSet, ValueFromPipelineByPropertyName = true, Mandatory = false), LocationCompleter(new string[] { "Microsoft.Batch/operationss" })]
        /// </summary>
        /// <param name="resourceTypes"></param>
        public LocationCompleterAttribute(params string[] resourceTypes)
        {
            _resourceTypes = resourceTypes;
        }

        public override string[] GetCompleterValues()
        {
            return FindLocations(_resourceTypes);
        }

        public static string[] FindLocations(string[] resourceTypes, int timeout)
        {
            _timeout = timeout;
            return FindLocations(resourceTypes);
        }

        public static string[] FindLocations(string[] resourceTypes)
        {
            return FindLocations(resourceTypes, ResourceTypeLocationDictionary);
        }

        /// <summary>
        /// Finds all valid Locations for 
        /// </summary>
        /// <param name="resourceTypes"></param>
        /// <param name="resourceTypeLocationDictionary"></param>
        /// <returns></returns>
        public static string[] FindLocations(string[] resourceTypes, IDictionary<string, ICollection<string>> resourceTypeLocationDictionary)
        {
            if (resourceTypeLocationDictionary == null)
            {
                resourceTypeLocationDictionary = new ConcurrentDictionary<string, ICollection<string>>(StringComparer.OrdinalIgnoreCase);
            }

            if (resourceTypes == null)
            {
                resourceTypes = new string[0];
            }

            List<string> validResourceTypes = new List<string>();
            foreach (string resourceType in resourceTypes)
            {
                if (resourceType != null)
                {
                    if (resourceTypeLocationDictionary.ContainsKey(resourceType) && resourceTypeLocationDictionary[resourceType] != null)
                        validResourceTypes.Add(resourceType);
#if DEBUG
                    else throw new Exception(String.Format(Resources.InvalidResourceType, resourceType));
#endif
                }
            }

            string[] distinctLocations = { };
            if (validResourceTypes.Count > 0)
            {
                distinctLocations = resourceTypeLocationDictionary[validResourceTypes[0]].ToArray();
                foreach (string resourceType in validResourceTypes)
                {
                    distinctLocations = distinctLocations.Intersect(resourceTypeLocationDictionary[resourceType].ToArray(), new LocationEqualityComparer()).ToArray();
                }
            }
#if DEBUG
            else throw new Exception(Resources.NoValidProviderFound);

            if (distinctLocations.Length < 1) throw new Exception(Resources.NoValidLocationsFound);
#endif
            for (int i = 0; i < distinctLocations.Length; i++)
            {
                distinctLocations[i] = String.Format("\'{0}\'", distinctLocations[i]);
            }
            return distinctLocations;
        }

        /// <summary>
        /// Create a dictionary mapping the ResourceTypes of all providers given to the valid locations available to that ResourceType
        /// </summary>
        /// <param name="allProviders"></param>
        /// <returns></returns>
        public static IDictionary<string, ICollection<string>> CreateLocationDictionary(List<Provider> allProviders)
        {
            IDictionary<string, ICollection<string>> resourceTypeLocationDictionary = new ConcurrentDictionary<string, ICollection<string>>(StringComparer.OrdinalIgnoreCase);

            foreach (var provider in allProviders)
            {
                foreach (var resourceType in provider.ResourceTypes)
                {
                    resourceTypeLocationDictionary.Add(String.Format("{0}/{1}", provider.NamespaceProperty, resourceType.ResourceType), resourceType.Locations);
                }
            }

            return resourceTypeLocationDictionary;
        }

        /// <summary>
        /// Create ScriptBlock that registers the correct location for tab completetion of the -Location parameter
        /// </summary>
        /// <param name="resourceTypes"></param>
        /// <returns></returns>
        public static ScriptBlock CreateScriptBlock(string[] resourceTypes)
        {
            string scriptResourceTypeList = "{" + String.Join(",", resourceTypes) + "}";
            string script = "param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)\n" +
                String.Format("$locations = [Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters.LocationCompleterAttribute]::FindLocations({0})\n", scriptResourceTypeList) +
                "$locations | Where-Object { $_ -Like \"`\"$wordToComplete*\" } | Sort-Object | ForEach-Object { [System.Management.Automation.CompletionResult]::new($_, $_, 'ParameterValue', $_) }";
            ScriptBlock scriptBlock = ScriptBlock.Create(script);
            return scriptBlock;
        }

        private static int HashContext(IAzureContext context)
        {
            return (context.Account.Id + context.Environment.Name + context.Subscription.Id + context.Tenant.Id).GetHashCode();
        }

        class LocationEqualityComparer : IEqualityComparer<string>
        {
            public bool Equals(string location1, string location2)
            {
                string strippedLocation1 = location1.Replace(" ", "").Replace("-", "").ToLower();
                string strippedLocation2 = location2.Replace(" ", "").Replace("-", "").ToLower();
                return strippedLocation1.Equals(strippedLocation2);
            }

            public int GetHashCode(string item)
            {
                return item.Replace(" ", "").Replace("-", "").ToLower().GetHashCode();
            }
        }
    }
}
