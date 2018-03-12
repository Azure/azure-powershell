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

using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.Azure.Commands.ApiManagement
{
    using AutoMapper;
    using Common.Authentication.Abstractions;
    using Management.ApiManagement;
    using Management.ApiManagement.Models;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class ApiManagementClient
    {
        private readonly IAzureContext _context;
        private Management.ApiManagement.ApiManagementClient _client;

        public ApiManagementClient(IAzureContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("AzureProfile");
            }

            _context = context;
        }

        private static IMapper _mapper;

        private static readonly object _lock = new object();

        public static IMapper Mapper
        {
            get
            {
                lock(_lock)
                {
                    if (_mapper == null)
                    {
                        var config = new MapperConfiguration(cfg => { });

                        _mapper = config.CreateMapper();
                    }

                    return _mapper;
                }
            }
        }

        private IApiManagementClient Client
        {
            get
            {
                if (_client == null)
                {
                    _client =
                        AzureSession.Instance.ClientFactory.CreateArmClient<Management.ApiManagement.ApiManagementClient>(
                            _context,
                            AzureEnvironment.Endpoint.ResourceManager);
                }

                return _client;
            }
        }

        public PsApiManagement GetApiManagement(string resourceGroupName, string serviceName)
        {
            ApiManagementServiceResource response = Client.ApiManagementService.Get(resourceGroupName, serviceName);
            return new PsApiManagement(response);
        }

        public IEnumerable<PsApiManagement> ListApiManagements(string resourceGroupName)
        {
            var response = Client.ApiManagementService.ListByResourceGroup(resourceGroupName);
            return response.Select(resource => new PsApiManagement(resource));
        }

        public ApiManagementServiceResource CreateApiManagementService(
            string resourceGroupName,
            string serviceName,
            string location,
            string organization,
            string administratorEmail,
            PsApiManagementSku sku = PsApiManagementSku.Developer,
            int capacity = 1,
            PsApiManagementVpnType vpnType = PsApiManagementVpnType.None,
            IDictionary<string, string> tags = null,
            PsApiManagementVirtualNetwork virtualNetwork = null,
            PsApiManagementRegion[] additionalRegions = null)
        {
            var parameters = new ApiManagementServiceResource
            {
                Location = location,
                PublisherEmail = administratorEmail,
                PublisherName = organization,
                VirtualNetworkType = MapVirtualNetworkType(vpnType),
                Sku = new ApiManagementServiceSkuProperties()
                {
                    Capacity = capacity,
                    Name = MapSku(sku)
                },
                Tags = tags
            };

            if (virtualNetwork != null)
            {
                parameters.VirtualNetworkConfiguration = new VirtualNetworkConfiguration
                {                    
                    SubnetResourceId = virtualNetwork.SubnetResourceId
                };
            }

            if (additionalRegions != null && additionalRegions.Any())
            {
                parameters.AdditionalLocations =
                    additionalRegions
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

            var apiManagementResource = Client.ApiManagementService.CreateOrUpdate(resourceGroupName, serviceName, parameters);
            return apiManagementResource;           
        }

        public ApiManagementServiceResource BeginBackupApiManagement(
            string resourceGroupName,
            string serviceName,
            string storageAccountName,
            string storageAccountKey,
            string backupContainer,
            string backupBlob)
        {
            if (string.IsNullOrWhiteSpace(backupBlob))
            {
                backupBlob = string.Format("{0}-{1:yyyy-MM-dd-HH-mm}.apimbackup", serviceName, DateTime.Now);
            }

            var parameters = new ApiManagementServiceBackupRestoreParameters
            {
                StorageAccount = storageAccountName,
                AccessKey = storageAccountKey,
                ContainerName = backupContainer,
                BackupName = backupBlob
            };

            var apiManagementServiceResource = Client.ApiManagementService.Backup(resourceGroupName, serviceName, parameters);
            return apiManagementServiceResource;
        }

        public bool DeleteApiManagement(string resourceGroupName, string serviceName)
        {
            Client.ApiManagementService.Delete(resourceGroupName, serviceName);

            return true;
        }

        public ApiManagementServiceResource RestoreApiManagement(
            string resourceGroupName,
            string serviceName,
            string storageAccountName,
            string storageAccountKey,
            string backupContainer,
            string backupBlob)
        {
            var parameters = new ApiManagementServiceBackupRestoreParameters
            {
                StorageAccount = storageAccountName,
                AccessKey = storageAccountKey,
                ContainerName = backupContainer,
                BackupName = backupBlob
            };

            var apiManagementServiceResource = Client.ApiManagementService.Restore(resourceGroupName, serviceName, parameters);
            return apiManagementServiceResource;
        }

        public ApiManagementServiceResource UpdateDeployment(
            string resourceGroupName,
            string serviceName,
            string location,
            PsApiManagementSku sku,
            int capacity,
            PsApiManagementVirtualNetwork vnetConfiguration,
            PsApiManagementVpnType vpnType,
            IList<PsApiManagementRegion> additionalRegions,
            PsApiManagement apiManagement)
        {
            ApiManagementServiceResource apiManagementParameters;
            if (apiManagement != null)
            {
                apiManagementParameters = MapPsApiManagement(apiManagement);
            }
            else
            {
                apiManagementParameters = Client.ApiManagementService.Get(resourceGroupName, serviceName);
                apiManagementParameters.Sku = new ApiManagementServiceSkuProperties()
                {
                    Name = MapSku(sku),
                    Capacity = capacity
                };

                if (vnetConfiguration != null)
                {
                    apiManagementParameters.VirtualNetworkConfiguration = new VirtualNetworkConfiguration()
                    {
                        SubnetResourceId = vnetConfiguration.SubnetResourceId
                    };
                }

                apiManagementParameters.VirtualNetworkType = MapVirtualNetworkType(vpnType);
                if (additionalRegions != null && additionalRegions.Any())
                {
                    apiManagementParameters.AdditionalLocations = new List<AdditionalLocation>();
                    foreach(var additionalRegion in additionalRegions)
                    {
                        apiManagementParameters.AdditionalLocations.Add(new AdditionalLocation()
                        {
                            Location = additionalRegion.Location,
                            Sku = new ApiManagementServiceSkuProperties()
                            {
                                Name = MapSku(additionalRegion.Sku),
                                Capacity = additionalRegion.Capacity
                            },
                            VirtualNetworkConfiguration = additionalRegion.VirtualNetwork == null ? null :
                            new VirtualNetworkConfiguration()
                            {
                                SubnetResourceId = additionalRegion.VirtualNetwork.SubnetResourceId
                            }
                        });
                    }
                }
            
            }
            var apiManagementService = Client.ApiManagementService.CreateOrUpdate(resourceGroupName, serviceName, apiManagementParameters);
            return apiManagementService;
        }

        public PsApiManagementHostnameCertificate UploadCertificate(
            string resourceGroupName,
            string serviceName,
            PsApiManagementHostnameType hostnameType,
            string pfxPath,
            string pfxPassword)
        {
            byte[] certificate;
            using (var certStream = File.OpenRead(pfxPath))
            {
                certificate = new byte[certStream.Length];
                certStream.Read(certificate, 0, certificate.Length);
            }
            var encodedCertificate = Convert.ToBase64String(certificate);

            var parameters = new ApiManagementServiceUploadCertificateParameters(MapHostnameType(hostnameType), encodedCertificate, pfxPassword);
            var result = Client.ApiManagementService.UploadCertificate(resourceGroupName, serviceName, parameters);

            return new PsApiManagementHostnameCertificate(result);
        }

        public ApiManagementServiceResource SetHostnames(
            string resourceGroupName,
            string serviceName,
            PsApiManagementHostnameConfiguration portalHostnameConfiguration,
            PsApiManagementHostnameConfiguration proxyHostnameConfiguration)
        {
            var currentStateResource = Client.ApiManagementService.Get(resourceGroupName, serviceName);
            var currentState = new PsApiManagement(currentStateResource);

            var parameters = new ApiManagementServiceUpdateHostnameParameters
            {
                Delete = GetHostnamesToDelete(portalHostnameConfiguration, proxyHostnameConfiguration, currentState),
                Update = GetHostnamesToCreateOrUpdate(portalHostnameConfiguration, proxyHostnameConfiguration, currentState).ToList()
            };

            var apiManagementServiceResource = Client.ApiManagementService.UpdateHostname(resourceGroupName, serviceName, parameters);
            return apiManagementServiceResource;
        }

        public string GetSsoToken(string resourceGroupName, string serviceName)
        {
            return Client.ApiManagementService.GetSsoToken(resourceGroupName, serviceName).RedirectUri;
        }

        private static HostnameType MapHostnameType(PsApiManagementHostnameType hostnameType)
        {
            return Mapper.Map<PsApiManagementHostnameType, HostnameType>(hostnameType);
        }

        public static string MapSku(PsApiManagementSku sku)
        {
            switch(sku)
            {
                case PsApiManagementSku.Developer : return SkuType.Developer;
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
            switch(vpnType)
            {
                case PsApiManagementVpnType.External: return VirtualNetworkType.External;
                case PsApiManagementVpnType.Internal: return VirtualNetworkType.Internal;
                case PsApiManagementVpnType.None: return VirtualNetworkType.None;
                default: throw new ArgumentException("Unrecognized Virtual Network Type");
            }
        }

        private static ApiManagementServiceResource MapPsApiManagement(PsApiManagement apiManagement)
        {
            var parameters = new ApiManagementServiceResource
            {
                Location = apiManagement.Location,
                PublisherEmail =apiManagement.PublisherEmail,
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

            return parameters;
        }


        private static IEnumerable<HostnameConfigurationOld> GetHostnamesToCreateOrUpdate(
            PsApiManagementHostnameConfiguration portalHostnameConfiguration,
            PsApiManagementHostnameConfiguration proxyHostnameConfiguration,
            PsApiManagement currentState)
        {
            if (portalHostnameConfiguration != null)
            {
                yield return new HostnameConfigurationOld(
                    HostnameType.Portal,
                    portalHostnameConfiguration.Hostname,
                    new CertificateInformation
                    {
                        Thumbprint = portalHostnameConfiguration.HostnameCertificate.Thumbprint,
                        Subject = string.IsNullOrWhiteSpace(portalHostnameConfiguration.HostnameCertificate.Subject) ? "dummy" : portalHostnameConfiguration.HostnameCertificate.Subject
                    });
            }

            if (proxyHostnameConfiguration != null)
            {
                yield return new HostnameConfigurationOld(
                    HostnameType.Proxy,
                    proxyHostnameConfiguration.Hostname,
                    new CertificateInformation
                    {
                        Thumbprint = proxyHostnameConfiguration.HostnameCertificate.Thumbprint,
                        Subject = string.IsNullOrWhiteSpace(proxyHostnameConfiguration.HostnameCertificate.Subject) ? "dummy" : proxyHostnameConfiguration.HostnameCertificate.Subject
                    });
            }
        }

        private static IList<HostnameType?> GetHostnamesToDelete(
            PsApiManagementHostnameConfiguration portalHostnameConfiguration,
            PsApiManagementHostnameConfiguration proxyHostnameConfiguration,
            PsApiManagement currentState)
        {
            var hostnameToDelete = new List<HostnameType?>();
            if (portalHostnameConfiguration == null && currentState.PortalHostnameConfiguration != null)
            {
                hostnameToDelete.Add(HostnameType.Portal);
            }

            if (proxyHostnameConfiguration == null && currentState.ProxyHostnameConfiguration != null)
            {
                hostnameToDelete.Add(HostnameType.Proxy);
            }

            return hostnameToDelete;
        }
    }
}