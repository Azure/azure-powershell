namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Backup Instance</summary>
    public partial class BackupInstance :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupInstance,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupInstanceInternal
    {

        /// <summary>Backing field for <see cref="CurrentProtectionState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.CurrentProtectionState? _currentProtectionState;

        /// <summary>Specifies the current protection state of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.CurrentProtectionState? CurrentProtectionState { get => this._currentProtectionState; }

        /// <summary>Backing field for <see cref="DataSourceInfo" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDatasource _dataSourceInfo;

        /// <summary>Gets or sets the data source information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDatasource DataSourceInfo { get => (this._dataSourceInfo = this._dataSourceInfo ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.Datasource()); set => this._dataSourceInfo = value; }

        /// <summary>Backing field for <see cref="DataSourceSetInfo" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDatasourceSet _dataSourceSetInfo;

        /// <summary>Gets or sets the data source set information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDatasourceSet DataSourceSetInfo { get => (this._dataSourceSetInfo = this._dataSourceSetInfo ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.DatasourceSet()); set => this._dataSourceSetInfo = value; }

        /// <summary>Backing field for <see cref="FriendlyName" /> property.</summary>
        private string _friendlyName;

        /// <summary>Gets or sets the Backup Instance friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string FriendlyName { get => this._friendlyName; set => this._friendlyName = value; }

        /// <summary>Internal Acessors for CurrentProtectionState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.CurrentProtectionState? Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupInstanceInternal.CurrentProtectionState { get => this._currentProtectionState; set { {_currentProtectionState = value;} } }

        /// <summary>Internal Acessors for ProtectionErrorDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingError Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupInstanceInternal.ProtectionErrorDetail { get => (this._protectionErrorDetail = this._protectionErrorDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.UserFacingError()); set { {_protectionErrorDetail = value;} } }

        /// <summary>Internal Acessors for ProtectionStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IProtectionStatusDetails Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupInstanceInternal.ProtectionStatus { get => (this._protectionStatus = this._protectionStatus ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ProtectionStatusDetails()); set { {_protectionStatus = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupInstanceInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="ObjectType" /> property.</summary>
        private string _objectType;

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string ObjectType { get => this._objectType; set => this._objectType = value; }

        /// <summary>Backing field for <see cref="PolicyInfo" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IPolicyInfo _policyInfo;

        /// <summary>Gets or sets the policy information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IPolicyInfo PolicyInfo { get => (this._policyInfo = this._policyInfo ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.PolicyInfo()); set => this._policyInfo = value; }

        /// <summary>Backing field for <see cref="ProtectionErrorDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingError _protectionErrorDetail;

        /// <summary>Specifies the protection error of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingError ProtectionErrorDetail { get => (this._protectionErrorDetail = this._protectionErrorDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.UserFacingError()); }

        /// <summary>Backing field for <see cref="ProtectionStatus" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IProtectionStatusDetails _protectionStatus;

        /// <summary>Specifies the protection status of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IProtectionStatusDetails ProtectionStatus { get => (this._protectionStatus = this._protectionStatus ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ProtectionStatusDetails()); }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>
        /// Specifies the provisioning state of the resource i.e. provisioning/updating/Succeeded/Failed
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Creates an new <see cref="BackupInstance" /> instance.</summary>
        public BackupInstance()
        {

        }
    }
    /// Backup Instance
    public partial interface IBackupInstance :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
    {
        /// <summary>Specifies the current protection state of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies the current protection state of the resource",
        SerializedName = @"currentProtectionState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.CurrentProtectionState) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.CurrentProtectionState? CurrentProtectionState { get;  }
        /// <summary>Gets or sets the data source information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Gets or sets the data source information.",
        SerializedName = @"dataSourceInfo",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDatasource) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDatasource DataSourceInfo { get; set; }
        /// <summary>Gets or sets the data source set information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the data source set information.",
        SerializedName = @"dataSourceSetInfo",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDatasourceSet) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDatasourceSet DataSourceSetInfo { get; set; }
        /// <summary>Gets or sets the Backup Instance friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Gets or sets the Backup Instance friendly name.",
        SerializedName = @"friendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string FriendlyName { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"objectType",
        PossibleTypes = new [] { typeof(string) })]
        string ObjectType { get; set; }
        /// <summary>Gets or sets the policy information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Gets or sets the policy information.",
        SerializedName = @"policyInfo",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IPolicyInfo) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IPolicyInfo PolicyInfo { get; set; }
        /// <summary>Specifies the protection error of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies the protection error of the resource",
        SerializedName = @"protectionErrorDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingError) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingError ProtectionErrorDetail { get;  }
        /// <summary>Specifies the protection status of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies the protection status of the resource",
        SerializedName = @"protectionStatus",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IProtectionStatusDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IProtectionStatusDetails ProtectionStatus { get;  }
        /// <summary>
        /// Specifies the provisioning state of the resource i.e. provisioning/updating/Succeeded/Failed
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies the provisioning state of the resource i.e. provisioning/updating/Succeeded/Failed",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }

    }
    /// Backup Instance
    internal partial interface IBackupInstanceInternal

    {
        /// <summary>Specifies the current protection state of the resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.CurrentProtectionState? CurrentProtectionState { get; set; }
        /// <summary>Gets or sets the data source information.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDatasource DataSourceInfo { get; set; }
        /// <summary>Gets or sets the data source set information.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDatasourceSet DataSourceSetInfo { get; set; }
        /// <summary>Gets or sets the Backup Instance friendly name.</summary>
        string FriendlyName { get; set; }

        string ObjectType { get; set; }
        /// <summary>Gets or sets the policy information.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IPolicyInfo PolicyInfo { get; set; }
        /// <summary>Specifies the protection error of the resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IUserFacingError ProtectionErrorDetail { get; set; }
        /// <summary>Specifies the protection status of the resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IProtectionStatusDetails ProtectionStatus { get; set; }
        /// <summary>
        /// Specifies the provisioning state of the resource i.e. provisioning/updating/Succeeded/Failed
        /// </summary>
        string ProvisioningState { get; set; }

    }
}