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
using Microsoft.WindowsAzure.Management.Storage.Models;
using Microsoft.WindowsAzure.Management.Storage;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.StorageServices
{
    /// <summary>
    /// Displays the primary and secondary keys for the account. Should have 
    /// the storage account resource specified.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureStorageKey"), OutputType(typeof(StorageServiceKeyOperationContext))]
    public class GetAzureStorageKeyCommand : ServiceManagementBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Service name.")]
        [ValidateNotNullOrEmpty]
        [Alias("ServiceName")]
        public string StorageAccountName
        {
            get;
            set;
        }

        protected override void OnProcessRecord()
        {
            ServiceManagementProfile.Initialize();

            ExecuteClientActionNewSM(
                null,
                CommandRuntime.ToString(),
                () => this.StorageClient.StorageAccounts.GetKeys(this.StorageAccountName),
                (s, response) =>
                {
                    var context = ContextFactory<StorageAccountGetKeysResponse, StorageServiceKeyOperationContext>(response, s);
                    ((StorageServiceKeyOperationContext) context).StorageAccountName = this.StorageAccountName;
                    return context;
                });
        }
    }
}
