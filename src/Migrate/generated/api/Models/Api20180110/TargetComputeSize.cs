namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Represents applicable recovery vm sizes.</summary>
    public partial class TargetComputeSize :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITargetComputeSize,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITargetComputeSizeInternal
    {

        /// <summary>The maximum cpu cores count supported by target compute size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public int? CpuCoresCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITargetComputeSizePropertiesInternal)Property).CpuCoresCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITargetComputeSizePropertiesInternal)Property).CpuCoresCount = value ?? default(int); }

        /// <summary>
        /// The reasons why the target compute size is not applicable for the protected item.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IComputeSizeErrorDetails[] Error { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITargetComputeSizePropertiesInternal)Property).Error; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITargetComputeSizePropertiesInternal)Property).Error = value ?? null /* arrayOf */; }

        /// <summary>Target compute size display name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string FriendlyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITargetComputeSizePropertiesInternal)Property).FriendlyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITargetComputeSizePropertiesInternal)Property).FriendlyName = value ?? null; }

        /// <summary>The value indicating whether the target compute size supports high Iops.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string HighIopsSupported { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITargetComputeSizePropertiesInternal)Property).HighIopsSupported; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITargetComputeSizePropertiesInternal)Property).HighIopsSupported = value ?? null; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>The Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>The maximum data disks count supported by target compute size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public int? MaxDataDiskCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITargetComputeSizePropertiesInternal)Property).MaxDataDiskCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITargetComputeSizePropertiesInternal)Property).MaxDataDiskCount = value ?? default(int); }

        /// <summary>The maximum Nics count supported by target compute size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public int? MaxNicsCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITargetComputeSizePropertiesInternal)Property).MaxNicsCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITargetComputeSizePropertiesInternal)Property).MaxNicsCount = value ?? default(int); }

        /// <summary>The maximum memory in GB supported by target compute size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public double? MemoryInGb { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITargetComputeSizePropertiesInternal)Property).MemoryInGb; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITargetComputeSizePropertiesInternal)Property).MemoryInGb = value ?? default(double); }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITargetComputeSizeProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITargetComputeSizeInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.TargetComputeSizeProperties()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Target compute size name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string PropertiesName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITargetComputeSizePropertiesInternal)Property).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITargetComputeSizePropertiesInternal)Property).Name = value ?? null; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITargetComputeSizeProperties _property;

        /// <summary>The custom data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITargetComputeSizeProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.TargetComputeSizeProperties()); set => this._property = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>The Type of the object.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="TargetComputeSize" /> instance.</summary>
        public TargetComputeSize()
        {

        }
    }
    /// Represents applicable recovery vm sizes.
    public partial interface ITargetComputeSize :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The maximum cpu cores count supported by target compute size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The maximum cpu cores count supported by target compute size.",
        SerializedName = @"cpuCoresCount",
        PossibleTypes = new [] { typeof(int) })]
        int? CpuCoresCount { get; set; }
        /// <summary>
        /// The reasons why the target compute size is not applicable for the protected item.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The reasons why the target compute size is not applicable for the protected item.",
        SerializedName = @"errors",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IComputeSizeErrorDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IComputeSizeErrorDetails[] Error { get; set; }
        /// <summary>Target compute size display name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Target compute size display name.",
        SerializedName = @"friendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string FriendlyName { get; set; }
        /// <summary>The value indicating whether the target compute size supports high Iops.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The value indicating whether the target compute size supports high Iops.",
        SerializedName = @"highIopsSupported",
        PossibleTypes = new [] { typeof(string) })]
        string HighIopsSupported { get; set; }
        /// <summary>The Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Id.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }
        /// <summary>The maximum data disks count supported by target compute size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The maximum data disks count supported by target compute size.",
        SerializedName = @"maxDataDiskCount",
        PossibleTypes = new [] { typeof(int) })]
        int? MaxDataDiskCount { get; set; }
        /// <summary>The maximum Nics count supported by target compute size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The maximum Nics count supported by target compute size.",
        SerializedName = @"maxNicsCount",
        PossibleTypes = new [] { typeof(int) })]
        int? MaxNicsCount { get; set; }
        /// <summary>The maximum memory in GB supported by target compute size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The maximum memory in GB supported by target compute size.",
        SerializedName = @"memoryInGB",
        PossibleTypes = new [] { typeof(double) })]
        double? MemoryInGb { get; set; }
        /// <summary>The name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>Target compute size name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Target compute size name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string PropertiesName { get; set; }
        /// <summary>The Type of the object.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Type of the object.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get; set; }

    }
    /// Represents applicable recovery vm sizes.
    internal partial interface ITargetComputeSizeInternal

    {
        /// <summary>The maximum cpu cores count supported by target compute size.</summary>
        int? CpuCoresCount { get; set; }
        /// <summary>
        /// The reasons why the target compute size is not applicable for the protected item.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IComputeSizeErrorDetails[] Error { get; set; }
        /// <summary>Target compute size display name.</summary>
        string FriendlyName { get; set; }
        /// <summary>The value indicating whether the target compute size supports high Iops.</summary>
        string HighIopsSupported { get; set; }
        /// <summary>The Id.</summary>
        string Id { get; set; }
        /// <summary>The maximum data disks count supported by target compute size.</summary>
        int? MaxDataDiskCount { get; set; }
        /// <summary>The maximum Nics count supported by target compute size.</summary>
        int? MaxNicsCount { get; set; }
        /// <summary>The maximum memory in GB supported by target compute size.</summary>
        double? MemoryInGb { get; set; }
        /// <summary>The name.</summary>
        string Name { get; set; }
        /// <summary>Target compute size name.</summary>
        string PropertiesName { get; set; }
        /// <summary>The custom data.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITargetComputeSizeProperties Property { get; set; }
        /// <summary>The Type of the object.</summary>
        string Type { get; set; }

    }
}