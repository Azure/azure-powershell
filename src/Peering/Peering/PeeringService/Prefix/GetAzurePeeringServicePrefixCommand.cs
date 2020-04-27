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
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.Management.Peering;
    using Microsoft.Azure.Management.Peering.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common;
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;

    /// <summary>
    /// The get azure peering service prefix command.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Constants.AzPeeringServicePrefix,
        DefaultParameterSetName = Constants.ParameterSetNameByResourceAndName)]
    [OutputType(typeof(PSPeeringServicePrefix))]
    public class GetAzurePeeringServicePrefixCommand : PeeringBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the peering service object.
        /// </summary>
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = Constants.PrefixInputObjectHelp,
            ValueFromPipeline = true,
            ParameterSetName = Constants.ParameterSetNameInputObject)]
        [ValidateNotNullOrEmpty]
        public PSPeeringService PeeringServiceObject { get; set; }

        /// <summary>
        /// Gets or sets the resource group name.
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
        /// Gets or sets the peering service name.
        /// </summary>
        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = Constants.PeeringServiceHelp,
            ParameterSetName = Constants.ParameterSetNameByResourceAndName)]
        public string PeeringServiceName { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.ParameterSetNameByResourceAndName)]
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.ParameterSetNameInputObject)]
        public string Name { get; set; }

        /// <summary>
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
        /// Gets or sets the expand flag.
        /// </summary>
        [Parameter(
            Mandatory = false, 
            HelpMessage = Constants.PeeringServicePrefixEventHelp,
            ParameterSetName = Constants.ParameterSetNameInputObject)]
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.PeeringServicePrefixEventHelp,
            ParameterSetName = Constants.ParameterSetNameByResourceAndName)]
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.PeeringServicePrefixEventHelp,
            ParameterSetName = Constants.ParameterSetNameByResourceId)]
        public SwitchParameter Expand { get; set; }

        /// <inheritdoc />
        /// <summary>
        ///     Execute Override for powershell cmdlet
        /// </summary>
        public override void Execute()
        {
            base.Execute();
            try
            {
                if (string.Equals(
                    this.ParameterSetName,
                    Constants.ParameterSetNameByResourceAndName,
                    StringComparison.OrdinalIgnoreCase))
                {
                    if (this.Name != null)
                    {
                        var item = this.GetPeeringServicePrefixByResourceAndName();
                        this.WriteObject(item);
                    }
                    else
                    {
                        this.WriteObject(this.ListPeeringService(), true);
                    }
                }
                else if (string.Equals(
                  this.ParameterSetName,
                  Constants.ParameterSetNameByResourceId,
                  StringComparison.OrdinalIgnoreCase))
                {
                    var resourceId = new ResourceIdentifier(this.ResourceId);
                    this.ResourceGroupName = resourceId.ResourceGroupName;
                    this.Name = resourceId.ResourceName;
                    this.PeeringServiceName = resourceId?.ParentResource?.Split('/')?[1];
                    var item = this.GetPeeringServicePrefixByResourceAndName();
                    this.WriteObject(item);
                }
                else if (string.Equals(
                  this.ParameterSetName,
                  Constants.ParameterSetNameInputObject,
                  StringComparison.OrdinalIgnoreCase))
                {
                    var resourceId = new ResourceIdentifier(this.PeeringServiceObject.Id);
                    this.ResourceGroupName = resourceId.ResourceGroupName;
                    this.PeeringServiceName = resourceId.ResourceName;
                    if (this.Name != null)
                    {
                        var item = this.GetPeeringServicePrefixByResourceAndName();
                        this.WriteObject(item);
                    }
                    else
                    {
                        this.WriteObject(this.ListPeeringService(), true);
                    }
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
        ///  Lists Peering Services
        /// </summary>
        /// <returns>List of peering service resources</returns>
        public List<PSPeeringServicePrefix> ListPeeringService()
        {
            return this.PrefixesClient.ListByPeeringService(this.ResourceGroupName, this.PeeringServiceName, this.Expand ? "events" : null).Select(ToPeeringServicePrefixPS).ToList();
        }

        /// <summary>
        ///     Gets the InputObject Resource by ResourceGroupName and InputObject Name
        /// </summary>
        /// <returns>InputObject Resource</returns>
        public object GetPeeringServicePrefixByResourceAndName()
        {
            var prefix = this.ToPeeringServicePrefixPS(this.PeeringServicePrefixesClient.Get(this.ResourceGroupName, this.PeeringServiceName, this.Name, this.Expand ? "events" : null));
            if (prefix != null)
            {
                return prefix;
            }
            return null;
        }
    }
}