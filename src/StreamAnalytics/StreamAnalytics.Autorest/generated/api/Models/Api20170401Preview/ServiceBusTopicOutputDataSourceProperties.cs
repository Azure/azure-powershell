namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>The properties that are associated with a Service Bus Topic output.</summary>
    public partial class ServiceBusTopicOutputDataSourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusTopicOutputDataSourceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusTopicOutputDataSourcePropertiesInternal,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusDataSourceProperties"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusDataSourceProperties __serviceBusDataSourceProperties = new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ServiceBusDataSourceProperties();

        /// <summary>Authentication Mode.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode? AuthenticationMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusDataSourcePropertiesInternal)__serviceBusDataSourceProperties).AuthenticationMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusDataSourcePropertiesInternal)__serviceBusDataSourceProperties).AuthenticationMode = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode)""); }

        /// <summary>Backing field for <see cref="PropertyColumn" /> property.</summary>
        private string[] _propertyColumn;

        /// <summary>
        /// A string array of the names of output columns to be attached to Service Bus messages as custom properties.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string[] PropertyColumn { get => this._propertyColumn; set => this._propertyColumn = value; }

        /// <summary>
        /// The namespace that is associated with the desired Event Hub, Service Bus Queue, Service Bus Topic, etc. Required on PUT
        /// (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public string ServiceBusNamespace { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusDataSourcePropertiesInternal)__serviceBusDataSourceProperties).ServiceBusNamespace; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusDataSourcePropertiesInternal)__serviceBusDataSourceProperties).ServiceBusNamespace = value ?? null; }

        /// <summary>
        /// The shared access policy key for the specified shared access policy. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public string SharedAccessPolicyKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusDataSourcePropertiesInternal)__serviceBusDataSourceProperties).SharedAccessPolicyKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusDataSourcePropertiesInternal)__serviceBusDataSourceProperties).SharedAccessPolicyKey = value ?? null; }

        /// <summary>
        /// The shared access policy name for the Event Hub, Service Bus Queue, Service Bus Topic, etc. Required on PUT (CreateOrReplace)
        /// requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public string SharedAccessPolicyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusDataSourcePropertiesInternal)__serviceBusDataSourceProperties).SharedAccessPolicyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusDataSourcePropertiesInternal)__serviceBusDataSourceProperties).SharedAccessPolicyName = value ?? null; }

        /// <summary>Backing field for <see cref="SystemPropertyColumn" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusTopicOutputDataSourcePropertiesSystemPropertyColumns _systemPropertyColumn;

        /// <summary>Dictionary of <string></summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusTopicOutputDataSourcePropertiesSystemPropertyColumns SystemPropertyColumn { get => (this._systemPropertyColumn = this._systemPropertyColumn ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ServiceBusTopicOutputDataSourcePropertiesSystemPropertyColumns()); set => this._systemPropertyColumn = value; }

        /// <summary>Backing field for <see cref="TopicName" /> property.</summary>
        private string _topicName;

        /// <summary>The name of the Service Bus Topic. Required on PUT (CreateOrReplace) requests.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string TopicName { get => this._topicName; set => this._topicName = value; }

        /// <summary>
        /// Creates an new <see cref="ServiceBusTopicOutputDataSourceProperties" /> instance.
        /// </summary>
        public ServiceBusTopicOutputDataSourceProperties()
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
            await eventListener.AssertNotNull(nameof(__serviceBusDataSourceProperties), __serviceBusDataSourceProperties);
            await eventListener.AssertObjectIsValid(nameof(__serviceBusDataSourceProperties), __serviceBusDataSourceProperties);
        }
    }
    /// The properties that are associated with a Service Bus Topic output.
    public partial interface IServiceBusTopicOutputDataSourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusDataSourceProperties
    {
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
        /// <summary>Dictionary of <string></summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Dictionary of <string>",
        SerializedName = @"systemPropertyColumns",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusTopicOutputDataSourcePropertiesSystemPropertyColumns) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusTopicOutputDataSourcePropertiesSystemPropertyColumns SystemPropertyColumn { get; set; }
        /// <summary>The name of the Service Bus Topic. Required on PUT (CreateOrReplace) requests.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the Service Bus Topic. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"topicName",
        PossibleTypes = new [] { typeof(string) })]
        string TopicName { get; set; }

    }
    /// The properties that are associated with a Service Bus Topic output.
    internal partial interface IServiceBusTopicOutputDataSourcePropertiesInternal :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusDataSourcePropertiesInternal
    {
        /// <summary>
        /// A string array of the names of output columns to be attached to Service Bus messages as custom properties.
        /// </summary>
        string[] PropertyColumn { get; set; }
        /// <summary>Dictionary of <string></summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusTopicOutputDataSourcePropertiesSystemPropertyColumns SystemPropertyColumn { get; set; }
        /// <summary>The name of the Service Bus Topic. Required on PUT (CreateOrReplace) requests.</summary>
        string TopicName { get; set; }

    }
}