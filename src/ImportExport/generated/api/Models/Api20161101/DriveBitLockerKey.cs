namespace Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Extensions;

    /// <summary>BitLocker recovery key or password to the specified drive</summary>
    public partial class DriveBitLockerKey :
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveBitLockerKey,
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveBitLockerKeyInternal
    {

        /// <summary>Backing field for <see cref="BitLockerKey" /> property.</summary>
        private string _bitLockerKey;

        /// <summary>BitLocker recovery key or password</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string BitLockerKey { get => this._bitLockerKey; set => this._bitLockerKey = value; }

        /// <summary>Backing field for <see cref="DriveId" /> property.</summary>
        private string _driveId;

        /// <summary>Drive ID</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string DriveId { get => this._driveId; set => this._driveId = value; }

        /// <summary>Creates an new <see cref="DriveBitLockerKey" /> instance.</summary>
        public DriveBitLockerKey()
        {

        }
    }
    /// BitLocker recovery key or password to the specified drive
    public partial interface IDriveBitLockerKey :
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.IJsonSerializable
    {
        /// <summary>BitLocker recovery key or password</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"BitLocker recovery key or password",
        SerializedName = @"bitLockerKey",
        PossibleTypes = new [] { typeof(string) })]
        string BitLockerKey { get; set; }
        /// <summary>Drive ID</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Drive ID",
        SerializedName = @"driveId",
        PossibleTypes = new [] { typeof(string) })]
        string DriveId { get; set; }

    }
    /// BitLocker recovery key or password to the specified drive
    internal partial interface IDriveBitLockerKeyInternal

    {
        /// <summary>BitLocker recovery key or password</summary>
        string BitLockerKey { get; set; }
        /// <summary>Drive ID</summary>
        string DriveId { get; set; }

    }
}