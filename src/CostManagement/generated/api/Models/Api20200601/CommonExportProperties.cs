namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>The common properties of the export.</summary>
    public partial class CommonExportProperties :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportProperties,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal
    {

        /// <summary>
        /// Array of column names to be included in the export. If not provided then the export will include all available columns.
        /// The available columns can vary by customer channel (see examples).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string[] ConfigurationColumn { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)Definition).ConfigurationColumn; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)Definition).ConfigurationColumn = value ?? null /* arrayOf */; }

        /// <summary>The granularity of rows in the export. Currently only 'Daily' is supported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType? DataSetGranularity { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)Definition).DataSetGranularity; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)Definition).DataSetGranularity = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType)""); }

        /// <summary>Backing field for <see cref="Definition" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinition _definition;

        /// <summary>Has the definition for the export.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinition Definition { get => (this._definition = this._definition ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDefinition()); set => this._definition = value; }

        /// <summary>
        /// The time frame for pulling data for the export. If custom, then a specific time period must be provided.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType DefinitionTimeframe { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)Definition).Timeframe; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)Definition).Timeframe = value ; }

        /// <summary>
        /// The type of the export. Note that 'Usage' is equivalent to 'ActualCost' and is applicable to exports that do not yet provide
        /// data for charges or amortization for service reservations.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType DefinitionType { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)Definition).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)Definition).Type = value ; }

        /// <summary>Backing field for <see cref="DeliveryInfo" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryInfo _deliveryInfo;

        /// <summary>Has delivery information for the export.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryInfo DeliveryInfo { get => (this._deliveryInfo = this._deliveryInfo ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDeliveryInfo()); set => this._deliveryInfo = value; }

        /// <summary>The name of the container where exports will be uploaded.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string DestinationContainer { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryInfoInternal)DeliveryInfo).DestinationContainer; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryInfoInternal)DeliveryInfo).DestinationContainer = value ; }

        /// <summary>The resource id of the storage account where exports will be delivered.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string DestinationResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryInfoInternal)DeliveryInfo).DestinationResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryInfoInternal)DeliveryInfo).DestinationResourceId = value ; }

        /// <summary>The name of the directory where exports will be uploaded.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string DestinationRootFolderPath { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryInfoInternal)DeliveryInfo).DestinationRootFolderPath; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryInfoInternal)DeliveryInfo).DestinationRootFolderPath = value ?? null; }

        /// <summary>Backing field for <see cref="Format" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.FormatType? _format;

        /// <summary>The format of the export being delivered. Currently only 'Csv' is supported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.FormatType? Format { get => this._format; set => this._format = value; }

        /// <summary>Internal Acessors for DataSetConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDatasetConfiguration Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal.DataSetConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)Definition).DataSetConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)Definition).DataSetConfiguration = value; }

        /// <summary>Internal Acessors for Definition</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinition Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal.Definition { get => (this._definition = this._definition ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDefinition()); set { {_definition = value;} } }

        /// <summary>Internal Acessors for DefinitionDataSet</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDataset Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal.DefinitionDataSet { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)Definition).DataSet; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)Definition).DataSet = value; }

        /// <summary>Internal Acessors for DefinitionTimePeriod</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportTimePeriod Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal.DefinitionTimePeriod { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)Definition).TimePeriod; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)Definition).TimePeriod = value; }

        /// <summary>Internal Acessors for DeliveryInfo</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryInfo Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal.DeliveryInfo { get => (this._deliveryInfo = this._deliveryInfo ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDeliveryInfo()); set { {_deliveryInfo = value;} } }

        /// <summary>Internal Acessors for DeliveryInfoDestination</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryDestination Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal.DeliveryInfoDestination { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryInfoInternal)DeliveryInfo).Destination; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryInfoInternal)DeliveryInfo).Destination = value; }

        /// <summary>Internal Acessors for NextRunTimeEstimate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal.NextRunTimeEstimate { get => this._nextRunTimeEstimate; set { {_nextRunTimeEstimate = value;} } }

        /// <summary>Internal Acessors for RunHistory</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionListResult Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal.RunHistory { get => (this._runHistory = this._runHistory ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportExecutionListResult()); set { {_runHistory = value;} } }

        /// <summary>Internal Acessors for RunHistoryValue</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecution[] Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal.RunHistoryValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionListResultInternal)RunHistory).Value; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionListResultInternal)RunHistory).Value = value; }

        /// <summary>Backing field for <see cref="NextRunTimeEstimate" /> property.</summary>
        private global::System.DateTime? _nextRunTimeEstimate;

        /// <summary>
        /// If the export has an active schedule, provides an estimate of the next execution time.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public global::System.DateTime? NextRunTimeEstimate { get => this._nextRunTimeEstimate; }

        /// <summary>Backing field for <see cref="RunHistory" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionListResult _runHistory;

        /// <summary>If requested, has the most recent execution history for the export.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionListResult RunHistory { get => (this._runHistory = this._runHistory ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportExecutionListResult()); set => this._runHistory = value; }

        /// <summary>A list of export executions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecution[] RunHistoryValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionListResultInternal)RunHistory).Value; }

        /// <summary>The start date for export data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public global::System.DateTime? TimePeriodFrom { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)Definition).TimePeriodFrom; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)Definition).TimePeriodFrom = value ?? default(global::System.DateTime); }

        /// <summary>The end date for export data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public global::System.DateTime? TimePeriodTo { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)Definition).TimePeriodTo; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinitionInternal)Definition).TimePeriodTo = value ?? default(global::System.DateTime); }

        /// <summary>Creates an new <see cref="CommonExportProperties" /> instance.</summary>
        public CommonExportProperties()
        {

        }
    }
    /// The common properties of the export.
    public partial interface ICommonExportProperties :
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
        /// <summary>
        /// The time frame for pulling data for the export. If custom, then a specific time period must be provided.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The time frame for pulling data for the export. If custom, then a specific time period must be provided.",
        SerializedName = @"timeframe",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType DefinitionTimeframe { get; set; }
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
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType DefinitionType { get; set; }
        /// <summary>The name of the container where exports will be uploaded.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the container where exports will be uploaded.",
        SerializedName = @"container",
        PossibleTypes = new [] { typeof(string) })]
        string DestinationContainer { get; set; }
        /// <summary>The resource id of the storage account where exports will be delivered.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The resource id of the storage account where exports will be delivered.",
        SerializedName = @"resourceId",
        PossibleTypes = new [] { typeof(string) })]
        string DestinationResourceId { get; set; }
        /// <summary>The name of the directory where exports will be uploaded.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the directory where exports will be uploaded.",
        SerializedName = @"rootFolderPath",
        PossibleTypes = new [] { typeof(string) })]
        string DestinationRootFolderPath { get; set; }
        /// <summary>The format of the export being delivered. Currently only 'Csv' is supported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The format of the export being delivered. Currently only 'Csv' is supported.",
        SerializedName = @"format",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.FormatType) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.FormatType? Format { get; set; }
        /// <summary>
        /// If the export has an active schedule, provides an estimate of the next execution time.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"If the export has an active schedule, provides an estimate of the next execution time.",
        SerializedName = @"nextRunTimeEstimate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? NextRunTimeEstimate { get;  }
        /// <summary>A list of export executions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A list of export executions.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecution) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecution[] RunHistoryValue { get;  }
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

    }
    /// The common properties of the export.
    public partial interface ICommonExportPropertiesInternal

    {
        /// <summary>
        /// Array of column names to be included in the export. If not provided then the export will include all available columns.
        /// The available columns can vary by customer channel (see examples).
        /// </summary>
        string[] ConfigurationColumn { get; set; }
        /// <summary>The export dataset configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDatasetConfiguration DataSetConfiguration { get; set; }
        /// <summary>The granularity of rows in the export. Currently only 'Daily' is supported.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType? DataSetGranularity { get; set; }
        /// <summary>Has the definition for the export.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinition Definition { get; set; }
        /// <summary>The definition for data in the export.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDataset DefinitionDataSet { get; set; }
        /// <summary>Has time period for pulling data for the export.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportTimePeriod DefinitionTimePeriod { get; set; }
        /// <summary>
        /// The time frame for pulling data for the export. If custom, then a specific time period must be provided.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType DefinitionTimeframe { get; set; }
        /// <summary>
        /// The type of the export. Note that 'Usage' is equivalent to 'ActualCost' and is applicable to exports that do not yet provide
        /// data for charges or amortization for service reservations.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType DefinitionType { get; set; }
        /// <summary>Has delivery information for the export.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryInfo DeliveryInfo { get; set; }
        /// <summary>Has destination for the export being delivered.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryDestination DeliveryInfoDestination { get; set; }
        /// <summary>The name of the container where exports will be uploaded.</summary>
        string DestinationContainer { get; set; }
        /// <summary>The resource id of the storage account where exports will be delivered.</summary>
        string DestinationResourceId { get; set; }
        /// <summary>The name of the directory where exports will be uploaded.</summary>
        string DestinationRootFolderPath { get; set; }
        /// <summary>The format of the export being delivered. Currently only 'Csv' is supported.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.FormatType? Format { get; set; }
        /// <summary>
        /// If the export has an active schedule, provides an estimate of the next execution time.
        /// </summary>
        global::System.DateTime? NextRunTimeEstimate { get; set; }
        /// <summary>If requested, has the most recent execution history for the export.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionListResult RunHistory { get; set; }
        /// <summary>A list of export executions.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecution[] RunHistoryValue { get; set; }
        /// <summary>The start date for export data.</summary>
        global::System.DateTime? TimePeriodFrom { get; set; }
        /// <summary>The end date for export data.</summary>
        global::System.DateTime? TimePeriodTo { get; set; }

    }
}