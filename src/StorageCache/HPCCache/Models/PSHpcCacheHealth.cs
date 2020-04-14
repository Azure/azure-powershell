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
    using System.Text;
    using StorageCacheModels = Microsoft.Azure.Management.StorageCache.Models;

    /// <summary>
    /// PSHpcCacheHealth.
    /// </summary>
    public class PSHpcCacheHealth
    {
        /// <summary>
        /// Gets cache health state.
        /// </summary>
        public string State;

        /// <summary>
        /// Gets cache health status description.
        /// </summary>
        public string StatusDescription;

        /// <summary>
        /// Initializes a new instance of the <see cref="PSHpcCacheHealth"/> class.
        /// </summary>
        /// <param name="health"> cache health object.</param>
        public PSHpcCacheHealth(StorageCacheModels.CacheHealth health)
        {
            this.State = health.State;
            this.StatusDescription = health.StatusDescription;
        }
    }
}