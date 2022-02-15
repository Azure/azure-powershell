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

namespace Microsoft.Azure.Commands.CosmosDB.Models
{
    using Microsoft.Azure.Management.CosmosDB.Models;

    public class PSSqlClientEncryptionKeyGetPropertiesResource
    {
        public PSSqlClientEncryptionKeyGetPropertiesResource()
        {
        }        
        
        public PSSqlClientEncryptionKeyGetPropertiesResource(ClientEncryptionKeyGetPropertiesResource clientEncryptionKeyGetPropertiesResource)
        {
            if (clientEncryptionKeyGetPropertiesResource == null)
            {
                return;
            }

            Id = clientEncryptionKeyGetPropertiesResource.Id;
            EncryptionAlgorithm = clientEncryptionKeyGetPropertiesResource.EncryptionAlgorithm;
            KeyWrapMetaData = clientEncryptionKeyGetPropertiesResource.KeyWrapMetadata;
            WrappedDataEncryptionKey = clientEncryptionKeyGetPropertiesResource.WrappedDataEncryptionKey;
            _rid = clientEncryptionKeyGetPropertiesResource._rid;
            _ts = clientEncryptionKeyGetPropertiesResource._ts;
            _etag = clientEncryptionKeyGetPropertiesResource._etag;

        }

        //
        // Summary:
        //     Gets or sets name of the Cosmos DB SQL container
        public string Id { get; set; }
        //
        // Summary:
        //     Gets or sets name of the Cosmos DB SQL container
        public string EncryptionAlgorithm { get; set; }
        //
        // Summary:
        //     Gets or sets the configuration of the indexing policy. By default, the indexing
        //     is automatic for all document paths within the container
        public KeyWrapMetadata KeyWrapMetaData { get; set; }
        //
        // Summary:
        //     Gets or sets the configuration of the partition key to be used for partitioning
        //     data into multiple partitions
        public byte[] WrappedDataEncryptionKey { get; set; }        
        //
        // Summary:
        //     Gets a system generated property. A unique identifier.
        public string _rid { get; }
        //
        // Summary:
        //     Gets a system generated property that denotes the last updated timestamp of the
        //     resource.
        public object _ts { get; }
        //
        // Summary:
        //     Gets a system generated property representing the resource etag required for
        //     optimistic concurrency control.
        public string _etag { get; }
    }
}
