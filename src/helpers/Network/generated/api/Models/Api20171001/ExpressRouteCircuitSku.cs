namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Contains SKU in an ExpressRouteCircuit.</summary>
    public partial class ExpressRouteCircuitSku :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitSku,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitSkuInternal
    {

        /// <summary>Backing field for <see cref="Family" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitSkuFamily? _family;

        /// <summary>The family of the SKU. Possible values are: 'UnlimitedData' and 'MeteredData'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitSkuFamily? Family { get => this._family; set => this._family = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Tier" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitSkuTier? _tier;

        /// <summary>The tier of the SKU. Possible values are 'Standard' and 'Premium'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitSkuTier? Tier { get => this._tier; set => this._tier = value; }

        /// <summary>Creates an new <see cref="ExpressRouteCircuitSku" /> instance.</summary>
        public ExpressRouteCircuitSku()
        {

        }
    }
    /// Contains SKU in an ExpressRouteCircuit.
    public partial interface IExpressRouteCircuitSku :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The family of the SKU. Possible values are: 'UnlimitedData' and 'MeteredData'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The family of the SKU. Possible values are: 'UnlimitedData' and 'MeteredData'.",
        SerializedName = @"family",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitSkuFamily) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitSkuFamily? Family { get; set; }
        /// <summary>The name of the SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the SKU.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>The tier of the SKU. Possible values are 'Standard' and 'Premium'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The tier of the SKU. Possible values are 'Standard' and 'Premium'.",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitSkuTier) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitSkuTier? Tier { get; set; }

    }
    /// Contains SKU in an ExpressRouteCircuit.
    internal partial interface IExpressRouteCircuitSkuInternal

    {
        /// <summary>The family of the SKU. Possible values are: 'UnlimitedData' and 'MeteredData'.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitSkuFamily? Family { get; set; }
        /// <summary>The name of the SKU.</summary>
        string Name { get; set; }
        /// <summary>The tier of the SKU. Possible values are 'Standard' and 'Premium'.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitSkuTier? Tier { get; set; }

    }
}