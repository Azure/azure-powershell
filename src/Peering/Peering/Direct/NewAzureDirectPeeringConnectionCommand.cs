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

namespace Microsoft.Azure.PowerShell.Cmdlets.Peering.Direct
{
    using System;
    using System.Management.Automation;

    using Microsoft.Azure.Commands.Peering.Properties;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;

    /// <summary>
    /// NewAzureDirectPeeringConnectionCommand
    /// </summary>
    [Cmdlet(
        VerbsCommon.New,
        "AzPeeringDirectConnectionObject",
        DefaultParameterSetName = Constants.ParameterSetNameIPv4Prefix, SupportsShouldProcess = false)]
    [OutputType(typeof(PSDirectConnection))]
    public class NewAzureDirectPeeringConnectionCommand : PeeringBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the InputObject Facility DB.
        /// </summary>
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = Constants.HelpPeeringDBFacilityId,
            ParameterSetName = Constants.ParameterSetNameIPv4Prefix)]
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = Constants.HelpPeeringDBFacilityId,
            ParameterSetName = Constants.ParameterSetNameIPv6Prefix)]
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = Constants.HelpPeeringDBFacilityId,
            ParameterSetName = Constants.ParameterSetNameIPv4Prefix + Constants.ParameterSetNameIPv6Prefix)]
        [ValidateNotNullOrEmpty]
        public int? PeeringDBFacilityId { get; set; }

        /// <summary>
        /// Gets or sets the session ipv4.
        /// </summary>
        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = Constants.HelpSessionIPv4Prefix,
            ParameterSetName = Constants.ParameterSetNameIPv4Prefix)]
        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.HelpSessionIPv4Prefix,
            ParameterSetName = Constants.ParameterSetNameIPv4Prefix + Constants.ParameterSetNameIPv6Prefix)]
        [ValidateNotNullOrEmpty]
        public string SessionPrefixV4 { get; set; }

        /// <summary>
        /// Gets or sets the session ipv6.
        /// </summary>
        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = Constants.HelpSessionIPv6Prefix,
            ParameterSetName = Constants.ParameterSetNameIPv6Prefix)]
        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.HelpSessionIPv6Prefix,
            ParameterSetName = Constants.ParameterSetNameIPv4Prefix + Constants.ParameterSetNameIPv6Prefix)]
        public string SessionPrefixV6 { get; set; }

        /// <summary>
        ///     Bandwidth offered at this location.
        /// </summary>
        [Parameter(
             Position = 2,
             Mandatory = true,
             HelpMessage = Constants.BandwidthHelp,
             ParameterSetName = Constants.ParameterSetNameIPv4Prefix),
         Parameter(
             Position = 2,
             Mandatory = true,
             HelpMessage = Constants.BandwidthHelp,
             ParameterSetName = Constants.ParameterSetNameIPv6Prefix),
         Parameter(
             Position = 2,
             Mandatory = true,
             HelpMessage = Constants.BandwidthHelp,
             ParameterSetName = Constants.ParameterSetNameIPv4Prefix + Constants.ParameterSetNameIPv6Prefix),
         PSArgumentCompleter("10000", "20000", "30000", "40000", "50000", "60000", "70000", "80000", "90000", "100000"),
         ValidateRange(Constants.MinRange, Constants.MaxRange), ValidateNotNullOrEmpty]
        public int? BandwidthInMbps { get; set; }

        /// <summary>
        /// Gets or sets the max prefixes advertised ipv4.
        /// </summary>
        [Parameter(
             Mandatory = false,
             HelpMessage = Constants.HelpMaxAdvertisedIPv4,
             ParameterSetName = Constants.ParameterSetNameIPv4Prefix),
         Parameter(
             Mandatory = false,
             HelpMessage = Constants.HelpMaxAdvertisedIPv4,
             ParameterSetName = Constants.ParameterSetNameIPv4Prefix + Constants.ParameterSetNameIPv6Prefix),
         ValidateRange(1, 20000)]
        public int? MaxPrefixesAdvertisedIPv4 { get; set; }

        /// <summary>
        /// Gets or sets the max prefixes advertised ipv6.
        /// </summary>
        [Parameter(
             Mandatory = false,
             HelpMessage = Constants.HelpMaxAdvertisedIPv6,
             ParameterSetName = Constants.ParameterSetNameIPv6Prefix),
         Parameter(
             Mandatory = false,
             HelpMessage = Constants.HelpMaxAdvertisedIPv6,
             ParameterSetName = Constants.ParameterSetNameIPv4Prefix + Constants.ParameterSetNameIPv6Prefix),
         ValidateRange(1, 2000)]
        public int? MaxPrefixesAdvertisedIPv6 { get; set; }

        /// <summary>
        /// Gets or sets the m d 5 authentication key.
        /// </summary>
        [Parameter(
             Mandatory = false,
             HelpMessage = Constants.MD5AuthenticationKeyHelp,
             ParameterSetName = Constants.ParameterSetNameIPv4Prefix),
         Parameter(
             Mandatory = false,
             HelpMessage = Constants.MD5AuthenticationKeyHelp,
             ParameterSetName = Constants.ParameterSetNameIPv6Prefix),
         Parameter(
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
            this.WriteObject(this.CreateDirectPeering());
        }

        /// <summary>
        /// The create InputObject.
        /// </summary>
        /// <returns>
        /// The <see cref="PSDirectConnection"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        private PSDirectConnection CreateDirectPeering()
        {

            var peeringRequest = new PSDirectConnection
                                     {
                                         BandwidthInMbps = this.BandwidthInMbps,
                                         PeeringDBFacilityId = this.PeeringDBFacilityId,
                                         BgpSession = new PSBgpSession
                                                          {
                                                              MaxPrefixesAdvertisedV4 = !string.IsNullOrEmpty(this.SessionPrefixV4) ? (this.MaxPrefixesAdvertisedIPv4 ?? 20000) : (int?)null,
                                                              MaxPrefixesAdvertisedV6 = !string.IsNullOrEmpty(this.SessionPrefixV6) ? (this.MaxPrefixesAdvertisedIPv6 ?? 2000) : (int?)null,
                                             SessionPrefixV4 =
                                                                  this.ValidatePrefix(
                                                                      this.SessionPrefixV4,
                                                                      Constants.Direct),
                                                              SessionPrefixV6 =
                                                                  this.ValidatePrefix(
                                                                      this.SessionPrefixV6,
                                                                      Constants.Direct),
                                                              Md5AuthenticationKey = this.MD5AuthenticationKey
                                                          }
                                     };

            if (this.IsValidConnection(peeringRequest)) return peeringRequest;
            throw new PSArgumentException(string.Format(Resources.Error_InvalidConnection));
        }
    }
}
