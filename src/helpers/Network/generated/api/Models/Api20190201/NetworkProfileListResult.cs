namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Response for ListNetworkProfiles API service call.</summary>
    public partial class NetworkProfileListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkProfileListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkProfileListResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkProfile[] _value;

        /// <summary>A list of network profiles that exist in a resource group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkProfile[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="NetworkProfileListResult" /> instance.</summary>
        public NetworkProfileListResult()
        {

        }
    }
    /// Response for ListNetworkProfiles API service call.
    public partial interface INetworkProfileListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The URL to get the next set of results.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>A list of network profiles that exist in a resource group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of network profiles that exist in a resource group.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkProfile) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkProfile[] Value { get; set; }

    }
    /// Response for ListNetworkProfiles API service call.
    internal partial interface INetworkProfileListResultInternal

    {
        /// <summary>The URL to get the next set of results.</summary>
        string NextLink { get; set; }
        /// <summary>A list of network profiles that exist in a resource group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkProfile[] Value { get; set; }

    }
}