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

using Microsoft.Azure.Management.ServiceBus.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.ServiceBus.Models
{

    public class PSServiceBusMigrationConfigurationAttributes
    {
        public PSServiceBusMigrationConfigurationAttributes()
        { }

        public PSServiceBusMigrationConfigurationAttributes(MigrationConfigProperties mcResource)
        {
            if (mcResource != null)
            {
                Name = mcResource.Name;
                Id = mcResource.Id;
                Type = mcResource.Type;
                ProvisioningState = mcResource.ProvisioningState;
                TargetNamespace = mcResource.TargetNamespace;
                PostMigrationName = mcResource.PostMigrationName;
                PendingReplicationOperationsCount = mcResource.PendingReplicationOperationsCount;
                MigrationState = mcResource.MigrationState;
            }
        }

        public string Name { get; set; }

        public string Id { get; set; }

        public string Type { get; set; }

        /// <summary>
        /// Gets provisioning state of Migration Configuration
        /// </summary>
        public string ProvisioningState { get; private set; }

        /// <summary>
        /// Gets or sets existing premium Namespace name which has no entities,
        /// will be used for migration
        /// </summary>
        public string TargetNamespace { get; set; }

        /// <summary>
        /// Gets or sets name to access connection strings of the Primary
        /// Namespace after migration
        /// </summary>
        public string PostMigrationName { get; set; }

        /// <summary>
        /// Gets number of entities pending to be replicated.
        /// </summary>
        public long? PendingReplicationOperationsCount { get; private set; }

        /// <summary>
        /// Gets state in which Standard to Premium Migration is, possible
        /// values : Unknown, Reverting, Completing, Initiating, Syncing,
        /// Active
        /// </summary>
        public string MigrationState { get; set; }

    }
}