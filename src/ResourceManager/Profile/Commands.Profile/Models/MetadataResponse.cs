using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Profile.Models
{
    /// <summary>
    /// Class to receive meta data endpoints json as objects
    /// </summary>
    public class MetadataResponse
    {
        public string GalleryEndpoint { get; set; }

        public string GraphEndpoint { get; set; }

        public string PortalEndpoint { get; set; }

        public Authentication authentication { get; set; }
    }

    public class Authentication
    {
        public string LoginEndpoint { get; set; }

        public string[] Audiences { get; set; }
    }
}