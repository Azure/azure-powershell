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
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Microsoft.Azure.Management.StorageCache;

    /// <summary>
    /// Base Cmdlet class for HPC cache cmdlets.
    /// </summary>
    public abstract class HpcCacheBaseCmdlet : AzureRMCmdlet
    {
        protected const string CacheNameAlias = "CacheName";
        protected const string StoragTargetNameAlias = "StorageTargetName";

        protected const string ResourceIdParameterSet = "ByResourceIdParameterSet";
        protected const string ObjectParameterSet = "ByObjectParameterSet";
        protected const string ParentObjectParameterSet = "ByParentObjectParameterSet";
        protected const string FieldsParameterSet = "ByFieldsParameterSet";

        private HpcCacheManagementClientWrapper hpcCacheClientWrapper;

        /// <summary>
        /// Gets or Sets HPC Cache client.
        /// </summary>
        public IStorageCacheManagementClient HpcCacheClient
        {
            get
            {
                if (this.hpcCacheClientWrapper == null)
                {
                    this.hpcCacheClientWrapper = new HpcCacheManagementClientWrapper(this.DefaultProfile.DefaultContext);
                }

                this.hpcCacheClientWrapper.VerboseLogger = this.WriteVerboseWithTimestamp;
                this.hpcCacheClientWrapper.ErrorLogger = this.WriteErrorWithTimestamp;
                this.hpcCacheClientWrapper.HpcCacheManagementClient.ApiVersion = "2019-11-01";
                return this.hpcCacheClientWrapper.HpcCacheManagementClient;
            }

            set
            {
                this.hpcCacheClientWrapper = new HpcCacheManagementClientWrapper(value);
            }
        }

        /// <summary>
        /// HashtableToDictionary.
        /// </summary>
        /// <typeparam name="TK">Key.</typeparam>
        /// <typeparam name="TV">Value.</typeparam>
        /// <param name="table">Hashtable.</param>
        /// <returns>Dictionary.</returns>
        public static Dictionary<TK, TV> HashtableToDictionary<TK, TV>(Hashtable table)
        {
            return table
                .Cast<DictionaryEntry>()
                .ToDictionary(kvp => (TK)kvp.Key, kvp => (TV)kvp.Value);
        }
    }
}
