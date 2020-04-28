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

namespace Microsoft.Azure.PowerShell.Cmdlets.HPCCache.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Management.StorageCache.Models;
    using StorageCacheModels = Microsoft.Azure.Management.StorageCache.Models;

    /// <summary>
    /// Wrapper that wraps the response from .NET SDK.
    /// </summary>
    public class PSHpcStorageTarget
    {
        private StorageTarget storageTarget;

        /// <summary>
        /// Initializes a new instance of the <see cref="PSHpcStorageTarget"/> class.
        /// </summary>
        public PSHpcStorageTarget()
        {
            this.storageTarget = new StorageCacheModels.StorageTarget();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSHpcStorageTarget"/> class.
        /// </summary>
        /// <param name="storageTargetObj">storage target object.</param>
        public PSHpcStorageTarget(StorageCacheModels.StorageTarget storageTargetObj)
        {
            this.storageTarget = storageTargetObj ?? throw new ArgumentNullException("storageTargetObj");
            this.Name = storageTargetObj.Name;
            this.Id = storageTargetObj.Id;
            this.TargetType = storageTargetObj.TargetType;
            if (storageTargetObj.Nfs3 != null)
            {
                this.Nfs3 = new PSHpcNfs3Target(storageTargetObj.Nfs3);
            }

            if (storageTargetObj.Clfs != null)
            {
                this.Clfs = new PSHpcClfsTarget(storageTargetObj.Clfs);
            }

            this.ProvisioningState = storageTargetObj.ProvisioningState;
            this.Junctions = new List<PSNamespaceJunction>();
            this.Junctions = storageTargetObj.Junctions.Select(j => new PSNamespaceJunction(j.NamespacePath, j.NfsExport, j.TargetPath)).ToList();
        }

        /// <summary>
        /// Gets or Sets Storage target name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Storage target ID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets TargetType.
        /// </summary>
        public string TargetType { get; set; }

        /// <summary>
        /// Gets or Sets Storage target ProvisioningState.
        /// </summary>
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Gets or sets storage target junctions.
        /// </summary>
        public IList<PSNamespaceJunction> Junctions { get; set; }

        /// <summary>
        /// Gets or Sets Storage target Nfs3.
        /// </summary>
        public PSHpcNfs3Target Nfs3 { get; set; }

        /// <summary>
        /// Gets or Sets Storage target Clfs.
        /// </summary>
        public PSHpcClfsTarget Clfs { get; set; }
    }
}