namespace Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Extensions;

    /// <summary>A list of Creator resources.</summary>
    public partial class CreatorList :
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreatorList,
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreatorListInternal
    {

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreator[] Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreatorListInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>
        /// URL client should use to fetch the next page (per server side paging).
        /// It's null for now, added for future use.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreator[] _value;

        /// <summary>a Creator account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreator[] Value { get => this._value; }

        /// <summary>Creates an new <see cref="CreatorList" /> instance.</summary>
        public CreatorList()
        {

        }
    }
    /// A list of Creator resources.
    public partial interface ICreatorList :
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
        /// <summary>a Creator account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"a Creator account.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreator) })]
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreator[] Value { get;  }

    }
    /// A list of Creator resources.
    internal partial interface ICreatorListInternal

    {
        /// <summary>
        /// URL client should use to fetch the next page (per server side paging).
        /// It's null for now, added for future use.
        /// </summary>
        string NextLink { get; set; }
        /// <summary>a Creator account.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreator[] Value { get; set; }

    }
}