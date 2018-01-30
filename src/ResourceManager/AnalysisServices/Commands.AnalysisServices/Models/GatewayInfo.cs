using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Analysis.Models;

namespace Microsoft.Azure.Commands.AnalysisServices.Models
{
    public class GatewayCollection
    {
        public GatewayInfo[] value { get; set; }
    }

    public class GatewayInfo
    {
        public GatewayProperties properties {get; set;}
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string location { get; set; }
    }

    public class GatewayProperties
    {
        public GatewayInstallation connectionGatewayInstallation { get; set; }
        public string[] contactInformation { get; set; }
        public string displayName { get; set; }
        public string machineName { get; set; }
        public string status { get; set; }
        public Uri backendUri { get; set; }
        
    }

    public class GatewayInstallation
    {
        public string location { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public string type { get; set; }
    }
}
