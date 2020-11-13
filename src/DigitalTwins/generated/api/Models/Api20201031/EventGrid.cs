namespace Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Extensions;

    /// <summary>Properties related to EventGrid.</summary>
    public partial class EventGrid :
        Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IEventGrid,
        Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IEventGridInternal,
        Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourceProperties"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourceProperties __digitalTwinsEndpointResourceProperties = new Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.DigitalTwinsEndpointResourceProperties();

        /// <summary>Backing field for <see cref="AccessKey1" /> property.</summary>
        private string _accessKey1;

        /// <summary>EventGrid secondary accesskey. Will be obfuscated during read.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Origin(Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.PropertyOrigin.Owned)]
        public string AccessKey1 { get => this._accessKey1; set => this._accessKey1 = value; }

        /// <summary>Backing field for <see cref="AccessKey2" /> property.</summary>
        private string _accessKey2;

        /// <summary>EventGrid secondary accesskey. Will be obfuscated during read.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Origin(Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.PropertyOrigin.Owned)]
        public string AccessKey2 { get => this._accessKey2; set => this._accessKey2 = value; }

        /// <summary>Time when the Endpoint was added to DigitalTwinsInstance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Origin(Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.PropertyOrigin.Inherited)]
        public global::System.DateTime? CreatedTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourcePropertiesInternal)__digitalTwinsEndpointResourceProperties).CreatedTime; }

        /// <summary>Dead letter storage secret. Will be obfuscated during read.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Origin(Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.PropertyOrigin.Inherited)]
        public string DeadLetterSecret { get => ((Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourcePropertiesInternal)__digitalTwinsEndpointResourceProperties).DeadLetterSecret; set => ((Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourcePropertiesInternal)__digitalTwinsEndpointResourceProperties).DeadLetterSecret = value; }

        /// <summary>The type of Digital Twins endpoint</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Origin(Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Support.EndpointType EndpointType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourcePropertiesInternal)__digitalTwinsEndpointResourceProperties).EndpointType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourcePropertiesInternal)__digitalTwinsEndpointResourceProperties).EndpointType = value; }

        /// <summary>Internal Acessors for CreatedTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourcePropertiesInternal.CreatedTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourcePropertiesInternal)__digitalTwinsEndpointResourceProperties).CreatedTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourcePropertiesInternal)__digitalTwinsEndpointResourceProperties).CreatedTime = value; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Support.EndpointProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourcePropertiesInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourcePropertiesInternal)__digitalTwinsEndpointResourceProperties).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourcePropertiesInternal)__digitalTwinsEndpointResourceProperties).ProvisioningState = value; }

        /// <summary>The provisioning state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Origin(Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Support.EndpointProvisioningState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourcePropertiesInternal)__digitalTwinsEndpointResourceProperties).ProvisioningState; }

        /// <summary>Backing field for <see cref="TopicEndpoint" /> property.</summary>
        private string _topicEndpoint;

        /// <summary>EventGrid Topic Endpoint</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Origin(Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.PropertyOrigin.Owned)]
        public string TopicEndpoint { get => this._topicEndpoint; set => this._topicEndpoint = value; }

        /// <summary>Creates an new <see cref="EventGrid" /> instance.</summary>
        public EventGrid()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__digitalTwinsEndpointResourceProperties), __digitalTwinsEndpointResourceProperties);
            await eventListener.AssertObjectIsValid(nameof(__digitalTwinsEndpointResourceProperties), __digitalTwinsEndpointResourceProperties);
        }
    }
    /// Properties related to EventGrid.
    public partial interface IEventGrid :
        Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourceProperties
    {
        /// <summary>EventGrid secondary accesskey. Will be obfuscated during read.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"EventGrid secondary accesskey. Will be obfuscated during read.",
        SerializedName = @"accessKey1",
        PossibleTypes = new [] { typeof(string) })]
        string AccessKey1 { get; set; }
        /// <summary>EventGrid secondary accesskey. Will be obfuscated during read.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"EventGrid secondary accesskey. Will be obfuscated during read.",
        SerializedName = @"accessKey2",
        PossibleTypes = new [] { typeof(string) })]
        string AccessKey2 { get; set; }
        /// <summary>EventGrid Topic Endpoint</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"EventGrid Topic Endpoint",
        SerializedName = @"TopicEndpoint",
        PossibleTypes = new [] { typeof(string) })]
        string TopicEndpoint { get; set; }

    }
    /// Properties related to EventGrid.
    internal partial interface IEventGridInternal :
        Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourcePropertiesInternal
    {
        /// <summary>EventGrid secondary accesskey. Will be obfuscated during read.</summary>
        string AccessKey1 { get; set; }
        /// <summary>EventGrid secondary accesskey. Will be obfuscated during read.</summary>
        string AccessKey2 { get; set; }
        /// <summary>EventGrid Topic Endpoint</summary>
        string TopicEndpoint { get; set; }

    }
}