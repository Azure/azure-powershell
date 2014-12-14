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
    [Cmdlet(VerbsCommon.Remove, "AzureStorSimpleDeviceBackupPolicy", DefaultParameterSetName="Default")]
    public class RemoveAzureStorSimpleDeviceBackupPolicy : StorSimpleCmdletBase
    {
        private string deviceId = null;

        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageDeviceName, ParameterSetName = "Default")]
        [ValidateNotNullOrEmptyAttribute]
        public string DeviceName { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageBackupPolicyIdToDelete, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyById)]
        [Parameter(Position = 1, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageBackupPolicyIdToDelete, ParameterSetName = "Default")]
        public string BackupPolicyId { get; set; }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipeline = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageBackupPolicyToDelete, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByObject)]
        [Parameter(Position = 1, Mandatory = false, ValueFromPipeline = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageBackupPolicyToDelete, ParameterSetName = "Default")]
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
                ProcessParameters();
                ConfirmAction(
                   Force.IsPresent,
                   string.Format(Resources.RemoveASSDBackupPolicyWarningMessage, backupPolicyIdFinal),
                   string.Format(Resources.RemoveASSDBackupPolicyMessage, backupPolicyIdFinal),
                  backupPolicyIdFinal,
                  () =>
                  {
                      if (WaitForComplete.IsPresent)
                      {
                          WriteVerbose("About to run a job to remove your backuppolicy!");
                          var deleteJobStatusInfo = StorSimpleClient.DeleteBackupPolicy(deviceId, backupPolicyIdFinal);
                          HandleSyncTaskResponse(deleteJobStatusInfo, "remove");
                      }
                      else
                      {
                          WriteVerbose("About to create a job to remove your backuppolicy!");
                          var jobresult = StorSimpleClient.DeleteBackupPolicyAsync(deviceId, backupPolicyIdFinal);
                          HandleAsyncTaskResponse(jobresult, "remove");
                      }
                  });
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
            switch (ParameterSetName)
            {
                case StorSimpleCmdletParameterSet.IdentifyById:
                    if (String.IsNullOrEmpty(BackupPolicyId))
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
        }
    }
}
