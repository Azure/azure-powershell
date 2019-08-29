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

    using Microsoft.Azure.Commands.Peering.Properties;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.Management.Peering;
    using Microsoft.Azure.Management.Peering.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;

    /// <summary>
    /// New Azure InputObject Command-let
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzPeeringServicePrefix", DefaultParameterSetName = Constants.ParameterSetNameDefault, SupportsShouldProcess = true)]
    [OutputType(typeof(PSPeeringServicePrefix))]
    public class NewAzurePeeringServicePrefixCommand : PeeringBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the peering service input object
        /// </summary>
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = Constants.PrefixInputObjectHelp,
            ValueFromPipeline = true,
            ParameterSetName = Constants.ParameterSetNamePeeringByResource)]
        [ValidateNotNullOrEmpty]
        public PSPeeringService InputObject { get; set; }

        /// <summary>
        /// Gets or sets The Resource Group Name
        /// </summary>
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = Constants.ResourceGroupNameHelp,
            ParameterSetName = Constants.ParameterSetNameDefault)]
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
            ParameterSetName = Constants.ParameterSetNameDefault)]
        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.ParameterSetNamePeeringByResource)]
        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.ParameterSetNameByResourceId)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets The InputObject Location.
        /// </summary>
        [Parameter(
            Position = 2,
            Mandatory = true,
            HelpMessage = Constants.PeeringServiceHelp,
            ParameterSetName = Constants.ParameterSetNameDefault)]
        [ValidateNotNullOrEmpty]
        public string PeeringServiceName { get; set; }

        /// <summary>
        /// Gets or sets The PeerAsn.
        /// </summary>
        [Parameter(
            Position = 3,
            Mandatory = true,
            HelpMessage = Constants.HelpSessionIPv4Prefix,
            ParameterSetName = Constants.ParameterSetNameDefault)]
        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.HelpSessionIPv4Prefix,
            ParameterSetName = Constants.ParameterSetNamePeeringByResource)]
        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.HelpSessionIPv4Prefix,
            ParameterSetName = Constants.ParameterSetNameByResourceId)]
        [ValidateNotNullOrEmpty]
        public string Prefix { get; set; }

        /// <summary>
        /// The resource  id
        /// </summary>
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = Constants.ResourceIdHelp,
            ParameterSetName = Constants.ParameterSetNameByResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

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
                this.WriteObject(this.NewPeeringServicePrefix());
            }
            catch (InvalidOperationException mapException)
            {
                throw new InvalidOperationException(string.Format(Resources.Error_Mapping, mapException));
            }
            catch (ErrorResponseException ex)
            {
                var error = this.GetErrorCodeAndMessageFromArmOrErm(ex);
                throw new ErrorResponseException(string.Format(Resources.Error_CloudError, error?.Code, error?.Message));
            }
            catch (PSArgumentOutOfRangeException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Creates a new peering service prefix
        /// </summary>
        /// <returns>Peering Service</returns>
        private object NewPeeringServicePrefix()
        {

            var prefix = new PeeringServicePrefix
            {
                Prefix = this.ValidatePrefix(this.Prefix, Constants.PeeringService)
            };

            if (this.InputObject != null)
            {
                var resourceId = new ResourceIdentifier(this.InputObject.Id);
                this.ResourceGroupName = resourceId.ResourceGroupName;
                this.PeeringServiceName = resourceId.ResourceName;
            }
            if(this.ResourceId != null)
            {
                var resourceId = new ResourceIdentifier(this.InputObject.Id);
                this.ResourceGroupName = resourceId.ResourceGroupName;
                this.PeeringServiceName = resourceId.ResourceName;
            }

            var peeringService = this.PeeringServicesClient.Get(this.ResourceGroupName, this.PeeringServiceName);
            this.PeeringServiceName = peeringService.Name;
            this.PeeringServicePrefixesClient.CreateOrUpdate(this.ResourceGroupName, this.PeeringServiceName, this.Name, prefix);
            return this.ToPeeringServicePrefixPS(this.PeeringServicePrefixesClient.Get(this.ResourceGroupName, this.PeeringServiceName, this.Name));
        }

    }
}
