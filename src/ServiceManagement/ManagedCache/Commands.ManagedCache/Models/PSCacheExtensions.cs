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
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PSCacheExtensions
    {
        public static string ConstructNamedCachesTable(List<PSNamedCachesAttributes> namedCaches)
        {
            StringBuilder namedCachesTable = new StringBuilder();

            if (namedCaches != null && namedCaches.Count > 0)
            {
                int maxCacheNameLength = Math.Max("CacheName".Length, namedCaches.Where(r => r.CacheName != null).DefaultIfEmpty(EmptyNamedCaches).Max(r => r.CacheName.Length));
                int maxExpiryPolicyLength = Math.Max("ExpiryPolicy".Length, namedCaches.Where(r => r.ExpiryPolicy != null).DefaultIfEmpty(EmptyNamedCaches).Max(r => r.ExpiryPolicy.Length));
                int maxTimeToLiveInMinutesLength = Math.Max("TimeToLiveInMinutes".Length, namedCaches.Where(r => r != null).DefaultIfEmpty(EmptyNamedCaches).Max(r => r.TimeToLiveInMinutes.ToString().Length));
                int maxEvictionLength = Math.Max("Eviction".Length, namedCaches.Where(r => r.Eviction != null).DefaultIfEmpty(EmptyNamedCaches).Max(r => r.Eviction.Length));
                int maxNotificationsLength = Math.Max("Notifications".Length, namedCaches.Where(r => r.Notifications != null).DefaultIfEmpty(EmptyNamedCaches).Max(r => r.Notifications.Length));
                int maxHighAvailabilityLength = Math.Max("HighAvailability".Length, namedCaches.Where(r => r.HighAvailability != null).DefaultIfEmpty(EmptyNamedCaches).Max(r => r.HighAvailability.Length));

                string rowFormat = "{0, -" + maxCacheNameLength + "}  {1, -" + maxExpiryPolicyLength + "}  {2, -" + maxTimeToLiveInMinutesLength + "}  {3, -" + maxEvictionLength + "}  {4, -" + maxNotificationsLength + "}  {5, -" + maxHighAvailabilityLength + "}\r\n";
                namedCachesTable.AppendLine();
                namedCachesTable.AppendFormat(rowFormat, "CacheName", "ExpiryPolicy", "TimeToLiveInMinutes", "Eviction", "Notifications", "HighAvailability");
                namedCachesTable.AppendFormat(rowFormat,
                    GenerateSeparator(maxCacheNameLength, "="),
                    GenerateSeparator(maxExpiryPolicyLength, "="),
                    GenerateSeparator(maxTimeToLiveInMinutesLength, "="),
                    GenerateSeparator(maxEvictionLength, "="),
                    GenerateSeparator(maxNotificationsLength, "="),
                    GenerateSeparator(maxHighAvailabilityLength, "="));

                foreach (PSNamedCachesAttributes namedCache in namedCaches)
                {
                    namedCachesTable.AppendFormat(rowFormat, namedCache.CacheName, namedCache.ExpiryPolicy, namedCache.TimeToLiveInMinutes, namedCache.Eviction, namedCache.Notifications, namedCache.HighAvailability);
                }
            }
            return namedCachesTable.ToString();
        }

        private static PSNamedCachesAttributes EmptyNamedCaches
        {
            get
            {
                return new PSNamedCachesAttributes
                {
                    CacheName = string.Empty,
                    ExpiryPolicy = string.Empty,
                    TimeToLiveInMinutes = 0,
                    Eviction = string.Empty,
                    Notifications = string.Empty,
                    HighAvailability = string.Empty
                };
            }
        }

        private static string GenerateSeparator(int amount, string separator)
        {
            StringBuilder result = new StringBuilder();
            while (amount-- != 0) result.Append(separator);
            return result.ToString();
        }
    }
}
