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
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.Exceptions;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.Operations;

namespace Microsoft.WindowsAzure.Commands.WAPackIaaS.VirtualMachine
{
    public class VMOperationsCmdlet : IaaSCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = WAPackCmdletParameterSets.FromVirtualMachineObject, ValueFromPipeline = true, HelpMessage = "Existing VirtualMachine Object.")]
        [ValidateNotNullOrEmpty]
        public Utilities.WAPackIaaS.DataContract.VirtualMachine VM
        {
            get;
            set;
        }

        [Parameter(Position = 1, Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        protected void ExecuteVMOperation(VMOperationsEnum operation)
        {
            var virtualMachineOperations = new VirtualMachineOperations(this.WebClientFactory);
            Guid? job = null;
            Utilities.WAPackIaaS.DataContract.VirtualMachine virtualMachine = null;

            switch (operation)
            {
                case VMOperationsEnum.Start:
                    virtualMachine = virtualMachineOperations.Start(VM.ID, out job);
                    break;

                case VMOperationsEnum.Stop:
                    virtualMachine = virtualMachineOperations.Stop(VM.ID, out job);
                    break;

                case VMOperationsEnum.Restart:
                    virtualMachine = virtualMachineOperations.Restart(VM.ID, out job);
                    break;

                case VMOperationsEnum.Shutdown:
                    virtualMachine = virtualMachineOperations.Shutdown(VM.ID, out job);
                    break;

                case VMOperationsEnum.Suspend:
                    virtualMachine = virtualMachineOperations.Suspend(VM.ID, out job);
                    break;

                case VMOperationsEnum.Resume:
                    virtualMachine = virtualMachineOperations.Resume(VM.ID, out job);
                    break;
            }

            if (!job.HasValue)
            {
                throw new WAPackOperationException(String.Format(Resources.OperationFailedErrorMessage, operation, VM.ID));
            }
            WaitForJobCompletion(job);

            if (PassThru)
            {
                var updatedVMObject = virtualMachineOperations.Read(virtualMachine.ID);
                WriteObject(updatedVMObject);
            }
        }

        public override void ExecuteCmdlet()
        {
            // no-op
        }

    }
}
