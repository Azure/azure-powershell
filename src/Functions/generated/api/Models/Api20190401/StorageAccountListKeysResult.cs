namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>The response from the ListKeys operation.</summary>
    public partial class StorageAccountListKeysResult :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountListKeysResult,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountListKeysResultInternal
    {

        /// <summary>Backing field for <see cref="Key" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountKey[] _key;

        /// <summary>
        /// Gets the list of storage account keys and their properties for the specified storage account.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountKey[] Key { get => this._key; }

        /// <summary>Internal Acessors for Key</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountKey[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountListKeysResultInternal.Key { get => this._key; set { {_key = value;} } }

        /// <summary>Creates an new <see cref="StorageAccountListKeysResult" /> instance.</summary>
        public StorageAccountListKeysResult()
        {

        }
    }
    /// The response from the ListKeys operation.
    public partial interface IStorageAccountListKeysResult :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Gets the list of storage account keys and their properties for the specified storage account.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the list of storage account keys and their properties for the specified storage account.",
        SerializedName = @"keys",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountKey) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountKey[] Key { get;  }

    }
    /// The response from the ListKeys operation.
    internal partial interface IStorageAccountListKeysResultInternal

    {
        /// <summary>
        /// Gets the list of storage account keys and their properties for the specified storage account.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountKey[] Key { get; set; }

    }
}