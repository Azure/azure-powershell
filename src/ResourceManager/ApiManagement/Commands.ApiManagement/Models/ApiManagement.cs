//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

namespace Microsoft.Azure.Commands.ApiManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading;
    using AutoMapper;
    using Microsoft.Azure.Management.ApiManagement.Models;

    public class ApiManagement
    {
        private static readonly Regex ResourceGroupRegex = 
            new Regex(@"/resourceGroups/(?<resourceGroupName>.+)/providers/", RegexOptions.Compiled);

        public ApiManagement()
        {
            Tags = new Dictionary<string, string>();
            AdditionalRegions = new List<ApiManagementRegion>();
        }

        internal ApiManagement(ApiServiceResource apiServiceResource)
            : this()
        {
            if (apiServiceResource == null)
            {
                throw new ArgumentNullException("apiServiceResource");
            }

            Id = apiServiceResource.Id;
            Name = apiServiceResource.Name;
            Location = apiServiceResource.Location;
            Sku = Mapper.Map<SkuType, ApiManagementSku>(apiServiceResource.Properties.SkuProperties.SkuType);
            Capacity = apiServiceResource.Properties.SkuProperties.Capacity ?? 1;
            ProvisioningState = apiServiceResource.Properties.ProvisioningState;
            RuntimeUrl = apiServiceResource.Properties.ProxyEndpoint;
            PortalUrl = apiServiceResource.Properties.ManagementPortalEndpoint;
            StaticIPs = apiServiceResource.Properties.StaticIPs.ToArray();

            if (apiServiceResource.Properties.AdditionalRegions != null)
            {
                AdditionalRegions =
                    apiServiceResource.Properties.AdditionalRegions
                        .Select(region => new ApiManagementRegion(region))
                        .ToList();
            }

            if (apiServiceResource.Properties.VirtualNetworkConfiguration != null)
            {
                VirtualNetwork = new ApiManagementVirtualNetwork(apiServiceResource.Properties.VirtualNetworkConfiguration);
            }

            if (apiServiceResource.Properties.HostnameConfigurations != null)
            {
                var portalHostnameResource = apiServiceResource.Properties.HostnameConfigurations.FirstOrDefault(conf => conf.Type == HostnameType.Portal);
                if (portalHostnameResource != null)
                {
                    PortalHostnameConfiguration = new ApiManagementHostnameConfiguration(portalHostnameResource);
                }

                var proxyHostnameResource = apiServiceResource.Properties.HostnameConfigurations.FirstOrDefault(conf => conf.Type == HostnameType.Proxy);
                if (proxyHostnameResource != null)
                {
                    PortalHostnameConfiguration = new ApiManagementHostnameConfiguration(proxyHostnameResource);
                }
            }

            if (apiServiceResource.Tags != null)
            {
                Tags = apiServiceResource.Tags;
            }
        }

        public string[] StaticIPs { get; private set; }

        public string Id { get; private set; }

        public string Name { get; private set; }

        public string Location { get; private set; }

        public ApiManagementSku Sku { get; set; }

        public int Capacity { get; set; }

        public string ProvisioningState { get; private set; }

        public string RuntimeUrl { get; private set; }

        public string PortalUrl { get; private set; }

        public ApiManagementVirtualNetwork VirtualNetwork { get; set; }

        public ApiManagementHostnameConfiguration PortalHostnameConfiguration { get; set; }

        public ApiManagementHostnameConfiguration ProxyHostnameConfiguration { get; set; }

        public IDictionary<string, string> Tags { get; set; }

        public IList<ApiManagementRegion> AdditionalRegions { get; private set; }

        public string ResourceGroupName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Id))
                {
                    return null;
                }

                var match = ResourceGroupRegex.Match(Id);
                if (match.Success)
                {
                    var resourceGroupNameGroup = match.Groups["resourceGroupName"];
                    if (resourceGroupNameGroup != null && resourceGroupNameGroup.Success)
                    {
                        return resourceGroupNameGroup.Value;
                    }
                }

                return null;
            }
        }

        public ApiManagementRegion AddRegion(
            string location,
            ApiManagementSku sku = ApiManagementSku.Developer,
            int capacity = 1,
            ApiManagementVirtualNetwork virtualNetwork = null)
        {
            if (location == null)
            {
                throw new ArgumentNullException("location");
            }

            if (!CommonConstants.ValidLocationsSet.Contains(location))
            {
                throw new ArgumentException(
                    string.Format(
                        Properties.Resources.InvalidLocation,
                        location,
                        string.Join(",", CommonConstants.ValidLocationsSet)
                        ),
                    "location");
            }

            if (location.Equals(Location) || AdditionalRegions.Any(r => location.Equals(r.Location)))
            {
                throw new ArgumentException(string.Format(Properties.Resources.AddRegionExistsMessage, location), "location");
            }

            var newRegion = new ApiManagementRegion
            {
                Location = location,
                Sku = sku,
                Capacity = capacity,
                VirtualNetwork = virtualNetwork
            };

            AdditionalRegions.Add(newRegion);

            return newRegion;
        }

        public bool RemoveRegion(string location)
        {
            if (location == null)
            {
                throw new ArgumentNullException("location");
            }

            if (!CommonConstants.ValidLocationsSet.Contains(location))
            {
                throw new ArgumentException(
                    string.Format(
                        Properties.Resources.InvalidLocation,
                        location,
                        string.Join(",", CommonConstants.ValidLocationsSet)
                        ),
                    "location");
            }

            if (location.Equals(Location))
            {
                throw new ArgumentException(
                    string.Format(Properties.Resources.RemoveRegionCannotRemoveMasterRegion, location),
                    "location");
            }

            var regionToRemove = AdditionalRegions.FirstOrDefault(r => location.Equals(r.Location));

            return regionToRemove != null && AdditionalRegions.Remove(regionToRemove);
        }

        public void UpdateRegion(string location, ApiManagementSku sku, int capacity, ApiManagementVirtualNetwork virtualNetwork)
        {
            if (location == null)
            {
                throw new ArgumentNullException("location");
            }

            if (!CommonConstants.ValidLocationsSet.Contains(location))
            {
                throw new ArgumentException(
                    string.Format(
                        Properties.Resources.InvalidLocation,
                        location,
                        string.Join(",", CommonConstants.ValidLocationsSet)
                        ),
                    "location");
            }

            var regionToUpdate = AdditionalRegions.FirstOrDefault(r => location.Equals(r.Location));
            if (regionToUpdate != null)
            {
                regionToUpdate.Sku = sku;
                regionToUpdate.Capacity = capacity;
                regionToUpdate.VirtualNetwork = virtualNetwork;
            }
            else if (location.Equals(Location))
            {
                Sku = sku;
                Capacity = capacity;
                VirtualNetwork = virtualNetwork;
            }
            else
            {
                throw new ArgumentException(string.Format(Properties.Resources.UpdateRegionDoesNotExistsMessage, location), "location");
            }
        }
    }
}