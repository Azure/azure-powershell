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

using Microsoft.Azure;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Storage;
using Microsoft.WindowsAzure.Management.Storage.Models;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.StorageServices
{
    /// <summary>
    /// Migrate ASM storage account to ARM
    /// </summary>
    [Cmdlet(VerbsCommon.Move, "AzureStorageAccount"), OutputType(typeof(OperationStatusResponse))]
    public class MoveStorageAccountCommand : ServiceManagementBaseCmdlet
    {
        private const string ValidateParameterSetName = "ValidateMigrationParameterSet";
        private const string AbortParameterSetName = "AbortMigrationParameterSet";
        private const string CommitParameterSetName = "CommitMigrationParameterSet";
        private const string PrepareParameterSetName = "PrepareMigrationParameterSet";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ValidateParameterSetName,
            HelpMessage = "Validate migration")]
        public SwitchParameter Validate
        {
            get;
            set;
        }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = AbortParameterSetName,
            HelpMessage = "Abort migration")]
        public SwitchParameter Abort
        {
            get;
            set;
        }

        [Parameter(Position = 0,
            Mandatory = true,
            ParameterSetName = CommitParameterSetName,
            HelpMessage = "Commit migration")]
        public SwitchParameter Commit
        {
            get;
            set;
        }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = PrepareParameterSetName,
            HelpMessage = "Prepare migration")]
        public SwitchParameter Prepare
        {
            get;
            set;
        }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Storage account name")]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName
        {
            get;
            set;
        }

        protected override void OnProcessRecord()
        {
            ServiceManagementProfile.Initialize();

            if (this.Validate.IsPresent)
            {
                ExecuteClientActionNewSM(
                null,
                CommandRuntime.ToString(),
                () => this.StorageClient.StorageAccounts.ValidateMigration(this.StorageAccountName),
                (operation, service) =>
                {
                    var context = MigrationValidateContextHelper.ConvertToContext(operation, service);
                    return context;
                });
            }
            else if (this.Abort.IsPresent)
            {
                ExecuteClientActionNewSM(
                null,
                CommandRuntime.ToString(),
                () => this.StorageClient.StorageAccounts.AbortMigration(this.StorageAccountName));
            }
            else if (this.Commit.IsPresent)
            {
                ExecuteClientActionNewSM(
                null,
                CommandRuntime.ToString(),
                () => this.StorageClient.StorageAccounts.CommitMigration(this.StorageAccountName));
            }
            else
            {
                ExecuteClientActionNewSM(
                null,
                CommandRuntime.ToString(),
                () => this.StorageClient.StorageAccounts.PrepareMigration(this.StorageAccountName));
            }
        }
    }
}
