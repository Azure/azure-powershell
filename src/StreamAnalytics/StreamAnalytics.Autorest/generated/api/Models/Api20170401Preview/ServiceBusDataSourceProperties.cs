namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>
    /// The common properties that are associated with Service Bus data sources (Queues, Topics, Event Hubs, etc.).
    /// </summary>
    public partial class ServiceBusDataSourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusDataSourceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusDataSourcePropertiesInternal
    {

        /// <summary>Backing field for <see cref="AuthenticationMode" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode? _authenticationMode;

        /// <summary>Authentication Mode.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode? AuthenticationMode { get => this._authenticationMode; set => this._authenticationMode = value; }

        /// <summary>Backing field for <see cref="ServiceBusNamespace" /> property.</summary>
        private string _serviceBusNamespace;

        /// <summary>
        /// The namespace that is associated with the desired Event Hub, Service Bus Queue, Service Bus Topic, etc. Required on PUT
        /// (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string ServiceBusNamespace { get => this._serviceBusNamespace; set => this._serviceBusNamespace = value; }

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
        /// The shared access policy name for the Event Hub, Service Bus Queue, Service Bus Topic, etc. Required on PUT (CreateOrReplace)
        /// requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string SharedAccessPolicyName { get => this._sharedAccessPolicyName; set => this._sharedAccessPolicyName = value; }

        /// <summary>Creates an new <see cref="ServiceBusDataSourceProperties" /> instance.</summary>
        public ServiceBusDataSourceProperties()
        {

        }
    }
    /// The common properties that are associated with Service Bus data sources (Queues, Topics, Event Hubs, etc.).
    public partial interface IServiceBusDataSourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable
    {
        /// <summary>Authentication Mode.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Authentication Mode.",
        SerializedName = @"authenticationMode",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode? AuthenticationMode { get; set; }
        /// <summary>
        /// The namespace that is associated with the desired Event Hub, Service Bus Queue, Service Bus Topic, etc. Required on PUT
        /// (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The namespace that is associated with the desired Event Hub, Service Bus Queue, Service Bus Topic, etc. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"serviceBusNamespace",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceBusNamespace { get; set; }
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
        /// The shared access policy name for the Event Hub, Service Bus Queue, Service Bus Topic, etc. Required on PUT (CreateOrReplace)
        /// requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The shared access policy name for the Event Hub, Service Bus Queue, Service Bus Topic, etc. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"sharedAccessPolicyName",
        PossibleTypes = new [] { typeof(string) })]
        string SharedAccessPolicyName { get; set; }

    }
    /// The common properties that are associated with Service Bus data sources (Queues, Topics, Event Hubs, etc.).
    internal partial interface IServiceBusDataSourcePropertiesInternal

    {
        /// <summary>Authentication Mode.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode? AuthenticationMode { get; set; }
        /// <summary>
        /// The namespace that is associated with the desired Event Hub, Service Bus Queue, Service Bus Topic, etc. Required on PUT
        /// (CreateOrReplace) requests.
        /// </summary>
        string ServiceBusNamespace { get; set; }
        /// <summary>
        /// The shared access policy key for the specified shared access policy. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        string SharedAccessPolicyKey { get; set; }
        /// <summary>
        /// The shared access policy name for the Event Hub, Service Bus Queue, Service Bus Topic, etc. Required on PUT (CreateOrReplace)
        /// requests.
        /// </summary>
        string SharedAccessPolicyName { get; set; }

    }
}