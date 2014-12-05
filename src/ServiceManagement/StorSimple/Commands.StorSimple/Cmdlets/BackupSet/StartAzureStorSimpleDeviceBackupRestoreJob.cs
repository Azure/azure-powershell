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
    [Cmdlet(VerbsLifecycle.Start, "AzureStorSimpleDeviceBackupRestoreJob"),OutputType(typeof(JobResponse), typeof(JobStatusInfo))]
    public class StartAzureStorSimpleDeviceBackupRestoreJob: StorSimpleCmdletBase
    {
        private string deviceId = null;

        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageDeviceName, ParameterSetName = StorSimpleCmdletParameterSet.Empty)]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageDeviceName, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyById)]
        [ValidateNotNullOrEmptyAttribute]
        public string DeviceName { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageBackupIdToRestore, ParameterSetName = StorSimpleCmdletParameterSet.Empty)]
        [Parameter(Position = 1, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageBackupIdToRestore, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyById)]
        public string BackupId { get; set; }

        [Parameter(Position = 2, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessagesnapshotIdToRestore, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyById)]
        public string SnapshotId { get; set; }

        [Parameter(Position = 3, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageWaitTillComplete)]
        public SwitchParameter WaitForComplete { get; set; }

        [Parameter(Position = 4, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageForce)]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                ProcessParameters();
                ConfirmAction(
                   Force.IsPresent,
                   string.Format(Resources.StartASSDBackupRestoreJobWarningMessage, BackupId),
                   string.Format(Resources.StartASSDBackupRestoreJobMessage, BackupId),
                  BackupId,
                  () =>
                  {
                      RestoreBackupRequest request = new RestoreBackupRequest();
                      request.BackupSetId = BackupId;
                      request.SnapshotId = SnapshotId;

                      if (WaitForComplete.IsPresent)
                      {
                          var restoreBackupResult = StorSimpleClient.RestoreBackup(deviceId, request);
                          HandleSyncJobResponse(restoreBackupResult, "start");
                      }
                      else
                      {
                          //async scenario
                          var jobresult = StorSimpleClient.RestoreBackupAsync(deviceId, request);
                          HandleAsyncJobResponse(jobresult, "start");
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
        }
    }
}
