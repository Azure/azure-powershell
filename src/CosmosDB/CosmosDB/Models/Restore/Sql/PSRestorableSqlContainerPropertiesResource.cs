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
    public class PSRestorableSqlContainerPropertiesResource
    {
        public PSRestorableSqlContainerPropertiesResource()
        {
        }

        public PSRestorableSqlContainerPropertiesResource(RestorableSqlContainerPropertiesResource restorableSqlContainerPropertiesResource)
        {
            if (restorableSqlContainerPropertiesResource == null)
            {
                return;
            }

            _rid = restorableSqlContainerPropertiesResource._rid;
            OperationType = restorableSqlContainerPropertiesResource.OperationType;
            EventTimestamp = restorableSqlContainerPropertiesResource.EventTimestamp;
            OwnerId = restorableSqlContainerPropertiesResource.OwnerId;
            OwnerResourceId = restorableSqlContainerPropertiesResource.OwnerResourceId;
            Container = new PSRestorableSqlContainerPropertiesResourceContainer(restorableSqlContainerPropertiesResource.Container);
        }

        /// <summary>
        /// Gets a system generated property. A unique identifier.
        /// </summary>
        public string _rid { get; private set; }

        /// <summary>
        /// Gets the operation type of this container event. Possible values
        /// include: 'Create', 'Replace', 'Delete', 'SystemOperation'
        /// </summary>
        public string OperationType { get; private set; }

        /// <summary>
        /// Gets the timestamp of this container event.
        /// </summary>
        public string EventTimestamp { get; private set; }

        /// <summary>
        /// Gets the name of this restorable SQL container.
        /// </summary>
        public string OwnerId { get; private set; }

        /// <summary>
        /// Gets the resource Id of this restorable SQL container.
        /// </summary>
        public string OwnerResourceId { get; private set; }

        /// <summary>
        /// Gets the container properties of the restorable SQL container
        /// </summary>
        public PSRestorableSqlContainerPropertiesResourceContainer Container { get; set; }
    }
}
