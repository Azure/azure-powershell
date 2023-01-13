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
using System.Management.Automation;
using System.Net.Http;
using Microsoft.Azure.Commands.Peering.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Peering;
using Microsoft.Azure.Management.Peering.Models;
using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common;
using Microsoft.Azure.PowerShell.Cmdlets.Peering.Models;

namespace Microsoft.Azure.PowerShell.Cmdlets.Peering.Peering
{
    /// <inheritdoc />
    /// <summary>
    ///     Updates the InputObject object.
    /// </summary>
    [Cmdlet(
        VerbsCommon.Set,
        Constants.AzPeeringRegisteredAsn,
        DefaultParameterSetName = Constants.ParameterSetNameByResourceAndName,
        SupportsShouldProcess = true)]
    [OutputType(typeof(PSPeeringRegisteredAsn))]
    public class SetAzPeeringRegisteredAsnCommand : PeeringBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the InputObject.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = Constants.ParameterSetNameInputObject,
            HelpMessage = Constants.InputObjectHelp)]
        [ValidateNotNullOrEmpty]
        public PSPeeringRegisteredAsn InputObject { get; set; }

        /// <summary>
        /// Gets or sets parent resource id.
        /// </summary>
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = Constants.ResourceIdHelp,
            ParameterSetName = Constants.ParameterSetNameByResourceId,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the Resource Group Name
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
        /// Gets or sets the peering resource name
        /// </summary>
        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = Constants.PeeringNameHelp,
            ParameterSetName = Constants.ParameterSetNameByResourceAndName)]
        [ValidateNotNullOrEmpty]
        public string PeeringName { get; set; }

        /// <summary>
        /// Gets or sets resource name
        /// </summary>
        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = Constants.AsnHelp,
            ParameterSetName = Constants.ParameterSetNameByResourceId)]
        [Parameter(
            Position = 2,
            Mandatory = true,
            HelpMessage = Constants.AsnHelp,
            ParameterSetName = Constants.ParameterSetNameByResourceAndName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.AsnHelp,
            ParameterSetName = Constants.ParameterSetNameInputObject)]
        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.AsnHelp,
            ParameterSetName = Constants.ParameterSetNameByResourceId)]
        [Parameter(
            Mandatory = true,
            HelpMessage = Constants.AsnHelp,
            ParameterSetName = Constants.ParameterSetNameByResourceAndName)]
        public int Asn { get; set; }

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
                if (this.ParameterSetName.Equals(Constants.ParameterSetNameInputObject, StringComparison.OrdinalIgnoreCase))
                {
                    this.WriteObject(this.CreateParameterSetNameDefault());
                }
                else if (this.ParameterSetName.Equals(Constants.ParameterSetNameByResourceId, StringComparison.OrdinalIgnoreCase))
                {
                    this.WriteObject(this.CreateParameterSetNameByResourceId());
                }
                else if (this.ParameterSetName.Equals(Constants.ParameterSetNameByResourceAndName, StringComparison.OrdinalIgnoreCase))
                {
                    this.WriteObject(this.CreateParameterSetNameByResourceAndName());
                }
            }
            catch (InvalidOperationException mapException)
            {
                throw new InvalidOperationException(string.Format(Resources.Error_Mapping, mapException));
            }
        }

        /// <summary>
        /// The create peering registered Asn.
        /// </summary>
        /// <returns>
        /// The <see cref="PSPeeringRegisteredAsn"/>.
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
        private PSPeeringRegisteredAsn CreateParameterSetNameByResourceAndName()
        {
            try
            {
                return PeeringResourceManagerProfile.Mapper.Map<PSPeeringRegisteredAsn>(this.RegisteredAsnClient.CreateOrUpdate(this.ResourceGroupName, this.PeeringName, this.Name, this.Asn));
            }
            catch (ErrorResponseException ex)
            {
                var error = this.GetErrorCodeAndMessageFromArmOrErm(ex);
                throw new ErrorResponseException(string.Format(Resources.Error_CloudError, error?.Code, error?.Message));
            }
        }

        /// <summary>
        /// The create peering registered Asn.
        /// </summary>
        /// <returns>
        /// The <see cref="PSPeeringRegisteredAsn"/>.
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
        private PSPeeringRegisteredAsn CreateParameterSetNameByResourceId()
        {
            var resource = new ResourceIdentifier(this.ResourceId);
            try
            {
                return PeeringResourceManagerProfile.Mapper.Map<PSPeeringRegisteredAsn>(this.RegisteredAsnClient.CreateOrUpdate(resource.ResourceGroupName, resource.ParentResource.Split('/')?[1], resource.ResourceName, this.Asn));
            }
            catch (ErrorResponseException ex)
            {
                var error = this.GetErrorCodeAndMessageFromArmOrErm(ex);
                throw new ErrorResponseException(string.Format(Resources.Error_CloudError, error?.Code, error?.Message));
            }
        }

        /// <summary>
        /// The create registered Asn
        /// </summary>
        /// <returns>
        /// The <see cref="PSPeeringRegisteredAsn"/>.
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
        private PSPeeringRegisteredAsn CreateParameterSetNameDefault()
        {
            try
            {
                var resource = new ResourceIdentifier(PeeringResourceManagerProfile.Mapper.Map<PSPeering>(this.InputObject).Id);
                return PeeringResourceManagerProfile.Mapper.Map<PSPeeringRegisteredAsn>(this.RegisteredAsnClient.CreateOrUpdate(resource.ResourceGroupName, resource.ParentResource.Split('/')?[1], resource.ResourceName, this.Asn));
            }
            catch (ErrorResponseException ex)
            {
                var error = this.GetErrorCodeAndMessageFromArmOrErm(ex);
                throw new ErrorResponseException(string.Format(Resources.Error_CloudError, error.Code, error.Message));
            }
        }
    }
}