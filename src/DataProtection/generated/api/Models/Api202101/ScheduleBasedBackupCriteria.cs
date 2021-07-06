namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Schedule based backup criteria</summary>
    public partial class ScheduleBasedBackupCriteria :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IScheduleBasedBackupCriteria,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IScheduleBasedBackupCriteriaInternal,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupCriteria"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupCriteria __backupCriteria = new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.BackupCriteria();

        /// <summary>Backing field for <see cref="AbsoluteCriterion" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.AbsoluteMarker[] _absoluteCriterion;

        /// <summary>
        /// it contains absolute values like "AllBackup" / "FirstOfDay" / "FirstOfWeek" / "FirstOfMonth"
        /// and should be part of AbsoluteMarker enum
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.AbsoluteMarker[] AbsoluteCriterion { get => this._absoluteCriterion; set => this._absoluteCriterion = value; }

        /// <summary>Backing field for <see cref="DaysOfMonth" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDay[] _daysOfMonth;

        /// <summary>This is day of the month from 1 to 28 other wise last of month</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDay[] DaysOfMonth { get => this._daysOfMonth; set => this._daysOfMonth = value; }

        /// <summary>Backing field for <see cref="DaysOfTheWeek" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DayOfWeek[] _daysOfTheWeek;

        /// <summary>It should be Sunday/Monday/T..../Saturday</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DayOfWeek[] DaysOfTheWeek { get => this._daysOfTheWeek; set => this._daysOfTheWeek = value; }

        /// <summary>Backing field for <see cref="MonthsOfYear" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.Month[] _monthsOfYear;

        /// <summary>It should be January/February/....../December</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.Month[] MonthsOfYear { get => this._monthsOfYear; set => this._monthsOfYear = value; }

        /// <summary>Type of the specific object - used for deserializing</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public string ObjectType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupCriteriaInternal)__backupCriteria).ObjectType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupCriteriaInternal)__backupCriteria).ObjectType = value ; }

        /// <summary>Backing field for <see cref="ScheduleTime" /> property.</summary>
        private global::System.DateTime[] _scheduleTime;

        /// <summary>List of schedule times for backup</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public global::System.DateTime[] ScheduleTime { get => this._scheduleTime; set => this._scheduleTime = value; }

        /// <summary>Backing field for <see cref="WeeksOfTheMonth" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.WeekNumber[] _weeksOfTheMonth;

        /// <summary>It should be First/Second/Third/Fourth/Last</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.WeekNumber[] WeeksOfTheMonth { get => this._weeksOfTheMonth; set => this._weeksOfTheMonth = value; }

        /// <summary>Creates an new <see cref="ScheduleBasedBackupCriteria" /> instance.</summary>
        public ScheduleBasedBackupCriteria()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__backupCriteria), __backupCriteria);
            await eventListener.AssertObjectIsValid(nameof(__backupCriteria), __backupCriteria);
        }
    }
    /// Schedule based backup criteria
    public partial interface IScheduleBasedBackupCriteria :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupCriteria
    {
        /// <summary>
        /// it contains absolute values like "AllBackup" / "FirstOfDay" / "FirstOfWeek" / "FirstOfMonth"
        /// and should be part of AbsoluteMarker enum
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"it contains absolute values like ""AllBackup"" / ""FirstOfDay"" / ""FirstOfWeek"" / ""FirstOfMonth""
        and should be part of AbsoluteMarker enum",
        SerializedName = @"absoluteCriteria",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.AbsoluteMarker) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.AbsoluteMarker[] AbsoluteCriterion { get; set; }
        /// <summary>This is day of the month from 1 to 28 other wise last of month</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"This is day of the month from 1 to 28 other wise last of month",
        SerializedName = @"daysOfMonth",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDay) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDay[] DaysOfMonth { get; set; }
        /// <summary>It should be Sunday/Monday/T..../Saturday</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"It should be Sunday/Monday/T..../Saturday",
        SerializedName = @"daysOfTheWeek",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DayOfWeek) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DayOfWeek[] DaysOfTheWeek { get; set; }
        /// <summary>It should be January/February/....../December</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"It should be January/February/....../December",
        SerializedName = @"monthsOfYear",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.Month) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.Month[] MonthsOfYear { get; set; }
        /// <summary>List of schedule times for backup</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of schedule times for backup",
        SerializedName = @"scheduleTimes",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime[] ScheduleTime { get; set; }
        /// <summary>It should be First/Second/Third/Fourth/Last</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"It should be First/Second/Third/Fourth/Last",
        SerializedName = @"weeksOfTheMonth",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.WeekNumber) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.WeekNumber[] WeeksOfTheMonth { get; set; }

    }
    /// Schedule based backup criteria
    internal partial interface IScheduleBasedBackupCriteriaInternal :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupCriteriaInternal
    {
        /// <summary>
        /// it contains absolute values like "AllBackup" / "FirstOfDay" / "FirstOfWeek" / "FirstOfMonth"
        /// and should be part of AbsoluteMarker enum
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.AbsoluteMarker[] AbsoluteCriterion { get; set; }
        /// <summary>This is day of the month from 1 to 28 other wise last of month</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDay[] DaysOfMonth { get; set; }
        /// <summary>It should be Sunday/Monday/T..../Saturday</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DayOfWeek[] DaysOfTheWeek { get; set; }
        /// <summary>It should be January/February/....../December</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.Month[] MonthsOfYear { get; set; }
        /// <summary>List of schedule times for backup</summary>
        global::System.DateTime[] ScheduleTime { get; set; }
        /// <summary>It should be First/Second/Third/Fourth/Last</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.WeekNumber[] WeeksOfTheMonth { get; set; }

    }
}