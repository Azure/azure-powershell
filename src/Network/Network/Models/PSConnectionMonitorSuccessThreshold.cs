using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSConnectionMonitorSuccessThreshold
    {
        public int? ChecksFailedPercent { get; set; }
        public int? RoundTripTimeMs { get; set; }
    }
}
