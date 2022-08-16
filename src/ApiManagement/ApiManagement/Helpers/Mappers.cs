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
    using Management.ApiManagement.Models;
    using Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public static class Mappers
    {
        public static string MapHostnameType(PsApiManagementHostnameType hostnameType)
        {
            switch(hostnameType)
            {
                case PsApiManagementHostnameType.Proxy: return HostnameType.Proxy;
                case PsApiManagementHostnameType.Portal: return HostnameType.Portal;
                case PsApiManagementHostnameType.Management: return HostnameType.Management;
                case PsApiManagementHostnameType.Scm: return HostnameType.Scm;
                case PsApiManagementHostnameType.DeveloperPortal: return HostnameType.DeveloperPortal;
                default: throw new ArgumentException($"Unrecognized Hostname Type {hostnameType.ToString("G")}.");
            }
        }

        public static PsApiManagementHostnameType MapHostnameType(string hostnameType)
        {
            switch (hostnameType)
            {
                case HostnameType.Proxy: return PsApiManagementHostnameType.Proxy;
                case HostnameType.Portal: return PsApiManagementHostnameType.Portal;
                case HostnameType.Management: return PsApiManagementHostnameType.Management;
                case HostnameType.Scm: return PsApiManagementHostnameType.Scm;
                case HostnameType.DeveloperPortal: return PsApiManagementHostnameType.DeveloperPortal;
                default: throw new ArgumentException("Unrecognized Hostname Type.");
            }
        }

        public static string MapSku(PsApiManagementSku sku)
        {
            switch (sku)
            {
                case PsApiManagementSku.Developer: return SkuType.Developer;
                case PsApiManagementSku.Standard: return SkuType.Standard;
                case PsApiManagementSku.Premium: return SkuType.Premium;
                case PsApiManagementSku.Basic: return SkuType.Basic;
                case PsApiManagementSku.Consumption: return SkuType.Consumption;
                case PsApiManagementSku.Isolated: return SkuType.Isolated;
                default: throw new ArgumentException($"Unrecognized Sku '{sku.ToString()}'");
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
                case SkuType.Consumption: return PsApiManagementSku.Consumption;
                case SkuType.Isolated: return PsApiManagementSku.Isolated;
                default: throw new ArgumentException($"Unrecognized Sku '{sku}'");
            }
        }

        public static string MapVirtualNetworkType(PsApiManagementVpnType vpnType)
        {
            switch (vpnType)
            {
                case PsApiManagementVpnType.External: return VirtualNetworkType.External;
                case PsApiManagementVpnType.Internal: return VirtualNetworkType.Internal;
                case PsApiManagementVpnType.None: return VirtualNetworkType.None;
                default: throw new ArgumentException($"Unrecognized Virtual Network Type '{vpnType.ToString("G")}");
            }
        }

        public static ApiManagementServiceIdentity MapAssignedIdentity(bool createSystemResourceIdentity, string[] userAssignedIdentity)
        {
            ApiManagementServiceIdentity identity = null;

            if (createSystemResourceIdentity || userAssignedIdentity != null)
            {
                identity = new ApiManagementServiceIdentity();

                if (createSystemResourceIdentity && userAssignedIdentity != null)
                {
                    identity.Type = PsApiManagementServiceIdentityTypes.SystemAndUserAssigned;
                }
                else if (createSystemResourceIdentity)
                {
                    identity.Type = PsApiManagementServiceIdentityTypes.SystemAssigned;
                }
                else
                {
                    identity.Type = PsApiManagementServiceIdentityTypes.UserAssigned;
                }

                if (userAssignedIdentity != null)
                {
                    identity.UserAssignedIdentities = userAssignedIdentity.ToDictionary(i => i, i => new UserIdentityProperties());
                }
            }
            return identity;
        }

        public static ApiManagementServiceIdentity MapPsApiManagementIdentity(PsApiManagementServiceIdentity identity)
        {
            if (identity == null)
            {
                return null;
            }

            if(identity.Type == PsApiManagementServiceIdentityTypes.None)
            {
                return new ApiManagementServiceIdentity() { Type = identity.Type.ToString() };
            }

            bool systemAssigned = identity.Type == PsApiManagementServiceIdentityTypes.SystemAssigned || identity.Type == PsApiManagementServiceIdentityTypes.SystemAndUserAssigned;
            string[] userIdentities = identity.UserAssignedIdentity?.Keys.ToArray();

            return MapAssignedIdentity(systemAssigned , userIdentities);
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
                Tags = apiManagement.Tags,
                EnableClientCertificate = apiManagement.EnableClientCertificate,
                Zones = apiManagement.Zone,
                DisableGateway = apiManagement.DisableGateway,
                PublicNetworkAccess = apiManagement.PublicNetworkAccess
            };

            if (apiManagement.VirtualNetwork != null)
            {
                parameters.VirtualNetworkConfiguration = new VirtualNetworkConfiguration
                {
                    SubnetResourceId = apiManagement.VirtualNetwork.SubnetResourceId
                };

                parameters.PublicIpAddressId = apiManagement.PublicIpAddressId;
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
                                    },
                                Zones = region.Zone,
                                DisableGateway = region.DisableGateway,
                                PublicIpAddressId = region.PublicIpAddressId
                            })
                        .ToList();
            }

            if (apiManagement.ProxyCustomHostnameConfiguration != null ||
                apiManagement.PortalCustomHostnameConfiguration != null ||
                apiManagement.ManagementCustomHostnameConfiguration != null ||
                apiManagement.ScmCustomHostnameConfiguration != null ||
                apiManagement.DeveloperPortalHostnameConfiguration != null)
            {
                parameters.HostnameConfigurations = new List<HostnameConfiguration>();

                if (apiManagement.ProxyCustomHostnameConfiguration != null)
                {
                    foreach (var proxyCustomHostnameConfiguration in apiManagement.ProxyCustomHostnameConfiguration)
                    {
                        parameters.HostnameConfigurations.Add(proxyCustomHostnameConfiguration.GetHostnameConfiguration());
                    }
                }
                if (apiManagement.PortalCustomHostnameConfiguration != null)
                {
                    parameters.HostnameConfigurations.Add(apiManagement.PortalCustomHostnameConfiguration.GetHostnameConfiguration());
                }
                if (apiManagement.DeveloperPortalHostnameConfiguration != null)
                {
                    parameters.HostnameConfigurations.Add(apiManagement.DeveloperPortalHostnameConfiguration.GetHostnameConfiguration());
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
                foreach (var systemCertificate in apiManagement.SystemCertificates)
                {
                    parameters.Certificates.Add(systemCertificate.GetCertificateConfiguration());
                }
            }

            if (!string.IsNullOrWhiteSpace(apiManagement.MinimalControlPlaneApiVersion))
            {
                parameters.ApiVersionConstraint = new ApiVersionConstraint()
                {
                    MinApiVersion = apiManagement.MinimalControlPlaneApiVersion
                };
            }

            if (apiManagement.Identity != null)
            {
                parameters.Identity = MapPsApiManagementIdentity(apiManagement.Identity);
            }

            parameters.CustomProperties = MapPsApiManagementSslSetting(apiManagement.SslSetting);

            return parameters;
        }

        public static PsApiManagementNetworkStatus MapPsApiManagementNetworkStatus(NetworkStatusContract networkStatusContract, string location)
        {
            var psNetworkStatus = new PsApiManagementNetworkStatus();
            psNetworkStatus.DnsServers = networkStatusContract.DnsServers.ToArray();
            var aggregateStatus = GetConnectivityStatus(networkStatusContract.ConnectivityStatus);
            psNetworkStatus.ConnectivityStatus = aggregateStatus.ToArray();
            psNetworkStatus.Location = location;

            return psNetworkStatus;
        }

        public static IList<PsApiManagementNetworkStatus> MapPsApiManagementNetworkEnumerable(IList<NetworkStatusContractByLocation> networkStatusList)
        {
            var psNetworkStatusEnumerable = new List<PsApiManagementNetworkStatus>();
            foreach (var statusLocation in networkStatusList)
            {
                var psNetworkStatus = MapPsApiManagementNetworkStatus(statusLocation.NetworkStatus, statusLocation.Location);                
                psNetworkStatusEnumerable.Add(psNetworkStatus);
            }

            return psNetworkStatusEnumerable;
        }

        private static List<PsApiManagementConnectivityStatus> GetConnectivityStatus(IList<ConnectivityStatusContract> status)
        {
            var aggregateStatus = new List<PsApiManagementConnectivityStatus>();
            foreach (var connectivityStatus in status)
            {
                var connectivity = new PsApiManagementConnectivityStatus();
                connectivity.Error = connectivityStatus.Error;
                connectivity.Name = connectivityStatus.Name;
                connectivity.Status = connectivityStatus.Status;
                connectivity.LastStatusChange = connectivityStatus.LastStatusChange;
                connectivity.LastUpdated = connectivityStatus.LastUpdated;
                connectivity.ResourceType = connectivityStatus.ResourceType;
                connectivity.IsOptional = connectivityStatus.IsOptional;
                aggregateStatus.Add(connectivity);
            }

            return aggregateStatus;
        }

        public static Dictionary<string, string> MapPsApiManagementSslSetting(PsApiManagementSslSetting sslSettings)
        {
            if (sslSettings == null)
            {
                return null;
            }

            var customProperties = new Dictionary<string, string>();
            if (sslSettings.FrontendProtocol != null)
            {
                foreach(DictionaryEntry frontend in sslSettings.FrontendProtocol)
                {
                    customProperties.Add(GetSslKey(Constants.FrontendProtocolSettingPrefix, frontend.Key),  frontend.Value.ToString());
                }
            }

            if (sslSettings.BackendProtocol != null)
            {
                foreach (DictionaryEntry backend in sslSettings.BackendProtocol)
                {
                    customProperties.Add(GetSslKey(Constants.BackendProtocolSettingPrefix, backend.Key), backend.Value.ToString());
                }
            }

            if (sslSettings.CipherSuite != null)
            {
                foreach (DictionaryEntry cipherSuite in sslSettings.CipherSuite)
                {
                    customProperties.Add(GetSslKey(Constants.CipherSettingPrefix, cipherSuite.Key), cipherSuite.Value.ToString());
                }
            }

            if (sslSettings.ServerProtocol != null)
            {
                foreach (DictionaryEntry serverProtocol in sslSettings.ServerProtocol)
                {
                    customProperties.Add(GetSslKey(Constants.ServerSettingPrefix, serverProtocol.Key), serverProtocol.Value.ToString());                    
                }
            }

            return customProperties;
        }

        private static string GetSslKey(string prefix, object inputKey)
        {
            return string.Concat(prefix, inputKey.ToString());
        }
    }
}
