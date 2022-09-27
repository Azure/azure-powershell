
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


namespace Microsoft.Azure.Commands.Network.Models.NetworkManager
{
    using Microsoft.Azure.Management.Network.Models;
    using System;

    public class PSSystemData
    {
        /// <summary>
        /// Gets or Sets the identity that created the resource.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or Sets the type of identity that created the resource: User|Application|ManagedIdentity|Key
        /// Possible values include: 'User', 'Application', 'ManagedIdentity', 'Key'
        /// </summary>
        public string CreatedByType { get; set; }

        /// <summary>
        /// Gets or Sets the timestamp of resource creation (UTC).
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or Sets the identity that last modified the resource.
        /// </summary>
        public string LastModifiedBy { get; set; }

        /// <summary>
        /// Gets or Sets the type of identity that last modified the resource: User|Application|ManagedIdentity|Key
        /// Possible values include: 'User', 'Application', 'ManagedIdentity', 'Key'
        /// </summary>
        public string LastModifiedByType { get; set; }

        /// <summary>
        /// Gets or Sets the timestamp of resource last modification (UTC).
        /// </summary>
        public DateTime? LastModifiedAt { get; set; }
    }
}
