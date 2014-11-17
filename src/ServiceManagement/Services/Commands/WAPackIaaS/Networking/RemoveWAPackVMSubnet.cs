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
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.DataContract;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.Operations;

namespace Microsoft.WindowsAzure.Commands.WAPackIaaS.Networking
{
    [Cmdlet(VerbsCommon.Remove, "WAPackVMSubnet")]
    public class RemoveWAPackVMSubnet : IaaSCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "Existing VMSubnet Object.")]
        [ValidateNotNullOrEmpty]
        public VMSubnet VMSubnet
        {
            get;
            set;
        }

        [Parameter(Position = 1, Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Position = 2, HelpMessage = "Confirm the removal of the VMSubnet.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(
            Force.IsPresent,
            string.Format(Resources.RemoveVMSubnetConfirmationMessage, VMSubnet.Name),
            string.Format(Resources.RemoveVMSubnetMessage), VMSubnet.Name,
            () =>
            {
                var vmSubnetOperations = new VMSubnetOperations(this.WebClientFactory);
                var staticIPAddressPoolOperations = new StaticIPAddressPoolOperations(this.WebClientFactory);

                var filter = new Dictionary<string, string>
                {
                    {"StampId", VMSubnet.StampId.ToString()},
                    {"ID ", VMSubnet.ID.ToString()}
                };
                var deletedSubnet = vmSubnetOperations.Read(filter)[0];

                var deletedIpPool = staticIPAddressPoolOperations.Read(deletedSubnet);
                foreach (var ipPool in deletedIpPool)
                {
                    Guid? ipPoolJobId = Guid.Empty;
                    staticIPAddressPoolOperations.Delete(ipPool.ID, out ipPoolJobId);
                    WaitForJobCompletion(ipPoolJobId);
                }

                Guid? subnetJobId = Guid.Empty;
                vmSubnetOperations.Delete(deletedSubnet.ID, out subnetJobId);
                var jobInfo = WaitForJobCompletion(subnetJobId);

                if (this.PassThru)
                {
                    WriteObject(jobInfo.jobStatus != JobStatusEnum.Failed);
                }
            });
        }
    }
}
