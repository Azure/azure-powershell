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

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Network
{
    using System.Management.Automation;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using Microsoft.WindowsAzure.Management.Network;
    using Microsoft.WindowsAzure.Management.Compute;
    using Microsoft.WindowsAzure.Management.Compute.Models;


    [Cmdlet(VerbsCommon.Add, "AzureVirtualIP"), OutputType(typeof(ManagementOperationContext))]
    public class AddAzureVirtualIP : ServiceManagementBaseCmdlet
    {
        public AddAzureVirtualIP()
        {
        }

        public AddAzureVirtualIP(IClientProvider provider) : base(provider)
        {
        }

        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public string ServiceName { get; set; }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public string VirtualIPName { get; set; }

        public override void ExecuteCmdlet()
        {
            ServiceManagementProfile.Initialize();
            
            string deploymentName = this.ComputeClient.Deployments.GetBySlot(
                        this.ServiceName,
                        DeploymentSlot.Production).Name;

            ExecuteClientActionNewSM(
                null,
                CommandRuntime.ToString(),
                () => this.NetworkClient.VirtualIPs.Add(this.ServiceName, deploymentName, this.VirtualIPName));
        }
    }
}
