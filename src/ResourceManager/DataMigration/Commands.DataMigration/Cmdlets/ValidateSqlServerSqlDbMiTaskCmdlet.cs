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
using Microsoft.Azure.Management.DataMigration.Models;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    public class ValidateSqlServerSqlDbMiTaskCmdlet : TaskCmdlet
    {
        private readonly string SelectedDatabase = "SelectedDatabase";
        private readonly string BackupBlobSasUri = "BackupBlobSasUri";
        private readonly string BackupFileShare = "BackupFileShare";

        public ValidateSqlServerSqlDbMiTaskCmdlet(InvocationInfo myInvocation) : base(myInvocation)
        {
        }

        public override void CustomInit()
        {
            this.TargetConnectionInfoParam(true);
            this.SimpleParam(SelectedDatabase, typeof(MigrateSqlServerSqlMIDatabaseInput[]), "Selected database to migrate", true);
            this.SimpleParam(BackupFileShare, typeof(FileShare), "File Share where the source server database files should be backed up. Use fully qualified domain name for the server", false);
            this.SimpleParam(BackupBlobSasUri, typeof(string), "SAS URI that provides DMS access to your storage account container that DMS will upload the backup files to and use for migrating databases to SQL DB Managed instance", true);
        }

        public override ProjectTaskProperties ProcessTaskCmdlet()
        {
            SqlConnectionInfo targetConnectionInfo = null;
            List<MigrateSqlServerSqlMIDatabaseInput> selectedDatabases = null;
            BlobShare backupBlobShare = null;
            FileShare backupFileShare = null;

            if (MyInvocation.BoundParameters.ContainsKey(TargetConnection))
            {
                targetConnectionInfo = (SqlConnectionInfo)MyInvocation.BoundParameters[TargetConnection];
                PSCredential cred = (PSCredential)MyInvocation.BoundParameters[TargetCred];
                targetConnectionInfo.UserName = cred.UserName;
                targetConnectionInfo.Password = Decrypt(cred.Password);
            }

            if (MyInvocation.BoundParameters.ContainsKey(SelectedDatabase))
            {
                selectedDatabases
                    = ((MigrateSqlServerSqlMIDatabaseInput[])MyInvocation.BoundParameters[SelectedDatabase]).ToList();
            }

            if (MyInvocation.BoundParameters.ContainsKey(BackupBlobSasUri))
            {
                backupBlobShare = new BlobShare
                {
                    SasUri = MyInvocation.BoundParameters[BackupBlobSasUri] as string
                };
            }

            if (MyInvocation.BoundParameters.ContainsKey(BackupFileShare))
            {
                backupFileShare = (FileShare)MyInvocation.BoundParameters[BackupFileShare];
            }

            var properties = new ValidateMigrationInputSqlServerSqlMITaskProperties
            {
                Input = new ValidateMigrationInputSqlServerSqlMITaskInput
                {
                    TargetConnectionInfo = targetConnectionInfo,
                    SelectedDatabases = selectedDatabases,
                    BackupBlobShare = backupBlobShare,
                    BackupFileShare = backupFileShare
                }
            };

            return properties;
        }
    }
}
