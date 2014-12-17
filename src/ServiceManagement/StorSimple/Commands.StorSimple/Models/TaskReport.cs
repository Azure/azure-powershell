using Microsoft.WindowsAzure.Management.StorSimple.Models;
using System.Collections.Generic;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Models
{
    public class TaskReport
    {
        public string TaskId { get; set; }
        public AsyncTaskResult TaskResult { get; set; }
        public AsyncTaskStatus TaskStatus { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public IList<TaskStep> TaskSteps { get; set; }

        public TaskReport(TaskStatusInfo taskStatusInfo)
        {
            this.TaskId = taskStatusInfo.TaskId;
            this.TaskResult = taskStatusInfo.Result;
            this.TaskStatus = taskStatusInfo.Status;
            this.ErrorCode = taskStatusInfo.Error.Code;
            this.ErrorMessage = taskStatusInfo.Error.Message;
            this.TaskSteps = taskStatusInfo.TaskSteps;
        }
    }
}
