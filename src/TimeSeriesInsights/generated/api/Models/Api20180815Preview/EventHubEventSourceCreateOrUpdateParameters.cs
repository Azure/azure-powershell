namespace Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Extensions;

    /// <summary>
    /// Parameters supplied to the Create or Update Event Source operation for an EventHub event source.
    /// </summary>
    public partial class EventHubEventSourceCreateOrUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventHubEventSourceCreateOrUpdateParameters,
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventHubEventSourceCreateOrUpdateParametersInternal,
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventSourceCreateOrUpdateParameters"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventSourceCreateOrUpdateParameters __eventSourceCreateOrUpdateParameters = new Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.EventSourceCreateOrUpdateParameters();

        /// <summary>
        /// The name of the event hub's consumer group that holds the partitions from which events will be read.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public string ConsumerGroupName { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventHubEventSourceCommonPropertiesInternal)Property).ConsumerGroupName; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventHubEventSourceCommonPropertiesInternal)Property).ConsumerGroupName = value; }

        /// <summary>The name of the event hub.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public string EventHubName { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventHubEventSourceCommonPropertiesInternal)Property).EventHubName; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventHubEventSourceCommonPropertiesInternal)Property).EventHubName = value; }

        /// <summary>The resource id of the event source in Azure Resource Manager.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public string EventSourceResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IAzureEventSourcePropertiesInternal)Property).EventSourceResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IAzureEventSourcePropertiesInternal)Property).EventSourceResourceId = value; }

        /// <summary>
        /// The name of the SAS key that grants the Time Series Insights service access to the event hub. The shared access policies
        /// for this key must grant 'Listen' permissions to the event hub.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public string KeyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventHubEventSourceCommonPropertiesInternal)Property).KeyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventHubEventSourceCommonPropertiesInternal)Property).KeyName = value; }

        /// <summary>The kind of the event source.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.Kind Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventSourceCreateOrUpdateParametersInternal)__eventSourceCreateOrUpdateParameters).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventSourceCreateOrUpdateParametersInternal)__eventSourceCreateOrUpdateParameters).Kind = value; }

        /// <summary>The location of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ICreateOrUpdateTrackedResourcePropertiesInternal)__eventSourceCreateOrUpdateParameters).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ICreateOrUpdateTrackedResourcePropertiesInternal)__eventSourceCreateOrUpdateParameters).Location = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventHubEventSourceCreationProperties Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventHubEventSourceCreateOrUpdateParametersInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.EventHubEventSourceCreationProperties()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventHubEventSourceCreationProperties _property;

        /// <summary>
        /// Properties of the EventHub event source that are required on create or update requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventHubEventSourceCreationProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.EventHubEventSourceCreationProperties()); set => this._property = value; }

        /// <summary>The name of the service bus that contains the event hub.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public string ServiceBusNamespace { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventHubEventSourceCommonPropertiesInternal)Property).ServiceBusNamespace; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventHubEventSourceCommonPropertiesInternal)Property).ServiceBusNamespace = value; }

        /// <summary>
        /// The value of the shared access key that grants the Time Series Insights service read access to the event hub. This property
        /// is not shown in event source responses.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public string SharedAccessKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventHubEventSourceCreationPropertiesInternal)Property).SharedAccessKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventHubEventSourceCreationPropertiesInternal)Property).SharedAccessKey = value; }

        /// <summary>Key-value pairs of additional properties for the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ICreateOrUpdateTrackedResourcePropertiesTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ICreateOrUpdateTrackedResourcePropertiesInternal)__eventSourceCreateOrUpdateParameters).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ICreateOrUpdateTrackedResourcePropertiesInternal)__eventSourceCreateOrUpdateParameters).Tag = value; }

        /// <summary>
        /// The event property that will be used as the event source's timestamp. If a value isn't specified for timestampPropertyName,
        /// or if null or empty-string is specified, the event creation time will be used.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public string TimestampPropertyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventSourceCommonPropertiesInternal)Property).TimestampPropertyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventSourceCommonPropertiesInternal)Property).TimestampPropertyName = value; }

        /// <summary>
        /// Creates an new <see cref="EventHubEventSourceCreateOrUpdateParameters" /> instance.
        /// </summary>
        public EventHubEventSourceCreateOrUpdateParameters()
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
            await eventListener.AssertNotNull(nameof(__eventSourceCreateOrUpdateParameters), __eventSourceCreateOrUpdateParameters);
            await eventListener.AssertObjectIsValid(nameof(__eventSourceCreateOrUpdateParameters), __eventSourceCreateOrUpdateParameters);
        }
    }
    /// Parameters supplied to the Create or Update Event Source operation for an EventHub event source.
    public partial interface IEventHubEventSourceCreateOrUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventSourceCreateOrUpdateParameters
    {
        /// <summary>
        /// The name of the event hub's consumer group that holds the partitions from which events will be read.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the event hub's consumer group that holds the partitions from which events will be read.",
        SerializedName = @"consumerGroupName",
        PossibleTypes = new [] { typeof(string) })]
        string ConsumerGroupName { get; set; }
        /// <summary>The name of the event hub.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the event hub.",
        SerializedName = @"eventHubName",
        PossibleTypes = new [] { typeof(string) })]
        string EventHubName { get; set; }
        /// <summary>The resource id of the event source in Azure Resource Manager.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The resource id of the event source in Azure Resource Manager.",
        SerializedName = @"eventSourceResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string EventSourceResourceId { get; set; }
        /// <summary>
        /// The name of the SAS key that grants the Time Series Insights service access to the event hub. The shared access policies
        /// for this key must grant 'Listen' permissions to the event hub.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the SAS key that grants the Time Series Insights service access to the event hub. The shared access policies for this key must grant 'Listen' permissions to the event hub.",
        SerializedName = @"keyName",
        PossibleTypes = new [] { typeof(string) })]
        string KeyName { get; set; }
        /// <summary>The name of the service bus that contains the event hub.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the service bus that contains the event hub.",
        SerializedName = @"serviceBusNamespace",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceBusNamespace { get; set; }
        /// <summary>
        /// The value of the shared access key that grants the Time Series Insights service read access to the event hub. This property
        /// is not shown in event source responses.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The value of the shared access key that grants the Time Series Insights service read access to the event hub. This property is not shown in event source responses.",
        SerializedName = @"sharedAccessKey",
        PossibleTypes = new [] { typeof(string) })]
        string SharedAccessKey { get; set; }
        /// <summary>
        /// The event property that will be used as the event source's timestamp. If a value isn't specified for timestampPropertyName,
        /// or if null or empty-string is specified, the event creation time will be used.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The event property that will be used as the event source's timestamp. If a value isn't specified for timestampPropertyName, or if null or empty-string is specified, the event creation time will be used.",
        SerializedName = @"timestampPropertyName",
        PossibleTypes = new [] { typeof(string) })]
        string TimestampPropertyName { get; set; }

    }
    /// Parameters supplied to the Create or Update Event Source operation for an EventHub event source.
    internal partial interface IEventHubEventSourceCreateOrUpdateParametersInternal :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventSourceCreateOrUpdateParametersInternal
    {
        /// <summary>
        /// The name of the event hub's consumer group that holds the partitions from which events will be read.
        /// </summary>
        string ConsumerGroupName { get; set; }
        /// <summary>The name of the event hub.</summary>
        string EventHubName { get; set; }
        /// <summary>The resource id of the event source in Azure Resource Manager.</summary>
        string EventSourceResourceId { get; set; }
        /// <summary>
        /// The name of the SAS key that grants the Time Series Insights service access to the event hub. The shared access policies
        /// for this key must grant 'Listen' permissions to the event hub.
        /// </summary>
        string KeyName { get; set; }
        /// <summary>
        /// Properties of the EventHub event source that are required on create or update requests.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventHubEventSourceCreationProperties Property { get; set; }
        /// <summary>The name of the service bus that contains the event hub.</summary>
        string ServiceBusNamespace { get; set; }
        /// <summary>
        /// The value of the shared access key that grants the Time Series Insights service read access to the event hub. This property
        /// is not shown in event source responses.
        /// </summary>
        string SharedAccessKey { get; set; }
        /// <summary>
        /// The event property that will be used as the event source's timestamp. If a value isn't specified for timestampPropertyName,
        /// or if null or empty-string is specified, the event creation time will be used.
        /// </summary>
        string TimestampPropertyName { get; set; }

    }
}