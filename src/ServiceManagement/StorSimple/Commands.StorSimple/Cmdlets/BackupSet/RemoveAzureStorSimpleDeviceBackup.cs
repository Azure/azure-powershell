using System.Linq;
using System.Management.Automation;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using Microsoft.WindowsAzure;
using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;


namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    /// <summary>
    /// This commandlet will remove a given backup from the device
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureStorSimpleDeviceBackup")]
    public class RemoveAzureStorSimpleDeviceBackup:StorSimpleCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageDeviceName)]
        [ValidateNotNullOrEmptyAttribute]
        public string DeviceName { get; set; }


        [Parameter(Position = 1, Mandatory = true, 
            HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageBackupIdToDelete,
            ParameterSetName = StorSimpleCmdletParameterSet.IdentifyById)]
        public String BackupId { get; set; }

        [Parameter(Position = 1, Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageBackupIdToDelete,
            ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByObject)]
        public Backup Backup { get; set; }

        [Parameter(Position = 2, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageForce)]
        public SwitchParameter Force
        {
            get { return force; }
            set { force = value; }
        }
        private bool force;

        [Parameter(Position = 3, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageWaitTillComplete)]
        public SwitchParameter WaitForComplete { get; set; }

        private string deviceId = null;
        private string finalBackupId = null;

        public override void ExecuteCmdlet()
        {
            try
            {
                ProcessParameters();
                ConfirmAction(
                   Force.IsPresent,
                   string.Format(Resources.RemoveASSDBackupWarningMessage, finalBackupId),
                   string.Format(Resources.RemoveASSDBackupMessage, finalBackupId),
                  BackupId,
                  () =>
                  {

                      if (WaitForComplete.IsPresent)
                      {
                          var deleteJobStatusInfo = StorSimpleClient.DeleteBackup(deviceId, finalBackupId);
                          HandleSyncJobResponse(deleteJobStatusInfo, "remove"); 
                      }
                      else
                      {
                          var jobresult = StorSimpleClient.DeleteBackupAsync(deviceId, finalBackupId);
                          HandleAsyncJobResponse(jobresult, "remove");
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
                WriteVerbose(Resources.NotFoundMessageDevice);
            }
            switch (ParameterSetName)
            {
                case StorSimpleCmdletParameterSet.IdentifyById:
                    if (String.IsNullOrEmpty(BackupId))
                        throw new ArgumentException(Resources.InvalidBackupIdParameter);
                    else
                    {
                        finalBackupId = BackupId;
                    }
                    break;
                case StorSimpleCmdletParameterSet.IdentifyByObject:
                    if(Backup==null || String.IsNullOrEmpty(Backup.InstanceId))
                        throw new ArgumentException(Resources.InvalidBackupObjectParameter);
                    else
                    {
                        finalBackupId = Backup.InstanceId;
                    }
                    break;
            }
 
        }
    }
}
