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

namespace Microsoft.Azure.PowerShell.Cmdlets.Peering.Peering
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
    [Cmdlet(VerbsCommon.Set, "AzPeering", DefaultParameterSetName = Constants.ParameterSetNameDefault, SupportsShouldProcess = true)]
    [OutputType(typeof(PSPeering))]
    public class SetAzurePeeringCommand : PeeringBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the legacy InputObject.
        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = Constants.ParameterSetNameDefault,
            DontShow = true)]
        public PSPeering InputObject { get; set; }

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
                throw new ErrorResponseException($"Error:{ex.Response.ReasonPhrase} reason:{ex.Body?.Code} message:{ex.Body?.Message}");
            }
        }

        /// <summary>
        ///     The update InputObject offer.
        /// </summary>
        /// <returns>
        ///     The <see cref="PSPeering" />.
        /// </returns>
        private PSPeering UpdatePeeringOffer()
        {
            try
            {
                if (this.InputObject is PSDirectPeeringModelView directPeeringModelView)
                {
                    var resourceGroupName = this.GetResourceGroupNameFromId(directPeeringModelView.Id);
                    var peeringName = this.GetPeeringNameFromId(directPeeringModelView.Id);
                    var peering = new PSPeering
                                      {
                                          Kind = directPeeringModelView.Kind,
                                          PeeringLocation = directPeeringModelView.PeeringLocation,
                                          Location = directPeeringModelView.Location,
                                          Sku = directPeeringModelView.Sku,
                                          Tags = directPeeringModelView.Tags
                                      };
                    peering.Direct = new PSPeeringPropertiesDirect
                                         {
                                             Connections = directPeeringModelView.Connections,
                                             PeerAsn = directPeeringModelView.PeerAsn,
                                             UseForPeeringService = directPeeringModelView.UseForPeeringService
                                         };
                    this.PeeringClient.CreateOrUpdate(
                        resourceGroupName.ToString(),
                        peeringName.ToString(),
                        PeeringResourceManagerProfile.Mapper.Map<PeeringModel>(peering));

                    return new PSDirectPeeringModelView(
                        PeeringResourceManagerProfile.Mapper.Map<PSPeering>(
                            this.PeeringClient.Get(resourceGroupName.ToString(), peeringName.ToString())));
                }

                if (this.InputObject is PSExchangePeeringModelView exchangePeeringModelView)
                {
                    var resourceGroupName = this.GetResourceGroupNameFromId(exchangePeeringModelView.Id);
                    var peeringName = this.GetPeeringNameFromId(exchangePeeringModelView.Id);
                    var peering = new PSPeering
                                      {
                                          Kind = exchangePeeringModelView.Kind,
                                          PeeringLocation = exchangePeeringModelView.PeeringLocation,
                                          Location = exchangePeeringModelView.Location,
                                          Sku = exchangePeeringModelView.Sku,
                                          Tags = exchangePeeringModelView.Tags,
                                          Exchange = new PSPeeringPropertiesExchange
                                                         {
                                                             Connections = exchangePeeringModelView.Connections,
                                                             PeerAsn = exchangePeeringModelView.PeerAsn,
                                                         }
                                      };
                    this.PeeringClient.CreateOrUpdate(
                        resourceGroupName.ToString(),
                        peeringName.ToString(),
                        PeeringResourceManagerProfile.Mapper.Map<PeeringModel>(peering));

                    return new PSExchangePeeringModelView(
                        PeeringResourceManagerProfile.Mapper.Map<PSPeering>(
                            this.PeeringClient.Get(resourceGroupName.ToString(), peeringName.ToString())));
                }
            }
            catch (InvalidOperationException mapException)
            {
                throw new InvalidOperationException($"Failed to map object {mapException}");
            }
            catch (ErrorResponseException ex)
            {
                throw new ErrorResponseException($"Error:{ex.Response.ReasonPhrase} reason:{ex.Body?.Code} message:{ex.Body?.Message}");
            }
            throw new InvalidOperationException("Check the input parameters.");
        }
    }
}