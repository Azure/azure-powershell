namespace Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Extensions;

    /// <summary>
    /// Properties of the EventHub event source that are required on create or update requests.
    /// </summary>
    public partial class EventHubEventSourceCreationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventHubEventSourceCreationProperties,
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventHubEventSourceCreationPropertiesInternal,
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventHubEventSourceCommonProperties"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventHubEventSourceCommonProperties __eventHubEventSourceCommonProperties = new Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.EventHubEventSourceCommonProperties();

        /// <summary>
        /// The name of the event hub's consumer group that holds the partitions from which events will be read.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inherited)]
        public string ConsumerGroupName { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventHubEventSourceCommonPropertiesInternal)__eventHubEventSourceCommonProperties).ConsumerGroupName; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventHubEventSourceCommonPropertiesInternal)__eventHubEventSourceCommonProperties).ConsumerGroupName = value; }

        /// <summary>The name of the event hub.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inherited)]
        public string EventHubName { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventHubEventSourceCommonPropertiesInternal)__eventHubEventSourceCommonProperties).EventHubName; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventHubEventSourceCommonPropertiesInternal)__eventHubEventSourceCommonProperties).EventHubName = value; }

        /// <summary>The resource id of the event source in Azure Resource Manager.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inherited)]
        public string EventSourceResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IAzureEventSourcePropertiesInternal)__eventHubEventSourceCommonProperties).EventSourceResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IAzureEventSourcePropertiesInternal)__eventHubEventSourceCommonProperties).EventSourceResourceId = value; }

        /// <summary>
        /// The name of the SAS key that grants the Time Series Insights service access to the event hub. The shared access policies
        /// for this key must grant 'Listen' permissions to the event hub.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inherited)]
        public string KeyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventHubEventSourceCommonPropertiesInternal)__eventHubEventSourceCommonProperties).KeyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventHubEventSourceCommonPropertiesInternal)__eventHubEventSourceCommonProperties).KeyName = value; }

        /// <summary>The name of the service bus that contains the event hub.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inherited)]
        public string ServiceBusNamespace { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventHubEventSourceCommonPropertiesInternal)__eventHubEventSourceCommonProperties).ServiceBusNamespace; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventHubEventSourceCommonPropertiesInternal)__eventHubEventSourceCommonProperties).ServiceBusNamespace = value; }

        /// <summary>Backing field for <see cref="SharedAccessKey" /> property.</summary>
        private string _sharedAccessKey;

        /// <summary>
        /// The value of the shared access key that grants the Time Series Insights service read access to the event hub. This property
        /// is not shown in event source responses.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Owned)]
        public string SharedAccessKey { get => this._sharedAccessKey; set => this._sharedAccessKey = value; }

        /// <summary>
        /// The event property that will be used as the event source's timestamp. If a value isn't specified for timestampPropertyName,
        /// or if null or empty-string is specified, the event creation time will be used.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inherited)]
        public string TimestampPropertyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventSourceCommonPropertiesInternal)__eventHubEventSourceCommonProperties).TimestampPropertyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventSourceCommonPropertiesInternal)__eventHubEventSourceCommonProperties).TimestampPropertyName = value; }

        /// <summary>Creates an new <see cref="EventHubEventSourceCreationProperties" /> instance.</summary>
        public EventHubEventSourceCreationProperties()
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
            await eventListener.AssertNotNull(nameof(__eventHubEventSourceCommonProperties), __eventHubEventSourceCommonProperties);
            await eventListener.AssertObjectIsValid(nameof(__eventHubEventSourceCommonProperties), __eventHubEventSourceCommonProperties);
        }
    }
    /// Properties of the EventHub event source that are required on create or update requests.
    public partial interface IEventHubEventSourceCreationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventHubEventSourceCommonProperties
    {
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

    }
    /// Properties of the EventHub event source that are required on create or update requests.
    internal partial interface IEventHubEventSourceCreationPropertiesInternal :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEventHubEventSourceCommonPropertiesInternal
    {
        /// <summary>
        /// The value of the shared access key that grants the Time Series Insights service read access to the event hub. This property
        /// is not shown in event source responses.
        /// </summary>
        string SharedAccessKey { get; set; }

    }
}