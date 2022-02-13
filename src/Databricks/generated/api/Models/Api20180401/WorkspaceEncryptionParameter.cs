namespace Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Extensions;

    /// <summary>The object that contains details of encryption used on the workspace.</summary>
    public partial class WorkspaceEncryptionParameter :
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceEncryptionParameter,
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceEncryptionParameterInternal
    {

        /// <summary>Internal Acessors for Type</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceEncryptionParameterInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IEncryption Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceEncryptionParameterInternal.Value { get => (this._value = this._value ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.Encryption()); set { {_value = value;} } }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? _type;

        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? Type { get => this._type; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IEncryption _value;

        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IEncryption Value { get => (this._value = this._value ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.Encryption()); set => this._value = value; }

        /// <summary>The name of KeyVault key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string ValueKeyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IEncryptionInternal)Value).KeyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IEncryptionInternal)Value).KeyName = value ?? null; }

        /// <summary>
        /// The encryption keySource (provider). Possible values (case-insensitive): Default, Microsoft.Keyvault
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.KeySource? ValueKeySource { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IEncryptionInternal)Value).KeySource; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IEncryptionInternal)Value).KeySource = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.KeySource)""); }

        /// <summary>The Uri of KeyVault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string ValueKeyVaultUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IEncryptionInternal)Value).KeyVaultUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IEncryptionInternal)Value).KeyVaultUri = value ?? null; }

        /// <summary>The version of KeyVault key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Inlined)]
        public string ValueKeyVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IEncryptionInternal)Value).KeyVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IEncryptionInternal)Value).KeyVersion = value ?? null; }

        /// <summary>Creates an new <see cref="WorkspaceEncryptionParameter" /> instance.</summary>
        public WorkspaceEncryptionParameter()
        {

        }
    }
    /// The object that contains details of encryption used on the workspace.
    public partial interface IWorkspaceEncryptionParameter :
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.IJsonSerializable
    {
        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The type of variable that this is",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? Type { get;  }
        /// <summary>The name of KeyVault key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of KeyVault key.",
        SerializedName = @"KeyName",
        PossibleTypes = new [] { typeof(string) })]
        string ValueKeyName { get; set; }
        /// <summary>
        /// The encryption keySource (provider). Possible values (case-insensitive): Default, Microsoft.Keyvault
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The encryption keySource (provider). Possible values (case-insensitive):  Default, Microsoft.Keyvault",
        SerializedName = @"keySource",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.KeySource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.KeySource? ValueKeySource { get; set; }
        /// <summary>The Uri of KeyVault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Uri of KeyVault.",
        SerializedName = @"keyvaulturi",
        PossibleTypes = new [] { typeof(string) })]
        string ValueKeyVaultUri { get; set; }
        /// <summary>The version of KeyVault key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The version of KeyVault key.",
        SerializedName = @"keyversion",
        PossibleTypes = new [] { typeof(string) })]
        string ValueKeyVersion { get; set; }

    }
    /// The object that contains details of encryption used on the workspace.
    internal partial interface IWorkspaceEncryptionParameterInternal

    {
        /// <summary>The type of variable that this is</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? Type { get; set; }
        /// <summary>The value which should be used for this field.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IEncryption Value { get; set; }
        /// <summary>The name of KeyVault key.</summary>
        string ValueKeyName { get; set; }
        /// <summary>
        /// The encryption keySource (provider). Possible values (case-insensitive): Default, Microsoft.Keyvault
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.KeySource? ValueKeySource { get; set; }
        /// <summary>The Uri of KeyVault.</summary>
        string ValueKeyVaultUri { get; set; }
        /// <summary>The version of KeyVault key.</summary>
        string ValueKeyVersion { get; set; }

    }
}