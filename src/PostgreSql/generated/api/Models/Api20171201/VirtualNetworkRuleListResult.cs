namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Extensions;

    /// <summary>A list of virtual network rules.</summary>
    public partial class VirtualNetworkRuleListResult :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IVirtualNetworkRuleListResult,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IVirtualNetworkRuleListResultInternal
    {

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IVirtualNetworkRuleListResultInternal.NextLink { get => this._nextLink; set { {_nextLink = value;} } }

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IVirtualNetworkRule[] Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IVirtualNetworkRuleListResultInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>Link to retrieve next page of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IVirtualNetworkRule[] _value;

        /// <summary>Array of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IVirtualNetworkRule[] Value { get => this._value; }

        /// <summary>Creates an new <see cref="VirtualNetworkRuleListResult" /> instance.</summary>
        public VirtualNetworkRuleListResult()
        {

        }
    }
    /// A list of virtual network rules.
    public partial interface IVirtualNetworkRuleListResult :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.IJsonSerializable
    {
        /// <summary>Link to retrieve next page of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Link to retrieve next page of results.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get;  }
        /// <summary>Array of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Array of results.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IVirtualNetworkRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IVirtualNetworkRule[] Value { get;  }

    }
    /// A list of virtual network rules.
    internal partial interface IVirtualNetworkRuleListResultInternal

    {
        /// <summary>Link to retrieve next page of results.</summary>
        string NextLink { get; set; }
        /// <summary>Array of results.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.IVirtualNetworkRule[] Value { get; set; }

    }
}