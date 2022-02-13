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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBSqlRoleAssignment", DefaultParameterSetName = NameParameterSet), OutputType(typeof(PSSqlRoleAssignmentGetResults))]
    public class GetAzCosmosDBSqlRoleAssignment : AzureCosmosDBCmdletBase
    {
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        public string ResourceGroupName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        public string AccountName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = false, HelpMessage = Constants.RoleAssignmentIdHelpMessage)]
        public string Id { get; set; }

        [ValidateNotNull]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.AccountObjectHelpMessage)]
        public PSDatabaseAccountGetResults ParentObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ParentObjectParameterSet, StringComparison.Ordinal))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(ParentObject.Id);
                AccountName = resourceIdentifier.ResourceName;
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
            }

            if (!string.IsNullOrEmpty(Id))
            {
                SqlRoleAssignmentGetResults sqlRoleAssignmentGetResults = CosmosDBManagementClient.SqlResources.GetSqlRoleAssignmentWithHttpMessagesAsync(RoleHelper.ParseToRoleAssignmentId(Id), ResourceGroupName, AccountName).GetAwaiter().GetResult().Body;
                WriteObject(new PSSqlRoleAssignmentGetResults(sqlRoleAssignmentGetResults));
            }
            else
            {
                IEnumerable<SqlRoleAssignmentGetResults> sqlRoleAssignments = CosmosDBManagementClient.SqlResources.ListSqlRoleAssignmentsWithHttpMessagesAsync(ResourceGroupName, AccountName).GetAwaiter().GetResult().Body;

                foreach (SqlRoleAssignmentGetResults sqlRoleAssignment in sqlRoleAssignments)
                {
                    WriteObject(new PSSqlRoleAssignmentGetResults(sqlRoleAssignment));
                }
            }

            return;
        }
    }
}
