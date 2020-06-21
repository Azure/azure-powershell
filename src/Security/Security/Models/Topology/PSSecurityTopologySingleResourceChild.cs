using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Security.Models.Topology
{
    public class PSSecurityTopologySingleResourceChild
    {
        /// <summary>
        /// Gets azure resource id which serves as child resource in topology
        /// view
        /// </summary>
        public string ResourceId { get; set; }
    }
}
