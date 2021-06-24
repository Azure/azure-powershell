using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Models
{
    public class PSExtendedLocation
    {
        public PSExtendedLocation()
        { }

        public PSExtendedLocation(string EdgeZone)
        {
            var extendedLocation = new ExtendedLocation(EdgeZone);

            this.Name = extendedLocation.Name;
            this.Type = ExtendedLocationTypes.EdgeZone;
        }

        public string Name { get; set; }

        public string Type { get; set; }
    }
}
