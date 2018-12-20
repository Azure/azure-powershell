// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MigrateMongoDbTaskCmdlet.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Management.Automation;
using Microsoft.Azure.Commands.DataMigration.Models;
using Microsoft.Azure.Management.DataMigration.Models;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{

    public class MigrateMongoDbTaskCmdlet : ValidateMongoDbMigrationTaskCmdlet
    {
        private readonly string MigrationValidation = "MigrationValidation";

        public MigrateMongoDbTaskCmdlet(InvocationInfo myInvocation) : base(myInvocation)
        {
        }

        public override void CustomInit()
        {
            base.CustomInit();
            this.SimpleParam(MigrationValidation, typeof(PSProjectTask), "Result from your validation call", true);
        }

        protected override ProjectTaskProperties CreateTaskProperties(MongoDbMigrationSettings input)
        {
            return new MigrateMongoDbTaskProperties() { Input = input };
        }

        public override ProjectTaskProperties ProcessTaskCmdlet()
        {
            var validationResult = MyInvocation.BoundParameters[MigrationValidation] as PSProjectTask;
            if ( validationResult == null || 
                 validationResult.ProjectTask == null || 
                 validationResult.ProjectTask.Properties == null ||
                 validationResult.ProjectTask.Properties.State != "Succeeded")
            {
                throw new PSArgumentException("Failed or pending migration validation, please check your validation task state and error");
            }

            return base.ProcessTaskCmdlet();
        }
    }
}
