namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>The definition of an export.</summary>
    public partial class ExportDefinition :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinition,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal
    {

        /// <summary>
        /// Array of column names to be included in the export. If not provided then the export will include all available columns.
        /// The available columns can vary by customer channel (see examples).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string[] ConfigurationColumn { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDatasetInternal)DataSet).ConfigurationColumn; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDatasetInternal)DataSet).ConfigurationColumn = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="DataSet" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDataset _dataSet;

        /// <summary>The definition for data in the export.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDataset DataSet { get => (this._dataSet = this._dataSet ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDataset()); set => this._dataSet = value; }

        /// <summary>The granularity of rows in the export. Currently only 'Daily' is supported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType? DataSetGranularity { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDatasetInternal)DataSet).Granularity; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDatasetInternal)DataSet).Granularity = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType)""); }

        /// <summary>Internal Acessors for DataSet</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDataset Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal.DataSet { get => (this._dataSet = this._dataSet ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDataset()); set { {_dataSet = value;} } }

        /// <summary>Internal Acessors for DataSetConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDatasetConfiguration Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal.DataSetConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDatasetInternal)DataSet).Configuration; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDatasetInternal)DataSet).Configuration = value; }

        /// <summary>Internal Acessors for TimePeriod</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportTimePeriod Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal.TimePeriod { get => (this._timePeriod = this._timePeriod ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportTimePeriod()); set { {_timePeriod = value;} } }

        /// <summary>Backing field for <see cref="TimePeriod" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportTimePeriod _timePeriod;

        /// <summary>Has time period for pulling data for the export.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportTimePeriod TimePeriod { get => (this._timePeriod = this._timePeriod ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportTimePeriod()); set => this._timePeriod = value; }

        /// <summary>The start date for export data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public global::System.DateTime? TimePeriodFrom { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportTimePeriodInternal)TimePeriod).From; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportTimePeriodInternal)TimePeriod).From = value ?? default(global::System.DateTime); }

        /// <summary>The end date for export data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public global::System.DateTime? TimePeriodTo { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportTimePeriodInternal)TimePeriod).To; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportTimePeriodInternal)TimePeriod).To = value ?? default(global::System.DateTime); }

        /// <summary>Backing field for <see cref="Timeframe" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType _timeframe;

        /// <summary>
        /// The time frame for pulling data for the export. If custom, then a specific time period must be provided.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType Timeframe { get => this._timeframe; set => this._timeframe = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType _type;

        /// <summary>
        /// The type of the export. Note that 'Usage' is equivalent to 'ActualCost' and is applicable to exports that do not yet provide
        /// data for charges or amortization for service reservations.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="ExportDefinition" /> instance.</summary>
        public ExportDefinition()
        {

        }
    }
    /// The definition of an export.
    public partial interface IExportDefinition :
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
        string[] ConfigurationColumn { get; set; }
        /// <summary>The granularity of rows in the export. Currently only 'Daily' is supported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The granularity of rows in the export. Currently only 'Daily' is supported.",
        SerializedName = @"granularity",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType? DataSetGranularity { get; set; }
        /// <summary>The start date for export data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The start date for export data.",
        SerializedName = @"from",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? TimePeriodFrom { get; set; }
        /// <summary>The end date for export data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The end date for export data.",
        SerializedName = @"to",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? TimePeriodTo { get; set; }
        /// <summary>
        /// The time frame for pulling data for the export. If custom, then a specific time period must be provided.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The time frame for pulling data for the export. If custom, then a specific time period must be provided.",
        SerializedName = @"timeframe",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType Timeframe { get; set; }
        /// <summary>
        /// The type of the export. Note that 'Usage' is equivalent to 'ActualCost' and is applicable to exports that do not yet provide
        /// data for charges or amortization for service reservations.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The type of the export. Note that 'Usage' is equivalent to 'ActualCost' and is applicable to exports that do not yet provide data for charges or amortization for service reservations.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType Type { get; set; }

    }
    /// The definition of an export.
    public partial interface IExportDefinitionInternal

    {
        /// <summary>
        /// Array of column names to be included in the export. If not provided then the export will include all available columns.
        /// The available columns can vary by customer channel (see examples).
        /// </summary>
        string[] ConfigurationColumn { get; set; }
        /// <summary>The definition for data in the export.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDataset DataSet { get; set; }
        /// <summary>The export dataset configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDatasetConfiguration DataSetConfiguration { get; set; }
        /// <summary>The granularity of rows in the export. Currently only 'Daily' is supported.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType? DataSetGranularity { get; set; }
        /// <summary>Has time period for pulling data for the export.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportTimePeriod TimePeriod { get; set; }
        /// <summary>The start date for export data.</summary>
        global::System.DateTime? TimePeriodFrom { get; set; }
        /// <summary>The end date for export data.</summary>
        global::System.DateTime? TimePeriodTo { get; set; }
        /// <summary>
        /// The time frame for pulling data for the export. If custom, then a specific time period must be provided.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType Timeframe { get; set; }
        /// <summary>
        /// The type of the export. Note that 'Usage' is equivalent to 'ActualCost' and is applicable to exports that do not yet provide
        /// data for charges or amortization for service reservations.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType Type { get; set; }

    }
}