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
    /// <summary>
    /// A record of metadata necessary to manage assets in a specific azure cloud, including necessary endpoints,
    /// location fo service-specific endpoints, and information for bootstrapping authentication
    /// </summary>
    public class AzureEnvironment : IAzureEnvironment
    {
        /// <summary>
        /// Predefined Microsoft Azure environments
        /// </summary>
        public static Dictionary<string, AzureEnvironment> PublicEnvironments { get; } =
        new Dictionary<string, AzureEnvironment>(StringComparer.InvariantCultureIgnoreCase)
        {
            {
                EnvironmentName.AzureCloud,
                new AzureEnvironment
                {
                    Name = EnvironmentName.AzureCloud,
                    PublishSettingsFile = new Uri(AzureEnvironmentConstants.AzurePublishSettingsFileUrl),
                    ServiceManagement = new Uri(AzureEnvironmentConstants.AzureServiceEndpoint),
                    ResourceManager = new Uri(AzureEnvironmentConstants.AzureResourceManagerEndpoint),
                    ManagementPortal = new Uri(AzureEnvironmentConstants.AzureManagementPortalUrl),
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
                    GraphEndpointResourceId = AzureEnvironmentConstants.AzureGraphEndpoint,
                    AdTenant = "Common"
                }
            },
            {
                EnvironmentName.AzureChinaCloud,
                new AzureEnvironment
                {
                    Name = EnvironmentName.AzureChinaCloud,
                    PublishSettingsFile = new Uri(AzureEnvironmentConstants.ChinaPublishSettingsFileUrl),
                    ServiceManagement = new Uri(AzureEnvironmentConstants.ChinaServiceEndpoint),
                    ResourceManager = new Uri(AzureEnvironmentConstants.ChinaResourceManagerEndpoint),
                    ManagementPortal = new Uri(AzureEnvironmentConstants.ChinaManagementPortalUrl),
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
                    GraphEndpointResourceId = AzureEnvironmentConstants.ChinaGraphEndpoint,
                    AdTenant = "Common"
                }
            },
            {
                EnvironmentName.AzureUSGovernment,
                 new AzureEnvironment
                {
                    Name = EnvironmentName.AzureUSGovernment,
                    PublishSettingsFile = new Uri(AzureEnvironmentConstants.USGovernmentPublishSettingsFileUrl),
                    ServiceManagement = new Uri(AzureEnvironmentConstants.USGovernmentServiceEndpoint),
                    ResourceManager = new Uri(AzureEnvironmentConstants.USGovernmentResourceManagerEndpoint),
                    ManagementPortal = new Uri(AzureEnvironmentConstants.USGovernmentManagementPortalUrl),
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
                    GraphEndpointResourceId = AzureEnvironmentConstants.USGovernmentGraphEndpoint,
                    AdTenant = "Common"
                }
            },
            {
                EnvironmentName.AzureGermanCloud,
                 new AzureEnvironment
                {
                    Name = EnvironmentName.AzureGermanCloud,
                    PublishSettingsFile = new Uri(AzureEnvironmentConstants.GermanPublishSettingsFileUrl),
                    ServiceManagement = new Uri(AzureEnvironmentConstants.GermanServiceEndpoint),
                    ResourceManager = new Uri(AzureEnvironmentConstants.GermanResourceManagerEndpoint),
                    ManagementPortal = new Uri(AzureEnvironmentConstants.GermanManagementPortalUrl),
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
                    GraphEndpointResourceId = AzureEnvironmentConstants.GermanGraphEndpoint,
                    AdTenant = "Common"
                }
            }
       };

        /// <summary>
        /// The name of the environment
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Whether the environment uses AAD (false) or ADFS (true) authentication
        /// </summary>
        public bool OnPremise { get; set; }

        /// <summary>
        /// The RDFE endpoint
        /// </summary>
        public Uri ServiceManagement { get; set; }

        /// <summary>
        /// The Azure Resource Manager endpoint
        /// </summary>
        public Uri ResourceManager { get; set; }

        /// <summary>
        /// The location fo the AUX portal
        /// </summary>
        public Uri ManagementPortal { get; set; }

        /// <summary>
        /// The location of the publishsettings fiel download web applciation
        /// </summary>
        public Uri PublishSettingsFile { get; set; }

        /// <summary>
        /// The authentication endpoint
        /// </summary>
        public Uri ActiveDirectory { get; set; }

        /// <summary>
        /// The uri of the template gallery
        /// </summary>
        public Uri Gallery { get; set; }

        /// <summary>
        /// The URI of the Azure Active Directory Graph endpoint
        /// </summary>
        public Uri Graph { get; set; }

        /// <summary>
        /// The token audience need for tokens that target RDFE or ARM endpoints
        /// </summary>
        public string ActiveDirectoryServiceEndpointResourceId { get; set; }

        /// <summary>
        /// The domain name suffix for storage services created in this environment
        /// </summary>
        public string StorageEndpointSuffix { get; set; }

        /// <summary>
        /// The domain name suffix for Sql server created in this environment
        /// </summary>
        public string SqlDatabaseDnsSuffix { get; set; }

        /// <summary>
        /// The domain name suffix for traffic manager endpoints created in this ebvironment
        /// </summary>
        public string TrafficManagerDnsSuffix { get; set; }

        /// <summary>
        /// The domain name suffix for Aure KeyVault vaults created in this environment
        /// </summary>
        public string AzureKeyVaultDnsSuffix { get; set; }

        /// <summary>
        /// The token audience required for communicating with the Azure KeyVault service in this environment
        /// </summary>
        public string AzureKeyVaultServiceEndpointResourceId { get; set; }

        /// <summary>
        /// The token audience required for communicating with the Azure Active Directory Graph service in this environment
        /// </summary>
        public string GraphEndpointResourceId { get; set; }

        /// <summary>
        /// The domain name suffix for Azure DataLake Catalog and Job services created in this environment
        /// </summary>
        public string AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix { get; set; }

        /// <summary>
        /// The domain name suffix for Azure DataLake file systems created in this environment
        /// </summary>
        public string AzureDataLakeStoreFileSystemEndpointSuffix { get; set; }

        /// <summary>
        /// The name of the default AdTenant in this environment
        /// </summary>
        public string AdTenant { get; set; } 

        /// <summary>
        /// The set of Azure Version Profiles supported in this environment
        /// </summary>
        public IList<string> VersionProfiles { get; } = new List<string>();

        /// <summary>
        /// Additional environment-specific metadata
        /// </summary>
        public IDictionary<string, string> ExtendedProperties { get; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// A set of string constants for each of the known environment values - allows users to specify a particular kind of endpoint by name
        /// </summary>
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
    }
}
