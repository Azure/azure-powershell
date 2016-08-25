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

    [Cmdlet(VerbsCommon.New, "AzureManagedCacheNamedCache"), OutputType(typeof(PSCacheServiceWithNamedCaches))]
    public class NewAzureManagedCacheNamedCache : ManagedCacheCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string NamedCache { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateSet("Absolute", "Sliding", "Never", IgnoreCase = false)]
        public string ExpiryPolicy { get; set; }

        [Parameter(Mandatory = false)]
        public int? ExpiryTime { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter WithNotifications { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter WithHighAvailability { get; set; }
        
        [Parameter(Mandatory = false)]
        public SwitchParameter WithoutEviction { get; set; }

        private string _DefaultExpiryPolicy = "Absolute";
        private int _DefaultExpiryTime = 10;

        public override void ExecuteCmdlet()
        {
            WriteWarning("Managed Cache will be retired on 11/30/2016. Please migrate to Azure Redis Cache. For more information, see http://go.microsoft.com/fwlink/?LinkID=717458");

            if (string.IsNullOrEmpty(ExpiryPolicy))
            {
                ExpiryPolicy = _DefaultExpiryPolicy;
            }

            if (ExpiryTime == null)
            {
                ExpiryTime = _DefaultExpiryTime;
            }

            string cacheServiceName = CacheClient.NormalizeCacheServiceName(Name);
            CacheClient.ProgressRecorder = (p) => { WriteVerbose(p); };
            WriteObject(new PSCacheServiceWithNamedCaches(CacheClient.AddNamedCache(cacheServiceName, NamedCache, ExpiryPolicy, (int)ExpiryTime,
                WithoutEviction.IsPresent, WithNotifications.IsPresent, WithHighAvailability.IsPresent)));
        }
    }
}