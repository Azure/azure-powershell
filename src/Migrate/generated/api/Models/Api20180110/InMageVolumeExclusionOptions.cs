namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>
    /// Guest disk signature based disk exclusion option when doing enable protection of virtual machine in InMage provider.
    /// </summary>
    public partial class InMageVolumeExclusionOptions :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageVolumeExclusionOptions,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageVolumeExclusionOptionsInternal
    {

        /// <summary>Backing field for <see cref="OnlyExcludeIfSingleVolume" /> property.</summary>
        private string _onlyExcludeIfSingleVolume;

        /// <summary>
        /// The value indicating whether to exclude multi volume disk or not. If a disk has multiple volumes and one of the volume
        /// has label matching with VolumeLabel this disk will be excluded from replication if OnlyExcludeIfSingleVolume is false.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string OnlyExcludeIfSingleVolume { get => this._onlyExcludeIfSingleVolume; set => this._onlyExcludeIfSingleVolume = value; }

        /// <summary>Backing field for <see cref="VolumeLabel" /> property.</summary>
        private string _volumeLabel;

        /// <summary>
        /// The volume label. The disk having any volume with this label will be excluded from replication.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string VolumeLabel { get => this._volumeLabel; set => this._volumeLabel = value; }

        /// <summary>Creates an new <see cref="InMageVolumeExclusionOptions" /> instance.</summary>
        public InMageVolumeExclusionOptions()
        {

        }
    }
    /// Guest disk signature based disk exclusion option when doing enable protection of virtual machine in InMage provider.
    public partial interface IInMageVolumeExclusionOptions :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The value indicating whether to exclude multi volume disk or not. If a disk has multiple volumes and one of the volume
        /// has label matching with VolumeLabel this disk will be excluded from replication if OnlyExcludeIfSingleVolume is false.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The value indicating whether to exclude multi volume disk or not. If a disk has multiple volumes and one of the volume has label matching with VolumeLabel this disk will be excluded from replication if OnlyExcludeIfSingleVolume is false.",
        SerializedName = @"onlyExcludeIfSingleVolume",
        PossibleTypes = new [] { typeof(string) })]
        string OnlyExcludeIfSingleVolume { get; set; }
        /// <summary>
        /// The volume label. The disk having any volume with this label will be excluded from replication.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The volume label. The disk having any volume with this label will be excluded from replication.",
        SerializedName = @"volumeLabel",
        PossibleTypes = new [] { typeof(string) })]
        string VolumeLabel { get; set; }

    }
    /// Guest disk signature based disk exclusion option when doing enable protection of virtual machine in InMage provider.
    internal partial interface IInMageVolumeExclusionOptionsInternal

    {
        /// <summary>
        /// The value indicating whether to exclude multi volume disk or not. If a disk has multiple volumes and one of the volume
        /// has label matching with VolumeLabel this disk will be excluded from replication if OnlyExcludeIfSingleVolume is false.
        /// </summary>
        string OnlyExcludeIfSingleVolume { get; set; }
        /// <summary>
        /// The volume label. The disk having any volume with this label will be excluded from replication.
        /// </summary>
        string VolumeLabel { get; set; }

    }
}