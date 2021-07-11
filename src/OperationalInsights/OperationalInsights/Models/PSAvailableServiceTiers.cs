using Microsoft.Azure.Management.OperationalInsights.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSAvailableServiceTiers
    {

        public PSAvailableServiceTiers(AvailableServiceTier serviceTier)
        {
            ServiceTier = serviceTier.ServiceTier;
            Enabled = serviceTier.Enabled;
            MinimumRetention = serviceTier.MinimumRetention;
            MaximumRetention = serviceTier.MaximumRetention;
            DefaultRetention = serviceTier.DefaultRetention;
            CapacityReservationLevel = serviceTier.CapacityReservationLevel;
            LastSkuUpdate = serviceTier.LastSkuUpdate;
        }

        public string ServiceTier { get; }

        public bool? Enabled { get; }

        public long? MinimumRetention { get; }

        public long? MaximumRetention { get; }

        public long? DefaultRetention { get; }

        public long? CapacityReservationLevel { get; }

        public string LastSkuUpdate { get; }
    }
}
