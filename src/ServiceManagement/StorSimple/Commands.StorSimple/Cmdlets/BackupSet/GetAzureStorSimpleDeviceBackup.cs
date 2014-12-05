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
    [Cmdlet(VerbsCommon.Get, "AzureStorSimpleDeviceBackup"),OutputType(typeof(GetBackupResponse))]
    public class GetAzureStorSimpleDeviceBackup: StorSimpleCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageDeviceName, ParameterSetName = StorSimpleCmdletParameterSet.Empty)]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageDeviceName, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyById)]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageDeviceName, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyById2)]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageDeviceName, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByObject)]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageDeviceName, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByObject2)]
        [ValidateNotNullOrEmptyAttribute]
        public string DeviceName { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageBackupPolicyId, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyById)]
        public string BackupPolicyId { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage =StorSimpleCmdletHelpMessage.HelpMessageVolumeIdForBackup , ParameterSetName = StorSimpleCmdletParameterSet.IdentifyById2)]
        public String VolumeId { get; set; }

        [Alias("BackupPolicyDetails")]
        [Parameter(Position = 1, Mandatory = true, ValueFromPipeline = true, HelpMessage =StorSimpleCmdletHelpMessage.HelpMessageBackupPolicyDetailsObject ,ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByObject)]
        public BackupPolicyDetails BackupPolicy { get; set; }

        [Alias("VirtualDiskInfo")]
        [Parameter(Position = 1, Mandatory = true, ValueFromPipeline = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageVolumeObject, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByObject2)]
        public VirtualDisk Volume { get; set; }

        [Parameter(Position = 2, Mandatory = false, HelpMessage =StorSimpleCmdletHelpMessage.HelpMessageStartFrom )]
        public string From { get; set; }

        [Parameter(Position = 3, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageEndTime)]
        public string To { get; set; }

        [Parameter(Position = 4, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageFirstDesc)]
        public int? First { get; set; }

        [Parameter(Position = 5, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageSkipDesc)]
        public int? Skip { get; set; }

        private string deviceId = null;
        private string IdToPass;
        private string isAllSelected;
        private string filterType;
        private DateTime FromDateTime;
        private DateTime ToDateTime;

        public override void ExecuteCmdlet()
        {
            try
            {
                ProcessParameters();
                GetBackupResponse backupList = null;
                backupList = StorSimpleClient.GetAllBackups(deviceId, filterType, isAllSelected, IdToPass,
                    FromDateTime.ToString(),
                    ToDateTime.ToString(), Skip.ToString(), First ==null? null: First.ToString());
                WriteObject(backupList.BackupSetsList, true);
                WriteVerbose(String.Format(Resources.BackupsReturnedCount, backupList.BackupSetsList.Count));
                if (backupList.NextPageUri != null 
                    && backupList.NextPageStartIdentifier!="1")
                {
                    if (First != null)
                    {
                        //user has provided First(Top) parameter while calling the commandlet
                        //so we need to provide it to him for calling the next page
                        WriteVerbose(String.Format(Resources.BackupNextPageFormatMessage, First, backupList.NextPageStartIdentifier));
                    }
                    else
                    {
                        //user has NOT provided First(Top) parameter while calling the commandlet
                        //so we DONT need to provide it to him for calling the next page
                        WriteVerbose(String.Format(Resources.BackupNextPagewithNoFirstMessage, backupList.NextPageStartIdentifier));
                    }
                }
                else
                {
                    WriteVerbose(Resources.BackupNoMorePagesMessage);
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
            if(First<0)
                throw new ArgumentException(Resources.FirstParameterInvalidMessage);
            if (Skip  < 0)
                throw new ArgumentException(Resources.SkipParameterInvalidMessage);
            if (Skip == null)
                Skip = 0;
            if (String.IsNullOrEmpty(From))
                FromDateTime = DateTime.MinValue;
            else
            {
                bool result = DateTime.TryParse(From, out FromDateTime);
                if(!result)
                    throw new ArgumentException(Resources.InvalidFromMessage);
            }
            if (String.IsNullOrEmpty(To))
                ToDateTime = DateTime.MaxValue;
            else
            {
                bool result = DateTime.TryParse(To, out ToDateTime);
                if (!result)
                    throw new ArgumentException(Resources.InvalidFromMessage);
            }

            switch (ParameterSetName)
            {
                case StorSimpleCmdletParameterSet.IdentifyById:
                    filterType = "BackupPolicy";
                    isAllSelected = Boolean.FalseString;
                    IdToPass = BackupPolicyId;
                    break;
                case StorSimpleCmdletParameterSet.IdentifyById2:
                    filterType = "Volume";
                    isAllSelected = Boolean.FalseString;
                    IdToPass = VolumeId;
                    break;
                case StorSimpleCmdletParameterSet.IdentifyByObject:
                    filterType = "BackupPolicy";
                    isAllSelected = Boolean.FalseString;
                    IdToPass = BackupPolicy.InstanceId;
                    break;
                case StorSimpleCmdletParameterSet.IdentifyByObject2:
                    filterType = "Volume";
                    isAllSelected = Boolean.FalseString;
                    IdToPass = Volume.InstanceId;
                    break;
                default:
                    //case where only deviceName is passed
                    filterType = "BackupPolicy";
                    isAllSelected = Boolean.TrueString;
                    IdToPass = null;
                    break;
            }
        }

    }
}
