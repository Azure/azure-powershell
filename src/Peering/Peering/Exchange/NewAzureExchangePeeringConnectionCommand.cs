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

namespace Microsoft.Azure.PowerShell.Cmdlets.Peering.Exchange
{
    using System;
    using System.Management.Automation;

    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;

    /// <summary>
    ///     New Azure InputObject Command-let
    /// </summary>
    [Cmdlet(
        VerbsCommon.New,
        "AzPeeringExchangeConnectionObject",
        DefaultParameterSetName = Constants.ParameterSetNameIPv4Prefix,
        SupportsShouldProcess = true)]
    [OutputType(typeof(PSExchangeConnection))]
    public class NewAzureExchangePeeringConnectionCommand : PeeringBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the InputObject Facility DB.
        /// </summary>
        [Parameter(
            Position = Constants.PositionPeeringZero,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpPeeringDBFacilityId,
            ParameterSetName = Constants.ParameterSetNameIPv4Prefix)]
        [Parameter(
            Position = Constants.PositionPeeringZero,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpPeeringDBFacilityId,
            ParameterSetName = Constants.ParameterSetNameIPv6Prefix)]
        [Parameter(
            Position = Constants.PositionPeeringZero,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.HelpPeeringDBFacilityId,
            ParameterSetName = Constants.ParameterSetNameIPv4Prefix + Constants.ParameterSetNameIPv6Prefix)]
        [ValidateNotNullOrEmpty]
        public virtual int? PeeringDBFacilityId { get; set; }

        /// <summary>
        /// Gets or sets the session i pv 4 prefix.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.HelpPeerSessionIPv4Prefix,
            ParameterSetName = Constants.ParameterSetNameIPv4Prefix)]
        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.HelpPeerSessionIPv4Prefix,
            ParameterSetName = Constants.ParameterSetNameIPv4Prefix + Constants.ParameterSetNameIPv6Prefix)]
        public virtual string PeerSessionIPv4Address { get; set; }

        /// <summary>
        /// Gets or sets the session i pv 6 prefix.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.HelpPeerSessionIPv6Prefix,
            ParameterSetName = Constants.ParameterSetNameIPv6Prefix)]
        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.HelpPeerSessionIPv6Prefix,
            ParameterSetName = Constants.ParameterSetNameIPv4Prefix + Constants.ParameterSetNameIPv6Prefix)]
        public virtual string PeerSessionIPv6Address { get; set; }

        /// <summary>
        /// Gets or sets the max prefixes advertised i pv 4.
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.HelpMaxAdvertisedIPv4,
            ParameterSetName = Constants.ParameterSetNameIPv4Prefix)]
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.HelpMaxAdvertisedIPv4,
            ParameterSetName = Constants.ParameterSetNameIPv4Prefix + Constants.ParameterSetNameIPv6Prefix)]
        public virtual int? MaxPrefixesAdvertisedIPv4 { get; set; }

        /// <summary>
        /// Gets or sets the max prefixes advertised i pv 6.
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.HelpMaxAdvertisedIPv6,
            ParameterSetName = Constants.ParameterSetNameIPv6Prefix)]
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.HelpMaxAdvertisedIPv6,
            ParameterSetName = Constants.ParameterSetNameIPv4Prefix + Constants.ParameterSetNameIPv6Prefix)]
        public virtual int? MaxPrefixesAdvertisedIPv6 { get; set; }

        /// <summary>
        /// Gets or sets the m d 5 authentication key.
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.MD5AuthenticationKeyHelp,
            ParameterSetName = Constants.ParameterSetNameIPv4Prefix)]
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.MD5AuthenticationKeyHelp,
            ParameterSetName = Constants.ParameterSetNameIPv6Prefix)]
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.MD5AuthenticationKeyHelp,
            ParameterSetName = Constants.ParameterSetNameIPv4Prefix + Constants.ParameterSetNameIPv6Prefix)]
        public string MD5AuthenticationKey { get; set; }

        /// <summary>
        ///     The inherited Execute function.
        /// </summary>
        public override void Execute()
        {
            base.Execute();
            this.WriteObject(this.CreateExchangePeeringConnection());
        }

        /// <summary>
        /// The create InputObject.
        /// </summary>
        /// <returns>
        /// The <see cref="PSPeering"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        private PSExchangeConnection CreateExchangePeeringConnection()
        {
            var PeeringRequest = new PSExchangeConnection
            {
                BgpSession = new PSBgpSession
                {
                    MaxPrefixesAdvertisedV4 = this.MaxPrefixesAdvertisedIPv4,
                    MaxPrefixesAdvertisedV6 = this.MaxPrefixesAdvertisedIPv6,
                    Md5AuthenticationKey = this.MD5AuthenticationKey,
                    PeerSessionIPv4Address = this.PeerSessionIPv4Address,
                    PeerSessionIPv6Address = this.PeerSessionIPv6Address
                },
                PeeringDBFacilityId = this.PeeringDBFacilityId,
            };


            if (this.ValidConnection(PeeringRequest))
            {
                return PeeringRequest;
            }
            throw new PSArgumentException($"Not a valid exchange connection");
        }
    }
}
