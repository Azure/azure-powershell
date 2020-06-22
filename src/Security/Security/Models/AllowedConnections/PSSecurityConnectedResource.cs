using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Security.Models.AllowedConnections
{
    public class PSSecurityConnectedResource
    {
        /// <summary>
        /// Gets azure resource id
        /// </summary>
        public string ConnectedResourceId { get; set; }
        /// <summary>
        /// Gets The allowed TCP ports
        /// </summary>
        public string TcpPorts { get; set; }
        /// <summary>
        /// Gets The allowed UDP ports
        /// </summary>
        public string UdpPorts { get; set; }
    }
}
