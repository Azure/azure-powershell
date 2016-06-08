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
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Compute.Models;
using Microsoft.WindowsAzure.Management.Compute;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.HostedServices
{
    /// <summary>
    /// View details of deployment events.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureDeploymentEvent", DefaultParameterSetName = GetDeploymentEventBySlotParamSet)]
    [OutputType(typeof(DeploymentRebootEventContext))]
    public class GetAzureDeploymentEventCommand : ServiceManagementBaseCmdlet
    {
        protected const string GetDeploymentEventByNameParamSet = "GetDeploymentEventByName";
        protected const string GetDeploymentEventBySlotParamSet = "GetDeploymentEventBySlot";

        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Service name.")]
        public string ServiceName { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = "Start time.")]
        public DateTime StartTime { get; set; }

        [Parameter(Position = 2, Mandatory = true, HelpMessage = "End time.")]
        public DateTime EndTime { get; set; }

        [Parameter(ParameterSetName = GetDeploymentEventByNameParamSet, Position = 1, Mandatory = true, HelpMessage = "Deployment name.")]
        [ValidateNotNullOrEmpty]
        public string DeploymentName { get; set; }

        [Parameter(ParameterSetName = GetDeploymentEventBySlotParamSet, Position = 3, HelpMessage = "Deployment slot.")]
        [ValidateSet(DeploymentSlotType.Staging, DeploymentSlotType.Production, IgnoreCase = true)]
        public string Slot { get; set; }

        protected override void OnProcessRecord()
        {
            ServiceManagementProfile.Initialize();

            ExecuteClientActionNewSM(
                null,
                CommandRuntime.ToString(),
                () =>
                {
                    if (!string.IsNullOrEmpty(this.DeploymentName))
                    {
                        return this.ComputeClient.Deployments.ListEvents(this.ServiceName, this.DeploymentName, this.StartTime, this.EndTime);
                    }
                    else
                    {
                        this.Slot = string.IsNullOrEmpty(this.Slot) ? DeploymentSlotType.Production : this.Slot;
                        var slot = (DeploymentSlot)Enum.Parse(typeof(DeploymentSlot), this.Slot, true);
                        return this.ComputeClient.Deployments.ListEventsBySlot(this.ServiceName, slot, this.StartTime, this.EndTime);
                    }
                },
                (s, d) =>
                {
                    return d.DeploymentEvents.Select(e => new DeploymentRebootEventContext
                    {
                        OperationId = s.Id,
                        OperationStatus = s.Status.ToString(),
                        OperationDescription = CommandRuntime.ToString(),
                        ServiceName = this.ServiceName,
                        DeploymentName = this.DeploymentName,
                        DeploymentSlot = this.Slot,
                        InstanceName = e.InstanceName,
                        RebootReason = e.RebootReason,
                        RebootStartTime = e.RebootStartTime,
                        RoleName = e.RoleName
                    });
                });
        }
    }
}