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

using Microsoft.Azure.Management.Synapse.Models;
using System;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSystemData
    {
        public PSSystemData(SystemData systemData)
        {
            this.CreatedAt = systemData?.CreatedAt;
            this.CreatedBy = systemData?.CreatedBy;
            this.CreatedByType = systemData?.CreatedByType;
            this.LastModifiedAt = systemData?.LastModifiedAt;
            this.LastModifiedBy = systemData?.LastModifiedBy;
            this.LastModifiedByType = systemData?.LastModifiedByType;
        }

        /// <summary>
        /// Gets the identity that created the resource.
        /// </summary>
        public string CreatedBy { get; }

        /// <summary>
        /// Gets the type of identity that created the resource: User|Application|ManagedIdentity|Key
        /// Possible values include: 'User', 'Application', 'ManagedIdentity', 'Key'
        /// </summary>
        public string CreatedByType { get; }

        /// <summary>
        /// Gets the timestamp of resource creation (UTC).
        /// </summary>
        public DateTime? CreatedAt { get; }

        /// <summary>
        /// Gets the identity that last modified the resource.
        /// </summary>
        public string LastModifiedBy { get; }

        /// <summary>
        /// Gets the type of identity that last modified the resource: User|Application|ManagedIdentity|Key
        /// Possible values include: 'User', 'Application', 'ManagedIdentity', 'Key'
        /// </summary>
        public string LastModifiedByType { get; }

        /// <summary>
        /// Gets the timestamp of resource last modification (UTC).
        /// </summary>
        public DateTime? LastModifiedAt { get; }
    }
}