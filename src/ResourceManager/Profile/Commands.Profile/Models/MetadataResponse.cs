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
        private string _galleryEndpoint;
        private string _graphEndpoint;
        private string _portalEndpoint;

        public string GalleryEndpoint
        {
            get { return this._galleryEndpoint; }
            set { this._galleryEndpoint = value; }
        }

        public string GraphEndpoint
        {
            get { return this._graphEndpoint; }
            set { this._graphEndpoint = value; }
        }

        public string PortalEndpoint
        {
            get { return this._portalEndpoint; }
            set { this._portalEndpoint = value; }
        }

        public Authentication authentication { get; set; }
    }

    public class Authentication
    {
        private string _loginEndpoint;
        private string[] _audiences;

        public string LoginEndpoint
        {
            get { return this._loginEndpoint; }
            set { this._loginEndpoint = value; }
        }

        public string[] Audiences
        {
            get { return this._audiences; }
            set { this._audiences = value; }
        }
    }
}