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
            bool enableClientCertificate,
            PsApiManagementSku sku = PsApiManagementSku.Developer,
            int? capacity = null,
            PsApiManagementVpnType vpnType = PsApiManagementVpnType.None,
            PsApiManagementVirtualNetwork virtualNetwork = null,
            PsApiManagementRegion[] additionalRegions = null,
            PsApiManagementCustomHostNameConfiguration[] customHostnameConfigurations = null,
            PsApiManagementSystemCertificate[] systemCertificates = null,
            PsApiManagementSslSetting sslSettings = null,
            bool createSystemResourceIdentity = false,
            string[] userAssignedIdentity = null,
            string[] zone = null,
            bool? disableGateway = null,
            string minimalControlPlaneApiVersion = null,
            string publicNetworkAccess = null,
            string publicIpAddressId = null)
        {
            string skuType = Mappers.MapSku(sku);

            if(capacity == null)
            {
                capacity = (sku == PsApiManagementSku.Consumption ? 0 : 1);
            }

            var skuProperties = new ApiManagementServiceSkuProperties(skuType, capacity.Value);

            var parameters = new ApiManagementServiceResource
            {
                Location = location,
                PublisherEmail = administratorEmail,
                PublisherName = organization,
                VirtualNetworkType = Mappers.MapVirtualNetworkType(vpnType),
                Sku = skuProperties,
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
                        .Select(region => region.GetAdditionalLocation())
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

            if (sslSettings != null)
            {
                parameters.CustomProperties = Mappers.MapPsApiManagementSslSetting(sslSettings);
            }

            if (enableClientCertificate)
            {
                parameters.EnableClientCertificate = enableClientCertificate;
            }

            if (zone != null)
            {
                parameters.Zones = zone;
            }

            if (disableGateway != null && disableGateway.HasValue)
            {
                parameters.DisableGateway = disableGateway.Value;
            }

            if (!string.IsNullOrWhiteSpace(minimalControlPlaneApiVersion))
            {
                parameters.ApiVersionConstraint = new ApiVersionConstraint()
                {
                    MinApiVersion = minimalControlPlaneApiVersion
                };
            }

            if (publicIpAddressId != null)
            {
                parameters.PublicIpAddressId = publicIpAddressId;
            }

            if (publicNetworkAccess != null)
            {
                parameters.PublicNetworkAccess = publicNetworkAccess;
            }

            parameters.Identity = Mappers.MapAssignedIdentity(createSystemResourceIdentity, userAssignedIdentity);

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
            string backupBlob,
            string accessType,
            string identityClientId = null)
        {
            if (string.IsNullOrWhiteSpace(backupBlob))
            {
                backupBlob = string.Format("{0}-{1:yyyy-MM-dd-HH-mm}.apimbackup", serviceName, DateTime.Now);
            }

            var parameters = new ApiManagementServiceBackupRestoreParameters
            {
                StorageAccount = storageAccountName,
                ContainerName = backupContainer,
                BackupName = backupBlob,
                AccessType = accessType
            };

            if (!string.IsNullOrWhiteSpace(storageAccountKey))
            {
                parameters.AccessKey = storageAccountKey;
            }

            if (!string.IsNullOrWhiteSpace(identityClientId))
            {
                parameters.ClientId = identityClientId;
            }

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
            string backupBlob,
            string accessType,
            string identityClientId)
        {
            var parameters = new ApiManagementServiceBackupRestoreParameters
            {
                StorageAccount = storageAccountName,
                ContainerName = backupContainer,
                BackupName = backupBlob,
                AccessType = accessType
            };

            if (!string.IsNullOrWhiteSpace(storageAccountKey))
            {
                parameters.AccessKey = storageAccountKey;
            }

            if (!string.IsNullOrWhiteSpace(identityClientId))
            {
                parameters.ClientId = identityClientId;
            }

            var apiManagementServiceResource = Client.ApiManagementService.Restore(resourceGroupName, serviceName, parameters);
            return new PsApiManagement(apiManagementServiceResource);
        }

        public PsApiManagement SetApiManagementService(
            PsApiManagement apiManagement,
            bool createSystemResourceIdentity,
            string[] userAssignedIdentity)
        {
            ApiManagementServiceResource apiManagementParameters = Mappers.MapPsApiManagement(apiManagement);

            apiManagementParameters.Identity = Mappers.MapAssignedIdentity(createSystemResourceIdentity, userAssignedIdentity);

            var apiManagementService = Client.ApiManagementService.CreateOrUpdate(
                apiManagement.ResourceGroupName, 
                apiManagement.Name, 
                apiManagementParameters);
            return new PsApiManagement(apiManagementService);
        }

        public string GetSsoToken(string resourceGroupName, string serviceName)
        {
            return Client.ApiManagementService.GetSsoToken(resourceGroupName, serviceName).RedirectUri;
        }

        public IList<PsApiManagementNetworkStatus> GetNetworkStatus(string resourceGroupName, string serviceName)
        {
            IList<NetworkStatusContractByLocation> networkStatus = Client.NetworkStatus.ListByService(
                resourceGroupName,
                serviceName);

            return Mappers.MapPsApiManagementNetworkEnumerable(networkStatus);
        }

        public PsApiManagementNetworkStatus GetNetworkStatusByLocation(string resourceGroupName, string serviceName, string location)
        {
            NetworkStatusContract networkStatus = Client.NetworkStatus.ListByLocation(
                resourceGroupName,
                serviceName,
                location);

            return Mappers.MapPsApiManagementNetworkStatus(networkStatus, location);
        }
    }
}