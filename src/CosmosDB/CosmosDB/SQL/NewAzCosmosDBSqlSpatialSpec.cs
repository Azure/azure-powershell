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
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBSqlSpatialSpec"), OutputType(typeof(PSSpatialSpec))]
    public class NewAzCosmosDBSqlSpatialSpec : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = Constants.SpatialPathHelpMessage)]
        public string Path { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.SpatialTypeHelpMessage)]
        public string[] Type { get; set; }

        public override void ExecuteCmdlet()
        {
            PSSpatialSpec pSSpatialSpec = new PSSpatialSpec();

            if (Type != null && Type.Length > 0)
            {
                IList<string> Types = new List<string>();
                foreach (string type in Type)
                {
                    Types.Add(type);
                }
                pSSpatialSpec.Types = Types;
            }

            if (Path != null)
            {     
                pSSpatialSpec.Path = Path;
            }

            WriteObject(pSSpatialSpec);
            return;
        }
    }
}
