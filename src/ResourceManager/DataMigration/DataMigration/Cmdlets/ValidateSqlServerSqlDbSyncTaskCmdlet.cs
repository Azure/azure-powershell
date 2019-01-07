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
    public class ValidateSqlServerSqlDbSyncTaskCmdlet : TaskCmdlet<ConnectionInfo>
    {
        private readonly string SelectedDatabase = "SelectedDatabase";

        public ValidateSqlServerSqlDbSyncTaskCmdlet(InvocationInfo myInvocation) : base(myInvocation)
        {
        }

        public override void CustomInit()
        {
            this.SourceConnectionInfoParam(true);
            this.TargetConnectionInfoParam(true);
            this.SimpleParam(SelectedDatabase, typeof(MigrateSqlServerSqlDbSyncDatabaseInput[]), "Selected database to migrate", true);
        }

        public override ProjectTaskProperties ProcessTaskCmdlet()
        {
            SqlConnectionInfo sourceConnectionInfo = null;
            SqlConnectionInfo targetConnectionInfo = null;
            List<MigrateSqlServerSqlDbSyncDatabaseInput> selectedDatabases = null;

            if (MyInvocation.BoundParameters.ContainsKey(SourceConnection))
            {
                sourceConnectionInfo = (SqlConnectionInfo)MyInvocation.BoundParameters[SourceConnection];
                PSCredential cred = (PSCredential)MyInvocation.BoundParameters[SourceCred];
                sourceConnectionInfo.UserName = cred.UserName;
                sourceConnectionInfo.Password = Decrypt(cred.Password);
            }

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
                    = ((MigrateSqlServerSqlDbSyncDatabaseInput[])MyInvocation.BoundParameters[SelectedDatabase]).ToList();
            }

            var properties = new ValidateMigrationInputSqlServerSqlDbSyncTaskProperties
            {
                Input = new ValidateSyncMigrationInputSqlServerTaskInput
                {
                    SourceConnectionInfo = sourceConnectionInfo,
                    TargetConnectionInfo = targetConnectionInfo,
                    SelectedDatabases = selectedDatabases,
                }
            };

            return properties;
        }
    }
}