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
    [Cmdlet(VerbsLifecycle.Start, "AzureStorSimpleDeviceBackupJob"),OutputType(typeof(JobResponse), typeof(JobStatusInfo))]
    public class StartAzureStorSimpleDeviceBackupJob : StorSimpleCmdletBase
    {
        private const string PARAMETERSET_BACKUPTYPE = "BackupTypeGiven";

        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageDeviceName, ParameterSetName = StorSimpleCmdletParameterSet.Empty)]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageDeviceName, ParameterSetName = PARAMETERSET_BACKUPTYPE)]
        [ValidateNotNullOrEmptyAttribute]
        public string DeviceName { get; set; }


        [Parameter(Position = 1, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageBackupPolicyIdForCreate, ParameterSetName = StorSimpleCmdletParameterSet.Empty)]
        [Parameter(Position = 1, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageBackupPolicyIdForCreate, ParameterSetName = PARAMETERSET_BACKUPTYPE)]
        public String BackupPolicyId { get; set; }


        [Parameter(Position = 2, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageBackupTypeDesc, ParameterSetName = PARAMETERSET_BACKUPTYPE)]
        [ValidateSet("LocalSnapshot", "CloudSnapshot")]
        public String BackupType { get; set; }

        [Parameter(Position = 3, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageWaitTillComplete)]
        public SwitchParameter WaitForComplete { get; set; }

        private string deviceId = null;
        private BackupNowRequest backupNowRequest = null;

         public override void ExecuteCmdlet()
        {
             try
             {
                 ProcessParameters();
                 if (WaitForComplete.IsPresent)
                 {
                     var JobStatusInfo = StorSimpleClient.DoBackup(deviceId, BackupPolicyId, backupNowRequest);
                     HandleSyncJobResponse(JobStatusInfo, "start");
                 }
                 else
                 {
                     var jobresult = StorSimpleClient.DoBackupAsync(deviceId, BackupPolicyId, backupNowRequest);
                     HandleAsyncJobResponse(jobresult, "start");
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

             BackupType backupTypeSelected = Management.StorSimple.Models.BackupType.Invalid;
             switch (ParameterSetName)
             {
                 case StorSimpleCmdletParameterSet.Empty:
                     backupTypeSelected = Microsoft.WindowsAzure.Management.StorSimple.Models.BackupType.LocalSnapshot;
                     break;
                 case PARAMETERSET_BACKUPTYPE:
                     backupTypeSelected = (BackupType)Enum.Parse(typeof(BackupType), BackupType);
                     break;
             }
             backupNowRequest = new BackupNowRequest();
             backupNowRequest.Type = backupTypeSelected;
        }
    }
}
