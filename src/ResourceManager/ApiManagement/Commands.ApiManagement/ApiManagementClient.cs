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
using Microsoft.Azure.Commands.Common.Authentication.Models;

namespace Microsoft.Azure.Commands.ApiManagement
{
    using AutoMapper;
    using Management.ApiManagement;
    using Management.ApiManagement.Models;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class ApiManagementClient
    {
        private readonly AzureContext _context;
        private Management.ApiManagement.ApiManagementClient _client;

        public ApiManagementClient(AzureContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("AzureProfile");
            }

            _context = context;
        }

        private IApiManagementClient Client
        {
            get
            {
                if (_client == null)
                {
                    _client =
                        AzureSession.ClientFactory.CreateClient<Management.ApiManagement.ApiManagementClient>(
                            _context,
                            AzureEnvironment.Endpoint.ResourceManager);
                }

                return _client;
            }
        }

        public PsApiManagement GetApiManagement(string resourceGroupName, string serviceName)
        {
            ApiServiceGetResponse response = Client.ResourceProvider.Get(resourceGroupName, serviceName);
            return new PsApiManagement(response.Value);
        }

        public IEnumerable<PsApiManagement> ListApiManagements(string resourceGroupName)
        {
            var response = Client.ResourceProvider.List(resourceGroupName);
            return response.Value.Select(resource => new PsApiManagement(resource));
        }

        public ApiManagementLongRunningOperation BeginCreateApiManagementService(
            string resourceGroupName,
            string serviceName,
            string location,
            string organization,
            string administratorEmail,
            PsApiManagementSku sku = PsApiManagementSku.Developer,
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

            var longrunningResponse = Client.ResourceProvider.BeginCreatingOrUpdating(resourceGroupName, serviceName, parameters);
            AdjustRetryAfter(longrunningResponse, _client.LongRunningOperationInitialTimeout);
            return ApiManagementLongRunningOperation.CreateLongRunningOperation("New-AzureRmApiManagement", longrunningResponse);
        }

        public ApiManagementLongRunningOperation BeginBackupApiManagement(
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

            var parameters = new ApiServiceBackupRestoreParameters
            {
                StorageAccount = storageAccountName,
                AccessKey = storageAccountKey,
                ContainerName = backupContainer,
                BackupName = backupBlob
            };

            var longrunningResponse = Client.ResourceProvider.BeginBackup(resourceGroupName, serviceName, parameters);
            AdjustRetryAfter(longrunningResponse, _client.LongRunningOperationInitialTimeout);
            return ApiManagementLongRunningOperation.CreateLongRunningOperation("Backup-AzureRmApiManagement", longrunningResponse);
        }

        public bool DeleteApiManagement(string resourceGroupName, string serviceName)
        {
            Client.ResourceProvider.Delete(resourceGroupName, serviceName);

            return true;
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

            var longrunningResponse = Client.ResourceProvider.BeginRestoring(resourceGroupName, serviceName, parameters);
            AdjustRetryAfter(longrunningResponse, _client.LongRunningOperationInitialTimeout);
            return ApiManagementLongRunningOperation.CreateLongRunningOperation("Restore-AzureRmApiManagement", longrunningResponse);
        }

        public ApiManagementLongRunningOperation BeginUpdateDeployments(
            string resourceGroupName,
            string serviceName,
            string location,
            PsApiManagementSku sku,
            int capacity,
            PsApiManagementVirtualNetwork vnetConfiguration,
            IList<PsApiManagementRegion> additionalRegions)
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

            var longrunningResponse = Client.ResourceProvider.BeginManagingDeployments(resourceGroupName, serviceName, parameters);
            AdjustRetryAfter(longrunningResponse, _client.LongRunningOperationInitialTimeout);
            return ApiManagementLongRunningOperation.CreateLongRunningOperation("Update-AzureRmApiManagementDeployment", longrunningResponse);
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

            var parameters = new ApiServiceUploadCertificateParameters(MapHostnameType(hostnameType), encodedCertificate, pfxPassword);
            var result = Client.ResourceProvider.UploadCertificate(resourceGroupName, serviceName, parameters);

