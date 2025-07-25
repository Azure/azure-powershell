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

    public class PSSqlClientEncryptionKeyGetResults
    {
        public PSSqlClientEncryptionKeyGetResults()
        {
        }        
        
        public PSSqlClientEncryptionKeyGetResults(ClientEncryptionKeyGetResults clientEncryptionKeyGetResults)
        {
            if (clientEncryptionKeyGetResults == null)
            {
                return;
            }

            Name = clientEncryptionKeyGetResults.Name;
            Id = clientEncryptionKeyGetResults.Id;
            Resource = new PSSqlClientEncryptionKeyGetPropertiesResource(clientEncryptionKeyGetResults.Resource);
        }

        /// <summary>
        /// Gets or sets Name of the Cosmos DB Client Encryption Key
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Id of the Cosmos DB Client Encryption Key
        /// </summary>
        public string Id { get; set; }

        public PSSqlClientEncryptionKeyGetPropertiesResource Resource { get; set; }
    }
}
