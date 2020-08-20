namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>Properties of the key vault.</summary>
    public partial class KeyVaultProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IKeyVaultProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IKeyVaultPropertiesInternal
    {

        /// <summary>Backing field for <see cref="KeyName" /> property.</summary>
        private string _keyName;

        /// <summary>The name of the key vault key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string KeyName { get => this._keyName; set => this._keyName = value; }

        /// <summary>Backing field for <see cref="KeyVaultUri" /> property.</summary>
        private string _keyVaultUri;

        /// <summary>The Uri of the key vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string KeyVaultUri { get => this._keyVaultUri; set => this._keyVaultUri = value; }

        /// <summary>Backing field for <see cref="KeyVersion" /> property.</summary>
        private string _keyVersion;

        /// <summary>The version of the key vault key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string KeyVersion { get => this._keyVersion; set => this._keyVersion = value; }

        /// <summary>Creates an new <see cref="KeyVaultProperties" /> instance.</summary>
        public KeyVaultProperties()
        {

        }
    }
    /// Properties of the key vault.
    public partial interface IKeyVaultProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
        /// <summary>The name of the key vault key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the key vault key.",
        SerializedName = @"keyName",
        PossibleTypes = new [] { typeof(string) })]
        string KeyName { get; set; }
        /// <summary>The Uri of the key vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The Uri of the key vault.",
        SerializedName = @"keyVaultUri",
        PossibleTypes = new [] { typeof(string) })]
        string KeyVaultUri { get; set; }
        /// <summary>The version of the key vault key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The version of the key vault key.",
        SerializedName = @"keyVersion",
        PossibleTypes = new [] { typeof(string) })]
        string KeyVersion { get; set; }

    }
    /// Properties of the key vault.
    internal partial interface IKeyVaultPropertiesInternal

    {
        /// <summary>The name of the key vault key.</summary>
        string KeyName { get; set; }
        /// <summary>The Uri of the key vault.</summary>
        string KeyVaultUri { get; set; }
        /// <summary>The version of the key vault key.</summary>
        string KeyVersion { get; set; }

    }
}