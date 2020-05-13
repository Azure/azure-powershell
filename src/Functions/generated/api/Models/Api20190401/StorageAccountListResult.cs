namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>The response from the List Storage Accounts operation.</summary>
    public partial class StorageAccountListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountListResultInternal
    {

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountListResultInternal.NextLink { get => this._nextLink; set { {_nextLink = value;} } }

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccount[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccountListResultInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>
        /// Request URL that can be used to query next page of storage accounts. Returned when total number of requested storage accounts
        /// exceed maximum page size.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccount[] _value;

        /// <summary>Gets the list of storage accounts and their properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccount[] Value { get => this._value; }

        /// <summary>Creates an new <see cref="StorageAccountListResult" /> instance.</summary>
        public StorageAccountListResult()
        {

        }
    }
    /// The response from the List Storage Accounts operation.
    public partial interface IStorageAccountListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Request URL that can be used to query next page of storage accounts. Returned when total number of requested storage accounts
        /// exceed maximum page size.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Request URL that can be used to query next page of storage accounts. Returned when total number of requested storage accounts exceed maximum page size.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get;  }
        /// <summary>Gets the list of storage accounts and their properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the list of storage accounts and their properties.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccount) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccount[] Value { get;  }

    }
    /// The response from the List Storage Accounts operation.
    internal partial interface IStorageAccountListResultInternal

    {
        /// <summary>
        /// Request URL that can be used to query next page of storage accounts. Returned when total number of requested storage accounts
        /// exceed maximum page size.
        /// </summary>
        string NextLink { get; set; }
        /// <summary>Gets the list of storage accounts and their properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IStorageAccount[] Value { get; set; }

    }
}