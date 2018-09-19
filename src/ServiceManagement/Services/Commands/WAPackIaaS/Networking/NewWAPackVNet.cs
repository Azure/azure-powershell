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
    [Cmdlet(VerbsCommon.New, "WAPackVNet")]
    public class NewWAPackVNet : IaaSCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "VNet LogicalNetwork.")]
        [ValidateNotNullOrEmpty]
        public LogicalNetwork LogicalNetwork
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "VNet Name.")]
        [ValidateNotNullOrEmpty]
        public string Name
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "VNet Description.")]
        [ValidateNotNullOrEmpty]
        public string Description
        {
            get;
            set;
        }

        public override void ExecuteCmdlet()
        {
            var vmNetwork = new VMNetwork()
            {
                Name = this.Name,
                Description = this.Description,
                LogicalNetworkId = this.LogicalNetwork.ID,
                StampId = this.LogicalNetwork.StampId,            
            };

            Guid? jobId = Guid.Empty;
            var vmNetworkOperations = new VMNetworkOperations(this.WebClientFactory);
            var createdVmNetwork = vmNetworkOperations.Create(vmNetwork, out jobId);
            WaitForJobCompletion(jobId);

            createdVmNetwork = vmNetworkOperations.Read(createdVmNetwork.ID);
            var results = new List<VMNetwork>() { createdVmNetwork };
            this.GenerateCmdletOutput(results);
        }
    }
}
