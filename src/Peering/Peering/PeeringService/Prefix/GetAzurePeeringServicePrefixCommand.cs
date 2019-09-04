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

    /// <inheritdoc />
    /// <summary>
    ///     The Get Az InputObject Legacy peering.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzPeeringServicePrefix", SupportsShouldProcess = true, DefaultParameterSetName = Constants.ParameterSetNameByResourceAndName)]
    [OutputType(typeof(PSPeeringServicePrefix))]
    public class GetAzurePeeringServicePrefixCommand : PeeringBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the peering service input object
        /// </summary>
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = Constants.PrefixInputObjectHelp,
            ValueFromPipeline = true,
            ParameterSetName = Constants.ParameterSetNameDefault)]
        [ValidateNotNullOrEmpty]
        public PSPeeringService InputObject { get; set; }

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
        ///     Gets or sets the InputObject name.
        /// </summary>
        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = Constants.PeeringServiceHelp,
            ParameterSetName = Constants.ParameterSetNameByResourceAndName)]
        public string PeeringServiceName { get; set; }

        /// <summary>
        ///     Gets or sets the InputObject name.
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.ParameterSetNameByResourceAndName)]
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.ParameterSetNameDefault)]
        public string Name { get; set; }

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
                    this.PeeringServiceName = resourceId.ParentResource.Split('/')?[1];
                    var item = this.GetPeeringServicePrefixByResourceAndName();
                    this.WriteObject(item);
                }
                else if (string.Equals(
                  this.ParameterSetName,
                  Constants.ParameterSetNameDefault,
                  StringComparison.OrdinalIgnoreCase))
                {
                    var resourceId = new ResourceIdentifier(this.InputObject.Id);
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
            if (this.ShouldProcess(string.Format(Resources.ShouldProcessMessage, $"a list of peering service prefixes for the resource group name:{this.ResourceGroupName} peering service name:{this.PeeringServiceName}.")))
            {
                return this.PrefixesClient.ListByPeeringService(this.ResourceGroupName, this.PeeringServiceName).Select(ToPeeringServicePrefixPS).ToList();
            }
            return null;
        }

        /// <summary>
        ///     Gets the InputObject Resource by ResourceGroupName and InputObject Name
        /// </summary>
        /// <returns>InputObject Resource</returns>
        public object GetPeeringServicePrefixByResourceAndName()
        {
            if (this.ShouldProcess(string.Format(Resources.ShouldProcessMessage, $"a peering service prefix for the resource group name:{this.ResourceGroupName} peering service name:{this.PeeringServiceName} and resource name:{this.Name}.")))
            {
                var prefix = this.ToPeeringServicePrefixPS(this.PeeringServicePrefixesClient.Get(this.ResourceGroupName, this.PeeringServiceName, this.Name));
                if (prefix != null)
                {
                    return prefix;
                }
            }
            return null;
        }
    }
}