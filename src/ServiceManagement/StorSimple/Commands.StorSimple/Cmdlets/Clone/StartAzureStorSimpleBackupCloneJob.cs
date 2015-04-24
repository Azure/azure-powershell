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

using System;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;
using Microsoft.WindowsAzure.Management.StorSimple.Models;


namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
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
        
        [Parameter(Mandatory = true, Position = 4, HelpMessage = StorSimpleCmdletHelpMessage.CloneVolumeName)]
        [ValidateNotNullOrEmpty]
        public string CloneVolumeName { get; set; }

        [Parameter(Mandatory = false, Position = 5, ValueFromPipeline = true, HelpMessage = StorSimpleCmdletHelpMessage.VolumeAcrList)]
        [ValidateNotNull]
        public List<AccessControlRecord> TargetAccessControlRecords { get; set; }
            
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
                    string.Format(Resources.StartAzureStorSimpleBackupCloneJobWarningMessage, BackupId),
                    string.Format(Resources.StartAzureStorSimpleBackupCloneJobMessage, BackupId),
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
                            TargetACRList = TargetAccessControlRecords ?? new List<AccessControlRecord>()
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
                        throw new ArgumentException(string.Format(Resources.NoDeviceFoundWithGivenNameInResourceMessage, StorSimpleContext.ResourceName, SourceDeviceName));
                    }

                    this.targetDeviceId = StorSimpleClient.GetDeviceId(TargetDeviceName);

                    if (this.targetDeviceId == null)
                    {
                        throw new ArgumentException(string.Format(Resources.NoDeviceFoundWithGivenNameInResourceMessage, StorSimpleContext.ResourceName, TargetDeviceName));
                    }
                    break;
            }
            
            return true;
        }

    }

}

