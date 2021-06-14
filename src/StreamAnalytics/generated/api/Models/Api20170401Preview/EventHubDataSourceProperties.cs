namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>The common properties that are associated with Event Hub data sources.</summary>
    public partial class EventHubDataSourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IEventHubDataSourceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IEventHubDataSourcePropertiesInternal,
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

        /// <summary>Backing field for <see cref="EventHubName" /> property.</summary>
        private string _eventHubName;

        /// <summary>The name of the Event Hub. Required on PUT (CreateOrReplace) requests.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string EventHubName { get => this._eventHubName; set => this._eventHubName = value; }

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

        /// <summary>Creates an new <see cref="EventHubDataSourceProperties" /> instance.</summary>
        public EventHubDataSourceProperties()
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
    /// The common properties that are associated with Event Hub data sources.
    public partial interface IEventHubDataSourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusDataSourceProperties
    {
        /// <summary>The name of the Event Hub. Required on PUT (CreateOrReplace) requests.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the Event Hub. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"eventHubName",
        PossibleTypes = new [] { typeof(string) })]
        string EventHubName { get; set; }

    }
    /// The common properties that are associated with Event Hub data sources.
    internal partial interface IEventHubDataSourcePropertiesInternal :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IServiceBusDataSourcePropertiesInternal
    {
        /// <summary>The name of the Event Hub. Required on PUT (CreateOrReplace) requests.</summary>
        string EventHubName { get; set; }

    }
}