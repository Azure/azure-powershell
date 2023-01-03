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
    public class PSMongoDBUserDefinitionGetResults
    {
        public PSMongoDBUserDefinitionGetResults()
        {
        }

        public PSMongoDBUserDefinitionGetResults(MongoUserDefinitionGetResults mongoUserDefinitionGetResults)
        {
            if (mongoUserDefinitionGetResults == null)
            {
                return;
            }

            Id = mongoUserDefinitionGetResults.Id;
            UserName = mongoUserDefinitionGetResults.UserName;
            Password = mongoUserDefinitionGetResults.Password;
            Mechanisms = mongoUserDefinitionGetResults.Mechanisms;
            DatabaseName = mongoUserDefinitionGetResults.DatabaseName;
            Roles = new List<Role>(mongoUserDefinitionGetResults.Roles);
            CustomData = mongoUserDefinitionGetResults.CustomData;
        }

        /// <summary>
        /// Gets or sets Id of the Cosmos DB Mongo DB User Definition
        /// </summary>
        [Ps1Xml(Label = "Id", Target = ViewControl.List)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets UserName of the Cosmos DB Mongo DB User Definition
        /// </summary>
        [Ps1Xml(Label = "UserName", Target = ViewControl.List)]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets Password of the Cosmos DB Mongo DB User Definition
        /// </summary>
        [Ps1Xml(Label = "Password", Target = ViewControl.List)]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets Mechanisms of the Cosmos DB Mongo DB User Definition
        /// </summary>
        [Ps1Xml(Label = "Mechanisms", Target = ViewControl.List)]
        public string Mechanisms { get; set; }

        /// <summary>
        /// Gets or sets AssignableScopes of the Cosmos DB SQL Role Definition
        /// </summary>
        [Ps1Xml(Label = "DatabaseName", Target = ViewControl.List)]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets Custom Data of the Cosmos DB Mongo DB User Definition
        /// </summary>
        [Ps1Xml(Label = "CustomData", Target = ViewControl.List)]
        public string CustomData { get; set; }

        /// <summary>
        /// Gets or sets Privileges of the Cosmos DB MongoDB Role Definition
        /// </summary>
        [Ps1Xml(Label = "Roles.Role", Target = ViewControl.List, ScriptBlock = "$_.Roles.Role")]
        [Ps1Xml(Label = "Roles.Db", Target = ViewControl.List, ScriptBlock = "$_.Roles.Db")]
        public IList<Role> Roles { get; set; }
    }
}
