using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Security.Models.Topology
{
    public class PSsecurityTopologySingleResourceParent
    {
        /// <summary>
        /// Gets azure resource id which serves as parent resource in topology
        /// view
        /// </summary>
        public string ResourceId { get; set; }
    }
}
