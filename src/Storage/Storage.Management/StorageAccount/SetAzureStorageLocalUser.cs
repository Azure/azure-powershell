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
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "StorageLocalUser", DefaultParameterSetName = AccountNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSLocalUser))]
    public class SetAzureStorageLocalUserCommand : StorageAccountBaseCmdlet
    {
        /// <summary>
        /// AccountName Parameter Set
        /// </summary>
        private const string AccountNameParameterSet = "AccountName";

        /// <summary>
        /// Account object parameter set 
        /// </summary>
        private const string AccountObjectParameterSet = "AccountObject";

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
            HelpMessage = "The name of local user. The username must contain lowercase letters and numbers only. It must be unique only within the storage account.")]
        [ValidateNotNullOrEmpty]
        public string UserName { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Local user home directory")]
        [ValidateNotNullOrEmpty]
        public string HomeDirectory { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "The name of local user. The username must contain lowercase letters and numbers only. It must be unique only within the storage account.")]
        [ValidateNotNullOrEmpty]
        public PSSshPublicKey[] SshAuthorizedKey { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "The name of local user. The username must contain lowercase letters and numbers only. It must be unique only within the storage account.")]
        [ValidateNotNullOrEmpty]
        public PSPermissionScope[] PermissionScope { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Whether shared key exists. Set it to false to remove existing shared key.")]
        [ValidateNotNullOrEmpty]
        public bool HasSharedKey
        {
            get
            {
                return hasSharedKey != null ? hasSharedKey.Value : false;
            }
            set
            {
                hasSharedKey = value;
            }
        }
        private bool? hasSharedKey = null;

        [Parameter(
            Mandatory = false,
            HelpMessage = "Whether SSH key exists. Set it to false to remove existing SSH key.")]
        [ValidateNotNullOrEmpty]
        public bool HasSshKey
        {
            get
            {
                return hasSshKey != null ? hasSshKey.Value : false;
            }
            set
            {
                hasSshKey = value;
            }
        }
        private bool? hasSshKey = null;

        [Parameter(
            Mandatory = false,
            HelpMessage = "Whether SSH password exists. Set it to false to remove existing SSH password.")]
        [ValidateNotNullOrEmpty]
        public bool HasSshPassword
        {
            get
            {
                return hasSshPassword != null ? hasSshPassword.Value : false;
            }
            set
            {
                hasSshPassword = value;
            }
        }
        private bool? hasSshPassword = null;

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
             
            if (ShouldProcess(this.UserName, "Create Storage Account LocalUser with name:"))
            {
                switch (ParameterSetName)
                {
                    case AccountObjectParameterSet:
                        this.ResourceGroupName = StorageAccount.ResourceGroupName;
                        this.StorageAccountName = StorageAccount.StorageAccountName;
                        break;
                    default:
                        // For AccountNameParameterSet, the ResourceGroupName and StorageAccountName can get from input directly
                        break;
                }

                PSLocalUser localuser = new PSLocalUser()
                {
                    HomeDirectory = this.HomeDirectory,
                    HasSharedKey = this.hasSharedKey,
                    HasSshKey = this.hasSshKey,
                    HasSshPassword = this.hasSshPassword,
                    PermissionScopes = this.PermissionScope,
                    SshAuthorizedKeys = this.SshAuthorizedKey
                };

                LocalUser localUser = this.StorageClient.LocalUsers.CreateOrUpdate(
                            this.ResourceGroupName,
                            this.StorageAccountName,
                            this.UserName,
                            localuser.ParseLocalUser());

                WriteObject(new PSLocalUser(localUser, this.ResourceGroupName, this.StorageAccountName));
            }
        }
    }
}
