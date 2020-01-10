namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Contains bgp community information offered in Service Community resources.</summary>
    public partial class BgpCommunity :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpCommunity,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBgpCommunityInternal
    {

        /// <summary>Backing field for <see cref="CommunityName" /> property.</summary>
        private string _communityName;

        /// <summary>The name of the bgp community. e.g. Skype.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string CommunityName { get => this._communityName; set => this._communityName = value; }

        /// <summary>Backing field for <see cref="CommunityPrefix" /> property.</summary>
        private string[] _communityPrefix;

        /// <summary>The prefixes that the bgp community contains.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string[] CommunityPrefix { get => this._communityPrefix; set => this._communityPrefix = value; }

        /// <summary>Backing field for <see cref="CommunityValue" /> property.</summary>
        private string _communityValue;

        /// <summary>
        /// The value of the bgp community. For more information: https://docs.microsoft.com/en-us/azure/expressroute/expressroute-routing.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string CommunityValue { get => this._communityValue; set => this._communityValue = value; }

        /// <summary>Backing field for <see cref="IsAuthorizedToUse" /> property.</summary>
        private bool? _isAuthorizedToUse;

        /// <summary>Customer is authorized to use bgp community or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? IsAuthorizedToUse { get => this._isAuthorizedToUse; set => this._isAuthorizedToUse = value; }

        /// <summary>Backing field for <see cref="ServiceGroup" /> property.</summary>
        private string _serviceGroup;

        /// <summary>The service group of the bgp community contains.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ServiceGroup { get => this._serviceGroup; set => this._serviceGroup = value; }

        /// <summary>Backing field for <see cref="ServiceSupportedRegion" /> property.</summary>
        private string _serviceSupportedRegion;

        /// <summary>The region which the service support. e.g. For O365, region is Global.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ServiceSupportedRegion { get => this._serviceSupportedRegion; set => this._serviceSupportedRegion = value; }

        /// <summary>Creates an new <see cref="BgpCommunity" /> instance.</summary>
        public BgpCommunity()
        {

        }
    }
    /// Contains bgp community information offered in Service Community resources.
    public partial interface IBgpCommunity :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The name of the bgp community. e.g. Skype.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the bgp community. e.g. Skype.",
        SerializedName = @"communityName",
        PossibleTypes = new [] { typeof(string) })]
        string CommunityName { get; set; }
        /// <summary>The prefixes that the bgp community contains.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The prefixes that the bgp community contains.",
        SerializedName = @"communityPrefixes",
        PossibleTypes = new [] { typeof(string) })]
        string[] CommunityPrefix { get; set; }
        /// <summary>
        /// The value of the bgp community. For more information: https://docs.microsoft.com/en-us/azure/expressroute/expressroute-routing.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The value of the bgp community. For more information: https://docs.microsoft.com/en-us/azure/expressroute/expressroute-routing.",
        SerializedName = @"communityValue",
        PossibleTypes = new [] { typeof(string) })]
        string CommunityValue { get; set; }
        /// <summary>Customer is authorized to use bgp community or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Customer is authorized to use bgp community or not.",
        SerializedName = @"isAuthorizedToUse",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsAuthorizedToUse { get; set; }
        /// <summary>The service group of the bgp community contains.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The service group of the bgp community contains.",
        SerializedName = @"serviceGroup",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceGroup { get; set; }
        /// <summary>The region which the service support. e.g. For O365, region is Global.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The region which the service support. e.g. For O365, region is Global.",
        SerializedName = @"serviceSupportedRegion",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceSupportedRegion { get; set; }

    }
    /// Contains bgp community information offered in Service Community resources.
    internal partial interface IBgpCommunityInternal

    {
        /// <summary>The name of the bgp community. e.g. Skype.</summary>
        string CommunityName { get; set; }
        /// <summary>The prefixes that the bgp community contains.</summary>
        string[] CommunityPrefix { get; set; }
        /// <summary>
        /// The value of the bgp community. For more information: https://docs.microsoft.com/en-us/azure/expressroute/expressroute-routing.
        /// </summary>
        string CommunityValue { get; set; }
        /// <summary>Customer is authorized to use bgp community or not.</summary>
        bool? IsAuthorizedToUse { get; set; }
        /// <summary>The service group of the bgp community contains.</summary>
        string ServiceGroup { get; set; }
        /// <summary>The region which the service support. e.g. For O365, region is Global.</summary>
        string ServiceSupportedRegion { get; set; }

    }
}