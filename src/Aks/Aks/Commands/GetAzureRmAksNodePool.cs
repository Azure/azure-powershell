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

using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

using Microsoft.Azure.Commands.Aks.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.ContainerService;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Rest;

namespace Microsoft.Azure.Commands.Aks.Commands
{

    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + Constants.NodePool, DefaultParameterSetName = Constants.NameParameterSet)]
    [OutputType(typeof(PSNodePool))]
    public class GetAzureRmAksNodePool : KubeCmdletBase
    {
        [Parameter(Mandatory = true,
            ParameterSetName = Constants.IdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Id of an node pool in managed Kubernetes cluster")]
        [ValidateNotNullOrEmpty]
        [Alias("ResourceId")]
        public string Id { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = Constants.ParentObjectParameterSet, ValueFromPipeline = true, HelpMessage = "The cluster object.")]
        [ValidateNotNull]
        public PSKubernetesCluster ClusterObject { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = Constants.NameParameterSet, HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = Constants.NameParameterSet, HelpMessage = "The name of the managed cluster resource.")]
        [ValidateNotNullOrEmpty]
        public string ClusterName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = Constants.NameParameterSet, HelpMessage = "The name of the node pool.")]
        [Parameter(Mandatory = false, ParameterSetName = Constants.ParentObjectParameterSet, HelpMessage = "The name of the node pool.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            RunCmdLet(() =>
            {
                switch (ParameterSetName)
                {
                    case Constants.IdParameterSet:
                        var resource = new ResourceIdentifier(Id);
                        ResourceGroupName = resource.ResourceGroupName;
                        ClusterName = Utilities.GetParentResourceName(resource.ParentResource, nameof(Id));
                        Name = resource.ResourceName;
                        break;
                    case Constants.ParentObjectParameterSet:
                        var clusterId = new ResourceIdentifier(ClusterObject.Id);
                        ResourceGroupName = clusterId.ResourceGroupName;
                        ClusterName = ClusterObject.Name;
                        break;
                    case Constants.NameParameterSet:
                        break;
                }
                try
                {
                    if (string.IsNullOrEmpty(Name))
                    {
                        var pools = ListPaged(() => Client.AgentPools.List(ResourceGroupName, ClusterName),
                            nextPageLink => Client.AgentPools.ListNext(nextPageLink));
                        WriteObject(pools.Select(PSMapper.Instance.Map<PSNodePool>), true);
                    }
                    else
                    {
                        var pool = Client.AgentPools.Get(ResourceGroupName, ClusterName, Name);
                        WriteObject(PSMapper.Instance.Map<PSNodePool>(pool));
                    }
                }
                catch (ValidationException e)
                {
                    var sdkApiParameterMap = new Dictionary<string, CmdletParameterNameValuePair>()
                    {
                        { Constants.DotNetApiParameterResourceGroupName, new CmdletParameterNameValuePair(nameof(ResourceGroupName), ResourceGroupName) },
                        { Constants.DotNetApiParameterResourceName, new CmdletParameterNameValuePair(nameof(ClusterName), ClusterName) },
                        { Constants.DotNetApiParameterAgentPoolName, new CmdletParameterNameValuePair(nameof(Name), Name) },
                    };

                    if (!HandleValidationException(e, sdkApiParameterMap))
                        throw;
                }
            });
        }
    }
}
