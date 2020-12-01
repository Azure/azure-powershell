namespace Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Extensions;

    /// <summary>A list of MySQL Server keys.</summary>
    public partial class ServerKeyListResult :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerKeyListResult,
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerKeyListResultInternal
    {

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerKeyListResultInternal.NextLink { get => this._nextLink; set { {_nextLink = value;} } }

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerKey[] Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerKeyListResultInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>Link to retrieve next page of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerKey[] _value;

        /// <summary>A list of MySQL Server keys.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerKey[] Value { get => this._value; }

        /// <summary>Creates an new <see cref="ServerKeyListResult" /> instance.</summary>
        public ServerKeyListResult()
        {

        }
    }
    /// A list of MySQL Server keys.
    public partial interface IServerKeyListResult :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.IJsonSerializable
    {
        /// <summary>Link to retrieve next page of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Link to retrieve next page of results.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get;  }
        /// <summary>A list of MySQL Server keys.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A list of MySQL Server keys.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerKey) })]
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerKey[] Value { get;  }

    }
    /// A list of MySQL Server keys.
    internal partial interface IServerKeyListResultInternal

    {
        /// <summary>Link to retrieve next page of results.</summary>
        string NextLink { get; set; }
        /// <summary>A list of MySQL Server keys.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerKey[] Value { get; set; }

    }
}