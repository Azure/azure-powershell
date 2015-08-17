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
using System.Collections.Generic;
using System.Xml;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    /// <summary>
    /// Stop the specified device job if its in progress and is cancellable.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureStorSimpleJob"), OutputType(typeof(IList<DeviceJobDetails>), typeof(DeviceJobDetails))]
    public class GetAzureStorSimpleJob : StorSimpleCmdletBase
    {
        #region params
        /// <summary>
        /// Name of StorSimple device for which to fetch jobs
        /// </summary>
        [Parameter(Mandatory = false, Position = 0, HelpMessage=StorSimpleCmdletHelpMessage.DeviceName)]
        [ValidateNotNullOrEmpty]
        public string DeviceName { get; set; }

        /// <summary>
        /// InstanceId/JobId of the job to retrieve
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, HelpMessage = StorSimpleCmdletHelpMessage.DeviceJobId)]
        [ValidateNotNullOrEmpty]
        public string InstanceId { get; set; }

        /// <summary>
        /// Filter jobs by their status.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, HelpMessage=StorSimpleCmdletHelpMessage.DeviceJobStatus)]
        [ValidateSetAttribute(new string[] { "Running", "Completed", "Cancelled", "Failed", "Cancelling", "CompletedWithErrors" })]
        public string Status { get; set; }

        /// <summary>
        /// Filter jobs by their status.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, HelpMessage=StorSimpleCmdletHelpMessage.DeviceJobType)]
        [ValidateSetAttribute(new string[] { "Backup", "ManualBackup", "Restore", "CloneWorkflow", "DeviceRestore", "Update", "SupportPackage", "VirtualApplianceProvisioning" })]
        public string Type { get; set; }
        
        /// <summary>
        /// Filter jobs that were created after specified time
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, HelpMessage = StorSimpleCmdletHelpMessage.FromTime)]
        public DateTime? From { get; set; }

        /// <summary>
        /// Filter jobs that were created till specified time
        /// </summary
        [Parameter(Mandatory = false, Position = 5, HelpMessage = StorSimpleCmdletHelpMessage.ToTime)]
        public DateTime? To { get; set; }

        /// <summary>
        /// Number of results to skip
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, HelpMessage = StorSimpleCmdletHelpMessage.SkipDesc)]
        [ValidateRange(0, Int32.MaxValue)]
        public int? Skip { get; set; }

        /// <summary>
        /// Number of results to include.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, HelpMessage = StorSimpleCmdletHelpMessage.FirstDesc)]
        [ValidateRange(0, Int32.MaxValue)]
        public int? First { get; set; }
        #endregion params

        // Private helper properties.
        private string deviceId;
        private string fromDateTimeIsoString;
        private string toDateTimeIsoString;

        public override void ExecuteCmdlet()
        {
            try
            {
                // Make sure params were supplied appropriately.
                ProcessParameters();

                // Make call to get device jobs.
                var response = StorSimpleClient.GetDeviceJobs(deviceId, Type, Status, InstanceId, fromDateTimeIsoString, toDateTimeIsoString, (int)Skip, (int)First);

                WriteObject(response.DeviceJobList, true);
                WriteVerbose(string.Format(Resources.DeviceJobsReturnedCount, response.DeviceJobList.Count, 
                    response.DeviceJobList.Count > 1 ? "s" : string.Empty));
                if (response.NextPageUri != null
                    && response.NextPageStartIdentifier != "-1")
                {
                    if (First != null)
                    {
                        //user has provided First(Top) parameter while calling the commandlet
                        //so we need to provide it to him for calling the next page
                        WriteVerbose(string.Format(Resources.DeviceJobsNextPageFormatMessage, First, response.NextPageStartIdentifier));
                    }
                    else
                    {
                        //user has NOT provided First(Top) parameter while calling the commandlet
                        //so we DONT need to provide it to him for calling the next page
                        WriteVerbose(string.Format(Resources.DeviceJobsNextPagewithNoFirstMessage, response.NextPageStartIdentifier));
                    }
                }
                else
                {
                    WriteVerbose(Resources.DeviceJobsNoMorePagesMessage);
                }
            }
            catch (Exception exception)
            {
                HandleException(exception);
            }
        }

        private void ProcessParameters()
        {
            // Default values for first and skip are 0
            First = First ?? 0;

            Skip = Skip ?? 0;

            // Need to use xml convert because we want ISO 8601 formatting - which is a mandatory requirement from the backend.
            fromDateTimeIsoString = From.HasValue ? XmlConvert.ToString(From.Value) : null;

            toDateTimeIsoString = To.HasValue ? XmlConvert.ToString(To.Value) : null;           

            deviceId = null;

            if (DeviceName != null)
            {
                deviceId = StorSimpleClient.GetDeviceId(DeviceName);
                if (deviceId == null)
                {
                    throw new ArgumentException(string.Format(Resources.NoDeviceFoundWithGivenNameInResourceMessage,StorSimpleContext.ResourceName, DeviceName));
                }
            }
        }
    }
}

