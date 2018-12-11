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
using Microsoft.Azure.Commands.DataMigration.Models.MongoDb;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    /// <summary>
    /// Class that creates a new instance of the mongo db target database setting
    /// </summary>
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataMigrationMongoDbDatabaseSetting", SupportsShouldProcess = true), OutputType(typeof(MongoDbDatabaseSetting))]
    [Alias("New-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DmsMongoDbDatabaseSetting")]
    public class NewMongoDbDatabaseSettingCmdlet : DataMigrationCmdlet
    {
        [Parameter(
           Mandatory = true,
           HelpMessage = "The mongo db database name"
               )]
        [Alias("DatabaseName")]
        public string Name { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "The database level shared RU at the target CosmosDb"
               )]
        [Alias("RU")]
        [ValidateRange(400,1000000)]
        public int? TargetRequestUnit { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "The collection settings for the databases, refer to: New-AzureRmDmsMongoCollectionSetting"
               )]
        [Alias("Coll")]
        public MongoDbCollectionSetting[] CollectionSetting { get; set; }
        
        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(this.Name, Resources.createDbInfo))
            {
                base.ExecuteCmdlet();
                var dbInfo = new MongoDbDatabaseSettings()
                {
                    TargetRUs = this.TargetRequestUnit,
                    Collections = new System.Collections.Generic.Dictionary<string, MongoDbCollectionSettings>()
                };

                if (this.CollectionSetting != null && this.CollectionSetting.Length > 0)
                {
                    foreach(var col in this.CollectionSetting)
                    {
                        dbInfo.Collections.Add(col.Name, col.Setting);
                    }
                }

                WriteObject(new MongoDbDatabaseSetting { Name = this.Name, Setting = dbInfo });
            }
        }
    }
}
