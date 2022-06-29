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

using Microsoft.Azure.Management.CosmosDB.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.CosmosDB.Models
{
    public class PSClientEncryptionIncludedPath
    {
        public PSClientEncryptionIncludedPath()
        {
        }

        public PSClientEncryptionIncludedPath(ClientEncryptionIncludedPath clientEncryptionIncludedPath)
        {
            if (clientEncryptionIncludedPath == null)
            {
                return;
            }

            Path = clientEncryptionIncludedPath.Path;
            ClientEncryptionKeyId = clientEncryptionIncludedPath.ClientEncryptionKeyId;
            EncryptionType = clientEncryptionIncludedPath.EncryptionType;
            EncryptionAlgorithm = clientEncryptionIncludedPath.EncryptionAlgorithm;
        }

        /// <summary>
        /// Gets or sets the path to be encrypted. Must be a top level path, eg. /salary
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the Client Encryption Key to be used to encrypt the path.
        /// </summary>
        public string ClientEncryptionKeyId { get; set; }

        /// <summary>
        /// Gets or sets the type of encryption to be performed. Eg - Deterministic, Randomized
        /// </summary>
        public string EncryptionType { get; set; }

        /// <summary>
        /// Gets or sets the encryption algorithm which will be used. Eg - AEAD_AES_256_CBC_HMAC_SHA256
        /// </summary>
        public string EncryptionAlgorithm { get; set; }
    }
}