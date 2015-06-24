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
using System.Web;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Management.BackupServices.Models;
using MBS = Microsoft.Azure.Management.BackupServices;
using Microsoft.Azure.Commands.AzureBackup.Models;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    /// <summary>
    /// Get list of containers
    /// </summary>
    [Cmdlet(VerbsLifecycle.Unregister, "AzureBackupContainer"), OutputType(typeof(string))]
    public class UnregisterAzureBackupContainer : AzureBackupVaultCmdletBase
    {
        [Parameter(Position = 2, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.VirtualMachine, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public AzureBackupContainer AzureBackupContainer { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                string containerUniqueName = AzureBackupContainer.ContainerUniqueName;
                UnregisterContainerRequestInput unregRequest = new UnregisterContainerRequestInput(containerUniqueName, AzureBackupContainerType.IaasVMContainer.ToString());
                var operationId = AzureBackupClient.UnRegisterContainer(unregRequest);

                var jobId = GetOperationStatus(operationId).JobList.FirstOrDefault();
                WriteObject(jobId);
            });
        }
    }
}
