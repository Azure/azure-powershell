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



    /// <summary>
    /// Class StorageSyncNetworkLimitConfiguration.
    /// Implements the <see cref="Commands.StorageSync.Interop.Interfaces.INetworkLimitConfigEntry" />
    /// </summary>
    /// <seealso cref="Commands.StorageSync.Interop.Interfaces.INetworkLimitConfigEntry" />
    public class StorageSyncNetworkLimitConfiguration : INetworkLimitConfigEntry
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StorageSyncNetworkLimitConfiguration" /> class.
        /// </summary>
        /// <param name="entry">The entry.</param>
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

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the day.
        /// </summary>
        /// <value>The day.</value>
        public DayOfWeek Day { get; set; }

        /// <summary>
        /// Gets or sets the start hour.
        /// </summary>
        /// <value>The start hour.</value>
        public uint StartHour { get; set; }

        /// <summary>
        /// Gets or sets the start minute.
        /// </summary>
        /// <value>The start minute.</value>
        public uint StartMinute { get; set; }

        /// <summary>
        /// Gets or sets the end hour.
        /// </summary>
        /// <value>The end hour.</value>
        public uint EndHour { get; set; }

        /// <summary>
        /// Gets or sets the end minute.
        /// </summary>
        /// <value>The end minute.</value>
        public uint EndMinute { get; set; }

        /// <summary>
        /// Gets or sets the limit KBPS.
        /// </summary>
        /// <value>The limit KBPS.</value>
        public uint LimitKbps { get; set; }
    }
}
