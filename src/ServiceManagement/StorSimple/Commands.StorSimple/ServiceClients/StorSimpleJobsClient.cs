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
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.Management.StorSimple;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets.Library;

namespace Microsoft.WindowsAzure.Commands.StorSimple
{
    public partial class StorSimpleClient
    {
        /// <summary>
        /// Retrieve a device job for the specified id.
        /// </summary>
        /// <param name="instanceId">Instance id of the Device Job</param>
        /// <returns>DeviceJobDetails of the queried job. Null if job not found.</returns>
        public DeviceJobDetails GetDeviceJobById(string instanceId)
        {
            var deviceJobsResponse = this.GetStorSimpleClient().DeviceJob.Get(null, null, null, instanceId, null, null, 0, 1, this.GetCustomRequestHeaders());
            if (deviceJobsResponse == null)
            {
                return null;
            }
            return deviceJobsResponse.DeviceJobList.FirstOrDefault();
        }

        /// <summary>
        /// Get paginated list of device jobs based on provided filters.
        /// </summary>
        /// <param name="deviceId">id of device to filter jobs by</param>
        /// <param name="jobType">type of jobs to include in result.</param>
        /// <param name="jobStatus">status of jobs to include in result.</param>
        /// <param name="jobId">InstanceId of the job if single job is being fetched.</param>
        /// <param name="startTime">start of time interval for which to get jobs</param>
        /// <param name="endTime">end of time interval for which to get jobs</param>
        /// <param name="skip">number of results to be skipped</param>
        /// <param name="top">number of results to include.</param>
        /// <returns></returns>
        public GetDeviceJobResponse GetDeviceJobs(string deviceId, string jobType, string jobStatus, string jobId, string startTime, string endTime, int skip=0, int top=0) 
        {
            var deviceJobsResponse = this.GetStorSimpleClient().DeviceJob.Get(deviceId, jobType, jobStatus, jobId, startTime, endTime, skip, top, this.GetCustomRequestHeaders());

            return deviceJobsResponse;
        }

        /// <summary>
        /// Stop the specified device job.
        /// </summary>
        /// <param name="instanceId">Instance id of the job to be stopped.</param>
        public TaskStatusInfo StopDeviceJob(string deviceId, string instanceId)
        {
            var updateRequest = new UpdateDeviceJobRequest{
                DeviceJobAction = DeviceJobAction.Cancel
            };
            var stopJobResponse = this.GetStorSimpleClient().DeviceJob.UpdateDeviceJob(deviceId, instanceId, updateRequest, this.GetCustomRequestHeaders());
            return stopJobResponse;
        }
    }
}