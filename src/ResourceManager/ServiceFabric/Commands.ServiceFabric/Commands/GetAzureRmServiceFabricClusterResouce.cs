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
    [Cmdlet(VerbsCommon.Get, CmdletNoun.AzureRmServiceFabricCluster, DefaultParameterSetName = "BySubscription"), OutputType(typeof(IList<PSCluster>))]
    public class GetAzureRmServiceFabricCluster : ServiceFabricClusterCmdlet
    {
        private const string ByResourceGroup = "ByResourceGroup";
        private const string ByName = "ByName";

        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = ByResourceGroup,
                   HelpMessage = "Specify the name of the resource group.")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = ByName,
                   HelpMessage = "Specify the name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = ByName,
                   HelpMessage = "Specify the name of the cluster")]
        [ValidateNotNullOrEmpty()]
        [Alias("ClusterName")]
        public override string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case ByName:
                    {
                        var cluster = GetCurrentCluster();
                        WriteObject(new List<PSCluster>() { new PSCluster(cluster) }, true);
                        break;
                    }
                case ByResourceGroup:
                    {
                        var clusters = SFRPClient.Clusters.
                            ListByResourceGroup(ResourceGroupName).
                            Select(c => new PSCluster(c)).ToList();

                        WriteObject(clusters, true);
                        break;
                    }
                default:
                    {
                        var clusters = SFRPClient.Clusters.List().Select(c => new PSCluster(c)).ToList();
                        WriteObject(clusters, true);
                        break;
                    }
            }
        }
    }
}