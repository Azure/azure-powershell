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

namespace Microsoft.WindowsAzure.Commands.Storage.Common
{
    /// <summary>
    /// Storage nouns for cmdlet name
    /// </summary>
    public static class StorageNouns
    {
        /// <summary>
        /// Blob cmdlet name
        /// </summary>
        public const string Blob = "AzureStorageBlob";

        /// <summary>
        /// Blobcontent cmdlet name
        /// </summary>
        public const string BlobContent = "AzureStorageBlobContent";

        /// <summary>
        /// blob snapshot cmdlet name
        /// </summary>
        public const string BlobSnapshot = "AzureStorageBlobSnapshot";

        /// <summary>
        /// Container cmdlet name
        /// </summary>
        public const string Container = "AzureStorageContainer";

        /// <summary>
        /// Container acl cmdlet name
        /// </summary>
        public const string ContainerAcl = "AzureStorageContainerAcl";

        /// <summary>
        /// Http protocol
        /// </summary>
        public const string HTTP = "Http";

        /// <summary>
        /// Https protocol
        /// </summary>
        public const string HTTPS = "Https";

        /// <summary>
        /// Queue cmdlet name
        /// </summary>
        public const string Queue = "AzureStorageQueue";

        /// <summary>
        /// Storage context cmdlet name
        /// </summary>
        public const string StorageContext = "AzureStorageContext";

        /// <summary>
        /// Storage account name
        /// </summary>
        public const string StorageAccountName = "Storage account name";

        /// <summary>
        /// Table cmdlet name
        /// </summary>
        public const string Table = "AzureStorageTable";

        /// <summary>
        /// Copy azure storage blob
        /// </summary>
        public const string CopyBlob = "AzureStorageBlobCopy";

        /// <summary>
        /// Copy azure storage blob deprecated name
        /// </summary>
        public const string CopyBlobDeprecatedName = "CopyAzureStorageBlob";

        /// <summary>
        /// Copy status for azure storage blob
        /// </summary>
        public const string CopyBlobStatus = "AzureStorageBlobCopyState";

        /// <summary>
        /// Azure storage service hour metrics
        /// </summary>
        public const string StorageServiceMetrics = "AzureStorageServiceMetricsProperty";

        /// <summary>
        /// Azure storage service logging
        /// </summary>
        public const string StorageServiceLogging = "AzureStorageServiceLoggingProperty";

        /// <summary>
        /// Azure storage CORS rule
        /// </summary>
        public const string StorageCORSRule = "AzureStorageCORSRule";

        /// <summary>
        /// Azure storage account sas
        /// </summary>
        public const string AccountSas = "AzureStorageAccountSASToken";

        /// <summary>
        /// Azure storage container sas
        /// </summary>
        public const string ContainerSas = "AzureStorageContainerSASToken";

        /// <summary>
        /// Azure storage blob sas
        /// </summary>
        public const string BlobSas = "AzureStorageBlobSASToken";

        /// <summary>
        /// Azure storage file share sas
        /// </summary>
        public const string ShareSas = "AzureStorageShareSASToken";

        /// <summary>
        /// Azure storage file sas
        /// </summary>
        public const string FileSas = "AzureStorageFileSASToken";

        /// <summary>
        /// Azure storage table sas
        /// </summary>
        public const string TableSas = "AzureStorageTableSASToken";

        /// <summary>
        /// Azure storage queue sas
        /// </summary>
        public const string QueueSas = "AzureStorageQueueSASToken";

        /// <summary>
        /// Azure storage table stored access policy
        /// </summary>
        public const string TableStoredAccessPolicy = "AzureStorageTableStoredAccessPolicy";

        /// <summary>
        /// Azure storage share stored access policy
        /// </summary>
        public const string ShareStoredAccessPolicy = "AzureStorageShareStoredAccessPolicy";

        /// <summary>
        /// Azure storage container stored access policy
        /// </summary>
        public const string ContainerStoredAccessPolicy = "AzureStorageContainerStoredAccessPolicy";


        /// <summary>
        /// Azure storage container stored access policy
        /// </summary>
        public const string QueueStoredAccessPolicy = "AzureStorageQueueStoredAccessPolicy";

        /// <summary>
        /// Azure storage share quota
        /// </summary>
        public const string ShareQuota = "AzureStorageShareQuota";

        /// <summary>
        /// Default service metrics version
        /// </summary>
        public const string DefaultMetricsVersion = "1.0";

        /// <summary>
        /// Default service logging version
        /// </summary>
        public const string DefaultLoggingVersion = "1.0";

        /// <summary>
        /// Permission const for New-AzureStorage(Blob/Container/Table/Queue)SasToken
        /// </summary>
        public static class Permission
        {
            /// <summary>
            /// Read permission
            /// </summary>
            public const char Read = 'r';

            /// <summary>
            /// Write permission
            /// </summary>
            public const char Write = 'w';

            /// <summary>
            /// Delete permission
            /// </summary>
            public const char Delete = 'd';

            /// <summary>
            /// List permission
            /// </summary>
            public const char List = 'l';

            /// <summary>
            /// Update permission
            /// </summary>
            public const char Update = 'u';

            /// <summary>
            /// Add permission
            /// </summary>
            public const char Add = 'a';

            /// <summary>
            /// Process permission
            /// </summary>
            public const char Process = 'p';

            /// <summary>
            /// Query permission
            /// </summary>
            public const char Query = 'q';

            /// <summary>
            /// Create permission.
            /// </summary>
            public const char Create = 'c';
        }
    }
}
