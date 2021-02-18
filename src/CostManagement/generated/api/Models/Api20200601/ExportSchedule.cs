namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>The schedule associated with the export.</summary>
    public partial class ExportSchedule :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportSchedule,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportScheduleInternal
    {

        /// <summary>Internal Acessors for RecurrencePeriod</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportRecurrencePeriod Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportScheduleInternal.RecurrencePeriod { get => (this._recurrencePeriod = this._recurrencePeriod ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportRecurrencePeriod()); set { {_recurrencePeriod = value;} } }

        /// <summary>Backing field for <see cref="Recurrence" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.RecurrenceType? _recurrence;

        /// <summary>The schedule recurrence.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.RecurrenceType? Recurrence { get => this._recurrence; set => this._recurrence = value; }

        /// <summary>Backing field for <see cref="RecurrencePeriod" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportRecurrencePeriod _recurrencePeriod;

        /// <summary>
        /// Has start and end date of the recurrence. The start date must be in future. If present, the end date must be greater than
        /// start date.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportRecurrencePeriod RecurrencePeriod { get => (this._recurrencePeriod = this._recurrencePeriod ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportRecurrencePeriod()); set => this._recurrencePeriod = value; }

        /// <summary>The start date of recurrence.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public global::System.DateTime? RecurrencePeriodFrom { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportRecurrencePeriodInternal)RecurrencePeriod).From; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportRecurrencePeriodInternal)RecurrencePeriod).From = value ?? default(global::System.DateTime); }

        /// <summary>The end date of recurrence.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public global::System.DateTime? RecurrencePeriodTo { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportRecurrencePeriodInternal)RecurrencePeriod).To; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportRecurrencePeriodInternal)RecurrencePeriod).To = value ?? default(global::System.DateTime); }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.StatusType? _status;

        /// <summary>
        /// The status of the export's schedule. If 'Inactive', the export's schedule is paused.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.StatusType? Status { get => this._status; set => this._status = value; }

        /// <summary>Creates an new <see cref="ExportSchedule" /> instance.</summary>
        public ExportSchedule()
        {

        }
    }
    /// The schedule associated with the export.
    public partial interface IExportSchedule :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable
    {
        /// <summary>The schedule recurrence.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The schedule recurrence.",
        SerializedName = @"recurrence",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.RecurrenceType) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.RecurrenceType? Recurrence { get; set; }
        /// <summary>The start date of recurrence.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The start date of recurrence.",
        SerializedName = @"from",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? RecurrencePeriodFrom { get; set; }
        /// <summary>The end date of recurrence.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The end date of recurrence.",
        SerializedName = @"to",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? RecurrencePeriodTo { get; set; }
        /// <summary>
        /// The status of the export's schedule. If 'Inactive', the export's schedule is paused.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The status of the export's schedule. If 'Inactive', the export's schedule is paused.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.StatusType) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.StatusType? Status { get; set; }

    }
    /// The schedule associated with the export.
    public partial interface IExportScheduleInternal

    {
        /// <summary>The schedule recurrence.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.RecurrenceType? Recurrence { get; set; }
        /// <summary>
        /// Has start and end date of the recurrence. The start date must be in future. If present, the end date must be greater than
        /// start date.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportRecurrencePeriod RecurrencePeriod { get; set; }
        /// <summary>The start date of recurrence.</summary>
        global::System.DateTime? RecurrencePeriodFrom { get; set; }
        /// <summary>The end date of recurrence.</summary>
        global::System.DateTime? RecurrencePeriodTo { get; set; }
        /// <summary>
        /// The status of the export's schedule. If 'Inactive', the export's schedule is paused.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.StatusType? Status { get; set; }

    }
}