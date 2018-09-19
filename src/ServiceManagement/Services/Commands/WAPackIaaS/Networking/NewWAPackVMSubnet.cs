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
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.DataContract;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.Operations;

namespace Microsoft.WindowsAzure.Commands.WAPackIaaS.Networking
{
    [Cmdlet(VerbsCommon.New, "WAPackVMSubnet")]
    public class NewWAPackVMSubnet : IaaSCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "VMSubnet VMNetwork.")]
        [ValidateNotNullOrEmpty]
        public VMNetwork VNet
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, HelpMessage = "VMSubnet Name.")]
        [ValidateNotNullOrEmpty]
        public string Name
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, HelpMessage = "VMSubnet Subnet.")]
        [ValidateNotNullOrEmpty]
        public string Subnet
        {
            get;
            set;
        }
        
        public override void ExecuteCmdlet()
        {
            var vmSubnet = new VMSubnet()
            {
                Name = this.Name,
                VMNetworkName = this.VNet.Name,
                VMNetworkId = this.VNet.ID,
                Subnet = this.Subnet,
                StampId = this.VNet.StampId,
            };

            Guid? jobId = Guid.Empty;
            var vmSubnetOperations = new VMSubnetOperations(this.WebClientFactory);
            var createdVMSubnet = vmSubnetOperations.Create(vmSubnet, out jobId);
            WaitForJobCompletion(jobId);

            var filter = new Dictionary<string, string>
            {
                {"ID", createdVMSubnet.ID.ToString()},
                {"StampId ", createdVMSubnet.StampId.ToString()}
            };
            var results = vmSubnetOperations.Read(filter);
            this.GenerateCmdletOutput(results);
        }
    }
}
