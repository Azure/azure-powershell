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
<<<<<<< HEAD
    [Cmdlet(VerbsCommon.New, "AzPeerAsn", SupportsShouldProcess = true)]
=======
    [Cmdlet(VerbsCommon.New, Constants.AzPeerAsn, SupportsShouldProcess = true, DefaultParameterSetName = Constants.ParameterSetNameByName)]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    [OutputType(typeof(PSPeerAsn))]
    public class NewAzurePeerAsn : PeeringBaseCmdlet
    {
        /// <summary>
        ///     Gets or sets The InputObject name
        /// </summary>
<<<<<<< HEAD
        [Parameter(Position = 0, Mandatory = true, HelpMessage = Constants.PeeringNameHelp)]
=======
        [Parameter(Position = 0, Mandatory = true, HelpMessage = Constants.PeeringNameHelp, ParameterSetName = Constants.ParameterSetNameByName)]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets The InputObject name
        /// </summary>
<<<<<<< HEAD
        [Parameter(Position = 1, Mandatory = true, HelpMessage = Constants.PeeringNameHelp)]
=======
        [Parameter(Position = 1, Mandatory = true, HelpMessage = Constants.PeeringNameHelp, ParameterSetName = Constants.ParameterSetNameByName)]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        [ValidateNotNullOrEmpty]
        public string PeerName { get; set; }

        /// <summary>
        ///     Gets or sets Peer ASN
        /// </summary>
<<<<<<< HEAD
        [Parameter(Position = 2, Mandatory = true, HelpMessage = Constants.PeeringAsnHelp)]
=======
        [Parameter(Position = 2, Mandatory = true, HelpMessage = Constants.PeeringAsnHelp, ParameterSetName = Constants.ParameterSetNameByName)]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        [ValidateNotNullOrEmpty]
        public int PeerAsn { get; set; }

        /// <summary>
<<<<<<< HEAD
        ///     Gets or sets the Email
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = Constants.EmailsHelp)]
        [ValidateNotNullOrEmpty]
        public string[] Email { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = Constants.PhoneHelp)]
        [ValidateNotNullOrEmpty]
        public string[] Phone { get; set; }
=======
        ///     Gets or sets the contact details
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = Constants.EmailsHelp, ParameterSetName = Constants.ParameterSetNameByName)]
        [ValidateNotNullOrEmpty]
        public PSContactDetail[] ContactDetail { get; set; }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

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
<<<<<<< HEAD
                var error = ex.Response.Content.Contains("\"error\":\"") ? JsonConvert.DeserializeObject<Dictionary<string, ErrorResponse>>(ex.Response.Content).FirstOrDefault().Value : JsonConvert.DeserializeObject<ErrorResponse>(ex.Response.Content);
=======
                var error = this.GetErrorCodeAndMessageFromArmOrErm(ex);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
        /// <exception cref="ArmErrorException">
        /// </exception>
        /// <exception cref="HttpRequestException">
        /// </exception>
        private PSPeerAsn CreatePeerInfo()
        {
<<<<<<< HEAD
            foreach (var s in Email)
            {
                HelperExtensionMethods.IsValidEmail(s);
            }

            var contactInfo = new PSContactInfo(emails: this.Email, phone: this.Phone);
            var peerInfo = new PSPeerAsn(
                peerAsnProperty: this.PeerAsn,
                peerContactInfo: contactInfo,
=======
            var peerInfo = new PSPeerAsn(
                peerAsnProperty: this.PeerAsn,
                peerContactDetail: this.ContactDetail,
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                peerName: this.PeerName,
                name: this.Name);
            return this.PutPeerInfo(peerInfo);
        }

        /// <summary>
        /// The put new InputObject.
        /// </summary>
        /// <param name="newPeering">
        /// The new InputObject.
        /// </param>
        /// <returns>
        /// The <see cref="PSPeerAsn"/>.
        /// </returns>
        private PSPeerAsn PutPeerInfo(PSPeerAsn psPeerInfo)
        {
<<<<<<< HEAD
            var peerInfo = this.PeeringManagementClient.PeerAsns.CreateOrUpdate(
=======
            var peerInfo = this.PeerAsnClient.CreateOrUpdate(
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                this.Name,
                PeeringResourceManagerProfile.Mapper.Map<PeerAsn>(psPeerInfo));
            return PeeringResourceManagerProfile.Mapper.Map<PSPeerAsn>(peerInfo);
        }
    }
}