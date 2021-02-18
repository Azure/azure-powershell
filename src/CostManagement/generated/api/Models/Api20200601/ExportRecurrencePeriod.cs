namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>The start and end date for recurrence schedule.</summary>
    public partial class ExportRecurrencePeriod :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportRecurrencePeriod,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportRecurrencePeriodInternal
    {

        /// <summary>Backing field for <see cref="From" /> property.</summary>
        private global::System.DateTime _from;

        /// <summary>The start date of recurrence.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public global::System.DateTime From { get => this._from; set => this._from = value; }

        /// <summary>Backing field for <see cref="To" /> property.</summary>
        private global::System.DateTime? _to;

        /// <summary>The end date of recurrence.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public global::System.DateTime? To { get => this._to; set => this._to = value; }

        /// <summary>Creates an new <see cref="ExportRecurrencePeriod" /> instance.</summary>
        public ExportRecurrencePeriod()
        {

        }
    }
    /// The start and end date for recurrence schedule.
    public partial interface IExportRecurrencePeriod :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable
    {
        /// <summary>The start date of recurrence.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The start date of recurrence.",
        SerializedName = @"from",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime From { get; set; }
        /// <summary>The end date of recurrence.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The end date of recurrence.",
        SerializedName = @"to",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? To { get; set; }

    }
    /// The start and end date for recurrence schedule.
    public partial interface IExportRecurrencePeriodInternal

    {
        /// <summary>The start date of recurrence.</summary>
        global::System.DateTime From { get; set; }
        /// <summary>The end date of recurrence.</summary>
        global::System.DateTime? To { get; set; }

    }
}