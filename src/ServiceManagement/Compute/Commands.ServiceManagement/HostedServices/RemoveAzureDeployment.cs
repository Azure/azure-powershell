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
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.HostedServices
{
    /// <summary>
    /// Deletes the specified deployment.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureDeployment"), OutputType(typeof(ManagementOperationContext))]
    public class RemoveAzureDeploymentCommand : ServiceManagementBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Service name.")]
        [ValidateNotNullOrEmpty]
        public string ServiceName
        {
            get;
            set;
        }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Deployment slot. Staging | Production")]
        [ValidateSet(DeploymentSlotType.Staging, DeploymentSlotType.Production, IgnoreCase = true)]
        public string Slot
        {
            get;
            set;
        }

        [Parameter(Position = 2, Mandatory = false, HelpMessage = "Specify to remove the deployment and the underlying disk blob(s).")]
        public SwitchParameter DeleteVHD
        {
            get;
            set;
        }

        [Parameter(Position = 3, Mandatory = false, HelpMessage = "Do not confirm deletion of deployment")]
        public SwitchParameter Force
        {
            get;
            set;
        }

        public void RemoveDeploymentProcess()
        {
            ServiceManagementProfile.Initialize();
            
            var slotType = (DeploymentSlot)Enum.Parse(typeof(DeploymentSlot), this.Slot, true);

            DeploymentGetResponse deploymentGetResponse = this.ComputeClient.Deployments.GetBySlot(this.ServiceName, slotType);

            if (deploymentGetResponse != null && !string.IsNullOrEmpty(deploymentGetResponse.ReservedIPName))
            {
                WriteVerboseWithTimestamp(string.Format(Resources.ReservedIPNameNoLongerInUseByDeploymentButStillBeingReserved, deploymentGetResponse.ReservedIPName));
            }
            if (DeleteVHD.IsPresent)
            {
                ExecuteClientActionNewSM(
                    null,
                    CommandRuntime.ToString(),
                    () => this.ComputeClient.Deployments.DeleteByName(this.ServiceName, deploymentGetResponse.Name, DeleteVHD.IsPresent));
            }
            else
            {
                ExecuteClientActionNewSM(
                    null,
                    CommandRuntime.ToString(),
                    () => this.ComputeClient.Deployments.DeleteBySlot(this.ServiceName, slotType));
            }
        }

        protected override void OnProcessRecord()
        {
            if (this.Force.IsPresent || this.ShouldContinue(Resources.DeployedArtifactsWillBeRemoved, Resources.DeploymentDeletion))
            {
                this.RemoveDeploymentProcess();
            }
        }
    }
}
