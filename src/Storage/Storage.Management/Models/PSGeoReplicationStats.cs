﻿// ----------------------------------------------------------------------------------
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

using Track2Models = Azure.ResourceManager.Storage.Models;
using System;

namespace Microsoft.Azure.Commands.Management.Storage.Models
{
    public class PSGeoReplicationStats
    {
        //Parse GeoReplicationStats in SDK to wrapped property PSGeoReplicationStats
        public static PSGeoReplicationStats ParsePSGeoReplicationStats(Track2Models.GeoReplicationStats geoReplicationStats)
        {
            if (geoReplicationStats == null)
            {
                return null;
            }

            PSGeoReplicationStats pSGeoReplicationStats = new PSGeoReplicationStats
            {
                Status = geoReplicationStats.Status?.ToString(),
                LastSyncTime = geoReplicationStats.LastSyncOn,
                CanFailover = geoReplicationStats.CanFailover != null ? geoReplicationStats.CanFailover : null
            };
            return pSGeoReplicationStats;
        }

        public string Status { get; set; }
        public DateTimeOffset? LastSyncTime { get; set; }
        public bool? CanFailover { get; set; }
    }
}
