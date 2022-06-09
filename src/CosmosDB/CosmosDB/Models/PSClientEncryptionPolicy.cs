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
using Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Microsoft.Azure.Commands.CosmosDB.Models
{

    public class PSClientEncryptionPolicy
    {
        public PSClientEncryptionPolicy()
        {
        }

        public PSClientEncryptionPolicy(ClientEncryptionPolicy clientEncryptionPolicy)
        {
            if (clientEncryptionPolicy == null)
            {
                return;
            }

            if (ModelHelper.IsNotNullOrEmpty(clientEncryptionPolicy.IncludedPaths))
            {
                PSClientEncryptionPolicy.ValidateIncludedPaths(clientEncryptionPolicy.IncludedPaths);

                IncludedPaths = new List<PSClientEncryptionIncludedPath>();
                foreach (ClientEncryptionIncludedPath key in clientEncryptionPolicy.IncludedPaths)
                {
                    IncludedPaths.Add(new PSClientEncryptionIncludedPath(key));
                }
            }

            this.PolicyFormatVersion = (int)clientEncryptionPolicy.PolicyFormatVersion;
        }

        ///  <summary>
        ///  Gets or sets paths of the item that need encryption along with path-specific settings.
        /// </summary>
        public IList<PSClientEncryptionIncludedPath> IncludedPaths { get; private set; }

        /// <summary>
        /// Version of the client encryption policy definition.
        /// </summary>
        public int PolicyFormatVersion { get; private set; }

        public static ClientEncryptionPolicy ToSDKModel(PSClientEncryptionPolicy pSClientEncryptionPolicy, List<string> partitionKeyPathTokens)
        {
            if (pSClientEncryptionPolicy == null)
            {
                return null;
            }

            ClientEncryptionPolicy clientEncryptionPolicy = new ClientEncryptionPolicy
            {
                IncludedPaths = new List<ClientEncryptionIncludedPath>(),
                PolicyFormatVersion = pSClientEncryptionPolicy.PolicyFormatVersion
            };

            if (ModelHelper.IsNotNullOrEmpty(pSClientEncryptionPolicy.IncludedPaths))
            {
                foreach (PSClientEncryptionIncludedPath includedPath in pSClientEncryptionPolicy.IncludedPaths)
                {
                    ClientEncryptionIncludedPath clientEncryptionIncludedPath = new ClientEncryptionIncludedPath
                    {
                        Path = includedPath.Path,
                        ClientEncryptionKeyId = includedPath.ClientEncryptionKeyId,
                        EncryptionAlgorithm = includedPath.EncryptionAlgorithm,
                        EncryptionType = includedPath.EncryptionType
                    };

                    clientEncryptionPolicy.IncludedPaths.Add(clientEncryptionIncludedPath);
                }
            }

            PSClientEncryptionPolicy.ValidatePartitionKeyPathsAreNotEncrypted(clientEncryptionPolicy.IncludedPaths, partitionKeyPathTokens);

            if(clientEncryptionPolicy.PolicyFormatVersion != 1)
            {
                throw new InvalidOperationException($"Invalid PolicyFormatVersion:{clientEncryptionPolicy.PolicyFormatVersion} used in Client Encryption Policy. ");
            }

            return clientEncryptionPolicy;
        }

        /// <summary>
        /// Ensures that partition key paths are not specified in the client encryption policy for encryption.
        /// </summary>
        /// <param name="clientEncryptionIncludedPath">Included paths of the client encryption policy.</param>
        /// <param name="partitionKeyPathTokens">Tokens corresponding to validated partition key.</param>
        private static void ValidatePartitionKeyPathsAreNotEncrypted(IEnumerable<ClientEncryptionIncludedPath> clientEncryptionIncludedPath, List<string> partitionKeyPathTokens)
        {
            Debug.Assert(partitionKeyPathTokens != null);
            IEnumerable<string> propertiesToEncrypt = clientEncryptionIncludedPath.Select(p => p.Path.Substring(1));
            foreach (string tokenInPath in partitionKeyPathTokens)
            {
                Debug.Assert(String.IsNullOrEmpty(tokenInPath));                
                if (propertiesToEncrypt.Contains(tokenInPath.Substring(1)))
                {
                    throw new ArgumentException($"Paths which are part of the partition key({tokenInPath}) may not be included in the Client Encryption Policy. ");
                }
            }
        }

        private static void ValidateIncludedPaths(IEnumerable<ClientEncryptionIncludedPath> clientEncryptionIncludedPath)
        {
            List<string> includedPathsList = new List<string>();
            foreach (ClientEncryptionIncludedPath path in clientEncryptionIncludedPath)
            {
                PSClientEncryptionPolicy.ValidateClientEncryptionIncludedPath(path);
                if (includedPathsList.Contains(path.Path))
                {
                    throw new ArgumentException($"Duplicate Path({path.Path}) found.", nameof(clientEncryptionIncludedPath));
                }

                includedPathsList.Add(path.Path);
            }
        }

        private static void ValidateClientEncryptionIncludedPath(ClientEncryptionIncludedPath clientEncryptionIncludedPath)
        {
            if (clientEncryptionIncludedPath == null)
            {
                throw new ArgumentNullException(nameof(clientEncryptionIncludedPath));
            }

            if (string.IsNullOrWhiteSpace(clientEncryptionIncludedPath.Path))
            {
                throw new ArgumentNullException(nameof(clientEncryptionIncludedPath.Path));
            }

            if (clientEncryptionIncludedPath.Path[0] != '/'
                || clientEncryptionIncludedPath.Path.LastIndexOf('/') != 0
                || string.Equals(clientEncryptionIncludedPath.Path.Substring(1), "id"))
            {
                throw new ArgumentException($"Invalid path '{clientEncryptionIncludedPath.Path ?? string.Empty}'.");
            }

            if (string.IsNullOrWhiteSpace(clientEncryptionIncludedPath.ClientEncryptionKeyId))
            {
                throw new ArgumentNullException(nameof(clientEncryptionIncludedPath.ClientEncryptionKeyId));
            }

            if (string.IsNullOrWhiteSpace(clientEncryptionIncludedPath.EncryptionType))
            {
                throw new ArgumentNullException(nameof(clientEncryptionIncludedPath.EncryptionType));
            }

            if (!string.Equals(clientEncryptionIncludedPath.EncryptionType, "Deterministic") &&
                !string.Equals(clientEncryptionIncludedPath.EncryptionType, "Randomized"))
            {
                throw new ArgumentException("EncryptionType should be either 'Deterministic' or 'Randomized'. ", nameof(clientEncryptionIncludedPath));
            }

            if (string.IsNullOrWhiteSpace(clientEncryptionIncludedPath.EncryptionAlgorithm))
            {
                throw new ArgumentNullException(nameof(clientEncryptionIncludedPath.EncryptionAlgorithm));
            }

            if (!string.Equals(clientEncryptionIncludedPath.EncryptionAlgorithm, "AEAD_AES_256_CBC_HMAC_SHA256"))
            {
                throw new ArgumentException("EncryptionAlgorithm should be 'AEAD_AES_256_CBC_HMAC_SHA256'. ", nameof(clientEncryptionIncludedPath));
            }
        }
    }
}