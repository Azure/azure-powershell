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
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.DataContract;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.Operations;

namespace Microsoft.WindowsAzure.Commands.WAPackIaaS.Networking
{
    [Cmdlet(VerbsCommon.Remove, "WAPackVNet")]
    public class RemoveWAPackVNet : IaaSCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipeline = true, HelpMessage = "Existing VNet Object.")]
        [ValidateNotNullOrEmpty]
        public VMNetwork VNet
        {
            get;
            set;
        }

        [Parameter(Position = 1, Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Position = 2, HelpMessage = "Confirm the removal of the VNet.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(
            Force.IsPresent,
            string.Format(Resources.RemoveVMNetworkConfirmationMessage, VNet.Name),
            string.Format(Resources.RemoveVMNetworkMessage), VNet.Name,
            () =>
            {
                Guid? vmNetworkJobId = Guid.Empty;
                var vmNetworkOperations = new VMNetworkOperations(this.WebClientFactory);
                var vmSubnetOperations = new VMSubnetOperations(this.WebClientFactory);
                var staticIPAddressPoolOperations = new StaticIPAddressPoolOperations(this.WebClientFactory);

                var deletedVMNetwork = vmNetworkOperations.Read(VNet.ID);
                var deletedSubnet = vmSubnetOperations.Read(VNet);

                foreach (var subnet in deletedSubnet)
                {
                    var deletedIpPool = staticIPAddressPoolOperations.Read(subnet);
                    foreach (var ipPool in deletedIpPool)
                    {
                        Guid? ipPoolJobId = Guid.Empty;
                        staticIPAddressPoolOperations.Delete(ipPool.ID, out ipPoolJobId);
                        WaitForJobCompletion(ipPoolJobId);   
                    }
                }

                foreach (var subnet in deletedSubnet)
                {
                    Guid? subnetJobId = Guid.Empty;
                    vmSubnetOperations.Delete(subnet.ID, out subnetJobId);
                    WaitForJobCompletion(subnetJobId);
                }
                vmNetworkOperations.Delete(VNet.ID, out vmNetworkJobId);
                var jobInfo = WaitForJobCompletion(vmNetworkJobId);

                if (this.PassThru)
                {
                    WriteObject(jobInfo.jobStatus != JobStatusEnum.Failed);
                }
            });
        }
    }
}
