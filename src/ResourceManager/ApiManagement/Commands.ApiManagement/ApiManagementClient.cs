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
    using Helpers;
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
            IList<ApiManagementServiceResource> response;
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                response = ListPaged(
                () => Client.ApiManagementService.List(),
                nextLink => Client.ApiManagementService.ListNext(nextLink));
            }
            else
            {
                response = ListPaged(
                () => Client.ApiManagementService.ListByResourceGroup(resourceGroupName),
                nextLink => Client.ApiManagementService.ListByResourceGroupNext(nextLink));
            }
            return response.Select(resource => new PsApiManagement(resource));
        }

        private static IList<T> ListPaged<T>(
            Func<Rest.Azure.IPage<T>> listFirstPage,
            Func<string, Rest.Azure.IPage<T>> listNextPage)
        {
            var resultsList = new List<T>();

            var pagedResponse = listFirstPage();
            resultsList.AddRange(pagedResponse);

            while (!string.IsNullOrEmpty(pagedResponse.NextPageLink))
            {
                pagedResponse = listNextPage(pagedResponse.NextPageLink);
                resultsList.AddRange(pagedResponse);
            }

            return resultsList;
        }

        public PsApiManagement CreateApiManagementService(
            string resourceGroupName,
            string serviceName,
            string location,
            string organization,
            string administratorEmail,
            Dictionary<string, string> tags,
            PsApiManagementSku sku = PsApiManagementSku.Developer,
            int capacity = 1,
            PsApiManagementVpnType vpnType = PsApiManagementVpnType.None,            
            PsApiManagementVirtualNetwork virtualNetwork = null,
            PsApiManagementRegion[] additionalRegions = null,
            PsApiManagementCustomHostNameConfiguration[] customHostnameConfigurations = null,
            PsApiManagementSystemCertificate[] systemCertificates = null,
            bool createResourceIdentity = false)
        {
            var parameters = new ApiManagementServiceResource
            {
                Location = location,
                PublisherEmail = administratorEmail,
                PublisherName = organization,
                VirtualNetworkType = Mappers.MapVirtualNetworkType(vpnType),
                Sku = new ApiManagementServiceSkuProperties()
                {
                    Capacity = capacity,
                    Name = Mappers.MapSku(sku)
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
                                    Name = Mappers.MapSku(region.Sku),
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

            if (customHostnameConfigurations != null)
            {
                parameters.HostnameConfigurations = BuildHostNameConfiguration(customHostnameConfigurations);
            }

            if (systemCertificates != null)
            {
                parameters.Certificates = new List<CertificateConfiguration>();
                foreach(var systemCertificate in systemCertificates)
                {
                    var certificateConfig = systemCertificate.GetCertificateConfiguration();
                    parameters.Certificates.Add(certificateConfig);
                }
            }

            if (createResourceIdentity)
            {
                parameters.Identity = new ApiManagementServiceIdentity();
            }

            var apiManagementResource = Client.ApiManagementService.CreateOrUpdate(resourceGroupName, serviceName, parameters);
            return new PsApiManagement(apiManagementResource);      
        }

        IList<HostnameConfiguration> BuildHostNameConfiguration(PsApiManagementCustomHostNameConfiguration[] pshostnameConfigurations)
        {
            var hostnameConfigurations = new List<HostnameConfiguration>();
            foreach (var psHostnameConfig in pshostnameConfigurations)
            {
                var customHostnameConfig = psHostnameConfig.GetHostnameConfiguration();
                if (customHostnameConfig != null)
                {                   
                    hostnameConfigurations.Add(customHostnameConfig);
                }
            }
            return hostnameConfigurations;
        }

        public PsApiManagement BackupApiManagement(
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
            return new PsApiManagement(apiManagementServiceResource);
        }

        public bool DeleteApiManagement(string resourceGroupName, string serviceName)
        {
            Client.ApiManagementService.Delete(resourceGroupName, serviceName);

            return true;
        }

        public PsApiManagement RestoreApiManagement(
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
            return new PsApiManagement(apiManagementServiceResource);
        }

        public PsApiManagement UpdateDeployment(
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
                apiManagementParameters = Mappers.MapPsApiManagement(apiManagement);
            }
            else
            {
                apiManagementParameters = Client.ApiManagementService.Get(resourceGroupName, serviceName);
                apiManagementParameters.Sku = new ApiManagementServiceSkuProperties()
                {
                    Name = Mappers.MapSku(sku),
                    Capacity = capacity
                };

                if (vnetConfiguration != null)
                {
                    apiManagementParameters.VirtualNetworkConfiguration = new VirtualNetworkConfiguration()
                    {
                        SubnetResourceId = vnetConfiguration.SubnetResourceId
                    };
                }

                apiManagementParameters.VirtualNetworkType = Mappers.MapVirtualNetworkType(vpnType);
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
                                Name = Mappers.MapSku(additionalRegion.Sku),
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
            return new PsApiManagement(apiManagementService);
        }

        public PsApiManagement SetApiManagementService(
            PsApiManagement apiManagement,
            bool createResourceIdentity)
        {
            ApiManagementServiceResource apiManagementParameters = Mappers.MapPsApiManagement(apiManagement);

            if (createResourceIdentity)
            {
                apiManagementParameters.Identity = new ApiManagementServiceIdentity();
            }

            var apiManagementService = Client.ApiManagementService.CreateOrUpdate(
                apiManagement.ResourceGroupName, 
                apiManagement.Name, 
                apiManagementParameters);
            return new PsApiManagement(apiManagementService);
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

            var parameters = new ApiManagementServiceUploadCertificateParameters(Mappers.MapHostnameType(hostnameType), encodedCertificate, pfxPassword);
            var result = Client.ApiManagementService.UploadCertificate(resourceGroupName, serviceName, parameters);

            return new PsApiManagementHostnameCertificate(result);
        }

        public PsApiManagement SetHostnames(
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
            return new PsApiManagement(apiManagementServiceResource);
        }

        public string GetSsoToken(string resourceGroupName, string serviceName)
        {
            return Client.ApiManagementService.GetSsoToken(resourceGroupName, serviceName).RedirectUri;
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