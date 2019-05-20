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
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Net.Sockets;

    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
    using Microsoft.Azure.Commands.Peering.Properties;
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Microsoft.Azure.Management.Peering;
    using Microsoft.Azure.Management.Peering.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;

    using Newtonsoft.Json;

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
            get =>
                this.peeringClient ?? (this.peeringClient =
                                           AzureSession.Instance.ClientFactory.CreateArmClient<PeeringManagementClient>(
                                               this.DefaultProfile.DefaultContext,
                                               AzureEnvironment.Endpoint.ResourceManager));

            set => this.peeringClient = value;
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
                throw new InvalidOperationException(String.Format(Resources.Error_Mapping, mapException));
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
                throw new InvalidOperationException(String.Format(Resources.Error_Mapping, mapException));
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
                throw new InvalidOperationException(string.Format(Resources.Error_Mapping, mapException));
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
                throw new InvalidOperationException(String.Format(Resources.Error_Mapping, mapException));
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
                throw new InvalidOperationException(String.Format(Resources.Error_Mapping, mapException));
            }
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
                throw new PSArgumentException(string.Format(Resources.Error_BandwidthTooLow, bandwidthInMbps));
            if (bandwidthInMbps % Constants.MinRange != 0)
                throw new PSArgumentException(
                    string.Format(Resources.Error_BandwidthIncorrectFormat, bandwidthInMbps, Constants.MinRange));
            if (bandwidthInMbps > Constants.MaxRange)
                throw new PSArgumentException(
                    string.Format(Resources.Error_BandwidthTooHigh, bandwidthInMbps, Constants.MaxRange));
            return true;
        }

        /// <summary>
        /// The valid upgrade bandwidth.
        /// </summary>
        /// <param name="startingBandwidth">
        /// The starting bandwidth.
        /// </param>
        /// <param name="newBandwidth">
        /// The new bandwidth.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="PSNotSupportedException">
        /// </exception>
        public bool ValidUpgradeBandwidth(int? startingBandwidth, int? newBandwidth)
        {
            if (!this.ValidBandwidth(newBandwidth))
                return false;
            if (newBandwidth <= (startingBandwidth ?? 0))
                throw new PSNotSupportedException(
                    string.Format(Resources.Error_BandwidthDowngrade, startingBandwidth, newBandwidth));
            return true;
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
                                throw new PSArgumentOutOfRangeException(
                                    string.Format(Resources.Error_InvalidPrefix, routePrefix, "/32"));
                            }
                        }
                        else
                        {
                            if (!(prefix.PrefixMaskWidth == 30 || prefix.PrefixMaskWidth == 31))
                            {
                                throw new PSArgumentOutOfRangeException(
                                    string.Format(Resources.Error_InvalidPrefix, routePrefix, "either /30 or /31"));
                            }
                            else
                            {
                                var actualPrefixBigInt = prefix.ActualPrefixBigInt;
                                if (prefix.Length == 4)
                                {
                                    return prefix.StartOfPrefixBigInt + 1 == actualPrefixBigInt
                                               ? routePrefix
                                               : throw new PSArgumentException(
                                                     string.Format(
                                                         Resources.Error_InvalidPrefixRange,
                                                         routePrefix,
                                                         (prefix.StartOfPrefixBigInt + 1).ToIpAddress(
                                                             AddressFamily.InterNetwork),
                                                         (prefix.EndOfPrefixBigInt).ToIpAddress(
                                                             AddressFamily.InterNetwork)));
                                }
                                else if (prefix.Length == 2)
                                {
                                    return prefix.StartOfPrefixBigInt == actualPrefixBigInt
                                               ? routePrefix
                                               : throw new PSArgumentException(
                                                     string.Format(
                                                         Resources.Error_InvalidPrefix,
                                                         routePrefix,
                                                         (prefix.EndOfPrefixBigInt - 1).ToIpAddress(
                                                             AddressFamily.InterNetwork)));
                                }

                                throw new PSArgumentOutOfRangeException(
                                    string.Format(Resources.Error_InvalidPrefixRange, routePrefix, "/30", "/31"));
                            }
                        }

                        return routePrefix;
                    case AddressFamily.InterNetworkV6:
                        if (PeeringType.Equals(Constants.Exchange, StringComparison.OrdinalIgnoreCase))
                        {
                            if (prefix.PrefixMaskWidth != 128)
                            {
                                throw new PSArgumentOutOfRangeException(
                                    string.Format(Resources.Error_InvalidPrefix, routePrefix, "/128"));
                            }
                        }
                        else
                        {
                            if (!(prefix.PrefixMaskWidth >= 64 && prefix.PrefixMaskWidth <= 127))
                            {
                                throw new PSArgumentOutOfRangeException(
                                    string.Format(Resources.Error_InvalidPrefixRange, routePrefix, "/64", "/127"));
                            }

                            switch (prefix.PrefixMaskWidth)
                            {
                                case 127:
                                    return prefix.StartOfPrefixBigInt == prefix.ActualPrefixBigInt
                                               ? routePrefix
                                               : throw new PSArgumentException(
                                                     string.Format(
                                                         Resources.Error_InvalidPrefix,
                                                         routePrefix,
                                                         (prefix.EndOfPrefixBigInt).ToIpAddress(
                                                             AddressFamily.InterNetworkV6)));
                                default:
                                    return prefix.StartOfPrefixBigInt + 1 <= prefix.ActualPrefixBigInt
                                               ? routePrefix
                                               : throw new ArgumentException(
                                                     string.Format(
                                                         Resources.Error_InvalidPrefixRange,
                                                         routePrefix,
                                                         (prefix.StartOfPrefixBigInt + 1).ToIpAddress(
                                                             AddressFamily.InterNetworkV6),
                                                         (prefix.EndOfPrefixBigInt).ToIpAddress(
                                                             AddressFamily.InterNetworkV6)));
                            }
                        }

                        return routePrefix;
                }
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
        /// <exception cref="NetworkErrorResponseException"></exception>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            this.Execute();

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
        public string GetAzureRegion(string peeringLocation, string kind)
        {
            try
            {
                if (peeringLocation == null)
                {
                    throw new PSArgumentNullException();
                }

                var icList = this.PeeringLocationClient.List(kind);
                foreach (var location in icList.Select(this.TopSPeeringLocation).ToList())
                {
                    if (location.Name == peeringLocation)
                    {
                        return location.AzureRegion;
                    }
                }

                return icList.Select(this.TopSPeeringLocation).FirstOrDefault()?.ToString();
            }
            catch (ErrorResponseException ex)
            {
                var error = ex.Response.Content.Contains("\"error\": \"")
                                ? JsonConvert.DeserializeObject<Dictionary<string, ErrorResponse>>(ex.Response.Content)
                                    .FirstOrDefault().Value
                                : JsonConvert.DeserializeObject<ErrorResponse>(ex.Response.Content);
                throw new ErrorResponseException(string.Format(Resources.Error_CloudError, error.Code, error.Message));
            }
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
        public bool IsValidConnection(PSExchangeConnection connection)
        {
            if (connection.PeeringDBFacilityId <= 0)
            {
                throw new PSArgumentException(
                    string.Format(Resources.Error_InvalidFacilityId, connection.PeeringDBFacilityId));
            }

            if (connection.BgpSession == null)
                throw new PSArgumentNullException(string.Format(Resources.Error_NullSession));
            if (connection.BgpSession.PeerSessionIPv4Address == null
                && connection.BgpSession.MaxPrefixesAdvertisedV4 != null)
                throw new PSArgumentException(
                    string.Format(Resources.Error_MustBeNull, "4", connection.BgpSession.MaxPrefixesAdvertisedV4));
            if (connection.BgpSession.PeerSessionIPv6Address == null
                && connection.BgpSession.MaxPrefixesAdvertisedV6 != null)
                throw new PSArgumentException(
                    string.Format(Resources.Error_MustBeNull, "6", connection.BgpSession.MaxPrefixesAdvertisedV6));
            if (connection.BgpSession.MaxPrefixesAdvertisedV4 <= 0 && connection.BgpSession.SessionPrefixV4 != null)
                throw new PSArgumentException(
                    string.Format(
                        Resources.Error_MustBeGreaterThanZero,
                        "4",
                        connection.BgpSession.MaxPrefixesAdvertisedV4));
            if (connection.BgpSession.MaxPrefixesAdvertisedV6 <= 0 && connection.BgpSession.SessionPrefixV6 != null)
                throw new PSArgumentException(
                    string.Format(
                        Resources.Error_MustBeGreaterThanZero,
                        "6",
                        connection.BgpSession.MaxPrefixesAdvertisedV6));
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
        public bool IsValidConnection(PSDirectConnection connection)
        {
            if (connection.PeeringDBFacilityId <= 0)
            {
                throw new PSArgumentException(
                    string.Format(Resources.Error_InvalidFacilityId, connection.PeeringDBFacilityId));
            }

            if (connection.BgpSession == null)
                throw new PSArgumentNullException(string.Format(Resources.Error_NullSession));
            return this.ValidBandwidth(connection.BandwidthInMbps);
        }
    }
}