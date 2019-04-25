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

using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using System.Net;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using AutoMapper;
using MNM = Microsoft.Azure.Management.Network.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Network
{

    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NatGateway", SupportsShouldProcess = true, DefaultParameterSetName = "SetByNameParameterSet"), OutputType(typeof(PSNatGateway))]
    public class SetAzureNatGatewayCommand : NetworkBaseCmdlet
    {
        private const string SetByNameParameterSet = "SetByNameParameterSet";
        private const string SetByInputObjectParameterSet = "SetByInputObjectParameterSet";
        private const string SetByResourceIdParameterSet = "SetByResourceIdParameterSet";

        [Parameter(Mandatory = true, ParameterSetName = SetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = SetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Nat Gateway Id",
            ParameterSetName = SetByResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = SetByInputObjectParameterSet,
            HelpMessage = "The nat gateway")]
        public PSNatGateway InputObject { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "An array of public ip addresses associated with the nat gateway resource.")]
        public PSResourceId[] PublicIpAddress { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "An array of public ip prefixes associated with the nat gateway resource.")]
        public PSResourceId[] PublicIpPrefix { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The idle timeout of the nat gateway.")]
        public int IdleTimeoutInMinutes { get; set; } = 4;

        public override void Execute()
        {
            base.Execute();

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.Name = resourceIdentifier.ResourceName;
            }

            var present = true;
            try
            {
                if (this.InputObject == null)
                {
                    var natGateway = this.NetworkClient.NetworkManagementClient.NatGateways.Get(this.ResourceGroupName, this.Name);
                    this.InputObject = NetworkResourceManagerProfile.Mapper.Map<PSNatGateway>(natGateway);
                    this.InputObject.ResourceGroupName = this.ResourceGroupName;
                    this.InputObject.Name = this.Name;
                }
                this.NetworkClient.NetworkManagementClient.NatGateways.Get(this.InputObject.ResourceGroupName, this.InputObject.Name);
            }
            catch (Microsoft.Rest.Azure.CloudException exception)
            {
                if (exception.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    // Resource is not present
                    present = false;
                }
                else
                {
                    throw;
                }
            }

            if (!present)
            {
                throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
            }

            // PublicIpAddresses
            List<PSResourceId> vPublicIpAddresses = null;

            // PublicIpPrefixes
            List<PSResourceId> vPublicIpPrefixes = null;

            if (this.IdleTimeoutInMinutes > 0)
            {
                this.InputObject.IdleTimeoutInMinutes = this.IdleTimeoutInMinutes;
            }

            if (this.PublicIpAddress != null)
            {
                vPublicIpAddresses = this.PublicIpAddress?.ToList();
                this.InputObject.PublicIpAddresses = vPublicIpAddresses;
            }

            if (this.PublicIpPrefix != null)
            {
                vPublicIpPrefixes = this.PublicIpPrefix?.ToList();
                this.InputObject.PublicIpPrefixes = vPublicIpPrefixes;
            }

            // Map to the sdk object
            var vNatGatewayModel = NetworkResourceManagerProfile.Mapper.Map<MNM.NatGateway>(this.InputObject);
            vNatGatewayModel.Tags = TagsConversionHelper.CreateTagDictionary(this.InputObject.Tag, validate: true);

            // Execute the PUT NatGateway call
            this.NetworkClient.NetworkManagementClient.NatGateways.CreateOrUpdate(this.InputObject.ResourceGroupName, this.InputObject.Name, vNatGatewayModel);

            var getNatGateway = this.NetworkClient.NetworkManagementClient.NatGateways.Get(this.InputObject.ResourceGroupName, this.InputObject.Name);
            var psNatGateway = NetworkResourceManagerProfile.Mapper.Map<PSNatGateway>(getNatGateway);
            psNatGateway.ResourceGroupName = this.InputObject.ResourceGroupName;
            psNatGateway.Tag = TagsConversionHelper.CreateTagHashtable(getNatGateway.Tags);
            WriteObject(psNatGateway, true);
        }
    }
}