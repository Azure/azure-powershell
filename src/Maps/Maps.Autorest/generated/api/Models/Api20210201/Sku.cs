namespace Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Extensions;

    /// <summary>The SKU of the Maps Account.</summary>
    public partial class Sku :
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ISku,
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ISkuInternal
    {

        /// <summary>Internal Acessors for Tier</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ISkuInternal.Tier { get => this._tier; set { {_tier = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.Name _name;

        /// <summary>The name of the SKU, in standard format (such as S0).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.Name Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Tier" /> property.</summary>
        private string _tier;

        /// <summary>Gets the sku tier. This is based on the SKU name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Owned)]
        public string Tier { get => this._tier; }

        /// <summary>Creates an new <see cref="Sku" /> instance.</summary>
        public Sku()
        {

        }
    }
    /// The SKU of the Maps Account.
    public partial interface ISku :
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.IJsonSerializable
    {
        /// <summary>The name of the SKU, in standard format (such as S0).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the SKU, in standard format (such as S0).",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.Name) })]
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.Name Name { get; set; }
        /// <summary>Gets the sku tier. This is based on the SKU name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the sku tier. This is based on the SKU name.",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(string) })]
        string Tier { get;  }

    }
    /// The SKU of the Maps Account.
    internal partial interface ISkuInternal

    {
        /// <summary>The name of the SKU, in standard format (such as S0).</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.Name Name { get; set; }
        /// <summary>Gets the sku tier. This is based on the SKU name.</summary>
        string Tier { get; set; }

    }
}