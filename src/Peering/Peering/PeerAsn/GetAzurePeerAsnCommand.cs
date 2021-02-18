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
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;

    using Microsoft.Azure.Commands.Peering.Properties;
<<<<<<< HEAD
=======
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    using Microsoft.Azure.Management.Peering;
    using Microsoft.Azure.Management.Peering.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;

<<<<<<< HEAD
    using Newtonsoft.Json;

    /// <summary>
    ///     The get InputObject locations.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzPeerAsn")]
=======
    /// <summary>
    ///     The get InputObject locations.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Constants.AzPeerAsn, DefaultParameterSetName = Constants.ParameterSetNameByName)]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    [OutputType(typeof(PSPeerAsn))]
    public class GetAzurePeerAsn : PeeringBaseCmdlet
    {
        /// <summary>
<<<<<<< HEAD
=======
        /// Gets or sets the resource id.
        /// </summary>
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = Constants.ResourceIdHelp,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.ParameterSetNameByResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        ///     Gets or sets The InputObject name
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.ParameterSetNameByName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <inheritdoc />
        /// <summary>
        ///     The base execute method.
        /// </summary>
        public override void Execute()
        {
            try
            {
                base.Execute();
<<<<<<< HEAD
                if (this.ParameterSetName.Equals(Constants.ParameterSetNameByName))
=======
                if (this.ParameterSetName.Equals(Constants.ParameterSetNameByResourceId))
                {
                    var psPeerAsnInfo = this.GetPeerAsn(this.ResourceId.Split('/').Last());
                    this.WriteObject(psPeerAsnInfo, true);
                }
                else if (this.ParameterSetName.Equals(Constants.ParameterSetNameByName) && !string.IsNullOrEmpty(this.Name))
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                {
                    var psPeerAsnInfo = this.GetPeerAsn(this.Name);
                    this.WriteObject(psPeerAsnInfo, true);
                }
                else
                {
                    var psPeerInfo = this.ListPeerAsn();
                    this.WriteObject(psPeerInfo, true);
                }
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
        /// The get peer asn.
        /// </summary>
        /// <param name="peerName">
        /// The peer name.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        private object GetPeerAsn(string peerName)
        {
<<<<<<< HEAD
            return this.ToPeeringAsnPs(this.PeeringManagementClient.PeerAsns.Get(peerName));
=======
            return this.ToPeeringAsnPs(this.PeerAsnClient.Get(peerName));
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }

        /// <summary>
        /// The list peer asn.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        private List<object> ListPeerAsn()
        {
<<<<<<< HEAD
            var peerInfoList = this.PeeringManagementClient.PeerAsns.ListBySubscription();
=======
            var peerInfoList = this.PeerAsnClient.ListBySubscription();
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            return peerInfoList.Select(peerAsn => this.ToPeeringAsnPs(peerAsn)).ToList();
        }
    }
}