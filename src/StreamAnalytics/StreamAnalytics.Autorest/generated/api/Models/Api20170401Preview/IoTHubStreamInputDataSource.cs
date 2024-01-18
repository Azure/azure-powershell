namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>Describes an IoT Hub input data source that contains stream data.</summary>
    public partial class IoTHubStreamInputDataSource :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IIoTHubStreamInputDataSource,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IIoTHubStreamInputDataSourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamInputDataSource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamInputDataSource __streamInputDataSource = new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.StreamInputDataSource();

        /// <summary>
        /// The name of an IoT Hub Consumer Group that should be used to read events from the IoT Hub. If not specified, the input
        /// uses the Iot Hub’s default consumer group.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string ConsumerGroupName { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IIoTHubStreamInputDataSourcePropertiesInternal)Property).ConsumerGroupName; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IIoTHubStreamInputDataSourcePropertiesInternal)Property).ConsumerGroupName = value ?? null; }

        /// <summary>
        /// The IoT Hub endpoint to connect to (ie. messages/events, messages/operationsMonitoringEvents, etc.).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string Endpoint { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IIoTHubStreamInputDataSourcePropertiesInternal)Property).Endpoint; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IIoTHubStreamInputDataSourcePropertiesInternal)Property).Endpoint = value ?? null; }

        /// <summary>The name or the URI of the IoT Hub. Required on PUT (CreateOrReplace) requests.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string IotHubNamespace { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IIoTHubStreamInputDataSourcePropertiesInternal)Property).IotHubNamespace; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IIoTHubStreamInputDataSourcePropertiesInternal)Property).IotHubNamespace = value ?? null; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IIoTHubStreamInputDataSourceProperties Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IIoTHubStreamInputDataSourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IoTHubStreamInputDataSourceProperties()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IIoTHubStreamInputDataSourceProperties _property;

        /// <summary>
        /// The properties that are associated with an IoT Hub input containing stream data. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IIoTHubStreamInputDataSourceProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IoTHubStreamInputDataSourceProperties()); set => this._property = value; }

        /// <summary>
        /// The shared access policy key for the specified shared access policy. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string SharedAccessPolicyKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IIoTHubStreamInputDataSourcePropertiesInternal)Property).SharedAccessPolicyKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IIoTHubStreamInputDataSourcePropertiesInternal)Property).SharedAccessPolicyKey = value ?? null; }

        /// <summary>
        /// The shared access policy name for the IoT Hub. This policy must contain at least the Service connect permission. Required
        /// on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string SharedAccessPolicyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IIoTHubStreamInputDataSourcePropertiesInternal)Property).SharedAccessPolicyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IIoTHubStreamInputDataSourcePropertiesInternal)Property).SharedAccessPolicyName = value ?? null; }

        /// <summary>
        /// Indicates the type of input data source containing stream data. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamInputDataSourceInternal)__streamInputDataSource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamInputDataSourceInternal)__streamInputDataSource).Type = value ; }

        /// <summary>Creates an new <see cref="IoTHubStreamInputDataSource" /> instance.</summary>
        public IoTHubStreamInputDataSource()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__streamInputDataSource), __streamInputDataSource);
            await eventListener.AssertObjectIsValid(nameof(__streamInputDataSource), __streamInputDataSource);
        }
    }
    /// Describes an IoT Hub input data source that contains stream data.
    public partial interface IIoTHubStreamInputDataSource :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamInputDataSource
    {
        /// <summary>
        /// The name of an IoT Hub Consumer Group that should be used to read events from the IoT Hub. If not specified, the input
        /// uses the Iot Hub’s default consumer group.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of an IoT Hub Consumer Group that should be used to read events from the IoT Hub. If not specified, the input uses the Iot Hub’s default consumer group.",
        SerializedName = @"consumerGroupName",
        PossibleTypes = new [] { typeof(string) })]
        string ConsumerGroupName { get; set; }
        /// <summary>
        /// The IoT Hub endpoint to connect to (ie. messages/events, messages/operationsMonitoringEvents, etc.).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The IoT Hub endpoint to connect to (ie. messages/events, messages/operationsMonitoringEvents, etc.).",
        SerializedName = @"endpoint",
        PossibleTypes = new [] { typeof(string) })]
        string Endpoint { get; set; }
        /// <summary>The name or the URI of the IoT Hub. Required on PUT (CreateOrReplace) requests.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name or the URI of the IoT Hub. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"iotHubNamespace",
        PossibleTypes = new [] { typeof(string) })]
        string IotHubNamespace { get; set; }
        /// <summary>
        /// The shared access policy key for the specified shared access policy. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The shared access policy key for the specified shared access policy. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"sharedAccessPolicyKey",
        PossibleTypes = new [] { typeof(string) })]
        string SharedAccessPolicyKey { get; set; }
        /// <summary>
        /// The shared access policy name for the IoT Hub. This policy must contain at least the Service connect permission. Required
        /// on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The shared access policy name for the IoT Hub. This policy must contain at least the Service connect permission. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"sharedAccessPolicyName",
        PossibleTypes = new [] { typeof(string) })]
        string SharedAccessPolicyName { get; set; }

    }
    /// Describes an IoT Hub input data source that contains stream data.
    internal partial interface IIoTHubStreamInputDataSourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamInputDataSourceInternal
    {
        /// <summary>
        /// The name of an IoT Hub Consumer Group that should be used to read events from the IoT Hub. If not specified, the input
        /// uses the Iot Hub’s default consumer group.
        /// </summary>
        string ConsumerGroupName { get; set; }
        /// <summary>
        /// The IoT Hub endpoint to connect to (ie. messages/events, messages/operationsMonitoringEvents, etc.).
        /// </summary>
        string Endpoint { get; set; }
        /// <summary>The name or the URI of the IoT Hub. Required on PUT (CreateOrReplace) requests.</summary>
        string IotHubNamespace { get; set; }
        /// <summary>
        /// The properties that are associated with an IoT Hub input containing stream data. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IIoTHubStreamInputDataSourceProperties Property { get; set; }
        /// <summary>
        /// The shared access policy key for the specified shared access policy. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        string SharedAccessPolicyKey { get; set; }
        /// <summary>
        /// The shared access policy name for the IoT Hub. This policy must contain at least the Service connect permission. Required
        /// on PUT (CreateOrReplace) requests.
        /// </summary>
        string SharedAccessPolicyName { get; set; }

    }
}