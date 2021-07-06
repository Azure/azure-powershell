using Microsoft.Azure.Management.OperationalInsights.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSWorkspacePurgeResponse
    {
        public PSWorkspacePurgeResponse(WorkspacePurgeResponse purgeResponse)
        {
            OperationId = purgeResponse.OperationId ;
        }

        public string OperationId { get; set; }

    }
}
