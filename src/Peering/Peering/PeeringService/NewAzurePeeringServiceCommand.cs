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
    using System.Linq;
    using System.Management.Automation;

    using Microsoft.Azure.Commands.Peering.Properties;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Peering;
    using Microsoft.Azure.Management.Peering.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;

    /// <summary>
    /// The new azure peering service command.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzPeeringService", DefaultParameterSetName = Constants.ParameterSetNameDefault, SupportsShouldProcess = true)]
    [OutputType(typeof(PSPeeringService))]
    public class NewAzurePeeringServiceCommand : PeeringBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the resource group name.
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
        /// Gets or sets the name.
        /// </summary>
        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.ParameterSetNameDefault)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the peering location.
        /// </summary>
        [Parameter(
            Position = 2,
            Mandatory = true,
            HelpMessage = Constants.PeeringServiceLocationHelp,
            ParameterSetName = Constants.ParameterSetNameDefault)]
        [ValidateNotNullOrEmpty]
        public string PeeringLocation { get; set; }

        /// <summary>
        /// Gets or sets the peering service provider.
        /// </summary>
        [Parameter(
            Position = 3,
            Mandatory = true,
            HelpMessage = Constants.PeeringServiceProviderHelp,
            ParameterSetName = Constants.ParameterSetNameDefault)]
        [ValidateNotNullOrEmpty]
        public string PeeringServiceProvider { get; set; }

        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = Constants.TagsHelp)]
        public Hashtable Tag { get; set; }

        /// <summary>
        /// Gets or sets the as job.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = Constants.AsJobHelp)]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// The execute cmdlet.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// </exception>
        public override void ExecuteCmdlet()
        {
            try
            {
                if (this.ParameterSetName.Equals(Constants.ParameterSetNameDefault, StringComparison.OrdinalIgnoreCase))
                {
                    this.WriteObject(this.NewPeeringServiceFromResourceGroupAndName(), true);
                }
            }
            catch (InvalidOperationException mapException)
            {
                throw new InvalidOperationException(string.Format(Resources.Error_Mapping, mapException));
            }
        }

        /// <summary>
        /// The new peering service from resource group and name.
        /// </summary>
        /// <returns>
        /// The <see cref="PSPeeringService"/>.
        /// </returns>
        /// <exception cref="ItemNotFoundException">
        /// </exception>
        /// <exception cref="ErrorResponseException">
        /// </exception>
        private PSPeeringService NewPeeringServiceFromResourceGroupAndName()
        {
            try
            {
                var location = this.PeeringServiceLocationsClient.List();
                var CheckProvider = this.PeeringManagementClient.CheckServiceProviderAvailability(this.PeeringLocation, this.PeeringServiceProvider);
                if (!CheckProvider.Equals(Constants.Available, StringComparison.InvariantCultureIgnoreCase))
                {
                    throw new ItemNotFoundException(string.Format(Resources.Error_ProviderNotFound, this.PeeringServiceProvider, this.PeeringLocation, CheckProvider));
                }
                
                var peeringService = new PeeringService
                {
                    Location = location.Select(ToPeeringServiceLocationPS).ToList().Find(x => x.State.Equals(this.PeeringLocation.Trim(), StringComparison.InvariantCultureIgnoreCase)).AzureRegion,
                    PeeringServiceLocation = this.PeeringLocation.Trim(),
                    PeeringServiceProvider = this.PeeringServiceProvider.Trim(),
                    Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, true)
                };
                if (this.ShouldProcess(string.Format(Resources.ShouldProcessMessage, $"a peering service with resource group:{this.ResourceGroupName} and name:{this.Name}.")))
                {
                    this.PeeringServicesClient.CreateOrUpdate(this.ResourceGroupName, this.Name, peeringService);
                    return this.ToPeeringServicePS(this.PeeringServicesClient.Get(this.ResourceGroupName, this.Name));
                }
                return this.ToPeeringServicePS(peeringService);
            }
            catch (ErrorResponseException ex)
            {
                var error = this.GetErrorCodeAndMessageFromArmOrErm(ex);
                throw new ErrorResponseException(string.Format(Resources.Error_CloudError, error?.Code, error?.Message));
            }
        }
    }
}