            return new PsApiManagementHostnameCertificate(result.Value);
        }

        public ApiManagementLongRunningOperation BeginSetHostnames(
            string resourceGroupName,
            string serviceName,
            PsApiManagementHostnameConfiguration portalHostnameConfiguration,
            PsApiManagementHostnameConfiguration proxyHostnameConfiguration)
        {
            var currentStateResource = Client.ResourceProvider.Get(resourceGroupName, serviceName);
            var currentState = new PsApiManagement(currentStateResource.Value);

            var parameters = new ApiServiceUpdateHostnameParameters
            {
                HostnamesToDelete = GetHostnamesToDelete(portalHostnameConfiguration, proxyHostnameConfiguration, currentState).ToList(),
                HostnamesToCreateOrUpdate = GetHostnamesToCreateOrUpdate(portalHostnameConfiguration, proxyHostnameConfiguration, currentState).ToList()
            };

            var longrunningResponse = Client.ResourceProvider.BeginUpdatingHostname(resourceGroupName, serviceName, parameters);
            AdjustRetryAfter(longrunningResponse, _client.LongRunningOperationInitialTimeout);
            return ApiManagementLongRunningOperation.CreateLongRunningOperation("Set-AzureRmApiManagementHostnames", longrunningResponse);
        }

        public string GetSsoToken(string resourceGroupName, string serviceName)
        {
            return Client.ResourceProvider.GetSsoToken(resourceGroupName, serviceName).RedirectUrl;
        }

        public ApiManagementLongRunningOperation BeginManageVirtualNetworks(
            string resourceGroupName,
            string serviceName,
            IList<PsApiManagementVirtualNetwork> virtualNetworks)
        {
            var parameters = new ApiServiceManageVirtualNetworksParameters
            {
                VirtualNetworkConfigurations = (virtualNetworks == null || virtualNetworks.Count == 0)
                    ? null
                    : virtualNetworks.Select(vn =>
                        new VirtualNetworkConfiguration
                        {
                            Location = vn.Location,
                            SubnetName = vn.SubnetName,
                            VnetId = vn.VnetId
                        }).ToList()
            };

            var longrunningResponse = Client.ResourceProvider.BeginManagingVirtualNetworks(resourceGroupName, serviceName, parameters);
            AdjustRetryAfter(longrunningResponse, _client.LongRunningOperationInitialTimeout);
            return ApiManagementLongRunningOperation.CreateLongRunningOperation("Set-AzureRmApiManagementVirtualNetworks", longrunningResponse);
        }

        internal ApiManagementLongRunningOperation GetLongRunningOperationStatus(ApiManagementLongRunningOperation longRunningOperation)
        {
            var response =
                Client.ResourceProvider
                    .GetApiServiceLongRunningOperationStatusAsync(longRunningOperation.OperationLink)
                    .ConfigureAwait(false)
                    .GetAwaiter()
                    .GetResult();

            AdjustRetryAfter(response, _client.LongRunningOperationInitialTimeout);
            var result = ApiManagementLongRunningOperation.CreateLongRunningOperation(longRunningOperation.OperationName, response);

            return result;
        }

        private static void AdjustRetryAfter(LongRunningOperationResponse longrunningResponse, int longRunningOperationInitialTimeout)
        {
            if (longRunningOperationInitialTimeout >= 0)
            {
                longrunningResponse.RetryAfter = longRunningOperationInitialTimeout;
            }
        }

        private static HostnameType MapHostnameType(PsApiManagementHostnameType hostnameType)
        {
            return Mapper.Map<PsApiManagementHostnameType, HostnameType>(hostnameType);
        }

        private static SkuType MapSku(PsApiManagementSku sku)
        {
            return Mapper.Map<PsApiManagementSku, SkuType>(sku);
        }

        private static IEnumerable<HostnameConfiguration> GetHostnamesToCreateOrUpdate(
            PsApiManagementHostnameConfiguration portalHostnameConfiguration,
            PsApiManagementHostnameConfiguration proxyHostnameConfiguration,
            PsApiManagement currentState)
        {
            if (portalHostnameConfiguration != null)
            {
                yield return new HostnameConfiguration(
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
                yield return new HostnameConfiguration(
                    HostnameType.Proxy,
                    proxyHostnameConfiguration.Hostname,
                    new CertificateInformation
                    {
                        Thumbprint = proxyHostnameConfiguration.HostnameCertificate.Thumbprint,
                        Subject = string.IsNullOrWhiteSpace(proxyHostnameConfiguration.HostnameCertificate.Subject) ? "dummy" : proxyHostnameConfiguration.HostnameCertificate.Subject
                    });
            }
        }

        private static IEnumerable<HostnameType> GetHostnamesToDelete(
            PsApiManagementHostnameConfiguration portalHostnameConfiguration,
            PsApiManagementHostnameConfiguration proxyHostnameConfiguration,
            PsApiManagement currentState)
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