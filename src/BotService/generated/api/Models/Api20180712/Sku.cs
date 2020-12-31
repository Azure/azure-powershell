namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>The SKU of the cognitive services account.</summary>
    public partial class Sku :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISku,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkuInternal
    {

        /// <summary>Internal Acessors for Tier</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.SkuTier? Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkuInternal.Tier { get => this._tier; set { {_tier = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.SkuName _name;

        /// <summary>The sku name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.SkuName Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Tier" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.SkuTier? _tier;

        /// <summary>Gets the sku tier. This is based on the SKU name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.SkuTier? Tier { get => this._tier; }

        /// <summary>Creates an new <see cref="Sku" /> instance.</summary>
        public Sku()
        {

        }
    }
    /// The SKU of the cognitive services account.
    public partial interface ISku :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable
    {
        /// <summary>The sku name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The sku name",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.SkuName) })]
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.SkuName Name { get; set; }
        /// <summary>Gets the sku tier. This is based on the SKU name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the sku tier. This is based on the SKU name.",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.SkuTier) })]
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.SkuTier? Tier { get;  }

    }
    /// The SKU of the cognitive services account.
    internal partial interface ISkuInternal

    {
        /// <summary>The sku name</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.SkuName Name { get; set; }
        /// <summary>Gets the sku tier. This is based on the SKU name.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.SkuTier? Tier { get; set; }

    }
}