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
                PSClientEncryptionPolicy.ValidateIncludedPaths(clientEncryptionPolicy.IncludedPaths, (int)clientEncryptionPolicy.PolicyFormatVersion);

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

            PSClientEncryptionPolicy.ValidatePartitionKeyPathsAreNotEncrypted(
                clientEncryptionPolicy.IncludedPaths,
                partitionKeyPathTokens,
                pSClientEncryptionPolicy.PolicyFormatVersion);

            if(clientEncryptionPolicy.PolicyFormatVersion < 1 || clientEncryptionPolicy.PolicyFormatVersion > 2)
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
        /// <param name="policyFormatVersion">Client encryption policy format version.</param>
        private static void ValidatePartitionKeyPathsAreNotEncrypted(
            IEnumerable<ClientEncryptionIncludedPath> clientEncryptionIncludedPath,
            List<string> partitionKeyPathTokens,
            int policyFormatVersion)
        {
            Debug.Assert(partitionKeyPathTokens != null);

            foreach (string tokenInPath in partitionKeyPathTokens)
            {
                Debug.Assert(String.IsNullOrEmpty(tokenInPath));

                string topLevelPath = tokenInPath.Split('/')[1];
                // paths in included paths start with "/". Get the ClientEncryptionIncludedPath and validate.
                IEnumerable<ClientEncryptionIncludedPath> encryptedPartitionKeyPath = clientEncryptionIncludedPath.Where(p => p.Path.Substring(1).Equals(topLevelPath));

                if (encryptedPartitionKeyPath.Any())
                {
                    if (policyFormatVersion < 2)
                    {
                        throw new ArgumentException($"Path: {encryptedPartitionKeyPath.Select(et => et.Path).FirstOrDefault()} which is part of the partition key cannot be encrypted with PolicyFormatVersion: {policyFormatVersion}. Please use PolicyFormatVersion: 2. ");
                    }

                    // for the ClientEncryptionIncludedPath found check the encryption type.
                    if (encryptedPartitionKeyPath.Select(et => et.EncryptionType).FirstOrDefault() != "Deterministic")
                    {
                        throw new ArgumentException($"Path: {encryptedPartitionKeyPath.Select(et => et.Path).FirstOrDefault()} which is part of the partition key has to be encrypted with Deterministic type Encryption.");
                    }
                }
            }
        }

        private static void ValidateIncludedPaths(IEnumerable<ClientEncryptionIncludedPath> clientEncryptionIncludedPath, int policyFormatVersion)
        {
            List<string> includedPathsList = new List<string>();
            foreach (ClientEncryptionIncludedPath path in clientEncryptionIncludedPath)
            {
                PSClientEncryptionPolicy.ValidateClientEncryptionIncludedPath(path, policyFormatVersion);
                if (includedPathsList.Contains(path.Path))
                {
                    throw new ArgumentException($"Duplicate Path({path.Path}) found.", nameof(clientEncryptionIncludedPath));
                }

                includedPathsList.Add(path.Path);
            }
        }

        private static void ValidateClientEncryptionIncludedPath(ClientEncryptionIncludedPath clientEncryptionIncludedPath, int policyFormatVersion)
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
                || clientEncryptionIncludedPath.Path.LastIndexOf('/') != 0)
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

            if (string.Equals(clientEncryptionIncludedPath.Path.Substring(1), "id"))
            {
                if (policyFormatVersion < 2)
                {
                    throw new ArgumentException($"Path: {clientEncryptionIncludedPath.Path} cannot be encrypted with PolicyFormatVersion: {policyFormatVersion}. Please use PolicyFormatVersion: 2. ");
                }

                if (clientEncryptionIncludedPath.EncryptionType != "Deterministic")
                {
                    throw new ArgumentException($"Only Deterministic encryption type is supported for path: {clientEncryptionIncludedPath.Path}. ");
                }
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