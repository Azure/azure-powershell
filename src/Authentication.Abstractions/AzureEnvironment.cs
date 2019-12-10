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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Models;
using Newtonsoft.Json;
using Polly;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Authentication.Abstractions
{
    /// <summary>
    /// A record of metadata necessary to manage assets in a specific azure cloud, including necessary endpoints,
    /// location fo service-specific endpoints, and information for bootstrapping authentication
    /// </summary>
    [Serializable]
    public class AzureEnvironment : IAzureEnvironment
    {        
        private const string ArmMetadataEnvVariable = "ARM_CLOUD_METADATA_URL";
        private static readonly HttpClient Client = new HttpClient();        

        static IDictionary<string, AzureEnvironment> InitializeBuiltInEnvironments()
        {
            IDictionary<string, AzureEnvironment> armAzureEnvironments = null;
            try
            {
                var armMetadataRequestUri = Environment.GetEnvironmentVariable(ArmMetadataEnvVariable);
                if (!string.IsNullOrEmpty(armMetadataRequestUri))
                {
                    armAzureEnvironments = InitializeEnvironmentsFromArm(armMetadataRequestUri).Result;
                }
            }
            catch (Exception)
            {
                armAzureEnvironments = null;
            }

            if (armAzureEnvironments != null)
            {
                return armAzureEnvironments;
            }

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

            var result = new ConcurrentDictionary<string, AzureEnvironment>(StringComparer.InvariantCultureIgnoreCase)
            {
                [EnvironmentName.AzureCloud] = azureCloud,
                [EnvironmentName.AzureChinaCloud] = azureChina,
                [EnvironmentName.AzureUSGovernment] = azureUSGovernment,
                [EnvironmentName.AzureGermanCloud] = azureGermany
            };
            SetExtendedProperties(result);
            return result;
        }

        /// <summary>
        /// Initializes cloud metadata dynamically from ARM.
        /// </summary>
        private static async Task<IDictionary<string, AzureEnvironment>> InitializeEnvironmentsFromArm(string armMetadataRequestUri)
        {
            var armResponseMessage = await Client.GetAsync(armMetadataRequestUri);
            if (armResponseMessage?.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Failed to load cloud metadata from the url specified by ARM_CLOUD_METADATA_URL.");
            }

            var armMetadataContent = await armResponseMessage.Content?.ReadAsStringAsync();
            if (string.IsNullOrEmpty(armMetadataContent))
            {
                throw new Exception("Failed to load cloud metadata from the url specified by ARM_CLOUD_METADATA_URL.");
            }

            var armMetadataList = JsonConvert.DeserializeObject<List<ArmMetadata>>(armMetadataContent);
            var result = new ConcurrentDictionary<string, AzureEnvironment>(StringComparer.InvariantCultureIgnoreCase);
            foreach (var armMetadata in armMetadataList)
            {
                result[armMetadata.Name] = MapArmToAzureEnvironment(armMetadataList.First(a =>
                    a.Name.Equals(armMetadata.Name, StringComparison.InvariantCultureIgnoreCase)));
            }

            SetExtendedProperties(result);
            return result;
        }

        /// <summary>
        /// Set Extended properties (to maintain parity).
        /// </summary>
        /// <param name="azureEnvironments">Collection of AzureEnvironments</param>
        private static void SetExtendedProperties(IDictionary<string, AzureEnvironment> azureEnvironments)
        {
            azureEnvironments[EnvironmentName.AzureCloud].SetProperty(ExtendedEndpoint.OperationalInsightsEndpoint, AzureEnvironmentConstants.AzureOperationalInsightsEndpoint);
            azureEnvironments[EnvironmentName.AzureCloud].SetProperty(ExtendedEndpoint.OperationalInsightsEndpointResourceId, AzureEnvironmentConstants.AzureOperationalInsightsEndpointResourceId);
            azureEnvironments[EnvironmentName.AzureCloud].SetProperty(ExtendedEndpoint.AnalysisServicesEndpointSuffix, AzureEnvironmentConstants.AzureAnalysisServicesEndpointSuffix);
            azureEnvironments[EnvironmentName.AzureCloud].SetProperty(ExtendedEndpoint.AnalysisServicesEndpointResourceId, AzureEnvironmentConstants.AzureAnalysisServicesEndpointResourceId);

            azureEnvironments[EnvironmentName.AzureChinaCloud].SetProperty(ExtendedEndpoint.AnalysisServicesEndpointSuffix, AzureEnvironmentConstants.ChinaAnalysisServicesEndpointSuffix);
            azureEnvironments[EnvironmentName.AzureChinaCloud].SetProperty(ExtendedEndpoint.AnalysisServicesEndpointResourceId, AzureEnvironmentConstants.ChinaAnalysisServicesEndpointResourceId);

            azureEnvironments[EnvironmentName.AzureUSGovernment].SetProperty(ExtendedEndpoint.OperationalInsightsEndpoint, AzureEnvironmentConstants.USGovernmentOperationalInsightsEndpoint);
            azureEnvironments[EnvironmentName.AzureUSGovernment].SetProperty(ExtendedEndpoint.OperationalInsightsEndpointResourceId, AzureEnvironmentConstants.USGovernmentOperationalInsightsEndpointResourceId);
            azureEnvironments[EnvironmentName.AzureUSGovernment].SetProperty(ExtendedEndpoint.AnalysisServicesEndpointSuffix, AzureEnvironmentConstants.USGovernmentAnalysisServicesEndpointSuffix);
            azureEnvironments[EnvironmentName.AzureUSGovernment].SetProperty(ExtendedEndpoint.AnalysisServicesEndpointResourceId, AzureEnvironmentConstants.USGovernmentAnalysisServicesEndpointResourceId);

            azureEnvironments[EnvironmentName.AzureGermanCloud].SetProperty(ExtendedEndpoint.AnalysisServicesEndpointSuffix, AzureEnvironmentConstants.GermanAnalysisServicesEndpointSuffix);
            azureEnvironments[EnvironmentName.AzureGermanCloud].SetProperty(ExtendedEndpoint.AnalysisServicesEndpointResourceId, AzureEnvironmentConstants.GermanAnalysisServicesEndpointResourceId);
        }

        /// <summary>
        /// Map ARM metadata schema to the AzureEnvironment object.
        /// </summary>
        /// <param name="armMetadata">ARM cloud metadata</param>
        /// <returns></returns>
        private static AzureEnvironment MapArmToAzureEnvironment(ArmMetadata armMetadata)
        {
            var azureEnvironment = new AzureEnvironment
            {
                Name = armMetadata.Name,
                PublishSettingsFileUrl = GetPublishSettingsFileUrl(armMetadata.Name),
                ServiceManagementUrl = armMetadata.Authentication.Audiences[0],
                ResourceManagerUrl = armMetadata.ResourceManager,
                ManagementPortalUrl = armMetadata.Portal,
                ActiveDirectoryAuthority = armMetadata.Authentication.LoginEndpoint,
                ActiveDirectoryServiceEndpointResourceId = armMetadata.Authentication.Audiences[0],
                StorageEndpointSuffix = armMetadata.Suffixes.Storage,
                GalleryUrl = armMetadata.Gallery,
                SqlDatabaseDnsSuffix = armMetadata.Suffixes.SqlServerHostname,
                GraphUrl = armMetadata.Graph,
                TrafficManagerDnsSuffix = GetTrafficManagerDnsSuffix(armMetadata.Name),
                AzureKeyVaultDnsSuffix = armMetadata.Suffixes.KeyVaultDns,
                AzureKeyVaultServiceEndpointResourceId = GetKeyVaultServiceEndpointResourceId(armMetadata.Name),
                AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix = armMetadata.Suffixes.AzureDataLakeAnalyticsCatalogAndJob,
                AzureDataLakeStoreFileSystemEndpointSuffix = armMetadata.Suffixes.AzureDataLakeStoreFileSystem,
                DataLakeEndpointResourceId = armMetadata.ActiveDirectoryDataLake,
                GraphEndpointResourceId = armMetadata.Graph,
                BatchEndpointResourceId = armMetadata.Batch,
                AdTenant = armMetadata.Authentication.Tenant
            };

            return azureEnvironment;
        }

        /// <summary>
        /// Gets publish setting file URL for a cloud.
        /// Note: Included for sake of parity, should remove if defunct.
        /// </summary>
        /// <param name="cloudName">Cloud name</param>
        /// <returns></returns>
        private static string GetPublishSettingsFileUrl(string cloudName)
        {
            switch (cloudName)
            {
                case EnvironmentName.AzureCloud:
                    return AzureEnvironmentConstants.AzurePublishSettingsFileUrl;
                case EnvironmentName.AzureChinaCloud:
                    return AzureEnvironmentConstants.ChinaPublishSettingsFileUrl;
                case EnvironmentName.AzureUSGovernment:
                    return AzureEnvironmentConstants.USGovernmentPublishSettingsFileUrl;
                case EnvironmentName.AzureGermanCloud:
                    return AzureEnvironmentConstants.GermanPublishSettingsFileUrl;
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Gets the key vault service endpoint resource id for a cloud.
        /// Note: Remove once the ARM metadata endpoint exposes KeyVaultServiceEndpointResourceId.
        /// </summary>
        /// <param name="cloudName">Cloud name</param>
        /// <returns></returns>
        private static string GetKeyVaultServiceEndpointResourceId(string cloudName)
        {
            switch (cloudName)
            {
                case EnvironmentName.AzureCloud:
                    return AzureEnvironmentConstants.AzureKeyVaultServiceEndpointResourceId;
                case EnvironmentName.AzureChinaCloud:
                    return AzureEnvironmentConstants.ChinaKeyVaultServiceEndpointResourceId;
                case EnvironmentName.AzureUSGovernment:
                    return AzureEnvironmentConstants.USGovernmentKeyVaultServiceEndpointResourceId;
                case EnvironmentName.AzureGermanCloud:
                    return AzureEnvironmentConstants.GermanAzureKeyVaultServiceEndpointResourceId;
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Gets the traffic manager DNS suffix for a cloud.
        /// Note: Remove once the ARM metadata endpoint exposes TrafficManagerDnsSuffix.
        /// </summary>
        /// <param name="cloudName">Cloud name</param>
        /// <returns></returns>
        private static string GetTrafficManagerDnsSuffix(string cloudName)
        {
            switch (cloudName)
            {
                case EnvironmentName.AzureCloud:
                    return AzureEnvironmentConstants.AzureTrafficManagerDnsSuffix;
                case EnvironmentName.AzureChinaCloud:
                    return AzureEnvironmentConstants.ChinaTrafficManagerDnsSuffix;
                case EnvironmentName.AzureUSGovernment:
                    return AzureEnvironmentConstants.USGovernmentTrafficManagerDnsSuffix;
                case EnvironmentName.AzureGermanCloud:
                    return AzureEnvironmentConstants.GermanTrafficManagerDnsSuffix;
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Predefined Microsoft Azure environments
        /// </summary>
        public static IDictionary<string, AzureEnvironment> PublicEnvironments { get; } = InitializeBuiltInEnvironments();

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
                OperationalInsightsEndpoint = "OperationalInsightsEndpoint",
                AnalysisServicesEndpointSuffix = "AzureAnalysisServicesEndpointSuffix",
                AnalysisServicesEndpointResourceId = "AnalysisServicesEndpointResourceId";
        }
    }
}
