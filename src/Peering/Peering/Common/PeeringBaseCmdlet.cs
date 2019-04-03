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
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Net.Sockets;
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Microsoft.Azure.Management.Peering;
    using Microsoft.Azure.Management.Peering.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common.Common;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;
    using Microsoft.Rest.Azure;

    /// <summary>
    ///     The InputObject base cmdlet
    /// </summary>
    public class PeeringBaseCmdlet : AzureRMCmdlet
    {
        private IPeeringManagementClient peeringClient;

        /// <summary>
        /// The PeeringClient
        /// </summary>
        public IPeeringManagementClient PeeringManagementClient
        {
            get
            {
                return this.peeringClient ?? (this.peeringClient =
                                                  AzureSession.Instance.ClientFactory.CreateArmClient<PeeringManagementClient>(
                                                      this.DefaultProfile.DefaultContext,
                                                      AzureEnvironment.Endpoint.ResourceManager));
            }

            set
            {
                this.peeringClient = value;
            }
        }

        /// <summary>
        ///     The InputObject client.
        /// </summary>
        public IPeeringsOperations PeeringClient => this.PeeringManagementClient.Peerings;

        /// <summary>
        ///     The PSPeering location client.
        /// </summary>
        public IPeeringLocationsOperations PeeringLocationClient => this.PeeringManagementClient.PeeringLocations;

        /// <summary>
        /// The peering legacy client.
        /// </summary>
        public ILegacyPeeringsOperations PeeringLegacyClient => this.PeeringManagementClient.LegacyPeerings;

        /// <summary>
        ///     The internal operations client to be used by JIT flagged users.
        /// </summary>
        public IOperations InternalOperationsClient => this.PeeringManagementClient.Operations;

        /// <summary>
        /// The to peering.
        /// </summary>
        /// <param name="resourceGroup">
        /// The resource group.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="PSPeering"/>.
        /// </returns>
        public PSPeering ToPeering(string resourceGroup, string name)
        {
            try
            {
                var ic = this.PeeringClient.Get(resourceGroup, name);

                var psPeering = PeeringResourceManagerProfile.Mapper.Map<PSPeering>(ic);
                return psPeering;
            }
            catch (InvalidOperationException mapException)
            {
                throw new InvalidOperationException($"Failed to map object {mapException}");
            }
            catch (ErrorResponseException ex)
            {
                throw new ErrorResponseException($"Error:{ex.Response.ReasonPhrase} reason:{ex.Body.Code} message:{ex.Body.Message}");
            }
        }

        /// <summary>
        /// The to peering.
        /// </summary>
        /// <param name="pSPeering">
        /// The p s peering.
        /// </param>
        /// <returns>
        /// The <see cref="PeeringModel"/>.
        /// </returns>
        public PeeringModel ToPeering(object pSPeering)
        {
            try
            {
                return PeeringResourceManagerProfile.Mapper.Map<PeeringModel>(pSPeering);
            }
            catch (InvalidOperationException mapException)
            {
                throw new InvalidOperationException($"Failed to map object {mapException}");
            }
            catch (ErrorResponseException ex)
            {
                throw new ErrorResponseException($"Error:{ex.Response.ReasonPhrase} reason:{ex.Body.Code} message:{ex.Body.Message}");
            }
        }

        /// <summary>
        /// The to peering ps.
        /// </summary>
        /// <param name="peering">
        /// The peering.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public PSPeering ToPeeringPs(object peering)
        {
            try
            {
                return PeeringResourceManagerProfile.Mapper.Map<PSPeering>(peering);
            }
            catch (InvalidOperationException mapException)
            {
                throw new InvalidOperationException($"Failed to map object {mapException}");
            }
            catch (ErrorResponseException ex)
            {
                throw new ErrorResponseException($"Error:{ex.Response.ReasonPhrase} reason:{ex.Body.Code} message:{ex.Body.Message}");
            }
        }

        public object ToPeeringAsnPs(object peeringAsn)
        {
            try
            {
                return PeeringResourceManagerProfile.Mapper.Map<PSPeerAsn>(peeringAsn);
            }
            catch (InvalidOperationException mapException)
            {
                throw new InvalidOperationException($"Failed to map object {mapException}");
            }
            catch (ErrorResponseException ex)
            {
                throw new ErrorResponseException($"Error:{ex.Response.ReasonPhrase} reason:{ex.Body.Code} message:{ex.Body.Message}");
            }
        }

        /// <summary>
        /// The top s peering location.
        /// </summary>
        /// <param name="peering">
        /// The oc.
        /// </param>
        /// <returns>
        /// The <see cref="PSPeeringLocation"/>.
        /// </returns>
        public PSPeeringLocation TopSPeeringLocation(object peering)
        {
            try
            {
                return PeeringResourceManagerProfile.Mapper.Map<PSPeeringLocation>(peering);
            }
            catch (InvalidOperationException mapException)
            {
                throw new InvalidOperationException($"Failed to map object {mapException}");
            }
            catch (ErrorResponseException ex)
            {
                throw new ErrorResponseException($"Error:{ex.Response.ReasonPhrase} reason:{ex.Body.Code} message:{ex.Body.Message}");
            }
        }

        /// <summary>
        /// The to peering asn.
        /// </summary>
        /// <param name="psPeerInfo">
        /// The ps peer info.
        /// </param>
        /// <returns>
        /// The <see cref="PeerAsn"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// </exception>
        /// <exception cref="ErrorResponseException">
        /// </exception>
        public PeerAsn ToPeeringAsn(PSPeerAsn psPeerInfo)
        {
            try
            {
                return PeeringResourceManagerProfile.Mapper.Map<PeerAsn>(psPeerInfo);
            }
            catch (InvalidOperationException mapException)
            {
                throw new InvalidOperationException($"Failed to map object {mapException}");
            }
            catch (ErrorResponseException ex)
            {
                throw new ErrorResponseException($"Error:{ex.Response.ReasonPhrase} reason:{ex.Body.Code} message:{ex.Body.Message}");
            }
        }

        /// <summary>
        /// The validate bandwidth.
        /// </summary>
        /// <param name="toValidateBandwidth"></param>
        /// <param name="peeringVlanBandwidthInMbps">
        /// The InputObject Vlan Bandwidth In Mbps.
        /// </param>
        /// <param name="defaultVlanBandwidthInMbps">
        /// The default Vlan Bandwidth In Mbps.
        /// </param>
        /// <param name="totalBandwidthInMbps">
        /// The bandwidth In Mbps.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// Incorrect bandwidth.
        /// </exception>
        public int? ValidateVlanBandwidth(
            int? toValidateBandwidth,
            int? peeringVlanBandwidthInMbps,
            int? defaultVlanBandwidthInMbps,
            int? totalBandwidthInMbps)
        {
            var i = totalBandwidthInMbps ?? peeringVlanBandwidthInMbps + defaultVlanBandwidthInMbps;
            if (toValidateBandwidth % Constants.MinRange != 0)
                throw new Exception($"VlanBandwidth:{toValidateBandwidth} must be a divisible by {Constants.MinRange}");
            if (toValidateBandwidth % Constants.MinRange == 0 && this.CompareDefaultToPeeringVlan(
                    peeringVlanBandwidthInMbps ?? 0,
                    defaultVlanBandwidthInMbps ?? 0,
                    i)) return toValidateBandwidth;
            throw new Exception("VlanBandwidth provided is not supported.");
        }

        /// <summary>
        /// The valid bandwidth.
        /// </summary>
        /// <param name="bandwidthInMbps">
        /// The bandwidth in mbps.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="PSArgumentException">
        /// </exception>
        public bool ValidBandwidth(int? bandwidthInMbps)
        {
            if (bandwidthInMbps <= 0)
                throw new PSArgumentException($"Bandwidth {bandwidthInMbps} must be greater than 0");
            if (bandwidthInMbps % Constants.MinRange != 0)
                throw new PSArgumentException(
                    $"Bandwidth {bandwidthInMbps} must have a multiple of {Constants.MinRange}.");
            if (bandwidthInMbps > Constants.MaxRange)
                throw new PSArgumentException($"Bandwidth:{bandwidthInMbps} is greater than {Constants.MaxRange}.");
            return true;
        }

        /// <summary>
        /// The compare default to InputObject vlan.
        /// </summary>
        /// <param name="PeeringVlanBandwidthInMbps">
        /// The InputObject vlan bandwidth in mbps.
        /// </param>
        /// <param name="defaultVlanBandwidthInMbps">
        /// The default vlan bandwidth in mbps.
        /// </param>
        /// <param name="bandwidthInMbps">
        /// The bandwidth In Mbps.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public bool CompareDefaultToPeeringVlan(
            int? PeeringVlanBandwidthInMbps,
            int? defaultVlanBandwidthInMbps,
            int? bandwidthInMbps)
        {
            if (PeeringVlanBandwidthInMbps + defaultVlanBandwidthInMbps == bandwidthInMbps) return true;
            throw new Exception(
                $"PeeringVlanBandwidthInMbps + DefaultVlanBandwidthInMbps({PeeringVlanBandwidthInMbps + defaultVlanBandwidthInMbps}) does not equal BandwidthInMbps ({bandwidthInMbps})");
        }

        /// <summary>
        /// The return newly created InputObject.
        /// </summary>
        /// <param name="PeeringName">
        /// The InputObject name.
        /// </param>
        /// <param name="resourceGroupName">
        /// The resource group name.
        /// </param>
        /// <returns>
        /// The <see cref="PSPeering"/>.
        /// </returns>
        public PSPeering ReturnNewlyCreatedPeering(string PeeringName, string resourceGroupName)
        {
            return PeeringResourceManagerProfile.Mapper.Map<PSPeering>(
                this.PeeringClient.Get(resourceGroupName, PeeringName));
        }

        /// <summary>
        /// The get resource group name from id.
        /// </summary>
        /// <param name="PeeringId">
        /// The InputObject id.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object GetResourceGroupNameFromId(string PeeringId)
        {
            var words = PeeringId.Split('/');
            bool isResourceGroup = false;
            foreach (var word in words)
            {
                if (!isResourceGroup)
                {
                    if (word.Equals("resourceGroups"))
                    {
                        isResourceGroup = true;
                    }
                }
                else
                {
                    return word;
                }
            }

            throw new ItemNotFoundException("No ResourceGroupName could be found for this object.");
        }

        public object GetPeeringNameFromId(string PeeringId)
        {
            var words = PeeringId.Split('/');
            bool isPeeringName = false;
            foreach (var word in words)
            {
                if (!isPeeringName)
                {
                    if (word.Equals("Peerings", StringComparison.InvariantCultureIgnoreCase))
                    {
                        isPeeringName = true;
                    }
                }
                else
                {
                    return word;
                }
            }

            throw new ItemNotFoundException("No ResourceGroupName could be found for this object.");
        }

        /// <summary>
        /// The validate prefix.
        /// </summary>
        /// <param name="routePrefix">
        /// The route prefix.
        /// </param>
        /// <param name="PeeringType">
        /// The InputObject Type.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string ValidatePrefix(string routePrefix, string PeeringType)
        {
            if (routePrefix != null)
            {
                var prefix = RoutePrefix.GetValidPrefix(routePrefix);
                switch (prefix.PrefixAddressFamily)
                {
                    case AddressFamily.InterNetwork:
                        if (PeeringType.Equals(Constants.Exchange, StringComparison.OrdinalIgnoreCase))
                        {
                            if (prefix.PrefixMaskWidth != 32)
                            {
                                throw new ArgumentOutOfRangeException($"Invalid Prefix: {routePrefix}, must be /32");
                            }
                        }
                        else
                        {
                            if (!(prefix.PrefixMaskWidth == 30 || prefix.PrefixMaskWidth == 31))
                            {
                                throw new ArgumentOutOfRangeException(
                                    $"Invalid Prefix: {routePrefix}, must be either /30 or /31");
                            }
                            else
                            {
                                var actualPrefixBigInt = prefix.ActualPrefixBigInt;
                                if (prefix.Length == 4)
                                {
                                    return prefix.StartOfPrefixBigInt + 1 == actualPrefixBigInt
                                               ? routePrefix
                                               : throw new ArgumentException(
                                                     $"Your IP address: {routePrefix} must be at least {(prefix.StartOfPrefixBigInt + 1).ToIpAddress(AddressFamily.InterNetwork)} not greater than {(prefix.EndOfPrefixBigInt).ToIpAddress(AddressFamily.InterNetwork)}");
                                }
                                else if (prefix.Length == 2)
                                {
                                    return prefix.StartOfPrefixBigInt == actualPrefixBigInt
                                               ? routePrefix
                                               : throw new ArgumentException(
                                                     $"IP address: {routePrefix} must be {(prefix.EndOfPrefixBigInt).ToIpAddress(AddressFamily.InterNetwork)} for the given IP Mask");
                                }

                                throw new ArgumentOutOfRangeException(
                                    $"IPv4 mask must be /30 or /31. IP Mask out of range {routePrefix}.");
                            }
                        }

                        return routePrefix;
                    case AddressFamily.InterNetworkV6:
                        if (PeeringType.Equals(Constants.Exchange, StringComparison.OrdinalIgnoreCase))
                        {
                            if (prefix.PrefixMaskWidth != 128)
                            {
                                throw new ArgumentOutOfRangeException($"Invalid Prefix: {routePrefix}, must be /128");
                            }
                        }
                        else
                        {
                            if (!(prefix.PrefixMaskWidth >= 64 && prefix.PrefixMaskWidth <= 127))
                            {
                                throw new ArgumentOutOfRangeException(
                                    $"IPv6 mask must be /64 - /127. IP Mask out of range {routePrefix}.");
                            }

                            switch (prefix.PrefixMaskWidth)
                            {
                                case 127:
                                    return prefix.StartOfPrefixBigInt == prefix.ActualPrefixBigInt
                                               ? routePrefix
                                               : throw new ArgumentException(
                                                     $"IP address: {routePrefix} must be "
                                                     + $"{(prefix.EndOfPrefixBigInt).ToIpAddress(AddressFamily.InterNetworkV6)} "
                                                     + "for the given IP Mask");
                                default:
                                    return prefix.StartOfPrefixBigInt + 1 >= prefix.ActualPrefixBigInt
                                               ? routePrefix
                                               : throw new ArgumentException(
                                                     $"Your IP address: {routePrefix} must be at least"
                                                     + $"{(prefix.StartOfPrefixBigInt + 1).ToIpAddress(AddressFamily.InterNetwork)} "
                                                     + $"not greater than {(prefix.EndOfPrefixBigInt).ToIpAddress(AddressFamily.InterNetwork)}");
                            }
                        }

                        return routePrefix;
                }

                throw new ArgumentOutOfRangeException($"Prefix out of range {routePrefix}.");
            }

            return null;
        }

        /// <summary>
        /// The base execute method.
        /// </summary>
        public virtual void Execute()
        {
        }

        /// <summary>
        /// Base Cmdlet execute.
        /// </summary>
        /// <exception cref="NetworkCloudException"></exception>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            try
            {
                Execute();
            }
            catch (CloudException ex)
            {
                throw new NetworkCloudException(ex);
            }
        }

        /// <summary>
        /// The get azure region.
        /// </summary>
        /// <param name="PeeringLocation">
        /// The InputObject location.
        /// </param>
        /// <param name="kind">
        /// The kind.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public string GetAzureRegion(string PeeringLocation, string kind)
        {
            try
            {
                var icList = this.PeeringLocationClient.List(kind);
                foreach (var location in icList.Select(this.TopSPeeringLocation).ToList())
                {
                    if (location.Name == PeeringLocation)
                    {
                        // For Production
                        // return location.Name == "Building40" ? "centralus" : location.AzureRegion;
                    }
                }
                // TODO remove for Production
                return "centralus";
            }
            catch
            {
                if (PeeringLocation.Equals("Building40", StringComparison.InvariantCultureIgnoreCase))
                {
                    return "centralus";
                }

                throw new Exception("Unable to map AzureRegion to InputObject location.");
            }

            throw new Exception("Unable to map AzureRegion to InputObject location.");
        }

        /// <summary>
        /// The convert to dictionary.
        /// </summary>
        /// <param name="tag">
        /// The tag.
        /// </param>
        /// <returns>
        /// The <see cref="IDictionary"/>.
        /// </returns>
        public IDictionary<string, string> ConvertToDictionary(Hashtable tag)
        {
            if (tag == null) return null;
            var dictionary = new Dictionary<string, string>();
            foreach (string key in tag?.Keys)
            {
                dictionary.Add(key, tag[key].ToString());
            }

            return dictionary;
        }

        /// <summary>
        /// The valid connection.
        /// </summary>
        /// <param name="connection">
        /// The connection.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="PSArgumentException">
        /// </exception>
        public bool ValidConnection(PSExchangeConnection connection)
        {
            if (connection.PeeringDBFacilityId <= 0)
            {
                throw new PSArgumentException(
                    $"Connection has invalid InputObject Facility ID: {connection.PeeringDBFacilityId}.");
            }

            if (connection.BgpSession == null) throw new PSArgumentException($"Session cannot be null or empty.");
            if (connection.BgpSession.PeerSessionIPv4Address == null && connection.BgpSession.MaxPrefixesAdvertisedV4 != null)
                throw new PSArgumentException(
                    $"Session V4 cannot be null if MaxPrefixesAdvertisedV4:{connection.BgpSession.MaxPrefixesAdvertisedV4} is greater and 0.");
            if (connection.BgpSession.PeerSessionIPv6Address == null && connection.BgpSession.MaxPrefixesAdvertisedV6 != null)
                throw new PSArgumentException(
                    $"Session V6 cannot be null if MaxPrefixesAdvertisedV6:{connection.BgpSession.MaxPrefixesAdvertisedV6} is greater and 0.");
            if (connection.BgpSession.MaxPrefixesAdvertisedV4 <= 0 && connection.BgpSession.SessionPrefixV4 != null)
                throw new PSArgumentException(
                    $"MaxPrefixesAdvertisedV4:{connection.BgpSession.MaxPrefixesAdvertisedV4} must be greater and 0.");
            if (connection.BgpSession.MaxPrefixesAdvertisedV6 <= 0 && connection.BgpSession.SessionPrefixV6 != null)
                throw new PSArgumentException(
                    $"MaxPrefixesAdvertisedV6:{connection.BgpSession.MaxPrefixesAdvertisedV6} must be greater and 0.");
            return true;
        }

        /// <summary>
        /// The valid connection.
        /// </summary>
        /// <param name="connection">
        /// The connection.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="PSArgumentException">
        /// </exception>
        public bool ValidConnection(PSDirectConnection connection)
        {
            if (connection.PeeringDBFacilityId <= 0)
            {
                // TODO validate facility ID with new peering
                throw new PSArgumentException(
                    $"Connection has invalid InputObject Facility ID: {connection.PeeringDBFacilityId}.");
            }

            if (connection.BgpSession == null) throw new PSArgumentException($"Session cannot be null or empty.");
            return this.ValidBandwidth(connection.BandwidthInMbps);
        }
    }
}