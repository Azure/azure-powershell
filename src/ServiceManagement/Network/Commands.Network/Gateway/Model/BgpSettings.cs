using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network
{
    public class BgpSettings
    {
        public uint Asn { get; set; }

        public string BgpPeeringAddress { get; set; }

        public int PeerWeight { get; set; }
    }
}
