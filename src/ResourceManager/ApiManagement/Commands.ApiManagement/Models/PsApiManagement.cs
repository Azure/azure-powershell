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
    using Microsoft.Azure.Commands.ApiManagement.Properties;
    using Microsoft.Azure.Management.ApiManagement.Models;
    using Models;
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

        public PsApiManagement(ApiManagementServiceResource apiServiceResource)
            : this()
        {
            if (apiServiceResource == null)
            {
                throw new ArgumentNullException("apiServiceResource");
            }

            Id = apiServiceResource.Id;
            Name = apiServiceResource.Name;
            Location = apiServiceResource.Location;
            Sku = ApiManagementClient.Mapper.Map<string, PsApiManagementSku>(apiServiceResource.Sku.Name);
            Capacity = apiServiceResource.Sku.Capacity ?? 1;
            PublisherEmail = apiServiceResource.PublisherEmail;
            OrganizationName = apiServiceResource.PublisherName;
            NotificationSenderEmail = apiServiceResource.NotificationSenderEmail;
            ProvisioningState = apiServiceResource.ProvisioningState;
            RuntimeUrl = apiServiceResource.GatewayUrl;
            RuntimeRegionalUrl = apiServiceResource.GatewayRegionalUrl;
            PortalUrl = apiServiceResource.PortalUrl;
            ManagementApiUrl = apiServiceResource.ManagementApiUrl;
            ScmUrl = apiServiceResource.ScmUrl;
            PublicIPAddresses = apiServiceResource.PublicIPAddresses != null ? apiServiceResource.PublicIPAddresses.ToArray() : null;
            PrivateIPAddresses = apiServiceResource.PrivateIPAddresses != null ? apiServiceResource.PrivateIPAddresses.ToArray() : null;
            var staticIPList = new List<string>();
            if (apiServiceResource.PublicIPAddresses != null)
            {
                staticIPList.AddRange(apiServiceResource.PublicIPAddresses);
            }
            if (apiServiceResource.PrivateIPAddresses != null)
            {
                staticIPList.AddRange(apiServiceResource.PrivateIPAddresses);
            }
            StaticIPs = staticIPList.ToArray();
            VpnType = ApiManagementClient.Mapper.Map<string, PsApiManagementVpnType>(apiServiceResource.VirtualNetworkType);            

            if (apiServiceResource.AdditionalLocations != null)
            {
                AdditionalRegions =
                    apiServiceResource.AdditionalLocations
                        .Select(region => new PsApiManagementRegion(region))
                        .ToList();
            }

            if (apiServiceResource.VirtualNetworkConfiguration != null)
            {
                VirtualNetwork = new PsApiManagementVirtualNetwork(apiServiceResource.VirtualNetworkConfiguration);
            }

            if (apiServiceResource.HostnameConfigurations != null &&
                apiServiceResource.HostnameConfigurations.Any())
            {
                var portalHostnameResource = apiServiceResource.HostnameConfigurations.FirstOrDefault(conf => conf.Type == HostnameType.Portal);
                if (portalHostnameResource != null)
                {
                    PortalHostnameConfiguration = new PsApiManagementHostnameConfiguration(portalHostnameResource);
                    PortalCustomHostnameConfiguration = new PsApiManagementCustomHostNameConfiguration(portalHostnameResource);
                }

                var proxyHostnameResources = apiServiceResource.HostnameConfigurations.Where(conf => conf.Type == HostnameType.Proxy);
                if (proxyHostnameResources != null && proxyHostnameResources.Any())
                {
                    ProxyHostnameConfiguration = new PsApiManagementHostnameConfiguration(proxyHostnameResources.First());
                    var proxyCustomHostnameResources = new List<PsApiManagementCustomHostNameConfiguration>();
                    foreach (var proxyHostNameResource in proxyHostnameResources)
                    {
                        proxyCustomHostnameResources.Add(new PsApiManagementCustomHostNameConfiguration(proxyHostNameResource));
                    }

                    ProxyCustomHostnameConfiguration = proxyCustomHostnameResources.ToArray();
                }

                var managementHostnameResource = apiServiceResource.HostnameConfigurations.FirstOrDefault(conf => conf.Type == HostnameType.Management);
                if (managementHostnameResource != null)
                {
                    ManagementHostnameConfiguration = new PsApiManagementHostnameConfiguration(managementHostnameResource);
                    ManagementCustomHostnameConfiguration = new PsApiManagementCustomHostNameConfiguration(managementHostnameResource);
                }

                var scmHostnameResource = apiServiceResource.HostnameConfigurations.FirstOrDefault(conf => conf.Type == HostnameType.Scm);
                if (scmHostnameResource != null)
                {
                    ScmHostnameConfiguration = new PsApiManagementHostnameConfiguration(scmHostnameResource);
                    ScmCustomHostnameConfiguration = new PsApiManagementCustomHostNameConfiguration(scmHostnameResource);
                }
            }

            if (apiServiceResource.Certificates != null && apiServiceResource.Certificates.Any())
            {
                var systemCertificates = new List<PsApiManagementSystemCertificate>();
                foreach(var certificate in apiServiceResource.Certificates)
                {
                    systemCertificates.Add(new PsApiManagementSystemCertificate(certificate));
                }
                SystemCertificates = systemCertificates.ToArray();
            }

            if (apiServiceResource.Tags != null)
            {
                Tags = apiServiceResource.Tags;
            }

            if (apiServiceResource.Identity != null)
            {
                this.Identity = new PsApiManagementServiceIdentity(apiServiceResource.Identity);
            }
        }

        [Obsolete("This property is deprecated and will be removed in a future releases.")]
        public string[] StaticIPs { get; private set; }

        public string[] PublicIPAddresses { get; private set; }

        public string[] PrivateIPAddresses { get; private set; }

        public string Id { get; private set; }

        public string Name { get; private set; }

        public string Location { get; private set; }

        public PsApiManagementSku Sku { get; set; }

        public int Capacity { get; set; }

        public string ProvisioningState { get; private set; }

        public string RuntimeUrl { get; private set; }

        public string RuntimeRegionalUrl { get; private set; }

        public string PortalUrl { get; private set; }

        public string ManagementApiUrl { get; private set; }

        public string ScmUrl { get; private set; }

        public string PublisherEmail { get; set; }

        public string OrganizationName { get; set; }

        public string NotificationSenderEmail { get; set; }

        public PsApiManagementVirtualNetwork VirtualNetwork { get; set; }

        public PsApiManagementVpnType VpnType { get; set; }

        [Obsolete("deprecated. Please use PortalCustomHostnameConfiguration instead.")]
        public PsApiManagementHostnameConfiguration PortalHostnameConfiguration { get; set; }

        [Obsolete("deprecated. Please use ProxyCustomHostnameConfiguration instead.")]
        public PsApiManagementHostnameConfiguration ProxyHostnameConfiguration { get; set; }

        [Obsolete("deprecated. Please use ManagementCustomHostnameConfiguration instead.")]
        public PsApiManagementHostnameConfiguration ManagementHostnameConfiguration { get; set; }

        [Obsolete("deprecated. Please use ScmCustomHostnameConfiguration instead.")]
        public PsApiManagementHostnameConfiguration ScmHostnameConfiguration { get; set; }

        public PsApiManagementCustomHostNameConfiguration PortalCustomHostnameConfiguration { get; set; }

        public PsApiManagementCustomHostNameConfiguration[] ProxyCustomHostnameConfiguration { get; set; }

        public PsApiManagementCustomHostNameConfiguration ManagementCustomHostnameConfiguration { get; set; }

        public PsApiManagementCustomHostNameConfiguration ScmCustomHostnameConfiguration { get; set; }

        public PsApiManagementSystemCertificate[] SystemCertificates { get; set; }

        public IDictionary<string, string> Tags { get; set; }

        public IList<PsApiManagementRegion> AdditionalRegions { get; private set; }

        public PsApiManagementServiceIdentity Identity { get; private set; }

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