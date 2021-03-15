namespace Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208
{
    using static Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.Extensions;

    /// <summary>Parameters for updating a HealthBot.</summary>
    public partial class HealthBotUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotUpdateParameters,
        Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotUpdateParametersInternal
    {

        /// <summary>Internal Acessors for Sku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.ISku Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotUpdateParametersInternal.Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.Sku()); set { {_sku = value;} } }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.ISku _sku;

        /// <summary>SKU of the HealthBot.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Origin(Microsoft.Azure.PowerShell.Cmdlets.HealthBot.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.ISku Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.Sku()); set => this._sku = value; }

        /// <summary>The name of the HealthBot SKU</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Origin(Microsoft.Azure.PowerShell.Cmdlets.HealthBot.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Support.SkuName? SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.ISkuInternal)Sku).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.ISkuInternal)Sku).Name = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Support.SkuName)""); }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotUpdateParametersTags _tag;

        /// <summary>Tags for a HealthBot.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Origin(Microsoft.Azure.PowerShell.Cmdlets.HealthBot.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotUpdateParametersTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.HealthBotUpdateParametersTags()); set => this._tag = value; }

        /// <summary>Creates an new <see cref="HealthBotUpdateParameters" /> instance.</summary>
        public HealthBotUpdateParameters()
        {

        }
    }
    /// Parameters for updating a HealthBot.
    public partial interface IHealthBotUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.IJsonSerializable
    {
        /// <summary>The name of the HealthBot SKU</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the HealthBot SKU",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Support.SkuName) })]
        Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Support.SkuName? SkuName { get; set; }
        /// <summary>Tags for a HealthBot.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Tags for a HealthBot.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotUpdateParametersTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotUpdateParametersTags Tag { get; set; }

    }
    /// Parameters for updating a HealthBot.
    internal partial interface IHealthBotUpdateParametersInternal

    {
        /// <summary>SKU of the HealthBot.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.ISku Sku { get; set; }
        /// <summary>The name of the HealthBot SKU</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Support.SkuName? SkuName { get; set; }
        /// <summary>Tags for a HealthBot.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotUpdateParametersTags Tag { get; set; }

    }
}