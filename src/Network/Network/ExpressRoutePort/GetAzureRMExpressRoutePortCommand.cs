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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using CNM = Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ExpressRoutePort", DefaultParameterSetName = ResourceNameParameterSet), OutputType(typeof(PSExpressRoutePort))]
    public partial class GetAzureRmExpressRoutePort : NetworkBaseCmdlet
    {
        private const string ResourceIdParameterSet = "ResourceIdParameterSet";
        private const string ResourceNameParameterSet = "ResourceNameParameterSet";

        [Parameter(
            ParameterSetName = ResourceNameParameterSet,
            Mandatory = false,
            HelpMessage = "The resource group name of the express route port.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            ParameterSetName = ResourceNameParameterSet,
            Mandatory = false,
            HelpMessage = "The name of the express route port.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            Mandatory = true,
            HelpMessage = "ResourceId of the express route port.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (string.Equals(this.ParameterSetName, ResourceIdParameterSet, StringComparison.OrdinalIgnoreCase))
            {
                var resourceInfo = new ResourceIdentifier(ResourceId);
                ResourceGroupName = resourceInfo.ResourceGroupName;
                Name = resourceInfo.ResourceName;
            }

            if (ShouldGetByName(ResourceGroupName, Name))
            {
                var vExpressRoutePort = this.NetworkClient.NetworkManagementClient.ExpressRoutePorts.Get(ResourceGroupName, Name);
                var vExpressRoutePortModel = NetworkResourceManagerProfile.Mapper.Map<CNM.PSExpressRoutePort>(vExpressRoutePort);
                vExpressRoutePortModel.ResourceGroupName = this.ResourceGroupName;
                vExpressRoutePortModel.Tag = TagsConversionHelper.CreateTagHashtable(vExpressRoutePort.Tags);
                WriteObject(vExpressRoutePortModel, true);
            }
            else
            {
                IPage<ExpressRoutePort> vExpressRoutePortPage;
                if(ShouldListByResourceGroup(ResourceGroupName, Name))
                {
                    vExpressRoutePortPage = this.NetworkClient.NetworkManagementClient.ExpressRoutePorts.ListByResourceGroup(this.ResourceGroupName);
                }
                else
                {
                    vExpressRoutePortPage = this.NetworkClient.NetworkManagementClient.ExpressRoutePorts.List();
                }

                var vExpressRoutePortList = ListNextLink<ExpressRoutePort>.GetAllResourcesByPollingNextLink(vExpressRoutePortPage,
                    this.NetworkClient.NetworkManagementClient.ExpressRoutePorts.ListNext);
                List<PSExpressRoutePort> psExpressRoutePortList = new List<PSExpressRoutePort>();
                foreach (var vExpressRoutePort in vExpressRoutePortList)
                {
                    var vExpressRoutePortModel = NetworkResourceManagerProfile.Mapper.Map<CNM.PSExpressRoutePort>(vExpressRoutePort);
                    vExpressRoutePortModel.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(vExpressRoutePort.Id);
                    vExpressRoutePortModel.Tag = TagsConversionHelper.CreateTagHashtable(vExpressRoutePort.Tags);
                    psExpressRoutePortList.Add(vExpressRoutePortModel);
                }
                WriteObject(TopLevelWildcardFilter(ResourceGroupName, Name, psExpressRoutePortList), true);
            }
        }
    }
}
