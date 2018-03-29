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

namespace Microsoft.Azure.Commands.ApiManagement.Helpers
{
    using AutoMapper;
    using Management.ApiManagement.Models;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Mappers
    {
        public static HostnameType MapHostnameType(PsApiManagementHostnameType hostnameType)
        {
            return Mapper.Map<PsApiManagementHostnameType, HostnameType>(hostnameType);
        }

        public static PsApiManagementHostnameType MapHostnameType(HostnameType hostnameType)
        {
            return Mapper.Map<HostnameType, PsApiManagementHostnameType>(hostnameType);
        }

        public static string MapSku(PsApiManagementSku sku)
        {
            switch (sku)
            {
                case PsApiManagementSku.Developer: return SkuType.Developer;
                case PsApiManagementSku.Standard: return SkuType.Standard;
                case PsApiManagementSku.Premium: return SkuType.Premium;
                case PsApiManagementSku.Basic: return SkuType.Basic;
                default: throw new ArgumentException("Unrecognized Sku");
            }
        }

        public static PsApiManagementSku MapSku(string sku)
        {
            switch (sku)
            {
                case SkuType.Developer: return PsApiManagementSku.Developer;
                case SkuType.Standard: return PsApiManagementSku.Standard;
                case SkuType.Premium: return PsApiManagementSku.Premium;
                case SkuType.Basic: return PsApiManagementSku.Basic;
                default: throw new ArgumentException("Unrecognized Sku");
            }
        }

        public static string MapVirtualNetworkType(PsApiManagementVpnType vpnType)
        {
            switch (vpnType)
            {
                case PsApiManagementVpnType.External: return VirtualNetworkType.External;
                case PsApiManagementVpnType.Internal: return VirtualNetworkType.Internal;
                case PsApiManagementVpnType.None: return VirtualNetworkType.None;
                default: throw new ArgumentException("Unrecognized Virtual Network Type");
            }
        }

        public static ApiManagementServiceResource MapPsApiManagement(PsApiManagement apiManagement)
        {
            var parameters = new ApiManagementServiceResource
            {
                Location = apiManagement.Location,
                PublisherEmail = apiManagement.PublisherEmail,
                PublisherName = apiManagement.OrganizationName,
                NotificationSenderEmail = apiManagement.NotificationSenderEmail,
                VirtualNetworkType = MapVirtualNetworkType(apiManagement.VpnType),
                Sku = new ApiManagementServiceSkuProperties
                {
                    Capacity = apiManagement.Capacity,
                    Name = MapSku(apiManagement.Sku)
                },
                Tags = apiManagement.Tags
            };

            if (apiManagement.VirtualNetwork != null)
            {
                parameters.VirtualNetworkConfiguration = new VirtualNetworkConfiguration
                {
                    SubnetResourceId = apiManagement.VirtualNetwork.SubnetResourceId
                };
            }

            if (apiManagement.AdditionalRegions != null && apiManagement.AdditionalRegions.Any())
            {
                parameters.AdditionalLocations =
                    apiManagement.AdditionalRegions
                        .Select(region =>
                            new AdditionalLocation
                            {
                                Location = region.Location,
                                Sku = new ApiManagementServiceSkuProperties()
                                {
                                    Name = MapSku(region.Sku),
                                    Capacity = region.Capacity
                                },
                                VirtualNetworkConfiguration = region.VirtualNetwork == null
                                    ? null
                                    : new VirtualNetworkConfiguration
                                    {
                                        SubnetResourceId = region.VirtualNetwork.SubnetResourceId
                                    }
                            })
                        .ToList();
            }

            if (apiManagement.ProxyCustomHostnameConfiguration != null || 
                apiManagement.PortalCustomHostnameConfiguration != null ||
                apiManagement.ManagementCustomHostnameConfiguration != null ||
                apiManagement.ScmCustomHostnameConfiguration != null)
            {
                parameters.HostnameConfigurations = new List<HostnameConfiguration>();

                if (apiManagement.ProxyCustomHostnameConfiguration != null)
                {
                    parameters.HostnameConfigurations.Add(apiManagement.ProxyCustomHostnameConfiguration.GetHostnameConfiguration());
                }
                if (apiManagement.PortalCustomHostnameConfiguration != null)
                {
                    parameters.HostnameConfigurations.Add(apiManagement.PortalCustomHostnameConfiguration.GetHostnameConfiguration());
                }
                if (apiManagement.ManagementCustomHostnameConfiguration != null)
                {
                    parameters.HostnameConfigurations.Add(apiManagement.ManagementCustomHostnameConfiguration.GetHostnameConfiguration());
                }
                if (apiManagement.ScmCustomHostnameConfiguration != null)
                {
                    parameters.HostnameConfigurations.Add(apiManagement.ScmCustomHostnameConfiguration.GetHostnameConfiguration());
                }
            }

            if (apiManagement.SystemCertificates != null)
            {
                parameters.Certificates = new List<CertificateConfiguration>();
                foreach(var systemCertificate in apiManagement.SystemCertificates)
                {
                    parameters.Certificates.Add(systemCertificate.GetCertificateConfiguration());
                }
            }

            if (apiManagement.Identity != null)
            {
                parameters.Identity = apiManagement.Identity;
            }

            return parameters;
        }
    }
}
