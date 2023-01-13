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
    using Microsoft.Azure.Commands.Common.Exceptions;
    using Microsoft.Azure.Commands.Peering.Properties;
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Microsoft.Azure.Management.Peering;
    using Microsoft.Azure.Management.Peering.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;

    using Newtonsoft.Json;
    using DirectPeeringType = Models.DirectPeeringType;

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
                if (this.peeringClient == null)
                {
                    this.peeringClient =
                                           AzureSession.Instance.ClientFactory.CreateArmClient<PeeringManagementClient>(
                                               this.DefaultProfile.DefaultContext,
                                               AzureEnvironment.Endpoint.ResourceManager);
                }
                // for testing.
                // this.peeringClient.BaseUri = new Uri("https://secrets.wanrr-test.radar.core.azure-test.net");
                return this.peeringClient;
            }

            set => this.peeringClient = value;
        }

        /// <summary>
        ///     The peering client.
        /// </summary>
        public IPeeringsOperations PeeringClient => this.PeeringManagementClient.Peerings;

        /// <summary>
        /// The Received routes client.
        /// </summary>
        public IReceivedRoutesOperations RxRoutesClient => this.PeeringManagementClient.ReceivedRoutes;

        /// <summary>
        /// The peer asn operations client
        /// </summary>
        public IPeerAsnsOperations PeerAsnClient => this.PeeringManagementClient.PeerAsns;

        /// <summary>
        ///     The PSPeering location client.
        /// </summary>
        public IPeeringLocationsOperations PeeringLocationClient => this.PeeringManagementClient.PeeringLocations;

        /// <summary>
        /// The peering legacy client.
        /// </summary>
        public ILegacyPeeringsOperations PeeringLegacyClient => this.PeeringManagementClient.LegacyPeerings;

        /// <summary>
        /// The peering service providers client
        /// </summary>
        public IPeeringServiceProvidersOperations PeeringServiceProvidersClient => this.PeeringManagementClient.PeeringServiceProviders;

        /// <summary>
        /// The Peering Service locations client.
        /// </summary>
        public IPeeringServiceLocationsOperations PeeringServiceLocationsClient => this.PeeringManagementClient.PeeringServiceLocations;

        /// <summary>
        /// The peering service country client.
        /// </summary>
        public IPeeringServiceCountriesOperations PeeringServiceCountryClient => this.PeeringManagementClient.PeeringServiceCountries;

        /// <summary>
        /// The peering registered asn client.
        /// </summary>
        public IRegisteredAsnsOperations RegisteredAsnClient => this.PeeringManagementClient.RegisteredAsns;

        /// <summary>
        /// The peering registered asn client
        /// </summary>
        public IRegisteredPrefixesOperations RegisteredPrefixesClient => this.PeeringManagementClient.RegisteredPrefixes;

        /// <summary>
        /// The peering service prefix client
        /// </summary>
        public IPrefixesOperations PeeringServicePrefixesClient => this.PeeringManagementClient.Prefixes;

        /// <summary>
        /// the peering service prefix client extended operations.
        /// </summary>
        public IPrefixesOperations PrefixesClient => this.PeeringManagementClient.Prefixes;

        /// <summary>
        /// The peering services client
        /// </summary>
        public IPeeringServicesOperations PeeringServicesClient => this.PeeringManagementClient.PeeringServices;

        /// <summary>
        /// The cdn peering prefix client
        /// </summary>
        public ICdnPeeringPrefixesOperations CdnPeeringPrefixesOperationsClient => this.PeeringManagementClient.CdnPeeringPrefixes;

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
        /// The <see cref="PSPeering"/>.
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

        /// <summary>
        /// Converts to powershell model for peering asn
        /// </summary>
        /// <param name="peeringAsn"></param>
        /// <returns>powershell object</returns>
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
        /// Converts to powershell peering service
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public PSPeeringService ToPeeringServicePS(object obj)
        {
            try
            {
                return PeeringResourceManagerProfile.Mapper.Map<PSPeeringService>(obj);
            }
            catch (InvalidOperationException mapException)
            {
                throw new InvalidOperationException(String.Format(Resources.Error_Mapping, mapException));
            }
        }

        /// <summary>
        /// Converts to powershell peering service prefix
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public PSPeeringServicePrefix ToPeeringServicePrefixPS(object obj)
        {
            try
            {
                return PeeringResourceManagerProfile.Mapper.Map<PSPeeringServicePrefix>(obj);
            }
            catch (InvalidOperationException mapException)
            {
                throw new InvalidOperationException(String.Format(Resources.Error_Mapping, mapException));
            }
        }

        /// <summary>
        /// Converts to powershell peering service provider
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public PSPeeringServiceProvider ToPeeringServiceProviderPS(object obj)
        {
            try
            {
                return PeeringResourceManagerProfile.Mapper.Map<PSPeeringServiceProvider>(obj);
            }
            catch (InvalidOperationException mapException)
            {
                throw new InvalidOperationException(String.Format(Resources.Error_Mapping, mapException));
            }
        }

        /// <summary>
        /// Converts to powershell peering service location
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public PSPeeringServiceLocation ToPeeringServiceLocationPS(object obj)
        {
            try
            {
                return PeeringResourceManagerProfile.Mapper.Map<PSPeeringServiceLocation>(obj);
            }
            catch (InvalidOperationException mapException)
            {
                throw new InvalidOperationException(String.Format(Resources.Error_Mapping, mapException));
            }
        }

        /// <summary>
        /// The to ps peering location.
        /// </summary>
        /// <param name="peering">
        /// The peering.
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
        /// Convert to powershell cdn peering prefix
        /// </summary>
        /// <param name="cdnPrefix">
        /// The cdn prefix.
        /// </param>
        /// <returns>
        /// The <see cref="PSPeeringLocation"/>.
        /// </returns>
        public PSCdnPeeringPrefix ToPSCdnPeeringPrefix(object cdnPrefix)
        {
            try
            {
                return PeeringResourceManagerProfile.Mapper.Map<PSCdnPeeringPrefix>(cdnPrefix);
            }
            catch (InvalidOperationException mapException)
            {
                throw new AzPSInvalidOperationException(String.Format(Resources.Error_Mapping, mapException));
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
            this.WriteVerbose($"validating bandwidth: {bandwidthInMbps}");
            if (bandwidthInMbps <= 0)
                throw new AzPSArgumentException(string.Format(Resources.Error_BandwidthTooLow, bandwidthInMbps), "bandwidthInMbps");
            if (bandwidthInMbps % Constants.MinRange != 0)
                throw new AzPSArgumentOutOfRangeException(
                    string.Format(Resources.Error_BandwidthIncorrectFormat, bandwidthInMbps, Constants.MinRange), "bandwidthInMbps");
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
            this.WriteVerbose($"Starting bandwidth: {startingBandwidth} new bandwidth: {newBandwidth}");
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
        /// <param name="peeringType">
        /// The InputObject Type.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string ValidatePrefix(string routePrefix, string peeringType = Constants.Direct)
        {
            if (routePrefix != null)
            {
                this.WriteVerbose($"Validating route prefix: {routePrefix} for PeeringType:{peeringType}");
                var prefix = RoutePrefix.GetValidPrefix(routePrefix);
                switch (prefix.PrefixAddressFamily)
                {
                    case AddressFamily.InterNetwork:
                        if (peeringType.Equals(Constants.Direct, StringComparison.OrdinalIgnoreCase))
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
                                    return prefix.StartOfPrefixBigInt == actualPrefixBigInt
                                               ? routePrefix
                                               : throw new PSArgumentException(
                                                     string.Format(
                                                         Resources.Error_InvalidPrefixRange,
                                                         routePrefix,
                                                         (prefix.StartOfPrefixBigInt).ToIpAddress(
                                                             AddressFamily.InterNetwork) + "/30"));
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
                        if (peeringType.Equals(Constants.PeeringService, StringComparison.OrdinalIgnoreCase))
                        {
                            if (prefix.PrefixMaskWidth <= 23)
                            {
                                throw new PSArgumentOutOfRangeException(
                                    string.Format(Resources.Error_InvalidPrefix, routePrefix, "/24 - or /32"));
                            }
                            else
                            {
                                var actualPrefixBigInt = prefix.ActualPrefixBigInt;
                                if (prefix.Length <= 256)
                                {
                                    return prefix.StartOfPrefixBigInt == actualPrefixBigInt
                                               ? routePrefix
                                               : throw new PSArgumentException(
                                                     string.Format(
                                                         Resources.Error_InvalidPrefixRange,
                                                         routePrefix,
                                                         (prefix.StartOfPrefixBigInt).ToIpAddress(
                                                             AddressFamily.InterNetwork)));
                                }
                                throw new PSArgumentOutOfRangeException(
                                    string.Format(Resources.Error_InvalidPrefixRange, routePrefix, "/24", "/31"));
                            }
                        }

                        return routePrefix;

                    case AddressFamily.InterNetworkV6:
                        if (peeringType.Equals(Constants.Direct, StringComparison.OrdinalIgnoreCase))
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
        /// <exception cref="ErrorResponseException"></exception>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            this.Execute();
        }

        /// <summary>
        /// The get azure region.
        /// </summary>
        /// <param name="peeringLocation">
        /// The InputObject location.
        /// </param>
        /// <param name="kind">
        /// The kind.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="PSArgumentNullException">
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
                        this.WriteVerbose($"Region: {location.AzureRegion}");
                        return location.AzureRegion;
                    }
                }

                return icList.Select(this.TopSPeeringLocation).FirstOrDefault()?.ToString();
            }
            catch (ErrorResponseException ex)
            {
                var error = this.GetErrorCodeAndMessageFromArmOrErm(ex);
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
            if (connection.ConnectionIdentifier == null || connection.ConnectionIdentifier == string.Empty)
            {
                throw new PSArgumentNullException(string.Format(Resources.Error_ConnectionIdentifierNull));
            }
            return this.ValidBandwidth(connection.BandwidthInMbps);
        }

        /// <summary>
        /// The get error code and message from arm or erm.
        /// </summary>
        /// <param name="ex">
        /// The ex.
        /// </param>
        /// <returns>
        /// The <see cref="ErrorResponse"/>.
        /// </returns>
        public ErrorDetail GetErrorCodeAndMessageFromArmOrErm(ErrorResponseException ex)
        {
            ErrorDetail error = null;
            try
            {
                var ermError = JsonConvert.DeserializeObject<ErrorResponse>(ex.Response.Content);
                if (ermError.Error != null)
                {
                    return ermError.Error;
                }
                else
                {
                    return JsonConvert.DeserializeObject<ErrorDetail>(ex.Response.Content);
                }
            }

            catch
            {
                try
                {
                    var armError = JsonConvert.DeserializeObject<Dictionary<string, ErrorResponse>>(ex.Response.Content);
                    if (armError.Values.FirstOrDefault()?.Error != null)
                    {
                        return armError.Values.FirstOrDefault().Error;
                    }
                }
                catch
                {
                    throw ex;
                }
            }
            return error;
        }

        public string ConvertToDirectPeeringType(string peeringType)
        {
            if (peeringType == Constants.Ix)
            {
                return DirectPeeringType.Ix;
            }
            if (peeringType == Constants.IxRs)
            {
                return DirectPeeringType.IxRs;
            }
            if (peeringType == Constants.CDN8069)
            {
                return DirectPeeringType.Cdn;
            }
            return DirectPeeringType.Edge;
        }
    }
}