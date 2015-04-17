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
using System.Management.Automation;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    /// <summary>
    /// Stop the specified device job if its in progress and is cancellable.
    /// </summary>
    [Cmdlet("Stop", "AzureStorSimpleJob"), OutputType(typeof(DeviceJobDetails))]
    public class StopAzureStorSimpleJob : StorSimpleCmdletBase
    {
        /// <summary>
        /// Device job id of the job to stop.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, HelpMessage = StorSimpleCmdletHelpMessage.DeviceJobId, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string InstanceId { get; set; }

        /// <summary>
        /// Wheter to prompt for permission or not.
        /// </summary>
        [Parameter(Position = 1, HelpMessage = StorSimpleCmdletHelpMessage.Force)]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                ConfirmAction(
                   Force.IsPresent,
                   string.Format(Resources.StopAzureStorSimpleJobWarningMessage, InstanceId),
                   string.Format(Resources.StopAzureStorSimpleJobMessage, InstanceId),
                  InstanceId,
                  () =>
                  {
                      // Get details of the job being cancelled.
                      var deviceJobDetails = StorSimpleClient.GetDeviceJobById(InstanceId);
                      if (deviceJobDetails == null)
                      {
                          throw new ArgumentException(string.Format(Resources.NoDeviceJobFoundWithGivenIdMessage, InstanceId));
                      }

                      // Make sure the job is running and cancellable, else fail.
                      if (!(deviceJobDetails.IsJobCancellable && deviceJobDetails.Status == "Running"))
                      {
                          throw new ArgumentException(string.Format(Resources.JobNotRunningOrCancellable, InstanceId));
                      }

                      // issue call to cancel the job.
                      WriteVerbose(string.Format(Resources.StoppingDeviceJob,InstanceId));
                      var taskStatusInfo = StorSimpleClient.StopDeviceJob(deviceJobDetails.Device.InstanceId, InstanceId);
                      HandleSyncTaskResponse(taskStatusInfo, "stop");
                      if (taskStatusInfo.AsyncTaskAggregatedResult == AsyncTaskAggregatedResult.Succeeded)
                      {
                          WriteVerbose(Resources.StopDeviceJobSucceeded);
                          WriteObject(deviceJobDetails);
                      }
                  });
            }
            catch (Exception exception)
            {
                HandleException(exception);
            }
        }
    }
}

