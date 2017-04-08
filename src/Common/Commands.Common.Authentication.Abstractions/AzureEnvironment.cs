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

        public string AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix { get; set; }

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
                AzureDataLakeStoreFileSystemEndpointSuffix = "AzureDataLakeStoreFileSystemEndpointSuffix";

        }

        private static readonly Dictionary<string, AzureEnvironment> _environments =
    new Dictionary<string, AzureEnvironment>(StringComparer.InvariantCultureIgnoreCase)
{
            {
                EnvironmentName.AzureCloud,
                new AzureEnvironment
                {
                    Name = EnvironmentName.AzureCloud,
                    PublishSettingsFileUrl = new Uri(AzureEnvironmentConstants.AzurePublishSettingsFileUrl),
                    ServiceManagement = new Uri(AzureEnvironmentConstants.AzureServiceEndpoint),
                    ResourceManager = new Uri(AzureEnvironmentConstants.AzureResourceManagerEndpoint),
                    ManagementPortalUrl = new Uri(AzureEnvironmentConstants.AzureManagementPortalUrl),
                    ActiveDirectory = new Uri(AzureEnvironmentConstants.AzureActiveDirectoryEndpoint),
                    ActiveDirectoryServiceEndpointResourceId = AzureEnvironmentConstants.AzureServiceEndpoint,
                    StorageEndpointSuffix = AzureEnvironmentConstants.AzureStorageEndpointSuffix,
                    Gallery = new Uri(AzureEnvironmentConstants.GalleryEndpoint),
                    SqlDatabaseDnsSuffix = AzureEnvironmentConstants.AzureSqlDatabaseDnsSuffix,
                    Graph = new Uri(AzureEnvironmentConstants.AzureGraphEndpoint),
                    TrafficManagerDnsSuffix = AzureEnvironmentConstants.AzureTrafficManagerDnsSuffix,
                    AzureKeyVaultDnsSuffix = AzureEnvironmentConstants.AzureKeyVaultDnsSuffix,
                    AzureKeyVaultServiceEndpointResourceId = AzureEnvironmentConstants.AzureKeyVaultServiceEndpointResourceId,
                    AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix = AzureEnvironmentConstants.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix,
                    AzureDataLakeStoreFileSystemEndpointSuffix = AzureEnvironmentConstants.AzureDataLakeStoreFileSystemEndpointSuffix,
                    GraphEndpointResourceId = AzureEnvironmentConstants.AzureGraphEndpoint
                }
            },
            {
                EnvironmentName.AzureChinaCloud,
                new AzureEnvironment
                {
                    Name = EnvironmentName.AzureChinaCloud,
                    PublishSettingsFileUrl = new Uri(AzureEnvironmentConstants.ChinaPublishSettingsFileUrl),
                    ServiceManagement = new Uri(AzureEnvironmentConstants.ChinaServiceEndpoint),
                    ResourceManager = new Uri(AzureEnvironmentConstants.ChinaResourceManagerEndpoint),
                    ManagementPortalUrl = new Uri(AzureEnvironmentConstants.ChinaManagementPortalUrl),
                    ActiveDirectory = new Uri(AzureEnvironmentConstants.ChinaActiveDirectoryEndpoint),
                    ActiveDirectoryServiceEndpointResourceId = AzureEnvironmentConstants.ChinaServiceEndpoint,
                    StorageEndpointSuffix = AzureEnvironmentConstants.ChinaStorageEndpointSuffix,
                    Gallery = new Uri(AzureEnvironmentConstants.GalleryEndpoint),
                    SqlDatabaseDnsSuffix = AzureEnvironmentConstants.ChinaSqlDatabaseDnsSuffix,
                    Graph = new Uri(AzureEnvironmentConstants.ChinaGraphEndpoint),
                    TrafficManagerDnsSuffix = AzureEnvironmentConstants.ChinaTrafficManagerDnsSuffix,
                    AzureKeyVaultDnsSuffix = AzureEnvironmentConstants.ChinaKeyVaultDnsSuffix,
                    AzureKeyVaultServiceEndpointResourceId = AzureEnvironmentConstants.ChinaKeyVaultServiceEndpointResourceId,
                    AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix = null,
                    AzureDataLakeStoreFileSystemEndpointSuffix = null,
                    GraphEndpointResourceId = AzureEnvironmentConstants.ChinaGraphEndpoint
                }
            },
            {
                EnvironmentName.AzureUSGovernment,
                 new AzureEnvironment
                {
                    Name = EnvironmentName.AzureUSGovernment,
                    PublishSettingsFileUrl = new Uri(AzureEnvironmentConstants.USGovernmentPublishSettingsFileUrl),
                    ServiceManagement = new Uri(AzureEnvironmentConstants.USGovernmentServiceEndpoint),
                    ResourceManager = new Uri(AzureEnvironmentConstants.USGovernmentResourceManagerEndpoint),
                    ManagementPortalUrl = new Uri(AzureEnvironmentConstants.USGovernmentManagementPortalUrl),
                    ActiveDirectory = new Uri(AzureEnvironmentConstants.USGovernmentActiveDirectoryEndpoint),
                    ActiveDirectoryServiceEndpointResourceId = AzureEnvironmentConstants.USGovernmentServiceEndpoint,
                    StorageEndpointSuffix = AzureEnvironmentConstants.USGovernmentStorageEndpointSuffix,
                    Gallery = new Uri(AzureEnvironmentConstants.GalleryEndpoint),
                    SqlDatabaseDnsSuffix = AzureEnvironmentConstants.USGovernmentSqlDatabaseDnsSuffix,
                    Graph = new Uri(AzureEnvironmentConstants.USGovernmentGraphEndpoint),
                    TrafficManagerDnsSuffix = AzureEnvironmentConstants.USGovernmentTrafficManagerDnsSuffix,
                    AzureKeyVaultDnsSuffix = AzureEnvironmentConstants.USGovernmentKeyVaultDnsSuffix,
                    AzureKeyVaultServiceEndpointResourceId = AzureEnvironmentConstants.USGovernmentKeyVaultServiceEndpointResourceId,
                    AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix = null,
                    AzureDataLakeStoreFileSystemEndpointSuffix = null,
                    GraphEndpointResourceId = AzureEnvironmentConstants.USGovernmentGraphEndpoint
                }
            },
            {
                EnvironmentName.AzureGermanCloud,
                 new AzureEnvironment
                {
                    Name = EnvironmentName.AzureGermanCloud,
                    PublishSettingsFileUrl = new Uri(AzureEnvironmentConstants.GermanPublishSettingsFileUrl),
                    ServiceManagement = new Uri(AzureEnvironmentConstants.GermanServiceEndpoint),
                    ResourceManager = new Uri(AzureEnvironmentConstants.GermanResourceManagerEndpoint),
                    ManagementPortalUrl = new Uri(AzureEnvironmentConstants.GermanManagementPortalUrl),
                    ActiveDirectory = new Uri(AzureEnvironmentConstants.GermanActiveDirectoryEndpoint),
                    ActiveDirectoryServiceEndpointResourceId = AzureEnvironmentConstants.GermanServiceEndpoint,
                    StorageEndpointSuffix = AzureEnvironmentConstants.GermanStorageEndpointSuffix,
                    Gallery = new Uri(AzureEnvironmentConstants.GalleryEndpoint),
                    SqlDatabaseDnsSuffix = AzureEnvironmentConstants.GermanSqlDatabaseDnsSuffix,
                    Graph = new Uri(AzureEnvironmentConstants.GermanGraphEndpoint),
                    TrafficManagerDnsSuffix = AzureEnvironmentConstants.GermanTrafficManagerDnsSuffix,
                    AzureKeyVaultDnsSuffix = AzureEnvironmentConstants.GermanKeyVaultDnsSuffix,
                    AzureKeyVaultServiceEndpointResourceId = AzureEnvironmentConstants.GermanAzureKeyVaultServiceEndpointResourceId,
                    AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix = null,
                    AzureDataLakeStoreFileSystemEndpointSuffix = null,
                    GraphEndpointResourceId = AzureEnvironmentConstants.GermanGraphEndpoint
                }
            }

};

    }
}
