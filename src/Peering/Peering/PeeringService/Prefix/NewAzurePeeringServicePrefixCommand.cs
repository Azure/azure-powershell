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
    using System.Management.Automation;

    using Microsoft.Azure.Commands.Peering.Properties;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.Management.Peering;
    using Microsoft.Azure.Management.Peering.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;

    /// <summary>
    /// The new azure peering service prefix command.
    /// </summary>
    [Cmdlet(VerbsCommon.New, Constants.AzPeeringServicePrefix,
        DefaultParameterSetName = Constants.ParameterSetNameDefault,
        SupportsShouldProcess = true)]
    [OutputType(typeof(PSPeeringServicePrefix))]
    public class NewAzurePeeringServicePrefixCommand : PeeringBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the peering service object.
        /// </summary>
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = Constants.PrefixInputObjectHelp,
            ValueFromPipeline = true,
            ParameterSetName = Constants.ParameterSetNameByResourceGroupName)]
        [ValidateNotNullOrEmpty]
        public PSPeeringService PeeringServiceObject { get; set; }

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
        /// Gets or sets the peering service name.
        /// </summary>
        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = Constants.PeeringServiceHelp,
            ParameterSetName = Constants.ParameterSetNameDefault)]
        [ValidateNotNullOrEmpty]
        public string PeeringServiceName { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Parameter(
            Position = 2,
            Mandatory = true,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.ParameterSetNameDefault)]
        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.ParameterSetNameByResourceGroupName)]
        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.ParameterSetNameByResourceId)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the prefix.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.HelpSessionIPv4Prefix,
            ParameterSetName = Constants.ParameterSetNameDefault)]
        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.HelpSessionIPv4Prefix,
            ParameterSetName = Constants.ParameterSetNameByResourceGroupName)]
        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.HelpSessionIPv4Prefix,
            ParameterSetName = Constants.ParameterSetNameByResourceId)]
        [ValidateNotNullOrEmpty]
        public string Prefix { get; set; }

        /// <summary>
        /// Gets or sets the prefix.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.HelpServiceKey,
            ParameterSetName = Constants.ParameterSetNameDefault)]
        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.HelpServiceKey,
            ParameterSetName = Constants.ParameterSetNameByResourceGroupName)]
        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.HelpServiceKey,
            ParameterSetName = Constants.ParameterSetNameByResourceId)]
        [ValidateNotNullOrEmpty]
        public string ServiceKey { get; set; }

        /// <summary>
        /// Gets or sets the peering service id.
        /// </summary>
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = Constants.ResourceIdHelp,
            ParameterSetName = Constants.ParameterSetNameByResourceId)]
        [ValidateNotNullOrEmpty]
        public string PeeringServiceId { get; set; }

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

            if (this.PeeringServiceObject != null)
            {
                var resourceId = new ResourceIdentifier(this.PeeringServiceObject.Id);
                this.ResourceGroupName = resourceId.ResourceGroupName;
                this.PeeringServiceName = resourceId.ResourceName;
            }
            if (this.PeeringServiceId != null)
            {
                var resourceId = new ResourceIdentifier(this.PeeringServiceObject.Id);
                this.ResourceGroupName = resourceId.ResourceGroupName;
                this.PeeringServiceName = resourceId.ResourceName;
            }

            var peeringService = this.PeeringServicesClient.Get(this.ResourceGroupName, this.PeeringServiceName);
            this.PeeringServiceName = peeringService.Name;
            if (this.ShouldProcess(string.Format(Resources.ShouldProcessMessage, $"peering service prefix for the resource group name:{this.ResourceGroupName} peering service name:{this.PeeringServiceName} and resource name:{this.Name}.")))
            {
                this.PeeringServicePrefixesClient.CreateOrUpdate(this.ResourceGroupName, this.PeeringServiceName, this.Name, prefix.Prefix, this.ServiceKey);
                return this.ToPeeringServicePrefixPS(this.PeeringServicePrefixesClient.Get(this.ResourceGroupName, this.PeeringServiceName, this.Name));
            }
            return new PSPeeringServicePrefix { Prefix = this.Prefix };
        }
    }
}