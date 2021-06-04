namespace Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Extensions;

    /// <summary>List of operations supported by the RP.</summary>
    public partial class StoragePoolOperationListResult :
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IStoragePoolOperationListResult,
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IStoragePoolOperationListResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>URI to fetch the next section of the paginated response.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IStoragePoolRpOperation[] _value;

        /// <summary>An array of operations supported by the StoragePool RP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IStoragePoolRpOperation[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="StoragePoolOperationListResult" /> instance.</summary>
        public StoragePoolOperationListResult()
        {

        }
    }
    /// List of operations supported by the RP.
    public partial interface IStoragePoolOperationListResult :
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.IJsonSerializable
    {
        /// <summary>URI to fetch the next section of the paginated response.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"URI to fetch the next section of the paginated response.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>An array of operations supported by the StoragePool RP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"An array of operations supported by the StoragePool RP.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IStoragePoolRpOperation) })]
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IStoragePoolRpOperation[] Value { get; set; }

    }
    /// List of operations supported by the RP.
    internal partial interface IStoragePoolOperationListResultInternal

    {
        /// <summary>URI to fetch the next section of the paginated response.</summary>
        string NextLink { get; set; }
        /// <summary>An array of operations supported by the StoragePool RP.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IStoragePoolRpOperation[] Value { get; set; }

    }
}