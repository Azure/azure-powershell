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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ServiceFabricNode", SupportsShouldProcess = true), OutputType(typeof(PSCluster))]
    public class AddAzureRmServiceFabricNode : UpdateAzureRmServiceFabricNodeBase
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true,
          HelpMessage = "The number of nodes to add")]
        [ValidateRange(1, 2147483647)]
        [Alias("Number")]
        public int NumberOfNodesToAdd
        {
            get; set;
        }

        protected override int Number
        {
            get { return this.NumberOfNodesToAdd; }
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
