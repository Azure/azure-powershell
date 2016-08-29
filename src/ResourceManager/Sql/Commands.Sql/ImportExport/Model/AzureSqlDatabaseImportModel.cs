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

using Microsoft.Azure.Commands.Sql.Database.Model;

namespace Microsoft.Azure.Commands.Sql.ImportExport.Model
{
    /// <summary>
    /// Represents an Azure Sql Database Import Request
    /// </summary>
    public class AzureSqlDatabaseImportModel : AzureSqlDatabaseImportExportBaseModel
    {
        /// <summary>
        /// Gets or sets the edition of the database
        /// </summary>
        public DatabaseEdition Edition
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the name of the service objective to assign to the Azure SQL Database
        /// </summary>
        public string ServiceObjectiveName
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the maximum size for the newly imported database
        /// </summary>
        public int DatabaseMaxSizeBytes
        {
            get; set;
        }

        /// <summary>
        /// Copies the model to a new class
        /// </summary>
        internal override AzureSqlDatabaseImportExportBaseModel Copy()
        {
            return new AzureSqlDatabaseImportModel()
            {
                ResourceGroupName = ResourceGroupName,
                ServerName = ServerName,
                AdministratorLogin = AdministratorLogin,
                AuthenticationType = AuthenticationType,
                DatabaseName = DatabaseName,
                StorageKeyType = StorageKeyType,
                StorageUri = StorageUri,
                Edition = Edition,
                ServiceObjectiveName = ServiceObjectiveName,
                DatabaseMaxSizeBytes = DatabaseMaxSizeBytes
            };
        }
    }
}
