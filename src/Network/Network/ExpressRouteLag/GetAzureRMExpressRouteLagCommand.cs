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
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ExpressRouteLag", DefaultParameterSetName = ResourceNameParameterSet), OutputType(typeof(PSExpressRouteLag))]
    public partial class GetAzureRmExpressRouteLag : NetworkBaseCmdlet
    {
        private const string ResourceIdParameterSet = "ResourceIdParameterSet";
        private const string ResourceNameParameterSet = "ResourceNameParameterSet";

        [Parameter(
            ParameterSetName = ResourceNameParameterSet,
            Mandatory = false,
            HelpMessage = "The resource group name of the express route LAG.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            ParameterSetName = ResourceNameParameterSet,
            Mandatory = false,
            HelpMessage = "The name of the express route LAG.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            Mandatory = true,
            HelpMessage = "ResourceId of the express route LAG.",
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
                var vExpressRouteLag = this.NetworkClient.NetworkManagementClient.ExpressRouteLags.Get(ResourceGroupName, Name);
                var vExpressRouteLagModel = NetworkResourceManagerProfile.Mapper.Map<CNM.PSExpressRouteLag>(vExpressRouteLag);
                vExpressRouteLagModel.ResourceGroupName = this.ResourceGroupName;
                vExpressRouteLagModel.Tag = TagsConversionHelper.CreateTagHashtable(vExpressRouteLag.Tags);
                WriteObject(vExpressRouteLagModel, true);
            }
            else
            {
                IPage<ExpressRouteLag> vExpressRouteLagPage;
                if (ShouldListByResourceGroup(ResourceGroupName, Name))
                {
                    vExpressRouteLagPage = this.NetworkClient.NetworkManagementClient.ExpressRouteLags.ListByResourceGroup(this.ResourceGroupName);
                }
                else
                {
                    vExpressRouteLagPage = this.NetworkClient.NetworkManagementClient.ExpressRouteLags.List();
                }

                var vExpressRouteLagList = ListNextLink<ExpressRouteLag>.GetAllResourcesByPollingNextLink(vExpressRouteLagPage,
                    this.NetworkClient.NetworkManagementClient.ExpressRouteLags.ListNext);
                List<PSExpressRouteLag> psExpressRouteLagList = new List<PSExpressRouteLag>();
                foreach (var vExpressRouteLag in vExpressRouteLagList)
                {
                    var vExpressRouteLagModel = NetworkResourceManagerProfile.Mapper.Map<CNM.PSExpressRouteLag>(vExpressRouteLag);
                    vExpressRouteLagModel.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(vExpressRouteLag.Id);
                    vExpressRouteLagModel.Tag = TagsConversionHelper.CreateTagHashtable(vExpressRouteLag.Tags);
                    psExpressRouteLagList.Add(vExpressRouteLagModel);
                }
                WriteObject(TopLevelWildcardFilter(ResourceGroupName, Name, psExpressRouteLagList), true);
            }
        }
    }
}
