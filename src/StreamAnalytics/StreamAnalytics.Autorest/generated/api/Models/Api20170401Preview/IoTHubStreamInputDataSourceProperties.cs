namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>The properties that are associated with a IoT Hub input containing stream data.</summary>
    public partial class IoTHubStreamInputDataSourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IIoTHubStreamInputDataSourceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IIoTHubStreamInputDataSourcePropertiesInternal
    {

        /// <summary>Backing field for <see cref="ConsumerGroupName" /> property.</summary>
        private string _consumerGroupName;

        /// <summary>
        /// The name of an IoT Hub Consumer Group that should be used to read events from the IoT Hub. If not specified, the input
        /// uses the Iot Hub’s default consumer group.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string ConsumerGroupName { get => this._consumerGroupName; set => this._consumerGroupName = value; }

        /// <summary>Backing field for <see cref="Endpoint" /> property.</summary>
        private string _endpoint;

        /// <summary>
        /// The IoT Hub endpoint to connect to (ie. messages/events, messages/operationsMonitoringEvents, etc.).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string Endpoint { get => this._endpoint; set => this._endpoint = value; }

        /// <summary>Backing field for <see cref="IotHubNamespace" /> property.</summary>
        private string _iotHubNamespace;

        /// <summary>The name or the URI of the IoT Hub. Required on PUT (CreateOrReplace) requests.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string IotHubNamespace { get => this._iotHubNamespace; set => this._iotHubNamespace = value; }

        /// <summary>Backing field for <see cref="SharedAccessPolicyKey" /> property.</summary>
        private string _sharedAccessPolicyKey;

        /// <summary>
        /// The shared access policy key for the specified shared access policy. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string SharedAccessPolicyKey { get => this._sharedAccessPolicyKey; set => this._sharedAccessPolicyKey = value; }

        /// <summary>Backing field for <see cref="SharedAccessPolicyName" /> property.</summary>
        private string _sharedAccessPolicyName;

        /// <summary>
        /// The shared access policy name for the IoT Hub. This policy must contain at least the Service connect permission. Required
        /// on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string SharedAccessPolicyName { get => this._sharedAccessPolicyName; set => this._sharedAccessPolicyName = value; }

        /// <summary>Creates an new <see cref="IoTHubStreamInputDataSourceProperties" /> instance.</summary>
        public IoTHubStreamInputDataSourceProperties()
        {

        }
    }
    /// The properties that are associated with a IoT Hub input containing stream data.
    public partial interface IIoTHubStreamInputDataSourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable
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
    /// The properties that are associated with a IoT Hub input containing stream data.
    internal partial interface IIoTHubStreamInputDataSourcePropertiesInternal

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