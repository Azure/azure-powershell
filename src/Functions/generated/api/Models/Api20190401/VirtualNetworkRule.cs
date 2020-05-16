namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Virtual Network rule.</summary>
    public partial class VirtualNetworkRule :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IVirtualNetworkRule,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IVirtualNetworkRuleInternal
    {

        /// <summary>Backing field for <see cref="Action" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Action? _action;

        /// <summary>The action of virtual network rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Action? Action { get => this._action; set => this._action = value; }

        /// <summary>Backing field for <see cref="State" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.State? _state;

        /// <summary>Gets the state of virtual network rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.State? State { get => this._state; set => this._state = value; }

        /// <summary>Backing field for <see cref="VirtualNetworkResourceId" /> property.</summary>
        private string _virtualNetworkResourceId;

        /// <summary>
        /// Resource ID of a subnet, for example: /subscriptions/{subscriptionId}/resourceGroups/{groupName}/providers/Microsoft.Network/virtualNetworks/{vnetName}/subnets/{subnetName}.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string VirtualNetworkResourceId { get => this._virtualNetworkResourceId; set => this._virtualNetworkResourceId = value; }

        /// <summary>Creates an new <see cref="VirtualNetworkRule" /> instance.</summary>
        public VirtualNetworkRule()
        {

        }
    }
    /// Virtual Network rule.
    public partial interface IVirtualNetworkRule :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>The action of virtual network rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The action of virtual network rule.",
        SerializedName = @"action",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Action) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Action? Action { get; set; }
        /// <summary>Gets the state of virtual network rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets the state of virtual network rule.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.State) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.State? State { get; set; }
        /// <summary>
        /// Resource ID of a subnet, for example: /subscriptions/{subscriptionId}/resourceGroups/{groupName}/providers/Microsoft.Network/virtualNetworks/{vnetName}/subnets/{subnetName}.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Resource ID of a subnet, for example: /subscriptions/{subscriptionId}/resourceGroups/{groupName}/providers/Microsoft.Network/virtualNetworks/{vnetName}/subnets/{subnetName}.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string VirtualNetworkResourceId { get; set; }

    }
    /// Virtual Network rule.
    internal partial interface IVirtualNetworkRuleInternal

    {
        /// <summary>The action of virtual network rule.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Action? Action { get; set; }
        /// <summary>Gets the state of virtual network rule.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.State? State { get; set; }
        /// <summary>
        /// Resource ID of a subnet, for example: /subscriptions/{subscriptionId}/resourceGroups/{groupName}/providers/Microsoft.Network/virtualNetworks/{vnetName}/subnets/{subnetName}.
        /// </summary>
        string VirtualNetworkResourceId { get; set; }

    }
}