// ----------------------------------------------------------------------------------
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

using System.Threading.Tasks;
using Microsoft.WindowsAzure.Management.MediaServices.Models;
using Microsoft.WindowsAzure.Management.Storage.Models;
using Microsoft.Azure;

namespace Microsoft.WindowsAzure.Commands.Utilities.MediaServices
{
    /// <summary>
    ///     Defines interface to communicate with Azure Media Services REST API
    /// </summary>
    public interface IMediaServicesClient
    {
        /// <summary>
        ///     Gets the media service accounts async.
        /// </summary>
        /// <returns></returns>
        Task<MediaServicesAccountListResponse> GetMediaServiceAccountsAsync();

        /// <summary>
        ///     Gets the media service account details async.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        Task<MediaServicesAccountGetResponse> GetMediaServiceAsync(string name);

        /// <summary>
        ///     Create new azure media service async.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<MediaServicesAccountCreateResponse> CreateNewAzureMediaServiceAsync(MediaServicesAccountCreateParameters request);

        /// <summary>
        ///     Deletes azure media service account async.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        Task<AzureOperationResponse> DeleteAzureMediaServiceAccountAsync(string name);

        /// <summary>
        ///     Regenerates azure media service account key async.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="keyType">Key Type</param>
        /// <returns></returns>
        Task<AzureOperationResponse> RegenerateMediaServicesAccountAsync(string name, MediaServicesKeyType keyType);

        /// <summary>
        /// Gets the storage service keys.
        /// </summary>
        /// <param name="storageAccountName">Name of the storage account.</param>
        /// <returns></returns>
        Task<StorageAccountGetKeysResponse> GetStorageServiceKeysAsync(string storageAccountName);

        /// <summary>
        /// Gets the storage service properties.
        /// </summary>
        /// <param name="storageAccountName">Name of the storage account.</param>
        /// <returns></returns>
        Task<StorageAccountGetResponse> GetStorageServicePropertiesAsync(string storageAccountName);
    }
}