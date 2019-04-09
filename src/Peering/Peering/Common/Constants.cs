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
    /// Constants Class for Powershell 
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// None
        /// </summary>
        public const string None = "None";

        /// <summary>
        /// Active
        /// </summary>
        public const string Active = "Active";

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

        #region Positions
        /// <summary>
        /// The position InputObject location.
        /// </summary>
        public const int PositionPeeringThree = 3;

        /// <summary>
        /// The position location.
        /// </summary>
        public const int PositionPeeringTwo = 2;

        /// <summary>
        /// The position resource group name.
        /// </summary>
        public const int PositionPeeringOne = 1;

        /// <summary>
        /// The position InputObject name.
        /// </summary>
        public const int PositionPeeringZero = 0;

        #endregion

        /// <summary>
        /// Partner InputObject ParameterSetName
        /// </summary>
        public const string PeeringService = "PeeringService";

        /// <summary>
        /// Exchange InputObject ParameterSetName
        /// </summary>
        public const string ExchangePeering = "ExchangePeering";

        /// <summary>
        /// Continue Message for InputObject Removal.
        /// </summary>
        public const string ContinueMessage = "You are about to remove an InputObject Resource. Are you sure?";

        /// <summary>
        /// Processing Message for InputObject Removal.
        /// </summary>
        public const string ProcessMessage = "InputObject {PeeringName} Resource being removed.";

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
        public const string ParameterSetNameLocationByFacilityId = "ParameterSetNameLocationByFacilityId";

        /// <summary>
        /// The parameter set name default.
        /// </summary>
        public const string ParameterSetNameDefault = "ParameterSetNameDefault";

        /// <summary>
        /// The parameter set name update phone.
        /// </summary>
        public const string ParameterSetNameUpdatePhone = "ParameterSetNameUpdatePhone";

        /// <summary>
        /// The parameter set name use for peering service.
        /// </summary>
        public const string ParameterSetNameUseForPeeringService = "ParameterSetNameUseForPeeringService";

        /// <summary>
        /// The parameter set name location by city.
        /// </summary>
        public const string ParameterSetNameLocationByCity = "ParameterSetNameLocationByCity";

        /// <summary>
        /// DeviceAAndBWithDefaultVlan ParameterSetName Enum 1
        /// </summary>
        public const string DeviceAWithDefaultVlan = "DeviceAWithDefaultVlan";

        /// <summary>
        /// DeviceAAndBWithDefaultVlan ParameterSetName Enum 2
        /// </summary>
        public const string DeviceBWithDefaultVlan = "DeviceBWithDefaultVlan";

        /// <summary>
        /// VlanAI ParameterSetName Enum 4
        /// </summary>
        public const string DeviceAWithPeeringVlan = "DeviceAWithPeeringVlan";

        /// <summary>
        /// VlanAI ParameterSetName Enum 6
        /// </summary>
        public const string DeviceBWithPeeringVlan = "DeviceBWithPeeringVlan";

        /// <summary>
        /// DeviceAAndBWithDefaultVlan ParameterSetName Enum 3
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const string DeviceAAndBWithDefaultVlan = "DeviceAAndBWithDefaultVlan";

        /// <summary>
        /// VlanAandBI ParameterSetName Enum 10
        /// </summary>
        public const string DeviceAAndBWithPeeringVlan = "DeviceAAndBWithPeeringVlan";

        /// <summary>
        /// DeviceAWithDefaultAndPeeringVlan ParameterSetName Enum 5
        /// </summary>
        public const string DeviceAWithDefaultAndPeeringVlan = "DeviceAWithDefaultAndPeeringVlan";

        /// <summary>
        /// DeviceAWithDefaultAndPeeringVlan ParameterSetName Enum 8
        /// </summary>
        public const string DeviceBWithDefaultAndPeeringVlan = "DeviceBWithDefaultAndPeeringVlan";

        /// <summary>
        /// DeviceAAndBWithDefaultAndPeeringVlan ParameterSetName Enum 13
        /// </summary>
        public const string DeviceAAndBWithDefaultAndPeeringVlan = "DeviceAAndBWithDefaultAndPeeringVlan";

        // With V6 mandatory

        /// <summary>
        /// The device A with InputObject with v6.
        /// </summary>
        public const string DeviceAAndBWithPeeringVlanV6 = "DeviceAAndBWithPeeringVlanV6";

        /// <summary>
        /// The device a and b with default and InputObject vlan v 6.
        /// </summary>
        public const string DeviceAAndBWithDefaultAndPeeringVlanV6 = "DeviceAAndBWithDefaultAndPeeringVlanV6";

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
        public const string ParameterSetNameByName = "ParameterSetNameByName";

        public const string ParameterSetNameByResourceId = "ParameterSetNameByResourceId";

        /// <summary>
        /// Parameter set name PeeringByKind
        /// </summary>
        public const string ParameterSetNamePeeringByKind = "PeeringByKind";

        /// <summary>
        /// The by subscription.
        /// </summary>
        public const string ParameterSetNameBySubscription = "BySubscription";

        /// <summary>
        /// The parameter set name prefix.
        /// </summary>
        public const string ParameterSetNameUpdateEmail = "ParameterSetNameUpdateContact";

        /// <summary>
        /// The parameter set name convert legacy InputObject.
        /// </summary>
        public const string ParameterSetNameConvertLegacyPeering = "ParameterSetNameConvertLegacyPeering";

        /// <summary>
        /// The parameter set name i pv 6 prefix.
        /// </summary>
        public const string ParameterSetNameIPv6Prefix = "ParameterSetNameIPv6Prefix";

        /// <summary>
        /// The parameter set name md 5 authentication.
        /// </summary>
        public const string ParameterSetNameMd5Authentication = "ParameterSetNameMd5Authentication";

        /// <summary>
        /// The parameter set name bandwidth.
        /// </summary>
        public const string ParameterSetNameBandwidth = "ParameterSetNameBandwidth";

        /// <summary>
        /// The parameter set name i pv 4 prefix.
        /// </summary>
        public const string ParameterSetNameIPv4Prefix = "ParameterSetNameIPv4Prefix";

        /// <summary>
        /// The parameter set name prefix by InputObject.
        /// </summary>
        public const string ParameterSetNameIPv4Address = "ParameterSetNameIPv4Address";

        /// <summary>
        /// The parameter set name prefix by prefix name.
        /// </summary>
        public const string ParameterSetNameIPv6Address = "ParameterSetNameIPv6Address";

        #endregion

        #region Help
        //Help Messages 
        /// <summary>
        /// ResourceGroupNameHelp
        /// </summary>
        public const string ResourceGroupNameHelp = "The resource group name.";

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
        public const string EmailsHelp = "Email";

        /// <summary>
        /// PeeringNameHelp
        /// </summary>
        public const string PhoneHelp = "Phone";

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
        public const string PeeringAsnHelp =
            "The Peer Asn Resource Id. Use Get-AzPeerAsn to retrieve the Id.";

        /// <summary>
        /// The peering db facility id help.
        /// </summary>
        public const string PeeringDbFacilityIdHelp = "The PeeringDB.com Facility ID";

        /// <summary>
        /// HelpSku
        /// </summary>
        public const string HelpSku = "The SKU Tier.";

        /// <summary>
        /// Gets or sets the help peering db facility id.
        /// </summary>
        public const string HelpPeeringDBFacilityId = "The peering facility Id found on https://peeringdb.com";

        /// <summary>
        /// IPv4Help
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const string IPv4Help = "The IPv4 session Prefix.";

        /// <summary>
        /// IPv6Help
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const string IPv6Help = "TheIPv6sessionPrefix.";

        /// <summary>
        /// BandwidthHelp
        /// </summary>
        public const string BandwidthHelp = "The Bandwidth offered at this location in Mbps.";

        /// <summary>
        /// AsJobHelp
        /// </summary>
        public const string AsJobHelp = "Run in the background.";

        /// <summary>
        /// KindHelp
        /// </summary>
        public const string KindHelp = "Shows all InputObject resource by Kind.";

        /// <summary>
        /// The use for partner peering.
        /// </summary>
        public const string UseForPeeringServiceHelp = "Enable for use with Microsoft InputObject Service (MPS).";

        /// <summary>
        /// SubscriberNameHelp
        /// </summary>
        public const string SubscriberNameHelp = "Name of carrier subscriber.";

        /// <summary>
        /// ProvisionedBandwidthHelp
        /// </summary>
        public const string ProvisionedBandwidthHelp = "The Bandwidth offered at this location in chunks of 10000 Mbps";

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
        public const string PeeringExchangeConnectionHelp = "Create a new Exchange connection using the New-AzExchangePeeringConnectionObject and pipe to this command.";

        /// <summary>
        /// The peering Direct connection help.
        /// </summary>
        public const string PeeringDirectConnectionHelp = "Create a new Direct connections using the New-AzDirectPeeringConnectionObject and pipe to this command.";

        /// <summary>
        /// The peering direct connection index help.
        /// </summary>
        public const string PeeringDirectConnectionIndexHelp = "The index associated with the connection from the Get-AzPeering";

        /// <summary>
        /// The help max advertised i pv 6.
        /// </summary>
        public const string HelpMaxAdvertisedIPv6 = "HelpMaxAdvertisedIPv6";

        /// <summary>
        /// The help session i pv 4 prefix.
        /// </summary>
        public const string HelpSessionIPv4Prefix = "HelpSessionIPv4Prefix";

        /// <summary>
        /// The help session i pv 6 prefix.
        /// </summary>
        public const string HelpSessionIPv6Prefix = "HelpSessionIPv6Prefix";

        /// <summary>
        /// The help peer session i pv 4 prefix.
        /// </summary>
        public const string HelpPeerSessionIPv4Prefix = "HelpPeerSessionIPv4Prefix";

        /// <summary>
        /// The help peer session i pv 6 prefix.
        /// </summary>
        public const string HelpPeerSessionIPv6Prefix = "HelpPeerSessionIPv6Prefix";

        /// <summary>
        /// The tags help.
        /// </summary>
        public const string TagsHelp = "The tags to associate with the Microsoft InputObject Service.";

        /// <summary>
        /// The help max advertised i pv 4.
        /// </summary>
        public const string HelpMaxAdvertisedIPv4 = "HelpMaxAdvertisedIPv4";

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