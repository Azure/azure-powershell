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

using System.Linq;
using System.Management.Automation;
using AutoMapper;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Storage.Models;
using Microsoft.WindowsAzure.Management.Storage;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.StorageServices
{
    /// <summary>
    /// Lists all storage services underneath the subscription.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureStorageAccount"), OutputType(typeof(PSStorageService))]
    public class GetAzureStorageAccountCommand : ServiceManagementBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Storage Account Name.")]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName
        {
            get;
            set;
        }

        protected override void OnProcessRecord()
        {
            ServiceManagementProfile.Initialize();

            if (!string.IsNullOrEmpty(this.StorageAccountName))
            {
                ExecuteClientActionNewSM(
                    null,
                    CommandRuntime.ToString(),
                    () => this.StorageClient.StorageAccounts.Get(this.StorageAccountName),
                    (s, response) =>
                    {
                        var context = ContextFactory<StorageAccountGetResponse, StorageServicePropertiesOperationContext>(response, s);
                        Mapper.Map(response.StorageAccount.Properties, context);
                        return PSStorageService.Create(this.StorageClient, context);
                    });
            }
            else
            {
                ExecuteClientActionNewSM(
                    null,
                    CommandRuntime.ToString(),
                    () => this.StorageClient.StorageAccounts.List(),
                    (s, storageServices) => 
                        storageServices.StorageAccounts.Select(r =>
                        {
                            var context = ContextFactory<StorageAccount, StorageServicePropertiesOperationContext>(r, s);
                            Mapper.Map(r.Properties, context);
                            return PSStorageService.Create(this.StorageClient, context);
                        }));
            }
        }
    }
}
