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
namespace Microsoft.Azure.PowerShell.Cmdlets.Peering.PeerAsn
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Net.Http;

    using Microsoft.Azure.Commands.Peering.Properties;
    using Microsoft.Azure.Management.Peering;
    using Microsoft.Azure.Management.Peering.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;

    using Newtonsoft.Json;

    /// <summary>
    ///     New Azure InputObject Command-let
    /// </summary>
    [Cmdlet(VerbsCommon.New, Constants.AzPeerAsn, SupportsShouldProcess = true, DefaultParameterSetName = Constants.ParameterSetNameByName)]
    [OutputType(typeof(PSPeerAsn))]
    public class NewAzurePeerAsn : PeeringBaseCmdlet
    {
        /// <summary>
        ///     Gets or sets The InputObject name
        /// </summary>
        [Parameter(Position = 0, Mandatory = true, HelpMessage = Constants.PeeringNameHelp, ParameterSetName = Constants.ParameterSetNameByName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets The InputObject name
        /// </summary>
        [Parameter(Position = 1, Mandatory = true, HelpMessage = Constants.PeeringNameHelp, ParameterSetName = Constants.ParameterSetNameByName)]
        [ValidateNotNullOrEmpty]
        public string PeerName { get; set; }

        /// <summary>
        ///     Gets or sets Peer ASN
        /// </summary>
        [Parameter(Position = 2, Mandatory = true, HelpMessage = Constants.PeeringAsnHelp, ParameterSetName = Constants.ParameterSetNameByName)]
        [ValidateNotNullOrEmpty]
        public int PeerAsn { get; set; }

        /// <summary>
        ///     Gets or sets the contact details
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = Constants.EmailsHelp, ParameterSetName = Constants.ParameterSetNameByName)]
        [ValidateNotNullOrEmpty]
        public PSContactDetail[] ContactDetail { get; set; }

        /// <summary>
        ///     The AsJob parameter to run in the background.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = Constants.AsJobHelp)]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        ///     The inherited Execute function.
        /// </summary>
        public override void Execute()
        {
            base.Execute();
            try
            {
                this.WriteObject(this.CreatePeerInfo());
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
        /// The create direct peering.
        /// </summary>
        /// <returns>
        /// The <see cref="PSPeering"/>.
        /// </returns>
        /// <exception cref="PSArgumentNullException">
        /// </exception>
        /// <exception cref="PSArgumentException">
        /// </exception>
        /// <exception cref="Exception">
        /// </exception>
        /// <exception cref="ErrorResponseException">
        /// </exception>
        /// <exception cref="HttpRequestException">
        /// </exception>
        private PSPeerAsn CreatePeerInfo()
        {
            var peerInfo = new PSPeerAsn(
                peerAsnProperty: this.PeerAsn,
                peerContactDetail: this.ContactDetail,
                peerName: this.PeerName,
                name: this.Name);
            return this.PutPeerInfo(peerInfo);
        }

        /// <summary>
        /// The put new InputObject.
        /// </summary>
        /// <param name="psPeerInfo">
        /// The new InputObject.
        /// </param>
        /// <returns>
        /// The <see cref="PSPeerAsn"/>.
        /// </returns>
        private PSPeerAsn PutPeerInfo(PSPeerAsn psPeerInfo)
        {
            var peerInfo = this.PeerAsnClient.CreateOrUpdate(
                this.Name,
                PeeringResourceManagerProfile.Mapper.Map<PeerAsn>(psPeerInfo));
            return PeeringResourceManagerProfile.Mapper.Map<PSPeerAsn>(peerInfo);
        }
    }
}