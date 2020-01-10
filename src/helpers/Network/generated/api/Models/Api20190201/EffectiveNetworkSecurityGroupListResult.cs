namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Response for list effective network security groups API service call.</summary>
    public partial class EffectiveNetworkSecurityGroupListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityGroupListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityGroupListResultInternal
    {

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityGroupListResultInternal.NextLink { get => this._nextLink; set { {_nextLink = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityGroup[] _value;

        /// <summary>A list of effective network security groups.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityGroup[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="EffectiveNetworkSecurityGroupListResult" /> instance.</summary>
        public EffectiveNetworkSecurityGroupListResult()
        {

        }
    }
    /// Response for list effective network security groups API service call.
    public partial interface IEffectiveNetworkSecurityGroupListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The URL to get the next set of results.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get;  }
        /// <summary>A list of effective network security groups.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of effective network security groups.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityGroup) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityGroup[] Value { get; set; }

    }
    /// Response for list effective network security groups API service call.
    internal partial interface IEffectiveNetworkSecurityGroupListResultInternal

    {
        /// <summary>The URL to get the next set of results.</summary>
        string NextLink { get; set; }
        /// <summary>A list of effective network security groups.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityGroup[] Value { get; set; }

    }
}