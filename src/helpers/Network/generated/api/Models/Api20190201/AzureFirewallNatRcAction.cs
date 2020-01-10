namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>AzureFirewall NAT Rule Collection Action.</summary>
    public partial class AzureFirewallNatRcAction :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallNatRcAction,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallNatRcActionInternal
    {

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallNatRcActionType? _type;

        /// <summary>The type of action.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallNatRcActionType? Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="AzureFirewallNatRcAction" /> instance.</summary>
        public AzureFirewallNatRcAction()
        {

        }
    }
    /// AzureFirewall NAT Rule Collection Action.
    public partial interface IAzureFirewallNatRcAction :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The type of action.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of action.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallNatRcActionType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallNatRcActionType? Type { get; set; }

    }
    /// AzureFirewall NAT Rule Collection Action.
    internal partial interface IAzureFirewallNatRcActionInternal

    {
        /// <summary>The type of action.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallNatRcActionType? Type { get; set; }

    }
}