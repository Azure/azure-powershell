using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models
{
    class PSConnectionMonitorTestConfiguration
    { 
        public string Name { get; set; }
        public int? TestFrequencySec { get; set; }
        public string Protocol { get; set; }
        public string PreferredIPVersion { get; set; }
        public PSConnectionMonitorHttpConfiguration HttpConfiguration { get; set; }
        public PSConnectionMonitorTcpConfiguration TcpConfiguration { get; set; }
        public PSConnectionMonitorIcmpConfiguration IcmpConfiguration { get; set; }
        public PSConnectionMonitorSuccessThreshold SuccessThreshold { get; set; }
    }
}
