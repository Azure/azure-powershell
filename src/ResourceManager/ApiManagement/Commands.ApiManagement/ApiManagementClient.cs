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

namespace Microsoft.Azure.Commands.ApiManagement
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using AutoMapper;
    using Microsoft.Azure.Commands.ApiManagement.Models;
    using Microsoft.Azure.Common.Authentication;
    using Microsoft.Azure.Common.Authentication.Models;
    using Microsoft.Azure.Management.ApiManagement;
    using Microsoft.Azure.Management.ApiManagement.Models;

    public class ApiManagementClient
    {
        private readonly AzureContext _context;
        private Management.ApiManagement.ApiManagementClient _client;

        public ApiManagementClient(AzureContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            _context = context;
        }

        public ApiManagement GetApiManagement(string resourceGroupName, string serviceName)
        {
#if DEBUG
            //var resource = new ApiServiceResource
            //{
            //    Id = string.Format("/resourceGroups/{0}/providers/Azure.ApiManagement/{1}", resourceGroupName, serviceName),
            //    Name = serviceName,
            //    Location = "Central US",
            //    Properties = new ApiServiceProperties
            //    {
            //        SkuProperties = new ApiServiceSkuProperties
            //        {
            //            SkuType = SkuType.Developer,
            //            Capacity = 1
            //        },
            //        ProvisioningState = "Succeeded",
            //        ProxyEndpoint = "sdsdsdsd",
            //        ManagementPortalEndpoint = "wewewewe",
            //        StaticIPs = new string[0]
            //    }
            //};

            //return new ApiManagement(resource);
#endif
            ApiServiceGetResponse response = Client.ApiManagement.Get(resourceGroupName, serviceName);
            return new ApiManagement(response.Value);
        }

        public IEnumerable<ApiManagement> ListApiManagements(string resourceGroupName)
        {
            var response = Client.ApiManagement.List(resourceGroupName);
            return response.Value.Select(resource => new ApiManagement(resource));
        }

        public ApiManagementLongRunningOperation BeginCreateApiManagementService(
            string resourceGroupName,
            string serviceName,
            string location,
            string organization,
            string administratorEmail,
            ApiManagementSku sku = ApiManagementSku.Developer,
            int capacity = 1,
            IDictionary<string, string> tags = null)
        {
            var parameters = new ApiServiceCreateOrUpdateParameters
            {
                Location = location,
                Properties = new ApiServiceProperties
                {
                    SkuProperties = new ApiServiceSkuProperties
                    {
                        Capacity = capacity,
                        SkuType = MapSku(sku)
                    },
                    PublisherEmail = administratorEmail,
                    PublisherName = organization
                },
                Tags = tags
            };

#if DEBUG
            //var longrunningResponse = new ApiServiceLongRunningOperationResponse
            //{
            //    Status = OperationStatus.Succeeded,
            //    Value = new ApiServiceResource
            //    {
            //        Id = string.Format("/resourceGroups/{0}/providers/Azure.ApiManagement/{1}", resourceGroupName, serviceName),
            //        Name = serviceName,
            //        Location = location,
            //        Properties = new ApiServiceProperties
            //        {
            //            SkuProperties = new ApiServiceSkuProperties
            //            {
            //                SkuType = Mapper.Map<ApiManagementSku, SkuType>(sku),
            //                Capacity = capacity
            //            },
            //            ProvisioningState = "Succeeded",
            //            ProxyEndpoint = "sdsdsdsd",
            //            ManagementPortalEndpoint = "wewewewe",
            //            StaticIPs = new string[0]
            //        }
            //    }
            //};
#endif

            var longrunningResponse = Client.ApiManagement.BeginCreatingOrUpdating(resourceGroupName, serviceName, parameters);
            return ApiManagementLongRunningOperation.CreateLongRunningOperation("New-AzureApiManagement", longrunningResponse);
        }

        public ApiManagementLongRunningOperation GetLongRunningOperationStatus(ApiManagementLongRunningOperation longRunningOperation)
        {
            var response =
                Client.ApiManagement
                    .GetApiServiceLongRunningOperationStatusAsync(longRunningOperation.OperationLink)
                    .ConfigureAwait(false)
                    .GetAwaiter()
                    .GetResult();

            var result = ApiManagementLongRunningOperation.CreateLongRunningOperation(longRunningOperation.OperationName, response);

            return result;
        }

        public ApiManagementLongRunningOperation BeginBackupApiManagement(
            string resourceGroupName,
            string serviceName,
            string storageAccountName,
            string storageAccountKey,
            string backupContainer,
            string backupBlob)
        {
            var parameters = new ApiServiceBackupRestoreParameters
            {
                StorageAccount = storageAccountName,
                AccessKey = storageAccountKey,
                ContainerName = backupContainer,
                BackupName = backupBlob
            };

            var longrunningResponse = Client.ApiManagement.BeginBackup(resourceGroupName, serviceName, parameters);
            return ApiManagementLongRunningOperation.CreateLongRunningOperation("Backup-AzureApiManagement", longrunningResponse);
        }

        public void DeleteApiManagement(string resourceGroupName, string serviceName)
        {
            Client.ApiManagement.Delete(resourceGroupName, serviceName);
        }

        public ApiManagementLongRunningOperation BeginRestoreApiManagement(
            string resourceGroupName,
            string serviceName,
            string storageAccountName,
            string storageAccountKey,
            string backupContainer,
            string backupBlob)
        {
            var parameters = new ApiServiceBackupRestoreParameters
            {
                StorageAccount = storageAccountName,
                AccessKey = storageAccountKey,
                ContainerName = backupContainer,
                BackupName = backupBlob
            };

            var longrunningResponse = Client.ApiManagement.BeginRestoring(resourceGroupName, serviceName, parameters);
            return ApiManagementLongRunningOperation.CreateLongRunningOperation("Restore-AzureApiManagement", longrunningResponse);
        }

        public ApiManagementLongRunningOperation BeginManageDeployments(
            string resourceGroupName,
            string serviceName,
            string location,
            ApiManagementSku sku,
            int capacity,
            ApiManagementVirtualNetwork vnetConfiguration,
            IList<ApiManagementRegion> additionalRegions)
        {
            var parameters = new ApiServiceManageDeploymentsParameters(location, MapSku(sku))
            {
                SkuUnitCount = capacity
            };

            if (vnetConfiguration != null)
            {
                parameters.VirtualNetworkConfiguration = new VirtualNetworkConfiguration
                {
                    Location = vnetConfiguration.Location,
                    SubnetName = vnetConfiguration.SubnetName,
                    VnetId = vnetConfiguration.VnetId
                };
            }

            if (additionalRegions != null && additionalRegions.Any())
            {
                parameters.AdditionalRegions =
                    additionalRegions
                        .Select(region =>
                            new AdditionalRegion
                            {
                                Location = region.Location,
                                SkuType = MapSku(region.Sku),
                                SkuUnitCount = region.Capacity,
                                VirtualNetworkConfiguration = region.VirtualNetwork == null
                                    ? null
                                    : new VirtualNetworkConfiguration
                                    {
                                        Location = region.VirtualNetwork.Location,
                                        SubnetName = region.VirtualNetwork.SubnetName,
                                        VnetId = region.VirtualNetwork.VnetId
                                    }
                            })
                        .ToList();
            }

            var longrunningResponse = Client.ApiManagement.BeginManagingDeployments(resourceGroupName, serviceName, parameters);
            return ApiManagementLongRunningOperation.CreateLongRunningOperation("Set-AzureApiManagementDeployment", longrunningResponse);
        }

        public ApiManagementCertificate UploadCertificate(
            string resourceGroupName,
            string serviceName,
            ApiManagementHostnameType hostnameType,
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

            var parameters = new ApiServiceUploadCertificateParameters(MapHostnameType(hostnameType), encodedCertificate, pfxPassword);
            var result = Client.ApiManagement.UploadCertificate(resourceGroupName, serviceName, parameters);

            return new ApiManagementCertificate(hostnameType, result.Value);
        }

        public ApiManagementLongRunningOperation BeginSetHostname(
            string resourceGroupName,
            string serviceName,
            ApiManagementHostnameConfiguration portalHostnameConfiguration,
            ApiManagementHostnameConfiguration proxyHostnameConfiguration)
        {
            var currentStateResource = Client.ApiManagement.Get(resourceGroupName, serviceName);
            var currentState = new ApiManagement(currentStateResource.Value);

            var parameters = new ApiServiceUpdateHostnameParameters
            {
                HostnamesToDelete = GetHostnamesToDelete(portalHostnameConfiguration, proxyHostnameConfiguration, currentState).ToList(),
                HostnamesToCreateOrUpdate = GetHostnamesToCreateOrUpdate(portalHostnameConfiguration, proxyHostnameConfiguration, currentState).ToList()
            };

            var longrunningResponse = Client.ApiManagement.BeginUpdatingHostname(resourceGroupName, serviceName, parameters);
            return ApiManagementLongRunningOperation.CreateLongRunningOperation("Set-AzureApiManagementHostname", longrunningResponse);
        }

        public string GetSsoToken(string resourceGroupName, string serviceName)
        {
            return Client.ApiManagement.GetSsoToken(resourceGroupName, serviceName).RedirectUrl;
        }

        private IApiManagementClient Client
        {
            get
            {
                //if (_client == null)
                {
                    _client =
                        AzureSession.ClientFactory.CreateClient<Management.ApiManagement.ApiManagementClient>(
                            _context,
                            AzureEnvironment.Endpoint.ResourceManager);
                }

                return _client;
            }
        }

        private static HostnameType MapHostnameType(ApiManagementHostnameType hostnameType)
        {
            return Mapper.Map<ApiManagementHostnameType, HostnameType>(hostnameType);
        }

        private static SkuType MapSku(ApiManagementSku sku)
        {
            return Mapper.Map<ApiManagementSku, SkuType>(sku);
        }

        private static IEnumerable<HostnameConfiguration> GetHostnamesToCreateOrUpdate(
            ApiManagementHostnameConfiguration portalHostnameConfiguration,
            ApiManagementHostnameConfiguration proxyHostnameConfiguration,
            ApiManagement currentState)
        {
            if (portalHostnameConfiguration != null && currentState.PortalHostnameConfiguration != null)
            {
                yield return new HostnameConfiguration(
                    HostnameType.Portal,
                    portalHostnameConfiguration.Hostname,
                    new CertificateInformation(
                        portalHostnameConfiguration.Certificate.Expiry,
                        portalHostnameConfiguration.Certificate.Thumbprint,
                        portalHostnameConfiguration.Certificate.Subject));
            }

            if (proxyHostnameConfiguration != null && currentState.ProxyHostnameConfiguration != null)
            {
                yield return new HostnameConfiguration(
                    HostnameType.Proxy,
                    proxyHostnameConfiguration.Hostname,
                    new CertificateInformation(
                        proxyHostnameConfiguration.Certificate.Expiry,
                        proxyHostnameConfiguration.Certificate.Thumbprint,
                        proxyHostnameConfiguration.Certificate.Subject));
            }
        }

        private static IEnumerable<HostnameType> GetHostnamesToDelete(
            ApiManagementHostnameConfiguration portalHostnameConfiguration,
            ApiManagementHostnameConfiguration proxyHostnameConfiguration,
            ApiManagement currentState)
        {
            if (portalHostnameConfiguration == null && currentState.PortalHostnameConfiguration != null)
            {
                yield return HostnameType.Portal;
            }

            if (proxyHostnameConfiguration == null && currentState.ProxyHostnameConfiguration != null)
            {
                yield return HostnameType.Proxy;
            }
        }
    }
}