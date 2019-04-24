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
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;

    using Microsoft.Azure.Commands.Peering.Properties;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Peering.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;
    using Microsoft.Rest.Azure;

    using Newtonsoft.Json;

    /// <inheritdoc />
    /// <summary>
    ///     Updates the InputObject object.
    /// </summary>
    [Cmdlet(
        VerbsCommon.Set,
        "AzPeeringDirectConnectionObject",
        DefaultParameterSetName = Constants.ParameterSetNameBandwidth, SupportsShouldProcess = false)]
    [OutputType(typeof(PSDirectConnection))]
    public class SetAzureDirectPeeringConnectionCommand : PeeringBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the legacy InputObject.
        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = Constants.PeeringDirectConnectionHelp,
             ParameterSetName = Constants.ParameterSetNameIPv4Prefix),
         Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = Constants.PeeringDirectConnectionHelp,
             ParameterSetName = Constants.ParameterSetNameIPv6Prefix),
         Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = Constants.PeeringDirectConnectionHelp,
             ParameterSetName = Constants.ParameterSetNameBandwidth),
         Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = Constants.PeeringDirectConnectionHelp,
             ParameterSetName = Constants.ParameterSetNameMd5Authentication)]
        public PSDirectConnection InputObject { get; set; }

        /// <summary>
        /// Gets or sets the session ipv4.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.HelpSessionIPv4Prefix,
            ParameterSetName = Constants.ParameterSetNameIPv4Prefix)]
        [ValidateNotNullOrEmpty]
        public string SessionPrefixV4 { get; set; }

        /// <summary>
        /// Gets or sets the max prefixes advertised ipv4.
        /// </summary>
        [Parameter(
             Mandatory = false,
             HelpMessage = Constants.HelpMaxAdvertisedIPv4,
             ParameterSetName = Constants.ParameterSetNameIPv4Prefix), ValidateRange(1, 20000)]
        public int? MaxPrefixesAdvertisedIPv4 { get; set; }

        /// <summary>
        /// Gets or sets the session ipv4.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.HelpSessionIPv4Prefix,
            ParameterSetName = Constants.ParameterSetNameIPv6Prefix)]
        [ValidateNotNullOrEmpty]
        public string SessionPrefixV6 { get; set; }

        /// <summary>
        /// Gets or sets the max prefixes advertised ipv4.
        /// </summary>
        [Parameter(
             Mandatory = false,
             HelpMessage = Constants.HelpMaxAdvertisedIPv4,
             ParameterSetName = Constants.ParameterSetNameIPv6Prefix), ValidateRange(1, 20000)]
        public int? MaxPrefixesAdvertisedIPv6 { get; set; }

        /// <summary>
        /// Gets or sets the m d 5 authentication key.
        /// </summary>
        [Parameter(
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
        public int? BandwidthInMbps { get; set; }

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

                this.WriteObject(newRequest);
            }
            catch (InvalidOperationException mapException)
            {
                throw new InvalidOperationException(string.Format(Resources.Error_Mapping, mapException));
            }
            catch (ErrorResponseException ex)
            {
                                var error = ex.Response.Content.Contains("\"error\\\":") ? JsonConvert.DeserializeObject<Dictionary<string, ErrorResponse>>(JsonConvert.DeserializeObject(ex.Response.Content).ToString()).FirstOrDefault().Value : JsonConvert.DeserializeObject<ErrorResponse>(ex.Response.Content);
                throw new ErrorResponseException(string.Format(Resources.Error_CloudError, error.Code, error.Message));
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
                if (this.IsValidConnection(inputObject))
                    return inputObject;
            }

            throw new InvalidOperationException(string.Format(Resources.Error_WrongCommandForDirectObject));
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
                if (this.IsValidConnection(inputObject))
                    return inputObject;
            }

            throw new InvalidOperationException(string.Format(Resources.Error_WrongCommandForDirectObject));
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
                if (this.IsValidConnection(inputObject))
                    return inputObject;
            }

            throw new InvalidOperationException(string.Format(Resources.Error_WrongCommandForDirectObject));
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
                if (this.IsValidConnection(inputObject))
                    return inputObject;
            }

            throw new InvalidOperationException(string.Format(Resources.Error_WrongCommandForDirectObject));
        }
    }
}