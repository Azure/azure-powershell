namespace Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Extensions;

    /// <summary>The set of operations available for Maps.</summary>
    public partial class MapsOperations :
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsOperations,
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsOperationsInternal
    {

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IOperationDetail[] Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsOperationsInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>
        /// URL client should use to fetch the next page (per server side paging).
        /// It's null for now, added for future use.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IOperationDetail[] _value;

        /// <summary>An operation available for Maps.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IOperationDetail[] Value { get => this._value; }

        /// <summary>Creates an new <see cref="MapsOperations" /> instance.</summary>
        public MapsOperations()
        {

        }
    }
    /// The set of operations available for Maps.
    public partial interface IMapsOperations :
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.IJsonSerializable
    {
        /// <summary>
        /// URL client should use to fetch the next page (per server side paging).
        /// It's null for now, added for future use.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"URL client should use to fetch the next page (per server side paging).
        It's null for now, added for future use.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>An operation available for Maps.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"An operation available for Maps.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IOperationDetail) })]
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IOperationDetail[] Value { get;  }

    }
    /// The set of operations available for Maps.
    internal partial interface IMapsOperationsInternal

    {
        /// <summary>
        /// URL client should use to fetch the next page (per server side paging).
        /// It's null for now, added for future use.
        /// </summary>
        string NextLink { get; set; }
        /// <summary>An operation available for Maps.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IOperationDetail[] Value { get; set; }

    }
}