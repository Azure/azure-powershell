// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Microsoft" file="SetAzurePeeringCommand.cs">
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
    ///     Updates the Peering object.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzDirectPeeringMD5Authentication", DefaultParameterSetName = Constants.ParameterSetNameDefault, SupportsShouldProcess = true)]
    [OutputType(typeof(PSPeering))]
    public class SetAzureDirectPeeringMD5AuthenticationCommand : PeeringBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the legacy Peering.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = Constants.ParameterSetNameDefault,
            DontShow = true)]
        public PSPeering Peering { get; set; }

        /// <summary>
        /// Gets or sets the connection index.
        /// </summary>
        [Parameter(
             Position = Constants.PositionPeeringOne,
             Mandatory = true,
             HelpMessage = Constants.PeeringDirectConnectionHelp,
             ParameterSetName = Constants.ParameterSetNameDefault),
         PSArgumentCompleter("0", "1", "2"),
         ValidateRange(0, 2), ValidateNotNullOrEmpty]
        public virtual int? ConnectionIndex { get; set; }

        /// <summary>
        /// Gets or sets the m d 5 authentication key.
        /// </summary>
        [Parameter(
             Position = Constants.PositionPeeringOne,
             Mandatory = false,
             HelpMessage = Constants.MD5AuthenticationKeyHelp,
             ParameterSetName = Constants.ParameterSetNameDefault)]
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
                var peeringRequest = this.UpdatePeeringOffer();
                this.WriteObject(peeringRequest);
            }
            catch (InvalidOperationException mapException)
            {
                throw new InvalidOperationException($"Failed to map object {mapException}");
            }
            catch (ErrorResponseException ex)
            {
                throw new ErrorResponseException($"Error:{ex.Response.ReasonPhrase} reason:{ex.Body.Code} message:{ex.Body.Message}");
            }
        }

        /// <summary>
        ///     The update Peering offer.
        /// </summary>
        /// <returns>
        ///     The <see cref="PSPeering" />.
        /// </returns>
        private PSPeering UpdatePeeringOffer()
        {
            if (this.Peering is PSDirectPeeringModelView directPeer)
            {
                var resourceGroupName = this.GetResourceGroupNameFromId(directPeer.Id);
                var peeringName = this.GetPeeringNameFromId(directPeer.Id);
                var peering = new PSPeering
                                  {
                                      Kind = directPeer.Kind,
                                      PeeringLocation = directPeer.PeeringLocation,
                                      Location = directPeer.Location,
                                      Sku = directPeer.Sku,
                                      Tags = directPeer.Tags,
                                      Direct = new PSPeeringPropertiesDirect
                                                   {
                                                       Connections = directPeer.Connections,
                                                       PeerAsn = directPeer.PeerAsn,
                                                       UseForPeeringService = directPeer.UseForPeeringService
                                                   }
                                  };

                if (this.ConnectionIndex >= directPeer.Connections.Count - 1)
                    throw new IndexOutOfRangeException($"ConnectionIndex out of range {this.ConnectionIndex}");
                var connectionIndex = this.ConnectionIndex;
                if (connectionIndex != null)
                    peering.Direct.Connections[(int)connectionIndex].BgpSession.Md5AuthenticationKey =
                        this.MD5AuthenticationKey;
                try
                {
                    this.PeeringClient.CreateOrUpdate(
                        resourceGroupName.ToString(),
                        peeringName.ToString(),
                        PeeringResourceManagerProfile.Mapper.Map<PeeringModel>(peering));
                }
                catch (HttpOperationException ex)
                {
                    throw new Exception(
                        $"Request URL: {ex.Request.RequestUri} StatusCode: {ex.Response.StatusCode} Content: {ex.Response.Content}");
                }

                return new PSDirectPeeringModelView(PeeringResourceManagerProfile.Mapper.Map<PSPeering>(this.PeeringClient.Get(resourceGroupName.ToString(), peeringName.ToString())));
            }

            throw new InvalidOperationException($"Exchange Peering does not support this operation.");
        }
    }
}