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
    using AutoMapper;
    using Microsoft.Azure.Commands.ApiManagement.Properties;
    using Microsoft.Azure.Management.ApiManagement.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class PsApiManagement
    {
        private static readonly Regex ResourceGroupRegex =
            new Regex(@"/resourceGroups/(?<resourceGroupName>.+)/providers/", RegexOptions.Compiled);

        public PsApiManagement()
        {
            Tags = new Dictionary<string, string>();
            AdditionalRegions = new List<PsApiManagementRegion>();
        }

        public PsApiManagement(ApiServiceResource apiServiceResource)
            : this()
        {
            if (apiServiceResource == null)
            {
                throw new ArgumentNullException("apiServiceResource");
            }

            Id = apiServiceResource.Id;
            Name = apiServiceResource.Name;
            Location = apiServiceResource.Location;
            Sku = Mapper.Map<SkuType, PsApiManagementSku>(apiServiceResource.Properties.SkuProperties.SkuType);
            Capacity = apiServiceResource.Properties.SkuProperties.Capacity ?? 1;
            ProvisioningState = apiServiceResource.Properties.ProvisioningState;
            RuntimeUrl = apiServiceResource.Properties.ProxyEndpoint;
            PortalUrl = apiServiceResource.Properties.ManagementPortalEndpoint;
            StaticIPs = apiServiceResource.Properties.StaticIPs.ToArray();

            if (apiServiceResource.Properties.AdditionalRegions != null)
            {
                AdditionalRegions =
                    apiServiceResource.Properties.AdditionalRegions
                        .Select(region => new PsApiManagementRegion(region))
                        .ToList();
            }

            if (apiServiceResource.Properties.VirtualNetworkConfiguration != null)
            {
                VirtualNetwork = new PsApiManagementVirtualNetwork(apiServiceResource.Properties.VirtualNetworkConfiguration);
            }

            if (apiServiceResource.Properties.HostnameConfigurations != null)
            {
                var portalHostnameResource = apiServiceResource.Properties.HostnameConfigurations.FirstOrDefault(conf => conf.Type == HostnameType.Portal);
                if (portalHostnameResource != null)
                {
                    PortalHostnameConfiguration = new PsApiManagementHostnameConfiguration(portalHostnameResource);
                }

                var proxyHostnameResource = apiServiceResource.Properties.HostnameConfigurations.FirstOrDefault(conf => conf.Type == HostnameType.Proxy);
                if (proxyHostnameResource != null)
                {
                    ProxyHostnameConfiguration = new PsApiManagementHostnameConfiguration(proxyHostnameResource);
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

        public PsApiManagementSku Sku { get; set; }

        public int Capacity { get; set; }

        public string ProvisioningState { get; private set; }

        public string RuntimeUrl { get; private set; }

        public string PortalUrl { get; private set; }

        public PsApiManagementVirtualNetwork VirtualNetwork { get; set; }

        public PsApiManagementHostnameConfiguration PortalHostnameConfiguration { get; set; }

        public PsApiManagementHostnameConfiguration ProxyHostnameConfiguration { get; set; }

        public IDictionary<string, string> Tags { get; set; }

        public IList<PsApiManagementRegion> AdditionalRegions { get; private set; }

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

        public PsApiManagementRegion AddRegion(
            string location,
            PsApiManagementSku sku = PsApiManagementSku.Developer,
            int capacity = 1,
            PsApiManagementVirtualNetwork virtualNetwork = null)
        {
            if (location == null)
            {
                throw new ArgumentNullException("location");
            }

            if (location.Equals(Location) || AdditionalRegions.Any(r => location.Equals(r.Location)))
            {
                throw new ArgumentException(string.Format(Resources.AddRegionExistsMessage, location), "location");
            }

            var newRegion = new PsApiManagementRegion
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

            if (location.Equals(Location))
            {
                throw new ArgumentException(
                    string.Format(Resources.RemoveRegionCannotRemoveMasterRegion, location),
                    "location");
            }

            var regionToRemove = AdditionalRegions.FirstOrDefault(r => location.Equals(r.Location));

            return regionToRemove != null && AdditionalRegions.Remove(regionToRemove);
        }

        public void UpdateRegion(string location, PsApiManagementSku sku, int capacity, PsApiManagementVirtualNetwork virtualNetwork)
        {
            if (location == null)
            {
                throw new ArgumentNullException("location");
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
                throw new ArgumentException(string.Format(Resources.UpdateRegionDoesNotExistsMessage, location), "location");
            }
        }
    }
}