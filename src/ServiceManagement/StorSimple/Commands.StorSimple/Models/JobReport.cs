using Microsoft.WindowsAzure.Management.StorSimple.Models;
using System.Collections.Generic;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Models
{
    public class JobReport
    {
        public string JobId { get; set; }
        public AsyncTaskResult JobResult { get; set; }
        public AsyncTaskStatus JobStatus { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public IList<TaskStep> JobSteps { get; set; }

        public JobReport(TaskStatusInfo jobStatusInfo)
        {
            this.JobId = jobStatusInfo.TaskId;
            this.JobResult = jobStatusInfo.Result;
            this.JobStatus = jobStatusInfo.Status;
            this.ErrorCode = jobStatusInfo.Error.Code;
            this.ErrorMessage = jobStatusInfo.Error.Message;
            this.JobSteps = jobStatusInfo.TaskSteps;
        }
    }
}
