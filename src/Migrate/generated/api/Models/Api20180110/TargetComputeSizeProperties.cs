namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Represents applicable recovery vm sizes properties.</summary>
    public partial class TargetComputeSizeProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITargetComputeSizeProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITargetComputeSizePropertiesInternal
    {

        /// <summary>Backing field for <see cref="CpuCoresCount" /> property.</summary>
        private int? _cpuCoresCount;

        /// <summary>The maximum cpu cores count supported by target compute size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? CpuCoresCount { get => this._cpuCoresCount; set => this._cpuCoresCount = value; }

        /// <summary>Backing field for <see cref="Error" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IComputeSizeErrorDetails[] _error;

        /// <summary>
        /// The reasons why the target compute size is not applicable for the protected item.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IComputeSizeErrorDetails[] Error { get => this._error; set => this._error = value; }

        /// <summary>Backing field for <see cref="FriendlyName" /> property.</summary>
        private string _friendlyName;

        /// <summary>Target compute size display name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string FriendlyName { get => this._friendlyName; set => this._friendlyName = value; }

        /// <summary>Backing field for <see cref="HighIopsSupported" /> property.</summary>
        private string _highIopsSupported;

        /// <summary>The value indicating whether the target compute size supports high Iops.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string HighIopsSupported { get => this._highIopsSupported; set => this._highIopsSupported = value; }

        /// <summary>Backing field for <see cref="MaxDataDiskCount" /> property.</summary>
        private int? _maxDataDiskCount;

        /// <summary>The maximum data disks count supported by target compute size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? MaxDataDiskCount { get => this._maxDataDiskCount; set => this._maxDataDiskCount = value; }

        /// <summary>Backing field for <see cref="MaxNicsCount" /> property.</summary>
        private int? _maxNicsCount;

        /// <summary>The maximum Nics count supported by target compute size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? MaxNicsCount { get => this._maxNicsCount; set => this._maxNicsCount = value; }

        /// <summary>Backing field for <see cref="MemoryInGb" /> property.</summary>
        private double? _memoryInGb;

        /// <summary>The maximum memory in GB supported by target compute size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public double? MemoryInGb { get => this._memoryInGb; set => this._memoryInGb = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Target compute size name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="TargetComputeSizeProperties" /> instance.</summary>
        public TargetComputeSizeProperties()
        {

        }
    }
    /// Represents applicable recovery vm sizes properties.
    public partial interface ITargetComputeSizeProperties :
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
        /// <summary>Target compute size name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Target compute size name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

    }
    /// Represents applicable recovery vm sizes properties.
    internal partial interface ITargetComputeSizePropertiesInternal

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
        /// <summary>The maximum data disks count supported by target compute size.</summary>
        int? MaxDataDiskCount { get; set; }
        /// <summary>The maximum Nics count supported by target compute size.</summary>
        int? MaxNicsCount { get; set; }
        /// <summary>The maximum memory in GB supported by target compute size.</summary>
        double? MemoryInGb { get; set; }
        /// <summary>Target compute size name.</summary>
        string Name { get; set; }

    }
}