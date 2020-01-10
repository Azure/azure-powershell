namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>SKU of nat gateway</summary>
    public partial class NatGatewaySku :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewaySku,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INatGatewaySkuInternal
    {

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.NatGatewaySkuName? _name;

        /// <summary>Name of Nat Gateway SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.NatGatewaySkuName? Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="NatGatewaySku" /> instance.</summary>
        public NatGatewaySku()
        {

        }
    }
    /// SKU of nat gateway
    public partial interface INatGatewaySku :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Name of Nat Gateway SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of Nat Gateway SKU.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.NatGatewaySkuName) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.NatGatewaySkuName? Name { get; set; }

    }
    /// SKU of nat gateway
    internal partial interface INatGatewaySkuInternal

    {
        /// <summary>Name of Nat Gateway SKU.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.NatGatewaySkuName? Name { get; set; }

    }
}