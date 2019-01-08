using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Analysis.Models;

namespace Microsoft.Azure.Commands.AnalysisServices.Models
{
    public class ServerGateway
    {
        public string GatewayResourceId { get; set; }

        public string GatewayObjectId { get; set; }

        public string DmtsClusterUri { get; set; }

        internal static ServerGateway FromResourceGateway(GatewayDetails resourceGateway)
        {
            return new ServerGateway()
            {
               GatewayResourceId = resourceGateway.GatewayResourceId,
                GatewayObjectId = resourceGateway.GatewayObjectId != null ? resourceGateway.GatewayObjectId : null,
               DmtsClusterUri = resourceGateway.DmtsClusterUri != null ? resourceGateway.DmtsClusterUri : null
            };
        }
    }
}
