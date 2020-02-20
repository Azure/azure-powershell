// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Management.WebSites.Version2016_09_01.Models;

namespace Microsoft.Azure.PowerShell.Cmdlets.Peering.Common
{
    /// <summary>
    /// The constants.
    /// </summary>
    public static class Constants
    {
        #region Kind

        /// <summary>
        /// The Partner Parameter set name
        /// </summary>
        public const string Partner = "Partner";

        /// <summary>
        /// The CDN Parameter set name.
        /// </summary>
        public const string CDN = "Cdn";

        /// <summary>
        /// The CDN Parameter set name.
        /// </summary>
        public const string Transit = "Transit";

        /// <summary>
        /// The CDN Parameter set name.
        /// </summary>
        public const string Edge = "Edge";

        /// <summary>
        /// The Direct InputObject Parameter set name.
        /// </summary>
        public const string Direct = "Direct";

        /// <summary>
        /// The exchange Parameter set name
        /// </summary>
        public const string Exchange = "Exchange";

        /// <summary>
        /// The peering service kind
        /// </summary>
        public const string PeeringService = "PeeringService";

        /// <summary>
        /// The avaliable setting
        /// </summary>
        public const string Available = "Available";

        /// <summary>
        /// The session provided address peer
        /// </summary>
        public const string Peer = "Peer";

        /// <summary>
        /// The session provided address microsoft
        /// </summary>
        public const string Microsoft = "Microsoft";

        #endregion Kind

        #region Ranges

        /// <summary>
        /// The min range.
        /// </summary>
        public const int MinRange = 10000;

        /// <summary>
        /// The max range.
        /// </summary>
        public const int MaxRange = 100000;

        #endregion Ranges

        #region ParameterSetName

        /// <summary>
        /// The parameter set name location by facility id.
        /// </summary>
        public const string ParameterSetNameLocationByFacilityId = "LocationByFacilityId";

        /// <summary>
        /// The parameter set name default.
        /// </summary>
        public const string ParameterSetNameDefault = "Default";

        /// <summary>
        /// The parameter set name location by city.
        /// </summary>
        public const string ParameterSetNameLocationByDirectType = "LocationByDirectType";

        /// <summary>
        /// ParameterSetName for GetPeering
        /// </summary>
        public const string ParameterSetNameByResourceGroupName = "ByResourceGroupName";

        /// <summary>
        /// Parameter set name for PeeringByResourceAndName
        /// </summary>
        public const string ParameterSetNameByResourceAndName = "ByResourceGroupAndName";

        /// <summary>
        /// The parameter set name by name.
        /// </summary>
        public const string ParameterSetNameByName = "ByName";

        /// <summary>
        /// The parameter set name by resource id.
        /// </summary>
        public const string ParameterSetNameByResourceId = "ByResourceId";

        /// <summary>
        /// Parameter set name PeeringByKind
        /// </summary>
        public const string ParameterSetNamePeeringByKind = "PeeringByKind";

        /// <summary>
        /// The by subscription.
        /// </summary>
        public const string ParameterSetNameBySubscription = "BySubscription";

        /// <summary>
        /// The parameter set name convert legacy InputObject.
        /// </summary>
        public const string ParameterSetNameConvertLegacyPeering = "ConvertLegacyPeering";

        /// <summary>
        /// The parameter set name i pv 6 prefix.
        /// </summary>
        public const string ParameterSetNameIPv6Prefix = "IPv6Prefix";

        /// <summary>
        /// The parameter set name for microsoft provided IP.
        /// </summary>
        public const string ParameterSetNameMicrosoftProvidedIPAddress = "ParameterSetNameMicrosoftProvidedIPAddress";

        /// <summary>
        /// The parameter set name for use for peering service
        /// </summary>
        public const string ParameterSetNameUseForPeeringService = "ParameterSetNameUseForPeeringService";

        /// <summary>
        /// The parameter set name md 5 authentication.
        /// </summary>
        public const string ParameterSetNameMd5Authentication = "Md5Authentication";

        /// <summary>
        /// The parameter set name bandwidth.
        /// </summary>
        public const string ParameterSetNameBandwidth = "Bandwidth";

        /// <summary>
        /// The parameter set name i pv 4 prefix.
        /// </summary>
        public const string ParameterSetNameIPv4Prefix = "IPv4Prefix";

