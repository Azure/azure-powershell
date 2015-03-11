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
    using Microsoft.Azure.Management.ApiManagement.Models;

    public class ApiManagementAttributes
    {
        private static readonly Regex ResourceGroupRegex = new Regex(@"/resourceGroups/(?<resourceGroupName>.+)/providers/", RegexOptions.Compiled);

        public ApiManagementAttributes()
        {
        }

        public ApiManagementAttributes(ApiServiceResource apiServiceResource)
            : this()
        {
            if (apiServiceResource == null)
            {
                throw new ArgumentNullException("apiServiceResource");
            }

            Id = apiServiceResource.Id;
            Name = apiServiceResource.Name;
            Location = apiServiceResource.Location;
            Sku = apiServiceResource.Properties.SkuProperties.SkuType.ToString();
            Capacity = apiServiceResource.Properties.SkuProperties.Capacity ?? 1;
            ProvisioningState = apiServiceResource.Properties.ProvisioningState;
            RuntimeUrl = apiServiceResource.Properties.ProxyEndpoint;
            PortalUrl = apiServiceResource.Properties.ManagementPortalEndpoint;
            StaticIPs = apiServiceResource.Properties.StaticIPs.ToArray();

            if (apiServiceResource.Properties.AdditionalRegions != null)
            {
                AdditionalRegions =
                    apiServiceResource.Properties.AdditionalRegions
                        .Select(region => new ApiManagementRegionAttributes(region))
                        .ToList();
            }

            if (apiServiceResource.Properties.VirtualNetworkConfiguration != null)
            {
                VnetConfiguration = new VirtualNetworkConfigurationAttributes(apiServiceResource.Properties.VirtualNetworkConfiguration);
            }

            if (apiServiceResource.Properties.HostnameConfigurations != null)
            {
                var portalHostnameResource = apiServiceResource.Properties.HostnameConfigurations.FirstOrDefault(conf => conf.Type == HostnameType.Portal);
                if (portalHostnameResource != null)
                {
                    this.PortalHostnameConfiguration = new ApiManagementHostnameAtributes(ApiManagementHostnameType.Portal, portalHostnameResource);
                }

                var proxyHostnameResource = apiServiceResource.Properties.HostnameConfigurations.FirstOrDefault(conf => conf.Type == HostnameType.Proxy);
                if (proxyHostnameResource != null)
                {
                    this.PortalHostnameConfiguration = new ApiManagementHostnameAtributes(ApiManagementHostnameType.Proxy, proxyHostnameResource);
                }
            }
        }

        public VirtualNetworkConfigurationAttributes VnetConfiguration { get; set; }

        public string[] StaticIPs { get; private set; }

        public string Id { get; private set; }

        public string Name { get; private set; }

        public string Location { get; private set; }

        public string Sku { get; set; }

        public int Capacity { get; set; }

        public string ProvisioningState { get; private set; }

        public string RuntimeUrl { get; private set; }

        public string PortalUrl { get; private set; }

        public IList<ApiManagementRegionAttributes> AdditionalRegions { get; set; }

        public ApiManagementHostnameAtributes PortalHostnameConfiguration { get; set; }

        public ApiManagementHostnameAtributes ProxyHostnameConfiguration { get; set; }

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
    }
}