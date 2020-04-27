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
using System;
using System.Linq;
using System.Management.Automation;

using Microsoft.Azure.Commands.Peering.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Peering;
using Microsoft.Azure.Management.Peering.Models;
using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common;
using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;

namespace Microsoft.Azure.PowerShell.Cmdlets.Peering.Peering
{
    /// <inheritdoc />
    /// <summary>
    ///     The Get Az InputObject cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Constants.AzPeeringRegisteredAsn,
        DefaultParameterSetName = Constants.ParameterSetNameByResourceAndName)]
    [OutputType(typeof(PSPeeringRegisteredAsn))]
    public class GetAzPeeringRegisteredAsnCommand : PeeringBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the peering service object.
        /// </summary>
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = Constants.InputObjectHelp,
            ValueFromPipeline = true,
            ParameterSetName = Constants.ParameterSetNameInputObject)]
        [ValidateNotNullOrEmpty]
        public PSPeering InputObject { get; set; }

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
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.ParameterSetNameByResourceAndName)]
        public string PeeringName { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.AsnNameHelp,
            ParameterSetName = Constants.ParameterSetNameByResourceAndName)]
        [Parameter(
            Mandatory = false,
            HelpMessage = Constants.AsnNameHelp,
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
                        var item = this.GetPeeringServiceAsnByResourceAndName();
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
                    this.PeeringName = resourceId?.ParentResource?.Split('/')?[1];
                    var item = this.GetPeeringServiceAsnByResourceAndName();
                    this.WriteObject(item);
                }
                else if (string.Equals(
                  this.ParameterSetName,
                  Constants.ParameterSetNameInputObject,
                  StringComparison.OrdinalIgnoreCase))
                {
                    var resourceId = new ResourceIdentifier(PeeringResourceManagerProfile.Mapper.Map<PSPeering>(this.InputObject).Id);
                    this.ResourceGroupName = resourceId.ResourceGroupName;
                    this.PeeringName = resourceId.ResourceName;
                    if (this.Name != null)
                    {
                        var item = this.GetPeeringServiceAsnByResourceAndName();
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
        public object ListPeeringService()
        {
            return this.RegisteredAsnClient.ListByPeering(this.ResourceGroupName, this.PeeringName).Select(p => PeeringResourceManagerProfile.Mapper.Map<PSPeeringRegisteredAsn>(p)).ToList();
        }

        /// <summary>
        ///     Gets the InputObject Resource by ResourceGroupName and InputObject Name
        /// </summary>
        /// <returns>InputObject Resource</returns>
        public object GetPeeringServiceAsnByResourceAndName()
        {
            var Asn = this.RegisteredAsnClient.Get(this.ResourceGroupName, this.PeeringName, this.Name);
            if (Asn != null)
            {
                return PeeringResourceManagerProfile.Mapper.Map<PSPeeringRegisteredAsn>(Asn);
            }
            return null;
        }
    }
}