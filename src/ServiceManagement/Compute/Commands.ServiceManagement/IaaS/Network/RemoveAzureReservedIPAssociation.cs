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

using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;
using Microsoft.WindowsAzure.Management.Network;
using Microsoft.WindowsAzure.Management.Network.Models;
using System;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    [Cmdlet(VerbsCommon.Remove, ReservedIPConstants.AssociationCmdletNoun), OutputType(typeof(ManagementOperationContext))]
    public class RemoveAzureReservedIPAssociationCmdlet : ServiceManagementBaseCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, HelpMessage = "Reserved IP Name.")]
        [ValidateNotNullOrEmpty]
        public string ReservedIPName
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, HelpMessage = "Hosted Service Name.")]
        [ValidateNotNullOrEmpty]
        public string ServiceName
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true, HelpMessage = "Virtual IP Name.")]
        [ValidateNotNullOrEmpty]
        public string VirtualIPName
        {
            get;
            set;
        }

        [Parameter(Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Deployment slot [Staging | Production].")]
        [ValidateSet(Microsoft.WindowsAzure.Commands.ServiceManagement.Model.DeploymentSlotType.Staging, Microsoft.WindowsAzure.Commands.ServiceManagement.Model.DeploymentSlotType.Production, IgnoreCase = true)]
        public string Slot
        {
            get;
            set;
        }

        [Parameter(Position = 4, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Do not confirm removal of reserved IP Association")]
        public SwitchParameter Force
        {
            get;
            set;
        }

        protected override void OnProcessRecord()
        {
            if (this.Force.IsPresent || this.ShouldContinue(Resources.ReservedIPAssociationWillBeRemoved, Resources.RemoveReservedIPAssociation))
            {
                this.ProcessRemoveAssociation();
            }
        }

        private void ProcessRemoveAssociation()
        {
            ServiceManagementProfile.Initialize();

            var slotType = string.IsNullOrEmpty(this.Slot) ?
                            DeploymentSlot.Production :
                            (DeploymentSlot)Enum.Parse(typeof(DeploymentSlot), this.Slot, true);


            string deploymentName = this.ComputeClient.Deployments.GetBySlot(
                        this.ServiceName,
                        slotType).Name;

            ExecuteClientActionNewSM(
                null,
                CommandRuntime.ToString(),
                () =>
                {
                    var parameters = new NetworkReservedIPMobilityParameters
                    {
                        ServiceName = this.ServiceName,
                        DeploymentName = deploymentName,
                        VirtualIPName = this.VirtualIPName
                    };

                    return this.NetworkClient.ReservedIPs.Disassociate(this.ReservedIPName, parameters);
                });
        }
    }
}
