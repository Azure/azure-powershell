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

using System.Management.Automation;
using Microsoft.Azure.Management.DataMigration.Models;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    using MongoDbCollectionSettingItem = System.Collections.Generic.KeyValuePair<string, MongoDbCollectionSettings>;
    using MongoDbDatabaseSettingItem = System.Collections.Generic.KeyValuePair<string, MongoDbDatabaseSettings>;

    /// <summary>
    /// Class that creates a new instance of the mongo db target database setting
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmDataMigrationMongoDbDatabaseSetting", SupportsShouldProcess = true), OutputType(typeof(MongoDbDatabaseSettingItem))]
    [Alias("New-AzureRmDmsMongoDbDatabaseSetting")]
    public class NewMongoDbDatabaseSettingsCmdlet : DataMigrationCmdlet
    {
        [Parameter(
           Mandatory = true,
           HelpMessage = "The mongo db database name"
               )]
        [Alias("Name")]
        public string DatabaseName { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "The database level shared RU at the target CosmosDb"
               )]
        [Alias("RU")]
        public int? TargetRU { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "The collection settings for the databases, refer to: New-AzureRmDmsMongoCollectionSetting"
               )]
        [Alias("Coll")]
        public MongoDbCollectionSettingItem[] Collections { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(this.DatabaseName, Resources.createDbInfo))
            {
                base.ExecuteCmdlet();
                var dbInfo = new MongoDbDatabaseSettings()
                {
                    TargetRUs = this.TargetRU,
                    Collections = new System.Collections.Generic.Dictionary<string, MongoDbCollectionSettings>()
                };

                var dbInfoItem = new System.Collections.Generic.KeyValuePair<string, MongoDbDatabaseSettings>(this.DatabaseName, dbInfo);
                if (this.Collections != null && this.Collections.Length > 0)
                {
                    foreach(var col in this.Collections)
                    {
                        dbInfoItem.Value.Collections.Add(col);
                    }
                }

                WriteObject(dbInfoItem);
            }
        }
    }
}
