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

namespace Microsoft.Azure.Commands.Sql.Database.Model
{
    /// <summary>
    /// Represents an Azure Sql Database
    /// </summary>
    public class AzureSqlDatabaseActivityModel
    {
        /// <summary>
        /// Represents the state of the properties
        /// </summary>
        public class DatabaseState
        {
            /// <summary>
            /// Gets or sets the properties of the database at the time of the start of the operation
            /// </summary>
            public IDictionary<string, string> Current { get; set; }

            /// <summary>
            /// Gets or sets the requested properties for the database
            /// </summary>
            public IDictionary<string, string> Requested { get; set; }
        }

        /// <summary>
        /// Gets or sets the operation id
        /// </summary>
        public Guid OperationId { get; set; }

        /// <summary>
        /// Gets or sets the server name
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the database name
        /// </summary>
        public string DatabaseName { get; set; }

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
        /// Gets or sets the state of the properties associated with the request
        /// </summary>
        public DatabaseState Properties { get; set; }
    }
}
