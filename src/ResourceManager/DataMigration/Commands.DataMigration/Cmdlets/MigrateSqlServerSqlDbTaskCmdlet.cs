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
using Microsoft.Azure.Management.DataMigration.Models;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    public class MigrateSqlServerSqlDbTaskCmdlet : TaskCmdlet
    {
        private readonly string SchemaValidation = "SchemaValidation";
        private readonly string DataIntegrityValidation = "DataIntegrityValidation";
        private readonly string QueryAnalysisValidation = "QueryAnalysisValidation";
        private readonly string SelectedDatabase = "SelectedDatabase";

        public MigrateSqlServerSqlDbTaskCmdlet(InvocationInfo myInvocation) : base(myInvocation)
        {
        }

        public override void CustomInit()
        {
            this.SourceConnectionInfoParam(true);
            this.TargetConnectionInfoParam(true);
            this.SimpleParam(SchemaValidation, typeof(SwitchParameter), "Allows to compare the schema information between source and target.");
            this.SimpleParam(DataIntegrityValidation, typeof(SwitchParameter), "Allows to perform a checksum based data integrity validation between source and target.");
            this.SimpleParam(QueryAnalysisValidation, typeof(SwitchParameter), "Allows to perform a quick and intelligent query analysis by retrieving queries from the source database and executes them in the target.");
            this.SimpleParam(SelectedDatabase, typeof(MigrateSqlServerSqlDbDatabaseInput[]), "Selected database to migrate", true);
        }

        public override ProjectTaskProperties ProcessTaskCmdlet()
        {
            MigrateSqlServerSqlDbTaskProperties properties = new MigrateSqlServerSqlDbTaskProperties();

            SqlConnectionInfo source = new SqlConnectionInfo();
            SqlConnectionInfo target = new SqlConnectionInfo();

            source = (SqlConnectionInfo)MyInvocation.BoundParameters[SourceConnection];
            PSCredential sourceCred = (PSCredential)MyInvocation.BoundParameters[SourceCred];
            source.UserName = sourceCred.UserName;
            source.Password = Decrypt(sourceCred.Password);

            target = (SqlConnectionInfo)MyInvocation.BoundParameters[TargetConnection];
            PSCredential targetCred = (PSCredential)MyInvocation.BoundParameters[TargetCred];
            target.UserName = targetCred.UserName;
            target.Password = Decrypt(targetCred.Password);

            MigrateSqlServerSqlDbTaskInput input = new MigrateSqlServerSqlDbTaskInput
            {
                SourceConnectionInfo = source,
                TargetConnectionInfo = target
            };

            if (MyInvocation.BoundParameters.ContainsKey(SelectedDatabase))
            {
                input.SelectedDatabases = ((MigrateSqlServerSqlDbDatabaseInput[])MyInvocation.BoundParameters[SelectedDatabase]).ToList();
            }

            MigrationValidationOptions options = new MigrationValidationOptions();

            if (MyInvocation.BoundParameters.ContainsKey(SchemaValidation))
            {
                options.EnableSchemaValidation = (SwitchParameter)MyInvocation.BoundParameters[SchemaValidation];
            }
            else
            {
                options.EnableSchemaValidation = false;
            }

            if (MyInvocation.BoundParameters.ContainsKey(DataIntegrityValidation))
            {
                options.EnableDataIntegrityValidation = (SwitchParameter)MyInvocation.BoundParameters[DataIntegrityValidation];
            }
            else
            {
                options.EnableDataIntegrityValidation = false;
            }

            if (MyInvocation.BoundParameters.ContainsKey(QueryAnalysisValidation))
            {
                options.EnableQueryAnalysisValidation = (SwitchParameter)MyInvocation.BoundParameters[QueryAnalysisValidation];
            }
            else
            {
                options.EnableQueryAnalysisValidation = false;
            }

            input.ValidationOptions = options;

            properties.Input = input;

            return properties;
        }
    }
}
