// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

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
