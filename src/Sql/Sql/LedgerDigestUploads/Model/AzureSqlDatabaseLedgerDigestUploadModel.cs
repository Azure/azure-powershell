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

namespace Microsoft.Azure.Commands.Sql.LedgerDigestUploads.Model
{
    /// <summary>
    /// The possible states in which an ledger digest upload configuration may be in
    /// </summary>
    public enum LedgerDigestUploadStateType { Enabled, Disabled };

    public class AzureSqlDatabaseLedgerDigestUploadModel
    {
        /// <summary>
        /// Construct AzureSqlDatabaseLedgerDigestUploadModel from Management.Sql.LedgerDigestUploads object
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure SQL Server</param>
        /// <param name="databaseName">The name of the Azure SQL Database</param>
        /// <param name="configuration">Management.Sql.LedgerDigestUploads object</param>
        public AzureSqlDatabaseLedgerDigestUploadModel(string resourceGroup, string serverName, string databaseName, Management.Sql.Models.LedgerDigestUploads configuration)
        {
            ResourceGroupName = resourceGroup;
            ServerName = serverName;
            DatabaseName = databaseName;
            Endpoint = configuration.DigestStorageEndpoint;
            State = string.IsNullOrEmpty(Endpoint) ? LedgerDigestUploadStateType.Disabled : LedgerDigestUploadStateType.Enabled;
        }
        /// <summary>
        /// Gets or sets the name of the resource group
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the server
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the database
        /// </summary>
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets the ledger digest upload state
        /// </summary>
        public LedgerDigestUploadStateType State { get; }

        /// <summary>
        /// Gets or sets the ledger digest upload endpoint
        /// </summary>
        public string Endpoint { get; set; }
    }
}
