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

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{

    /// <summary>
    /// this commandlet will help in creating a new updateconfig that can be used to update an existing backuppolicy subsequently
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureStorSimpleDeviceBackupScheduleUpdateConfig"), OutputType(typeof(BackupScheduleUpdateRequest))]
    public class NewAzureStorSimpleDeviceBackupScheduleUpdateConfig:StorSimpleCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.BackupScheduleId)]
        [ValidateNotNullOrEmptyAttribute]
        public string Id { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.BackupTypeDesc)]
        [ValidateNotNullOrEmptyAttribute]
        [ValidateSet("LocalSnapshot", "CloudSnapshot")]
        public string BackupType { get; set; }

        [Parameter(Position = 2, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.RecurrenceTypeDesc)]
        [ValidateNotNullOrEmptyAttribute]
        [ValidateSet("Minutes", "Hourly", "Daily", "Weekly")]
        public string RecurrenceType { get; set; }

        [Parameter(Position = 3, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.RecurrenceValueDesc)]
        [ValidateNotNullOrEmptyAttribute]
        public int RecurrenceValue { get; set; }

        [Parameter(Position = 4, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.RetentionCountDesc)]
        [ValidateNotNullOrEmptyAttribute]
        public long RetentionCount { get; set; }

        [Parameter(Position = 5, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.BackupStartFromDesc)]
        public string StartFromDateTime { get; set; }

        [Parameter(Position = 6, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.BackupEnabledDesc)]
        public bool Enabled { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                BackupScheduleUpdateRequest updateScheduleObject = new BackupScheduleUpdateRequest();
                updateScheduleObject.BackupType = (BackupType)Enum.Parse(typeof(BackupType), BackupType);
                updateScheduleObject.Status = Enabled ? ScheduleStatus.Enabled : ScheduleStatus.Disabled;
                updateScheduleObject.RetentionCount = RetentionCount;
                updateScheduleObject.StartTime = StartFromDateTime;
                updateScheduleObject.Recurrence = new ScheduleRecurrence();
                updateScheduleObject.Recurrence.RecurrenceType = (RecurrenceType)Enum.Parse(typeof(RecurrenceType), RecurrenceType);
                updateScheduleObject.Recurrence.RecurrenceValue = RecurrenceValue;
                updateScheduleObject.Id = Id;
                StorSimpleClient.ValidateBackupScheduleUpdateRequest(updateScheduleObject);
                WriteObject(updateScheduleObject);
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }

    }
}
