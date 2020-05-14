namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>HybridConnection resource specific properties</summary>
    public partial class HybridConnectionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHybridConnectionProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHybridConnectionPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Hostname" /> property.</summary>
        private string _hostname;

        /// <summary>The hostname of the endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Hostname { get => this._hostname; set => this._hostname = value; }

        /// <summary>Backing field for <see cref="Port" /> property.</summary>
        private int? _port;

        /// <summary>The port of the endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? Port { get => this._port; set => this._port = value; }

        /// <summary>Backing field for <see cref="RelayArmUri" /> property.</summary>
        private string _relayArmUri;

        /// <summary>The ARM URI to the Service Bus relay.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string RelayArmUri { get => this._relayArmUri; set => this._relayArmUri = value; }

        /// <summary>Backing field for <see cref="RelayName" /> property.</summary>
        private string _relayName;

        /// <summary>The name of the Service Bus relay.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string RelayName { get => this._relayName; set => this._relayName = value; }

        /// <summary>Backing field for <see cref="SendKeyName" /> property.</summary>
        private string _sendKeyName;

        /// <summary>
        /// The name of the Service Bus key which has Send permissions. This is used to authenticate to Service Bus.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string SendKeyName { get => this._sendKeyName; set => this._sendKeyName = value; }

        /// <summary>Backing field for <see cref="SendKeyValue" /> property.</summary>
        private string _sendKeyValue;

        /// <summary>
        /// The value of the Service Bus key. This is used to authenticate to Service Bus. In ARM this key will not be returned
        /// normally, use the POST /listKeys API instead.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string SendKeyValue { get => this._sendKeyValue; set => this._sendKeyValue = value; }

        /// <summary>Backing field for <see cref="ServiceBusNamespace" /> property.</summary>
        private string _serviceBusNamespace;

        /// <summary>The name of the Service Bus namespace.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ServiceBusNamespace { get => this._serviceBusNamespace; set => this._serviceBusNamespace = value; }

        /// <summary>Backing field for <see cref="ServiceBusSuffix" /> property.</summary>
        private string _serviceBusSuffix;

        /// <summary>
        /// The suffix for the service bus endpoint. By default this is .servicebus.windows.net
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ServiceBusSuffix { get => this._serviceBusSuffix; set => this._serviceBusSuffix = value; }

        /// <summary>Creates an new <see cref="HybridConnectionProperties" /> instance.</summary>
        public HybridConnectionProperties()
        {

        }
    }
    /// HybridConnection resource specific properties
    public partial interface IHybridConnectionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>The hostname of the endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The hostname of the endpoint.",
        SerializedName = @"hostname",
        PossibleTypes = new [] { typeof(string) })]
        string Hostname { get; set; }
        /// <summary>The port of the endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The port of the endpoint.",
        SerializedName = @"port",
        PossibleTypes = new [] { typeof(int) })]
        int? Port { get; set; }
        /// <summary>The ARM URI to the Service Bus relay.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ARM URI to the Service Bus relay.",
        SerializedName = @"relayArmUri",
        PossibleTypes = new [] { typeof(string) })]
        string RelayArmUri { get; set; }
        /// <summary>The name of the Service Bus relay.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the Service Bus relay.",
        SerializedName = @"relayName",
        PossibleTypes = new [] { typeof(string) })]
        string RelayName { get; set; }
        /// <summary>
        /// The name of the Service Bus key which has Send permissions. This is used to authenticate to Service Bus.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the Service Bus key which has Send permissions. This is used to authenticate to Service Bus.",
        SerializedName = @"sendKeyName",
        PossibleTypes = new [] { typeof(string) })]
        string SendKeyName { get; set; }
        /// <summary>
        /// The value of the Service Bus key. This is used to authenticate to Service Bus. In ARM this key will not be returned
        /// normally, use the POST /listKeys API instead.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The value of the Service Bus key. This is used to authenticate to Service Bus. In ARM this key will not be returned
        normally, use the POST /listKeys API instead.",
        SerializedName = @"sendKeyValue",
        PossibleTypes = new [] { typeof(string) })]
        string SendKeyValue { get; set; }
        /// <summary>The name of the Service Bus namespace.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the Service Bus namespace.",
        SerializedName = @"serviceBusNamespace",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceBusNamespace { get; set; }
        /// <summary>
        /// The suffix for the service bus endpoint. By default this is .servicebus.windows.net
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The suffix for the service bus endpoint. By default this is .servicebus.windows.net",
        SerializedName = @"serviceBusSuffix",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceBusSuffix { get; set; }

    }
    /// HybridConnection resource specific properties
    internal partial interface IHybridConnectionPropertiesInternal

    {
        /// <summary>The hostname of the endpoint.</summary>
        string Hostname { get; set; }
        /// <summary>The port of the endpoint.</summary>
        int? Port { get; set; }
        /// <summary>The ARM URI to the Service Bus relay.</summary>
        string RelayArmUri { get; set; }
        /// <summary>The name of the Service Bus relay.</summary>
        string RelayName { get; set; }
        /// <summary>
        /// The name of the Service Bus key which has Send permissions. This is used to authenticate to Service Bus.
        /// </summary>
        string SendKeyName { get; set; }
        /// <summary>
        /// The value of the Service Bus key. This is used to authenticate to Service Bus. In ARM this key will not be returned
        /// normally, use the POST /listKeys API instead.
        /// </summary>
        string SendKeyValue { get; set; }
        /// <summary>The name of the Service Bus namespace.</summary>
        string ServiceBusNamespace { get; set; }
        /// <summary>
        /// The suffix for the service bus endpoint. By default this is .servicebus.windows.net
        /// </summary>
        string ServiceBusSuffix { get; set; }

    }
}