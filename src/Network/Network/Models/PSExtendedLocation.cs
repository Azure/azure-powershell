using Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSExtendedLocation
    {
        public PSExtendedLocation()
        { }

        public PSExtendedLocation(string EdgeZone)
        {
            var extendedLocation = new ExtendedLocation(EdgeZone);
            this.Name = extendedLocation.Name;
            this.Type = ExtendedLocation.Type;
        }

        public string Name { get; set; }
        public string Type { get; set; }
    }
}
