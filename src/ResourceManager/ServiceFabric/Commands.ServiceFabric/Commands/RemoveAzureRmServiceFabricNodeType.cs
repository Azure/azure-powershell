﻿// ----------------------------------------------------------------------------------
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
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.ServiceFabric;
using ServiceFabricProperties = Microsoft.Azure.Commands.ServiceFabric.Properties;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Remove, CmdletNoun.AzureRmServiceFabricNodeType, SupportsShouldProcess = true), OutputType(typeof(PSCluster))]
    public class RemoveAzureRmServiceFabricNodeType : ServiceFabricNodeTypeCmdletBase
    {
        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [ValidateNotNullOrEmpty()]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specify the name of the cluster")]
        [ValidateNotNullOrEmpty()]
        [Alias("ClusterName")]
        public override string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!CheckNodeTypeExistence())
            {
                throw new PSArgumentException(this.NodeType);
            }

            var cluster = SFRPClient.Clusters.Get(this.ResourceGroupName, this.Name);

            if (cluster.NodeTypes == null)
            {
                throw new PSInvalidOperationException(ServiceFabricProperties.Resources.NoneNodeTypeFound);
            }

            var existingNodeType = cluster.NodeTypes.FirstOrDefault(n =>
                this.NodeType.Equals(
                    n.Name,    
                    StringComparison.OrdinalIgnoreCase));

            if (existingNodeType == null)
            {
                throw new PSInvalidOperationException(
                    string.Format(
                        ServiceFabricProperties.Resources.CannotFindTheNodeType,
                        this.NodeType));
            }

            if (existingNodeType.IsPrimary)
            {
                throw new PSInvalidOperationException(
                    string.Format(
                        ServiceFabricProperties.Resources.CannotDeletePrimayNodeType,
                        this.NodeType));
            }

            DurabilityLevel durabilityLevel;
            bool missMatch;
            GetDurabilityLevel(this.NodeType, out durabilityLevel, out missMatch);

            if (durabilityLevel == DurabilityLevel.Bronze)
            {
                throw new PSInvalidOperationException(
                    ServiceFabricProperties.Resources.CannotUpdateBronzeNodeType);
            }

            if (ShouldProcess(target: this.NodeType, action: string.Format("Remove a nodetype {0} ", this.NodeType)))
            {
                this.ComputeClient.VirtualMachineScaleSets.Delete(this.ResourceGroupName, this.NodeType);

                cluster = RemoveNodeTypeFromSfrp();

                WriteObject((PSCluster)cluster, true);
            }
        }
    }
}
