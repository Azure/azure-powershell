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
//

namespace Microsoft.Azure.Commands.ApiManagement
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Microsoft.Azure.Commands.ApiManagement.Models;
    using Microsoft.Azure.Common.Extensions;
    using Microsoft.Azure.Common.Extensions.Models;
    using Microsoft.Azure.Management.ApiManagement;
    using Microsoft.Azure.Management.ApiManagement.Models;

    public class ApiManagementClient
    {
        private readonly AzureContext _context;

        public ApiManagementClient(AzureContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            _context = context;
        }

        public ApiManagementAttributes GetApiManagement(string resourceGroupName, string name)
        {
            using (var client = GetClient())
            {
                ApiServiceGetResponse response = client.ApiManagement.Get(resourceGroupName, name);
                return new ApiManagementAttributes(response.Value);
            }
        }

        public IEnumerable<ApiManagementAttributes> ListApiManagements(string resourceGroupName)
        {
            using (var client = GetClient())
            {
                ApiServiceListResponse response = client.ApiManagement.List(resourceGroupName);
                return response.Value.Select(resource => new ApiManagementAttributes(resource));
            }
        }

        public ApiManagementLongRunningOperation BeginCreateApiManagementService(
            string resourceGroupName, 
            string serviceName, 
            string location, 
            string organization, 
            string administratorEmail, 
            ApiManagementSku sku = ApiManagementSku.Developer, 
            int capacity = 1)
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
                }
            };

            using (var client = GetClient())
            {
                var longrunningResponse = client.ApiManagement.BeginCreatingOrUpdating(resourceGroupName, serviceName, parameters);
                return ApiManagementLongRunningOperation.CreateLongRunningOperation(longrunningResponse);
            }
        }

        public ApiManagementLongRunningOperation GetLongRunningOperationStatus(ApiManagementLongRunningOperation longRunningOperation)
        {
            using (var client = GetClient())
            {
                var response = client.ApiManagement.GetApiServiceLongRunningOperationStatus(longRunningOperation.OperationLink);
                return ApiManagementLongRunningOperation.CreateLongRunningOperation(response);
            }
        }

        public ApiManagementLongRunningOperation BeginBackupApiManagement(
            string resourceGroupName, 
            string serviceName, 
            string storageAccountName, 
            string storageAccountKey, 
            string backupContainer, 
            string backupBlob)
        {
            using (var client = GetClient())
            {
                var parameters = new ApiServiceBackupRestoreParameters
                {
                    StorageAccount = storageAccountName,
                    AccessKey = storageAccountKey,
                    ContainerName = backupContainer,
                    BackupName = backupBlob
                };

                var longrunningResponse = client.ApiManagement.BeginBackup(resourceGroupName, serviceName, parameters);
                return ApiManagementLongRunningOperation.CreateLongRunningOperation(longrunningResponse);
            }
        }

        public void DeleteApiManagement(string resourceGroupName, string serviceName)
        {
            using (var client = GetClient())
            {
                client.ApiManagement.Delete(resourceGroupName, serviceName);
            }
        }

        public ApiManagementLongRunningOperation BeginRestoreApiManagement(
            string resourceGroupName,
            string serviceName,
            string storageAccountName,
            string storageAccountKey,
            string backupContainer,
            string backupBlob)
        {
            using (var client = GetClient())
            {
                var parameters = new ApiServiceBackupRestoreParameters
                {
                    StorageAccount = storageAccountName,
                    AccessKey = storageAccountKey,
                    ContainerName = backupContainer,
                    BackupName = backupBlob
                };

                var longrunningResponse = client.ApiManagement.BeginRestoring(resourceGroupName, serviceName, parameters);
                return ApiManagementLongRunningOperation.CreateLongRunningOperation(longrunningResponse);
            }
        }

        public ApiManagementLongRunningOperation BeginManageDeployments(
            string resourceGroupName, 
            string serviceName,
            string location,
            ApiManagementSku sku, 
            int capacity, 
            VirtualNetworkConfigurationAttributes vnetConfiguration, 
            IEnumerable<ApiManagementRegionAttributes> additionalRegions)
        {
            using (var client = GetClient())
            {
                var parameters = new ApiServiceManageDeploymentsParameters(location, MapSku(sku))
                {
                    SkuUnitCount = capacity,
                    VirtualNetworkConfiguration = new VirtualNetworkConfiguration
                    {
                        Location = vnetConfiguration.Location,
                        SubnetName = vnetConfiguration.SubnetName,
                        VnetId = vnetConfiguration.VnetId
                    }
                };

                var longrunningResponse = client.ApiManagement.BeginManagingDeployments(resourceGroupName, serviceName, parameters);
                return ApiManagementLongRunningOperation.CreateLongRunningOperation(longrunningResponse);
            }
        }

        public ApiManagementCertificateAttributes UploadCertificate(
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
            string encodedCertificate = Convert.ToBase64String(certificate);

            using (var client = GetClient())
            {
                var parameters = new ApiServiceUploadCertificateParameters(MapHostnameType(hostnameType), encodedCertificate, pfxPassword);
                var result = client.ApiManagement.UploadCertificate(resourceGroupName, serviceName, parameters);

                return new ApiManagementCertificateAttributes(hostnameType, result.Value);
            }
        }

        public ApiManagementLongRunningOperation BeginUpdateHostname(
            string resourceGroupName, 
            string serviceName, 
            ApiManagementHostnameAtributes portalHostnameConfiguration, 
            ApiManagementHostnameAtributes proxyHostnameConfiguration)
        {
            using (var client = GetClient())
            {
                var currentStateResource = client.ApiManagement.Get(resourceGroupName, serviceName);
                var currentState = new ApiManagementAttributes(currentStateResource.Value);

                var parameters = new ApiServiceUpdateHostnameParameters
                {
                    HostnamesToDelete = GetHostnamesToDelete(portalHostnameConfiguration, proxyHostnameConfiguration, currentState).ToList(),
                    HostnamesToCreateOrUpdate = GetHostnamesToCreateOrUpdate(portalHostnameConfiguration, proxyHostnameConfiguration, currentState).ToList()
                };

                var longrunningResponse = client.ApiManagement.BeginUpdatingHostname(resourceGroupName, serviceName, parameters);
                return ApiManagementLongRunningOperation.CreateLongRunningOperation(longrunningResponse);
            }
        }

        private Management.ApiManagement.ApiManagementClient GetClient()
        {
            return AzureSession.ClientFactory.CreateClient<Management.ApiManagement.ApiManagementClient>(_context, AzureEnvironment.Endpoint.ResourceManager);
        }

        private static HostnameType MapHostnameType(ApiManagementHostnameType hostnameType)
        {
            switch (hostnameType)
            {
                case ApiManagementHostnameType.Portal:
                    return HostnameType.Portal;
                case ApiManagementHostnameType.Proxy:
                    return HostnameType.Proxy;
                default:
                    throw new NotSupportedException(string.Format("Hostname type {0} is not supported", hostnameType));
            }
        }

        private static SkuType MapSku(ApiManagementSku sku)
        {
            switch (sku)
            {
                case ApiManagementSku.Developer:
                    return SkuType.Developer;
                case ApiManagementSku.Standard:
                    return SkuType.Standard;
                case ApiManagementSku.Premium:
                    return SkuType.Premium;
                default:
                    throw new NotSupportedException(string.Format("Sku {0} is not supported", sku));
            }
        }

        private IEnumerable<HostnameConfiguration> GetHostnamesToCreateOrUpdate(
            ApiManagementHostnameAtributes portalHostnameConfiguration,
            ApiManagementHostnameAtributes proxyHostnameConfiguration,
            ApiManagementAttributes currentState)
        {
            if (portalHostnameConfiguration != null && currentState.PortalHostnameConfiguration != null)
            {
                yield return new HostnameConfiguration(
                    HostnameType.Portal,
                    portalHostnameConfiguration.Hostname,
                    new CertificateInformation(
                        portalHostnameConfiguration.CertificateAttributes.Expiry,
                        portalHostnameConfiguration.CertificateAttributes.Thumbprint,
                        portalHostnameConfiguration.CertificateAttributes.Subject));
            }

            if (proxyHostnameConfiguration != null && currentState.ProxyHostnameConfiguration != null)
            {
                yield return new HostnameConfiguration(
                    HostnameType.Proxy,
                    proxyHostnameConfiguration.Hostname,
                    new CertificateInformation(
                        proxyHostnameConfiguration.CertificateAttributes.Expiry,
                        proxyHostnameConfiguration.CertificateAttributes.Thumbprint,
                        proxyHostnameConfiguration.CertificateAttributes.Subject));
            }
        }

        private IEnumerable<HostnameType> GetHostnamesToDelete(
            ApiManagementHostnameAtributes portalHostnameConfiguration,
            ApiManagementHostnameAtributes proxyHostnameConfiguration,
            ApiManagementAttributes currentState)
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