namespace Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Extensions;

    /// <summary>Properties related to EventHub.</summary>
    public partial class EventHub :
        Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IEventHub,
        Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IEventHubInternal,
        Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourceProperties"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourceProperties __digitalTwinsEndpointResourceProperties = new Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.DigitalTwinsEndpointResourceProperties();

        /// <summary>Backing field for <see cref="ConnectionStringPrimaryKey" /> property.</summary>
        private string _connectionStringPrimaryKey;

        /// <summary>PrimaryConnectionString of the endpoint. Will be obfuscated during read.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Origin(Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.PropertyOrigin.Owned)]
        public string ConnectionStringPrimaryKey { get => this._connectionStringPrimaryKey; set => this._connectionStringPrimaryKey = value; }

        /// <summary>Backing field for <see cref="ConnectionStringSecondaryKey" /> property.</summary>
        private string _connectionStringSecondaryKey;

        /// <summary>SecondaryConnectionString of the endpoint. Will be obfuscated during read.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Origin(Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.PropertyOrigin.Owned)]
        public string ConnectionStringSecondaryKey { get => this._connectionStringSecondaryKey; set => this._connectionStringSecondaryKey = value; }

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

        /// <summary>Creates an new <see cref="EventHub" /> instance.</summary>
        public EventHub()
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
    /// Properties related to EventHub.
    public partial interface IEventHub :
        Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourceProperties
    {
        /// <summary>PrimaryConnectionString of the endpoint. Will be obfuscated during read.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"PrimaryConnectionString of the endpoint. Will be obfuscated during read.",
        SerializedName = @"connectionStringPrimaryKey",
        PossibleTypes = new [] { typeof(string) })]
        string ConnectionStringPrimaryKey { get; set; }
        /// <summary>SecondaryConnectionString of the endpoint. Will be obfuscated during read.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"SecondaryConnectionString of the endpoint. Will be obfuscated during read.",
        SerializedName = @"connectionStringSecondaryKey",
        PossibleTypes = new [] { typeof(string) })]
        string ConnectionStringSecondaryKey { get; set; }

    }
    /// Properties related to EventHub.
    internal partial interface IEventHubInternal :
        Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResourcePropertiesInternal
    {
        /// <summary>PrimaryConnectionString of the endpoint. Will be obfuscated during read.</summary>
        string ConnectionStringPrimaryKey { get; set; }
        /// <summary>SecondaryConnectionString of the endpoint. Will be obfuscated during read.</summary>
        string ConnectionStringSecondaryKey { get; set; }

    }
}