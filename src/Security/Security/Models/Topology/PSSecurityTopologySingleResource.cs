using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Security.Models.Topology
{
    public class PSSecurityTopologySingleResource
    {
        /// <summary>
        /// Gets azure resource id
        /// </summary>
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets the security severity of the resource
        /// </summary>
        public string Severity { get; set; }

        /// <summary>
        /// Gets indicates if the resource has security recommendations
        /// </summary>
        public bool? RecommendationsExist { get; set; }

        /// <summary>
        /// Gets indicates the resource connectivity level to the Internet
        /// (InternetFacing, Internal ,etc.)
        /// </summary>
        public string NetworkZones { get; set; }

        /// <summary>
        /// Gets score of the resource based on its security severity
        /// </summary>
        public int? TopologyScore { get; set; }

        /// <summary>
        /// Gets the location of this resource
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets azure resources connected to this resource which are in higher
        /// level in the topology view
        /// </summary>
        public IList<PSsecurityTopologySingleResourceParent> Parents { get; set; }

        /// <summary>
        /// Gets azure resources connected to this resource which are in lower
        /// level in the topology view
        /// </summary>
        public IList<PSSecurityTopologySingleResourceChild> Children { get; set; }

    }
}
