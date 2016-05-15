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
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Microsoft.Azure.Commands.Resources.Models;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Azure.Subscriptions.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;

    /// <summary>
    /// Get all locations with the supported providers.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmLocation"), OutputType(typeof(List<PSResourceProviderLocation>))]
    public class GetAzureLocationCmdlet : ResourcesBaseCmdlet
    {
        /// <summary>
        /// Executes the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            WriteWarning("The output object type of this cmdlet will be modified in a future release.");

            var allLocations = this.SubscriptionsClient.ListLocations(DefaultContext.Subscription.Id.ToString());
            var providers = this.ResourcesClient.ListResourceProviders(providerName: null, listAvailable: true);
            var providerLocations = ConstructResourceProviderLocations(allLocations, providers);

            this.WriteObject(providerLocations, enumerateCollection: true);
        }

        private List<PSResourceProviderLocation> ConstructResourceProviderLocations(List<Location> locations, List<Provider> providers)
        {
            var locationProviderMap = GetLocationProviderMap(providers);

            // Join locations and locationProviderMap on DisplayName
            // locations: list of [Name, DisplayName, Id, ...]
            // locationProviderMap: list of [Key: DisplayName, Value: Providers]
            var joinResult = locations.CoalesceEnumerable().Join(
                locationProviderMap.CoalesceEnumerable(),
                location => location.DisplayName,
                mapEntry => mapEntry.Key,
                (location, mapEntry) => new PSResourceProviderLocation
                {
                    Location = location.Name,
                    DisplayName = location.DisplayName,
                    Providers = mapEntry.Value
                },
                StringComparer.InvariantCultureIgnoreCase);

            return joinResult.ToList();
        }

        private Dictionary<string, List<string>> GetLocationProviderMap(List<Provider> providers)
        {
            var locationMap = new Dictionary<string, List<string>>(StringComparer.InvariantCultureIgnoreCase);
            providers.CoalesceEnumerable()
                .ForEach(provider => AddResourceProvider(provider, locationMap));

            return locationMap;
        }

        private bool AddResourceProvider(Provider provider, Dictionary<string, List<string>> locationMap)
        {
            if (locationMap == null || provider == null)
            {
                return false;
            }

            var providersLocations = provider.ResourceTypes
                .CoalesceEnumerable()
                .SelectMany(type => type.Locations)
                .Distinct(StringComparer.InvariantCultureIgnoreCase);

            providersLocations.ForEach(location =>
            {
                if (!locationMap.ContainsKey(location))
                {
                    locationMap[location] = new List<string>();
                }
                if (!locationMap[location].Contains(provider.Namespace))
                {
                    locationMap[location].Add(provider.Namespace);
                }
            });

            return true;
        }
    }
}