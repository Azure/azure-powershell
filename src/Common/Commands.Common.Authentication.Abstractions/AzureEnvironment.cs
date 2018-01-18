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
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace Microsoft.Azure.Commands.Common.Authentication.Abstractions
{
    /// <summary>
    /// A record of metadata necessary to manage assets in a specific azure cloud, including necessary endpoints,
    /// location fo service-specific endpoints, and information for bootstrapping authentication
    /// </summary>
    [Serializable]
    public class AzureEnvironment : IAzureEnvironment
    {
        static IDictionary<string, AzureEnvironment> InitializeBuiltInEnvironments()
        {
            var azureCloud = new AzureEnvironment
            {
                Name = EnvironmentName.AzureCloud,
                PublishSettingsFileUrl = AzureEnvironmentConstants.AzurePublishSettingsFileUrl,
                ServiceManagementUrl = AzureEnvironmentConstants.AzureServiceEndpoint,
                ResourceManagerUrl = AzureEnvironmentConstants.AzureResourceManagerEndpoint,
                ManagementPortalUrl = AzureEnvironmentConstants.AzureManagementPortalUrl,
                ActiveDirectoryAuthority = AzureEnvironmentConstants.AzureActiveDirectoryEndpoint,
                ActiveDirectoryServiceEndpointResourceId = AzureEnvironmentConstants.AzureServiceEndpoint,
                StorageEndpointSuffix = AzureEnvironmentConstants.AzureStorageEndpointSuffix,
                GalleryUrl = AzureEnvironmentConstants.GalleryEndpoint,
                SqlDatabaseDnsSuffix = AzureEnvironmentConstants.AzureSqlDatabaseDnsSuffix,
                GraphUrl = AzureEnvironmentConstants.AzureGraphEndpoint,
                TrafficManagerDnsSuffix = AzureEnvironmentConstants.AzureTrafficManagerDnsSuffix,
                AzureKeyVaultDnsSuffix = AzureEnvironmentConstants.AzureKeyVaultDnsSuffix,
                AzureKeyVaultServiceEndpointResourceId = AzureEnvironmentConstants.AzureKeyVaultServiceEndpointResourceId,
                AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix = AzureEnvironmentConstants.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix,
                AzureDataLakeStoreFileSystemEndpointSuffix = AzureEnvironmentConstants.AzureDataLakeStoreFileSystemEndpointSuffix,
                GraphEndpointResourceId = AzureEnvironmentConstants.AzureGraphEndpoint,
                DataLakeEndpointResourceId = AzureEnvironmentConstants.AzureDataLakeServiceEndpointResourceId,
                BatchEndpointResourceId = AzureEnvironmentConstants.BatchEndpointResourceId,
                AdTenant = "Common"
            };
            azureCloud.SetProperty(ExtendedEndpoint.OperationalInsightsEndpoint, AzureEnvironmentConstants.AzureOperationalInsightsEndpoint);
            azureCloud.SetProperty(ExtendedEndpoint.OperationalInsightsEndpointResourceId, AzureEnvironmentConstants.AzureOperationalInsightsEndpointResourceId);
            var azureChina = new AzureEnvironment
            {
                Name = EnvironmentName.AzureChinaCloud,
                PublishSettingsFileUrl = AzureEnvironmentConstants.ChinaPublishSettingsFileUrl,
                ServiceManagementUrl = AzureEnvironmentConstants.ChinaServiceEndpoint,
                ResourceManagerUrl = AzureEnvironmentConstants.ChinaResourceManagerEndpoint,
                ManagementPortalUrl = AzureEnvironmentConstants.ChinaManagementPortalUrl,
                ActiveDirectoryAuthority = AzureEnvironmentConstants.ChinaActiveDirectoryEndpoint,
                ActiveDirectoryServiceEndpointResourceId = AzureEnvironmentConstants.ChinaServiceEndpoint,
                StorageEndpointSuffix = AzureEnvironmentConstants.ChinaStorageEndpointSuffix,
                GalleryUrl = AzureEnvironmentConstants.GalleryEndpoint,
                SqlDatabaseDnsSuffix = AzureEnvironmentConstants.ChinaSqlDatabaseDnsSuffix,
                GraphUrl = AzureEnvironmentConstants.ChinaGraphEndpoint,
                TrafficManagerDnsSuffix = AzureEnvironmentConstants.ChinaTrafficManagerDnsSuffix,
                AzureKeyVaultDnsSuffix = AzureEnvironmentConstants.ChinaKeyVaultDnsSuffix,
                AzureKeyVaultServiceEndpointResourceId = AzureEnvironmentConstants.ChinaKeyVaultServiceEndpointResourceId,
                AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix = null,
                AzureDataLakeStoreFileSystemEndpointSuffix = null,
                DataLakeEndpointResourceId = null,
                GraphEndpointResourceId = AzureEnvironmentConstants.ChinaGraphEndpoint,
                BatchEndpointResourceId = AzureEnvironmentConstants.ChinaBatchEndpointResourceId,
                AdTenant = "Common"
            };
            var azureUSGovernment = new AzureEnvironment
            {
                Name = EnvironmentName.AzureUSGovernment,
                PublishSettingsFileUrl = AzureEnvironmentConstants.USGovernmentPublishSettingsFileUrl,
                ServiceManagementUrl = AzureEnvironmentConstants.USGovernmentServiceEndpoint,
                ResourceManagerUrl = AzureEnvironmentConstants.USGovernmentResourceManagerEndpoint,
                ManagementPortalUrl = AzureEnvironmentConstants.USGovernmentManagementPortalUrl,
                ActiveDirectoryAuthority = AzureEnvironmentConstants.USGovernmentActiveDirectoryEndpoint,
                ActiveDirectoryServiceEndpointResourceId = AzureEnvironmentConstants.USGovernmentServiceEndpoint,
                StorageEndpointSuffix = AzureEnvironmentConstants.USGovernmentStorageEndpointSuffix,
                GalleryUrl = AzureEnvironmentConstants.GalleryEndpoint,
                SqlDatabaseDnsSuffix = AzureEnvironmentConstants.USGovernmentSqlDatabaseDnsSuffix,
                GraphUrl = AzureEnvironmentConstants.USGovernmentGraphEndpoint,
                TrafficManagerDnsSuffix = AzureEnvironmentConstants.USGovernmentTrafficManagerDnsSuffix,
                AzureKeyVaultDnsSuffix = AzureEnvironmentConstants.USGovernmentKeyVaultDnsSuffix,
                AzureKeyVaultServiceEndpointResourceId = AzureEnvironmentConstants.USGovernmentKeyVaultServiceEndpointResourceId,
                AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix = null,
                AzureDataLakeStoreFileSystemEndpointSuffix = null,
                DataLakeEndpointResourceId = null,
                GraphEndpointResourceId = AzureEnvironmentConstants.USGovernmentGraphEndpoint,
                BatchEndpointResourceId = AzureEnvironmentConstants.USGovernmentBatchEndpointResourceId,
                AdTenant = "Common"
            };
            var azureGermany = new AzureEnvironment
            {
                Name = EnvironmentName.AzureGermanCloud,
                PublishSettingsFileUrl = AzureEnvironmentConstants.GermanPublishSettingsFileUrl,
                ServiceManagementUrl = AzureEnvironmentConstants.GermanServiceEndpoint,
                ResourceManagerUrl = AzureEnvironmentConstants.GermanResourceManagerEndpoint,
                ManagementPortalUrl = AzureEnvironmentConstants.GermanManagementPortalUrl,
                ActiveDirectoryAuthority = AzureEnvironmentConstants.GermanActiveDirectoryEndpoint,
                ActiveDirectoryServiceEndpointResourceId = AzureEnvironmentConstants.GermanServiceEndpoint,
                StorageEndpointSuffix = AzureEnvironmentConstants.GermanStorageEndpointSuffix,
                GalleryUrl = AzureEnvironmentConstants.GalleryEndpoint,
                SqlDatabaseDnsSuffix = AzureEnvironmentConstants.GermanSqlDatabaseDnsSuffix,
                GraphUrl = AzureEnvironmentConstants.GermanGraphEndpoint,
                TrafficManagerDnsSuffix = AzureEnvironmentConstants.GermanTrafficManagerDnsSuffix,
                AzureKeyVaultDnsSuffix = AzureEnvironmentConstants.GermanKeyVaultDnsSuffix,
                AzureKeyVaultServiceEndpointResourceId = AzureEnvironmentConstants.GermanAzureKeyVaultServiceEndpointResourceId,
                AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix = null,
                AzureDataLakeStoreFileSystemEndpointSuffix = null,
                DataLakeEndpointResourceId = null,
                GraphEndpointResourceId = AzureEnvironmentConstants.GermanGraphEndpoint,
                BatchEndpointResourceId = AzureEnvironmentConstants.GermanBatchEndpointResourceId,
                AdTenant = "Common"
            };
            return new Dictionary<string, AzureEnvironment>(StringComparer.InvariantCultureIgnoreCase)
            {
                { EnvironmentName.AzureCloud, azureCloud },           
                { EnvironmentName.AzureChinaCloud, azureChina },
                { EnvironmentName.AzureUSGovernment, azureUSGovernment },
                { EnvironmentName.AzureGermanCloud, azureGermany }
                 
            };
        }

        static int _initialized = 0;
        static IDictionary<string, AzureEnvironment> _builtInEnvironments;
        /// <summary>
        /// Predefined Microsoft Azure environments
        /// </summary>
        public static IDictionary<string, AzureEnvironment> PublicEnvironments
        {
            get
            {
                if (Interlocked.Exchange(ref _initialized, 1) == 0)
                {
                    _builtInEnvironments = InitializeBuiltInEnvironments();
                }

                return _builtInEnvironments;
            }
        }


        public AzureEnvironment()
        {
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="other"></param>
        public AzureEnvironment(IAzureEnvironment other)
        {
            this.CopyFrom(other);
        }

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
        public string ServiceManagementUrl { get; set; }

        /// <summary>
        /// The Azure Resource Manager endpoint
        /// </summary>
        public string ResourceManagerUrl { get; set; }

        /// <summary>
        /// The location fo the AUX portal
        /// </summary>
        public string ManagementPortalUrl { get; set; }

        /// <summary>
        /// The location of the publishsettings fiel download web applciation
        /// </summary>
        public string PublishSettingsFileUrl { get; set; }

        /// <summary>
        /// The authentication endpoint
        /// </summary>
        public string ActiveDirectoryAuthority { get; set; }

        /// <summary>
        /// The uri of the template gallery
        /// </summary>
        public string GalleryUrl { get; set; }

        /// <summary>
        /// The URI of the Azure Active Directory Graph endpoint
        /// </summary>
        public string GraphUrl { get; set; }

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
        /// The token audience required for communicating with the Azure Active Directory Data Lake service in this environment
        /// </summary>
        public string DataLakeEndpointResourceId { get; set; }

        /// <summary>
        /// The token audience required for communicating with the Batch service in this enviornment
        /// </summary>
        public string BatchEndpointResourceId { get; set; }

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
                AzureDataLakeStoreFileSystemEndpointSuffix = "AzureDataLakeStoreFileSystemEndpointSuffix",
                DataLakeEndpointResourceId = "DataLakeEndpointResourceId",
                BatchEndpointResourceId = "BatchEndpointResourceId";
        }

        public static class ExtendedEndpoint
        {
            public const string OperationalInsightsEndpointResourceId = "OperationalInsightsEndpointResourceId",
                OperationalInsightsEndpoint = "OperationalInsightsEndpoint";
        }
    }
}
