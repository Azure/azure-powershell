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
    public class PSSoftDeletedSqlContainerGetResult
    {
        public PSSoftDeletedSqlContainerGetResult()
        {
        }

        public PSSoftDeletedSqlContainerGetResult(SoftDeletedSqlContainerGetResult softDeletedSqlContainerGetResult)
        {
            if (softDeletedSqlContainerGetResult == null)
            {
                return;
            }

            Id = softDeletedSqlContainerGetResult.Id;
            Name = softDeletedSqlContainerGetResult.Name;
            Type = softDeletedSqlContainerGetResult.Type;
            IsSoftDeleted = softDeletedSqlContainerGetResult.Properties?.SoftDeletionMetadata?.IsSoftDeleted;
            SoftDeletionStartTimestamp = softDeletedSqlContainerGetResult.Properties?.SoftDeletionMetadata?.SoftDeletionStartTimestamp;
            SoftDeletionResourceExpirationTimestamp = softDeletedSqlContainerGetResult.Properties?.SoftDeletionMetadata?.SoftDeletionResourceExpirationTimestamp;
            ResourceId = softDeletedSqlContainerGetResult.Properties?.Resource?.Id;
        }

        /// <summary>
        /// Gets or sets the unique resource identifier.
        /// </summary>
        [Ps1Xml(Label = "Id", Target = ViewControl.List)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the soft-deleted SQL container.
        /// </summary>
        [Ps1Xml(Label = "Name", Target = ViewControl.List)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of Azure resource.
        /// </summary>
        [Ps1Xml(Label = "Type", Target = ViewControl.List)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets whether the container is soft-deleted.
        /// </summary>
        [Ps1Xml(Label = "IsSoftDeleted", Target = ViewControl.List)]
        public bool? IsSoftDeleted { get; set; }

        /// <summary>
        /// Gets or sets the time at which the container was deleted (epoch timestamp).
        /// </summary>
        [Ps1Xml(Label = "SoftDeletionStartTimestamp", Target = ViewControl.List)]
        public long? SoftDeletionStartTimestamp { get; set; }

        /// <summary>
        /// Gets or sets the time at which the container will be permanently purged (epoch timestamp).
        /// </summary>
        [Ps1Xml(Label = "SoftDeletionResourceExpirationTimestamp", Target = ViewControl.List)]
        public long? SoftDeletionResourceExpirationTimestamp { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the soft-deleted container.
        /// </summary>
        [Ps1Xml(Label = "ResourceId", Target = ViewControl.List)]
        public string ResourceId { get; set; }
    }
}
