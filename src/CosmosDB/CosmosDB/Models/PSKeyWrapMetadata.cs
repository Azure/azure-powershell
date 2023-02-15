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
using System;

namespace Microsoft.Azure.Commands.CosmosDB.Models
{

    public class PSKeyWrapMetadata
    {
        public PSKeyWrapMetadata()
        {
        }        

        public PSKeyWrapMetadata(KeyWrapMetadata keyWrapMetadata)
        {
            if (keyWrapMetadata == null)
            {
                return;
            }

            Name = keyWrapMetadata.Name;
            Type = keyWrapMetadata.Type;
            Value = keyWrapMetadata.Value;
            Algorithm = keyWrapMetadata.Algorithm;
        }

        //
        // Summary:
        //     Gets or sets the name of associated KeyEncryptionKey (aka CustomerManagedKey).
        public string Name { get; set; }
        //
        // Summary:
        //     Gets or sets providerName of KeyStoreProvider.
        public string Type { get; set; }
        //
        // Summary:
        //     Gets or sets reference / link to the KeyEncryptionKey.
        public string Value { get; set; }
        // 
        // Summary:
        //      Gets or sets algorithm used in wrapping and unwrapping of the data encryption key.
        public string Algorithm { get; set; }


        public static KeyWrapMetadata ToSDKModel(PSKeyWrapMetadata pSKeyWrapMetadata)
        {
            if (pSKeyWrapMetadata == null)
            {
                return null;
            }

            if(string.IsNullOrEmpty(pSKeyWrapMetadata.Name))
            {
                throw new ArgumentNullException("Name cannot be null or empty");
            }

            if (string.IsNullOrEmpty(pSKeyWrapMetadata.Type))
            {
                throw new ArgumentNullException("Type cannot be null or empty");
            }

            if (string.IsNullOrEmpty(pSKeyWrapMetadata.Value))
            {
                throw new ArgumentNullException("Value cannot be null or empty");
            }

            if (string.IsNullOrEmpty(pSKeyWrapMetadata.Algorithm))
            {
                throw new ArgumentNullException("Algorithm cannot be null or empty");
            }

            KeyWrapMetadata keyWrapMetadata = new KeyWrapMetadata
            {
                Name = pSKeyWrapMetadata.Name,
                Type = pSKeyWrapMetadata.Type,
                Value = pSKeyWrapMetadata.Value,
                Algorithm = pSKeyWrapMetadata.Algorithm
            };

            return keyWrapMetadata;
        }
    }
}