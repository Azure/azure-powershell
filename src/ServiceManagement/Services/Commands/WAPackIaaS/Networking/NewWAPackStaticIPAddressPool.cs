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
    [Cmdlet(VerbsCommon.New, "WAPackStaticIPAddressPool")]
    public class NewWAPackStaticIPAddressPool : IaaSCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "StaticIPAddressPool VMSubnet.")]
        [ValidateNotNullOrEmpty]
        public VMSubnet VMSubnet
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, HelpMessage = "StaticIPAddressPool Name.")]
        [ValidateNotNullOrEmpty]
        public string Name
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, HelpMessage = "StaticIPAddressPool IPAddressRangeStart.")]
        [ValidateNotNullOrEmpty]
        public string IPAddressRangeStart
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, HelpMessage = "StaticIPAddressPool IPAddressRangeEnd.")]
        [ValidateNotNullOrEmpty]
        public string IPAddressRangeEnd
        {
            get;
            set;
        }

        public override void ExecuteCmdlet()
        {
            var staticIPAddressPool = new StaticIPAddressPool()
            {
                Name = this.Name,
                VMSubnetId = this.VMSubnet.ID,
                Subnet = this.VMSubnet.Subnet,
                IPAddressRangeStart = this.IPAddressRangeStart,
                IPAddressRangeEnd = this.IPAddressRangeEnd,
                StampId = this.VMSubnet.StampId
            };

            Guid? jobId = Guid.Empty;
            var staticIPAddressPoolOperations = new StaticIPAddressPoolOperations(this.WebClientFactory);
            var createdStaticIPAddressPool = staticIPAddressPoolOperations.Create(staticIPAddressPool, out jobId);
            WaitForJobCompletion(jobId);

            var filter = new Dictionary<string, string>
            {
                {"ID", createdStaticIPAddressPool.ID.ToString()},
                {"StampId ", createdStaticIPAddressPool.StampId.ToString()}
            };
            var results = staticIPAddressPoolOperations.Read(filter);
            this.GenerateCmdletOutput(results);
        }
    }
}
