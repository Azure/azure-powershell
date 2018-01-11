// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MigrateSqlServerSqlDbTaskCmdlet.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Management.DataMigration.Models;
using Microsoft.Azure.Management.DataMigration;

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
            }else
            {
                options.EnableSchemaValidation = false;
            }

            if (MyInvocation.BoundParameters.ContainsKey(DataIntegrityValidation))
            {
                options.EnableDataIntegrityValidation = (SwitchParameter)MyInvocation.BoundParameters[DataIntegrityValidation];
            }else
            {
                options.EnableDataIntegrityValidation = false;
            }

            if (MyInvocation.BoundParameters.ContainsKey(QueryAnalysisValidation))
            {
                options.EnableQueryAnalysisValidation = (SwitchParameter)MyInvocation.BoundParameters[QueryAnalysisValidation];
            }else
            {
                options.EnableQueryAnalysisValidation = false;
            }

            input.ValidationOptions = options;

            properties.Input = input;

            return properties;
        }
    }
}
