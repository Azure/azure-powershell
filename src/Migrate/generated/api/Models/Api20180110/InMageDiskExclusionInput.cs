namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>
    /// DiskExclusionInput when doing enable protection of virtual machine in InMage provider.
    /// </summary>
    public partial class InMageDiskExclusionInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageDiskExclusionInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageDiskExclusionInputInternal
    {

        /// <summary>Backing field for <see cref="DiskSignatureOption" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageDiskSignatureExclusionOptions[] _diskSignatureOption;

        /// <summary>The guest disk signature based option for disk exclusion.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageDiskSignatureExclusionOptions[] DiskSignatureOption { get => this._diskSignatureOption; set => this._diskSignatureOption = value; }

        /// <summary>Backing field for <see cref="VolumeOption" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageVolumeExclusionOptions[] _volumeOption;

        /// <summary>The volume label based option for disk exclusion.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageVolumeExclusionOptions[] VolumeOption { get => this._volumeOption; set => this._volumeOption = value; }

        /// <summary>Creates an new <see cref="InMageDiskExclusionInput" /> instance.</summary>
        public InMageDiskExclusionInput()
        {

        }
    }
    /// DiskExclusionInput when doing enable protection of virtual machine in InMage provider.
    public partial interface IInMageDiskExclusionInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The guest disk signature based option for disk exclusion.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The guest disk signature based option for disk exclusion.",
        SerializedName = @"diskSignatureOptions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageDiskSignatureExclusionOptions) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageDiskSignatureExclusionOptions[] DiskSignatureOption { get; set; }
        /// <summary>The volume label based option for disk exclusion.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The volume label based option for disk exclusion.",
        SerializedName = @"volumeOptions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageVolumeExclusionOptions) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageVolumeExclusionOptions[] VolumeOption { get; set; }

    }
    /// DiskExclusionInput when doing enable protection of virtual machine in InMage provider.
    internal partial interface IInMageDiskExclusionInputInternal

    {
        /// <summary>The guest disk signature based option for disk exclusion.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageDiskSignatureExclusionOptions[] DiskSignatureOption { get; set; }
        /// <summary>The volume label based option for disk exclusion.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageVolumeExclusionOptions[] VolumeOption { get; set; }

    }
}