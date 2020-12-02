namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>The retention details of the MT.</summary>
    public partial class RetentionVolume :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRetentionVolume,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRetentionVolumeInternal
    {

        /// <summary>Backing field for <see cref="CapacityInByte" /> property.</summary>
        private long? _capacityInByte;

        /// <summary>The volume capacity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public long? CapacityInByte { get => this._capacityInByte; set => this._capacityInByte = value; }

        /// <summary>Backing field for <see cref="FreeSpaceInByte" /> property.</summary>
        private long? _freeSpaceInByte;

        /// <summary>The free space available in this volume.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public long? FreeSpaceInByte { get => this._freeSpaceInByte; set => this._freeSpaceInByte = value; }

        /// <summary>Backing field for <see cref="ThresholdPercentage" /> property.</summary>
        private int? _thresholdPercentage;

        /// <summary>The threshold percentage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? ThresholdPercentage { get => this._thresholdPercentage; set => this._thresholdPercentage = value; }

        /// <summary>Backing field for <see cref="VolumeName" /> property.</summary>
        private string _volumeName;

        /// <summary>The volume name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string VolumeName { get => this._volumeName; set => this._volumeName = value; }

        /// <summary>Creates an new <see cref="RetentionVolume" /> instance.</summary>
        public RetentionVolume()
        {

        }
    }
    /// The retention details of the MT.
    public partial interface IRetentionVolume :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The volume capacity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The volume capacity.",
        SerializedName = @"capacityInBytes",
        PossibleTypes = new [] { typeof(long) })]
        long? CapacityInByte { get; set; }
        /// <summary>The free space available in this volume.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The free space available in this volume.",
        SerializedName = @"freeSpaceInBytes",
        PossibleTypes = new [] { typeof(long) })]
        long? FreeSpaceInByte { get; set; }
        /// <summary>The threshold percentage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The threshold percentage.",
        SerializedName = @"thresholdPercentage",
        PossibleTypes = new [] { typeof(int) })]
        int? ThresholdPercentage { get; set; }
        /// <summary>The volume name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The volume name.",
        SerializedName = @"volumeName",
        PossibleTypes = new [] { typeof(string) })]
        string VolumeName { get; set; }

    }
    /// The retention details of the MT.
    internal partial interface IRetentionVolumeInternal

    {
        /// <summary>The volume capacity.</summary>
        long? CapacityInByte { get; set; }
        /// <summary>The free space available in this volume.</summary>
        long? FreeSpaceInByte { get; set; }
        /// <summary>The threshold percentage.</summary>
        int? ThresholdPercentage { get; set; }
        /// <summary>The volume name.</summary>
        string VolumeName { get; set; }

    }
}