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
    [Cmdlet(
        VerbsCommon.Set,
        "AzPeeringDirectConnectionObject",
        DefaultParameterSetName = Constants.ParameterSetNameBandwidth,
        SupportsShouldProcess = true)]
    [OutputType(typeof(PSDirectConnection))]
    public class SetAzureDirectPeeringConnectionCommand : PeeringBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the legacy InputObject.
        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             ParameterSetName = Constants.ParameterSetNameIPv4Prefix,
             DontShow = true),
         Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             ParameterSetName = Constants.ParameterSetNameIPv6Prefix,
             DontShow = true),
         Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             ParameterSetName = Constants.ParameterSetNameBandwidth,
             DontShow = true),
         Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             ParameterSetName = Constants.ParameterSetNameMd5Authentication,
             DontShow = true)]
        public PSDirectConnection InputObject { get; set; }

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
             ParameterSetName = Constants.ParameterSetNameIPv4Prefix), ValidateRange(1, 20000)]
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
             ParameterSetName = Constants.ParameterSetNameIPv6Prefix), ValidateRange(1, 20000)]
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
                PSDirectConnection newRequest = null;
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

                this.WriteObject(newRequest);
            }
            catch (InvalidOperationException mapException)
            {
                throw new InvalidOperationException($"Failed to map object {mapException}");
            }
            catch (ErrorResponseException ex)
            {
                throw new ErrorResponseException(
                    $"Error:{ex.Response.ReasonPhrase} reason:{ex.Body?.Code} message:{ex.Body?.Message}");
            }
        }

        /// <summary>
        ///     The update InputObject offer.
        /// </summary>
        /// <returns>
        ///     The <see cref="PSDirectConnection" />.
        /// </returns>
        private PSDirectConnection UpdatePeeringOffer()
        {
            if (this.InputObject is PSDirectConnection inputObject)
            {
                inputObject.BandwidthInMbps =
                    this.ValidUpgradeBandwidth(inputObject.BandwidthInMbps, this.BandwidthInMbps)
                        ? this.BandwidthInMbps
                        : inputObject.BandwidthInMbps;
                if (this.ValidConnection(inputObject))
                    return inputObject;
            }

            throw new InvalidOperationException("Use Set-AzPeeringExchangeConnectionObject instead.");
        }

        /// <summary>
        ///     The update InputObject offer.
        /// </summary>
        /// <returns>
        ///     The <see cref="PSDirectConnection" />.
        /// </returns>
        private PSDirectConnection UpdateMD5Authentication()
        {
            if (this.InputObject is PSDirectConnection inputObject)
            {
                inputObject.BgpSession.Md5AuthenticationKey = this.MD5AuthenticationKey; 
                if (this.ValidConnection(inputObject))
                    return inputObject;
            }

            throw new InvalidOperationException("Use Set-AzPeeringExchangeConnectionObject instead.");
        }

        /// <summary>
        ///     The update InputObject offer.
        /// </summary>
        /// <returns>
        ///     The <see cref="PSDirectConnection" />.
        /// </returns>
        private PSDirectConnection UpdateIpV4Prefix()
        {
            if (this.InputObject is PSDirectConnection inputObject)
            {
                inputObject.BgpSession.MaxPrefixesAdvertisedV4 =
                    this.MaxPrefixesAdvertisedIPv4 == null ? inputObject.BgpSession.MaxPrefixesAdvertisedV4 : 20000;
                inputObject.BgpSession.SessionPrefixV4 = this.ValidatePrefix(this.SessionPrefixV4, Constants.Direct);
                if (this.ValidConnection(inputObject))
                    return inputObject;
            }

            throw new InvalidOperationException("Use Set-AzPeeringExchangeConnectionObject instead.");
        }

        /// <summary>
        ///     The update InputObject offer.
        /// </summary>
        /// <returns>
        ///     The <see cref="PSDirectConnection" />.
        /// </returns>
        private PSDirectConnection UpdateIpV6Prefix()
        {
            if (this.InputObject is PSDirectConnection inputObject)
            {
                inputObject.BgpSession.MaxPrefixesAdvertisedV6 =
                    this.MaxPrefixesAdvertisedIPv6 == null ? inputObject.BgpSession.MaxPrefixesAdvertisedV6 : 2000;
                inputObject.BgpSession.SessionPrefixV6 = this.ValidatePrefix(this.SessionPrefixV6, Constants.Direct);
                if (this.ValidConnection(inputObject))
                    return inputObject;
            }

            throw new InvalidOperationException("Use Set-AzPeeringExchangeConnectionObject instead.");
        }
    }
}