        /// <summary>
        /// The parameter set name prefix by InputObject.
        /// </summary>
        public const string ParameterSetNameIPv4Address = "IPv4Address";

        /// <summary>
        /// The parameter set name prefix by prefix name.
        /// </summary>
        public const string ParameterSetNameIPv6Address = "IPv6Address";

        #endregion ParameterSetName

        #region Help

        /// <summary>
        /// ResourceGroupNameHelp
        /// </summary>
        public const string ResourceGroupNameHelp = "The create or use an existing resource group name.";

        /// <summary>
        /// The legacy item help.
        /// </summary>
        public const string LegacyItemHelp = "Use Get-AzLegacyPeering to retrieve this object.";

        /// <summary>
        /// The input item help.
        /// </summary>
        public const string PrefixInputObjectHelp = "Use a Get-AzPeeringService";

        /// <summary>
        /// The input item help.
        /// </summary>
        public const string InputObjectHelp = "Use a Get-AzPeering";

        /// <summary>
        /// The peering object help.
        /// </summary>
        public const string PeeringObjectHelp = "Use Get-AzPeering to retrieve this object.";

        /// <summary>
        /// The resource id help.
        /// </summary>
        public const string ResourceIdHelp = "The resource id string name.";

        /// <summary>
        /// PeeringNameHelp
        /// </summary>
        public const string PeeringNameHelp = "The unique name of the PSPeering.";

        /// <summary>
        /// The peer asn help.
        /// </summary>
        public const string PeerAsnHelp = "The PeerAsn object.";

        /// <summary>
        /// PeeringNameHelp
        /// </summary>
        public const string EmailsHelp = "Email Addresses used to contact if issues arrise typically a Network Operations Center";

        /// <summary>
        /// PeeringNameHelp
        /// </summary>
        public const string PhoneHelp = "Phone used to contact if issues arrise typically a Network Operations Center";

        /// <summary>
        /// The location help.
        /// </summary>
        public const string LocationHelp = "The location of the resource.";

        /// <summary>
        /// The Direct peering Type Hep
        /// </summary>
        public const string DirectPeeringTypeHelp = @"Select 'Edge', 'CDN', and 'Transit'.";

        /// <summary>
        /// PeeringLocationHelp
        /// </summary>
        public const string PeeringLocationHelp =
            "The Physical Location Different from Azure Region. Use Get-AzPeeringLocation -Kind <kind> use City name as key.";

        /// <summary>
        /// PeeringLocationHelp
        /// </summary>
        public const string PeeringServiceLocationHelp =
            "The Physical Location Different from Azure Region. Use Get-AzPeeringServiceLocation [-Country <country>]";

        /// <summary>
        /// PeeringAsnHelp
        /// </summary>
        public const string PeeringAsnHelp = "The Peer Asn Resource Id. Use Get-AzPeerAsn to retrieve the Id.";

        /// <summary>
        /// The peering db facility id help.
        /// </summary>
        public const string PeeringDbFacilityIdHelp = "The PeeringDB.com Facility ID";

        /// <summary>
        /// Gets or sets the help peering db facility id.
        /// </summary>
        public const string HelpPeeringDBFacilityId = "The peering facility Id found on https://peeringdb.com";

        /// <summary>
        /// BandwidthHelp
        /// </summary>
        public const string BandwidthHelp = "The Bandwidth offered at this location in Mbps.";

        /// <summary>
        /// Session address provider help.
        /// </summary>
        public const string SessionAddressProviderHelp = "Enable flag that tells Microsoft to provide the BGP session addresses.";

        /// <summary>
        /// AsJobHelp
        /// </summary>
        public const string AsJobHelp = "Run in the background.";

        /// <summary>
        /// The force help.
        /// </summary>
        public const string ForceHelp = "Force the operation to complete";

        /// <summary>
        /// The pass thru help.
        /// </summary>
        public const string PassThruHelp = "Return true if complete";

        /// <summary>
        /// KindHelp
        /// </summary>
        public const string KindHelp = "Shows all InputObject resource by Kind.";

        /// <summary>
        /// The use for partner peering.
        /// </summary>
        public const string UseForPeeringServiceHelp = "Enable for use with Microsoft Peering Service (MPS).";

