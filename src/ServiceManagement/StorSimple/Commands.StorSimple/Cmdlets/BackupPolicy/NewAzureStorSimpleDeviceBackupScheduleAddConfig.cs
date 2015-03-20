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
using Microsoft.WindowsAzure;
using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    /// <summary>
    /// this commandlet will help in creating a new Addconfig that can be used to create a new BackupPolicy subsequently
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureStorSimpleDeviceBackupScheduleAddConfig"),OutputType(typeof(BackupScheduleBase))]
    public class NewAzureStorSimpleDeviceBackupScheduleAddConfig : StorSimpleCmdletBase 
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageBackupTypeDesc)]
        [ValidateNotNullOrEmptyAttribute]
        [ValidateSet("LocalSnapshot", "CloudSnapshot")]
        public string BackupType { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageRecurrenceTypeDesc)]
        [ValidateNotNullOrEmptyAttribute]
        [ValidateSet("Minutes", "Hourly", "Daily", "Weekly")]
        public string RecurrenceType { get; set; }

        [Parameter(Position = 2, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageRecurrenceValueDesc)]
        [ValidateNotNullOrEmptyAttribute]
        public int RecurrenceValue { get; set; }

        [Parameter(Position = 3, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageRetentionCountDesc)]
        [ValidateNotNullOrEmptyAttribute]
        public long RetentionCount { get; set; }

        [Parameter(Position = 4, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageBackupStartFromDesc)]
        public string StartFromDateTime { get; set; }

        [Parameter(Position = 5, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageBackupEnabledDesc)]
        public bool Enabled { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                BackupScheduleBase newScheduleObject = new BackupScheduleBase();
                newScheduleObject.BackupType = (BackupType)Enum.Parse(typeof(BackupType), BackupType);
                newScheduleObject.Status = Enabled ? ScheduleStatus.Enabled : ScheduleStatus.Disabled;
                newScheduleObject.RetentionCount = RetentionCount;
                newScheduleObject.StartTime = StartFromDateTime;
                newScheduleObject.Recurrence = new ScheduleRecurrence();
                newScheduleObject.Recurrence.RecurrenceType = (RecurrenceType)Enum.Parse(typeof(RecurrenceType), RecurrenceType);
                newScheduleObject.Recurrence.RecurrenceValue = RecurrenceValue;
                StorSimpleClient.ValidateBackupScheduleBase(newScheduleObject);
                WriteObject(newScheduleObject);
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}
