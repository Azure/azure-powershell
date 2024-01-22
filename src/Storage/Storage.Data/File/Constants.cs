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

namespace Microsoft.WindowsAzure.Commands.Storage.File
{
    using System;

    /// <summary>
    /// Provides constants for cmdlets.
    /// </summary>
    internal static class Constants
    {
        /// <summary>
        /// Protocol string for HTTP.
        /// </summary>
        public const string HTTP = "Http";

        /// <summary>
        /// Protocol string for HTTPs.
        /// </summary>
        public const string HTTPS = "Https";

        /// <summary>
        /// Cmdlet name for storage context.
        /// </summary>
        public const string StorageContextCmdletName = "AzureStorageContext";

        /// <summary>
        /// Cmdlet name for file share.
        /// </summary>
        public const string ShareCmdletName = "AzureStorageShare";

        /// <summary>
        /// Cmdlet name for file directory.
        /// </summary>
        public const string FileDirectoryCmdletName = "AzureStorageDirectory";

        /// <summary>
        /// Cmdlet name for file.
        /// </summary>
        public const string FileCmdletName = "AzureStorageFile";

        /// <summary>
        /// Cmdlet name for file content.
        /// </summary>
        public const string FileContentCmdletName = "AzureStorageFileContent";

        /// <summary>
        /// Cmdlet name for file copy.
        /// </summary>
        public const string FileCopyCmdletName = "AzureStorageFileCopy";

        /// <summary>
        /// Cmdlet name for file copy state.
        /// </summary>
        public const string FileCopyCmdletStateName = "AzureStorageFileCopyState";

        /// <summary>
        /// Stores the default endpoint suffix for storage accounts.
        /// </summary>
        public const string DefaultStorageEndPointSuffix = "core.windows.net";

        /// <summary>
        /// Parameter set name for Share.
        /// </summary>
        public const string ShareParameterSetName = "Share";

        /// <summary>
        /// Parameter set name for ShareName.
        /// </summary>
        public const string ShareNameParameterSetName = "ShareName";

        /// <summary>
        /// Parameter set name for MatchingPrefix.
        /// </summary>
        public const string MatchingPrefixParameterSetName = "MatchingPrefix";

        /// <summary>
        /// Parameter set name for specific matching.
        /// </summary>
        public const string SpecificParameterSetName = "Specific";

        /// <summary>
        /// Parameter set name for directory.
        /// </summary>
        public const string DirectoryParameterSetName = "Directory";

        /// <summary>
        /// Parameter set name for file.
        /// </summary>
        public const string FileParameterSetName = "File";

        /// <summary>
        /// Stores the environment name for connection string.
        /// </summary>
        public const string ConnectionStringEnvironmentName = "AZURE_STORAGE_CONNECTION_STRING";

        /// <summary>
        /// Stores the default server side timeout for each request.
        /// </summary>
        public static readonly TimeSpan DefaultServerTimeoutPerRequest = TimeSpan.FromSeconds(15);

        /// <summary>
        /// Stores the default client side timeout for each request.
        /// </summary>
        public static readonly TimeSpan DefaultClientTimeoutPerRequests = TimeSpan.FromSeconds(30);

        /// <summary>
        /// Stores the default timeout for downloading and uploading files.
        /// </summary>
        public static readonly TimeSpan DefaultTimeoutForDownloadingAndUploading = TimeSpan.FromMinutes(10);
    }
}
