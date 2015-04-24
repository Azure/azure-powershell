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
    using Microsoft.IdentityModel.Clients.ActiveDirectory;

    public class ApiManagementClient
    {
        private readonly AzureProfile _azureProfile;
        private Management.ApiManagement.ApiManagementClient _client;

        public ApiManagementClient(AzureProfile azureProfile)
        {
            if (azureProfile == null)
            {
                throw new ArgumentNullException("azureProfile");
            }

            _azureProfile = azureProfile;
        }

        public PsApiManagement GetApiManagement(string resourceGroupName, string serviceName)
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

            //return new PsApiManagement(resource);
#endif
            ApiServiceGetResponse response = Client.ApiManagement.Get(resourceGroupName, serviceName);
            return new PsApiManagement(response.Value);
        }

        public IEnumerable<PsApiManagement> ListApiManagements(string resourceGroupName)
        {
            var response = Client.ApiManagement.List(resourceGroupName);
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
            //                SkuType = Mapper.Map<PsApiManagementSku, SkuType>(sku),
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
            AdjustRetryAfter(longrunningResponse, _client.LongRunningOperationInitialTimeout);
            return ApiManagementLongRunningOperation.CreateLongRunningOperation("New-AzureApiManagement", longrunningResponse);
        }

        private static void AdjustRetryAfter(LongRunningOperationResponse longrunningResponse, int longRunningOperationInitialTimeout)
        {
            if (longRunningOperationInitialTimeout >= 0)
            {
                longrunningResponse.RetryAfter = longRunningOperationInitialTimeout;
            }
        }

        internal ApiManagementLongRunningOperation GetLongRunningOperationStatus(ApiManagementLongRunningOperation longRunningOperation)
        {
            var response =
                Client.ApiManagement
                    .GetApiServiceLongRunningOperationStatusAsync(longRunningOperation.OperationLink)
                    .ConfigureAwait(false)
                    .GetAwaiter()
                    .GetResult();

            AdjustRetryAfter(response, _client.LongRunningOperationInitialTimeout);
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

            var longrunningResponse = Client.ApiManagement.BeginBackup(resourceGroupName, serviceName, parameters);
            AdjustRetryAfter(longrunningResponse, _client.LongRunningOperationInitialTimeout);
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
            AdjustRetryAfter(longrunningResponse, _client.LongRunningOperationInitialTimeout);
            return ApiManagementLongRunningOperation.CreateLongRunningOperation("Restore-AzureApiManagement", longrunningResponse);
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

            var longrunningResponse = Client.ApiManagement.BeginManagingDeployments(resourceGroupName, serviceName, parameters);
            AdjustRetryAfter(longrunningResponse, _client.LongRunningOperationInitialTimeout);
            return ApiManagementLongRunningOperation.CreateLongRunningOperation("Update-AzureApiManagementDeployment", longrunningResponse);
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
            var result = Client.ApiManagement.UploadCertificate(resourceGroupName, serviceName, parameters);

            return new PsApiManagementHostnameCertificate(result.Value);
        }

        public ApiManagementLongRunningOperation BeginSetHostnames(
            string resourceGroupName,
            string serviceName,
            PsApiManagementHostnameConfiguration portalHostnameConfiguration,
            PsApiManagementHostnameConfiguration proxyHostnameConfiguration)
        {
            var currentStateResource = Client.ApiManagement.Get(resourceGroupName, serviceName);
            var currentState = new PsApiManagement(currentStateResource.Value);

            var parameters = new ApiServiceUpdateHostnameParameters
            {
                HostnamesToDelete = GetHostnamesToDelete(portalHostnameConfiguration, proxyHostnameConfiguration, currentState).ToList(),
                HostnamesToCreateOrUpdate = GetHostnamesToCreateOrUpdate(portalHostnameConfiguration, proxyHostnameConfiguration, currentState).ToList()
            };

            var longrunningResponse = Client.ApiManagement.BeginUpdatingHostname(resourceGroupName, serviceName, parameters);
            AdjustRetryAfter(longrunningResponse, _client.LongRunningOperationInitialTimeout);
            return ApiManagementLongRunningOperation.CreateLongRunningOperation("Set-AzureApiManagementHostnames", longrunningResponse);
        }

        public string GetSsoToken(string resourceGroupName, string serviceName)
        {
            return Client.ApiManagement.GetSsoToken(resourceGroupName, serviceName).RedirectUrl;
        }

        private IApiManagementClient Client
        {
            get
            {
                if (_client == null)
                {
                    _client =
                        AzureSession.ClientFactory.CreateClient<Management.ApiManagement.ApiManagementClient>(
                            _azureProfile,
                            AzureEnvironment.Endpoint.ResourceManager);
                }

#if DEBUG
                RefreshTokenIfRequired();
#endif

                return _client;
            }
        }

        private void RefreshTokenIfRequired()
        {
            if (_client != null && TokenCache.DefaultShared != null)
            {
                var tokenCredentials = _client.Credentials as TokenCloudCredentials;
                if (tokenCredentials != null)
                {
                    var token =
                        TokenCache.DefaultShared
                            .ReadItems()
                            .FirstOrDefault(item => !string.IsNullOrWhiteSpace(item.AccessToken) && item.IsMultipleResourceRefreshToken);

                    if (token != null &&
                        !string.IsNullOrWhiteSpace(token.RefreshToken) &&
                        DateTime.UtcNow + TimeSpan.FromMinutes(5) >= token.ExpiresOn.UtcDateTime)
                    {
                        var authenticationContex = new AuthenticationContext(token.Authority);

                        var result = authenticationContex.AcquireToken(token.Resource, token.ClientId, new Uri("urn:ietf:wg:oauth:2.0:oob"), PromptBehavior.Auto);
                        var newToken = authenticationContex.AcquireTokenByRefreshToken(result.RefreshToken, token.ClientId, token.Resource);
                        tokenCredentials.Token = newToken.AccessToken;
                    }
                }
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
            if (portalHostnameConfiguration != null && currentState.PortalHostnameConfiguration != null)
            {
                yield return new HostnameConfiguration(
                    HostnameType.Portal,
                    portalHostnameConfiguration.Hostname,
                    new CertificateInformation(
                        portalHostnameConfiguration.HostnameCertificate.Expiry,
                        portalHostnameConfiguration.HostnameCertificate.Thumbprint,
                        portalHostnameConfiguration.HostnameCertificate.Subject));
            }

            if (proxyHostnameConfiguration != null && currentState.ProxyHostnameConfiguration != null)
            {
                yield return new HostnameConfiguration(
                    HostnameType.Proxy,
                    proxyHostnameConfiguration.Hostname,
                    new CertificateInformation(
                        proxyHostnameConfiguration.HostnameCertificate.Expiry,
                        proxyHostnameConfiguration.HostnameCertificate.Thumbprint,
                        proxyHostnameConfiguration.HostnameCertificate.Subject));
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

            var longrunningResponse = Client.ApiManagement.BeginManagingVirtualNetworks(resourceGroupName, serviceName, parameters);
            AdjustRetryAfter(longrunningResponse, _client.LongRunningOperationInitialTimeout);
            return ApiManagementLongRunningOperation.CreateLongRunningOperation("Set-AzureApiManagementVirtualNetworks", longrunningResponse);
        }
    }
}