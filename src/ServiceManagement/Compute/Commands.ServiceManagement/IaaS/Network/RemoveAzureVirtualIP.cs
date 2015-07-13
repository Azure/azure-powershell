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
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Network;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    [Cmdlet(VerbsCommon.Remove, "AzureVirtualIP"), OutputType(typeof(ManagementOperationContext))]
    public class RemoveAzureVirtualIP : ServiceManagementBaseCmdlet
    {
        public RemoveAzureVirtualIP()
        {
        }

        public RemoveAzureVirtualIP(IClientProvider provider) : base(provider)
        {
        }

        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public string ServiceName { get; set; }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public string VirtualIPName { get; set; }

        [Parameter(Position = 2, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Do not confirm removal of Virtual IP")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.Force.IsPresent || this.ShouldContinue(Resources.VirtualIPWillBeRemoved, Resources.RemoveVirtualIP))
            {
                this.ProcessRemoveAzureVirtualIP();
            }
        }

        public void ProcessRemoveAzureVirtualIP()
        {
            ServiceManagementProfile.Initialize();

            string deploymentName = this.ComputeClient.Deployments.GetBySlot(
                        this.ServiceName,
                        DeploymentSlot.Production).Name;

            ExecuteClientActionNewSM(
                null,
                CommandRuntime.ToString(),
                () => this.NetworkClient.VirtualIPs.Remove(this.ServiceName, deploymentName, this.VirtualIPName));
        }
    }
}
