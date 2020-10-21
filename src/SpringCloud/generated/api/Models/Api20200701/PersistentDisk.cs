namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Extensions;

    /// <summary>Persistent disk payload</summary>
    public partial class PersistentDisk :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IPersistentDisk,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IPersistentDiskInternal
    {

        /// <summary>Internal Acessors for UsedInGb</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IPersistentDiskInternal.UsedInGb { get => this._usedInGb; set { {_usedInGb = value;} } }

        /// <summary>Backing field for <see cref="MountPath" /> property.</summary>
        private string _mountPath;

        /// <summary>Mount path of the persistent disk</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string MountPath { get => this._mountPath; set => this._mountPath = value; }

        /// <summary>Backing field for <see cref="SizeInGb" /> property.</summary>
        private int? _sizeInGb;

        /// <summary>Size of the persistent disk in GB</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public int? SizeInGb { get => this._sizeInGb; set => this._sizeInGb = value; }

        /// <summary>Backing field for <see cref="UsedInGb" /> property.</summary>
        private int? _usedInGb;

        /// <summary>Size of the used persistent disk in GB</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public int? UsedInGb { get => this._usedInGb; }

        /// <summary>Creates an new <see cref="PersistentDisk" /> instance.</summary>
        public PersistentDisk()
        {

        }
    }
    /// Persistent disk payload
    public partial interface IPersistentDisk :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IJsonSerializable
    {
        /// <summary>Mount path of the persistent disk</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Mount path of the persistent disk",
        SerializedName = @"mountPath",
        PossibleTypes = new [] { typeof(string) })]
        string MountPath { get; set; }
        /// <summary>Size of the persistent disk in GB</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Size of the persistent disk in GB",
        SerializedName = @"sizeInGB",
        PossibleTypes = new [] { typeof(int) })]
        int? SizeInGb { get; set; }
        /// <summary>Size of the used persistent disk in GB</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Size of the used persistent disk in GB",
        SerializedName = @"usedInGB",
        PossibleTypes = new [] { typeof(int) })]
        int? UsedInGb { get;  }

    }
    /// Persistent disk payload
    public partial interface IPersistentDiskInternal

    {
        /// <summary>Mount path of the persistent disk</summary>
        string MountPath { get; set; }
        /// <summary>Size of the persistent disk in GB</summary>
        int? SizeInGb { get; set; }
        /// <summary>Size of the used persistent disk in GB</summary>
        int? UsedInGb { get; set; }

    }
}