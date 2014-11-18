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

namespace Microsoft.WindowsAzure.Commands.WAPackIaaS.VirtualMachine
{
    [Cmdlet(VerbsLifecycle.Stop, "WAPackVM", DefaultParameterSetName = WAPackCmdletParameterSets.FromVirtualMachineObject)]
    public class StopWAPackVM : VMOperationsCmdlet
    {
        [Parameter(Mandatory = false, ParameterSetName = WAPackCmdletParameterSets.FromVirtualMachineObject, HelpMessage = "Shutdown an existing VirtualMachine.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Shutdown
        {
            get;
            set;
        }

        public override void ExecuteCmdlet()
        {
            if (Shutdown.IsPresent)
            {
                this.ExecuteVMOperation(VMOperationsEnum.Shutdown);
            }
            else
            {
                this.ExecuteVMOperation(VMOperationsEnum.Stop);
            }
        }
    }
}
