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

using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;
using System.Linq;
using Microsoft.Azure.Commands.CosmosDB.Models;
using System.Reflection;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.CosmosDB.Helpers;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBSqlConflictResolutionPolicy"), OutputType(typeof(PSConflictResolutionPolicy))]
    public class NewAzCosmosDBSqlConflictResolutionPolicy : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = Constants.ConflictResolutionPolicyTypeHelpMessage)]
        [PSArgumentCompleter("LastWriterWins", "Custom", "Manual")]
        public string Type { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ConflictResolutionPolicyPathHelpMessage)]
        public string Path { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ConflictResolutionPolicyStoredProcedureNameHelpMessage)]
        public string StoredProcedureName { get; set; }

        public override void ExecuteCmdlet()
        {
            PSConflictResolutionPolicy conflictResolutionPolicy = new PSConflictResolutionPolicy(Type);

            if (Path != null)
                conflictResolutionPolicy.Path = Path;
            if (StoredProcedureName != null)
                conflictResolutionPolicy.StoredProcedureName = StoredProcedureName;

            WriteObject(conflictResolutionPolicy);
            return;
        }
    }

}
