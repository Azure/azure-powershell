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
    public class PSSoftDeletedSqlDatabaseGetResult
    {
        public PSSoftDeletedSqlDatabaseGetResult()
        {
        }

        public PSSoftDeletedSqlDatabaseGetResult(SoftDeletedSqlDatabaseGetResult softDeletedSqlDatabaseGetResult)
        {
            if (softDeletedSqlDatabaseGetResult == null)
            {
                return;
            }

            Id = softDeletedSqlDatabaseGetResult.Id;
            Name = softDeletedSqlDatabaseGetResult.Name;
            Type = softDeletedSqlDatabaseGetResult.Type;
            DeletionTime = softDeletedSqlDatabaseGetResult.DeletionTime;
            ScheduledPurgeTime = softDeletedSqlDatabaseGetResult.ScheduledPurgeTime;
        }

        /// <summary>
        /// Gets or sets the unique resource identifier.
        /// </summary>
        [Ps1Xml(Label = "Id", Target = ViewControl.List)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the soft-deleted SQL database.
        /// </summary>
        [Ps1Xml(Label = "Name", Target = ViewControl.List)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of Azure resource.
        /// </summary>
        [Ps1Xml(Label = "Type", Target = ViewControl.List)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the time at which the database was deleted.
        /// </summary>
        [Ps1Xml(Label = "DeletionTime", Target = ViewControl.List)]
        public System.DateTime? DeletionTime { get; set; }

        /// <summary>
        /// Gets or sets the time at which the database will be permanently purged.
        /// </summary>
        [Ps1Xml(Label = "ScheduledPurgeTime", Target = ViewControl.List)]
        public System.DateTime? ScheduledPurgeTime { get; set; }
    }
}
