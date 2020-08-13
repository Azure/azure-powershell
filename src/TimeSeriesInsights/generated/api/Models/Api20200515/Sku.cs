namespace Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515
{
    using static Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Extensions;

    /// <summary>
    /// The sku determines the type of environment, either Gen1 (S1 or S2) or Gen2 (L1). For Gen1 environments the sku determines
    /// the capacity of the environment, the ingress rate, and the billing rate.
    /// </summary>
    public partial class Sku :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ISku,
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ISkuInternal
    {

        /// <summary>Backing field for <see cref="Capacity" /> property.</summary>
        private int _capacity;

        /// <summary>
        /// The capacity of the sku. For Gen1 environments, this value can be changed to support scale out of environments after they
        /// have been created.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Owned)]
        public int Capacity { get => this._capacity; set => this._capacity = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.SkuName _name;

        /// <summary>The name of this SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.SkuName Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="Sku" /> instance.</summary>
        public Sku()
        {

        }
    }
    /// The sku determines the type of environment, either Gen1 (S1 or S2) or Gen2 (L1). For Gen1 environments the sku determines
    /// the capacity of the environment, the ingress rate, and the billing rate.
    public partial interface ISku :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The capacity of the sku. For Gen1 environments, this value can be changed to support scale out of environments after they
        /// have been created.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The capacity of the sku. For Gen1 environments, this value can be changed to support scale out of environments after they have been created.",
        SerializedName = @"capacity",
        PossibleTypes = new [] { typeof(int) })]
        int Capacity { get; set; }
        /// <summary>The name of this SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of this SKU.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.SkuName) })]
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.SkuName Name { get; set; }

    }
    /// The sku determines the type of environment, either Gen1 (S1 or S2) or Gen2 (L1). For Gen1 environments the sku determines
    /// the capacity of the environment, the ingress rate, and the billing rate.
    internal partial interface ISkuInternal

    {
        /// <summary>
        /// The capacity of the sku. For Gen1 environments, this value can be changed to support scale out of environments after they
        /// have been created.
        /// </summary>
        int Capacity { get; set; }
        /// <summary>The name of this SKU.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.SkuName Name { get; set; }

    }
}