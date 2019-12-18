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
    class MigrateOracleAzureDbPostgreSqlSyncTaskCmdlet : TaskCmdlet<ConnectionInfo>
    {
        private readonly string SelectedDatabases = "SelectedDatabases";

        public MigrateOracleAzureDbPostgreSqlSyncTaskCmdlet(InvocationInfo myInvocation) : base(myInvocation)
        {
        }

        public override void CustomInit()
        {
            this.SourceConnectionInfoParam(true);
            this.TargetConnectionInfoParam(true);
            this.SimpleParam(SelectedDatabases, typeof(MigrateOracleAzureDbPostgreSqlSyncDatabaseInput[]), "Selected databases to migrate", true);
        }

        public override ProjectTaskProperties ProcessTaskCmdlet()
        {
            OracleConnectionInfo sourceConnectionInfo = null;
            PostgreSqlConnectionInfo targetConnectionInfo = null;
            List<MigrateOracleAzureDbPostgreSqlSyncDatabaseInput> selectedDatabases = null;

            if (MyInvocation.BoundParameters.ContainsKey(SourceConnection))
            {
                sourceConnectionInfo = (OracleConnectionInfo)MyInvocation.BoundParameters[SourceConnection];
                PSCredential cred = (PSCredential)MyInvocation.BoundParameters[SourceCred];
                sourceConnectionInfo.UserName = cred.UserName;
                sourceConnectionInfo.Password = Decrypt(cred.Password);
            }

            if (MyInvocation.BoundParameters.ContainsKey(TargetConnection))
            {
                targetConnectionInfo = (PostgreSqlConnectionInfo)MyInvocation.BoundParameters[TargetConnection];
                PSCredential cred = (PSCredential)MyInvocation.BoundParameters[TargetCred];
                targetConnectionInfo.UserName = cred.UserName;
                targetConnectionInfo.Password = Decrypt(cred.Password);
            }

            if (MyInvocation.BoundParameters.ContainsKey(SelectedDatabases))
            {
                selectedDatabases
                    = ((MigrateOracleAzureDbPostgreSqlSyncDatabaseInput[])MyInvocation.BoundParameters[SelectedDatabases]).ToList();
            }

            var properties = new MigrateOracleAzureDbForPostgreSqlSyncTaskProperties
            {
                Input = new MigrateOracleAzureDbPostgreSqlSyncTaskInput
                {
                    SelectedDatabases = selectedDatabases,
                    SourceConnectionInfo = sourceConnectionInfo,
                    TargetConnectionInfo = targetConnectionInfo,
                }
            };

            return properties;
        }
    }
}
