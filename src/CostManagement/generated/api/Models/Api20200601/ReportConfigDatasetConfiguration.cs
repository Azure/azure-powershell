namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>The configuration of dataset in the report.</summary>
    public partial class ReportConfigDatasetConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IReportConfigDatasetConfigurationInternal
    {

        /// <summary>Backing field for <see cref="Column" /> property.</summary>
        private string[] _column;

        /// <summary>
        /// Array of column names to be included in the report. Any valid report column name is allowed. If not provided, then report
        /// includes all columns.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string[] Column { get => this._column; set => this._column = value; }

        /// <summary>Creates an new <see cref="ReportConfigDatasetConfiguration" /> instance.</summary>
        public ReportConfigDatasetConfiguration()
        {

        }
    }
    /// The configuration of dataset in the report.
    public partial interface IReportConfigDatasetConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Array of column names to be included in the report. Any valid report column name is allowed. If not provided, then report
        /// includes all columns.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Array of column names to be included in the report. Any valid report column name is allowed. If not provided, then report includes all columns.",
        SerializedName = @"columns",
        PossibleTypes = new [] { typeof(string) })]
        string[] Column { get; set; }

    }
    /// The configuration of dataset in the report.
    public partial interface IReportConfigDatasetConfigurationInternal

    {
        /// <summary>
        /// Array of column names to be included in the report. Any valid report column name is allowed. If not provided, then report
        /// includes all columns.
        /// </summary>
        string[] Column { get; set; }

    }
}