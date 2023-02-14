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
using System.Text.RegularExpressions;
using Microsoft.Azure.Management.DataMigration.Models;
using Microsoft.Azure.Commands.DataMigration.Models.MongoDb;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    /// <summary>
    /// Class that creates a new instance of the mongo db collection info
    /// </summary>
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataMigrationMongoDbCollectionSetting", SupportsShouldProcess = true), OutputType(typeof(MongoDbCollectionSetting))]
    [Alias("New-"+ ResourceManager.Common.AzureRMConstants.AzureRMPrefix +"DmsMongoDbCollectionSetting")]
    public class NewMongoDbCollectionSettingCmdlet : DataMigrationCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the database collection.")]
        [ValidateNotNullOrEmpty]
        [Alias("CollectionName")]
        public string Name;

        [Parameter(
           Mandatory = false,
           HelpMessage = "The database level shared RU at the target CosmosDb"
               )]
        [Alias("RU")]
        [ValidateRange(400, 1000000)]
        public int? TargetRequestUnit { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "Whether to delete data from the target collection"
               )]
        [Alias("Clean")]
        public SwitchParameter CanDelete { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "Whether to create a unique key for the shard key"
               )]
        [Alias("Unique")]
        public SwitchParameter UniqueShard { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "Comma separated field names to represent shard key to be created, with format of 'a:-1,b:1,c' where -1/1 is for order"
               )]
        public string ShardKey { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(this.Name, Resources.createCollectionSetting))
            {
                base.ExecuteCmdlet();
                var setting = new MongoDbCollectionSettings()
                {
                    TargetRUs = this.TargetRequestUnit,
                    CanDelete = this.CanDelete.IsPresent,
                    ShardKey = new MongoDbShardKeySetting(this._parseShardKey(this.ShardKey), this.UniqueShard.IsPresent)
                };
                WriteObject(new MongoDbCollectionSetting { Name = this.Name, Setting = setting });
            }
        }

        private System.Collections.Generic.List<MongoDbShardKeyField> _parseShardKey(string shardKeyStr)
        {
            var res = new System.Collections.Generic.List<MongoDbShardKeyField>();
            if (!string.IsNullOrWhiteSpace(shardKeyStr))
            {
                var regex = new Regex(@"(?<name>[^,:]+)(\s*:\s*)?((?<order>[\+|\-]?1)\s*)?", RegexOptions.Multiline | RegexOptions.IgnoreCase);
                var matchs = regex.Matches(shardKeyStr);
                for (int i = 0; i < matchs.Count; i++)
                {
                    var m = matchs[i];
                    string name = m.Groups["name"].ToString();
                    string order = m.Groups["order"].ToString();
                    var fieldOrder = MongoDbShardKeyOrder.Hashed;
                    switch (order)
                    {
                        case "Forward": case "1": fieldOrder = MongoDbShardKeyOrder.Forward; break;
                        case "Reverse": case "-1": fieldOrder = MongoDbShardKeyOrder.Reverse; break;
                    }
                    var shardField = new MongoDbShardKeyField
                    {
                        Name = name,
                        Order = fieldOrder
                    };
                    res.Add(shardField);
                }
            }
            return res;
        }
    }
}
