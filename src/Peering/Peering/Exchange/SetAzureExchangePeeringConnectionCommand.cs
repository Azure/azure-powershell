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
    [Cmdlet(
        VerbsCommon.Set,
        "AzPeeringExchangeConnectionObject",
        DefaultParameterSetName = Constants.ParameterSetNameMd5Authentication,
        SupportsShouldProcess = true)]
    [OutputType(typeof(PSExchangeConnection))]
    public class SetAzureExchangePeeringConnectionCommand : PeeringBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the legacy InputObject.
        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             ParameterSetName = Constants.ParameterSetNameIPv4Address,
             DontShow = true),
         Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             ParameterSetName = Constants.ParameterSetNameIPv6Address,
             DontShow = true),
         Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             ParameterSetName = Constants.ParameterSetNameMd5Authentication,
             DontShow = true)]
        public PSExchangeConnection InputObject { get; set; }

        /// <summary>
        /// Gets or sets the session ipv4.
        /// </summary>
        [Parameter(
            Position = 2,
            Mandatory = true,
            HelpMessage = Constants.HelpSessionIPv4Prefix,
            ParameterSetName = Constants.ParameterSetNameIPv4Address)]
        [ValidateNotNullOrEmpty]
        public virtual string PeerSessionIPv4Address { get; set; }

        /// <summary>
        /// Gets or sets the max prefixes advertised ipv4.
        /// </summary>
        [Parameter(
             Mandatory = false,
             HelpMessage = Constants.HelpMaxAdvertisedIPv4,
             ParameterSetName = Constants.ParameterSetNameIPv4Address), ValidateRange(1, 20000)]
        public virtual int? MaxPrefixesAdvertisedIPv4 { get; set; }

        /// <summary>
        /// Gets or sets the session ipv4.
        /// </summary>
        [Parameter(
            Position = 2,
            Mandatory = true,
            HelpMessage = Constants.HelpSessionIPv4Prefix,
            ParameterSetName = Constants.ParameterSetNameIPv6Address)]
        [ValidateNotNullOrEmpty]
        public virtual string PeerSessionIPv6Address { get; set; }

        /// <summary>
        /// Gets or sets the max prefixes advertised ipv4.
        /// </summary>
        [Parameter(
             Mandatory = false,
             HelpMessage = Constants.HelpMaxAdvertisedIPv4,
             ParameterSetName = Constants.ParameterSetNameIPv6Address), ValidateRange(1, 20000)]
        public virtual int? MaxPrefixesAdvertisedIPv6 { get; set; }

        /// <summary>
        /// Gets or sets the m d 5 authentication key.
        /// </summary>
        [Parameter(
            Position = 1,
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
        ///     The <see cref="PSExchangeConnection" />.
        /// </returns>
        private PSExchangeConnection UpdateMD5Authentication()
        {
            if (this.InputObject is PSExchangeConnection inputObject)
            {
                inputObject.BgpSession.Md5AuthenticationKey = this.MD5AuthenticationKey;
                if (this.ValidConnection(inputObject))
                    return inputObject;
            }

            throw new InvalidOperationException($"Exchange InputObject does not support this operation.");
        }

        /// <summary>
        ///     The update InputObject offer.
        /// </summary>
        /// <returns>
        ///     The <see cref="PSExchangeConnection" />.
        /// </returns>
        private PSExchangeConnection UpdateIpV4Prefix()
        {
            if (this.InputObject is PSExchangeConnection inputObject)
            {
                inputObject.BgpSession.PeerSessionIPv4Address = this.PeerSessionIPv4Address;
                if (this.MaxPrefixesAdvertisedIPv4 != null)
                {
                    inputObject.BgpSession.MaxPrefixesAdvertisedV4 = this.MaxPrefixesAdvertisedIPv4;
                }
                if (this.ValidConnection(inputObject))
                    return inputObject;
            }

            throw new InvalidOperationException($"Exchange InputObject does not support this operation.");
        }

        /// <summary>
        ///     The update InputObject offer.
        /// </summary>
        /// <returns>
        ///     The <see cref="PSExchangeConnection" />.
        /// </returns>
        private PSExchangeConnection UpdateIpV6Prefix()
        {
            if (this.InputObject is PSExchangeConnection inputObject)
            {
                inputObject.BgpSession.PeerSessionIPv6Address = this.PeerSessionIPv6Address;
                if (this.MaxPrefixesAdvertisedIPv6 != null)
                {
                    inputObject.BgpSession.MaxPrefixesAdvertisedV6 = this.MaxPrefixesAdvertisedIPv4;
                }
                if (this.ValidConnection(inputObject))
                    return inputObject;
            }

            throw new InvalidOperationException($"Exchange InputObject does not support this operation.");
        }
    }
}