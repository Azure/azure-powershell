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
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.ServiceFabric;
using Microsoft.Azure.Management.ServiceFabric.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using ServiceFabricProperties = Microsoft.Azure.Commands.ServiceFabric.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Common.Compute.Version_2018_04;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ServiceFabricNodeType", SupportsShouldProcess = true), OutputType(typeof(PSCluster))]
    public class UpdateAzServiceFabricNodeType : ServiceFabricNodeTypeCmdletBase
    {
        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specify the name of the cluster")]
        [ValidateNotNullOrEmpty()]
        [Alias("ClusterName")]
        public override string Name { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true,
           HelpMessage = "Define whether the node type is a primary node type. Primary node type may have seed nodes and system services.")]
        public bool? IsPrimaryNodeType { get; set; }

        public override void ExecuteCmdlet()
        {
            var cluster = GetCurrentCluster();
            var existingNodeType = GetNodeType(cluster, this.NodeType, ignoreErrors: true);

            if (existingNodeType == null)
            {
                throw new PSArgumentException(
                    string.Format(
                        ServiceFabricProperties.Resources.CannotFindTheNodeType,
                        this.NodeType));
            }

            if (ShouldProcess(target: this.NodeType, action: string.Format("Update nodetype {0}", this.NodeType)))
            {
                if (cluster.NodeTypes == null)
                {
                    throw new PSInvalidOperationException(ServiceFabricProperties.Resources.NodeTypesNotDefinedInCluster);
                }

                bool isPatchRequired = false;

                if (this.IsPrimaryNodeType.HasValue && this.IsPrimaryNodeType.Value != existingNodeType.IsPrimary)
                {
                    existingNodeType.IsPrimary = this.IsPrimaryNodeType.Value;
                    isPatchRequired = true;
                }

                if (isPatchRequired)
                {
                    var patchRequest = new ClusterUpdateParameters
                    {
                        NodeTypes = cluster.NodeTypes
                    };

                    var psCluster = SendPatchRequest(patchRequest);

                    WriteObject(psCluster, true);
                }
                else
                {
                    WriteVerbose(string.Format(ServiceFabricProperties.Resources.NodeTypeUpdateIsNoOp, this.NodeType));
                    WriteObject(new PSCluster(cluster), true);
                }
            }
        }
    }
}
