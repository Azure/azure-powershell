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

namespace Microsoft.Azure.Commands.ManagedCache
{
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ManagedCache.Models;
    using Microsoft.Azure.Management.ManagedCache.Models;

    /// <summary>
    /// Retrieves a list of Microsoft Azure SQL Database servers in the selected subscription.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureManagedCache"), OutputType(typeof(PSCacheService))]
    public class SetAzureManagedCache : ManagedCacheCmdletBase, IDynamicParameters
    {
        private MemoryDynamicParameterSet memoryDynamicParameterSet = new MemoryDynamicParameterSet();

        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter]
        public CacheServiceSkuType Sku { get; set; }

        [Parameter]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            WriteWarning("Managed Cache will be retired on 11/30/2016. Please migrate to Azure Redis Cache. For more information, see http://go.microsoft.com/fwlink/?LinkID=717458");

            CacheClient.ProgressRecorder = (message) => { WriteVerbose(message); };
            string memory = memoryDynamicParameterSet.GetMemoryValue(Sku);
            PSCacheService cacheService = new PSCacheService(
                CacheClient.UpdateCacheService(Name, Sku, memory, ConfirmAction, Force.IsPresent));
            WriteObject(cacheService);
        }

        public object GetDynamicParameters()
        {
            return memoryDynamicParameterSet.GetDynamicParameters(Sku);
        }
    }
}