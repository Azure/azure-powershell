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
using Microsoft.WindowsAzure.Management.Compute.Models;
using Microsoft.WindowsAzure.Management.Compute;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Network
{
    [Cmdlet(VerbsCommon.Set, "AzureDns"), OutputType(typeof(ManagementOperationContext))]
    public class SetAzureDnsCommand : ServiceManagementBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "Name of the DNS Server")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = "IP Address of the DNS Server")]
        [ValidateNotNullOrEmpty]
        public string IPAddress { get; set; }

        [Parameter(Position = 2, Mandatory = true, HelpMessage = "Service Name")]
        [ValidateNotNullOrEmpty]
        public string ServiceName { get; set; }

        protected override void ProcessRecord()
        {
            ServiceManagementProfile.Initialize();

            var dnsUpdateParameters = new DNSUpdateParameters()
            {
                Address = this.IPAddress,
                Name = this.Name
            };
            ExecuteClientActionNewSM(null,
                CommandRuntime.ToString(),
                () =>
                {
                    var deploymentName = this.ComputeClient.Deployments.GetBySlot(
                        this.ServiceName,
                        DeploymentSlot.Production).Name;

                    return this.ComputeClient.DnsServer.UpdateDNSServer(
                        this.ServiceName,
                        deploymentName,
                        dnsUpdateParameters.Name,
                        dnsUpdateParameters);
                });
        }
    }
}
