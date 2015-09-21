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
using Hyak.Common;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.HostedServices
{
    /// <summary>
    /// Swaps the deployments in production and stage.
    /// </summary>
    [Cmdlet(VerbsCommon.Move, "AzureDeployment"), OutputType(typeof(ManagementOperationContext))]
    public class MoveAzureDeploymentCommand : ServiceManagementBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Service name.")]
        [ValidateNotNullOrEmpty]
        public string ServiceName
        {
            get;
            set;
        }

        protected override void OnProcessRecord()
        {
            ServiceManagementProfile.Initialize();
            this.ExecuteCommand();
        }

        public void ExecuteCommand()
        {
            var prodDeployment = GetDeploymentBySlot(DeploymentSlotType.Production);
            var stagingDeployment = GetDeploymentBySlot(DeploymentSlotType.Staging);

            if(stagingDeployment == null && prodDeployment == null)
            {
                throw new ArgumentOutOfRangeException(String.Format(Resources.NoDeploymentInStagingOrProduction, ServiceName));
            }

            if(stagingDeployment == null && prodDeployment != null)
            {
                throw new ArgumentOutOfRangeException(String.Format(Resources.NoDeploymentInStaging, ServiceName));
            }

            if(prodDeployment == null)
            {
                this.WriteVerbose(string.Format(Resources.MovingDeploymentFromStagingToProduction, ServiceName));
            }
            else
            {
                this.WriteVerbose(string.Format(Resources.VIPSwapBetweenStagingAndProduction, ServiceName));
            }

            var swapDeploymentParams = new DeploymentSwapParameters
            {
                SourceDeployment = stagingDeployment.Name,
                ProductionDeployment = prodDeployment == null ? null : prodDeployment.Name
            };

            ExecuteClientActionNewSM(
                swapDeploymentParams,
                CommandRuntime.ToString(),
                () => this.ComputeClient.Deployments.Swap(ServiceName, swapDeploymentParams));
        }

        private DeploymentGetResponse GetDeploymentBySlot(string slot)
        {
            var slotType = (DeploymentSlot)Enum.Parse(typeof(DeploymentSlot), slot, true);
            DeploymentGetResponse prodDeployment = null;
            try
            {
                InvokeInOperationContext(() => prodDeployment = this.ComputeClient.Deployments.GetBySlot(ServiceName, slotType));
                if (prodDeployment != null && prodDeployment.Roles != null)
                {
                    if (string.Compare(prodDeployment.Roles[0].RoleType, "PersistentVMRole", StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        throw new ArgumentException(String.Format(Resources.CanNotMoveDeploymentsWhileVMsArePresent, slot));
                    }
                }
            }
            catch (CloudException)
            {
                this.WriteDebug(String.Format(Resources.NoDeploymentFoundToMove, slot));
            }

            return prodDeployment;
        }
    }
}
