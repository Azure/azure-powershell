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
<<<<<<< HEAD
    using System.Collections.Generic;
    using System.Linq;
=======
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    using System.Management.Automation;

    using Microsoft.Azure.Commands.Peering.Properties;
    using Microsoft.Azure.Management.Peering.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;
<<<<<<< HEAD
    using Microsoft.Rest.Azure;

    using Newtonsoft.Json;
=======
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

    /// <inheritdoc />
    /// <summary>
    ///     Updates the InputObject object.
    /// </summary>
    [Cmdlet(
        VerbsCommon.Set,
<<<<<<< HEAD
        "AzPeeringExchangeConnectionObject",
        DefaultParameterSetName = Constants.ParameterSetNameMd5Authentication, SupportsShouldProcess = false)]
=======
        Constants.AzPeeringExchangeConnectionObject,
        DefaultParameterSetName = Constants.ParameterSetNameIPv4Address, SupportsShouldProcess = false)]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    [OutputType(typeof(PSExchangeConnection))]
    public class SetAzureExchangePeeringConnectionCommand : PeeringBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the legacy InputObject.
        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = Constants.PeeringExchangeConnectionHelp,
             ParameterSetName = Constants.ParameterSetNameIPv4Address),
         Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = Constants.PeeringExchangeConnectionHelp,
             ParameterSetName = Constants.ParameterSetNameIPv6Address),
         Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = Constants.PeeringExchangeConnectionHelp,
             ParameterSetName = Constants.ParameterSetNameMd5Authentication)]
        public PSExchangeConnection InputObject { get; set; }

        /// <summary>
        /// Gets or sets the session ipv4.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.HelpSessionIPv4Prefix,
            ParameterSetName = Constants.ParameterSetNameIPv4Address)]
        [ValidateNotNullOrEmpty]
        public string PeerSessionIPv4Address { get; set; }

        /// <summary>
        /// Gets or sets the max prefixes advertised ipv4.
        /// </summary>
        [Parameter(
             Mandatory = false,
             HelpMessage = Constants.HelpMaxAdvertisedIPv4,
             ParameterSetName = Constants.ParameterSetNameIPv4Address), ValidateRange(1, 20000)]
        public int? MaxPrefixesAdvertisedIPv4 { get; set; }

        /// <summary>
        /// Gets or sets the session ipv4.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.HelpSessionIPv4Prefix,
            ParameterSetName = Constants.ParameterSetNameIPv6Address)]
        [ValidateNotNullOrEmpty]
        public string PeerSessionIPv6Address { get; set; }

        /// <summary>
        /// Gets or sets the max prefixes advertised ipv4.
        /// </summary>
        [Parameter(
             Mandatory = false,
             HelpMessage = Constants.HelpMaxAdvertisedIPv4,
             ParameterSetName = Constants.ParameterSetNameIPv6Address), ValidateRange(1, 20000)]
        public int? MaxPrefixesAdvertisedIPv6 { get; set; }

        /// <summary>
        /// Gets or sets the m d 5 authentication key.
        /// </summary>
        [Parameter(
<<<<<<< HEAD
            Mandatory = false,
=======
            Mandatory = true,
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
                PSExchangeConnection newRequest = null;
                if (this.ParameterSetName.Equals(
                    Constants.ParameterSetNameIPv4Address,
                    StringComparison.OrdinalIgnoreCase))
                {
                    newRequest = this.UpdateIpV4Prefix();
                }
                else if (this.ParameterSetName.Equals(
                    Constants.ParameterSetNameIPv6Address,
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

                this.WriteObject(newRequest);
            }
            catch (InvalidOperationException mapException)
            {
                throw new InvalidOperationException(string.Format(Resources.Error_Mapping, mapException));
            }
            catch (ErrorResponseException ex)
            {
<<<<<<< HEAD
                                var error = this.GetErrorCodeAndMessageFromArmOrErm(ex);
=======
                var error = this.GetErrorCodeAndMessageFromArmOrErm(ex);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                throw new ErrorResponseException(string.Format(Resources.Error_CloudError, error.Code, error.Message));
            }
        }

        /// <summary>
        ///     The update InputObject offer.
        /// </summary>
        /// <returns>
        ///     The <see cref="PSExchangeConnection" />.
        /// </returns>
        private PSExchangeConnection UpdateMD5Authentication()
        {
<<<<<<< HEAD
                this.InputObject.BgpSession.Md5AuthenticationKey = this.MD5AuthenticationKey;
                if (this.IsValidConnection(this.InputObject))
                    return this.InputObject;
=======
            this.InputObject.BgpSession.Md5AuthenticationKey = this.MD5AuthenticationKey;
            if (this.IsValidConnection(this.InputObject))
                return this.InputObject;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

            throw new InvalidOperationException(string.Format(Resources.Error_InvalidInputObject_Exchange));
        }

        /// <summary>
        ///     The update InputObject offer.
        /// </summary>
        /// <returns>
        ///     The <see cref="PSExchangeConnection" />.
        /// </returns>
        private PSExchangeConnection UpdateIpV4Prefix()
        {
<<<<<<< HEAD
                this.InputObject.BgpSession.MaxPrefixesAdvertisedV4 =
                    this.MaxPrefixesAdvertisedIPv4 == null ? (this.InputObject.BgpSession.MaxPrefixesAdvertisedV4 != 0 ? this.InputObject.BgpSession.MaxPrefixesAdvertisedV4 : 2000) : 2000;
                this.InputObject.BgpSession.PeerSessionIPv6Address = this.ValidatePrefix(this.PeerSessionIPv4Address, Constants.Exchange);
                if (this.IsValidConnection(this.InputObject))
                    return this.InputObject;
=======
            this.InputObject.BgpSession.MaxPrefixesAdvertisedV4 =
                this.MaxPrefixesAdvertisedIPv4 == null ? (this.InputObject.BgpSession.MaxPrefixesAdvertisedV4 != 0 ? this.InputObject.BgpSession.MaxPrefixesAdvertisedV4 : 20000) : this.MaxPrefixesAdvertisedIPv4;
            this.InputObject.BgpSession.PeerSessionIPv4Address = this.PeerSessionIPv4Address?.Trim();
            if (this.IsValidConnection(this.InputObject))
                return this.InputObject;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

            throw new InvalidOperationException(string.Format(Resources.Error_InvalidInputObject_Exchange));
        }

        /// <summary>
        ///     The update InputObject offer.
        /// </summary>
        /// <returns>
        ///     The <see cref="PSExchangeConnection" />.
        /// </returns>
        private PSExchangeConnection UpdateIpV6Prefix()
        {
<<<<<<< HEAD
                this.InputObject.BgpSession.MaxPrefixesAdvertisedV6 =
                    this.MaxPrefixesAdvertisedIPv6 == null ? (this.InputObject.BgpSession.MaxPrefixesAdvertisedV6 != 0 ? this.InputObject.BgpSession.MaxPrefixesAdvertisedV6 : 2000) : 2000;
                this.InputObject.BgpSession.PeerSessionIPv6Address = this.ValidatePrefix(this.PeerSessionIPv6Address, Constants.Exchange);
                if (this.IsValidConnection(this.InputObject))
                    return this.InputObject;
=======
            this.InputObject.BgpSession.MaxPrefixesAdvertisedV6 =
                this.MaxPrefixesAdvertisedIPv6 == null ? (this.InputObject.BgpSession.MaxPrefixesAdvertisedV6 != 0 ? this.InputObject.BgpSession.MaxPrefixesAdvertisedV6 : 2000) : this.MaxPrefixesAdvertisedIPv6;
            this.InputObject.BgpSession.PeerSessionIPv6Address = this.PeerSessionIPv6Address?.Trim();
            if (this.IsValidConnection(this.InputObject))
                return this.InputObject;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

            throw new InvalidOperationException(string.Format(Resources.Error_InvalidInputObject_Exchange));
        }
    }
}