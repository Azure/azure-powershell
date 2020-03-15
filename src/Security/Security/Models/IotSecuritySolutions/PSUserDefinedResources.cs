using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Security.Models.IotSecuritySolutions
{
    public class PSUserDefinedResources
    {
        public string Query { get; set; }

        public IList<string> QuerySubscriptions { get; set; }
    }
}
