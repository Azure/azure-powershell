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

using Microsoft.Azure.Commands.Management.Storage.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.Storage
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "StorageLocalUserSshPassword", DefaultParameterSetName = AccountNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSLocalUserKeys))]
    public class NewAzureStorageLocalUserSshPasswordCommand : StorageAccountBaseCmdlet
    {
        /// <summary>
        /// AccountName Parameter Set
        /// </summary>
        private const string AccountNameParameterSet = "AccountName";

        /// <summary>
        /// Account object parameter set 
        /// </summary>
        private const string AccountObjectParameterSet = "AccountObject";

        /// <summary>
        /// User object parameter set 
        /// </summary>
        private const string UserObjectParameterSet = "UserObject";

        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = "Resource Group Name.",
            ParameterSetName = AccountNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = "Storage Account Name.",
            ParameterSetName = AccountNameParameterSet)]
        [Alias(AccountNameAlias)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "Storage account object",
            ValueFromPipeline = true,
            ParameterSetName = AccountObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSStorageAccount StorageAccount { get; set; }

        [Alias("Name")]
        [Parameter(Mandatory = true,
            HelpMessage = "The name of local user. The username must contain lowercase letters and numbers only. It must be unique only within the storage account.",
            ParameterSetName = AccountNameParameterSet)]
        [Parameter(Mandatory = true,
            HelpMessage = "The name of local user. The username must contain lowercase letters and numbers only. It must be unique only within the storage account.",
            ParameterSetName = AccountObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        [Parameter(Position = 0,
            Mandatory = true,
            HelpMessage = "Local User Object to  Regenerate Password Keys.",
            ValueFromPipeline = true,
            ParameterSetName = UserObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSLocalUser InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            switch (ParameterSetName)
            {
                case AccountObjectParameterSet:
                    this.ResourceGroupName = StorageAccount.ResourceGroupName;
                    this.StorageAccountName = StorageAccount.StorageAccountName;
                    break;
                case UserObjectParameterSet:
                    this.ResourceGroupName = InputObject.ResourceGroupName;
                    this.StorageAccountName = InputObject.StorageAccountName;
                    this.UserName = InputObject.Name;
                    break;
                default:
                    // For AccountNameParameterSet, the ResourceGroupName and StorageAccountName can get from input directly
                    break;
            }

            if (ShouldProcess(this.UserName, "Regenerate Password Keys of Storage Account LocalUser:"))
            {

                LocalUserRegeneratePasswordResult result = this.StorageClient.LocalUsers.RegeneratePassword(
                            this.ResourceGroupName,
                            this.StorageAccountName,
                            this.UserName);

                WriteObject(new PSLocalUserRegeneratePasswordResult(result));
            }
        }
    }
}
