namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>Describes a Service Bus Queue output data source.</summary>
    public partial class ServiceBusQueueOutputDataSource :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusQueueOutputDataSource,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusQueueOutputDataSourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSource __outputDataSource = new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.OutputDataSource();

        /// <summary>Authentication Mode.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode? AuthenticationMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusDataSourcePropertiesInternal)Property).AuthenticationMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusDataSourcePropertiesInternal)Property).AuthenticationMode = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode)""); }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusQueueOutputDataSourceProperties Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusQueueOutputDataSourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ServiceBusQueueOutputDataSourceProperties()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusQueueOutputDataSourceProperties _property;

        /// <summary>
        /// The properties that are associated with a Service Bus Queue output. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusQueueOutputDataSourceProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ServiceBusQueueOutputDataSourceProperties()); set => this._property = value; }

        /// <summary>
        /// A string array of the names of output columns to be attached to Service Bus messages as custom properties.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string[] PropertyColumn { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusQueueOutputDataSourcePropertiesInternal)Property).PropertyColumn; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusQueueOutputDataSourcePropertiesInternal)Property).PropertyColumn = value ?? null /* arrayOf */; }

        /// <summary>The name of the Service Bus Queue. Required on PUT (CreateOrReplace) requests.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string QueueName { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusQueueOutputDataSourcePropertiesInternal)Property).QueueName; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusQueueOutputDataSourcePropertiesInternal)Property).QueueName = value ?? null; }

        /// <summary>
        /// The namespace that is associated with the desired Event Hub, Service Bus Queue, Service Bus Topic, etc. Required on PUT
        /// (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string ServiceBusNamespace { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusDataSourcePropertiesInternal)Property).ServiceBusNamespace; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusDataSourcePropertiesInternal)Property).ServiceBusNamespace = value ?? null; }

        /// <summary>
        /// The shared access policy key for the specified shared access policy. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string SharedAccessPolicyKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusDataSourcePropertiesInternal)Property).SharedAccessPolicyKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusDataSourcePropertiesInternal)Property).SharedAccessPolicyKey = value ?? null; }

        /// <summary>
        /// The shared access policy name for the Event Hub, Service Bus Queue, Service Bus Topic, etc. Required on PUT (CreateOrReplace)
        /// requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string SharedAccessPolicyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusDataSourcePropertiesInternal)Property).SharedAccessPolicyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusDataSourcePropertiesInternal)Property).SharedAccessPolicyName = value ?? null; }

        /// <summary>Dictionary of <string></summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusQueueOutputDataSourcePropertiesSystemPropertyColumns SystemPropertyColumn { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusQueueOutputDataSourcePropertiesInternal)Property).SystemPropertyColumn; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusQueueOutputDataSourcePropertiesInternal)Property).SystemPropertyColumn = value ?? null /* model class */; }

        /// <summary>
        /// Indicates the type of data source output will be written to. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSourceInternal)__outputDataSource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSourceInternal)__outputDataSource).Type = value ; }

        /// <summary>Creates an new <see cref="ServiceBusQueueOutputDataSource" /> instance.</summary>
        public ServiceBusQueueOutputDataSource()
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
            await eventListener.AssertNotNull(nameof(__outputDataSource), __outputDataSource);
            await eventListener.AssertObjectIsValid(nameof(__outputDataSource), __outputDataSource);
        }
    }
    /// Describes a Service Bus Queue output data source.
    public partial interface IServiceBusQueueOutputDataSource :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSource
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
        /// A string array of the names of output columns to be attached to Service Bus messages as custom properties.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A string array of the names of output columns to be attached to Service Bus messages as custom properties.",
        SerializedName = @"propertyColumns",
        PossibleTypes = new [] { typeof(string) })]
        string[] PropertyColumn { get; set; }
        /// <summary>The name of the Service Bus Queue. Required on PUT (CreateOrReplace) requests.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the Service Bus Queue. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"queueName",
        PossibleTypes = new [] { typeof(string) })]
        string QueueName { get; set; }
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
        /// <summary>Dictionary of <string></summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Dictionary of <string>",
        SerializedName = @"systemPropertyColumns",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusQueueOutputDataSourcePropertiesSystemPropertyColumns) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusQueueOutputDataSourcePropertiesSystemPropertyColumns SystemPropertyColumn { get; set; }

    }
    /// Describes a Service Bus Queue output data source.
    internal partial interface IServiceBusQueueOutputDataSourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSourceInternal
    {
        /// <summary>Authentication Mode.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode? AuthenticationMode { get; set; }
        /// <summary>
        /// The properties that are associated with a Service Bus Queue output. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusQueueOutputDataSourceProperties Property { get; set; }
        /// <summary>
        /// A string array of the names of output columns to be attached to Service Bus messages as custom properties.
        /// </summary>
        string[] PropertyColumn { get; set; }
        /// <summary>The name of the Service Bus Queue. Required on PUT (CreateOrReplace) requests.</summary>
        string QueueName { get; set; }
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
        /// <summary>Dictionary of <string></summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusQueueOutputDataSourcePropertiesSystemPropertyColumns SystemPropertyColumn { get; set; }

    }
}