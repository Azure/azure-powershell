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
using Microsoft.Azure.Commands.Compute;
using Microsoft.Azure.Management.BackupServices.Models;
using MBS = Microsoft.Azure.Management.BackupServices;
using  Microsoft.Azure.Commands.Compute.Models;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    /// <summary>
    /// Get list of containers
    /// </summary>
    [Cmdlet(VerbsLifecycle.Unregister, "AzureBackupContainer"), OutputType(typeof(Guid))]
    public class UnregisterAzureBackupContainer : AzureBackupVaultCmdletBase
    {
        [Parameter(Position = 2, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.VirtualMachine, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ContainerUniqueName { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecutionBlock(() =>
            {
                UnregisterContainerRequestInput unregRequest = new UnregisterContainerRequestInput(ContainerUniqueName, AzureBackupContainerType.IaasVMContainer.ToString());
                MBS.OperationResponse operationResponse = AzureBackupClient.Container.UnregisterAsync(unregRequest, GetCustomRequestHeaders(), CmdletCancellationToken).Result;
                Guid jobId = operationResponse.OperationId; //TODO: Fix it once PiyushKa publish the rest APi to get jobId based on operationId                        

                WriteObject(jobId);
            });
        }

        private string GetQueryFileter(ListContainerQueryParameter queryParams)
        {
            NameValueCollection collection = new NameValueCollection();
            if (!String.IsNullOrEmpty(queryParams.ContainerTypeField))
            {
                collection.Add("ContainerType", queryParams.ContainerTypeField);
            }

            if (!String.IsNullOrEmpty(queryParams.ContainerStatusField))
            {
                collection.Add("ContainerStatus", queryParams.ContainerStatusField);
            }

            if (!String.IsNullOrEmpty(queryParams.ContainerFriendlyNameField))
            {
                collection.Add("FriendlyName", queryParams.ContainerFriendlyNameField);
            }

            if (collection == null || collection.Count == 0)
            {
                return String.Empty;
            }

            var httpValueCollection = HttpUtility.ParseQueryString(String.Empty);
            httpValueCollection.Add(collection);

            return "&" + httpValueCollection.ToString();

        }
    }
}
