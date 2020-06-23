using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Security.Models.AllowedConnection
{
    public class PSSecurityConnectableResources
    {
        /// <summary>
        /// Gets azure resource id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets The list of Azure resources that the resource has inbound allowed connection from
        /// </summary>
        public IList<PSSecurityConnectedResource> InboundConnectedResources { get; set; }

        /// <summary>
        /// The list of Azure resources that the resource has outbound allowed connection to
        /// </summary>
        public IList<PSSecurityConnectedResource> OutboundConnectedResources { get; set; }

    }
}
