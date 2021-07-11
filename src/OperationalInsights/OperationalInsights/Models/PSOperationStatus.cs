using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Management.OperationalInsights.Models;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSOperationStatus
    {
        public PSOperationStatus(Management.OperationalInsights.Models.OperationStatus opStatus)
        {
            Id = opStatus.Id;
            Name = opStatus.Name;
            Status = opStatus.Status;
            Error = opStatus.Error;
            EndTime = opStatus.EndTime;
            StartTime = opStatus.StartTime;
        }

        public string Id { set; get; }
        public string Name { set; get; }
        public string Status { set; get; }
        public ErrorResponse Error { set; get; }
        public string EndTime { set; get; }
        public string StartTime { set; get; }
    }
}
