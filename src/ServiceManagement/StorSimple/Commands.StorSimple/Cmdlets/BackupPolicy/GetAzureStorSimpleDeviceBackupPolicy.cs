using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using Microsoft.WindowsAzure;
using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    /// <summary>
    /// commandlet that returns one or more BackupPolicy objects for a given DeviceName and BackupPolicyName
    /// </summary>
     [Cmdlet(VerbsCommon.Get, "AzureStorSimpleDeviceBackupPolicy")]
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
                    WriteVerbose(String.Format(Resources.BackupPoliciesReturnedCount,backupPolicyList.BackupPolicies.Count));
                    WriteObject(backupPolicyList.BackupPolicies);
                }
                else
                {
                    GetBackupPolicyDetailsResponse backupPolicyDetail = null;
                    backupPolicyDetail = StorSimpleClient.GetBackupPolicyByName(deviceId, BackupPolicyName);
                    if (String.IsNullOrEmpty(backupPolicyDetail.BackupPolicyDetails.InstanceId))
                        WriteVerbose(Resources.BackupPolicyNotFound);
                    else
                    {
                        WriteVerbose(String.Format(Resources.BackupPolicyFound, backupPolicyDetail.BackupPolicyDetails.InstanceId));
                        WriteObject(backupPolicyDetail.BackupPolicyDetails);
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
                WriteVerbose(Resources.NotFoundMessageDevice);
            }
        }
    }
    }
