namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>
    /// The date range for data in the export. This should only be specified with timeFrame set to 'Custom'. The maximum date
    /// range is 3 months.
    /// </summary>
    public partial class ExportTimePeriod :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportTimePeriod,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportTimePeriodInternal
    {

        /// <summary>Backing field for <see cref="From" /> property.</summary>
        private global::System.DateTime _from;

        /// <summary>The start date for export data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public global::System.DateTime From { get => this._from; set => this._from = value; }

        /// <summary>Backing field for <see cref="To" /> property.</summary>
        private global::System.DateTime _to;

        /// <summary>The end date for export data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public global::System.DateTime To { get => this._to; set => this._to = value; }

        /// <summary>Creates an new <see cref="ExportTimePeriod" /> instance.</summary>
        public ExportTimePeriod()
        {

        }
    }
    /// The date range for data in the export. This should only be specified with timeFrame set to 'Custom'. The maximum date
    /// range is 3 months.
    public partial interface IExportTimePeriod :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable
    {
        /// <summary>The start date for export data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The start date for export data.",
        SerializedName = @"from",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime From { get; set; }
        /// <summary>The end date for export data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The end date for export data.",
        SerializedName = @"to",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime To { get; set; }

    }
    /// The date range for data in the export. This should only be specified with timeFrame set to 'Custom'. The maximum date
    /// range is 3 months.
    public partial interface IExportTimePeriodInternal

    {
        /// <summary>The start date for export data.</summary>
        global::System.DateTime From { get; set; }
        /// <summary>The end date for export data.</summary>
        global::System.DateTime To { get; set; }

    }
}