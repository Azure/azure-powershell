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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CosmosDB.Models;
using static Microsoft.Azure.Management.CosmosDB.Models.DataType;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBSqlIncludedPathIndex"), OutputType(typeof(PSIndexes))]
    public class NewAzCosmosDBSqlIncludedPathIndex : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = Constants.IncludedPathIndexesDataTypeHelpMessage)]
        [PSArgumentCompleter(String, Number, Point, Polygon, LineString, MultiPolygon)]
        [ValidateNotNullOrEmpty]
        public string DataType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.IncludedPathIndexesPrecisionHelpMessage)]
        public int? Precision { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.IncludedPathIndexesKindHelpMessage)]
        [PSArgumentCompleter(IndexKind.Hash, IndexKind.Range, IndexKind.Spatial)]
        [ValidateNotNullOrEmpty]
        public string Kind { get; set; }

        public override void ExecuteCmdlet()
        {
            PSIndexes pSIndexes = new PSIndexes
            {
                DataType = DataType,
                Precision = Precision,
                Kind = Kind
            };

            WriteObject(pSIndexes);
            return;
        }
    }
}
