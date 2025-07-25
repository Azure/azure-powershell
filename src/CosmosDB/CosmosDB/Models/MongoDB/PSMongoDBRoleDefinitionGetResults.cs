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
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Models.MongoDB
{
    public class PSMongoDBRoleDefinitionGetResults
    {
        public PSMongoDBRoleDefinitionGetResults()
        {
        }

        public PSMongoDBRoleDefinitionGetResults(MongoRoleDefinitionGetResults mongoRoleDefinitionGetResults)
        {
            if (mongoRoleDefinitionGetResults == null)
            {
                return;
            }

            RoleName = mongoRoleDefinitionGetResults.RoleName;
            Id = mongoRoleDefinitionGetResults.Id;
            Type = mongoRoleDefinitionGetResults.PropertiesType.ToString();
            DatabaseName = mongoRoleDefinitionGetResults.DatabaseName;
            Privileges = new List<Privilege>(mongoRoleDefinitionGetResults.Privileges);
            Roles = new List<Role>(mongoRoleDefinitionGetResults.Roles);
        }

        /// <summary>
        /// Gets or sets Id of the Cosmos DB MongoDB Role Definition
        /// </summary>
        [Ps1Xml(Label = "Id", Target = ViewControl.List)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets RoleName of the Cosmos DB MongoDB Role Definition
        /// </summary>
        [Ps1Xml(Label = "RoleName", Target = ViewControl.List)]
        public string RoleName { get; set; }

        /// <summary>
        /// Gets or sets Type of the Cosmos DB MongoDB Role Definition
        /// </summary>
        [Ps1Xml(Label = "Type", Target = ViewControl.List)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets AssignableScopes of the Cosmos DB SQL Role Definition
        /// </summary>
        [Ps1Xml(Label = "DatabaseName", Target = ViewControl.List)]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets Privileges of the Cosmos DB MongoDB Role Definition
        /// </summary>
        [Ps1Xml(Label = "Privileges.Resource", Target = ViewControl.List, ScriptBlock = "$_.Privileges.Resource")]
        [Ps1Xml(Label = "Privileges.Actions", Target = ViewControl.List, ScriptBlock = "$_.Privileges.Actions")]
        public IList<Privilege> Privileges { get; set; }

        /// <summary>
        /// Gets or sets Privileges of the Cosmos DB MongoDB Role Definition
        /// </summary>
        [Ps1Xml(Label = "Roles.Role", Target = ViewControl.List, ScriptBlock = "$_.Roles.Role")]
        [Ps1Xml(Label = "Roles.Db", Target = ViewControl.List, ScriptBlock = "$_.Roles.Db")]
        public IList<Role> Roles { get; set; }
    }
}
