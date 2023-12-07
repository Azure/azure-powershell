namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class SkuCost :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuCost,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuCostInternal
    {

        /// <summary>Backing field for <see cref="ExtendedUnit" /> property.</summary>
        private string _extendedUnit;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string ExtendedUnit { get => this._extendedUnit; set => this._extendedUnit = value; }

        /// <summary>Backing field for <see cref="MeterId" /> property.</summary>
        private string _meterId;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string MeterId { get => this._meterId; set => this._meterId = value; }

        /// <summary>Backing field for <see cref="Quantity" /> property.</summary>
        private int? _quantity;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public int? Quantity { get => this._quantity; set => this._quantity = value; }

        /// <summary>Creates an new <see cref="SkuCost" /> instance.</summary>
        public SkuCost()
        {

        }
    }
    public partial interface ISkuCost :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"extendedUnit",
        PossibleTypes = new [] { typeof(string) })]
        string ExtendedUnit { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"meterId",
        PossibleTypes = new [] { typeof(string) })]
        string MeterId { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"quantity",
        PossibleTypes = new [] { typeof(int) })]
        int? Quantity { get; set; }

    }
    internal partial interface ISkuCostInternal

    {
        string ExtendedUnit { get; set; }

        string MeterId { get; set; }

        int? Quantity { get; set; }

    }
}