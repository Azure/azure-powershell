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

    using Microsoft.Azure.Commands.Peering.Properties;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;

    /// <summary>
    ///     New Azure InputObject Command-let
    /// </summary>
    [Cmdlet(
        VerbsCommon.New,
        "AzPeeringExchangeConnectionObject",
        DefaultParameterSetName = Constants.ParameterSetNameIPv4Address, SupportsShouldProcess = false)]
    [OutputType(typeof(PSExchangeConnection))]
    public class NewAzureExchangePeeringConnectionCommand : PeeringBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the InputObject Facility DB.
        /// </summary>
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = Constants.HelpPeeringDBFacilityId,
            ParameterSetName = Constants.ParameterSetNameIPv4Address)]
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = Constants.HelpPeeringDBFacilityId,
            ParameterSetName = Constants.ParameterSetNameIPv6Address)]
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = Constants.HelpPeeringDBFacilityId,
            ParameterSetName = Constants.ParameterSetNameIPv4Address + Constants.ParameterSetNameIPv6Address)]
        [ValidateNotNullOrEmpty]
        public int? PeeringDBFacilityId { get; set; }

        /// <summary>
        /// Gets or sets the session i pv 4 prefix.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.HelpPeerSessionIPv4Prefix,
            ParameterSetName = Constants.ParameterSetNameIPv4Address)]
        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.HelpPeerSessionIPv4Prefix,
            ParameterSetName = Constants.ParameterSetNameIPv4Address + Constants.ParameterSetNameIPv6Address)]
        public string PeerSessionIPv4Address { get; set; }

        /// <summary>
        /// Gets or sets the session i pv 6 prefix.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.HelpPeerSessionIPv6Prefix,
            ParameterSetName = Constants.ParameterSetNameIPv6Address)]
        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.HelpPeerSessionIPv6Prefix,
            ParameterSetName = Constants.ParameterSetNameIPv4Address + Constants.ParameterSetNameIPv6Address)]
        public string PeerSessionIPv6Address { get; set; }

        /// <summary>
        /// Gets or sets the max prefixes advertised i pv 4.
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.HelpMaxAdvertisedIPv4,
            ParameterSetName = Constants.ParameterSetNameIPv4Address)]
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.HelpMaxAdvertisedIPv4,
            ParameterSetName = Constants.ParameterSetNameIPv4Address + Constants.ParameterSetNameIPv6Address)]
        public int? MaxPrefixesAdvertisedIPv4 { get; set; }

        /// <summary>
        /// Gets or sets the max prefixes advertised i pv 6.
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.HelpMaxAdvertisedIPv6,
            ParameterSetName = Constants.ParameterSetNameIPv6Address)]
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.HelpMaxAdvertisedIPv6,
            ParameterSetName = Constants.ParameterSetNameIPv4Address + Constants.ParameterSetNameIPv6Address)]
        public int? MaxPrefixesAdvertisedIPv6 { get; set; }

        /// <summary>
        /// Gets or sets the m d 5 authentication key.
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.MD5AuthenticationKeyHelp,
            ParameterSetName = Constants.ParameterSetNameIPv4Address)]
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.MD5AuthenticationKeyHelp,
            ParameterSetName = Constants.ParameterSetNameIPv6Address)]
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.MD5AuthenticationKeyHelp,
            ParameterSetName = Constants.ParameterSetNameIPv4Address + Constants.ParameterSetNameIPv6Address)]
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
            var peeringRequest = new PSExchangeConnection
                                     {
                                         BgpSession = new PSBgpSession
                                                          {
                                                              MaxPrefixesAdvertisedV4 = !string.IsNullOrEmpty(this.PeerSessionIPv4Address) ? (this.MaxPrefixesAdvertisedIPv4 ?? 20000) : (int?)null,
                                                              MaxPrefixesAdvertisedV6 = !string.IsNullOrEmpty(this.PeerSessionIPv6Address) ? (this.MaxPrefixesAdvertisedIPv6 ?? 2000) : (int?)null,
                                                              Md5AuthenticationKey = this.MD5AuthenticationKey,
                                                              PeerSessionIPv4Address = this.PeerSessionIPv4Address,
                                                              PeerSessionIPv6Address = this.PeerSessionIPv6Address
                                                          },
                                         PeeringDBFacilityId = this.PeeringDBFacilityId,
                                     };
            if (this.IsValidConnection(peeringRequest))
            {
                return peeringRequest;
            }

            throw new PSArgumentException(string.Format(Resources.Error_InvalidConnection));
        }
    }
}
