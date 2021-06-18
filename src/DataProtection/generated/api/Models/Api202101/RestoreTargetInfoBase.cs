namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Base class common to RestoreTargetInfo and RestoreFilesTargetInfo</summary>
    public partial class RestoreTargetInfoBase :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreTargetInfoBase,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreTargetInfoBaseInternal
    {

        /// <summary>Internal Acessors for RecoveryOption</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRestoreTargetInfoBaseInternal.RecoveryOption { get => this._recoveryOption; set { {_recoveryOption = value;} } }

        /// <summary>Backing field for <see cref="ObjectType" /> property.</summary>
        private string _objectType;

        /// <summary>Type of Datasource object, used to initialize the right inherited type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string ObjectType { get => this._objectType; set => this._objectType = value; }

        /// <summary>Backing field for <see cref="RecoveryOption" /> property.</summary>
        private string _recoveryOption= @"FailIfExists";

        /// <summary>Recovery Option</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string RecoveryOption { get => this._recoveryOption; }

        /// <summary>Backing field for <see cref="RestoreLocation" /> property.</summary>
        private string _restoreLocation;

        /// <summary>Target Restore region</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string RestoreLocation { get => this._restoreLocation; set => this._restoreLocation = value; }

        /// <summary>Creates an new <see cref="RestoreTargetInfoBase" /> instance.</summary>
        public RestoreTargetInfoBase()
        {

        }
    }
    /// Base class common to RestoreTargetInfo and RestoreFilesTargetInfo
    public partial interface IRestoreTargetInfoBase :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
    {
        /// <summary>Type of Datasource object, used to initialize the right inherited type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Type of Datasource object, used to initialize the right inherited type",
        SerializedName = @"objectType",
        PossibleTypes = new [] { typeof(string) })]
        string ObjectType { get; set; }
        /// <summary>Recovery Option</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = true,
        Description = @"Recovery Option",
        SerializedName = @"recoveryOption",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryOption { get;  }
        /// <summary>Target Restore region</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Target Restore region",
        SerializedName = @"restoreLocation",
        PossibleTypes = new [] { typeof(string) })]
        string RestoreLocation { get; set; }

    }
    /// Base class common to RestoreTargetInfo and RestoreFilesTargetInfo
    internal partial interface IRestoreTargetInfoBaseInternal

    {
        /// <summary>Type of Datasource object, used to initialize the right inherited type</summary>
        string ObjectType { get; set; }
        /// <summary>Recovery Option</summary>
        string RecoveryOption { get; set; }
        /// <summary>Target Restore region</summary>
        string RestoreLocation { get; set; }

    }
}