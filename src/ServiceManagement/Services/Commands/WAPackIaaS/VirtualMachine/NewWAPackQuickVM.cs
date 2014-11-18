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
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.DataContract;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.Exceptions;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.Operations;

namespace Microsoft.WindowsAzure.Commands.WAPackIaaS.VirtualMachine
{
    [Cmdlet(VerbsCommon.New, "WAPackQuickVM")]
    public class NewWAPackQuickVM : IaaSCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "VirtualMachine Name.")]
        [ValidateNotNullOrEmpty]
        public string Name
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "VMTemplate to be used in VM creation.")]
        [ValidateNotNullOrEmpty]
        public VMTemplate Template
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Credentials for the localuser.")]
        [ValidateNotNullOrEmpty]
        public PSCredential VMCredential
        {
            get;
            set;
        }

        public override void ExecuteCmdlet()
        {
            Utilities.WAPackIaaS.DataContract.VirtualMachine pendingVirtualMachine = null;
            var virtualMachineOperations = new VirtualMachineOperations(this.WebClientFactory);
            Guid? jobId = Guid.Empty;

            var newVirtualMachine = new Utilities.WAPackIaaS.DataContract.VirtualMachine()
            {
                Name = Name,
                VMTemplateId = Template.ID,
                LocalAdminUserName = VMCredential.UserName,
                LocalAdminPassword = ExtractSecureString(VMCredential.Password),
            };

            pendingVirtualMachine = virtualMachineOperations.Create(newVirtualMachine, out jobId);

            if (!jobId.HasValue)
            {
                throw new WAPackOperationException(Resources.CreateFailedErrorMessage);
            }
            WaitForJobCompletion(jobId);

            var createdVM = virtualMachineOperations.Read(pendingVirtualMachine.ID);
           
            WriteObject(createdVM);
        }
    }
}
