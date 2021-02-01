namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>Active Directory Key Credential information.</summary>
    public partial class KeyCredential :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredentialInternal
    {

        /// <summary>Backing field for <see cref="CustomKeyIdentifier" /> property.</summary>
        private string _customKeyIdentifier;

        /// <summary>Custom Key Identifier</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string CustomKeyIdentifier { get => this._customKeyIdentifier; set => this._customKeyIdentifier = value; }

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

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>Type. Acceptable values are 'AsymmetricX509Cert' and 'Symmetric'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Backing field for <see cref="Usage" /> property.</summary>
        private string _usage;

        /// <summary>Usage. Acceptable values are 'Verify' and 'Sign'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string Usage { get => this._usage; set => this._usage = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private string _value;

        /// <summary>Key value.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="KeyCredential" /> instance.</summary>
        public KeyCredential()
        {

        }
    }
    /// Active Directory Key Credential information.
    public partial interface IKeyCredential :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IAssociativeArray<global::System.Object>
    {
        /// <summary>Custom Key Identifier</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Custom Key Identifier",
        SerializedName = @"customKeyIdentifier",
        PossibleTypes = new [] { typeof(string) })]
        string CustomKeyIdentifier { get; set; }
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
        /// <summary>Type. Acceptable values are 'AsymmetricX509Cert' and 'Symmetric'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type. Acceptable values are 'AsymmetricX509Cert' and 'Symmetric'.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get; set; }
        /// <summary>Usage. Acceptable values are 'Verify' and 'Sign'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Usage. Acceptable values are 'Verify' and 'Sign'.",
        SerializedName = @"usage",
        PossibleTypes = new [] { typeof(string) })]
        string Usage { get; set; }
        /// <summary>Key value.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Key value.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string Value { get; set; }

    }
    /// Active Directory Key Credential information.
    internal partial interface IKeyCredentialInternal

    {
        /// <summary>Custom Key Identifier</summary>
        string CustomKeyIdentifier { get; set; }
        /// <summary>End date.</summary>
        global::System.DateTime? EndDate { get; set; }
        /// <summary>Key ID.</summary>
        string KeyId { get; set; }
        /// <summary>Start date.</summary>
        global::System.DateTime? StartDate { get; set; }
        /// <summary>Type. Acceptable values are 'AsymmetricX509Cert' and 'Symmetric'.</summary>
        string Type { get; set; }
        /// <summary>Usage. Acceptable values are 'Verify' and 'Sign'.</summary>
        string Usage { get; set; }
        /// <summary>Key value.</summary>
        string Value { get; set; }

    }
}