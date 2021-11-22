using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSVirtualNetworkEncryption
    {
        public string Enabled { get; set; }

        public string Enforcement { get; set; }
    }
}
