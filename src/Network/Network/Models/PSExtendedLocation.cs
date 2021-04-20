using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSExtendedLocation
    {
        public PSExtendedLocation()
        { }

        public PSExtendedLocation(ExtendedLocation extendedLocation)
        {
            this.Name = extendedLocation.Name;
            this.Type = ExtendedLocation.Type;
        }

        public string Name { get; set; }
        public string Type { get; set; }
    }
}
