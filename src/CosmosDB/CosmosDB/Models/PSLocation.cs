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

using Microsoft.Azure.Management.CosmosDB.Models;

namespace Microsoft.Azure.Commands.CosmosDB.Models
{
    public class PSLocation
    {
        public PSLocation()
        {
        }

        public PSLocation(string locationName, int? failoverPriority, bool? isZoneRedundant)
        {
            LocationName = locationName;
            FailoverPriority = failoverPriority;
            IsZoneRedundant = isZoneRedundant;
        }

        public PSLocation(Location location)
        {
            LocationName = location.LocationName;
            FailoverPriority = location.FailoverPriority;
            IsZoneRedundant = location.IsZoneRedundant;
        }
        //
        // Summary:
        //     Gets or sets the name of the region.
        public string LocationName { get; set; }
        //
        // Summary:
        //     Gets or sets the failover priority of the region. A failover priority of 0 indicates
        //     a write region. The maximum value for a failover priority = (total number of
        //     regions - 1). Failover priority values must be unique for each of the regions
        //     in which the database account exists.
        public int? FailoverPriority { get; set; }
        //
        // Summary:
        //     Gets or sets flag to indicate whether or not this region is an AvailabilityZone
        //     region
        public bool? IsZoneRedundant { get; set; }

        static public Location ConvertPSLocationToLocation(PSLocation location)
        {
            return new Location
            {
                LocationName = location.LocationName,
                FailoverPriority = location.FailoverPriority,
                IsZoneRedundant = location.IsZoneRedundant
            };
        }
    }
}