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
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Storage;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.StorageServices
{
    /// <summary>
    /// Deletes the specified storage account from Microsoft Azure.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureStorageAccount"), OutputType(typeof(StorageServiceOperationContext))]
    public class RemoveAzureStorageAccountCommand : ServiceManagementBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the storage account to be removed.")]
        [ValidateNotNullOrEmpty]
        [Alias("ServiceName")]
        public string StorageAccountName
        {
            get;
            set;
        }

        public string RemoveStorageAccountProcess()
        {
            var operationId = string.Empty;

            ExecuteClientActionNewSM(
                null,
                CommandRuntime.ToString(),
                () => this.StorageClient.StorageAccounts.Delete(this.StorageAccountName),
                (s, r) =>
                {
                    return new StorageServiceOperationContext
                    {
                        OperationId = s.Id,
                        OperationStatus = s.Status.ToString(),
                        OperationDescription = CommandRuntime.ToString(),
                        StorageAccountName = this.StorageAccountName
                    };
                });

            return operationId;
        }

        protected override void OnProcessRecord()
        {
            var operationId = this.RemoveStorageAccountProcess();

            if (!string.IsNullOrEmpty(operationId))
            {
                var ctx = new StorageServiceOperationContext()
                {
                    StorageAccountName = this.StorageAccountName,
                    OperationId = operationId
                };

                WriteObject(ctx, true);
            }
        }

    }
}
