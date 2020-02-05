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

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBSqlCompositePath"), OutputType(typeof(PSCompositePath))]
    public class NewAzCosmosDBSqlCompositePath : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = Constants.CompositePathHelpMessage)]
        public string Path { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.CompositePathOrderTypeHelpMessage)]
        [PSArgumentCompleter("Ascending", "Descending")]
        public string Order { get; set; }

        public override void ExecuteCmdlet()
        {
            PSCompositePath pSCompositePath = new PSCompositePath();

            if(Path != null)
            {
                pSCompositePath.Path = Path;
            }

            if(Order != null)
            {
                pSCompositePath.Order = Order;
            }

            WriteObject(pSCompositePath);
            return;
        }
    }
}
