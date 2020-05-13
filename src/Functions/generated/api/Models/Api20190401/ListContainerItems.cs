namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>
    /// Response schema. Contains list of blobs returned, and if paging is requested or required, a URL to next page of containers.
    /// </summary>
    public partial class ListContainerItems :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IListContainerItems,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IListContainerItemsInternal
    {

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IListContainerItemsInternal.NextLink { get => this._nextLink; set { {_nextLink = value;} } }

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IListContainerItem[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IListContainerItemsInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>
        /// Request URL that can be used to query next page of containers. Returned when total number of requested containers exceed
        /// maximum page size.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IListContainerItem[] _value;

        /// <summary>List of blobs containers returned.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IListContainerItem[] Value { get => this._value; }

        /// <summary>Creates an new <see cref="ListContainerItems" /> instance.</summary>
        public ListContainerItems()
        {

        }
    }
    /// Response schema. Contains list of blobs returned, and if paging is requested or required, a URL to next page of containers.
    public partial interface IListContainerItems :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Request URL that can be used to query next page of containers. Returned when total number of requested containers exceed
        /// maximum page size.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Request URL that can be used to query next page of containers. Returned when total number of requested containers exceed maximum page size.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get;  }
        /// <summary>List of blobs containers returned.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of blobs containers returned.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IListContainerItem) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IListContainerItem[] Value { get;  }

    }
    /// Response schema. Contains list of blobs returned, and if paging is requested or required, a URL to next page of containers.
    internal partial interface IListContainerItemsInternal

    {
        /// <summary>
        /// Request URL that can be used to query next page of containers. Returned when total number of requested containers exceed
        /// maximum page size.
        /// </summary>
        string NextLink { get; set; }
        /// <summary>List of blobs containers returned.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IListContainerItem[] Value { get; set; }

    }
}