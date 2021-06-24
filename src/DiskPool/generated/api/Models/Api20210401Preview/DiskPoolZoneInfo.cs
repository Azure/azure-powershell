namespace Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Extensions;

    /// <summary>Disk Pool Sku Details</summary>
    public partial class DiskPoolZoneInfo :
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IDiskPoolZoneInfo,
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IDiskPoolZoneInfoInternal
    {

        /// <summary>Backing field for <see cref="AdditionalCapability" /> property.</summary>
        private string[] _additionalCapability;

        /// <summary>List of additional capabilities for Disk Pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.FormatTable(Index = 3)]
        public string[] AdditionalCapability { get => this._additionalCapability; set => this._additionalCapability = value; }

        /// <summary>Backing field for <see cref="AvailabilityZone" /> property.</summary>
        private string[] _availabilityZone;

        /// <summary>Logical zone for Disk Pool resource; example: ["1"].</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.FormatTable(Index = 2)]
        public string[] AvailabilityZone { get => this._availabilityZone; set => this._availabilityZone = value; }

        /// <summary>Internal Acessors for Sku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.ISku Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IDiskPoolZoneInfoInternal.Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.Sku()); set { {_sku = value;} } }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.ISku _sku;

        /// <summary>Determines the SKU of VM deployed for Disk Pool</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.ISku Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.Sku()); set => this._sku = value; }

        /// <summary>Sku name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.FormatTable(Index = 0)]
        public string SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.ISkuInternal)Sku).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.ISkuInternal)Sku).Name = value ?? null; }

        /// <summary>Sku tier</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.FormatTable(Index = 1)]
        public string SkuTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.ISkuInternal)Sku).Tier; set => ((Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.ISkuInternal)Sku).Tier = value ?? null; }

        /// <summary>Creates an new <see cref="DiskPoolZoneInfo" /> instance.</summary>
        public DiskPoolZoneInfo()
        {

        }
    }
    /// Disk Pool Sku Details
    public partial interface IDiskPoolZoneInfo :
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.IJsonSerializable
    {
        /// <summary>List of additional capabilities for Disk Pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of additional capabilities for Disk Pool.",
        SerializedName = @"additionalCapabilities",
        PossibleTypes = new [] { typeof(string) })]
        string[] AdditionalCapability { get; set; }
        /// <summary>Logical zone for Disk Pool resource; example: ["1"].</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Logical zone for Disk Pool resource; example: [""1""].",
        SerializedName = @"availabilityZones",
        PossibleTypes = new [] { typeof(string) })]
        string[] AvailabilityZone { get; set; }
        /// <summary>Sku name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Sku name",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string SkuName { get; set; }
        /// <summary>Sku tier</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Sku tier",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(string) })]
        string SkuTier { get; set; }

    }
    /// Disk Pool Sku Details
    internal partial interface IDiskPoolZoneInfoInternal

    {
        /// <summary>List of additional capabilities for Disk Pool.</summary>
        string[] AdditionalCapability { get; set; }
        /// <summary>Logical zone for Disk Pool resource; example: ["1"].</summary>
        string[] AvailabilityZone { get; set; }
        /// <summary>Determines the SKU of VM deployed for Disk Pool</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.ISku Sku { get; set; }
        /// <summary>Sku name</summary>
        string SkuName { get; set; }
        /// <summary>Sku tier</summary>
        string SkuTier { get; set; }

    }
}