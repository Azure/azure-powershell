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
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Store;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Network
{
    [Cmdlet(VerbsCommon.Remove, "AzureDns"), OutputType(typeof(ManagementOperationContext))]
    public class RemoveAzureDnsCommand : ServiceManagementBaseCmdlet
    {
        public PowerShellCustomConfirmation CustomConfirmation;

        [Parameter(Position = 0, Mandatory = true, HelpMessage = "Name of the DNS Server")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = "Service Name")]
        [ValidateNotNullOrEmpty]
        public string ServiceName { get; set; }

        [Parameter(Position = 2, Mandatory = false, HelpMessage = "Do not confirm deletion of deployment")]
        public SwitchParameter Force { get; set; }

        private void RemoveDnsServer()
        {
            ServiceManagementProfile.Initialize();

            ExecuteClientActionNewSM(null,
                CommandRuntime.ToString(),
                () =>
                {
                    var deploymentName = this.ComputeClient.Deployments.GetBySlot(
                        this.ServiceName,
                        DeploymentSlot.Production).Name;

                    return this.ComputeClient.DnsServer.DeleteDNSServer(
                        this.ServiceName,
                        deploymentName,
                        this.Name);
                });
        }

        private string GetWarningMessage()
        {
            return string.Format(Resources.RemoveAzureDnsServerWarning, this.Name, this.ServiceName);
        }

        protected override void ProcessRecord()
        {
            if (this.Force.IsPresent)
            {
                this.RemoveDnsServer();
            }
            else
            {
                CustomConfirmation = CustomConfirmation ?? new PowerShellCustomConfirmation(Host);
                bool remove = CustomConfirmation.ShouldProcess(Resources.RemoveAzureDnsServerCaption, this.GetWarningMessage());
                if (remove)
                {
                    this.RemoveDnsServer();
                }
            }
        }
    }
}
