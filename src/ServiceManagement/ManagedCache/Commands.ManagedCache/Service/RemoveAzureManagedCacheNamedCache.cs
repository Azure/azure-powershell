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

    [Cmdlet(VerbsCommon.Remove, "AzureManagedCacheNamedCache"), OutputType(typeof(bool))]
    public class RemoveAzureManagedCacheNamedCache : ManagedCacheCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string NamedCache { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter Force { get; set; }

        [Parameter]
        public SwitchParameter PassThru { get; set; }
        
        public override void ExecuteCmdlet()
        {
            WriteWarning("Managed Cache will be retired on 11/30/2016. Please migrate to Azure Redis Cache. For more information, see http://go.microsoft.com/fwlink/?LinkID=717458");

            string cacheServiceName = CacheClient.NormalizeCacheServiceName(Name);
            CacheClient.ProgressRecorder = (p) => { WriteVerbose(p); };
            CacheClient.RemoveNamedCache(cacheServiceName, NamedCache, ConfirmAction, Force.IsPresent);
            if (PassThru)
            {
                WriteObject(true);
            }
        }
    }
}