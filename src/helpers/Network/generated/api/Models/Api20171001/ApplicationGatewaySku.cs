namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>SKU of an application gateway</summary>
    public partial class ApplicationGatewaySku :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySku,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewaySkuInternal
    {

        /// <summary>Backing field for <see cref="Capacity" /> property.</summary>
        private int? _capacity;

        /// <summary>Capacity (instance count) of an application gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? Capacity { get => this._capacity; set => this._capacity = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySkuName? _name;

        /// <summary>Name of an application gateway SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySkuName? Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Tier" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayTier? _tier;

        /// <summary>Tier of an application gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayTier? Tier { get => this._tier; set => this._tier = value; }

        /// <summary>Creates an new <see cref="ApplicationGatewaySku" /> instance.</summary>
        public ApplicationGatewaySku()
        {

        }
    }
    /// SKU of an application gateway
    public partial interface IApplicationGatewaySku :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Capacity (instance count) of an application gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Capacity (instance count) of an application gateway.",
        SerializedName = @"capacity",
        PossibleTypes = new [] { typeof(int) })]
        int? Capacity { get; set; }
        /// <summary>Name of an application gateway SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of an application gateway SKU.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySkuName) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySkuName? Name { get; set; }
        /// <summary>Tier of an application gateway.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Tier of an application gateway.",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayTier) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayTier? Tier { get; set; }

    }
    /// SKU of an application gateway
    internal partial interface IApplicationGatewaySkuInternal

    {
        /// <summary>Capacity (instance count) of an application gateway.</summary>
        int? Capacity { get; set; }
        /// <summary>Name of an application gateway SKU.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewaySkuName? Name { get; set; }
        /// <summary>Tier of an application gateway.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayTier? Tier { get; set; }

    }
}