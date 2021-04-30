namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Policy Info in backupInstance</summary>
    public partial class PolicyInfo :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IPolicyInfo,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IPolicyInfoInternal
    {

        /// <summary>Internal Acessors for PolicyVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IPolicyInfoInternal.PolicyVersion { get => this._policyVersion; set { {_policyVersion = value;} } }

        /// <summary>Backing field for <see cref="PolicyId" /> property.</summary>
        private string _policyId;

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string PolicyId { get => this._policyId; set => this._policyId = value; }

        /// <summary>Backing field for <see cref="PolicyParameter" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IPolicyParameters _policyParameter;

        /// <summary>Policy parameters for the backup instance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IPolicyParameters PolicyParameter { get => (this._policyParameter = this._policyParameter ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.PolicyParameters()); set => this._policyParameter = value; }

        /// <summary>Backing field for <see cref="PolicyVersion" /> property.</summary>
        private string _policyVersion;

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string PolicyVersion { get => this._policyVersion; }

        /// <summary>Creates an new <see cref="PolicyInfo" /> instance.</summary>
        public PolicyInfo()
        {

        }
    }
    /// Policy Info in backupInstance
    public partial interface IPolicyInfo :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"policyId",
        PossibleTypes = new [] { typeof(string) })]
        string PolicyId { get; set; }
        /// <summary>Policy parameters for the backup instance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Policy parameters for the backup instance",
        SerializedName = @"policyParameters",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IPolicyParameters) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IPolicyParameters PolicyParameter { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"policyVersion",
        PossibleTypes = new [] { typeof(string) })]
        string PolicyVersion { get;  }

    }
    /// Policy Info in backupInstance
    internal partial interface IPolicyInfoInternal

    {
        string PolicyId { get; set; }
        /// <summary>Policy parameters for the backup instance</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IPolicyParameters PolicyParameter { get; set; }

        string PolicyVersion { get; set; }

    }
}