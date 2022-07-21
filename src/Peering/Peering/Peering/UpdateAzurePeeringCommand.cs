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
namespace Microsoft.Azure.PowerShell.Cmdlets.Peering.Peering
{
    using System;
    using System.Linq;
    using System.Management.Automation;

    using Microsoft.Azure.Commands.Peering.Properties;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.Management.Peering;
    using Microsoft.Azure.Management.Peering.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;

    /// <inheritdoc />
    /// <summary>
    ///     Updates the InputObject object.
    /// </summary>
    [Cmdlet(
        "Update",
        Constants.AzPeering,
        DefaultParameterSetName = Constants.ParameterSetNameDefault + Constants.Exchange,
        SupportsShouldProcess = true)]
    [OutputType(typeof(PSPeering))]
    public class UpdateAzurePeeringCommand : PeeringBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the input object.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = Constants.ParameterSetNameDefault + Constants.Direct,
            HelpMessage = Constants.PeeringObjectHelp)]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = Constants.PeeringObjectHelp,
            ParameterSetName = Constants.ParameterSetNameDefault + Constants.Exchange)]
        public PSPeering InputObject { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.ParameterSetNameByResourceId + Constants.Direct,
            HelpMessage = Constants.ResourceIdHelp)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.ParameterSetNameByResourceId + Constants.Exchange,
            HelpMessage = Constants.ResourceIdHelp)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets The Resource Group Name
        /// </summary>
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = Constants.ResourceGroupNameHelp,
            ParameterSetName = Constants.Direct)]
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = Constants.ResourceGroupNameHelp,
            ParameterSetName = Constants.Exchange)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets The InputObject NameMD5AuthenticationKeyHelp
        /// </summary>
        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.Direct)]
        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.Exchange)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the exchange session.
        /// </summary>
        [Parameter(
            Mandatory = true,
            Position = 2,
            HelpMessage = Constants.PeeringExchangeConnectionHelp,
            ParameterSetName = Constants.Exchange)]
        [Parameter(
            Mandatory = true,
            Position = 1,
            HelpMessage = Constants.PeeringExchangeConnectionHelp,
            ParameterSetName = Constants.ParameterSetNameByResourceId + Constants.Exchange)]
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.PeeringExchangeConnectionHelp,
            ParameterSetName = Constants.ParameterSetNameDefault + Constants.Exchange)]
        public PSExchangeConnection[] ExchangeConnection { get; set; }

        /// <summary>
        /// Gets or sets the direct session.
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.PeeringDirectConnectionHelp,
            ParameterSetName = Constants.Direct)]
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.PeeringDirectConnectionHelp,
            ParameterSetName = Constants.ParameterSetNameByResourceId + Constants.Direct)]
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.PeeringDirectConnectionHelp,
            ParameterSetName = Constants.ParameterSetNameDefault + Constants.Direct)]
        public PSDirectConnection[] DirectConnection { get; set; }

        /// <inheritdoc />
        /// <summary>
        ///     The base execute operation.
        /// </summary>
        public override void Execute()
        {
            try
            {
                base.Execute();
                if (this.ParameterSetName.Contains(Constants.ParameterSetNameDefault))
                {
                    if (this.InputObject is PSDirectPeeringModelView)
                    {
                        var peeringRequest = this.InputUpdateDirect();
                        this.WriteObject(peeringRequest);
                    }
                    if (this.InputObject is PSExchangePeeringModelView)
                    {
                        var peeringRequest = this.InputUpdateExchange();
                        this.WriteObject(peeringRequest);
                    }
                }

                if (this.ParameterSetName.Contains(Constants.ParameterSetNameByResourceId))
                {
                    var resourceId = new ResourceIdentifier(this.ResourceId);
                    var resourceGroupName = resourceId.ResourceGroupName;
                    var resourceName = resourceId.ResourceName;
                    var peeringRequest = this.PeeringClient.Get(resourceGroupName, resourceName);
                    var peering = this.ToPeeringPs(peeringRequest);
                    if (peering.Exchange == null)
                    {
                        // var directPeering = new PSDirectPeeringModelView(peering);
                        this.WriteObject(this.UpdateDirectPeering(peering, resourceGroupName, resourceName));
                    }

                    if (peering.Direct == null)
                    {
                        // var exchangePeering = new PSExchangePeeringModelView(peering);
                        this.WriteObject(this.UpdateExchangePeering(peering, resourceGroupName, resourceName));
                    }
                }

                if (this.ParameterSetName.Equals(Constants.Direct, StringComparison.OrdinalIgnoreCase))
                {
                    var peeringRequest = this.GetAndUpdateDirectPeering();
                    this.WriteObject(peeringRequest);
                }

                if (this.ParameterSetName.Equals(Constants.Exchange, StringComparison.OrdinalIgnoreCase))
                {
                    var peeringRequest = this.GetAndUpdateExchangePeering();
                    this.WriteObject(peeringRequest);
                }
            }
            catch (InvalidOperationException mapException)
            {
                throw new InvalidOperationException(String.Format(Resources.Error_Mapping, mapException));
            }
            catch (ErrorResponseException ex)
            {
                var error = this.GetErrorCodeAndMessageFromArmOrErm(ex);
                throw new ErrorResponseException(string.Format(Resources.Error_CloudError, error.Code, error.Message));
            }
        }

        /// <summary>
        /// The input update direct.
        /// </summary>
        /// <returns>
        /// The <see cref="PSDirectPeeringModelView"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException"> Only one value can be changed.
        /// </exception>
        /// <exception cref="ErrorResponseException"> Http request failed.
        /// </exception>
        private PSDirectPeeringModelView InputUpdateDirect()
        {
            try
            {
                if (this.InputObject is PSDirectPeeringModelView directPeeringModelView)
                {
                    var resourceId = new ResourceIdentifier(directPeeringModelView.Id);
                    var resourceGroupName = resourceId.ResourceGroupName;
                    var peeringName = resourceId.ResourceName;
                    var peering = new PSPeering
                    {
                        Kind = directPeeringModelView.Kind,
                        PeeringLocation = directPeeringModelView.PeeringLocation,
                        Location = directPeeringModelView.Location,
                        Sku = directPeeringModelView.Sku,
                        Tags = directPeeringModelView.Tags,
                        Direct = new PSPeeringPropertiesDirect
                        {
                            Connections = directPeeringModelView.Connections,
                            PeerAsn = new PSSubResource(
                                                               directPeeringModelView.PeerAsn.Id),
                        }
                    };

                    if (this.DirectConnection != null)
                    {
                        this.DirectConnection.ToList().ForEach(x => peering.Direct.Connections.Add(x));
                    }

                    this.WriteVerbose($"Updating:{peeringName} for ResourceGroup:{resourceGroupName}");
                    return new PSDirectPeeringModelView(
                        this.ToPeeringPs(
                            this.PeeringClient.CreateOrUpdate(
                                resourceGroupName,
                                peeringName,
                                this.ToPeering(peering))));
                }
            }
            catch (InvalidOperationException mapException)
            {
                throw new InvalidOperationException(String.Format(Resources.Error_Mapping, mapException));
            }
            catch (ErrorResponseException ex)
            {
                var error = GetErrorCodeAndMessageFromArmOrErm(ex);
                throw new ErrorResponseException(string.Format(Resources.Error_CloudError, error.Code, error.Message));
            }

            throw new InvalidOperationException("Check the input parameters.");
        }

        /// <summary>
        /// The input update exchange.
        /// </summary>
        /// <returns>
        /// The <see cref="PSExchangePeeringModelView"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException"> Only one value can be changed.
        /// </exception>
        /// <exception cref="ErrorResponseException"> Http request failed.
        /// </exception>
        private PSExchangePeeringModelView InputUpdateExchange()
        {
            try
            {
                if (this.InputObject is PSExchangePeeringModelView exchangePeeringModelView)
                {
                    var resourceId = new ResourceIdentifier(exchangePeeringModelView.Id);
                    var resourceGroupName = resourceId.ResourceGroupName;
                    var peeringName = resourceId.ResourceName;
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
                            PeerAsn = new PSSubResource(
                                                                 exchangePeeringModelView.PeerAsn.Id),
                        }
                    };

                    if (this.ExchangeConnection != null)
                    {
                        this.ExchangeConnection.ToList().ForEach(x => peering.Exchange.Connections.Add(x));
                    }

                    this.WriteVerbose($"Updating:{peeringName} for ResourceGroup:{resourceGroupName}");
                    this.PeeringClient.CreateOrUpdate(
                        resourceGroupName.ToString(),
                        peeringName.ToString(),
                        this.ToPeering(peering));
                    return new PSExchangePeeringModelView(
                        this.ToPeeringPs(this.PeeringClient.Get(resourceGroupName.ToString(), peeringName.ToString())));
                }
            }
            catch (InvalidOperationException mapException)
            {
                throw new InvalidOperationException(String.Format(Resources.Error_Mapping, mapException));
            }
            catch (ErrorResponseException ex)
            {
                var error = GetErrorCodeAndMessageFromArmOrErm(ex);
                throw new ErrorResponseException(string.Format(Resources.Error_CloudError, error.Code, error.Message));
            }

            throw new InvalidOperationException("Check the input parameters.");
        }

        /// <summary>
        /// The get and update direct peering.
        /// </summary>
        /// <returns>
        /// The <see cref="PSDirectPeeringModelView"/>.
        /// </returns>
        private PSDirectPeeringModelView GetAndUpdateDirectPeering()
        {
            var directPeering = this.ToPeeringPs(this.PeeringClient.Get(this.ResourceGroupName, this.Name));

            directPeering.Direct.PeerAsn = new PSSubResource(directPeering.Direct.PeerAsn.Id);
            if (this.DirectConnection != null)
            {
                this.DirectConnection.ToList().ForEach(x => directPeering.Direct.Connections.Add(x));
            }

            return new PSDirectPeeringModelView(
                this.ToPeeringPs(
                    this.PeeringClient.CreateOrUpdate(
                        this.ResourceGroupName,
                        this.Name,
                        this.ToPeering(directPeering))));
        }

        /// <summary>
        /// The get and update direct peering.
        /// </summary>
        /// <param name="directPeering">
        /// The direct peering.
        /// </param>
        /// <param name="resourceGroupName">
        /// The resource group name.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="PSDirectPeeringModelView"/>.
        /// </returns>
        private PSDirectPeeringModelView UpdateDirectPeering(
            PSPeering directPeering,
            string resourceGroupName,
            string name)
        {
            directPeering.Direct.PeerAsn = new PSSubResource(directPeering.Direct.PeerAsn.Id);
            if (this.DirectConnection != null)
            {
                this.DirectConnection.ToList().ForEach(x => directPeering.Direct.Connections.Add(x));
            }

            return new PSDirectPeeringModelView(
                this.ToPeeringPs(
                    this.PeeringClient.CreateOrUpdate(
                        resourceGroupName,
                        name,
                        this.ToPeering(directPeering))));
        }

        /// <summary>
        /// The get and update exchange peering.
        /// </summary>
        /// <returns>
        /// The <see cref="PSExchangePeeringModelView"/>.
        /// </returns>
        /// <exception cref="PSInvalidOperationException"> Only one value can be changed.
        /// </exception>
        private PSExchangePeeringModelView GetAndUpdateExchangePeering()
        {
            var exchangePeering = this.ToPeeringPs(this.PeeringClient.Get(this.ResourceGroupName, this.Name));
            exchangePeering.Exchange.PeerAsn = new PSSubResource(exchangePeering.Exchange.PeerAsn.Id);
            if (this.ExchangeConnection != null)
            {
                this.ExchangeConnection.ToList().ForEach(x => exchangePeering.Exchange.Connections.Add(x));
            }

            return new PSExchangePeeringModelView(
                this.ToPeeringPs(
                    this.PeeringClient.CreateOrUpdate(this.ResourceGroupName, this.Name, this.ToPeering(exchangePeering))));
        }

        /// <summary>
        /// The update exchange peering.
        /// </summary>
        /// <param name="exchangePeering">
        /// The ps exchange.
        /// </param>
        /// <param name="resourceGroupName">
        /// The resource group name.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="PSExchangePeeringModelView"/>.
        /// </returns>
        /// <exception cref="PSArgumentNullException"> Not valid operation
        /// </exception>
        private PSExchangePeeringModelView UpdateExchangePeering(
            PSPeering exchangePeering,
            string resourceGroupName,
            string name)
        {
            exchangePeering.Exchange.PeerAsn = new PSSubResource(exchangePeering.Exchange.PeerAsn.Id);
            if (this.ExchangeConnection != null)
            {
                this.ExchangeConnection.ToList().ForEach(x => exchangePeering.Exchange.Connections.Add(x));
            }

            return new PSExchangePeeringModelView(
                        this.ToPeeringPs(
                            this.PeeringClient.CreateOrUpdate(resourceGroupName, name, this.ToPeering(exchangePeering))));

            throw new PSArgumentNullException("Exchange Connections is Null or Invalid.");
        }
    }
}