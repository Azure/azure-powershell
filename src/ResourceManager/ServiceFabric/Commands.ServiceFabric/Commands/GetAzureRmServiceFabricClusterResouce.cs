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
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.ServiceFabric;
using ServiceFabricProperties = Microsoft.Azure.Commands.ServiceFabric.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Get, CmdletNoun.AzureRmServiceFabricCluster), OutputType(typeof(IList<PSCluster>))]
    public class GetAzureRmServiceFabricCluster : ServiceFabricClusterCmdlet
    {
        [Parameter(Mandatory = false, Position = 0, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specify the name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specify the name of the cluster")]
        [ValidateNotNullOrEmpty()]
        [Alias("ClusterName")]
        public override string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ResourceGroupName != null && Name != null)
            {
                var cluster = SFRPClient.Clusters.Get(ResourceGroupName, Name);
                WriteObject(new List<PSCluster>() { new PSCluster(cluster) }, true);
            }
            else if (ResourceGroupName != null)
            {
                var clusters = SFRPClient.Clusters.
                    ListByResourceGroup(ResourceGroupName).
                    Select(c => new PSCluster(c)).ToList();

                WriteObject(clusters, true);
            }
            else if (ResourceGroupName == null && Name == null)
            {
                var clusters = SFRPClient.Clusters.List().Select(c => new PSCluster(c)).ToList();
                WriteObject(clusters, true);
            }
            else
            {
                throw new PSArgumentException(ServiceFabricProperties.Resources.InvalidInput);
            }
        }
    }
}