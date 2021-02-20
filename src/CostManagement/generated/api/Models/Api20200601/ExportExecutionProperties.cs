namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>The properties of the export execution.</summary>
    public partial class ExportExecutionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionProperties,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionPropertiesInternal
    {

        /// <summary>Error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string Code { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IErrorDetailsInternal)Error).Code; }

        /// <summary>
        /// Array of column names to be included in the export. If not provided then the export will include all available columns.
        /// The available columns can vary by customer channel (see examples).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string[] ConfigurationColumn { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)RunSetting).ConfigurationColumn; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)RunSetting).ConfigurationColumn = value ?? null /* arrayOf */; }

        /// <summary>The granularity of rows in the export. Currently only 'Daily' is supported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType? DataSetGranularity { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)RunSetting).DataSetGranularity; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)RunSetting).DataSetGranularity = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType)""); }

        /// <summary>
        /// The time frame for pulling data for the export. If custom, then a specific time period must be provided.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType? DefinitionTimeframe { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)RunSetting).DefinitionTimeframe; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)RunSetting).DefinitionTimeframe = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType)""); }

        /// <summary>
        /// The type of the export. Note that 'Usage' is equivalent to 'ActualCost' and is applicable to exports that do not yet provide
        /// data for charges or amortization for service reservations.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType? DefinitionType { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)RunSetting).DefinitionType; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)RunSetting).DefinitionType = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType)""); }

        /// <summary>The name of the container where exports will be uploaded.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string DestinationContainer { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)RunSetting).DestinationContainer; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)RunSetting).DestinationContainer = value ?? null; }

        /// <summary>The resource id of the storage account where exports will be delivered.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string DestinationResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)RunSetting).DestinationResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)RunSetting).DestinationResourceId = value ?? null; }

        /// <summary>The name of the directory where exports will be uploaded.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string DestinationRootFolderPath { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)RunSetting).DestinationRootFolderPath; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)RunSetting).DestinationRootFolderPath = value ?? null; }

        /// <summary>Backing field for <see cref="Error" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IErrorDetails _error;

        /// <summary>The details of any error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IErrorDetails Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ErrorDetails()); set => this._error = value; }

        /// <summary>Backing field for <see cref="ExecutionType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExecutionType? _executionType;

        /// <summary>The type of the export execution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExecutionType? ExecutionType { get => this._executionType; set => this._executionType = value; }

        /// <summary>Backing field for <see cref="FileName" /> property.</summary>
        private string _fileName;

        /// <summary>The name of the exported file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string FileName { get => this._fileName; set => this._fileName = value; }

        /// <summary>Error message indicating why the operation failed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string Message { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IErrorDetailsInternal)Error).Message; }

        /// <summary>Internal Acessors for Code</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionPropertiesInternal.Code { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IErrorDetailsInternal)Error).Code; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IErrorDetailsInternal)Error).Code = value; }

        /// <summary>Internal Acessors for DataSetConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDatasetConfiguration Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionPropertiesInternal.DataSetConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)RunSetting).DataSetConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)RunSetting).DataSetConfiguration = value; }

        /// <summary>Internal Acessors for DefinitionDataSet</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDataset Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionPropertiesInternal.DefinitionDataSet { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)RunSetting).DefinitionDataSet; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)RunSetting).DefinitionDataSet = value; }

        /// <summary>Internal Acessors for DefinitionTimePeriod</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportTimePeriod Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionPropertiesInternal.DefinitionTimePeriod { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)RunSetting).DefinitionTimePeriod; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)RunSetting).DefinitionTimePeriod = value; }

        /// <summary>Internal Acessors for DeliveryInfoDestination</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryDestination Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionPropertiesInternal.DeliveryInfoDestination { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)RunSetting).DeliveryInfoDestination; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)RunSetting).DeliveryInfoDestination = value; }

        /// <summary>Internal Acessors for Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IErrorDetails Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionPropertiesInternal.Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ErrorDetails()); set { {_error = value;} } }

        /// <summary>Internal Acessors for Message</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionPropertiesInternal.Message { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IErrorDetailsInternal)Error).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IErrorDetailsInternal)Error).Message = value; }

        /// <summary>Internal Acessors for RunHistoryValue</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecution[] Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionPropertiesInternal.RunHistoryValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)RunSetting).RunHistoryValue; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)RunSetting).RunHistoryValue = value; }

        /// <summary>Internal Acessors for RunSetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportProperties Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionPropertiesInternal.RunSetting { get => (this._runSetting = this._runSetting ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.CommonExportProperties()); set { {_runSetting = value;} } }

        /// <summary>Internal Acessors for RunSettingDefinition</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinition Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionPropertiesInternal.RunSettingDefinition { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)RunSetting).Definition; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)RunSetting).Definition = value; }

        /// <summary>Internal Acessors for RunSettingDeliveryInfo</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryInfo Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionPropertiesInternal.RunSettingDeliveryInfo { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)RunSetting).DeliveryInfo; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)RunSetting).DeliveryInfo = value; }

        /// <summary>Internal Acessors for RunSettingNextRunTimeEstimate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionPropertiesInternal.RunSettingNextRunTimeEstimate { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)RunSetting).NextRunTimeEstimate; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)RunSetting).NextRunTimeEstimate = value; }

        /// <summary>Internal Acessors for RunSettingRunHistory</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionListResult Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionPropertiesInternal.RunSettingRunHistory { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)RunSetting).RunHistory; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)RunSetting).RunHistory = value; }

        /// <summary>Backing field for <see cref="ProcessingEndTime" /> property.</summary>
        private global::System.DateTime? _processingEndTime;

        /// <summary>The time when the export execution finished.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public global::System.DateTime? ProcessingEndTime { get => this._processingEndTime; set => this._processingEndTime = value; }

        /// <summary>Backing field for <see cref="ProcessingStartTime" /> property.</summary>
        private global::System.DateTime? _processingStartTime;

        /// <summary>The time when export was picked up to be executed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public global::System.DateTime? ProcessingStartTime { get => this._processingStartTime; set => this._processingStartTime = value; }

        /// <summary>A list of export executions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecution[] RunHistoryValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)RunSetting).RunHistoryValue; }

        /// <summary>Backing field for <see cref="RunSetting" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportProperties _runSetting;

        /// <summary>The export settings that were in effect for this execution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportProperties RunSetting { get => (this._runSetting = this._runSetting ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.CommonExportProperties()); set => this._runSetting = value; }

        /// <summary>The format of the export being delivered. Currently only 'Csv' is supported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.FormatType? RunSettingFormat { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)RunSetting).Format; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)RunSetting).Format = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.FormatType)""); }

        /// <summary>
        /// If the export has an active schedule, provides an estimate of the next execution time.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public global::System.DateTime? RunSettingNextRunTimeEstimate { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)RunSetting).NextRunTimeEstimate; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExecutionStatus? _status;

        /// <summary>The last known status of the export execution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExecutionStatus? Status { get => this._status; set => this._status = value; }

        /// <summary>Backing field for <see cref="SubmittedBy" /> property.</summary>
        private string _submittedBy;

        /// <summary>
        /// The identifier for the entity that executed the export. For OnDemand executions it is the user email. For scheduled executions
        /// it is 'System'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string SubmittedBy { get => this._submittedBy; set => this._submittedBy = value; }

        /// <summary>Backing field for <see cref="SubmittedTime" /> property.</summary>
        private global::System.DateTime? _submittedTime;

        /// <summary>The time when export was queued to be executed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public global::System.DateTime? SubmittedTime { get => this._submittedTime; set => this._submittedTime = value; }

        /// <summary>The start date for export data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public global::System.DateTime? TimePeriodFrom { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)RunSetting).TimePeriodFrom; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)RunSetting).TimePeriodFrom = value ?? default(global::System.DateTime); }

        /// <summary>The end date for export data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public global::System.DateTime? TimePeriodTo { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)RunSetting).TimePeriodTo; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)RunSetting).TimePeriodTo = value ?? default(global::System.DateTime); }

        /// <summary>Creates an new <see cref="ExportExecutionProperties" /> instance.</summary>
        public ExportExecutionProperties()
        {

        }
    }
    /// The properties of the export execution.
    public partial interface IExportExecutionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable
    {
        /// <summary>Error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Error code.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get;  }
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
        Required = false,
        ReadOnly = false,
        Description = @"The time frame for pulling data for the export. If custom, then a specific time period must be provided.",
        SerializedName = @"timeframe",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType? DefinitionTimeframe { get; set; }
        /// <summary>
        /// The type of the export. Note that 'Usage' is equivalent to 'ActualCost' and is applicable to exports that do not yet provide
        /// data for charges or amortization for service reservations.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of the export. Note that 'Usage' is equivalent to 'ActualCost' and is applicable to exports that do not yet provide data for charges or amortization for service reservations.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType? DefinitionType { get; set; }
        /// <summary>The name of the container where exports will be uploaded.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the container where exports will be uploaded.",
        SerializedName = @"container",
        PossibleTypes = new [] { typeof(string) })]
        string DestinationContainer { get; set; }
        /// <summary>The resource id of the storage account where exports will be delivered.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
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
        /// <summary>The type of the export execution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of the export execution.",
        SerializedName = @"executionType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExecutionType) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExecutionType? ExecutionType { get; set; }
        /// <summary>The name of the exported file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the exported file.",
        SerializedName = @"fileName",
        PossibleTypes = new [] { typeof(string) })]
        string FileName { get; set; }
        /// <summary>Error message indicating why the operation failed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Error message indicating why the operation failed.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get;  }
        /// <summary>The time when the export execution finished.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The time when the export execution finished.",
        SerializedName = @"processingEndTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? ProcessingEndTime { get; set; }
        /// <summary>The time when export was picked up to be executed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The time when export was picked up to be executed.",
        SerializedName = @"processingStartTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? ProcessingStartTime { get; set; }
        /// <summary>A list of export executions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A list of export executions.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecution) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecution[] RunHistoryValue { get;  }
        /// <summary>The format of the export being delivered. Currently only 'Csv' is supported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The format of the export being delivered. Currently only 'Csv' is supported.",
        SerializedName = @"format",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.FormatType) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.FormatType? RunSettingFormat { get; set; }
        /// <summary>
        /// If the export has an active schedule, provides an estimate of the next execution time.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"If the export has an active schedule, provides an estimate of the next execution time.",
        SerializedName = @"nextRunTimeEstimate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? RunSettingNextRunTimeEstimate { get;  }
        /// <summary>The last known status of the export execution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The last known status of the export execution.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExecutionStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExecutionStatus? Status { get; set; }
        /// <summary>
        /// The identifier for the entity that executed the export. For OnDemand executions it is the user email. For scheduled executions
        /// it is 'System'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The identifier for the entity that executed the export. For OnDemand executions it is the user email. For scheduled executions it is 'System'.",
        SerializedName = @"submittedBy",
        PossibleTypes = new [] { typeof(string) })]
        string SubmittedBy { get; set; }
        /// <summary>The time when export was queued to be executed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The time when export was queued to be executed.",
        SerializedName = @"submittedTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? SubmittedTime { get; set; }
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
    /// The properties of the export execution.
    public partial interface IExportExecutionPropertiesInternal

    {
        /// <summary>Error code.</summary>
        string Code { get; set; }
        /// <summary>
        /// Array of column names to be included in the export. If not provided then the export will include all available columns.
        /// The available columns can vary by customer channel (see examples).
        /// </summary>
        string[] ConfigurationColumn { get; set; }
        /// <summary>The export dataset configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDatasetConfiguration DataSetConfiguration { get; set; }
        /// <summary>The granularity of rows in the export. Currently only 'Daily' is supported.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType? DataSetGranularity { get; set; }
        /// <summary>The definition for data in the export.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDataset DefinitionDataSet { get; set; }
        /// <summary>Has time period for pulling data for the export.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportTimePeriod DefinitionTimePeriod { get; set; }
        /// <summary>
        /// The time frame for pulling data for the export. If custom, then a specific time period must be provided.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType? DefinitionTimeframe { get; set; }
        /// <summary>
        /// The type of the export. Note that 'Usage' is equivalent to 'ActualCost' and is applicable to exports that do not yet provide
        /// data for charges or amortization for service reservations.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType? DefinitionType { get; set; }
        /// <summary>Has destination for the export being delivered.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryDestination DeliveryInfoDestination { get; set; }
        /// <summary>The name of the container where exports will be uploaded.</summary>
        string DestinationContainer { get; set; }
        /// <summary>The resource id of the storage account where exports will be delivered.</summary>
        string DestinationResourceId { get; set; }
        /// <summary>The name of the directory where exports will be uploaded.</summary>
        string DestinationRootFolderPath { get; set; }
        /// <summary>The details of any error.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IErrorDetails Error { get; set; }
        /// <summary>The type of the export execution.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExecutionType? ExecutionType { get; set; }
        /// <summary>The name of the exported file.</summary>
        string FileName { get; set; }
        /// <summary>Error message indicating why the operation failed.</summary>
        string Message { get; set; }
        /// <summary>The time when the export execution finished.</summary>
        global::System.DateTime? ProcessingEndTime { get; set; }
        /// <summary>The time when export was picked up to be executed.</summary>
        global::System.DateTime? ProcessingStartTime { get; set; }
        /// <summary>A list of export executions.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecution[] RunHistoryValue { get; set; }
        /// <summary>The export settings that were in effect for this execution.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportProperties RunSetting { get; set; }
        /// <summary>Has the definition for the export.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinition RunSettingDefinition { get; set; }
        /// <summary>Has delivery information for the export.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryInfo RunSettingDeliveryInfo { get; set; }
        /// <summary>The format of the export being delivered. Currently only 'Csv' is supported.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.FormatType? RunSettingFormat { get; set; }
        /// <summary>
        /// If the export has an active schedule, provides an estimate of the next execution time.
        /// </summary>
        global::System.DateTime? RunSettingNextRunTimeEstimate { get; set; }
        /// <summary>If requested, has the most recent execution history for the export.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionListResult RunSettingRunHistory { get; set; }
        /// <summary>The last known status of the export execution.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExecutionStatus? Status { get; set; }
        /// <summary>
        /// The identifier for the entity that executed the export. For OnDemand executions it is the user email. For scheduled executions
        /// it is 'System'.
        /// </summary>
        string SubmittedBy { get; set; }
        /// <summary>The time when export was queued to be executed.</summary>
        global::System.DateTime? SubmittedTime { get; set; }
        /// <summary>The start date for export data.</summary>
        global::System.DateTime? TimePeriodFrom { get; set; }
        /// <summary>The end date for export data.</summary>
        global::System.DateTime? TimePeriodTo { get; set; }

    }
}