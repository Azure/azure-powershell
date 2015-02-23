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
using System.Linq;
using System.Management.Automation;
using Hyak.Common;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;
using Microsoft.WindowsAzure.Commands.StorSimple;
using System.Net.Sockets;

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
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyById, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageDeviceJobId)]
        [ValidateNotNullOrEmptyAttribute]
        public string JobId { get; set; }

        /// <summary>
        /// Wheter to prompt for permission or not.
        /// </summary>
        [Parameter(Position = 1, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageForce)]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                ConfirmAction(
                   Force.IsPresent,
                   string.Format(Resources.StopASSJobWarningMessage, JobId),
                   string.Format(Resources.StopASSJobMessage, JobId),
                  JobId,
                  () =>
                  {
                      // Get details of the job being cancelled.
                      var deviceJobDetails = StorSimpleClient.GetDeviceJobById(JobId);
                      if (deviceJobDetails == null)
                      {
                          WriteVerbose(string.Format(Resources.NoDeviceJobFoundWithGivenIdMessage, JobId));
                          WriteObject(null);
                          return;
                      }

                      // issue call to cancel the job.
                      WriteVerbose(string.Format(Resources.StoppingDeviceJob,JobId));
                      var taskStatusInfo = StorSimpleClient.StopDeviceJob(deviceJobDetails.Device.InstanceId, JobId);
                      HandleSyncTaskResponse(taskStatusInfo, "stop");
                      if (taskStatusInfo.AsyncTaskAggregatedResult == AsyncTaskAggregatedResult.Succeeded)
                      {
                          WriteVerbose(Resources.StopDeviceJobSucceeded);
                          WriteObject(deviceJobDetails);
                          return;
                      }
                      return;
                  });
                return;
            }
            catch (Exception exception)
            {
                HandleException(exception);
            }
        }
    }
}

