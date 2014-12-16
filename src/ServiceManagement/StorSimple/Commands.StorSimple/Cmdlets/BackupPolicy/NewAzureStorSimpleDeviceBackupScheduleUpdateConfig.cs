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
    /// this commandlet will help in creating a new updateconfig that can be used to update an existing backuppolicy subsequently
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureStorSimpleDeviceBackupScheduleUpdateConfig"), OutputType(typeof(BackupScheduleUpdateRequest))]
    public class NewAzureStorSimpleDeviceBackupScheduleUpdateConfig:StorSimpleCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageBackupScheduleId)]
        [ValidateNotNullOrEmptyAttribute]
        public String Id { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageBackupTypeDesc)]
        [ValidateNotNullOrEmptyAttribute]
        [ValidateSet("LocalSnapshot", "CloudSnapshot")]
        public String BackupType { get; set; }

        [Parameter(Position = 2, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageRecurrenceTypeDesc)]
        [ValidateNotNullOrEmptyAttribute]
        [ValidateSet("Minutes", "Hourly", "Daily", "Weekly")]
        public String RecurrenceType { get; set; }

        [Parameter(Position = 3, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageRecurrenceValueDesc)]
        [ValidateNotNullOrEmptyAttribute]
        public int RecurrenceValue { get; set; }

        [Parameter(Position = 4, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageRetentionCountDesc)]
        [ValidateNotNullOrEmptyAttribute]
        public long RetentionCount { get; set; }

        [Parameter(Position = 5, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageBackupStartFromDesc)]
        public String StartFromDateTime { get; set; }

        [Parameter(Position = 6, Mandatory = false, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageBackupEnabledDesc)]
        public bool Enabled { get; set; }

        private ScheduleStatus scheduleStatus;
        private DateTime StartFromDt;
        private void ProcessParameters()
        {
            if (!String.IsNullOrEmpty(StartFromDateTime))
            {
                bool dateTimeValid = DateTime.TryParse(StartFromDateTime, out StartFromDt);

                if (!dateTimeValid)
                {
                    throw new ArgumentException(Resources.StartFromDateForBackupNotValid);
                }
            }
            else
                StartFromDt = DateTime.Now;

            scheduleStatus = Enabled ? ScheduleStatus.Enabled : ScheduleStatus.Disabled;
            if (BackupType == "Invalid")
            {
                throw new ArgumentException("BackupType cannot be Invalid");
            }

            if (RetentionCount < 1 || RetentionCount > 64)
            {
                throw new ArgumentException("RetentionCount value should be 1 - 64");
            }

            if (RecurrenceType == "Invalid")
            {
                throw new ArgumentException("RecurrenceType cannot be Invalid");
            }

            if (RecurrenceValue <= 0)
            {
                throw new ArgumentException("RecurrenceValue should be >=0");
            }
        }

        public override void ExecuteCmdlet()
        {
            try
            {
                ProcessParameters();

                BackupScheduleUpdateRequest updateScheduleObject = new BackupScheduleUpdateRequest();
                updateScheduleObject.BackupType = (BackupType)Enum.Parse(typeof(BackupType), BackupType);
                updateScheduleObject.Status = scheduleStatus;
                updateScheduleObject.RetentionCount = RetentionCount;
                updateScheduleObject.StartTime = StartFromDt.ToString("yyyy-MM-ddTHH:mm:sszzz");
                updateScheduleObject.Recurrence = new ScheduleRecurrence();
                updateScheduleObject.Recurrence.RecurrenceType = (RecurrenceType)Enum.Parse(typeof(RecurrenceType), RecurrenceType);
                updateScheduleObject.Recurrence.RecurrenceValue = RecurrenceValue;
                updateScheduleObject.Id = Id;

                WriteObject(updateScheduleObject);
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }

    }
}
