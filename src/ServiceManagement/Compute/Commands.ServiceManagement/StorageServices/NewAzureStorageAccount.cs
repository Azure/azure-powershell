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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Storage;
using Microsoft.WindowsAzure.Management.Storage.Models;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.StorageServices
{
    /// <summary>
    /// Creates a new storage account in Microsoft Azure.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureStorageAccount", DefaultParameterSetName = "ParameterSetAffinityGroup"), OutputType(typeof(ManagementOperationContext))]
    public class NewAzureStorageAccountCommand : ServiceManagementBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A name for the storage account that is unique to the subscription. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.")]
        [ValidateNotNullOrEmpty]
        [Alias("ServiceName")]
        public string StorageAccountName
        {
            get;
            set;
        }

        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = "Label for the storage account.")]
        [ValidateNotNullOrEmpty]
        public string Label
        {
            get;
            set;
        }

        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = "A description for the storage account.")]
        [ValidateNotNullOrEmpty]
        public string Description
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = "ParameterSetAffinityGroup",
            HelpMessage = "Required if Location is not specified. The name of an existing affinity group in the specified subscription.")]
        [ValidateNotNullOrEmpty]
        public string AffinityGroup
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = "ParameterSetLocation",
            HelpMessage = "Required if AffinityGroup is not specified. The location where the storage account is created.")]
        [ValidateNotNullOrEmpty]
        public string Location
        {
            get;
            set;
        }

        [Parameter(HelpMessage = "Type of the storage account.")]
        [ValidateNotNullOrEmpty]
        public string Type
        {
            get;
            set;
        }

        internal void ExecuteCommand()
        {
            ServiceManagementProfile.Initialize();

            var parameters = new StorageAccountCreateParameters
            {
                Name =  this.StorageAccountName,
                Label =  this.Label,
                Description = this.Description,
                AffinityGroup = this.AffinityGroup,
                Location = this.Location,
                AccountType = string.IsNullOrEmpty(this.Type) ? StorageAccountTypes.StandardGRS : this.Type
            };

            ExecuteClientActionNewSM(
                parameters,
                CommandRuntime.ToString(),
                () => this.StorageClient.StorageAccounts.Create(parameters));
        }

        protected override void OnProcessRecord()
        {
            this.ExecuteCommand();
        }

    }
}
