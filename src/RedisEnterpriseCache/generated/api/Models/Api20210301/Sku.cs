namespace Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Extensions;

    /// <summary>SKU parameters supplied to the create RedisEnterprise operation.</summary>
    public partial class Sku :
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.ISku,
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.ISkuInternal
    {

        /// <summary>Backing field for <see cref="Capacity" /> property.</summary>
        private int? _capacity;

        /// <summary>
        /// The size of the RedisEnterprise cluster. Defaults to 2 or 3 depending on SKU. Valid values are (2, 4, 6, ...) for Enterprise
        /// SKUs and (3, 9, 15, ...) for Flash SKUs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Owned)]
        public int? Capacity { get => this._capacity; set => this._capacity = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.SkuName _name;

        /// <summary>
        /// The type of RedisEnterprise cluster to deploy. Possible values: (Enterprise_E10, EnterpriseFlash_F300 etc.)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.SkuName Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="Sku" /> instance.</summary>
        public Sku()
        {

        }
    }
    /// SKU parameters supplied to the create RedisEnterprise operation.
    public partial interface ISku :
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The size of the RedisEnterprise cluster. Defaults to 2 or 3 depending on SKU. Valid values are (2, 4, 6, ...) for Enterprise
        /// SKUs and (3, 9, 15, ...) for Flash SKUs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The size of the RedisEnterprise cluster. Defaults to 2 or 3 depending on SKU. Valid values are (2, 4, 6, ...) for Enterprise SKUs and (3, 9, 15, ...) for Flash SKUs.",
        SerializedName = @"capacity",
        PossibleTypes = new [] { typeof(int) })]
        int? Capacity { get; set; }
        /// <summary>
        /// The type of RedisEnterprise cluster to deploy. Possible values: (Enterprise_E10, EnterpriseFlash_F300 etc.)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The type of RedisEnterprise cluster to deploy. Possible values: (Enterprise_E10, EnterpriseFlash_F300 etc.)",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.SkuName) })]
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.SkuName Name { get; set; }

    }
    /// SKU parameters supplied to the create RedisEnterprise operation.
    internal partial interface ISkuInternal

    {
        /// <summary>
        /// The size of the RedisEnterprise cluster. Defaults to 2 or 3 depending on SKU. Valid values are (2, 4, 6, ...) for Enterprise
        /// SKUs and (3, 9, 15, ...) for Flash SKUs.
        /// </summary>
        int? Capacity { get; set; }
        /// <summary>
        /// The type of RedisEnterprise cluster to deploy. Possible values: (Enterprise_E10, EnterpriseFlash_F300 etc.)
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.SkuName Name { get; set; }

    }
}