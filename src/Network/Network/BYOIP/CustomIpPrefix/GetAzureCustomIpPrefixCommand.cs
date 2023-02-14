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

namespace Microsoft.Azure.Commands.Network
{
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Network;
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Rest.Azure;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CustomIpPrefix", DefaultParameterSetName = GetByNameParameterSet), OutputType(typeof(PSCustomIpPrefix))]
    public class GetAzureCustomIpPrefixCommand : CustomIpPrefixBaseCmdlet
    {
        private const string GetByNameParameterSet = "GetByNameParameterSet";
        private const string GetByResourceIdParameterSet = "GetByResourceIdParameterSet";

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.",
            ParameterSetName = GetByNameParameterSet)]
        [ResourceNameCompleter("Microsoft.Network/customIpPrefix", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.",
            ParameterSetName = GetByNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true, 
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource id.",
            ParameterSetName = GetByResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceId { get; set; }

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
                PSCustomIpPrefix psModel;

                psModel = this.GetCustomIpPrefix(this.ResourceGroupName, this.Name);

                WriteObject(psModel);
            }
            else
            {
                IPage<CustomIpPrefix> page;
                if (ShouldListByResourceGroup(this.ResourceGroupName, this.Name))
                {
                    page = this.CustomIpPrefixClient.List(this.ResourceGroupName);
                }
                else
                {
                    page = this.CustomIpPrefixClient.ListAll();
                }

                // Get all resources by polling on next page link
                List<CustomIpPrefix> sdkModelList;

                sdkModelList = ListNextLink<CustomIpPrefix>.GetAllResourcesByPollingNextLink(page, this.CustomIpPrefixClient.ListNext);

                var psModelList = new List<PSCustomIpPrefix>();

                // populate the publicIpPrefixes with the ResourceGroupName
                foreach (var sdkModel in sdkModelList)
                {
                    var psModel = this.ToPsCustomIpPrefix(sdkModel);
                    psModel.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(psModel.Id);
                    psModelList.Add(psModel);
                }

                WriteObject(TopLevelWildcardFilter(this.ResourceGroupName, this.Name, psModelList), true);
            }
        }
    }
}
