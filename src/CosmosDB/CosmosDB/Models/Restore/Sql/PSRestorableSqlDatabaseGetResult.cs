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

using Microsoft.WindowsAzure.Commands.Common.Attributes;

namespace Microsoft.Azure.Management.CosmosDB.Models
{
    public class PSRestorableSqlDatabaseGetResult
    {
        public PSRestorableSqlDatabaseGetResult()
        {
        }

        public PSRestorableSqlDatabaseGetResult(RestorableSqlDatabaseGetResult restorableSqlDatabaseGetResult)
        {
            if (restorableSqlDatabaseGetResult == null)
            {
                return;
            }

            Name = restorableSqlDatabaseGetResult.Name;
            Id = restorableSqlDatabaseGetResult.Id;
            Type = restorableSqlDatabaseGetResult.Type;
            Resource = new PSRestorableSqlDatabasePropertiesResource(restorableSqlDatabaseGetResult.Resource);
        }

        /// <summary>
        /// Gets or sets Name of the Cosmos DB Sql database
        /// </summary>
        [Ps1Xml(Label = "Name", Target = ViewControl.List)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Id of the Cosmos DB Sql database
        /// </summary>
        [Ps1Xml(Label = "Id", Target = ViewControl.List)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets Type of the Cosmos DB resource
        /// </summary>
        [Ps1Xml(Label = "Type", Target = ViewControl.List)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the properties of the CosmosDB Sql database resource
        /// </summary>
        [Ps1Xml(Label = "Resource", Target = ViewControl.List)]
        public PSRestorableSqlDatabasePropertiesResource Resource { get; set; }
    }
}
