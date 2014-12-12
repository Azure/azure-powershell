using Microsoft.WindowsAzure.Management.StorSimple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Models
{
    public class JobReport
    {
        public string JobId { get; set; }
        public JobResult JobResult { get; set; }
        public JobStatus JobStatus { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public IList<JobStep> JobSteps { get; set; }

        public JobReport(JobStatusInfo jobStatusInfo)
        {
            this.JobId = jobStatusInfo.JobId;
            this.JobResult = jobStatusInfo.Result;
            this.JobStatus = jobStatusInfo.Status;
            this.ErrorCode = jobStatusInfo.Error.Code;
            this.ErrorMessage = jobStatusInfo.Error.Message;
            this.JobSteps = jobStatusInfo.JobSteps;
        }
    }
}
