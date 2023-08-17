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

namespace Microsoft.Azure.Commands.TestFx
{
    public class ConnectionStringKeys
    {
        public const string TestCSMOrgIdConnectionStringKey = "TEST_CSM_ORGID_AUTHENTICATION";

        public const string AZURE_TEST_MODE_ENVKEY = "AZURE_TEST_MODE";

        /// <summary>
        /// Environment name
        /// </summary>
        public const string EnvironmentKey = "Environment";

        /// <summary>
        /// The key inside the connection string for the management certificate
        /// </summary>
        public const string ManagementCertificateKey = "ManagementCertificate";

        /// <summary>
        /// The key inside the connection string for the subscription identifier
        /// </summary>
        public const string SubscriptionIdKey = "SubscriptionId";

        /// <summary>
        /// If a tenant other than common is to be used with the subscription, specifies the tenant
        /// </summary>
        public const string TenantIdKey = "TenantId";

        /// <summary>
        /// HttpRecorderMode
        /// </summary>
        public const string HttpRecorderModeKey = "HttpRecorderMode";

        /// <summary>
        /// The key inside the connection string for a Microsoft ID (OrgId or LiveId)
        /// </summary>
        public const string UserIdKey = "UserId";

        /// <summary>
        /// The key inside the connection string for a user password matching the Microsoft ID
        /// </summary>
        public const string PasswordKey = "Password";

        /// <summary>
        /// Service principal key
        /// </summary>
        public const string ServicePrincipalKey = "ServicePrincipal";

        /// <summary>
        /// ServicePrincipal Secret Key
        /// </summary>
        public const string ServicePrincipalSecretKey = "ServicePrincipalSecret";

        /// <summary>
        /// Resource Management endpoint
        /// </summary>
        public const string ResourceManagementUriKey = "ResourceManagementUri";

        /// <summary>
        /// Service Management endpoint
        /// </summary>
        public const string ServiceManagementUriKey = "ServiceManagementUri";

        /// <summary>
        /// The client ID to use when authenticating with AAD
        /// </summary>
        public const string AADClientIdKey = "AADClientId";

        /// <summary>
        /// A raw JWT token for AAD authentication
        /// </summary>
        public const string RawTokenKey = "RawToken";

        /// <summary>
        /// A raw JWT token for Graph authentication
        /// </summary>
        public const string RawGraphTokenKey = "RawGraphToken";

        /// <summary>
        /// AAD token Audience Uri 
        /// </summary>
        public const string AADTokenAudienceUriKey = "AADTokenAudienceUri";

        /// <summary>
        /// Graph token Audience Uri
        /// </summary>
        public const string GraphTokenAudienceUriKey = "GraphTokenAudienceUri";

        /// <summary>
        /// The key inside the connection string for the base management URI
        /// </summary>
        public const string BaseUriKey = "BaseUri";

        /// <summary>
        /// Endpoint to use for AAD authentication
        /// </summary>
        public const string AADAuthUriKey = "AADAuthUri";   //Most probably ActiveDirectoryAuthority

        /// <summary>
        /// The key inside the connection string for AD Graph URI
        /// </summary>
        public const string GraphUriKey = "GraphUri";

        /// <summary>
        /// The key inside the connection string for AD Gallery URI
        /// </summary>
        public const string GalleryUriKey = "GalleryUri";

        /// <summary>
        /// The key inside the connection string for the Ibiza Portal URI
        /// </summary>
        public const string IbizaPortalUriKey = "IbizaPortalUri";

        /// <summary>
        /// The key inside the connection string for the RDFE Portal URI
        /// </summary>
        public const string RdfePortalUriKey = "RdfePortalUri";

        /// <summary>
        /// The key inside the connection string for the DataLake FileSystem URI suffix
        /// </summary>
        public const string DataLakeStoreServiceUriKey = "DataLakeStoreServiceUri";

        /// <summary>
        /// The key inside the connection string for the Kona Catalog URI
        /// </summary>
        public const string DataLakeAnalyticsJobAndCatalogServiceUriKey = "DataLakeAnalyticsJobAndCatalogServiceUri";

        /// <summary>
        /// Publishsettings endpoint
        /// </summary>
        public const string PublishSettingsFileUriKey = "PublishSettingsFileUri";

        public const string OptimizeRecordedFileKey = "OptimizeRecordedFile";
    }
}
