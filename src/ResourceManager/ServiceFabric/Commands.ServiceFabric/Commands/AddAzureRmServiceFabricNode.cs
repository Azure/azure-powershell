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

using System.Management.Automation;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Add, CmdletNoun.AzureRmServiceFabricNode, SupportsShouldProcess = true), OutputType(typeof(PSCluster))]
    public class AddAzureRmServiceFabricNode : UpdateAzureRmServiceFabricNodeBase
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

        [Parameter(Mandatory = true, ValueFromPipeline = true,
           HelpMessage = "Node type name")]
        public override string NodeType { get; set; }

        protected override int Number
        {
            get { return this.NumberOfNodesToAdd; }
        }

        [Parameter(Mandatory = true, ValueFromPipeline = true,
          HelpMessage = "The number of nodes to add")]
        [ValidateRange(1, 2147483647)]
        [Alias("Number")]
        public int NumberOfNodesToAdd
        {
            get; set;
        }

        public override void ExecuteCmdlet()
        {
            if (this.Number < 0)
            {
                throw new PSArgumentException(this.Number.ToString());
            }

            if (ShouldProcess(target: this.Name, action: string.Format("Add {0} nodes to {1}", this.Number, this.NodeType)))
            {
                base.ExecuteCmdlet();
            }
        }
    }
}