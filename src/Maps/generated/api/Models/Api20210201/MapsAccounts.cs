namespace Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Extensions;

    /// <summary>A list of Maps Accounts.</summary>
    public partial class MapsAccounts :
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccounts,
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountsInternal
    {

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccount[] Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountsInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>
        /// URL client should use to fetch the next page (per server side paging).
        /// It's null for now, added for future use.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccount[] _value;

        /// <summary>a Maps Account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccount[] Value { get => this._value; }

        /// <summary>Creates an new <see cref="MapsAccounts" /> instance.</summary>
        public MapsAccounts()
        {

        }
    }
    /// A list of Maps Accounts.
    public partial interface IMapsAccounts :
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
        /// <summary>a Maps Account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"a Maps Account.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccount) })]
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccount[] Value { get;  }

    }
    /// A list of Maps Accounts.
    internal partial interface IMapsAccountsInternal

    {
        /// <summary>
        /// URL client should use to fetch the next page (per server side paging).
        /// It's null for now, added for future use.
        /// </summary>
        string NextLink { get; set; }
        /// <summary>a Maps Account.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccount[] Value { get; set; }

    }
}