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
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;

    using Microsoft.Azure.Commands.Peering.Properties;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Peering;
    using Microsoft.Azure.Management.Peering.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;

    /// <inheritdoc />
    /// <summary>
    ///     The Get Az InputObject cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Constants.AzPeeringReceivedRoute,
        DefaultParameterSetName = Constants.ParameterSetNameByResourceAndName)]
    [OutputType(typeof(PSPeeringReceivedRoute))]
    public class GetAzurePeeringReceivedRouteCommand : PeeringBaseCmdlet
    {
        /// <summary>
        ///     Gets or sets the ResourceGroupName
        /// </summary>
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = Constants.ResourceGroupNameHelp,
            ParameterSetName = Constants.ParameterSetNameByResourceAndName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.ParameterSetNameByResourceAndName)]
        public string Name { get; set; }

        /// <summary>
        /// The resource  id
        /// </summary>
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = Constants.ResourceIdHelp,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.ParameterSetNameByResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.RxPrefix,
            ParameterSetName = Constants.ParameterSetNameByResourceId)]
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.RxPrefix,
            ParameterSetName = Constants.ParameterSetNameByResourceAndName)]
        public string Prefix { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.RxAsPath,
            ParameterSetName = Constants.ParameterSetNameByResourceId)]
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.RxAsPath,
            ParameterSetName = Constants.ParameterSetNameByResourceAndName)]
        public string AsPath { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.RxOriginAsValidationState,
            ParameterSetName = Constants.ParameterSetNameByResourceId)]
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.RxOriginAsValidationState,
            ParameterSetName = Constants.ParameterSetNameByResourceAndName)]
        public string OriginAsValidationState { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.RxRPKIValidationState,
            ParameterSetName = Constants.ParameterSetNameByResourceId)]
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.RxRPKIValidationState,
            ParameterSetName = Constants.ParameterSetNameByResourceAndName)]
        public string RPKIValidationState { get; set; }

        /// <inheritdoc />
        /// <summary>
        ///     Execute Override for powershell cmdlet
        /// </summary>
        public override void Execute()
        {
            base.Execute();
            try
            {
                if (string.Equals(this.ParameterSetName, Constants.ParameterSetNameByResourceId))
                {
                    var resourceId = new ResourceIdentifier(this.ResourceId);
                    this.ResourceGroupName = resourceId.ResourceGroupName;
                    this.Name = resourceId.ResourceName;
                }
                {
                    var list = this.GetPeeringRxRoutes();
                    this.WriteObject(list, true);
                }
            }
            catch (InvalidOperationException mapException)
            {
                throw new InvalidOperationException(string.Format(Resources.Error_Mapping, mapException));
            }
            catch (ErrorResponseException ex)
            {
                var error = GetErrorCodeAndMessageFromArmOrErm(ex);
                throw new ErrorResponseException(string.Format(Resources.Error_CloudError, error.Code, error.Message));
            }
        }

        /// <summary>
        ///     Gets all InputObject for a subscription.
        /// </summary>
        /// <returns>List of all InputObject for a subscription</returns>
        public List<object> GetPeeringRxRoutes()
        {
            var icList = this.RxRoutesClient.ListByPeering(this.ResourceGroupName, this.Name, this.Prefix, this.AsPath, this.OriginAsValidationState, this.RPKIValidationState);
            return icList.ToList<object>();
        }
    }
}