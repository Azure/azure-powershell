using Microsoft.Azure.Management.OperationalInsights.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSWorkspacePurgeStatusResponse
    {
        public PSWorkspacePurgeStatusResponse(WorkspacePurgeStatusResponse purgeStatusResponse)
        {
            Status = purgeStatusResponse.Status;
        }

        public string Status { get; set; }
    }
}
