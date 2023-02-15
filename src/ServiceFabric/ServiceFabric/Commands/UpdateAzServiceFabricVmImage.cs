// ----------------------------------------------------------------------------------
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

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ServiceFabric.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ServiceFabricVmImage", SupportsShouldProcess = true), OutputType(typeof(PSCluster))]
    public class UpdateAzServiceFabricVmImage : ServiceFabricClusterCmdlet
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

        /// <summary>
        /// VmImage sets the Service Fabric runtime package delivery hint for the cluster, which results in dropping the appropriately-mapped package for the VM image OS.
        /// Accepted values: Windows, Linux, Ubuntu, Ubuntu18_04
        /// Note: Linux &amp; Ubuntu both map to Ubuntu 16.04
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true,
                   HelpMessage = "VM Image hint for determining SF runtime package delivery: i.e. .cab/.deb")]
        [ValidateNotNullOrEmpty()]
        public VmImageKind VmImage { get; set; }

        public override void ExecuteCmdlet()
        {
            var cluster = GetCurrentCluster();
            var oldVmImage = GetVmImage(cluster);
            if (this.VmImage == oldVmImage)
            {
                WriteObject(new PSCluster(cluster), true);
                return;
            }

            if (ShouldProcess(target: this.Name, action: string.Format("Update fabric vmImage package delivery hint to {0}", this.VmImage)))
            {
                var request = new
                {
                    properties = new
                    {
                        VmImage = this.VmImage.ToString()
                    }
                };

                var psCluster = SendDynamicPatchRequest(request);

                WriteObject(psCluster, true);
            }
        }
    }
}
