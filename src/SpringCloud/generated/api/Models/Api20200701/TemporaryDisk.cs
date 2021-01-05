namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Extensions;

    /// <summary>Temporary disk payload</summary>
    public partial class TemporaryDisk :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ITemporaryDisk,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ITemporaryDiskInternal
    {

        /// <summary>Backing field for <see cref="MountPath" /> property.</summary>
        private string _mountPath;

        /// <summary>Mount path of the temporary disk</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string MountPath { get => this._mountPath; set => this._mountPath = value; }

        /// <summary>Backing field for <see cref="SizeInGb" /> property.</summary>
        private int? _sizeInGb;

        /// <summary>Size of the temporary disk in GB</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public int? SizeInGb { get => this._sizeInGb; set => this._sizeInGb = value; }

        /// <summary>Creates an new <see cref="TemporaryDisk" /> instance.</summary>
        public TemporaryDisk()
        {

        }
    }
    /// Temporary disk payload
    public partial interface ITemporaryDisk :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IJsonSerializable
    {
        /// <summary>Mount path of the temporary disk</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Mount path of the temporary disk",
        SerializedName = @"mountPath",
        PossibleTypes = new [] { typeof(string) })]
        string MountPath { get; set; }
        /// <summary>Size of the temporary disk in GB</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Size of the temporary disk in GB",
        SerializedName = @"sizeInGB",
        PossibleTypes = new [] { typeof(int) })]
        int? SizeInGb { get; set; }

    }
    /// Temporary disk payload
    public partial interface ITemporaryDiskInternal

    {
        /// <summary>Mount path of the temporary disk</summary>
        string MountPath { get; set; }
        /// <summary>Size of the temporary disk in GB</summary>
        int? SizeInGb { get; set; }

    }
}