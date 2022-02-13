namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>The properties of the export.</summary>
    public partial class ExportProperties :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportProperties,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportPropertiesInternal,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportProperties"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportProperties __commonExportProperties = new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.CommonExportProperties();

        /// <summary>
        /// Array of column names to be included in the export. If not provided then the export will include all available columns.
        /// The available columns can vary by customer channel (see examples).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inherited)]
        public string[] ConfigurationColumn { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)__commonExportProperties).ConfigurationColumn; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)__commonExportProperties).ConfigurationColumn = value ?? null /* arrayOf */; }

        /// <summary>The export dataset configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDatasetConfiguration DataSetConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)__commonExportProperties).DataSetConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)__commonExportProperties).DataSetConfiguration = value ?? null /* model class */; }

        /// <summary>The granularity of rows in the export. Currently only 'Daily' is supported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType? DataSetGranularity { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)__commonExportProperties).DataSetGranularity; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)__commonExportProperties).DataSetGranularity = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType)""); }

        /// <summary>Has the definition for the export.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDefinition Definition { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)__commonExportProperties).Definition; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)__commonExportProperties).Definition = value ; }

        /// <summary>The definition for data in the export.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDataset DefinitionDataSet { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)__commonExportProperties).DefinitionDataSet; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)__commonExportProperties).DefinitionDataSet = value ?? null /* model class */; }

        /// <summary>Has time period for pulling data for the export.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportTimePeriod DefinitionTimePeriod { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)__commonExportProperties).DefinitionTimePeriod; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)__commonExportProperties).DefinitionTimePeriod = value ?? null /* model class */; }

        /// <summary>
        /// The time frame for pulling data for the export. If custom, then a specific time period must be provided.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.TimeframeType DefinitionTimeframe { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)__commonExportProperties).DefinitionTimeframe; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)__commonExportProperties).DefinitionTimeframe = value ; }

        /// <summary>
        /// The type of the export. Note that 'Usage' is equivalent to 'ActualCost' and is applicable to exports that do not yet provide
        /// data for charges or amortization for service reservations.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ExportType DefinitionType { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)__commonExportProperties).DefinitionType; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)__commonExportProperties).DefinitionType = value ; }

        /// <summary>Has delivery information for the export.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryInfo DeliveryInfo { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)__commonExportProperties).DeliveryInfo; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)__commonExportProperties).DeliveryInfo = value ; }

        /// <summary>Has destination for the export being delivered.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDeliveryDestination DeliveryInfoDestination { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)__commonExportProperties).DeliveryInfoDestination; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)__commonExportProperties).DeliveryInfoDestination = value ; }

        /// <summary>The name of the container where exports will be uploaded.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inherited)]
        public string DestinationContainer { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)__commonExportProperties).DestinationContainer; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)__commonExportProperties).DestinationContainer = value ; }

        /// <summary>The resource id of the storage account where exports will be delivered.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inherited)]
        public string DestinationResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)__commonExportProperties).DestinationResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)__commonExportProperties).DestinationResourceId = value ; }

        /// <summary>The name of the directory where exports will be uploaded.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inherited)]
        public string DestinationRootFolderPath { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)__commonExportProperties).DestinationRootFolderPath; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)__commonExportProperties).DestinationRootFolderPath = value ?? null; }

        /// <summary>The format of the export being delivered. Currently only 'Csv' is supported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.FormatType? Format { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)__commonExportProperties).Format; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)__commonExportProperties).Format = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.FormatType)""); }

        /// <summary>Internal Acessors for NextRunTimeEstimate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal.NextRunTimeEstimate { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)__commonExportProperties).NextRunTimeEstimate; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)__commonExportProperties).NextRunTimeEstimate = value; }

        /// <summary>Internal Acessors for RunHistoryValue</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecution[] Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal.RunHistoryValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)__commonExportProperties).RunHistoryValue; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)__commonExportProperties).RunHistoryValue = value; }

        /// <summary>Internal Acessors for Schedule</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportSchedule Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportPropertiesInternal.Schedule { get => (this._schedule = this._schedule ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportSchedule()); set { {_schedule = value;} } }

        /// <summary>Internal Acessors for ScheduleRecurrencePeriod</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportRecurrencePeriod Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportPropertiesInternal.ScheduleRecurrencePeriod { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportScheduleInternal)Schedule).RecurrencePeriod; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportScheduleInternal)Schedule).RecurrencePeriod = value; }

        /// <summary>
        /// If the export has an active schedule, provides an estimate of the next execution time.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inherited)]
        public global::System.DateTime? NextRunTimeEstimate { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)__commonExportProperties).NextRunTimeEstimate; }

        /// <summary>The start date of recurrence.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public global::System.DateTime? RecurrencePeriodFrom { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportScheduleInternal)Schedule).RecurrencePeriodFrom; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportScheduleInternal)Schedule).RecurrencePeriodFrom = value ?? default(global::System.DateTime); }

        /// <summary>The end date of recurrence.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public global::System.DateTime? RecurrencePeriodTo { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportScheduleInternal)Schedule).RecurrencePeriodTo; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportScheduleInternal)Schedule).RecurrencePeriodTo = value ?? default(global::System.DateTime); }

        /// <summary>If requested, has the most recent execution history for the export.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecutionListResult RunHistory { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)__commonExportProperties).RunHistory; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)__commonExportProperties).RunHistory = value ?? null /* model class */; }

        /// <summary>A list of export executions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportExecution[] RunHistoryValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)__commonExportProperties).RunHistoryValue; }

        /// <summary>Backing field for <see cref="Schedule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportSchedule _schedule;

        /// <summary>Has schedule information for the export.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportSchedule Schedule { get => (this._schedule = this._schedule ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportSchedule()); set => this._schedule = value; }

        /// <summary>The schedule recurrence.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.RecurrenceType? ScheduleRecurrence { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportScheduleInternal)Schedule).Recurrence; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportScheduleInternal)Schedule).Recurrence = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.RecurrenceType)""); }

        /// <summary>
        /// The status of the export's schedule. If 'Inactive', the export's schedule is paused.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.StatusType? ScheduleStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportScheduleInternal)Schedule).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportScheduleInternal)Schedule).Status = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.StatusType)""); }

        /// <summary>The start date for export data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inherited)]
        public global::System.DateTime? TimePeriodFrom { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)__commonExportProperties).TimePeriodFrom; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)__commonExportProperties).TimePeriodFrom = value ?? default(global::System.DateTime); }

        /// <summary>The end date for export data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inherited)]
        public global::System.DateTime? TimePeriodTo { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)__commonExportProperties).TimePeriodTo; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal)__commonExportProperties).TimePeriodTo = value ?? default(global::System.DateTime); }

        /// <summary>Creates an new <see cref="ExportProperties" /> instance.</summary>
        public ExportProperties()
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
            await eventListener.AssertNotNull(nameof(__commonExportProperties), __commonExportProperties);
            await eventListener.AssertObjectIsValid(nameof(__commonExportProperties), __commonExportProperties);
        }
    }
    /// The properties of the export.
    public partial interface IExportProperties :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportProperties
    {
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

    }
    /// The properties of the export.
    public partial interface IExportPropertiesInternal :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ICommonExportPropertiesInternal
    {
        /// <summary>The start date of recurrence.</summary>
        global::System.DateTime? RecurrencePeriodFrom { get; set; }
        /// <summary>The end date of recurrence.</summary>
        global::System.DateTime? RecurrencePeriodTo { get; set; }
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

    }
}