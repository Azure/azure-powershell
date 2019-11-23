using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models
{
    class PSConnectionMonitorSuccessThreshold
    {
        public int? ChecksFailedPercent { get; set; }
        public bool? DisableTraceRoute { get; set; }
    }
}
