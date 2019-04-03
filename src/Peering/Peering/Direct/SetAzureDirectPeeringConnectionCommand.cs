// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Microsoft" file="SetAzureDirectPeeringConnectionCommand.cs">
//   Licensed under the Apache License, Version 2.0 (the "License");
//   //   you may not use this file except in compliance with the License.
//   //   You may obtain a copy of the License at
//   //   http://www.apache.org/licenses/LICENSE-2.0
//   //   Unless required by applicable law or agreed to in writing, software
//   //   distributed under the License is distributed on an "AS IS" BASIS,
//   //   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   //   See the License for the specific language governing permissions and
//   //   limitations under the License.
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Microsoft.Azure.PowerShell.Cmdlets.Peering.Direct
{
    using System;
    using System.Management.Automation;

    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Peering;
    using Microsoft.Azure.Management.Peering.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;
    using Microsoft.Rest;

    /// <inheritdoc />
    /// <summary>
    ///     Updates the InputObject object.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzPeeringDirectConnectionObject", DefaultParameterSetName = Constants.ParameterSetNameUseForPeeringService, SupportsShouldProcess = true)]
    [OutputType(typeof(PSPeering))]
    public class SetAzureDirectPeeringConnectionCommand : PeeringBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the legacy InputObject.
        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = Constants.ParameterSetNameUseForPeeringService,
            DontShow = true),
         Parameter(Mandatory = true,
             ValueFromPipeline = true,
             ParameterSetName = Constants.ParameterSetNameIPv4Prefix,
             DontShow = true),
         Parameter(Mandatory = true,
             ValueFromPipeline = true,
             ParameterSetName = Constants.ParameterSetNameIPv6Prefix,
             DontShow = true),
         Parameter(Mandatory = true,
             ValueFromPipeline = true,
             ParameterSetName = Constants.ParameterSetNameBandwidth,
             DontShow = true),
         Parameter(Mandatory = true,
             ValueFromPipeline = true,
             ParameterSetName = Constants.ParameterSetNameMd5Authentication,
             DontShow = true)]
        public PSPeering InputObject { get; set; }

        /// <summary>
        /// Gets or sets the connection index.
        /// </summary>
        [Parameter(
             Position = Constants.PositionPeeringZero,
             Mandatory = true,
             HelpMessage = Constants.PeeringDirectConnectionHelp,
             ParameterSetName = Constants.ParameterSetNameUseForPeeringService),
         Parameter(
             Position = Constants.PositionPeeringZero,
             Mandatory = true,
             HelpMessage = Constants.PeeringDirectConnectionHelp,
             ParameterSetName = Constants.ParameterSetNameIPv4Prefix),
         Parameter(
             Position = Constants.PositionPeeringZero,
             Mandatory = true,
             HelpMessage = Constants.PeeringDirectConnectionHelp,
             ParameterSetName = Constants.ParameterSetNameIPv6Prefix),
         Parameter(
             Position = Constants.PositionPeeringZero,
             Mandatory = true,
             HelpMessage = Constants.PeeringDirectConnectionHelp,
             ParameterSetName = Constants.ParameterSetNameBandwidth),
         Parameter(
             Position = Constants.PositionPeeringZero,
             Mandatory = true,
             HelpMessage = Constants.PeeringDirectConnectionHelp,
             ParameterSetName = Constants.ParameterSetNameMd5Authentication),
         PSArgumentCompleter("0", "1", "2"),
         ValidateRange(0, 2), ValidateNotNullOrEmpty]
        public virtual int? ConnectionIndex { get; set; }

        /// <summary>
        /// Gets or sets the session ipv4.
        /// </summary>
        [Parameter(
            Position = Constants.PositionPeeringTwo,
            Mandatory = true,

            HelpMessage = Constants.HelpSessionIPv4Prefix,
            ParameterSetName = Constants.ParameterSetNameIPv4Prefix)]
        [ValidateNotNullOrEmpty]
        public virtual string SessionPrefixV4 { get; set; }

        /// <summary>
        /// Gets or sets the max prefixes advertised ipv4.
        /// </summary>
        [Parameter(
             Mandatory = false,
             HelpMessage = Constants.HelpMaxAdvertisedIPv4,
             ParameterSetName = Constants.ParameterSetNameIPv4Prefix),
         ValidateRange(1, 20000)]
        public virtual int? MaxPrefixesAdvertisedIPv4 { get; set; }

        /// <summary>
        /// Gets or sets the session ipv4.
        /// </summary>
        [Parameter(
            Position = Constants.PositionPeeringTwo,
            Mandatory = true,
            HelpMessage = Constants.HelpSessionIPv4Prefix,
            ParameterSetName = Constants.ParameterSetNameIPv6Prefix)]
        [ValidateNotNullOrEmpty]
        public virtual string SessionPrefixV6 { get; set; }

        /// <summary>
        /// Gets or sets the max prefixes advertised ipv4.
        /// </summary>
        [Parameter(
             Mandatory = false,
             HelpMessage = Constants.HelpMaxAdvertisedIPv4,
             ParameterSetName = Constants.ParameterSetNameIPv6Prefix),
         ValidateRange(1, 20000)]
        public virtual int? MaxPrefixesAdvertisedIPv6 { get; set; }

        /// <summary>
        /// Gets or sets the m d 5 authentication key.
        /// </summary>
        [Parameter(
            Position = Constants.PositionPeeringOne,
            Mandatory = false,
            HelpMessage = Constants.MD5AuthenticationKeyHelp,
            ParameterSetName = Constants.ParameterSetNameMd5Authentication)]
        public string MD5AuthenticationKey { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = Constants.UseForPeeringServiceHelp,
            ParameterSetName = Constants.ParameterSetNameUseForPeeringService)]
        public SwitchParameter UseForPeeringService { get; set; }

        /// <summary>
        ///     Bandwidth offered at this location.
        /// </summary>
        [Parameter(
             Mandatory = true,
             HelpMessage = Constants.BandwidthHelp,
             ParameterSetName = Constants.ParameterSetNameBandwidth),
         PSArgumentCompleter("10000", "20000", "30000", "40000", "50000", "60000", "70000", "80000", "90000", "100000"),
         ValidateRange(Constants.MinRange, Constants.MaxRange), ValidateNotNullOrEmpty]
        public virtual int? BandwidthInMbps { get; set; }

        /// <inheritdoc />
        /// <summary>
        ///     The base execute operation.
        /// </summary>
        public override void Execute()
        {
            try
            {
                base.Execute();
                PSPeering newRequest = null;
                if (this.ParameterSetName.Equals(
                    Constants.ParameterSetNameUseForPeeringService,
                    StringComparison.OrdinalIgnoreCase))
                {
                    newRequest = this.UpdateUseForPeeringService();
                }
                else if (this.ParameterSetName.Equals(
                    Constants.ParameterSetNameIPv4Prefix,
                    StringComparison.OrdinalIgnoreCase))
                {
                    newRequest = this.UpdateIpV4Prefix();
                }
                else if (this.ParameterSetName.Equals(
                    Constants.ParameterSetNameIPv6Prefix,
                    StringComparison.OrdinalIgnoreCase))
                {
                    newRequest = this.UpdateIpV6Prefix();
                }
                else if (this.ParameterSetName.Equals(
                    Constants.ParameterSetNameBandwidth,
                    StringComparison.OrdinalIgnoreCase))
                {
                    newRequest = this.UpdatePeeringOffer();
                }
                else if (this.ParameterSetName.Equals(
                    Constants.ParameterSetNameMd5Authentication,
                    StringComparison.OrdinalIgnoreCase))
                {
                    newRequest = this.UpdateMD5Authentication();
                }
                else
                {
                    throw new PSArgumentException("Unable to complete the request. Check your syntax for errors.");
                }
                this.WriteObject(new PSDirectPeeringModelView(newRequest));
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
        ///     The update InputObject offer.
        /// </summary>
        /// <returns>
        ///     The <see cref="PSPeering" />.
        /// </returns>
        private PSPeering UpdatePeeringOffer()
        {
            if (this.InputObject is PSDirectPeeringModelView directPeer)
            {
                var resourceGroupName = this.GetResourceGroupNameFromId(directPeer.Id);
                var peeringName = this.GetPeeringNameFromId(directPeer.Id);
                var peering = new PSPeering
                {
                    Kind = directPeer.Kind,
                    PeeringLocation = directPeer.PeeringLocation,
                    Location = directPeer.Location,
                    Sku = directPeer.Sku,
                    Tags = directPeer.Tags
                };
                peering.Direct = new PSPeeringPropertiesDirect
                {
                    Connections = directPeer.Connections,
                    PeerAsn = directPeer.PeerAsn,
                    UseForPeeringService = directPeer.UseForPeeringService
                };

                if (this.ConnectionIndex >= directPeer.Connections.Count - 1)
                    throw new IndexOutOfRangeException($"ConnectionIndex out of range {this.ConnectionIndex}");
                var connectionIndex = this.ConnectionIndex;
                if (connectionIndex != null)
                    if (this.ValidBandwidth(this.BandwidthInMbps))
                        peering.Direct.Connections[(int)connectionIndex].BandwidthInMbps =
                            this.BandwidthInMbps >= directPeer.Connections[(int)connectionIndex].BandwidthInMbps
                                ? this.BandwidthInMbps
                                : throw new ArgumentOutOfRangeException($"Only Bandwidth upgrades are supported.");
                try
                {
                    this.PeeringClient.CreateOrUpdate(
                        resourceGroupName.ToString(),
                        peeringName.ToString(),
                        PeeringResourceManagerProfile.Mapper.Map<PeeringModel>(peering));
                }
                catch (HttpOperationException ex)
                {
                    throw new Exception(
                        $"Request URL: {ex.Request.RequestUri} StatusCode: {ex.Response.StatusCode} Content: {ex.Response.Content}");
                }

                return new PSDirectPeeringModelView(PeeringResourceManagerProfile.Mapper.Map<PSPeering>(this.PeeringClient.Get(resourceGroupName.ToString(), peeringName.ToString())));
            }

            throw new InvalidOperationException("Exchange InputObject does not support this operation.");
        }

        /// <summary>
        ///     The update InputObject offer.
        /// </summary>
        /// <returns>
        ///     The <see cref="PSPeering" />.
        /// </returns>
        private PSPeering UpdateMD5Authentication()
        {
            if (this.InputObject is PSDirectPeeringModelView directPeer)
            {
                var resourceGroupName = this.GetResourceGroupNameFromId(directPeer.Id);
                var peeringName = this.GetPeeringNameFromId(directPeer.Id);
                var peering = new PSPeering
                {
                    Kind = directPeer.Kind,
                    PeeringLocation = directPeer.PeeringLocation,
                    Location = directPeer.Location,
                    Sku = directPeer.Sku,
                    Tags = directPeer.Tags,
                    Direct = new PSPeeringPropertiesDirect
                    {
                        Connections = directPeer.Connections,
                        PeerAsn = directPeer.PeerAsn,
                        UseForPeeringService = directPeer.UseForPeeringService
                    }
                };

                if (this.ConnectionIndex >= directPeer.Connections.Count - 1)
                    throw new IndexOutOfRangeException($"ConnectionIndex out of range {this.ConnectionIndex}");
                var connectionIndex = this.ConnectionIndex;
                if (connectionIndex != null)
                    peering.Direct.Connections[(int)connectionIndex].BgpSession.Md5AuthenticationKey =
                        this.MD5AuthenticationKey;
                try
                {
                    this.PeeringClient.CreateOrUpdate(
                        resourceGroupName.ToString(),
                        peeringName.ToString(),
                        PeeringResourceManagerProfile.Mapper.Map<PeeringModel>(peering));
                }
                catch (HttpOperationException ex)
                {
                    throw new Exception(
                        $"Request URL: {ex.Request.RequestUri} StatusCode: {ex.Response.StatusCode} Content: {ex.Response.Content}");
                }

                return new PSDirectPeeringModelView(PeeringResourceManagerProfile.Mapper.Map<PSPeering>(this.PeeringClient.Get(resourceGroupName.ToString(), peeringName.ToString())));
            }

            throw new InvalidOperationException($"Exchange InputObject does not support this operation.");
        }

        /// <summary>
        ///     The update InputObject offer.
        /// </summary>
        /// <returns>
        ///     The <see cref="PSPeering" />.
        /// </returns>
        private PSPeering UpdateIpV4Prefix()
        {
            if (this.InputObject is PSDirectPeeringModelView directPeer)
            {
                var resourceGroupName = this.GetResourceGroupNameFromId(directPeer.Id);
                var peeringName = this.GetPeeringNameFromId(directPeer.Id);
                var peering = new PSPeering
                {
                    Kind = directPeer.Kind,
                    PeeringLocation = directPeer.PeeringLocation,
                    Location = directPeer.Location,
                    Sku = directPeer.Sku,
                    Tags = directPeer.Tags,
                    Direct = new PSPeeringPropertiesDirect
                    {
                        Connections = directPeer.Connections,
                        PeerAsn = directPeer.PeerAsn,
                        UseForPeeringService = directPeer.UseForPeeringService
                    }

                };
                if (this.ConnectionIndex >= directPeer.Connections.Count - 1)
                    throw new IndexOutOfRangeException($"ConnectionIndex out of range {this.ConnectionIndex}");
                var connectionIndex = this.ConnectionIndex;
                if (connectionIndex != null)
                {
                    peering.Direct.Connections[(int)connectionIndex].BgpSession.SessionPrefixV4 =
                        this.ValidatePrefix(this.SessionPrefixV4, Constants.Direct);
                    peering.Direct.Connections[(int)connectionIndex].BgpSession.MaxPrefixesAdvertisedV4 =
                        this.MaxPrefixesAdvertisedIPv4 == null ? directPeer.Connections[(int)connectionIndex].BgpSession.MaxPrefixesAdvertisedV4 : 20000;
                }

                try
                {
                    this.PeeringClient.CreateOrUpdate(
                        resourceGroupName.ToString(),
                        peeringName.ToString(),
                        PeeringResourceManagerProfile.Mapper.Map<PeeringModel>(peering));
                }
                catch (HttpOperationException ex)
                {
                    throw new Exception(
                        $"Request URL: {ex.Request.RequestUri} StatusCode: {ex.Response.StatusCode} Content: {ex.Response.Content}");
                }

                return new PSDirectPeeringModelView(PeeringResourceManagerProfile.Mapper.Map<PSPeering>(this.PeeringClient.Get(resourceGroupName.ToString(), peeringName.ToString())));
            }

            throw new InvalidOperationException();
        }

        /// <summary>
        ///     The update InputObject offer.
        /// </summary>
        /// <returns>
        ///     The <see cref="PSPeering" />.
        /// </returns>
        private PSPeering UpdateIpV6Prefix()
        {
            if (this.InputObject is PSDirectPeeringModelView directPeer)
            {
                var resourceGroupName = this.GetResourceGroupNameFromId(directPeer.Id);
                var peeringName = this.GetPeeringNameFromId(directPeer.Id);
                var peering = new PSPeering
                {
                    Kind = directPeer.Kind,
                    PeeringLocation = directPeer.PeeringLocation,
                    Location = directPeer.Location,
                    Sku = directPeer.Sku,
                    Tags = directPeer.Tags,
                    Direct = new PSPeeringPropertiesDirect
                    {
                        Connections = directPeer.Connections,
                        PeerAsn = directPeer.PeerAsn,
                        UseForPeeringService = directPeer.UseForPeeringService
                    }

                };
                if (this.ConnectionIndex >= directPeer.Connections.Count - 1)
                    throw new IndexOutOfRangeException($"ConnectionIndex out of range {this.ConnectionIndex}");
                var connectionIndex = this.ConnectionIndex;
                if (connectionIndex != null)
                {
                    peering.Direct.Connections[(int)connectionIndex].BgpSession.SessionPrefixV6 =
                        this.ValidatePrefix(this.SessionPrefixV6, Constants.Direct);
                    peering.Direct.Connections[(int)connectionIndex].BgpSession.MaxPrefixesAdvertisedV4 =
                        this.MaxPrefixesAdvertisedIPv6 == null ? directPeer.Connections[(int)connectionIndex].BgpSession.MaxPrefixesAdvertisedV4 : 20000;
                }

                try
                {
                    this.PeeringClient.CreateOrUpdate(
                        resourceGroupName.ToString(),
                        peeringName.ToString(),
                        PeeringResourceManagerProfile.Mapper.Map<PeeringModel>(peering));
                }
                catch (HttpOperationException ex)
                {
                    throw new Exception(
                        $"Request URL: {ex.Request.RequestUri} StatusCode: {ex.Response.StatusCode} Content: {ex.Response.Content}");
                }

                return new PSDirectPeeringModelView(PeeringResourceManagerProfile.Mapper.Map<PSPeering>(this.PeeringClient.Get(resourceGroupName.ToString(), peeringName.ToString())));
            }

            if (this.InputObject is PSExchangePeeringModelView exPeer)
            {
                var resourceGroupName = this.GetResourceGroupNameFromId(exPeer.Id);
                var peeringName = this.GetPeeringNameFromId(exPeer.Id);
                var peering = new PSPeering
                {
                    Kind = exPeer.Kind,
                    PeeringLocation = exPeer.PeeringLocation,
                    Location = exPeer.Location,
                    Sku = exPeer.Sku,
                    Tags = exPeer.Tags
                };
                if (exPeer.Kind == Constants.Exchange)
                {
                    peering.Exchange = new PSPeeringPropertiesExchange
                    {
                        Connections = exPeer.Connections,
                        PeerAsn = exPeer.PeerAsn
                    };
                }
                try
                {
                    this.PeeringClient.CreateOrUpdate(
                        resourceGroupName.ToString(),
                        peeringName.ToString(),
                        PeeringResourceManagerProfile.Mapper.Map<PeeringModel>(peering));
                }
                catch (HttpOperationException ex)
                {
                    throw new Exception(
                        $"Request URL: {ex.Request.RequestUri} StatusCode: {ex.Response.StatusCode} Content: {ex.Response.Content}");
                }

                return new PSExchangePeeringModelView(PeeringResourceManagerProfile.Mapper.Map<PSPeering>(this.PeeringClient.Get(resourceGroupName.ToString(), peeringName.ToString())));
            }

            throw new InvalidOperationException();
        }

        /// <summary>
        ///     The update InputObject offer.
        /// </summary>
        /// <returns>
        ///     The <see cref="PSPeering" />.
        /// </returns>
        private PSPeering UpdateUseForPeeringService()
        {
            if (this.InputObject is PSDirectPeeringModelView directPeer)
            {
                var resourceGroupName = this.GetResourceGroupNameFromId(directPeer.Id);
                var peeringName = this.GetPeeringNameFromId(directPeer.Id);
                var peering = new PSPeering
                {
                    Kind = directPeer.Kind,
                    PeeringLocation = directPeer.PeeringLocation,
                    Location = directPeer.Location,
                    Sku = directPeer.Sku,
                    Tags = directPeer.Tags,
                    Direct = new PSPeeringPropertiesDirect
                    {
                        Connections = directPeer.Connections,
                        PeerAsn = directPeer.PeerAsn,
                        UseForPeeringService =
                                                           directPeer.UseForPeeringService != this.UseForPeeringService
                                                               ? this.UseForPeeringService
                                                               : directPeer.UseForPeeringService
                    }
                };

                try
                {
                    this.PeeringClient.CreateOrUpdate(
                        resourceGroupName.ToString(),
                        peeringName.ToString(),
                        PeeringResourceManagerProfile.Mapper.Map<PeeringModel>(peering));
                }
                catch (HttpOperationException ex)
                {
                    throw new Exception(
                        $"Request URL: {ex.Request.RequestUri} StatusCode: {ex.Response.StatusCode} Content: {ex.Response.Content}");
                }

                return new PSDirectPeeringModelView(
                    PeeringResourceManagerProfile.Mapper.Map<PSPeering>(
                        this.PeeringClient.Get(resourceGroupName.ToString(), peeringName.ToString())));
            }

            if (this.InputObject is PSExchangePeeringModelView exPeer)
            {
                var resourceGroupName = this.GetResourceGroupNameFromId(exPeer.Id);
                var peeringName = this.GetPeeringNameFromId(exPeer.Id);
                var peering = new PSPeering
                {
                    Kind = exPeer.Kind,
                    PeeringLocation = exPeer.PeeringLocation,
                    Location = exPeer.Location,
                    Sku = exPeer.Sku,
                    Tags = exPeer.Tags
                };
                if (exPeer.Kind == Constants.Exchange)
                {
                    peering.Exchange = new PSPeeringPropertiesExchange
                    {
                        Connections = exPeer.Connections,
                        PeerAsn = exPeer.PeerAsn
                    };
                }
                try
                {
                    this.PeeringClient.CreateOrUpdate(
                        resourceGroupName.ToString(),
                        peeringName.ToString(),
                        PeeringResourceManagerProfile.Mapper.Map<PeeringModel>(peering));
                }
                catch (HttpOperationException ex)
                {
                    throw new Exception(
                        $"Request URL: {ex.Request.RequestUri} StatusCode: {ex.Response.StatusCode} Content: {ex.Response.Content}");
                }

                return new PSExchangePeeringModelView(PeeringResourceManagerProfile.Mapper.Map<PSPeering>(this.PeeringClient.Get(resourceGroupName.ToString(), peeringName.ToString())));
            }

            throw new InvalidOperationException();
        }
    }
}