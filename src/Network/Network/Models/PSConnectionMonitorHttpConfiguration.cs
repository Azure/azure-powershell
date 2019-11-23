using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models
{
    class PSConnectionMonitorHttpConfiguration
    {
        public int? Port { get; set; }
        public string Method { get; set; }
        public string Path { get; set; }
        public IList<PSHTTPHeader> RequestHeaders { get; set; }
        public IList<string> ValidStatusCodeRanges { get; set; }
        public bool? PreferHTTPS { get; set; }
    }
}
