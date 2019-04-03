// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Microsoft" file="SetAzureExchangePeeringConnectionCommand.cs">
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

namespace Microsoft.Azure.PowerShell.Cmdlets.Peering.Exchange
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
    [Cmdlet(VerbsCommon.Set, "AzPeeringExchangeConnectionObject", DefaultParameterSetName = Constants.ParameterSetNameMd5Authentication, SupportsShouldProcess = true)]
    [OutputType(typeof(PSPeering))]
    public class SetAzureExchangePeeringConnectionCommand : PeeringBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the legacy InputObject.
        [Parameter(Mandatory = true,
             ValueFromPipeline = true,
             ParameterSetName = Constants.ParameterSetNameIPv4Prefix,
             DontShow = true),
         Parameter(Mandatory = true,
             ValueFromPipeline = true,
             ParameterSetName = Constants.ParameterSetNameIPv6Prefix,
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
             HelpMessage = Constants.PeeringExchangeConnectionHelp,
             ParameterSetName = Constants.ParameterSetNameIPv4Prefix),
         Parameter(
             Position = Constants.PositionPeeringZero,
             Mandatory = true,
             HelpMessage = Constants.PeeringExchangeConnectionHelp,
             ParameterSetName = Constants.ParameterSetNameIPv6Prefix),
         Parameter(
             Position = Constants.PositionPeeringZero,
             Mandatory = true,
             HelpMessage = Constants.PeeringExchangeConnectionHelp,
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
        public virtual string PeerSessionIPv4Address { get; set; }

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
        public virtual string PeerSessionIPv6Address { get; set; }

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
                    Constants.ParameterSetNameMd5Authentication,
                    StringComparison.OrdinalIgnoreCase))
                {
                    newRequest = this.UpdateMD5Authentication();
                }
                else
                {
                    throw new PSArgumentException("Unable to complete the request. Check your syntax for errors.");
                }

                this.WriteObject(newRequest);
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
        private PSPeering UpdateMD5Authentication()
        {
            if (this.InputObject is PSExchangePeeringModelView modelView)
            {
                var resourceGroupName = this.GetResourceGroupNameFromId(modelView.Id);
                var peeringName = this.GetPeeringNameFromId(modelView.Id);
                var peering = new PSPeering
                {
                    Kind = modelView.Kind,
                    PeeringLocation = modelView.PeeringLocation,
                    Location = modelView.Location,
                    Sku = modelView.Sku,
                    Tags = modelView.Tags,
                    Exchange = new PSPeeringPropertiesExchange
                    {
                        Connections = modelView.Connections,
                        PeerAsn = modelView.PeerAsn
                    }
                };

                if (this.ConnectionIndex >= modelView.Connections.Count - 1)
                    throw new IndexOutOfRangeException($"ConnectionIndex out of range {this.ConnectionIndex}");
                var connectionIndex = this.ConnectionIndex;
                if (connectionIndex != null)
                    peering.Exchange.Connections[(int)connectionIndex].BgpSession.Md5AuthenticationKey =
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

                return new PSExchangePeeringModelView(PeeringResourceManagerProfile.Mapper.Map<PSPeering>(this.PeeringClient.Get(resourceGroupName.ToString(), peeringName.ToString())));
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
            if (this.InputObject is PSExchangePeeringModelView modelView)
            {
                var resourceGroupName = this.GetResourceGroupNameFromId(modelView.Id);
                var peeringName = this.GetPeeringNameFromId(modelView.Id);
                var peering = new PSPeering
                {
                    Kind = modelView.Kind,
                    PeeringLocation = modelView.PeeringLocation,
                    Location = modelView.Location,
                    Sku = modelView.Sku,
                    Tags = modelView.Tags,
                    Exchange = new PSPeeringPropertiesExchange
                    {
                        Connections = modelView.Connections,
                        PeerAsn = modelView.PeerAsn,
                    }

                };
                if (this.ConnectionIndex >= modelView.Connections.Count - 1)
                    throw new IndexOutOfRangeException($"ConnectionIndex out of range {this.ConnectionIndex}");
                var connectionIndex = this.ConnectionIndex;
                if (connectionIndex != null)
                {
                    peering.Exchange.Connections[(int)connectionIndex].BgpSession.SessionPrefixV4 =
                        this.ValidatePrefix(this.PeerSessionIPv4Address, Constants.Exchange);
                    peering.Exchange.Connections[(int)connectionIndex].BgpSession.MaxPrefixesAdvertisedV4 =
                        this.MaxPrefixesAdvertisedIPv4 == null ? modelView.Connections[(int)connectionIndex].BgpSession.MaxPrefixesAdvertisedV4 : 20000;
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
        private PSPeering UpdateIpV6Prefix()
        {
            if (this.InputObject is PSExchangePeeringModelView modelView)
            {
                var resourceGroupName = this.GetResourceGroupNameFromId(modelView.Id);
                var peeringName = this.GetPeeringNameFromId(modelView.Id);
                var peering = new PSPeering
                {
                    Kind = modelView.Kind,
                    PeeringLocation = modelView.PeeringLocation,
                    Location = modelView.Location,
                    Sku = modelView.Sku,
                    Tags = modelView.Tags,
                    Exchange = new PSPeeringPropertiesExchange
                    {
                        Connections = modelView.Connections,
                        PeerAsn = modelView.PeerAsn,
                    }

                };
                if (this.ConnectionIndex >= modelView.Connections.Count - 1)
                    throw new IndexOutOfRangeException($"ConnectionIndex out of range {this.ConnectionIndex}");
                var connectionIndex = this.ConnectionIndex;
                if (connectionIndex != null)
                {
                    peering.Exchange.Connections[(int)connectionIndex].BgpSession.SessionPrefixV6 =
                        this.ValidatePrefix(this.PeerSessionIPv6Address, Constants.Exchange);
                    peering.Exchange.Connections[(int)connectionIndex].BgpSession.MaxPrefixesAdvertisedV4 =
                        this.MaxPrefixesAdvertisedIPv6 == null ? modelView.Connections[(int)connectionIndex].BgpSession.MaxPrefixesAdvertisedV4 : 2000;
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