// ----------------------------------------------------------------------------------
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

using Microsoft.WindowsAzure.Commands.SqlDatabase.Model;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Common;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Services.ImportExport
{
    /// <summary>
    /// Holds the necessary information to query or stop an import/export operation
    /// </summary>
    public class ImportExportRequest : SqlDatabaseServerOperationContext
    {
        /// <summary>
        /// Gets or sets the SQL login credentials
        /// </summary>
        public SqlAuthenticationCredentials SqlCredentials { get; set; }

        /// <summary>
        /// Gets or sets the GUID that represents this operation
        /// </summary>
        public string RequestGuid { get; set; }
    }
}
