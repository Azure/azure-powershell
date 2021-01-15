namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>An export resource.</summary>
    public partial class Export :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExport,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResource __proxyResource = new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ProxyResource();

        /// <summary>
        /// Array of column names to be included in the export. If not provided then the export will include all available columns.
        /// The available columns can vary by customer channel (see examples).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string[] ConfigurationColumn { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)Property).ConfigurationColumn; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)Property).ConfigurationColumn = value ?? null /* arrayOf */; }

        /// <summary>The granularity of rows in the export. Currently only 'Daily' is supported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType? DataSetGranularity { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)Property).DataSetGranularity; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)Property).DataSetGranularity = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType)""); }

        /// <summary>
        /// The time frame for pulling data for the export. If custom, then a specific time period must be provided.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType? DefinitionTimeframe { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)Property).DefinitionTimeframe; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)Property).DefinitionTimeframe = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType)""); }

        /// <summary>
        /// The type of the export. Note that 'Usage' is equivalent to 'ActualCost' and is applicable to exports that do not yet provide
        /// data for charges or amortization for service reservations.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType? DefinitionType { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)Property).DefinitionType; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)Property).DefinitionType = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType)""); }

        /// <summary>The name of the container where exports will be uploaded.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string DestinationContainer { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)Property).DestinationContainer; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)Property).DestinationContainer = value ?? null; }

        /// <summary>The resource id of the storage account where exports will be delivered.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string DestinationResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)Property).DestinationResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)Property).DestinationResourceId = value ?? null; }

        /// <summary>The name of the directory where exports will be uploaded.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string DestinationRootFolderPath { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)Property).DestinationRootFolderPath; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)Property).DestinationRootFolderPath = value ?? null; }

        /// <summary>
        /// eTag of the resource. To handle concurrent update scenario, this field will be used to determine whether the user is updating
        /// the latest version or not.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inherited)]
        public string ETag { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)__proxyResource).ETag; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)__proxyResource).ETag = value ?? null; }

        /// <summary>The format of the export being delivered. Currently only 'Csv' is supported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.FormatType? Format { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)Property).Format; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)Property).Format = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.FormatType)""); }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)__proxyResource).Id; }

        /// <summary>Internal Acessors for DataSetConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDatasetConfiguration Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal.DataSetConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)Property).DataSetConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)Property).DataSetConfiguration = value; }

        /// <summary>Internal Acessors for Definition</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinition Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal.Definition { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)Property).Definition; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)Property).Definition = value; }

        /// <summary>Internal Acessors for DefinitionDataSet</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDataset Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal.DefinitionDataSet { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)Property).DefinitionDataSet; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)Property).DefinitionDataSet = value; }

        /// <summary>Internal Acessors for DefinitionTimePeriod</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportTimePeriod Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal.DefinitionTimePeriod { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)Property).DefinitionTimePeriod; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)Property).DefinitionTimePeriod = value; }

        /// <summary>Internal Acessors for DeliveryInfo</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryInfo Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal.DeliveryInfo { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)Property).DeliveryInfo; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)Property).DeliveryInfo = value; }

        /// <summary>Internal Acessors for DeliveryInfoDestination</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryDestination Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal.DeliveryInfoDestination { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)Property).DeliveryInfoDestination; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)Property).DeliveryInfoDestination = value; }

        /// <summary>Internal Acessors for NextRunTimeEstimate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal.NextRunTimeEstimate { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)Property).NextRunTimeEstimate; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)Property).NextRunTimeEstimate = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportProperties Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for RunHistory</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionListResult Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal.RunHistory { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)Property).RunHistory; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)Property).RunHistory = value; }

        /// <summary>Internal Acessors for RunHistoryValue</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecution[] Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal.RunHistoryValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)Property).RunHistoryValue; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)Property).RunHistoryValue = value; }

        /// <summary>Internal Acessors for Schedule</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportSchedule Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal.Schedule { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportPropertiesInternal)Property).Schedule; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportPropertiesInternal)Property).Schedule = value; }

        /// <summary>Internal Acessors for ScheduleRecurrencePeriod</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportRecurrencePeriod Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportInternal.ScheduleRecurrencePeriod { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportPropertiesInternal)Property).ScheduleRecurrencePeriod; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportPropertiesInternal)Property).ScheduleRecurrencePeriod = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)__proxyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)__proxyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)__proxyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)__proxyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)__proxyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)__proxyResource).Type = value; }

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)__proxyResource).Name; }

        /// <summary>
        /// If the export has an active schedule, provides an estimate of the next execution time.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public global::System.DateTime? NextRunTimeEstimate { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)Property).NextRunTimeEstimate; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportProperties _property;

        /// <summary>The properties of the export.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportProperties()); set => this._property = value; }

        /// <summary>The start date of recurrence.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public global::System.DateTime? RecurrencePeriodFrom { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportPropertiesInternal)Property).RecurrencePeriodFrom; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportPropertiesInternal)Property).RecurrencePeriodFrom = value ?? default(global::System.DateTime); }

        /// <summary>The end date of recurrence.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public global::System.DateTime? RecurrencePeriodTo { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportPropertiesInternal)Property).RecurrencePeriodTo; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportPropertiesInternal)Property).RecurrencePeriodTo = value ?? default(global::System.DateTime); }

        /// <summary>A list of export executions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecution[] RunHistoryValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)Property).RunHistoryValue; }

        /// <summary>The schedule recurrence.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.RecurrenceType? ScheduleRecurrence { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportPropertiesInternal)Property).ScheduleRecurrence; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportPropertiesInternal)Property).ScheduleRecurrence = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.RecurrenceType)""); }

        /// <summary>
        /// The status of the export's schedule. If 'Inactive', the export's schedule is paused.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.StatusType? ScheduleStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportPropertiesInternal)Property).ScheduleStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportPropertiesInternal)Property).ScheduleStatus = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.StatusType)""); }

        /// <summary>The start date for export data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public global::System.DateTime? TimePeriodFrom { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)Property).TimePeriodFrom; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)Property).TimePeriodFrom = value ?? default(global::System.DateTime); }

        /// <summary>The end date for export data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public global::System.DateTime? TimePeriodTo { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)Property).TimePeriodTo; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)Property).TimePeriodTo = value ?? default(global::System.DateTime); }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal)__proxyResource).Type; }

        /// <summary>Creates an new <see cref="Export" /> instance.</summary>
        public Export()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__proxyResource), __proxyResource);
            await eventListener.AssertObjectIsValid(nameof(__proxyResource), __proxyResource);
        }
    }
    /// An export resource.
    public partial interface IExport :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResource
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
        /// <summary>A list of export executions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A list of export executions.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecution) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecution[] RunHistoryValue { get;  }
        /// <summary>The schedule recurrence.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The schedule recurrence.",
        SerializedName = @"recurrence",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.RecurrenceType) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.RecurrenceType? ScheduleRecurrence { get; set; }
        /// <summary>
        /// The status of the export's schedule. If 'Inactive', the export's schedule is paused.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The status of the export's schedule. If 'Inactive', the export's schedule is paused.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.StatusType) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.StatusType? ScheduleStatus { get; set; }
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
    /// An export resource.
    public partial interface IExportInternal :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IProxyResourceInternal
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
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType? DefinitionTimeframe { get; set; }
        /// <summary>
        /// The type of the export. Note that 'Usage' is equivalent to 'ActualCost' and is applicable to exports that do not yet provide
        /// data for charges or amortization for service reservations.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType? DefinitionType { get; set; }
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
        /// <summary>The properties of the export.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportProperties Property { get; set; }
        /// <summary>The start date of recurrence.</summary>
        global::System.DateTime? RecurrencePeriodFrom { get; set; }
        /// <summary>The end date of recurrence.</summary>
        global::System.DateTime? RecurrencePeriodTo { get; set; }
        /// <summary>If requested, has the most recent execution history for the export.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionListResult RunHistory { get; set; }
        /// <summary>A list of export executions.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecution[] RunHistoryValue { get; set; }
        /// <summary>Has schedule information for the export.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportSchedule Schedule { get; set; }
        /// <summary>The schedule recurrence.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.RecurrenceType? ScheduleRecurrence { get; set; }
        /// <summary>
        /// Has start and end date of the recurrence. The start date must be in future. If present, the end date must be greater than
        /// start date.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportRecurrencePeriod ScheduleRecurrencePeriod { get; set; }
        /// <summary>
        /// The status of the export's schedule. If 'Inactive', the export's schedule is paused.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.StatusType? ScheduleStatus { get; set; }
        /// <summary>The start date for export data.</summary>
        global::System.DateTime? TimePeriodFrom { get; set; }
        /// <summary>The end date for export data.</summary>
        global::System.DateTime? TimePeriodTo { get; set; }

    }
}