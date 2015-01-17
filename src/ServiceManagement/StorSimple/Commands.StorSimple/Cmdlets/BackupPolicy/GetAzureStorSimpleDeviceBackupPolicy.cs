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

using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using Microsoft.WindowsAzure;
using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;
using Microsoft.WindowsAzure.Commands.StorSimple.Exceptions;

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

        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageDeviceName)]
        [ValidateNotNullOrEmptyAttribute]
        public string DeviceName { get; set; }

        [Alias("Name")]
        [Parameter(Position = 1, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageBackupPolicyName)]
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
                    backupPolicyList.BackupPolicies = CorrectLastBackupForNewPolicy(backupPolicyList.BackupPolicies);
                    WriteObject(backupPolicyList.BackupPolicies);
                    WriteVerbose(string.Format(Resources.BackupPolicyGet_StatusMessage, backupPolicyList.BackupPolicies.Count, backupPolicyList.BackupPolicies.Count > 1 ? "ies" : "y"));
                }
                else
                {
                    GetBackupPolicyDetailsResponse backupPolicyDetail = null;
                    backupPolicyDetail = StorSimpleClient.GetBackupPolicyByName(deviceId, BackupPolicyName);
                    backupPolicyDetail.BackupPolicyDetails = CorrectLastBackupForNewPolicyDetail(backupPolicyDetail.BackupPolicyDetails);
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
                WriteVerbose(string.Format(Resources.NoDeviceFoundWithGivenNameInResourceMessage, StorSimpleContext.ResourceName, DeviceName));
                WriteObject(null);
                return false;
            }
            return true;
        }

          /// <summary>
          /// for a new backuppolicy for which no backup has yet been taken,service returns last backup time as 1/1/2010 which is misleading
          /// we are setting it to null
          /// </summary>
          /// <param name="backupPolicyList"></param>
          /// <returns></returns>
          private IList<BackupPolicy> CorrectLastBackupForNewPolicy(IList<BackupPolicy> backupPolicyList)
          {
              if (backupPolicyList != null)
              {
                  for (int i = 0; i < backupPolicyList.Count; ++i)
                  {
                      if (backupPolicyList[i].LastBackup.Value.Year == 2010
                          && backupPolicyList[i].LastBackup.Value.Month == 1
                          && backupPolicyList[i].LastBackup.Value.Day == 1)
                      {
                          //this means that for this policy no backup has yet been taken
                          //so the service returns 1/1/2010 which is incorrect. hence we are correcting it here
                          backupPolicyList[i].LastBackup = null;
                      }
                  }
              }
              return backupPolicyList;
          }

          /// <summary>
          /// for a new backuppolicy for which no backup has yet been taken,service returns last backup time as 1/1/2010 which is misleading
          /// we are setting it to null
          /// </summary>
          /// <param name="backupPolicyList"></param>
          /// <returns></returns>
          private BackupPolicyDetails CorrectLastBackupForNewPolicyDetail(BackupPolicyDetails backupPolicyDetail)
          {
              if (backupPolicyDetail != null && backupPolicyDetail.LastBackup != null)
              {
                  if (backupPolicyDetail.LastBackup.Value.Year == 2010
                      && backupPolicyDetail.LastBackup.Value.Month == 1
                      && backupPolicyDetail.LastBackup.Value.Day == 1)
                  {
                      //this means that for this policy no backup has yet been taken
                      //so the service returns 1/1/2010 which is incorrect. hence we are correcting it here
                      backupPolicyDetail.LastBackup = null;
                  }

              }
              return backupPolicyDetail;
          }
    }
    }
