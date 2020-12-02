namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>
    /// The export dataset configuration. Allows columns to be selected for the export. If not provided then the export will include
    /// all available columns.
    /// </summary>
    public partial class ExportDatasetConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDatasetConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDatasetConfigurationInternal
    {

        /// <summary>Backing field for <see cref="Column" /> property.</summary>
        private string[] _column;

        /// <summary>
        /// Array of column names to be included in the export. If not provided then the export will include all available columns.
        /// The available columns can vary by customer channel (see examples).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string[] Column { get => this._column; set => this._column = value; }

        /// <summary>Creates an new <see cref="ExportDatasetConfiguration" /> instance.</summary>
        public ExportDatasetConfiguration()
        {

        }
    }
    /// The export dataset configuration. Allows columns to be selected for the export. If not provided then the export will include
    /// all available columns.
    public partial interface IExportDatasetConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Array of column names to be included in the export. If not provided then the export will include all available columns.
        /// The available columns can vary by customer channel (see examples).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Array of column names to be included in the export. If not provided then the export will include all available columns. The available columns can vary by customer channel (see examples).",
        SerializedName = @"columns",
        PossibleTypes = new [] { typeof(string) })]
        string[] Column { get; set; }

    }
    /// The export dataset configuration. Allows columns to be selected for the export. If not provided then the export will include
    /// all available columns.
    public partial interface IExportDatasetConfigurationInternal

    {
        /// <summary>
        /// Array of column names to be included in the export. If not provided then the export will include all available columns.
        /// The available columns can vary by customer channel (see examples).
        /// </summary>
        string[] Column { get; set; }

    }
}