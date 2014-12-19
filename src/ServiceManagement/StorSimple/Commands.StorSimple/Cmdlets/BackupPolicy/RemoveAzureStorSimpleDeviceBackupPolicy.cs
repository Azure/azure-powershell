﻿using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using Microsoft.WindowsAzure;
using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    [Cmdlet(VerbsCommon.Remove, "AzureStorSimpleDeviceBackupPolicy", DefaultParameterSetName = StorSimpleCmdletParameterSet.IdentifyById)]
    public class RemoveAzureStorSimpleDeviceBackupPolicy : StorSimpleCmdletBase
    {
        private string deviceId = null;

        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageDeviceName, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyById)]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageDeviceName, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByObject)]
        [ValidateNotNullOrEmptyAttribute]
        public string DeviceName { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageBackupPolicyIdToDelete, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyById)]
        public string BackupPolicyId { get; set; }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipeline = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageBackupPolicyToDelete, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByObject)]
        public BackupPolicyDetails BackupPolicy { get; set; }

        [Parameter(Position = 2, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageForce)]
        public SwitchParameter Force
        {
            get { return force; }
            set { force = value; }
        }
        private bool force;

        [Parameter(Position = 3, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageWaitTillComplete)]
        public SwitchParameter WaitForComplete { get; set; }

        private string backupPolicyIdFinal = null;
        public override void ExecuteCmdlet()
        {
            try
            {
                if (!ProcessParameters())
                    return;
                ConfirmAction(
                   Force.IsPresent,
                   string.Format(Resources.RemoveASSDBackupPolicyWarningMessage, backupPolicyIdFinal),
                   string.Format(Resources.RemoveASSDBackupPolicyMessage, backupPolicyIdFinal),
                  backupPolicyIdFinal,
                  () =>
                  {
                      if (WaitForComplete.IsPresent)
                      {
                          WriteVerbose("About to run a task to remove your backuppolicy!");
                          var deleteTaskStatusInfo = StorSimpleClient.DeleteBackupPolicy(deviceId, backupPolicyIdFinal);
                          HandleSyncTaskResponse(deleteTaskStatusInfo, "remove");
                      }
                      else
                      {
                          WriteVerbose("About to create a task to remove your backuppolicy!");
                          var taskresult = StorSimpleClient.DeleteBackupPolicyAsync(deviceId, backupPolicyIdFinal);
                          HandleAsyncTaskResponse(taskresult, "remove");
                      }
                  });
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
                WriteVerbose(String.Format(Resources.NoDeviceFoundWithGivenNameInResourceMessage, StorSimpleContext.ResourceName, DeviceName));
                WriteObject(null);
                return false;
            }
            switch (ParameterSetName)
            {
                case StorSimpleCmdletParameterSet.IdentifyById:
                    Guid backuppolicyIdGuid;
                    bool isIdValidGuid = Guid.TryParse(BackupPolicyId,out backuppolicyIdGuid);
                    if (String.IsNullOrEmpty(BackupPolicyId)
                        || !isIdValidGuid)
                        throw new ArgumentException(Resources.InvalidBackupPolicyIdParameter);
                    else
                    {
                        backupPolicyIdFinal = BackupPolicyId;
                    }
                    break;
                case StorSimpleCmdletParameterSet.IdentifyByObject:
                    if (BackupPolicy == null || String.IsNullOrEmpty(BackupPolicy.InstanceId))
                        throw new ArgumentException(Resources.InvalidBackupPolicyObjectParameter);
                    else
                    {
                        backupPolicyIdFinal = BackupPolicy.InstanceId;
                    }
                    break;
            }
            return true;
        }
    }
}
