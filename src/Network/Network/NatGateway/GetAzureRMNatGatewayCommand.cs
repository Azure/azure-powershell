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
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using AutoMapper;
using CNM = Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NatGateway", 
            DefaultParameterSetName = "ListParameterSet"), OutputType(typeof(PSNatGateway))]
    public partial class GetAzureRmNatGateway : NetworkBaseCmdlet
    {
        private const string ListParameterSet = "ListParameterSet";
        private const string GetByNameParameterSet = "GetByNameParameterSet";
        private const string GetByResourceIdParameterSet = "GetByResourceIdParameterSet";

        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group name of the nat gateway.",
            ParameterSetName = GetByNameParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The resource group name of the nat gateway.",
            ParameterSetName = ListParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the nat gateway.",
            ParameterSetName = GetByNameParameterSet)]
        [ResourceNameCompleter("Microsoft.Network/natGateways", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Nat Gateway Id",
            ParameterSetName = GetByResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.Name = resourceIdentifier.ResourceName;
            }

            if (ShouldGetByName(this.ResourceGroupName, this.Name))
            {
                var vNatGateway = this.NetworkClient.NetworkManagementClient.NatGateways.Get(ResourceGroupName, Name);
                var vNatGatewayModel = NetworkResourceManagerProfile.Mapper.Map<CNM.PSNatGateway>(vNatGateway);
                vNatGatewayModel.ResourceGroupName = this.ResourceGroupName;
                vNatGatewayModel.Tag = TagsConversionHelper.CreateTagHashtable(vNatGateway.Tags);
                WriteObject(vNatGatewayModel, true);
            }
            else
            {
                IPage<NatGateway> vNatGatewayPage;
                if (ShouldListByResourceGroup(this.ResourceGroupName, this.Name))
                {
                    vNatGatewayPage = this.NetworkClient.NetworkManagementClient.NatGateways.List(this.ResourceGroupName);
                }
                else
                {
                    vNatGatewayPage = this.NetworkClient.NetworkManagementClient.NatGateways.ListAll();
                }

                var vNatGatewayList = ListNextLink<NatGateway>.GetAllResourcesByPollingNextLink(vNatGatewayPage,
                    this.NetworkClient.NetworkManagementClient.NatGateways.ListNext);
                List<PSNatGateway> psNatGatewayList = new List<PSNatGateway>();
                foreach (var vNatGateway in vNatGatewayList)
                {
                    var vNatGatewayModel = NetworkResourceManagerProfile.Mapper.Map<CNM.PSNatGateway>(vNatGateway);
                    vNatGatewayModel.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(vNatGateway.Id);
                    vNatGatewayModel.Tag = TagsConversionHelper.CreateTagHashtable(vNatGateway.Tags);
                    psNatGatewayList.Add(vNatGatewayModel);
                }
                WriteObject(TopLevelWildcardFilter(ResourceGroupName, Name, psNatGatewayList), true);
            }
        }
    }
}
