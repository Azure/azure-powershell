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
using System.Xml.Linq;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;
using Microsoft.Azure;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.HostedServices
{
    /// <summary>
    /// Sets the instance count for the selected role.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRole", DefaultParameterSetName = "ParameterSetDeploymentSlot"), OutputType(typeof(ManagementOperationContext))]
    public class SetAzureRoleCommand : ServiceManagementBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string ServiceName
        {
            get;
            set;
        }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Slot of the deployment.")]
        [ValidateSet(DeploymentSlotType.Staging, DeploymentSlotType.Production, IgnoreCase = true)]
        public string Slot
        {
            get;
            set;
        }

        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string RoleName
        {
            get;
            set;
        }

        [Parameter(Position = 3, Mandatory = true, HelpMessage = "Instance count.")]
        [ValidateNotNullOrEmpty]
        public int Count
        {
            get;
            set;
        }

        public void SetRoleInstanceCountProcess()
        {
            OperationStatusResponse operation;
            var currentDeployment = this.GetCurrentDeployment(out operation);
            if (currentDeployment == null)
            {
                return;
            }

            XNamespace ns = "http://schemas.microsoft.com/ServiceHosting/2008/10/ServiceConfiguration";
            var configuration = XDocument.Parse(currentDeployment.Configuration);
            var role = configuration.Root.Elements(ns + "Role").SingleOrDefault(p => string.Compare(p.Attribute("name").Value, this.RoleName, true) == 0);

            if (role != null)
            {
                role.Element(ns + "Instances").SetAttributeValue("count", this.Count);
            }

            var updatedConfigurationParameter = new DeploymentChangeConfigurationParameters
            {
                Configuration = configuration.ToString()
            };
            DeploymentSlot slot;
            if (!Enum.TryParse(this.Slot, out slot))
            {
                throw new ArgumentOutOfRangeException("Slot");
            }
            ExecuteClientActionNewSM(configuration, 
                CommandRuntime.ToString(), 
                () => this.ComputeClient.Deployments.ChangeConfigurationBySlot(this.ServiceName, slot, updatedConfigurationParameter));
        }

        protected override void OnProcessRecord()
        {
            ServiceManagementProfile.Initialize();
            this.SetRoleInstanceCountProcess();
        }

        private DeploymentGetResponse GetCurrentDeployment(out OperationStatusResponse operation)
        {
            DeploymentSlot slot;
            if (!Enum.TryParse(this.Slot, out slot))
            {
                throw new ArgumentOutOfRangeException("Slot");
            }

            WriteVerboseWithTimestamp(Resources.GetDeploymentBeginOperation);
            DeploymentGetResponse deploymentGetResponse = this.ComputeClient.Deployments.GetBySlot(this.ServiceName, slot);
            operation = GetOperation(deploymentGetResponse.RequestId);
            WriteVerboseWithTimestamp(Resources.GetDeploymentCompletedOperation);

            return deploymentGetResponse;
        }
    }
}