// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MigrateMongoDbTaskCmdlet.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Management.Automation;
using Microsoft.Azure.Management.DataMigration.Models;
using PSModels = Microsoft.Azure.Commands.DataMigration.Models;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    using MongoDbDatabaseDictionary = System.Collections.Generic.Dictionary<string, MongoDbDatabaseSettings>;
    using MongoDbDatabaseSettingItem = System.Collections.Generic.KeyValuePair<string, MongoDbDatabaseSettings>;

    public class MigrateMongoDbTaskCmdlet : TaskCmdlet<PSModels.MongoDbConnectionInfo>
    {
        private readonly string Replication = "Replication";
        private readonly string SelectedDatabase = "SelectedDatabase";

        public MigrateMongoDbTaskCmdlet(InvocationInfo myInvocation) : base(myInvocation)
        {
        }

        public override void CustomInit()
        {
            this.SimpleParam(SourceConnection, typeof(PSModels.MongoDbConnectionInfo), "Source Connection Info Detail", true);
            this.SimpleParam(TargetConnection, typeof(PSModels.MongoDbConnectionInfo), "Target Connection Info Detail", true);
            this.SimpleParam(Replication, typeof(string), "type of migration, valid value: OneTime, Continous, or Disabled, default is OneTime");
            this.SimpleParam(SelectedDatabase, typeof(MongoDbDatabaseSettingItem[]), "Selected database to migrate", true);
        }

        public override ProjectTaskProperties ProcessTaskCmdlet()
        {
            var properties = new MigrateMongoDbTaskProperties();
            properties.ClientData = new System.Collections.Generic.Dictionary<string, string>()
            {
                {  "startedOn", System.DateTime.UtcNow.ToString("o") }
            };

            var source = MyInvocation.BoundParameters[SourceConnection] as PSModels.MongoDbConnectionInfo;
            var target = MyInvocation.BoundParameters[TargetConnection] as PSModels.MongoDbConnectionInfo;

            var input = properties.Input = new MongoDbMigrationSettings()
            {
                Source = new MongoDbConnectionInfo { ConnectionString = source.ConnectionString },
                Target = new MongoDbConnectionInfo { ConnectionString = target.ConnectionString },
                Replication = "OneTime",
                Databases = new MongoDbDatabaseDictionary()
            };

            if (MyInvocation.BoundParameters.ContainsKey(SelectedDatabase))
            {
                var items = MyInvocation.BoundParameters[SelectedDatabase] as MongoDbDatabaseSettingItem[];
                foreach (var i in items)
                {
                    input.Databases.Add(i);
                }
            }

            if (MyInvocation.BoundParameters.ContainsKey(Replication))
            {
                input.Replication = MyInvocation.BoundParameters[Replication] as string;
            }

            properties.Input = input;
            return properties;
        }
    }
}
