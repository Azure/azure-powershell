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
    using StorageCacheModels = Microsoft.Azure.Management.StorageCache.Models;

    /// <summary>
    /// PSHpcClfsTarget.
    /// </summary>
    public class PSHpcClfsTarget
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSHpcClfsTarget"/> class.
        /// </summary>
        /// <param name="clfsTarget">clfsTarget.</param>
        public PSHpcClfsTarget(StorageCacheModels.ClfsTarget clfsTarget)
        {
            this.Target = clfsTarget.Target;
        }

        /// <summary>
        /// Gets or Sets Clfs Target.
        /// </summary>
        public string Target { get; set; }
    }
}