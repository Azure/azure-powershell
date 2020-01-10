namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of Service Community.</summary>
    public partial class BgpServiceCommunityPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBgpServiceCommunityPropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBgpServiceCommunityPropertiesFormatInternal
    {

        /// <summary>Backing field for <see cref="BgpCommunity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBgpCommunity[] _bgpCommunity;

        /// <summary>Get a list of bgp communities.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBgpCommunity[] BgpCommunity { get => this._bgpCommunity; set => this._bgpCommunity = value; }

        /// <summary>Backing field for <see cref="ServiceName" /> property.</summary>
        private string _serviceName;

        /// <summary>The name of the bgp community. e.g. Skype.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ServiceName { get => this._serviceName; set => this._serviceName = value; }

        /// <summary>Creates an new <see cref="BgpServiceCommunityPropertiesFormat" /> instance.</summary>
        public BgpServiceCommunityPropertiesFormat()
        {

        }
    }
    /// Properties of Service Community.
    public partial interface IBgpServiceCommunityPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Get a list of bgp communities.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Get a list of bgp communities.",
        SerializedName = @"bgpCommunities",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBgpCommunity) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBgpCommunity[] BgpCommunity { get; set; }
        /// <summary>The name of the bgp community. e.g. Skype.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the bgp community. e.g. Skype.",
        SerializedName = @"serviceName",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceName { get; set; }

    }
    /// Properties of Service Community.
    internal partial interface IBgpServiceCommunityPropertiesFormatInternal

    {
        /// <summary>Get a list of bgp communities.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBgpCommunity[] BgpCommunity { get; set; }
        /// <summary>The name of the bgp community. e.g. Skype.</summary>
        string ServiceName { get; set; }

    }
}