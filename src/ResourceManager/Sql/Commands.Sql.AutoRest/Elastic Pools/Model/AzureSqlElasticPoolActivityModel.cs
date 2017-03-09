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

namespace Microsoft.Azure.Commands.Sql.ElasticPool.Model
{
    /// <summary>
    /// Represents an Azure Sql Database
    /// </summary>
    public class AzureSqlElasticPoolActivityModel
    {
        /// <summary>
        /// Gets or sets the operation id
        /// </summary>
        public Guid OperationId { get; set; }

        /// <summary>
        /// Gets or sets the server name
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the resource pool name
        /// </summary>
        public string ElasticPoolName { get; set; }

        /// <summary>
        /// Gets or sets the state
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets operation
        /// </summary>
        public string Operation { get; set; }

        /// <summary>
        /// Gets or sets the error code
        /// </summary>
        public int? ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the error message
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the error severity
        /// </summary>
        public int? ErrorSeverity { get; set; }

        /// <summary>
        /// Gets or sets the start time
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Gets or sets the percent complete
        /// </summary>
        public int? PercentComplete { get; set; }

        /// <summary>
        /// Gets or sets the requested resource pool name
        /// </summary>
        public string RequestedElasticPoolName { get; set; }

        /// <summary>
        /// Gets or sets the requested DTU
        /// </summary>
        public int? RequestedDtu { get; set; }

        /// <summary>
        /// Gets or sets the requested DTU max
        /// </summary>
        public int? RequestedDatabaseDtuMax { get; set; }

        /// <summary>
        /// Gets or sets the requested DTU min
        /// </summary>
        public int? RequestedDatabaseDtuMin { get; set; }

        /// <summary>
        /// Gets or sets the requested storage limit in GB
        /// </summary>
        public long? RequestedStorageLimitInGB { get; set; }
    }
}
