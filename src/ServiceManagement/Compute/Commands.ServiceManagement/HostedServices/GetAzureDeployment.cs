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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.HostedServices
{
    /// <summary>
    /// View details of a specified deployment.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureDeployment"), OutputType(typeof(DeploymentInfoContext))]
    public class GetAzureDeploymentCommand : ServiceManagementBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Service name.")]
        public string ServiceName
        {
            get;
            set;
        }

        [Parameter(Position = 1, Mandatory = false, HelpMessage = "Deployment slot. Staging | Production (default Production)")]
        [ValidateSet(DeploymentSlotType.Staging, DeploymentSlotType.Production, IgnoreCase = true)]
        public string Slot
        {
            get;
            set;
        }

        protected override void OnProcessRecord()
        {
            ServiceManagementProfile.Initialize();

            if (string.IsNullOrEmpty(this.Slot))
            {
                this.Slot = DeploymentSlotType.Production;
            }

            ExecuteClientActionNewSM(
                null,
                CommandRuntime.ToString(),
                () => this.ComputeClient.Deployments.GetBySlot(this.ServiceName, (DeploymentSlot)Enum.Parse(typeof(DeploymentSlot), Slot, true)),
                (s, d) =>
                {
                    return new DeploymentInfoContext(d)
                    {
                        OperationId = s.Id,
                        OperationStatus = s.Status.ToString(),
                        OperationDescription = CommandRuntime.ToString(),
                        ServiceName = this.ServiceName
                    };
                });
        }
    }
}