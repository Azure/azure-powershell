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

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Model
{
    /// <summary>
    /// Represents a server quota and the operation context from which it was obtained.
    /// </summary>
    public class SqlDatabaseServerQuotaContext : SqlDatabaseServerOperationContext
    {
        /// <summary>
        /// Gets or sets the name of the quota.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the quota.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the state of the server quota.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the value of the quota.  This will be the maximum for the quota.
        /// </summary>
        public string Value { get; set; }
    }
}
