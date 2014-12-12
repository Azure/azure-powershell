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
        public String BackupPolicyName { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                ProcessParameters();
                if (String.IsNullOrEmpty(BackupPolicyName))
                {
                    BackupPolicyListResponse backupPolicyList = null;
                    backupPolicyList = StorSimpleClient.GetAllBackupPolicies(deviceId);
                    backupPolicyList.BackupPolicies = CorrectLastBackupForNewPolicy(backupPolicyList.BackupPolicies);
                    WriteObject(backupPolicyList.BackupPolicies);
                    WriteVerbose(String.Format(Resources.BackupPolicyGet_StatusMessage, backupPolicyList.BackupPolicies.Count, backupPolicyList.BackupPolicies.Count > 1 ? "ies" : "y"));
                }
                else
                {
                    GetBackupPolicyDetailsResponse backupPolicyDetail = null;
                    backupPolicyDetail = StorSimpleClient.GetBackupPolicyByName(deviceId, BackupPolicyName);
                    backupPolicyDetail.BackupPolicyDetails = CorrectLastBackupForNewPolicyDetail(backupPolicyDetail.BackupPolicyDetails);
                    if (String.IsNullOrEmpty(backupPolicyDetail.BackupPolicyDetails.InstanceId))
                        WriteVerbose(String.Format(Resources.NoBackupPolicyWithGivenNameFound,BackupPolicyName,DeviceName));
                    else
                    {
                        WriteObject(backupPolicyDetail.BackupPolicyDetails);
                        WriteVerbose(String.Format(Resources.BackupPolicyFound, backupPolicyDetail.BackupPolicyDetails.InstanceId));
                    }
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }

          private void ProcessParameters()
        {
            deviceId = StorSimpleClient.GetDeviceId(DeviceName);

            if (deviceId == null)
            {
                WriteVerbose(String.Format(Resources.NoDeviceFoundWithGivenNameInResourceMessage, StorSimpleContext.ResourceName, DeviceName));
                WriteObject(null);
                return;
            }
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
              if (backupPolicyDetail != null)
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