        /// <summary>
        /// The prefix help.
        /// </summary>
        public const string PrefixHelp = "The prefix for a metro region.";

        /// <summary>
        /// The MD5 hash for authentication between the peers.
        /// </summary>
        public const string MD5AuthenticationKeyHelp = "The MD5 authentication key for session.";

        /// <summary>
        /// The metro help.
        /// </summary>
        public const string MetroHelp = "The name of the Metro.";

        /// <summary>
        /// The prefix name help.
        /// </summary>
        public const string PrefixNameHelp = "The name of prefix.";

        /// <summary>
        /// The InputObject state help.
        /// </summary>
        public const string PeeringStateHelp = "The InputObject state of a subscriber.";

        /// <summary>
        /// The peering exchange connection help.
        /// </summary>
        public const string PeeringExchangeConnectionHelp =
            "Create a new Exchange connection using the New-AzExchangePeeringConnectionObject and pipe to this command.";

        /// <summary>
        /// The peering Direct connection help.
        /// </summary>
        public const string PeeringDirectConnectionHelp =
            "Create a new Direct connections using the New-AzDirectPeeringConnectionObject and pipe to this command.";

        public const string PeeringDirectSkuHelp = "Select Basic_Direct_Free or Premium_Direct_Free unless explicitly told to select another option.";

        /// <summary>
        /// The peering direct connection index help.
        /// </summary>
        public const string PeeringDirectConnectionIndexHelp =
            "The index associated with the connection from the Get-AzPeering";

        /// <summary>
        /// The help max advertised i pv 6.
        /// </summary>
        public const string HelpMaxAdvertisedIPv6 = "The maximum advertised IPv6";

        /// <summary>
        /// The help session i pv 4 prefix.
        /// </summary>
        public const string HelpSessionIPv4Prefix = "The session IPv4 prefix";

        /// <summary>
        /// The help session i pv 6 prefix.
        /// </summary>
        public const string HelpSessionIPv6Prefix = "The session IPv6 prefix";

        /// <summary>
        /// The help peer session i pv 4 prefix.
        /// </summary>
        public const string HelpPeerSessionIPv4Prefix = "The peer session IPv4 address";

        /// <summary>
        /// The help peer session i pv 6 prefix.
        /// </summary>
        public const string HelpPeerSessionIPv6Prefix = "The peer session IPv6 address";

        /// <summary>
        /// The tags help.
        /// </summary>
        public const string TagsHelp = "The tags to associate with the Microsoft InputObject Service.";

        /// <summary>
        /// The help max advertised i pv 4.
        /// </summary>
        public const string HelpMaxAdvertisedIPv4 = "The maximum advertised IPv4";

        /// <summary>
        /// The peering country help
        /// </summary>
        public const string PeeringCountryHelp = "The country filter";

        /// <summary>
        /// The peering service provider help
        /// </summary>
        public const string PeeringServiceProviderHelp = "The peering service provider name. Use Get-AzPeeringServiceProvider cmdlet for a list";

        /// <summary>
        /// The peering service help
        /// </summary>
        public const string PeeringServiceHelp = "The peering service name. Use New-AzPeeringService cmdlet for a new peering service or Get-AzPeeringService for a list.";

        /// <summary>
        /// The peering service prefix event expand flag
        /// </summary>
        public const string PeeringServicePrefixEventHelp = "View the events for a peering service prefix";

        #endregion Help

        #region SKU

        /// <summary>
        /// The premium partner metered.
        /// </summary>
        public const string PremiumPartnerMetered = "Premium_Partner_Metered";

        /// <summary>
        /// The premium direct free.
        /// </summary>
        public const string PremiumDirectFree = "Premium_Direct_Free";

        /// <summary>
        /// The premium direct metered.
        /// </summary>
        public const string PremiumDirectMetered = "Premium_Direct_Metered";

        /// <summary>
        /// The premium direct unlimited.
        /// </summary>
        public const string PremiumDirectUnlimited = "Premium_Direct_Unlimited";

        /// <summary>
        /// The basic direct free.
        /// </summary>
        public const string BasicDirectFree = "Basic_Direct_Free";

        /// <summary>
        /// The basic exchange free.
        /// </summary>
        public const string BasicExchangeFree = "Basic_Exchange_Free";

        #endregion SKU
    }
}