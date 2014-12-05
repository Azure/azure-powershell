using System.Management.Automation;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using Microsoft.WindowsAzure;
using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "AzureStorSimpleDeviceBackupScheduleAddConfig"),OutputType(typeof(BackupScheduleBase))]
    public class NewAzureStorSimpleDeviceBackupScheduleAddConfig : StorSimpleCmdletBase 
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageBackupTypeDesc)]
        [ValidateNotNullOrEmptyAttribute]
        [ValidateSet("LocalSnapshot", "CloudSnapshot")]
        public String BackupType { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageRecurrenceTypeDesc)]
        [ValidateNotNullOrEmptyAttribute]
        [ValidateSet("Minutes", "Hourly", "Daily", "Weekly")]
        public String RecurrenceType { get; set; }

        [Parameter(Position = 2, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageRecurrenceValueDesc)]
        [ValidateNotNullOrEmptyAttribute]
        public int RecurrenceValue { get; set; }

        [Parameter(Position = 3, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageRetentionCountDesc)]
        [ValidateNotNullOrEmptyAttribute]
        public long RetentionCount { get; set; }

        [Parameter(Position = 4, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageBackupStartFromDesc)]
        public String StartFromDateTime { get; set; }

        [Parameter(Position = 5, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageBackupEnabledDesc)]
        public bool Enabled { get; set; }

        private ScheduleStatus scheduleStatus;
        private DateTime StartFromDt;
        private void ProcessParameters()
        {
            if (String.IsNullOrEmpty(StartFromDateTime))
            {
                StartFromDt = DateTime.Now;
            }
            else
            {
                bool dateTimeValid = DateTime.TryParse(StartFromDateTime, out StartFromDt); 
                
                if (!dateTimeValid)
                {
                    throw new ArgumentException(Resources.StartFromDateForBackupNotValid);
                }
            }
            scheduleStatus = Enabled ? ScheduleStatus.Enabled : ScheduleStatus.Disabled;
        }

        public override void ExecuteCmdlet()
        {
            try
            {
                ProcessParameters();

                BackupScheduleBase newScheduleObject = new BackupScheduleBase();
                newScheduleObject.BackupType = (BackupType)Enum.Parse(typeof(BackupType), BackupType);
                newScheduleObject.Status = scheduleStatus;
                newScheduleObject.RetentionCount = RetentionCount;
                newScheduleObject.StartTime = StartFromDt.ToString("yyyy-MM-ddTHH:mm:sszzz");
                newScheduleObject.Recurrence = new ScheduleRecurrence();
                newScheduleObject.Recurrence.RecurrenceType = (RecurrenceType)Enum.Parse(typeof(RecurrenceType), RecurrenceType);
                newScheduleObject.Recurrence.RecurrenceValue = RecurrenceValue;

                WriteObject(newScheduleObject);
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}
