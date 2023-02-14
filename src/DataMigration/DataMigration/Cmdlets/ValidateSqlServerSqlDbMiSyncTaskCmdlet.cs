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

using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.DataMigration.Models;
using Microsoft.Azure.Management.DataMigration.Models;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    public class ValidateSqlServerSqlDbMiSyncTaskCmdlet : TaskCmdlet<ConnectionInfo>
    {
        private readonly string SelectedDatabase = "SelectedDatabase";
        private readonly string BackupFileShare = "BackupFileShare";
        private readonly string AadApp = "AzureActiveDirectoryApp";
        private readonly string StorageResourceId = "StorageResourceId";

        public ValidateSqlServerSqlDbMiSyncTaskCmdlet(InvocationInfo myInvocation) : base(myInvocation)
        {
        }

        public override void CustomInit()
        {
            this.TargetConnectionInfoParam(true);
            this.SourceConnectionInfoParam(true);
            this.SimpleParam(SelectedDatabase, typeof(MigrateSqlServerSqlMIDatabaseInput[]), "Selected database to migrate", true);
            this.SimpleParam(AadApp, typeof(PSAzureActiveDirectoryApp), "Azure Active Directory App", true);
            this.SimpleParam(BackupFileShare, typeof(FileShare), "File Share where the backup and transaction logs files are stored", true);
            this.SimpleParam(StorageResourceId, typeof(string), "Azure Storage Resource Id", true);
        }

        public override ProjectTaskProperties ProcessTaskCmdlet()
        {
            MiSqlConnectionInfo targetConnectionInfo = null;
            SqlConnectionInfo sourceConnectionInfo = null;
            List<MigrateSqlServerSqlMIDatabaseInput> selectedDatabases = null;
            FileShare backupFileShare = null;
            string storageId = null;

            if (MyInvocation.BoundParameters.ContainsKey(TargetConnection))
            {
                targetConnectionInfo = (MiSqlConnectionInfo)MyInvocation.BoundParameters[TargetConnection];
                PSCredential cred = (PSCredential)MyInvocation.BoundParameters[TargetCred];
                targetConnectionInfo.UserName = cred.UserName;
                targetConnectionInfo.Password = Decrypt(cred.Password);
            }

            if (MyInvocation.BoundParameters.ContainsKey(SourceConnection))
            {
                sourceConnectionInfo = (SqlConnectionInfo)MyInvocation.BoundParameters[SourceConnection];
                PSCredential cred = (PSCredential)MyInvocation.BoundParameters[SourceCred];
                sourceConnectionInfo.UserName = cred.UserName;
                sourceConnectionInfo.Password = Decrypt(cred.Password);
            }

            if (MyInvocation.BoundParameters.ContainsKey(SelectedDatabase))
            {
                selectedDatabases
                    = ((MigrateSqlServerSqlMIDatabaseInput[])MyInvocation.BoundParameters[SelectedDatabase]).ToList();
            }

            if (MyInvocation.BoundParameters.ContainsKey(BackupFileShare))
            {
                backupFileShare = (FileShare)MyInvocation.BoundParameters[BackupFileShare];
            }

            if (MyInvocation.BoundParameters.ContainsKey(StorageResourceId))
            {
                storageId = MyInvocation.BoundParameters[StorageResourceId] as string;
            }

            PSAzureActiveDirectoryApp aadAp = (PSAzureActiveDirectoryApp)MyInvocation.BoundParameters[AadApp];

            AzureActiveDirectoryApp app = new AzureActiveDirectoryApp
            {
                ApplicationId = aadAp.ApplicationId,
                AppKey = Decrypt(aadAp.AppKey),
                TenantId = aadAp.TenantId
            };

            var properties = new ValidateMigrationInputSqlServerSqlMISyncTaskProperties
            {
                Input = new ValidateMigrationInputSqlServerSqlMISyncTaskInput
                {
                    TargetConnectionInfo = targetConnectionInfo,
                    SourceConnectionInfo = sourceConnectionInfo,
                    SelectedDatabases = selectedDatabases,
                    BackupFileShare = backupFileShare,
                    StorageResourceId = storageId,
                    AzureApp = app
                }
            };

            return properties;
        }
    }
}