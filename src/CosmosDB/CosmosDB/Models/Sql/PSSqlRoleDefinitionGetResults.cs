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

using System.Collections.Generic;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.WindowsAzure.Commands.Common.Attributes;

namespace Microsoft.Azure.Commands.CosmosDB.Models
{
    public class PSSqlRoleDefinitionGetResults
    {

        public PSSqlRoleDefinitionGetResults()
        {
        }        
        
        public PSSqlRoleDefinitionGetResults(SqlRoleDefinitionGetResults sqlRoleDefinitionGetResults)
        {
            if (sqlRoleDefinitionGetResults == null)
            {
                return;
            }

            RoleName = sqlRoleDefinitionGetResults.RoleName;
            Id = sqlRoleDefinitionGetResults.Id;
            Type = sqlRoleDefinitionGetResults.SqlRoleDefinitionGetResultsType.ToString();
            Permissions = new List<Permission>(sqlRoleDefinitionGetResults.Permissions);
            AssignableScopes = new List<string>(sqlRoleDefinitionGetResults.AssignableScopes);
        }

        /// <summary>
        /// Gets or sets Id of the Cosmos DB SQL Role Definition
        /// </summary>
        [Ps1Xml(Label = "Id", Target = ViewControl.List)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets RoleName of the Cosmos DB SQL Role Definition
        /// </summary>
        [Ps1Xml(Label = "RoleName", Target = ViewControl.List)]
        public string RoleName { get; set; }

        /// <summary>
        /// Gets or sets Type of the Cosmos DB SQL Role Definition
        /// </summary>
        [Ps1Xml(Label = "Type", Target = ViewControl.List)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets AssignableScopes of the Cosmos DB SQL Role Definition
        /// </summary>
        [Ps1Xml(Label = "AssignableScopes", Target = ViewControl.List)]
        public IList<string> AssignableScopes { get; set; }

        /// <summary>
        /// Gets or sets DataActions of the Cosmos DB SQL Role Definition
        /// </summary>
        [Ps1Xml(Label = "Permissions.DataActions", Target = ViewControl.List, ScriptBlock = "$_.Permissions.DataActions")]
        [Ps1Xml(Label = "Permissions.NotDataActions", Target = ViewControl.List, ScriptBlock = "$_.Permissions.NotDataActions")]
        public IList<Permission> Permissions { get; set; }
    }
}