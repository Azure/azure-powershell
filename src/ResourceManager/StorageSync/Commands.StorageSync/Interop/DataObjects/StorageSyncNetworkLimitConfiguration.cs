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

namespace Commands.StorageSync.Interop.DataObjects
{
    using Commands.StorageSync.Interop.Interfaces;
    using System;



    public class StorageSyncNetworkLimitConfiguration : INetworkLimitConfigEntry
    {
        public StorageSyncNetworkLimitConfiguration(INetworkLimitConfigEntry entry = null)
        {
            if (entry != null)
            {
                Id = entry.Id;
                Day = entry.Day;
                StartHour = entry.StartHour;
                StartMinute = entry.StartMinute;
                EndHour = entry.EndHour;
                EndMinute = entry.EndMinute;
                LimitKbps = entry.LimitKbps;
            }
        }

        public string Id { get; set; }

        public DayOfWeek Day { get; set; }

        public uint StartHour { get; set; }

        public uint StartMinute { get; set; }

        public uint EndHour { get; set; }

        public uint EndMinute { get; set; }

        public uint LimitKbps { get; set; }
    }
}
