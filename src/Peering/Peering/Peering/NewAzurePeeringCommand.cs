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
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Net.Http;
    using System.Threading;
    using Microsoft.Azure.Commands.Peering.Properties;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Peering;
    using Microsoft.Azure.Management.Peering.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;

    /// <summary>
    /// New Azure InputObject Command-let
    /// </summary>
    [Cmdlet(VerbsCommon.New, Constants.AzPeering,
        DefaultParameterSetName = Constants.Exchange,
        SupportsShouldProcess = true)]
    [OutputType(typeof(PSPeering))]
    public class NewAzurePeeringCommand : PeeringBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the legacy InputObject.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = Constants.ParameterSetNameConvertLegacyPeering,
            HelpMessage = Constants.LegacyItemHelp)]
        [ValidateNotNullOrEmpty]
        public PSPeering InputObject { get; set; }

        /// <summary>
        /// Gets or sets The Resource Group Name
        /// </summary>
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = Constants.ResourceGroupNameHelp,
            ParameterSetName = Constants.ParameterSetNameConvertLegacyPeering)]
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = Constants.ResourceGroupNameHelp,
            ParameterSetName = Constants.Exchange)]
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = Constants.ResourceGroupNameHelp,
            ParameterSetName = Constants.Direct)]
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
            ParameterSetName = Constants.ParameterSetNameConvertLegacyPeering)]
        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.Exchange)]
        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.Direct)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets The InputObject Location.
        /// </summary>
        [Parameter(
            Position = 2,
            Mandatory = true,
            HelpMessage = Constants.PeeringLocationHelp,
            ParameterSetName = Constants.Exchange)]
        [Parameter(
            Position = 2,
            Mandatory = true,
            HelpMessage = Constants.PeeringLocationHelp,
            ParameterSetName = Constants.Direct)]
        [ValidateNotNullOrEmpty]
        public string PeeringLocation { get; set; }

        /// <summary>
        /// Gets or sets the Sku type
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.MicrosoftNetworkHelp,
            ParameterSetName = Constants.Direct)]
        [PSArgumentCompleter(Constants.Edge8075, Constants.CDN8069, Constants.Ix, Constants.IxRs)]
        [PSDefaultValue(Value = Constants.Edge8075)]
        public string MicrosoftNetwork { get; set; }

        /// <summary>
        /// Gets or sets The PeerAsn.
        /// </summary>
        [Parameter(
            Position = 3,
            Mandatory = true,
            HelpMessage = Constants.PeeringAsnHelp,
            ParameterSetName = Constants.ParameterSetNameConvertLegacyPeering)]
        [Parameter(
            Position = 3,
            Mandatory = true,
            HelpMessage = Constants.PeeringAsnHelp,
            ParameterSetName = Constants.Exchange)]
        [Parameter(
            Position = 3,
            Mandatory = true,
            HelpMessage = Constants.PeeringAsnHelp,
            ParameterSetName = Constants.Direct)]
        [ValidateNotNullOrEmpty]
        public string PeerAsnResourceId { get; set; }

        /// <summary>
        /// Gets or sets the exchange session.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.PeeringExchangeConnectionHelp,
            ParameterSetName = Constants.Exchange)]
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.PeeringExchangeConnectionHelp,
            ParameterSetName = Constants.ParameterSetNameConvertLegacyPeering)]
        [ValidateNotNull]
        public PSExchangeConnection[] ExchangeConnection { get; set; }

        /// <summary>
        /// Gets or sets the direct session.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.PeeringDirectConnectionHelp,
            ParameterSetName = Constants.Direct)]
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.PeeringDirectConnectionHelp,
            ParameterSetName = Constants.ParameterSetNameConvertLegacyPeering)]
        [ValidateNotNull]
        public PSDirectConnection[] DirectConnection { get; set; }

        /// <summary>
        /// Gets or sets the Sku type
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.PeeringDirectSkuHelp,
            ParameterSetName = Constants.Direct)]
        [PSArgumentCompleter(Constants.BasicDirectFree, Constants.PremiumDirectFree, Constants.PremiumDirectMetered, Constants.PremiumDirectUnlimited)]
        [PSDefaultValue(Value = Constants.BasicDirectFree)]
        public string Sku { get; set; }

        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = Constants.TagsHelp)]
        public Hashtable Tag { get; set; }

        /// <summary>
        ///     The AsJob parameter to run in the background.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = Constants.AsJobHelp)]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// The inherited Execute function.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                if (this.ParameterSetName.Equals(Constants.Exchange, StringComparison.OrdinalIgnoreCase))
                    this.WriteObject(new PSExchangePeeringModelView(this.CreateExchangePeering()));
                if (this.ParameterSetName.Equals(Constants.Direct, StringComparison.OrdinalIgnoreCase))
                    this.WriteObject(new PSDirectPeeringModelView(this.CreateDirectPeering()));
                if (this.ParameterSetName.Equals(Constants.ParameterSetNameConvertLegacyPeering))
                {
                    var legacy = this.InputObject;
                    if (legacy.Exchange != null && string.Equals(
                            legacy.Kind,
                            Constants.Exchange,
                            StringComparison.OrdinalIgnoreCase))
                    {
                        this.WriteObject(this.ConvertClassicToExchangePeering(new PSExchangePeeringModelView(legacy)), true);
                    }
                    else if (legacy.Direct != null && string.Equals(
                                 legacy.Kind,
                                 Constants.Direct,
                                 StringComparison.OrdinalIgnoreCase))
                    {
                        this.WriteObject(this.ConvertClassicToDirectPeering(new PSDirectPeeringModelView(legacy)), true);
                    }
                    base.EndProcessing();
                }
            }
            catch (InvalidOperationException mapException)
            {
                throw new InvalidOperationException(string.Format(Resources.Error_Mapping, mapException));
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
        private PSPeering CreateDirectPeering()
        {
            var peeringRequest =
                new PSPeering(
                    name: this.Name,
                    location: this.GetAzureRegion(this.PeeringLocation, Constants.Direct),
                    sku: new PSPeeringSku { Name = this.Sku },
                    kind: Constants.Direct)
                {
                    PeeringLocation = this.PeeringLocation,
                    Direct = new PSPeeringPropertiesDirect
                    {
                        DirectPeeringType = this.ConvertToDirectPeeringType(this.MicrosoftNetwork),
                        Connections = new List<PSDirectConnection>(),
                        PeerAsn = new PSSubResource(this.PeerAsnResourceId),
                    },
                    Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, true),
                };
            if (this.DirectConnection == null)
            {
                throw new PSArgumentNullException(string.Format(Resources.Create_NewConnectionObject, Constants.Direct));
            }

            foreach (var psDirectConnection in this.DirectConnection)
            {
                if (this.IsValidConnection(psDirectConnection))
                    peeringRequest.Direct.Connections.Add(psDirectConnection);
            }


            if (this.DirectConnection.Any((c) => c.UseForPeeringService == true))
            {
                if(this.Sku != Constants.PremiumDirectFree && this.Sku != Constants.PremiumDirectMetered && this.Sku != Constants.PremiumDirectUnlimited)
                {
                    throw new PSArgumentException(string.Format(Resources.Error_Sku, $"{Constants.PremiumDirectFree},{Constants.PremiumDirectMetered},{Constants.PremiumDirectUnlimited}"));
                }
            }

            if (this.ParameterSetName.Equals(Constants.Direct))
            {
                if (peeringRequest.Direct?.Connections.Count <= 0)
                    throw new PSArgumentException(string.Format(Resources.Error_NullConnection, Constants.Direct));
                if (peeringRequest.Exchange != null)
                {
                    peeringRequest.Exchange = null;
                }

                try
                {
                    return (PSPeering)this.PutNewPeering(peeringRequest);
                }
                catch (ErrorResponseException ex)
                {
                    var error = this.GetErrorCodeAndMessageFromArmOrErm(ex);
                    throw new ErrorResponseException(string.Format(Resources.Error_CloudError, error?.Code, error?.Message));
                }
            }
            else
            {
                throw new PSInvalidOperationException(string.Format(Resources.Error_GenericSyntax));
            }
        }

        /// <summary>
        /// The create exchange peering.
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
        private PSPeering CreateExchangePeering()
        {
            var peeringRequest =
                new PSPeering(
                    name: this.Name,
                    location: this.GetAzureRegion(this.PeeringLocation, Constants.Exchange),
                    sku: new PSPeeringSku { Name = Constants.BasicExchangeFree },
                    kind: Constants.Exchange)
                {
                    PeeringLocation = this.PeeringLocation,
                    Exchange = new PSPeeringPropertiesExchange
                    {
                        Connections = new List<PSExchangeConnection>(),
                        PeerAsn = new PSSubResource(this.PeerAsnResourceId)
                    },
                    Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, true),
                };
            if (this.ExchangeConnection == null)
            {
                throw new PSArgumentNullException(
                    string.Format(Resources.Create_NewConnectionObject, Constants.Exchange));
            }

            foreach (PSExchangeConnection psExchangeConnection in this.ExchangeConnection)
            {
                if (this.IsValidConnection(psExchangeConnection))
                    peeringRequest.Exchange.Connections.Add(psExchangeConnection);
            }

            if (this.ParameterSetName.Equals(Constants.Exchange))
            {
                if (peeringRequest.Exchange?.Connections.Count <= 0)
                    throw new PSArgumentException(string.Format(Resources.Error_InvalidConnection, "Exchange Connection is null."));
                if (peeringRequest.Direct != null)
                {
                    peeringRequest.Direct = null;
                }

                try
                {
                    return (PSPeering)this.PutNewPeering(peeringRequest);
                }
                catch (ErrorResponseException ex)
                {
                    var error = this.GetErrorCodeAndMessageFromArmOrErm(ex);
                    throw new ErrorResponseException(string.Format(Resources.Error_CloudError, error.Code, error.Message));
                }
            }
            throw new PSInvalidOperationException(string.Format(Resources.Error_GenericSyntax));
        }

        /// <summary>
        /// The put new InputObject.
        /// </summary>
        /// <param name="newPeering">
        /// The new InputObject.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        private object PutNewPeering(PSPeering newPeering)
        {
            var peering = PeeringResourceManagerProfile.Mapper.Map<PeeringModel>(newPeering);
            return PeeringResourceManagerProfile.Mapper.Map<PSPeering>(this.PeeringClient.CreateOrUpdate(this.ResourceGroupName, this.Name, peering));
        }

        /// <summary>
        /// The convert classic to Exchange peering.
        /// </summary>
        /// <param name="peering">
        /// The classic peering.
        /// </param>
        /// <returns>
        /// The <see cref="PSPeering"/>.
        /// </returns>
        private PSPeering ConvertClassicToExchangePeering(PSExchangePeeringModelView peering)
        {
            if (peering == null)
                throw new PSArgumentNullException(string.Format(Resources.Error_UnableToConvertLegacy, "LegacyPeering"));
            if (peering.Connections == null)
                throw new PSArgumentNullException(string.Format(Resources.Error_UnableToConvertLegacy, "Connection"));

            var connections = peering.Connections.ToList();
            if (this.ExchangeConnection != null)
            {
                this.ExchangeConnection.ToList().ForEach(x => connections.Add(x));
            }

            var newPeering = new PSPeering
            {
                Location = this.GetAzureRegion(peering.PeeringLocation, Constants.Exchange),
                PeeringLocation = peering.PeeringLocation,
                Kind = peering.Kind ?? Constants.Exchange,
                Sku = peering.Sku ?? new PSPeeringSku { Name = Constants.BasicExchangeFree },
                Exchange = new PSPeeringPropertiesExchange
                {
                    Connections = connections,
                    PeerAsn = new PSSubResource(this.PeerAsnResourceId)
                },
                Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, true),
            };

            try
            {
                return (PSPeering)this.PutNewPeering(newPeering);
            }
            catch (ErrorResponseException ex)
            {
                var error = this.GetErrorCodeAndMessageFromArmOrErm(ex);
                throw new ErrorResponseException(string.Format(Resources.Error_CloudError, error.Code, error.Message));
            }
        }

        /// <summary>
        /// The convert classic to direct peering.
        /// </summary>
        /// <param name="peering">
        /// The classic peering.
        /// </param>
        /// <returns>
        /// The <see cref="PSPeering"/>.
        /// </returns>
        private PSPeering ConvertClassicToDirectPeering(PSDirectPeeringModelView peering)
        {
            if (peering == null)
                throw new PSArgumentNullException(string.Format(Resources.Error_UnableToConvertLegacy, "LegacyPeering"));
            if (peering.Connections == null)
                throw new PSArgumentNullException(string.Format(Resources.Error_UnableToConvertLegacy, "Connection"));
            var connections = peering.Connections.ToList();
            var newPeering = new PSPeering
            {
                Location = this.GetAzureRegion(peering.PeeringLocation, Constants.Direct),
                PeeringLocation = peering.PeeringLocation,
                Kind = peering.Kind ?? Constants.Direct,
                Sku = peering.Sku ?? new PSPeeringSku(Constants.BasicDirectFree),
                Direct = new PSPeeringPropertiesDirect
                {
                    Connections = connections,
                    PeerAsn = new PSSubResource(this.PeerAsnResourceId)
                },
                Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, true),
            };
            foreach (var connection in newPeering.Direct.Connections)
            {
                connection.ConnectionIdentifier = Guid.NewGuid().ToString();
                connection.BandwidthInMbps = connection.ProvisionedBandwidthInMbps ?? 10000;
            }

            try
            {
                return (PSPeering)this.PutNewPeering(newPeering);
            }
            catch (ErrorResponseException ex)
            {
                var error = this.GetErrorCodeAndMessageFromArmOrErm(ex);
                throw new ErrorResponseException(string.Format(Resources.Error_CloudError, error.Code, error.Message));
            }
        }
    }
}