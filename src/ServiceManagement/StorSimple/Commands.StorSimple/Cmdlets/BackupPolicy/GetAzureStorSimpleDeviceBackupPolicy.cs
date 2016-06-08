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

using System.Management.Automation;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    /// <summary>
    /// commandlet that returns one or more BackupPolicy objects for a given DeviceName and BackupPolicyName
    /// </summary>
     [Cmdlet(VerbsCommon.Get, "AzureStorSimpleDeviceBackupPolicy"),
    OutputType(typeof(IList<BackupPolicy>), typeof(BackupPolicyDetails))]
    public class GetAzureStorSimpleDeviceBackupPolicy:StorSimpleCmdletBase
    {
        private string deviceId = null;

        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.DeviceName)]
        [ValidateNotNullOrEmptyAttribute]
        public string DeviceName { get; set; }

        [Alias("Name")]
        [Parameter(Position = 1, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.BackupPolicyName)]
        public string BackupPolicyName { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                if (!ProcessParameters()) 
                    return;
                if (string.IsNullOrEmpty(BackupPolicyName))
                {
                    BackupPolicyListResponse backupPolicyList = null;
                    backupPolicyList = StorSimpleClient.GetAllBackupPolicies(deviceId);
                    WriteObject(backupPolicyList.BackupPolicies);
                    WriteVerbose(string.Format(Resources.BackupPolicyGet_StatusMessage, backupPolicyList.BackupPolicies.Count, backupPolicyList.BackupPolicies.Count > 1 ? "ies" : "y"));
                }
                else
                {
                    GetBackupPolicyDetailsResponse backupPolicyDetail = null;
                    backupPolicyDetail = StorSimpleClient.GetBackupPolicyByName(deviceId, BackupPolicyName);
                    if (string.IsNullOrEmpty(backupPolicyDetail.BackupPolicyDetails.InstanceId))
                        WriteVerbose(string.Format(Resources.NoBackupPolicyWithGivenNameFound,BackupPolicyName,DeviceName));
                    else
                    {
                        WriteObject(backupPolicyDetail.BackupPolicyDetails);
                        WriteVerbose(string.Format(Resources.BackupPolicyFound, backupPolicyDetail.BackupPolicyDetails.InstanceId));
                    }
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }

          private bool ProcessParameters()
        {
            deviceId = StorSimpleClient.GetDeviceId(DeviceName);

            if (deviceId == null)
            {
                throw new ArgumentException(string.Format(Resources.NoDeviceFoundWithGivenNameInResourceMessage, StorSimpleContext.ResourceName, DeviceName));
            }

            return true;
        }
    }
}
