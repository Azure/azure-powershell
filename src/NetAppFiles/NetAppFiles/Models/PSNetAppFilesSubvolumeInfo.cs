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
namespace Microsoft.Azure.Commands.NetAppFiles.Models
{
    using System;
    using System.Collections.Generic;

    public class PSNetAppFilesSubvolumeInfo
    {
        /// <summary>
        /// Gets or sets the Resource group name
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets fully qualified resource ID for the resource. Ex -
        /// /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>        
        public string Id { get; set; }

        /// <summary>
        /// Gets the name of the resource
        /// </summary>        
        public string Name { get; set; }

        /// <summary>
        /// Gets the type of the resource. E.g.
        /// "Microsoft.Compute/virtualMachines" or
        /// "Microsoft.Storage/storageAccounts"
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets resource etag
        /// </summary>
        /// <remarks>
        /// A unique read-only string that changes whenever the resource is updated.
        /// </remarks>
        public string Etag { get; set; }

        /// <summary>
        /// Gets or sets path
        /// </summary>
        /// <remarks>
        /// Path to the subvolume
        /// </remarks>
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets size
        /// </summary>
        /// <remarks>
        /// Truncate subvolume to the provided size in bytes
        /// </remarks>
        public long? Size { get; set; }

        /// <summary>
        /// Gets or sets name
        /// </summary>
        /// <remarks>
        /// parent path to the subvolume
        /// </remarks>
        public string ParentPath { get; set; }

        /// <summary>
        /// Gets azure lifecycle management
        /// </summary>        
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Gets the system meta data relating to this resource.
        /// </summary>        
        public PSSystemData SystemData { get; set; }
    }
}
