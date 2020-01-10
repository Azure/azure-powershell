namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Response for the ListServiceCommunity API service call.</summary>
    public partial class BgpServiceCommunityListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpServiceCommunityListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpServiceCommunityListResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpServiceCommunity[] _value;

        /// <summary>A list of service community resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpServiceCommunity[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="BgpServiceCommunityListResult" /> instance.</summary>
        public BgpServiceCommunityListResult()
        {

        }
    }
    /// Response for the ListServiceCommunity API service call.
    public partial interface IBgpServiceCommunityListResult :
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
        /// <summary>A list of service community resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of service community resources.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpServiceCommunity) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpServiceCommunity[] Value { get; set; }

    }
    /// Response for the ListServiceCommunity API service call.
    internal partial interface IBgpServiceCommunityListResultInternal

    {
        /// <summary>The URL to get the next set of results.</summary>
        string NextLink { get; set; }
        /// <summary>A list of service community resources.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpServiceCommunity[] Value { get; set; }

    }
}