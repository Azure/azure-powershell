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

using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Microsoft.WindowsAzure.Commands.Utilities.MediaServices.Services.Entities
{
    [DataContract]
    [JsonObject(Title = "AccountCreationRequest")]
    public class AccountCreationRequest
    {
        /// <summary>
        ///     Gets or sets the name of the account.
        /// </summary>
        /// <value>
        ///     The name of the account.
        /// </value>
        [DataMember]
        public string AccountName { get; set; }

        /// <summary>
        ///     Gets or sets the BLOB storage endpoint URI.
        /// </summary>
        /// <value>
        ///     The BLOB storage endpoint URI.
        /// </value>
        [DataMember]
        public string BlobStorageEndpointUri { get; set; }

        /// <summary>
        ///     Gets or sets the region.
        /// </summary>
        /// <value>
        ///     The region.
        /// </value>
        [DataMember]
        public string Region { get; set; }

        /// <summary>
        ///     Gets or sets the storage account key.
        /// </summary>
        /// <value>
        ///     The storage account key.
        /// </value>
        [DataMember]
        public string StorageAccountKey { get; set; }

        /// <summary>
        ///     Gets or sets the name of the storage account.
        /// </summary>
        /// <value>
        ///     The name of the storage account.
        /// </value>
        [DataMember]
        public string StorageAccountName { get; set; }
    }
}