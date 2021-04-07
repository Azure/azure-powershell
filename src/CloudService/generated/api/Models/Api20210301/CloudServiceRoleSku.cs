namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Extensions;

    /// <summary>Describes the cloud service role sku.</summary>
    public partial class CloudServiceRoleSku :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRoleSku,
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRoleSkuInternal
    {

        /// <summary>Backing field for <see cref="Capacity" /> property.</summary>
        private long? _capacity;

        /// <summary>Specifies the number of role instances in the cloud service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public long? Capacity { get => this._capacity; set => this._capacity = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>
        /// The sku name. NOTE: If the new SKU is not supported on the hardware the cloud service is currently on, you need to delete
        /// and recreate the cloud service or move back to the old sku.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Tier" /> property.</summary>
        private string _tier;

        /// <summary>
        /// Specifies the tier of the cloud service. Possible Values are <br /><br /> **Standard** <br /><br /> **Basic**
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public string Tier { get => this._tier; set => this._tier = value; }

        /// <summary>Creates an new <see cref="CloudServiceRoleSku" /> instance.</summary>
        public CloudServiceRoleSku()
        {

        }
    }
    /// Describes the cloud service role sku.
    public partial interface ICloudServiceRoleSku :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.IJsonSerializable
    {
        /// <summary>Specifies the number of role instances in the cloud service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies the number of role instances in the cloud service.",
        SerializedName = @"capacity",
        PossibleTypes = new [] { typeof(long) })]
        long? Capacity { get; set; }
        /// <summary>
        /// The sku name. NOTE: If the new SKU is not supported on the hardware the cloud service is currently on, you need to delete
        /// and recreate the cloud service or move back to the old sku.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The sku name. NOTE: If the new SKU is not supported on the hardware the cloud service is currently on, you need to delete and recreate the cloud service or move back to the old sku.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>
        /// Specifies the tier of the cloud service. Possible Values are <br /><br /> **Standard** <br /><br /> **Basic**
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies the tier of the cloud service. Possible Values are <br /><br /> **Standard** <br /><br /> **Basic**",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(string) })]
        string Tier { get; set; }

    }
    /// Describes the cloud service role sku.
    internal partial interface ICloudServiceRoleSkuInternal

    {
        /// <summary>Specifies the number of role instances in the cloud service.</summary>
        long? Capacity { get; set; }
        /// <summary>
        /// The sku name. NOTE: If the new SKU is not supported on the hardware the cloud service is currently on, you need to delete
        /// and recreate the cloud service or move back to the old sku.
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Specifies the tier of the cloud service. Possible Values are <br /><br /> **Standard** <br /><br /> **Basic**
        /// </summary>
        string Tier { get; set; }

    }
}