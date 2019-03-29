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
    [Cmdlet(VerbsCommon.Set, "AzDirectPeeringBandwidth", DefaultParameterSetName = Constants.ParameterSetNameDefault, SupportsShouldProcess = true)]
    [OutputType(typeof(PSPeering))]
    public class SetAzureDirectPeeringBandwidthCommand : PeeringBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the legacy Peering.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = Constants.ParameterSetNameDefault,
            DontShow = true)]
        public PSPeering Peering { get; set; }

        [Parameter(
             Mandatory = true,
             HelpMessage = Constants.PeeringDirectConnectionIndexHelp,
             ParameterSetName = Constants.ParameterSetNameDefault),
         PSArgumentCompleter("0", "1", "2"),
         ValidateRange(0, 2), ValidateNotNullOrEmpty]
        public virtual int? ConnectionIndex { get; set; }

        /// <summary>
        ///     Bandwidth offered at this location.
        /// </summary>
        [Parameter(
             Mandatory = true,
             HelpMessage = Constants.BandwidthHelp,
             ParameterSetName = Constants.ParameterSetNameDefault),
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
                    Tags = directPeer.Tags
                };
                peering.Direct = new PSPeeringPropertiesDirect
                {
                    Connections = directPeer.Connections,
                    PeerAsn = directPeer.PeerAsn,
                    UseForPeeringService = directPeer.UseForPeeringService
                };

                if (this.ConnectionIndex >= directPeer.Connections.Count - 1)
                    throw new IndexOutOfRangeException($"ConnectionIndex out of range {this.ConnectionIndex}");
                var connectionIndex = this.ConnectionIndex;
                if (connectionIndex != null)
                    if (this.ValidBandwidth(this.BandwidthInMbps))
                        peering.Direct.Connections[(int)connectionIndex].BandwidthInMbps =
                            this.BandwidthInMbps >= directPeer.Connections[(int)connectionIndex].BandwidthInMbps
                                ? this.BandwidthInMbps
                                : throw new ArgumentOutOfRangeException($"Only Bandwidth upgrades are supported.");
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

            throw new InvalidOperationException("Exchange Peering does not support this operation.");
        }
    }
}