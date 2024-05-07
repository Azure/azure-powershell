using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSNetworkVirtualApplianceRestartOperationStatusResponse
    {
        public string Name { get; set; }
        public IList<string> InstancesRestarted { get; set; }
        public string Status { get; set; }
        public string OperationId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public ApiError Error { get; set; }

        public PSNetworkVirtualApplianceRestartOperationStatusResponse()
        {
            this.Status = "Succeeded";
        }
    }

    public class ApiError
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public string Target { get; set; }

    }
}
