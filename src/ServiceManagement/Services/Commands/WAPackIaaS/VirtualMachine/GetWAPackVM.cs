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
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.Operations;

namespace Microsoft.WindowsAzure.Commands.WAPackIaaS.VirtualMachine
{
    [Cmdlet(VerbsCommon.Get, "WAPackVM", DefaultParameterSetName = WAPackCmdletParameterSets.Empty)]
    public class GetWAPackVM : IaaSCmdletBase
    {
        [Parameter(Position = 0, Mandatory = false, ParameterSetName = WAPackCmdletParameterSets.FromName, ValueFromPipelineByPropertyName = true, HelpMessage = "VirtualMachine Name.")]
        [ValidateNotNullOrEmpty]
        public string Name
        {
            get;
            set;
        }

        [Parameter(Position = 0, Mandatory = false, ParameterSetName = WAPackCmdletParameterSets.FromId, ValueFromPipelineByPropertyName = true, HelpMessage = "VirtualMachine ID.")]
        [ValidateNotNullOrEmpty]
        public Guid ID
        {
            get;
            set;
        }

        public override void ExecuteCmdlet()
        {
            IEnumerable<Utilities.WAPackIaaS.DataContract.VirtualMachine> results = null;
            var virtualMachineOperations = new VirtualMachineOperations(this.WebClientFactory);

            if (this.ParameterSetName == WAPackCmdletParameterSets.Empty)
            {
                results = virtualMachineOperations.Read();
            }
            else if (this.ParameterSetName == WAPackCmdletParameterSets.FromId)
            {
                Utilities.WAPackIaaS.DataContract.VirtualMachine vm = null;
                vm = virtualMachineOperations.Read(ID);
                results = new List<Utilities.WAPackIaaS.DataContract.VirtualMachine>() { vm };
            }
            else if (this.ParameterSetName == WAPackCmdletParameterSets.FromName)
            {
                results = virtualMachineOperations.Read(Name);
            }

            this.GenerateCmdletOutput(results);
        }
    }
}