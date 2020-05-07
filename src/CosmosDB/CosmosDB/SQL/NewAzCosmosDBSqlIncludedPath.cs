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
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBSqlIncludedPath"), OutputType(typeof(PSIncludedPath))]
    public class NewAzCosmosDBSqlIncludedPath : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = Constants.IncludedPathHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.IncludedPathIndexesHelpMessage)]
        [ValidateNotNullOrEmpty]
        public PSIndexes[] Index { get; set; }

        public override void ExecuteCmdlet()
        {
            PSIncludedPath pSIncludedPath = new PSIncludedPath();

            if (Path != null)
            {
                pSIncludedPath.Path = Path;
            }

            if(Index != null && Index.Length > 0)
            {
                pSIncludedPath.Indexes = new List<PSIndexes>(Index);
            }

            WriteObject(pSIncludedPath);
            return;
        }
    }
}
