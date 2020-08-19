namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>VMware/Physical specific Disk Details</summary>
    public partial class InMageDiskDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageDiskDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageDiskDetailsInternal
    {

        /// <summary>Backing field for <see cref="DiskConfiguration" /> property.</summary>
        private string _diskConfiguration;

        /// <summary>Whether disk is dynamic disk or basic disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string DiskConfiguration { get => this._diskConfiguration; set => this._diskConfiguration = value; }

        /// <summary>Backing field for <see cref="DiskId" /> property.</summary>
        private string _diskId;

        /// <summary>The disk Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string DiskId { get => this._diskId; set => this._diskId = value; }

        /// <summary>Backing field for <see cref="DiskName" /> property.</summary>
        private string _diskName;

        /// <summary>The disk name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string DiskName { get => this._diskName; set => this._diskName = value; }

        /// <summary>Backing field for <see cref="DiskSizeInMb" /> property.</summary>
        private string _diskSizeInMb;

        /// <summary>The disk size in MB.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string DiskSizeInMb { get => this._diskSizeInMb; set => this._diskSizeInMb = value; }

        /// <summary>Backing field for <see cref="DiskType" /> property.</summary>
        private string _diskType;

        /// <summary>Whether disk is system disk or data disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string DiskType { get => this._diskType; set => this._diskType = value; }

        /// <summary>Backing field for <see cref="VolumeList" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskVolumeDetails[] _volumeList;

        /// <summary>Volumes of the disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskVolumeDetails[] VolumeList { get => this._volumeList; set => this._volumeList = value; }

        /// <summary>Creates an new <see cref="InMageDiskDetails" /> instance.</summary>
        public InMageDiskDetails()
        {

        }
    }
    /// VMware/Physical specific Disk Details
    public partial interface IInMageDiskDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Whether disk is dynamic disk or basic disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether disk is dynamic disk or basic disk.",
        SerializedName = @"diskConfiguration",
        PossibleTypes = new [] { typeof(string) })]
        string DiskConfiguration { get; set; }
        /// <summary>The disk Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The disk Id.",
        SerializedName = @"diskId",
        PossibleTypes = new [] { typeof(string) })]
        string DiskId { get; set; }
        /// <summary>The disk name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The disk name.",
        SerializedName = @"diskName",
        PossibleTypes = new [] { typeof(string) })]
        string DiskName { get; set; }
        /// <summary>The disk size in MB.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The disk size in MB.",
        SerializedName = @"diskSizeInMB",
        PossibleTypes = new [] { typeof(string) })]
        string DiskSizeInMb { get; set; }
        /// <summary>Whether disk is system disk or data disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether disk is system disk or data disk.",
        SerializedName = @"diskType",
        PossibleTypes = new [] { typeof(string) })]
        string DiskType { get; set; }
        /// <summary>Volumes of the disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Volumes of the disk.",
        SerializedName = @"volumeList",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskVolumeDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskVolumeDetails[] VolumeList { get; set; }

    }
    /// VMware/Physical specific Disk Details
    internal partial interface IInMageDiskDetailsInternal

    {
        /// <summary>Whether disk is dynamic disk or basic disk.</summary>
        string DiskConfiguration { get; set; }
        /// <summary>The disk Id.</summary>
        string DiskId { get; set; }
        /// <summary>The disk name.</summary>
        string DiskName { get; set; }
        /// <summary>The disk size in MB.</summary>
        string DiskSizeInMb { get; set; }
        /// <summary>Whether disk is system disk or data disk.</summary>
        string DiskType { get; set; }
        /// <summary>Volumes of the disk.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskVolumeDetails[] VolumeList { get; set; }

    }
}