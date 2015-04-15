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

using System.Management.Automation;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "AzureStorSimpleDeviceBackup", DefaultParameterSetName = StorSimpleCmdletParameterSet.Empty),OutputType(typeof(IList<Backup>))]
    public class GetAzureStorSimpleDeviceBackup: StorSimpleCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.DeviceName, ParameterSetName = StorSimpleCmdletParameterSet.Empty)]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.DeviceName, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyById)]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.DeviceName, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyById2)]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.DeviceName, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByObject)]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.DeviceName, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByObject2)]
        [ValidateNotNullOrEmptyAttribute]
        public string DeviceName { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.BackupPolicyId, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyById)]
        public string BackupPolicyId { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage =StorSimpleCmdletHelpMessage.VolumeIdForBackup , ParameterSetName = StorSimpleCmdletParameterSet.IdentifyById2)]
        public string VolumeId { get; set; }

        [Alias("BackupPolicyDetails")]
        [Parameter(Position = 1, Mandatory = true, ValueFromPipeline = true, HelpMessage =StorSimpleCmdletHelpMessage.BackupPolicyDetailsObject ,ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByObject)]
        public BackupPolicyDetails BackupPolicy { get; set; }

        [Alias("VirtualDiskInfo")]
        [Parameter(Position = 1, Mandatory = true, ValueFromPipeline = true, HelpMessage = StorSimpleCmdletHelpMessage.VolumeObject, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByObject2)]
        public VirtualDisk Volume { get; set; }

        [Parameter(Position = 2, Mandatory = false, HelpMessage =StorSimpleCmdletHelpMessage.StartFrom )]
        public string From { get; set; }

        [Parameter(Position = 3, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.EndTime)]
        public string To { get; set; }

        [Parameter(Position = 4, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.FirstDesc)]
        [ValidateRange(0, Int32.MaxValue)]
        public int? First { get; set; }

        [Parameter(Position = 5, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.SkipDesc)]
        [ValidateRange(0, Int32.MaxValue)]
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
                if (!ProcessParameters()) 
                    return;
                GetBackupResponse backupList = null;
                backupList = StorSimpleClient.GetAllBackups(deviceId, filterType, isAllSelected, IdToPass,
                    FromDateTime.ToString(),
                    ToDateTime.ToString(), Skip == null ? "0" : Skip.ToString(), First == null ? null : First.ToString());
                WriteObject(backupList.BackupSetsList, true);
                WriteVerbose(string.Format(Resources.BackupsReturnedCount, backupList.BackupSetsList.Count));
                
                if (backupList.NextPageUri != null 
                    && backupList.NextPageStartIdentifier!="1")
                {
                    if (First != null)
                    {
                        //user has provided First(Top) parameter while calling the commandlet
                        //so we need to provide it to him for calling the next page
                        WriteVerbose(string.Format(Resources.BackupNextPageFormatMessage, First, backupList.NextPageStartIdentifier));
                    }
                    else
                    {
                        //user has NOT provided First(Top) parameter while calling the commandlet
                        //so we DONT need to provide it to him for calling the next page
                        WriteVerbose(string.Format(Resources.BackupNextPagewithNoFirstMessage, backupList.NextPageStartIdentifier));
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

        private bool ProcessParameters()
        {
            deviceId = StorSimpleClient.GetDeviceId(DeviceName);

            if (deviceId == null)
            {
                throw new ArgumentException(string.Format(Resources.NoDeviceFoundWithGivenNameInResourceMessage, StorSimpleContext.ResourceName, DeviceName));
            }

            if (string.IsNullOrEmpty(From))
                FromDateTime = DateTime.MinValue;
            else
            {
                bool result = DateTime.TryParse(From, out FromDateTime);
                if (!result)
                    throw new ArgumentException(Resources.InvalidFromMessage);
            }
            if (string.IsNullOrEmpty(To))
                ToDateTime = DateTime.MaxValue;
            else
            {
                bool result = DateTime.TryParse(To, out ToDateTime);
                if (!result)
                    throw new ArgumentException(Resources.InvalidToMessage);
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
            return true;
        }

    }
}
