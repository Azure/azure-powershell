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

using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.WindowsAzure.Commands.Common.Attributes;

namespace Microsoft.Azure.Commands.CosmosDB.Models
{
    public class PSSqlRoleAssignmentGetResults
    {

        public PSSqlRoleAssignmentGetResults()
        {
        }        
        
        public PSSqlRoleAssignmentGetResults(SqlRoleAssignmentGetResults sqlRoleAssignmentGetResults)
        {
            if (sqlRoleAssignmentGetResults == null)
            {
                return;
            }

            Id = sqlRoleAssignmentGetResults.Id;
            Scope = sqlRoleAssignmentGetResults.Scope;
            RoleDefinitionId = sqlRoleAssignmentGetResults.RoleDefinitionId;
            PrincipalId = sqlRoleAssignmentGetResults.PrincipalId;
        }

        /// <summary>
        /// Gets or sets Id of the Cosmos DB SQL Role Assignment
        /// </summary>
        [Ps1Xml(Label = "Id", Target = ViewControl.List)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets Scope of the Cosmos DB SQL Role Assignment
        /// </summary>
        [Ps1Xml(Label = "Scope", Target = ViewControl.List)]
        public string Scope { get; set; }

        /// <summary>
        /// Gets or sets RoleDefinitionId of the Cosmos DB SQL Role Assignment
        /// </summary>
        [Ps1Xml(Label = "RoleDefinitionId", Target = ViewControl.List)]
        public string RoleDefinitionId { get; set; }

        /// <summary>
        /// Gets or sets PrincipalId of the Cosmos DB SQL Role Assignment
        /// </summary>
        [Ps1Xml(Label = "PrincipalId", Target = ViewControl.List)]
        public string PrincipalId { get; set; }
    }
}