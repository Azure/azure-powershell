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
    using Microsoft.Azure.Management.Peering.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;

    /// <inheritdoc />
    /// <summary>
    ///     Updates the InputObject object.
    /// </summary>
    [Cmdlet(
        VerbsCommon.Set,
        Constants.AzPeeringExchangeConnectionObject,
        DefaultParameterSetName = Constants.ParameterSetNameIPv4Address, SupportsShouldProcess = false)]
    [OutputType(typeof(PSExchangeConnection))]
    public class SetAzureExchangePeeringConnectionCommand : PeeringBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the legacy InputObject.
        /// </summary>
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
            Mandatory = true,
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
                var error = this.GetErrorCodeAndMessageFromArmOrErm(ex);
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
            this.InputObject.BgpSession.Md5AuthenticationKey = this.MD5AuthenticationKey;
            if (this.IsValidConnection(this.InputObject))
                return this.InputObject;

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
            this.InputObject.BgpSession.MaxPrefixesAdvertisedV4 =
                this.MaxPrefixesAdvertisedIPv4 == null ? (this.InputObject.BgpSession.MaxPrefixesAdvertisedV4 != 0 ? this.InputObject.BgpSession.MaxPrefixesAdvertisedV4 : 20000) : this.MaxPrefixesAdvertisedIPv4;
            this.InputObject.BgpSession.PeerSessionIPv4Address = this.PeerSessionIPv4Address?.Trim();
            if (this.IsValidConnection(this.InputObject))
                return this.InputObject;

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
            this.InputObject.BgpSession.MaxPrefixesAdvertisedV6 =
                this.MaxPrefixesAdvertisedIPv6 == null ? (this.InputObject.BgpSession.MaxPrefixesAdvertisedV6 != 0 ? this.InputObject.BgpSession.MaxPrefixesAdvertisedV6 : 2000) : this.MaxPrefixesAdvertisedIPv6;
            this.InputObject.BgpSession.PeerSessionIPv6Address = this.PeerSessionIPv6Address?.Trim();
            if (this.IsValidConnection(this.InputObject))
                return this.InputObject;

            throw new InvalidOperationException(string.Format(Resources.Error_InvalidInputObject_Exchange));
        }
    }
}