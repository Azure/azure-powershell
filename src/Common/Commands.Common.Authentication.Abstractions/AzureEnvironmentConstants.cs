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

namespace Microsoft.Azure.Commands.Common.Authentication.Abstractions
{
    /// <summary>
    /// Known endpoint values for public azure clouds
    /// </summary>
    public static class AzureEnvironmentConstants
    {
        /// <summary>
        /// RDFE endpoints
        /// </summary>
        public const string AzureServiceEndpoint = "https://management.core.windows.net/";
        public const string ChinaServiceEndpoint = "https://management.core.chinacloudapi.cn/";
        public const string USGovernmentServiceEndpoint = "https://management.core.usgovcloudapi.net/";
        public const string GermanServiceEndpoint = "https://management.core.cloudapi.de/";

        /// <summary>
        /// Azure ResourceManager endpoints
        /// </summary>
        public const string AzureResourceManagerEndpoint = "https://management.azure.com/";
        public const string ChinaResourceManagerEndpoint = "https://management.chinacloudapi.cn/";
        public const string USGovernmentResourceManagerEndpoint = "https://management.usgovcloudapi.net/";
        public const string GermanResourceManagerEndpoint = "https://management.microsoftazure.de/";

        /// <summary>
        /// Template gallery endpoints
        /// </summary>
        public const string GalleryEndpoint = "https://gallery.azure.com/";
        public const string ChinaGalleryEndpoint = "https://gallery.chinacloudapi.cn/";
        public const string USGovernmentGalleryEndpoint = "https://gallery.usgovcloudapi.net/";
        public const string GermanGalleryEndpoint = "https://gallery.cloudapi.de/";

        /// <summary>
        /// Location of the publishsettings file web application
        /// </summary>
        public const string AzurePublishSettingsFileUrl = "http://go.microsoft.com/fwlink/?LinkID=301775";
        public const string ChinaPublishSettingsFileUrl = "http://go.microsoft.com/fwlink/?LinkID=301776";
        public const string USGovernmentPublishSettingsFileUrl = "https://manage.windowsazure.us/publishsettings/index";
        public const string GermanPublishSettingsFileUrl = "https://manage.microsoftazure.de/publishsettings/index";

        /// <summary>
        /// Location of the maagement portal for the environment
        /// </summary>
        public const string AzureManagementPortalUrl = "http://go.microsoft.com/fwlink/?LinkId=254433";
        public const string ChinaManagementPortalUrl = "http://go.microsoft.com/fwlink/?LinkId=301902";
        public const string USGovernmentManagementPortalUrl = "https://manage.windowsazure.us";
        public const string GermanManagementPortalUrl = "http://portal.microsoftazure.de/";

        /// <summary>
        /// The domain name suffix for storage services
        /// </summary>
        public const string AzureStorageEndpointSuffix = "core.windows.net";
        public const string ChinaStorageEndpointSuffix = "core.chinacloudapi.cn";
        public const string USGovernmentStorageEndpointSuffix = "core.usgovcloudapi.net";
        public const string GermanStorageEndpointSuffix = "core.cloudapi.de";

        /// <summary>
        /// The domain name suffix for Sql database services
        /// </summary>
        public const string AzureSqlDatabaseDnsSuffix = ".database.windows.net";
        public const string ChinaSqlDatabaseDnsSuffix = ".database.chinacloudapi.cn";
        public const string USGovernmentSqlDatabaseDnsSuffix = ".database.usgovcloudapi.net";
        public const string GermanSqlDatabaseDnsSuffix = ".database.cloudapi.de";

        /// <summary>
        /// The Azure Active Directory authentication endpoint
        /// </summary>
        public const string AzureActiveDirectoryEndpoint = "https://login.microsoftonline.com/";
        public const string ChinaActiveDirectoryEndpoint = "https://login.chinacloudapi.cn/";
        public const string USGovernmentActiveDirectoryEndpoint = "https://login.microsoftonline.us/";
        public const string GermanActiveDirectoryEndpoint = "https://login.microsoftonline.de/";

        /// <summary>
        /// The Azure Active Directory Graph endpoint
        /// </summary>
        public const string AzureGraphEndpoint = "https://graph.windows.net/";
        public const string ChinaGraphEndpoint = "https://graph.chinacloudapi.cn/";
        public const string USGovernmentGraphEndpoint = "https://graph.windows.net/";
        public const string GermanGraphEndpoint = "https://graph.cloudapi.de/";

        /// <summary>
        /// The domian name suffix for Traffic manager services
        /// </summary>
        public const string AzureTrafficManagerDnsSuffix = "trafficmanager.net";
        public const string ChinaTrafficManagerDnsSuffix = "trafficmanager.cn";
        public const string USGovernmentTrafficManagerDnsSuffix = "usgovtrafficmanager.net";
        public const string GermanTrafficManagerDnsSuffix = "azuretrafficmanager.de";

        /// <summary>
        /// The domain name suffix for azure keyvault vaults
        /// </summary>
        public const string AzureKeyVaultDnsSuffix = "vault.azure.net";
        public const string ChinaKeyVaultDnsSuffix = "vault.azure.cn";
        public const string USGovernmentKeyVaultDnsSuffix = "vault.usgovcloudapi.net";
        public const string GermanKeyVaultDnsSuffix = "vault.microsoftazure.de";

        /// <summary>
        /// The token audience for authorizing KeyVault requests
        /// </summary>
        public const string AzureKeyVaultServiceEndpointResourceId = "https://vault.azure.net";
        public const string ChinaKeyVaultServiceEndpointResourceId = "https://vault.azure.cn";
        public const string USGovernmentKeyVaultServiceEndpointResourceId = "https://vault.usgovcloudapi.net";
        public const string GermanAzureKeyVaultServiceEndpointResourceId = "https://vault.microsoftazure.de";

        /// <summary>
        /// The token audience for Log Analytics Queries
        /// </summary>
        public const string AzureOperationalInsightsEndpointResourceId = "https://api.loganalytics.io";

        /// <summary>
        /// The endpoint URI for Log Analytics Queries
        /// </summary>
        public const string AzureOperationalInsightsEndpoint = "https://api.loganalytics.io/v1";

        /// <summary>
        /// The domain name suffix for Azure DataLake services
        /// </summary>
        public const string AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix = "azuredatalakeanalytics.net";
        public const string AzureDataLakeStoreFileSystemEndpointSuffix = "azuredatalakestore.net";

        /// <summary>
        /// The token audience for authorizing DataLake requests
        /// </summary>
        public const string AzureDataLakeServiceEndpointResourceId = "https://datalake.azure.net";

        public const string BatchEndpointResourceId = "https://batch.core.windows.net/";
        public const string ChinaBatchEndpointResourceId = "https://batch.chinacloudapi.cn/";
        public const string USGovernmentBatchEndpointResourceId = "https://batch.core.usgovcloudapi.net/";
        public const string GermanBatchEndpointResourceId = "https://batch.cloudapi.de/";
    }
}
