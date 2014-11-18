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
    [Cmdlet(VerbsCommon.Get, "WAPackVMSubnet", DefaultParameterSetName = WAPackCmdletParameterSets.FromVMNetworkObject)]
    public class GetWAPackVMSubnet : IaaSCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = WAPackCmdletParameterSets.FromVMNetworkObject, ValueFromPipeline = true, HelpMessage = "VMSubnet VMNetwork.")]
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = WAPackCmdletParameterSets.FromName, ValueFromPipeline = true, HelpMessage = "VMSubnet VMNetwork.")]
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = WAPackCmdletParameterSets.FromId, ValueFromPipeline = true, HelpMessage = "VMSubnet VMNetwork.")]
        [ValidateNotNullOrEmpty]
        public  VMNetwork VNet
        {
            get;
            set;
        }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = WAPackCmdletParameterSets.FromId, HelpMessage = "VMSubnet ID.")]
        [ValidateNotNullOrEmpty]
        public Guid ID
        {
            get;
            set;
        }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = WAPackCmdletParameterSets.FromName, HelpMessage = "VMSubnet Name.")]
        [ValidateNotNullOrEmpty]
        public string Name
        {
            get;
            set;
        }

        public override void ExecuteCmdlet()
        {
            IEnumerable<VMSubnet> results = null;
            Guid? jobId = Guid.Empty;

            var vmSubnetOperations = new VMSubnetOperations(this.WebClientFactory);

            if (this.ParameterSetName == WAPackCmdletParameterSets.FromVMNetworkObject)
            {
                results = vmSubnetOperations.Read(this.VNet);
            }
            else if (this.ParameterSetName == WAPackCmdletParameterSets.FromName)
            {
                var filter = new Dictionary<string, string>()
                {
                    {"VMNetworkId", this.VNet.ID.ToString()},
                    {"StampId", this.VNet.StampId.ToString()},
                    {"Name", this.Name}
                };
                results = vmSubnetOperations.Read(filter);
            }
            else if (this.ParameterSetName == WAPackCmdletParameterSets.FromId)
            {
                var filter = new Dictionary<string, string>()
                {
                    {"VMNetworkId", this.VNet.ID.ToString()},
                    {"StampId", this.VNet.StampId.ToString()},
                    {"ID", this.ID.ToString()}
                };
                results = vmSubnetOperations.Read(filter);
            }

            this.GenerateCmdletOutput(results);
        }
    }
}
