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
        public const string CDN = "CDN";

        /// <summary>
        /// The Direct InputObject Parameter set name.
        /// </summary>
        public const string Direct = "Direct";

        /// <summary>
        /// The exchange Parameter set name
        /// </summary>
        public const string Exchange = "Exchange";

        #endregion

        #region Ranges

        /// <summary>
        /// The min range.
        /// </summary>
        public const int MinRange = 10000;

        /// <summary>
        /// The max range.
        /// </summary>
        public const int MaxRange = 100000;

        #endregion

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
        public const string ParameterSetNameLocationByCity = "ByPeeringLocation";

        /// <summary>
        /// ParameterSetName for GetPeering
        /// </summary>
        public const string ParameterSetNamePeeringByResource = "PeeringByResource";

        /// <summary>
        /// Parameter set name for PeeringByResourceAndName
        /// </summary>
        public const string ParameterSetNamePeeringByResourceAndName = "PeeringByResourceAndName";

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

        #endregion

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
        /// PeeringLocationHelp
        /// </summary>
        public const string PeeringLocationHelp =
            "The Physical Location Different from Azure Region. Use Get-AzPeeringLocation -Kind <kind> use City name as key.";

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
        public const string UseForPeeringServiceHelp = "Enable for use with Microsoft InputObject Service (MPS).";

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

        #endregion

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
        /// The basic direct free.
        /// </summary>
        public const string BasicDirectFree = "Basic_Direct_Free";

        /// <summary>
        /// The basic exchange free.
        /// </summary>
        public const string BasicExchangeFree = "Basic_Exchange_Free";

        #endregion
    }
}