namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>BackupPolicy base</summary>
    public partial class BaseBackupPolicy :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBaseBackupPolicy,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBaseBackupPolicyInternal
    {

        /// <summary>Backing field for <see cref="DatasourceType" /> property.</summary>
        private string[] _datasourceType;

        /// <summary>Type of datasource for the backup management</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string[] DatasourceType { get => this._datasourceType; set => this._datasourceType = value; }

        /// <summary>Backing field for <see cref="ObjectType" /> property.</summary>
        private string _objectType;

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string ObjectType { get => this._objectType; set => this._objectType = value; }

        /// <summary>Creates an new <see cref="BaseBackupPolicy" /> instance.</summary>
        public BaseBackupPolicy()
        {

        }
    }
    /// BackupPolicy base
    public partial interface IBaseBackupPolicy :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
    {
        /// <summary>Type of datasource for the backup management</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Type of datasource for the backup management",
        SerializedName = @"datasourceTypes",
        PossibleTypes = new [] { typeof(string) })]
        string[] DatasourceType { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"objectType",
        PossibleTypes = new [] { typeof(string) })]
        string ObjectType { get; set; }

    }
    /// BackupPolicy base
    internal partial interface IBaseBackupPolicyInternal

    {
        /// <summary>Type of datasource for the backup management</summary>
        string[] DatasourceType { get; set; }

        string ObjectType { get; set; }

    }
}