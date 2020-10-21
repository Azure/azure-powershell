namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Disk details for E2A provider.</summary>
    public partial class AzureVMDiskDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureVMDiskDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureVMDiskDetailsInternal
    {

        /// <summary>Backing field for <see cref="LunId" /> property.</summary>
        private string _lunId;

        /// <summary>Ordinal\LunId of the disk for the Azure VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string LunId { get => this._lunId; set => this._lunId = value; }

        /// <summary>Backing field for <see cref="MaxSizeMb" /> property.</summary>
        private string _maxSizeMb;

        /// <summary>Max side in MB.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string MaxSizeMb { get => this._maxSizeMb; set => this._maxSizeMb = value; }

        /// <summary>Backing field for <see cref="TargetDiskLocation" /> property.</summary>
        private string _targetDiskLocation;

        /// <summary>Blob uri of the Azure disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string TargetDiskLocation { get => this._targetDiskLocation; set => this._targetDiskLocation = value; }

        /// <summary>Backing field for <see cref="TargetDiskName" /> property.</summary>
        private string _targetDiskName;

        /// <summary>The target Azure disk name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string TargetDiskName { get => this._targetDiskName; set => this._targetDiskName = value; }

        /// <summary>Backing field for <see cref="VhdId" /> property.</summary>
        private string _vhdId;

        /// <summary>The VHD id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string VhdId { get => this._vhdId; set => this._vhdId = value; }

        /// <summary>Backing field for <see cref="VhdName" /> property.</summary>
        private string _vhdName;

        /// <summary>VHD name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string VhdName { get => this._vhdName; set => this._vhdName = value; }

        /// <summary>Backing field for <see cref="VhdType" /> property.</summary>
        private string _vhdType;

        /// <summary>VHD type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string VhdType { get => this._vhdType; set => this._vhdType = value; }

        /// <summary>Creates an new <see cref="AzureVMDiskDetails" /> instance.</summary>
        public AzureVMDiskDetails()
        {

        }
    }
    /// Disk details for E2A provider.
    public partial interface IAzureVMDiskDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Ordinal\LunId of the disk for the Azure VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Ordinal\LunId of the disk for the Azure VM.",
        SerializedName = @"lunId",
        PossibleTypes = new [] { typeof(string) })]
        string LunId { get; set; }
        /// <summary>Max side in MB.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Max side in MB.",
        SerializedName = @"maxSizeMB",
        PossibleTypes = new [] { typeof(string) })]
        string MaxSizeMb { get; set; }
        /// <summary>Blob uri of the Azure disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Blob uri of the Azure disk.",
        SerializedName = @"targetDiskLocation",
        PossibleTypes = new [] { typeof(string) })]
        string TargetDiskLocation { get; set; }
        /// <summary>The target Azure disk name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The target Azure disk name.",
        SerializedName = @"targetDiskName",
        PossibleTypes = new [] { typeof(string) })]
        string TargetDiskName { get; set; }
        /// <summary>The VHD id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The VHD id.",
        SerializedName = @"vhdId",
        PossibleTypes = new [] { typeof(string) })]
        string VhdId { get; set; }
        /// <summary>VHD name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"VHD name.",
        SerializedName = @"vhdName",
        PossibleTypes = new [] { typeof(string) })]
        string VhdName { get; set; }
        /// <summary>VHD type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"VHD type.",
        SerializedName = @"vhdType",
        PossibleTypes = new [] { typeof(string) })]
        string VhdType { get; set; }

    }
    /// Disk details for E2A provider.
    internal partial interface IAzureVMDiskDetailsInternal

    {
        /// <summary>Ordinal\LunId of the disk for the Azure VM.</summary>
        string LunId { get; set; }
        /// <summary>Max side in MB.</summary>
        string MaxSizeMb { get; set; }
        /// <summary>Blob uri of the Azure disk.</summary>
        string TargetDiskLocation { get; set; }
        /// <summary>The target Azure disk name.</summary>
        string TargetDiskName { get; set; }
        /// <summary>The VHD id.</summary>
        string VhdId { get; set; }
        /// <summary>VHD name.</summary>
        string VhdName { get; set; }
        /// <summary>VHD type.</summary>
        string VhdType { get; set; }

    }
}