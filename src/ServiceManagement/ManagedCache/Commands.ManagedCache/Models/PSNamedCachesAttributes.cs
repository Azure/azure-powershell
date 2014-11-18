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

namespace Microsoft.Azure.Commands.ManagedCache.Models
{
    using Microsoft.Azure.Management.ManagedCache.Models;

    public class PSNamedCachesAttributes
    {
        public PSNamedCachesAttributes()
        { }

        public PSNamedCachesAttributes(IntrinsicSettings.CacheServiceInput.NamedCache namedCache)
        {
            CacheName = namedCache.CacheName;
            ExpiryPolicy = namedCache.ExpirationSettingsSection.Type;
            TimeToLiveInMinutes = namedCache.ExpirationSettingsSection.TimeToLiveInMinutes;
            Eviction = "LeastRecentlyUsed".Equals(namedCache.EvictionPolicy) ? "Enabled" : "Disabled";
            Notifications = namedCache.NotificationsEnabled ? "Enabled" : "Disabled";
            HighAvailability = namedCache.HighAvailabilityEnabled ? "Enabled" : "Disabled";
        }

        public string CacheName { get; set; }

        public string ExpiryPolicy { get; set; }

        public int TimeToLiveInMinutes { get; set; }
        
        public string Eviction { get; set; }

        public string Notifications { get; set; }

        public string HighAvailability { get; set; }
    }
}
