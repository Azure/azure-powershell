namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>Active Directory Password Credential information.</summary>
    public partial class PasswordCredential :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredentialInternal
    {

        /// <summary>Backing field for <see cref="CustomKeyIdentifier" /> property.</summary>
        private byte[] _customKeyIdentifier;

        /// <summary>Custom Key Identifier</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public byte[] CustomKeyIdentifier { get => this._customKeyIdentifier; set => this._customKeyIdentifier = value; }

        /// <summary>Backing field for <see cref="EndDate" /> property.</summary>
        private global::System.DateTime? _endDate;

        /// <summary>End date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public global::System.DateTime? EndDate { get => this._endDate; set => this._endDate = value; }

        /// <summary>Backing field for <see cref="KeyId" /> property.</summary>
        private string _keyId;

        /// <summary>Key ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string KeyId { get => this._keyId; set => this._keyId = value; }

        /// <summary>Backing field for <see cref="StartDate" /> property.</summary>
        private global::System.DateTime? _startDate;

        /// <summary>Start date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public global::System.DateTime? StartDate { get => this._startDate; set => this._startDate = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private string _value;

        /// <summary>Key value.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="PasswordCredential" /> instance.</summary>
        public PasswordCredential()
        {

        }
    }
    /// Active Directory Password Credential information.
    public partial interface IPasswordCredential :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IAssociativeArray<global::System.Object>
    {
        /// <summary>Custom Key Identifier</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Custom Key Identifier",
        SerializedName = @"customKeyIdentifier",
        PossibleTypes = new [] { typeof(byte[]) })]
        byte[] CustomKeyIdentifier { get; set; }
        /// <summary>End date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"End date.",
        SerializedName = @"endDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? EndDate { get; set; }
        /// <summary>Key ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Key ID.",
        SerializedName = @"keyId",
        PossibleTypes = new [] { typeof(string) })]
        string KeyId { get; set; }
        /// <summary>Start date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Start date.",
        SerializedName = @"startDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? StartDate { get; set; }
        /// <summary>Key value.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Key value.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string Value { get; set; }

    }
    /// Active Directory Password Credential information.
    internal partial interface IPasswordCredentialInternal

    {
        /// <summary>Custom Key Identifier</summary>
        byte[] CustomKeyIdentifier { get; set; }
        /// <summary>End date.</summary>
        global::System.DateTime? EndDate { get; set; }
        /// <summary>Key ID.</summary>
        string KeyId { get; set; }
        /// <summary>Start date.</summary>
        global::System.DateTime? StartDate { get; set; }
        /// <summary>Key value.</summary>
        string Value { get; set; }

    }
}