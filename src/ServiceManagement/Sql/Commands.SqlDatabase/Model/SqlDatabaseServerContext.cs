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
    /// Represents a server and includes the operation context under which it was obtained.
    /// </summary>
    public class SqlDatabaseServerContext : SqlDatabaseServerOperationContext
    {
        /// <summary>
        /// Gets or sets the administrator login for the server.
        /// </summary>
        public string AdministratorLogin { get; set; }

        /// <summary>
        /// Gets or sets the location (region) where the server resides.  Eg: East Asia
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the version number of the server.  Valid values are 1.0 and 2.0.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the current state of the server.
        /// </summary>
        public string State { get; set; }
    }
}
