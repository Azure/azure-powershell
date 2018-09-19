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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.DataContract;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.Operations;

namespace Microsoft.WindowsAzure.Commands.WAPackIaaS.Networking
{
    [Cmdlet(VerbsCommon.Get, "WAPackStaticIPAddressPool", DefaultParameterSetName = WAPackCmdletParameterSets.FromVMSubnetObject)]
    public class GetWAPackStaticIPAddressPool : IaaSCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = WAPackCmdletParameterSets.FromVMSubnetObject, ValueFromPipeline = true, HelpMessage = "StaticIPAddressPool VMSubnet.")]
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = WAPackCmdletParameterSets.FromName, ValueFromPipeline = true, HelpMessage = "StaticIPAddressPool VMSubnet.")]
        [ValidateNotNullOrEmpty]
        public VMSubnet VMSubnet
        {
            get;
            set;
        }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = WAPackCmdletParameterSets.FromName, HelpMessage = "StaticIPAddressPool Name.")]
        [ValidateNotNullOrEmpty]
        public string Name
        {
            get;
            set;
        }

        public override void ExecuteCmdlet()
        {
            IEnumerable<StaticIPAddressPool> results = null;
            var staticIPAddressPoolOperations = new StaticIPAddressPoolOperations(this.WebClientFactory);

            if (this.ParameterSetName == WAPackCmdletParameterSets.FromVMSubnetObject)
            {
                results = staticIPAddressPoolOperations.Read(this.VMSubnet);
            }
            else if (this.ParameterSetName == WAPackCmdletParameterSets.FromName)
            {
                var filter = new Dictionary<string, string>() 
                {
                    {"StampId", this.VMSubnet.StampId.ToString()},
                    {"VMSubnetId", this.VMSubnet.ID.ToString()},
                    {"Name", this.Name}
                };
                results = staticIPAddressPoolOperations.Read(filter);
            }

            this.GenerateCmdletOutput(results);
        }
    }
}
