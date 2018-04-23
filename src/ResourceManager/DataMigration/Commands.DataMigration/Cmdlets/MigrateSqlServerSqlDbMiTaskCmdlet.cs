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
    public class MigrateSqlServerSqlDbMiTaskCmdlet : TaskCmdlet
    {
        private readonly string SelectedDatabase = "SelectedDatabase";
        private readonly string BackupBlobSasUri = "BackupBlobSasUri";
        private readonly string BackupFileShare = "BackupFileShare";
        private readonly string SelectedAgentJobs = "SelectedAgentJobs";
        private readonly string SelectedLogins = "SelectedLogins";

        public MigrateSqlServerSqlDbMiTaskCmdlet(InvocationInfo myInvocation) : base(myInvocation)
        {
        }

        public override void CustomInit()
        {
            this.SourceConnectionInfoParam(true);
            this.TargetConnectionInfoParam(true);

            this.SimpleParam(SelectedDatabase, typeof(MigrateSqlServerSqlMIDatabaseInput[]), "Selected database to migrate", false);
            this.SimpleParam(BackupFileShare, typeof(FileShare), "File Share where the source server database files should be backed up. Use fully qualified domain name for the server", false);
            this.SimpleParam(BackupBlobSasUri, typeof(string), "SAS URI that provides DMS access to your storage account container that DMS will upload the backup files to and use for migrating databases to SQL DB Managed instance", false);

            this.SimpleParam(SelectedAgentJobs, typeof(string[]), "Selected agents jobs to migrate by name.", false);
            this.SimpleParam(SelectedLogins, typeof(string[]), "Selected logins to migrate by name.", false);
        }

        public override ProjectTaskProperties ProcessTaskCmdlet()
        {
            var source = new SqlConnectionInfo();
            var target = new SqlConnectionInfo();
            List<MigrateSqlServerSqlMIDatabaseInput> selectedDatabases = null;
            BlobShare backupBlobShare = null;
            FileShare backupFileShare = null;
            List<string> selectedAgentJobs = null;
            List<string> selectedLogins = null;

            source = (SqlConnectionInfo)MyInvocation.BoundParameters[SourceConnection];
            PSCredential sourceCred = (PSCredential)MyInvocation.BoundParameters[SourceCred];
            source.UserName = sourceCred.UserName;
            source.Password = Decrypt(sourceCred.Password);

            target = (SqlConnectionInfo)MyInvocation.BoundParameters[TargetConnection];
            PSCredential targetCred = (PSCredential)MyInvocation.BoundParameters[TargetCred];
            target.UserName = targetCred.UserName;
            target.Password = Decrypt(targetCred.Password);

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

            if (MyInvocation.BoundParameters.ContainsKey(SelectedAgentJobs))
            {
                selectedAgentJobs
                    = ((string[])MyInvocation.BoundParameters[SelectedAgentJobs]).ToList();
            }

            if (MyInvocation.BoundParameters.ContainsKey(SelectedLogins))
            {
                selectedLogins
                    = ((string[])MyInvocation.BoundParameters[SelectedLogins]).ToList();
            }

            var properties = new MigrateSqlServerSqlMITaskProperties
            {
                Input = new MigrateSqlServerSqlMITaskInput
                {
                    SourceConnectionInfo = source,
                    TargetConnectionInfo = target,
                    SelectedDatabases = selectedDatabases,
                    BackupBlobShare = backupBlobShare,
                    BackupFileShare = backupFileShare,
                    SelectedLogins = selectedLogins,
                    SelectedAgentJobs = selectedAgentJobs
                }
            };

            return properties;
        }
    }
}