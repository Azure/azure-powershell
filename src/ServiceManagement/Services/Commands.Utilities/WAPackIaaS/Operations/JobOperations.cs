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

using System;
using System.Globalization;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.DataContract;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.Exceptions;

namespace Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.Operations
{
    internal class JobOperations : OperationsBase<Job>
    {
        public JobOperations(WebClientFactory webClientFactory)
            : base(webClientFactory, "/Jobs")
        {
        }

        /// <summary>
        /// Waits until the job with the given ID is completed, then returns the job object.
        /// Default timeout (-1) is unlimited, but can be limited by specifying a value in milliseconds. 
        /// If timeout is reached before the job is finished, the latest version of the job object is returned.
        /// If timeout is a possibility, caller must check the returned job object to determine whether the job finished or timeout occurred.
        /// </summary>
        /// <param name="jobId">GUID of the job to wait on</param>
        /// <param name="timeout">Duration of time, in milliseconds, to wait for the job before returning. -1 means unlimited.</param>
        /// <returns>Job object</returns>
        public JobInfo WaitOnJob(Guid jobId, long timeout = -1)
        {
            var errorMessage = String.Format(CultureInfo.InvariantCulture, Resources.OperationTimedOutOrError, jobId);
            var startTime = DateTime.Now;

            Job job = null;
            do
            {
                try
                {
                    job = this.Read(jobId);
                }
                catch (WAPackOperationException)
                {
                    break;
                }

                if (job.IsCompleted == true)
                    break;
                System.Threading.Thread.Sleep(3000);
            }
            while ((DateTime.Now - startTime).TotalMilliseconds < timeout || timeout < 0);

            if (job != null)
            {
                if ((String.Compare(job.Status, "Completed", StringComparison.InvariantCultureIgnoreCase) == 0) ||
                    (String.Compare(job.Status, "SucceedWithInfo", StringComparison.InvariantCultureIgnoreCase) == 0))
                {
                    return new JobInfo(JobStatusEnum.CompletedSuccessfully, null);
                }
                else
                    if ((String.Compare(job.Status, "Invalid", StringComparison.InvariantCultureIgnoreCase) == 0) ||
                        (String.Compare(job.Status, "Failed", StringComparison.InvariantCultureIgnoreCase) == 0) ||
                        (String.Compare(job.Status, "Canceled", StringComparison.InvariantCultureIgnoreCase) == 0))
                    {
                        errorMessage = string.Format(CultureInfo.InvariantCulture, Resources.FailedJobErrorMessage, jobId, job.ErrorInfo.ErrorCodeString, job.ErrorInfo.ExceptionDetails);
                        return new JobInfo(JobStatusEnum.Failed, errorMessage);
                    }
            }
            else
            {
                errorMessage = String.Format(CultureInfo.InvariantCulture, Resources.JobNotFound, jobId);
                return new JobInfo(JobStatusEnum.JobNotFound, errorMessage);
            }

            return new JobInfo(JobStatusEnum.OperationTimedOut, errorMessage); 
        }
    }
}
