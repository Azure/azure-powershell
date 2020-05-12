namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Collection of SKU information.</summary>
    public partial class SkuInfos :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfos,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuInfosInternal
    {

        /// <summary>Backing field for <see cref="ResourceType" /> property.</summary>
        private string _resourceType;

        /// <summary>Resource type that this SKU applies to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ResourceType { get => this._resourceType; set => this._resourceType = value; }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IGlobalCsmSkuDescription[] _sku;

        /// <summary>List of SKUs the subscription is able to use.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IGlobalCsmSkuDescription[] Sku { get => this._sku; set => this._sku = value; }

        /// <summary>Creates an new <see cref="SkuInfos" /> instance.</summary>
        public SkuInfos()
        {

        }
    }
    /// Collection of SKU information.
    public partial interface ISkuInfos :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Resource type that this SKU applies to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource type that this SKU applies to.",
        SerializedName = @"resourceType",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceType { get; set; }
        /// <summary>List of SKUs the subscription is able to use.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of SKUs the subscription is able to use.",
        SerializedName = @"skus",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IGlobalCsmSkuDescription) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IGlobalCsmSkuDescription[] Sku { get; set; }

    }
    /// Collection of SKU information.
    internal partial interface ISkuInfosInternal

    {
        /// <summary>Resource type that this SKU applies to.</summary>
        string ResourceType { get; set; }
        /// <summary>List of SKUs the subscription is able to use.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IGlobalCsmSkuDescription[] Sku { get; set; }

    }
}