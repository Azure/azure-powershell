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

namespace Microsoft.Azure.Management.CosmosDB.Models
{
    public class PSRestorableMongodbCollectionPropertiesResource
    {
        public PSRestorableMongodbCollectionPropertiesResource()
        {
        }

        public PSRestorableMongodbCollectionPropertiesResource(RestorableMongodbCollectionPropertiesResource restorableMongodbCollectionPropertiesResource)
        {
            Rid = restorableMongodbCollectionPropertiesResource._rid;
            OperationType = restorableMongodbCollectionPropertiesResource.OperationType;
            EventTimestamp = restorableMongodbCollectionPropertiesResource.EventTimestamp;
            OwnerId = restorableMongodbCollectionPropertiesResource.OwnerId;
            OwnerResourceId = restorableMongodbCollectionPropertiesResource.OwnerResourceId;
        }

        /// <summary>
        /// Gets a system generated property. A unique identifier.
        /// </summary>
        public string Rid { get; private set; }

        /// <summary>
        /// Gets the operation type of this collection event. Possible values
        /// include: 'Create', 'Replace', 'Delete', 'SystemOperation'
        /// </summary>
        public string OperationType { get; private set; }

        /// <summary>
        /// Gets the timestamp of this collection event.
        /// </summary>
        public string EventTimestamp { get; private set; }

        /// <summary>
        /// Gets the name of this restorable MongoDB collection.
        /// </summary>
        public string OwnerId { get; private set; }

        /// <summary>
        /// Gets the resource Id of this restorable MongoDB collection.
        /// </summary>
        public string OwnerResourceId { get; private set; }
    }
}
