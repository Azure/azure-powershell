namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of the application rule protocol.</summary>
    public partial class AzureFirewallApplicationRuleProtocol :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallApplicationRuleProtocol,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallApplicationRuleProtocolInternal
    {

        /// <summary>Backing field for <see cref="Port" /> property.</summary>
        private int? _port;

        /// <summary>
        /// Port number for the protocol, cannot be greater than 64000. This field is optional.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? Port { get => this._port; set => this._port = value; }

        /// <summary>Backing field for <see cref="ProtocolType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallApplicationRuleProtocolType? _protocolType;

        /// <summary>Protocol type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallApplicationRuleProtocolType? ProtocolType { get => this._protocolType; set => this._protocolType = value; }

        /// <summary>Creates an new <see cref="AzureFirewallApplicationRuleProtocol" /> instance.</summary>
        public AzureFirewallApplicationRuleProtocol()
        {

        }
    }
    /// Properties of the application rule protocol.
    public partial interface IAzureFirewallApplicationRuleProtocol :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Port number for the protocol, cannot be greater than 64000. This field is optional.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Port number for the protocol, cannot be greater than 64000. This field is optional.",
        SerializedName = @"port",
        PossibleTypes = new [] { typeof(int) })]
        int? Port { get; set; }
        /// <summary>Protocol type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Protocol type",
        SerializedName = @"protocolType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallApplicationRuleProtocolType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallApplicationRuleProtocolType? ProtocolType { get; set; }

    }
    /// Properties of the application rule protocol.
    internal partial interface IAzureFirewallApplicationRuleProtocolInternal

    {
        /// <summary>
        /// Port number for the protocol, cannot be greater than 64000. This field is optional.
        /// </summary>
        int? Port { get; set; }
        /// <summary>Protocol type</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallApplicationRuleProtocolType? ProtocolType { get; set; }

    }
}