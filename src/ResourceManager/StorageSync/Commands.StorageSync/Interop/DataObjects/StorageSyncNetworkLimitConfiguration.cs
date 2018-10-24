// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StorageSyncNetworkLimitConfiguration.cs" company="Microsoft Corporation.">
//   All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

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
