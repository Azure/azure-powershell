namespace Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515
{
    using static Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Extensions;

    /// <summary>Parameters supplied to the Create or Update Event Source operation.</summary>
    public partial class EventSourceCreateOrUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEventSourceCreateOrUpdateParameters,
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEventSourceCreateOrUpdateParametersInternal,
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ICreateOrUpdateTrackedResourceProperties"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ICreateOrUpdateTrackedResourceProperties __createOrUpdateTrackedResourceProperties = new Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.CreateOrUpdateTrackedResourceProperties();

        /// <summary>Backing field for <see cref="Kind" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.Kind _kind;

        /// <summary>The kind of the event source.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.Kind Kind { get => this._kind; set => this._kind = value; }

        /// <summary>Backing field for <see cref="LocalTimestamp" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ILocalTimestamp _localTimestamp;

        /// <summary>
        /// An object that represents the local timestamp property. It contains the format of local timestamp that needs to be used
        /// and the corresponding timezone offset information. If a value isn't specified for localTimestamp, or if null, then the
        /// local timestamp will not be ingressed with the events.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ILocalTimestamp LocalTimestamp { get => (this._localTimestamp = this._localTimestamp ?? new Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.LocalTimestamp()); set => this._localTimestamp = value; }

        /// <summary>
        /// An enum that represents the format of the local timestamp property that needs to be set.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.LocalTimestampFormat? LocalTimestampFormat { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ILocalTimestampInternal)LocalTimestamp).Format; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ILocalTimestampInternal)LocalTimestamp).Format = value; }

        /// <summary>The location of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ICreateOrUpdateTrackedResourcePropertiesInternal)__createOrUpdateTrackedResourceProperties).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ICreateOrUpdateTrackedResourcePropertiesInternal)__createOrUpdateTrackedResourceProperties).Location = value; }

        /// <summary>Internal Acessors for LocalTimestamp</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ILocalTimestamp Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEventSourceCreateOrUpdateParametersInternal.LocalTimestamp { get => (this._localTimestamp = this._localTimestamp ?? new Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.LocalTimestamp()); set { {_localTimestamp = value;} } }

        /// <summary>Internal Acessors for LocalTimestampTimeZoneOffset</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ILocalTimestampTimeZoneOffset Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEventSourceCreateOrUpdateParametersInternal.LocalTimestampTimeZoneOffset { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ILocalTimestampInternal)LocalTimestamp).TimeZoneOffset; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ILocalTimestampInternal)LocalTimestamp).TimeZoneOffset = value; }

        /// <summary>Key-value pairs of additional properties for the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ICreateOrUpdateTrackedResourcePropertiesTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ICreateOrUpdateTrackedResourcePropertiesInternal)__createOrUpdateTrackedResourceProperties).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ICreateOrUpdateTrackedResourcePropertiesInternal)__createOrUpdateTrackedResourceProperties).Tag = value; }

        /// <summary>
        /// The event property that will be contain the offset information to calculate the local timestamp. When the LocalTimestampFormat
        /// is Iana, the property name will contain the name of the column which contains IANA Timezone Name (eg: Americas/Los Angeles).
        /// When LocalTimestampFormat is Timespan, it contains the name of property which contains values representing the offset
        /// (eg: P1D or 1.00:00:00)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public string TimeZoneOffsetPropertyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ILocalTimestampInternal)LocalTimestamp).TimeZoneOffsetPropertyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ILocalTimestampInternal)LocalTimestamp).TimeZoneOffsetPropertyName = value; }

        /// <summary>Creates an new <see cref="EventSourceCreateOrUpdateParameters" /> instance.</summary>
        public EventSourceCreateOrUpdateParameters()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__createOrUpdateTrackedResourceProperties), __createOrUpdateTrackedResourceProperties);
            await eventListener.AssertObjectIsValid(nameof(__createOrUpdateTrackedResourceProperties), __createOrUpdateTrackedResourceProperties);
        }
    }
    /// Parameters supplied to the Create or Update Event Source operation.
    public partial interface IEventSourceCreateOrUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ICreateOrUpdateTrackedResourceProperties
    {
        /// <summary>The kind of the event source.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The kind of the event source.",
        SerializedName = @"kind",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.Kind) })]
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.Kind Kind { get; set; }
        /// <summary>
        /// An enum that represents the format of the local timestamp property that needs to be set.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"An enum that represents the format of the local timestamp property that needs to be set.",
        SerializedName = @"format",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.LocalTimestampFormat) })]
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.LocalTimestampFormat? LocalTimestampFormat { get; set; }
        /// <summary>
        /// The event property that will be contain the offset information to calculate the local timestamp. When the LocalTimestampFormat
        /// is Iana, the property name will contain the name of the column which contains IANA Timezone Name (eg: Americas/Los Angeles).
        /// When LocalTimestampFormat is Timespan, it contains the name of property which contains values representing the offset
        /// (eg: P1D or 1.00:00:00)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The event property that will be contain the offset information to calculate the local timestamp. When the LocalTimestampFormat is Iana, the property name will contain the name of the column which contains IANA Timezone Name (eg: Americas/Los Angeles). When LocalTimestampFormat is Timespan, it contains the name of property which contains values representing the offset (eg: P1D or 1.00:00:00)",
        SerializedName = @"propertyName",
        PossibleTypes = new [] { typeof(string) })]
        string TimeZoneOffsetPropertyName { get; set; }

    }
    /// Parameters supplied to the Create or Update Event Source operation.
    internal partial interface IEventSourceCreateOrUpdateParametersInternal :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ICreateOrUpdateTrackedResourcePropertiesInternal
    {
        /// <summary>The kind of the event source.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.Kind Kind { get; set; }
        /// <summary>
        /// An object that represents the local timestamp property. It contains the format of local timestamp that needs to be used
        /// and the corresponding timezone offset information. If a value isn't specified for localTimestamp, or if null, then the
        /// local timestamp will not be ingressed with the events.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ILocalTimestamp LocalTimestamp { get; set; }
        /// <summary>
        /// An enum that represents the format of the local timestamp property that needs to be set.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.LocalTimestampFormat? LocalTimestampFormat { get; set; }
        /// <summary>
        /// An object that represents the offset information for the local timestamp format specified. Should not be specified for
        /// LocalTimestampFormat - Embedded.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ILocalTimestampTimeZoneOffset LocalTimestampTimeZoneOffset { get; set; }
        /// <summary>
        /// The event property that will be contain the offset information to calculate the local timestamp. When the LocalTimestampFormat
        /// is Iana, the property name will contain the name of the column which contains IANA Timezone Name (eg: Americas/Los Angeles).
        /// When LocalTimestampFormat is Timespan, it contains the name of property which contains values representing the offset
        /// (eg: P1D or 1.00:00:00)
        /// </summary>
        string TimeZoneOffsetPropertyName { get; set; }

    }
}