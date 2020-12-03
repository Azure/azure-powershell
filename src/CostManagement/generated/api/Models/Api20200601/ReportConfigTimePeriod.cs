namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>The start and end date for pulling data for the report.</summary>
    public partial class ReportConfigTimePeriod :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigTimePeriod,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigTimePeriodInternal
    {

        /// <summary>Backing field for <see cref="From" /> property.</summary>
        private global::System.DateTime _from;

        /// <summary>The start date to pull data from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public global::System.DateTime From { get => this._from; set => this._from = value; }

        /// <summary>Backing field for <see cref="To" /> property.</summary>
        private global::System.DateTime _to;

        /// <summary>The end date to pull data to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public global::System.DateTime To { get => this._to; set => this._to = value; }

        /// <summary>Creates an new <see cref="ReportConfigTimePeriod" /> instance.</summary>
        public ReportConfigTimePeriod()
        {

        }
    }
    /// The start and end date for pulling data for the report.
    public partial interface IReportConfigTimePeriod :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable
    {
        /// <summary>The start date to pull data from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The start date to pull data from.",
        SerializedName = @"from",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime From { get; set; }
        /// <summary>The end date to pull data to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The end date to pull data to.",
        SerializedName = @"to",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime To { get; set; }

    }
    /// The start and end date for pulling data for the report.
    public partial interface IReportConfigTimePeriodInternal

    {
        /// <summary>The start date to pull data from.</summary>
        global::System.DateTime From { get; set; }
        /// <summary>The end date to pull data to.</summary>
        global::System.DateTime To { get; set; }

    }
}