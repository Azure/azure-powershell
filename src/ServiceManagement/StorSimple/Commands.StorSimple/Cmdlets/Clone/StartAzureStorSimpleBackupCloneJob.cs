#region Using directives
using System;
using System.Management.Automation;
#endregion


namespace Microsoft.AzureStorSimpleDeviceCmdlets.Commands
{
    using System.Collections.Generic;

    using Microsoft.WindowsAzure.Commands.StorSimple;
    using Microsoft.WindowsAzure.Commands.StorSimple.Properties;
    using Microsoft.WindowsAzure.Management.StorSimple.Models;

    /// <summary>
    /// Given a backupId, snapshot and a targetDeviceName , this commandlet will 
    /// clone it on the given target device.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "AzureStorSimpleBackupCloneJob", DefaultParameterSetName = StorSimpleCmdletParameterSet.Empty)]
    public class StartAzureStorSimpleBackupCloneJob : StorSimpleCmdletBase
    {
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByName, HelpMessage = StorSimpleCmdletHelpMessage.SourceDeviceName)]
        [ValidateNotNullOrEmpty]
        public string SourceDeviceName { get; set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyById, HelpMessage = StorSimpleCmdletHelpMessage.SourceDeviceId)]
        [ValidateNotNullOrEmpty]
        public string SourceDeviceId { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByName, HelpMessage = StorSimpleCmdletHelpMessage.TargetDeviceName)]
        [ValidateNotNullOrEmpty]
        public string TargetDeviceName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyById, HelpMessage = StorSimpleCmdletHelpMessage.TargetDeviceId)]
        [ValidateNotNullOrEmpty]
        public string TargetDeviceId { get; set; }

        [Parameter(Mandatory = true, Position = 2, HelpMessage = StorSimpleCmdletHelpMessage.BackupIdToClone)]
        [ValidateNotNullOrEmpty]
        public string BackupId { get; set; }

        [Parameter(Mandatory = true, Position = 3, ValueFromPipeline = true, HelpMessage = StorSimpleCmdletHelpMessage.SnapshotToClone)]
        [ValidateNotNull]
        public Snapshot Snapshot { get; set; }

        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = true, HelpMessage = StorSimpleCmdletHelpMessage.VolumeAcrList)]
        [ValidateNotNull]
        public List<AccessControlRecord> TargetAccessControlRecords { get; set; }
            
        [Parameter(Mandatory = false, Position = 5, HelpMessage = StorSimpleCmdletHelpMessage.CloneVolumeName)]
        [ValidateNotNullOrEmpty]
        public string CloneVolumeName { get; set; }

        [Parameter(Mandatory = false, Position = 6, HelpMessage = StorSimpleCmdletHelpMessage.Force)]
        public SwitchParameter Force { get; set; }


        private string sourceDeviceId;
        private string targetDeviceId;

        public override void ExecuteCmdlet()
        {
            try
            {
                if (!ProcessParameters())
                {
                    return;
                }

                this.ConfirmAction(
                    Force.IsPresent,
                    string.Format(Resources.StartASSBackupCloneJobWarningMessage, BackupId),
                    string.Format(Resources.StartASSBackupCloneJobMessage, BackupId),
                    BackupId,
                    () =>
                    {
                        JobResponse response = null;
                        var request = new TriggerCloneRequest()
                        {
                            TargetDeviceId = targetDeviceId,
                            BackupSetId = BackupId,
                            SourceSnapshot = Snapshot,
                            ReturnWorkflowId = true,
                            TargetVolName = CloneVolumeName,
                            TargetACRList = TargetAccessControlRecords
                        };
                        response = StorSimpleClient.CloneVolume(sourceDeviceId, request);
                        HandleDeviceJobResponse(response, "start");
                    }
                    );
            }
            catch (Exception ex)
            {
                this.HandleException(ex);
            }
        }

        private bool ProcessParameters()
        {
            switch (ParameterSetName)
            {
                case StorSimpleCmdletParameterSet.IdentifyById:
                    this.sourceDeviceId = SourceDeviceId;
                    this.targetDeviceId = TargetDeviceId;
                    break;
                case StorSimpleCmdletParameterSet.IdentifyByName:
                    this.sourceDeviceId = StorSimpleClient.GetDeviceId(SourceDeviceName);

                    if (this.sourceDeviceId == null)
                    {
                        WriteVerbose(Resources.NoDeviceFoundWithGivenNameInResourceMessage);
                        return false;
                    }

                    this.targetDeviceId = StorSimpleClient.GetDeviceId(TargetDeviceName);

                    if (this.targetDeviceId == null)
                    {
                        WriteVerbose(Resources.NoDeviceFoundWithGivenNameInResourceMessage);
                        return false;
                    }
                    break;
            }
            
            return true;
        }

    }//End Class

}//End namespace

