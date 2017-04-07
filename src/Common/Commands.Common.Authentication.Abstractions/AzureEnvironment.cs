// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Common.Authentication.Abstractions
{
    public class AzureEnvironment : IAzureEnvironment
    {
        /// <summary>
        /// Predefined Microsoft Azure environments
        /// </summary>
        public static Dictionary<string, AzureEnvironment> PublicEnvironments
        {
            get { return _environments; }
        }

        public string Name { get; set; }

        public bool OnPremise { get; set; }

        public Uri ServiceManagement { get; set; }

        public Uri ResourceManager { get; set; }

        public Uri ManagementPortalUrl { get; set; }

        public Uri PublishSettingsFileUrl { get; set; }

        public Uri ActiveDirectory { get; set; }

        public Uri Gallery { get; set; }

        public Uri Graph { get; set; }

        public string ActiveDirectoryServiceEndpointResourceId { get; set; }

        public string StorageEndpointSuffix { get; set; }

        public string SqlDatabaseDnsSuffix { get; set; }

        public string TrafficManagerDnsSuffix { get; set; }

        public string AzureKeyVaultDnsSuffix { get; set; }

        public string AzureKeyVaultServiceEndpointResourceId { get; set; }

        public string GraphEndpointResourceId { get; set; }

        public string AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix {get; set;}

        public string AzureDataLakeStoreFileSystemEndpointSuffix { get; set; }

        public string AdTenant { get; set; }


        public IList<string> VersionProfiles { get; } = new List<string>();

        public IDictionary<string, string> ExtendedProperties { get; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public static class Endpoint
        {
            public const string AdTenant = "AdTenant",
                ActiveDirectoryServiceEndpointResourceId = "ActiveDirectoryServiceEndpointResourceId",
                GraphEndpointResourceId = "GraphEndpointResourceId",
                AzureKeyVaultServiceEndpointResourceId = "AzureKeyVaultServiceEndpointResourceId",
                AzureKeyVaultDnsSuffix = "AzureKeyVaultDnsSuffix",
                TrafficManagerDnsSuffix = "TrafficManagerDnsSuffix",
                SqlDatabaseDnsSuffix = "SqlDatabaseDnsSuffix",
                StorageEndpointSuffix = "StorageEndpointSuffix",
                Graph = "Graph",
                Gallery = "Gallery",
                ActiveDirectory = "ActiveDirectory",
                ServiceManagement = "ServiceManagement",
                ResourceManager = "ResourceManager",
                PublishSettingsFileUrl = "PublishSettingsFileUrl",
                ManagementPortalUrl = "ManagementPortalUrl",
                AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix = "AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix",
                AzureDataLakeStoreFileSystemEndpointSuffix= "AzureDataLakeStoreFileSystemEndpointSuffix";

        }

        private static readonly Dictionary<string, AzureEnvironment> environments =
    new Dictionary<string, AzureEnvironment>(StringComparer.InvariantCultureIgnoreCase)
{
            {
                EnvironmentName.AzureCloud,
                new AzureEnvironment
                {
                    Name = EnvironmentName.AzureCloud,
                    Endpoints = new Dictionary<AzureEnvironment.Endpoint, string>
                    {
                        { AzureEnvironmentExtensions.Endpoint.PublishSettingsFileUrl, AzureEnvironmentConstants.AzurePublishSettingsFileUrl },
                        { AzureEnvironment.Endpoint.ServiceManagement, AzureEnvironmentConstants.AzureServiceEndpoint },
                        { AzureEnvironment.Endpoint.ResourceManager, AzureEnvironmentConstants.AzureResourceManagerEndpoint },
                        { AzureEnvironment.Endpoint.ManagementPortalUrl, AzureEnvironmentConstants.AzureManagementPortalUrl },
                        { AzureEnvironment.Endpoint.ActiveDirectory, AzureEnvironmentConstants.AzureActiveDirectoryEndpoint },
                        { AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId, AzureEnvironmentConstants.AzureServiceEndpoint },
                        { AzureEnvironment.Endpoint.StorageEndpointSuffix, AzureEnvironmentConstants.AzureStorageEndpointSuffix },
                        { AzureEnvironment.Endpoint.Gallery, AzureEnvironmentConstants.GalleryEndpoint },
                        { AzureEnvironment.Endpoint.SqlDatabaseDnsSuffix, AzureEnvironmentConstants.AzureSqlDatabaseDnsSuffix },
                        { AzureEnvironment.Endpoint.Graph, AzureEnvironmentConstants.AzureGraphEndpoint },
                        { AzureEnvironment.Endpoint.TrafficManagerDnsSuffix, AzureEnvironmentConstants.AzureTrafficManagerDnsSuffix },
                        { AzureEnvironment.Endpoint.AzureKeyVaultDnsSuffix, AzureEnvironmentConstants.AzureKeyVaultDnsSuffix},
                        { AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId, AzureEnvironmentConstants.AzureKeyVaultServiceEndpointResourceId},
                        { AzureEnvironment.Endpoint.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix, AzureEnvironmentConstants.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix},
                        { AzureEnvironment.Endpoint.AzureDataLakeStoreFileSystemEndpointSuffix, AzureEnvironmentConstants.AzureDataLakeStoreFileSystemEndpointSuffix},
                        { AzureEnvironment.Endpoint.GraphEndpointResourceId, AzureEnvironmentConstants.AzureGraphEndpoint}
                    }
                }
            },
            {
                EnvironmentName.AzureChinaCloud,
                new AzureEnvironment
                {
                    Name = EnvironmentName.AzureChinaCloud,
                    Endpoints = new Dictionary<AzureEnvironment.Endpoint, string>
                    {
                        { AzureEnvironment.Endpoint.PublishSettingsFileUrl, AzureEnvironmentConstants.ChinaPublishSettingsFileUrl },
                        { AzureEnvironment.Endpoint.ServiceManagement, AzureEnvironmentConstants.ChinaServiceEndpoint },
                        { AzureEnvironment.Endpoint.ResourceManager, AzureEnvironmentConstants.ChinaResourceManagerEndpoint },
                        { AzureEnvironment.Endpoint.ManagementPortalUrl, AzureEnvironmentConstants.ChinaManagementPortalUrl },
                        { AzureEnvironment.Endpoint.ActiveDirectory, AzureEnvironmentConstants.ChinaActiveDirectoryEndpoint },
                        { AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId, AzureEnvironmentConstants.ChinaServiceEndpoint },
                        { AzureEnvironment.Endpoint.StorageEndpointSuffix, AzureEnvironmentConstants.ChinaStorageEndpointSuffix },
                        { AzureEnvironment.Endpoint.Gallery, AzureEnvironmentConstants.ChinaGalleryEndpoint },
                        { AzureEnvironment.Endpoint.SqlDatabaseDnsSuffix, AzureEnvironmentConstants.ChinaSqlDatabaseDnsSuffix },
                        { AzureEnvironment.Endpoint.Graph, AzureEnvironmentConstants.ChinaGraphEndpoint },
                        { AzureEnvironment.Endpoint.TrafficManagerDnsSuffix, AzureEnvironmentConstants.ChinaTrafficManagerDnsSuffix },
                        { AzureEnvironment.Endpoint.AzureKeyVaultDnsSuffix, AzureEnvironmentConstants.ChinaKeyVaultDnsSuffix },
                        { AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId, AzureEnvironmentConstants.ChinaKeyVaultServiceEndpointResourceId },
                         { AzureEnvironment.Endpoint.GraphEndpointResourceId, AzureEnvironmentConstants.ChinaGraphEndpoint}
                       // TODO: DataLakeAnalytics and ADL do not have a China endpoint yet. Once they do, add them here.
                    }
                }
            },
            {
                EnvironmentName.AzureUSGovernment,
                new AzureEnvironment
                {
                    Name = EnvironmentName.AzureUSGovernment,
                    Endpoints = new Dictionary<AzureEnvironment.Endpoint, string>
                    {
                        { AzureEnvironment.Endpoint.PublishSettingsFileUrl, AzureEnvironmentConstants.USGovernmentPublishSettingsFileUrl },
                        { AzureEnvironment.Endpoint.ServiceManagement, AzureEnvironmentConstants.USGovernmentServiceEndpoint },
                        { AzureEnvironment.Endpoint.ResourceManager, AzureEnvironmentConstants.USGovernmentResourceManagerEndpoint },
                        { AzureEnvironment.Endpoint.ManagementPortalUrl, AzureEnvironmentConstants.USGovernmentManagementPortalUrl },
                        { AzureEnvironment.Endpoint.ActiveDirectory, AzureEnvironmentConstants.USGovernmentActiveDirectoryEndpoint },
                        { AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId, AzureEnvironmentConstants.USGovernmentServiceEndpoint },
                        { AzureEnvironment.Endpoint.StorageEndpointSuffix, AzureEnvironmentConstants.USGovernmentStorageEndpointSuffix },
                        { AzureEnvironment.Endpoint.Gallery, AzureEnvironmentConstants.USGovernmentGalleryEndpoint },
                        { AzureEnvironment.Endpoint.SqlDatabaseDnsSuffix, AzureEnvironmentConstants.USGovernmentSqlDatabaseDnsSuffix },
                        { AzureEnvironment.Endpoint.Graph, AzureEnvironmentConstants.USGovernmentGraphEndpoint },
                        { AzureEnvironment.Endpoint.TrafficManagerDnsSuffix, AzureEnvironmentConstants.USGovernmentTrafficManagerDnsSuffix },
                        { AzureEnvironment.Endpoint.AzureKeyVaultDnsSuffix, AzureEnvironmentConstants.USGovernmentKeyVaultDnsSuffix},
                        { AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId, AzureEnvironmentConstants.USGovernmentKeyVaultServiceEndpointResourceId},
                        { AzureEnvironment.Endpoint.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix, null},
                        { AzureEnvironment.Endpoint.AzureDataLakeStoreFileSystemEndpointSuffix, null},
                        { AzureEnvironment.Endpoint.GraphEndpointResourceId, AzureEnvironmentConstants.USGovernmentGraphEndpoint }
                    }
                }
            },
            {
                EnvironmentName.AzureGermanCloud,
                new AzureEnvironment
                {
                    Name = EnvironmentName.AzureGermanCloud,
                    Endpoints = new Dictionary<AzureEnvironment.Endpoint, string>
                    {
                        { AzureEnvironment.Endpoint.PublishSettingsFileUrl, AzureEnvironmentConstants.GermanPublishSettingsFileUrl },
                        { AzureEnvironment.Endpoint.ServiceManagement, AzureEnvironmentConstants.GermanServiceEndpoint },
                        { AzureEnvironment.Endpoint.ResourceManager, AzureEnvironmentConstants.GermanResourceManagerEndpoint },
                        { AzureEnvironment.Endpoint.ManagementPortalUrl, AzureEnvironmentConstants.GermanManagementPortalUrl },
                        { AzureEnvironment.Endpoint.ActiveDirectory, AzureEnvironmentConstants.GermanActiveDirectoryEndpoint },
                        { AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId, AzureEnvironmentConstants.GermanServiceEndpoint },
                        { AzureEnvironment.Endpoint.StorageEndpointSuffix, AzureEnvironmentConstants.GermanStorageEndpointSuffix },
                        { AzureEnvironment.Endpoint.Gallery, AzureEnvironmentConstants.GermanGalleryEndpoint },
                        { AzureEnvironment.Endpoint.SqlDatabaseDnsSuffix, AzureEnvironmentConstants.GermanSqlDatabaseDnsSuffix },
                        { AzureEnvironment.Endpoint.Graph, AzureEnvironmentConstants.GermanGraphEndpoint },
                        { AzureEnvironment.Endpoint.TrafficManagerDnsSuffix, AzureEnvironmentConstants.GermanTrafficManagerDnsSuffix },
                        { AzureEnvironment.Endpoint.AzureKeyVaultDnsSuffix, AzureEnvironmentConstants.GermanKeyVaultDnsSuffix },
                        { AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId, AzureEnvironmentConstants.GermanAzureKeyVaultServiceEndpointResourceId },
                        { AzureEnvironment.Endpoint.GraphEndpointResourceId, AzureEnvironmentConstants.GermanGraphEndpoint }
                    }
                }
            }

};

    }
}
