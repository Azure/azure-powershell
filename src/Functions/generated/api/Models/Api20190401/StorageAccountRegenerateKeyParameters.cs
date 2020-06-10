namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>The parameters used to regenerate the storage account key.</summary>
    public partial class StorageAccountRegenerateKeyParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountRegenerateKeyParameters,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountRegenerateKeyParametersInternal
    {

        /// <summary>Backing field for <see cref="KeyName" /> property.</summary>
        private string _keyName;

        /// <summary>
        /// The name of storage keys that want to be regenerated, possible values are key1, key2, kerb1, kerb2.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string KeyName { get => this._keyName; set => this._keyName = value; }

        /// <summary>Creates an new <see cref="StorageAccountRegenerateKeyParameters" /> instance.</summary>
        public StorageAccountRegenerateKeyParameters()
        {

        }
    }
    /// The parameters used to regenerate the storage account key.
    public partial interface IStorageAccountRegenerateKeyParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The name of storage keys that want to be regenerated, possible values are key1, key2, kerb1, kerb2.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of storage keys that want to be regenerated, possible values are key1, key2, kerb1, kerb2.",
        SerializedName = @"keyName",
        PossibleTypes = new [] { typeof(string) })]
        string KeyName { get; set; }

    }
    /// The parameters used to regenerate the storage account key.
    internal partial interface IStorageAccountRegenerateKeyParametersInternal

    {
        /// <summary>
        /// The name of storage keys that want to be regenerated, possible values are key1, key2, kerb1, kerb2.
        /// </summary>
        string KeyName { get; set; }

    }
}