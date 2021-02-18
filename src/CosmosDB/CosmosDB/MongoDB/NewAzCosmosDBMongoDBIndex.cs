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
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBMongoDBIndex"), OutputType(typeof(PSMongoIndex))]
    public class NewAzCosmosDBMongoDBIndex : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = Constants.MongoIndexTtlInSeconds)]
        public int? TtlInSeconds { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.MongoIndexUnique)]
        public bool? Unique{ get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.MongoIndexKey)]
        [ValidateNotNullOrEmpty]
        public string[] Key { get; set; }

        public override void ExecuteCmdlet()
        {
            PSMongoIndex pSMongoIndex = new PSMongoIndex();

            if(Key != null && Key.Length > 0)
            {
                pSMongoIndex.Key = new PSMongoIndexKeys
                {
                    Keys = new List<string>()
                };

                foreach (string key in Key)
                {
                    pSMongoIndex.Key.Keys.Add(key);
                }
            }

            if(TtlInSeconds != null || Unique != null )
            {
                pSMongoIndex.Options = new PSMongoIndexOptions
                {
                    ExpireAfterSeconds = TtlInSeconds,
                    Unique = Unique
                };
            }

            WriteObject(pSMongoIndex);
            return;
        }
    }
}
