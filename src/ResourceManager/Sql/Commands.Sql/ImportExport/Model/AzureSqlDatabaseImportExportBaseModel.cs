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
using System.Security;

namespace Microsoft.Azure.Commands.Sql.ImportExport.Model
{
    /// <summary>
    /// Represents an Azure Sql Database Import/Export request
    /// </summary>
    public class AzureSqlDatabaseImportExportBaseModel
    {
        /// <summary>
        /// Gets or sets the name of the resource group
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the Azure SQL Server to use.
        /// </summary>
        public string ServerName
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the name of the Azure SQL database to export
        /// </summary>
        public string DatabaseName
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the type of the storage key to use.
        /// </summary>
        public StorageKeyType StorageKeyType
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the storage key to use.
        /// </summary>
        public string StorageKey
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the blob URI of the .bacpac file
        /// </summary>
        public Uri StorageUri
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the name of the SQL administrator
        /// </summary>
        public string AdministratorLogin
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the password of the SQL administrator
        /// </summary>
        public SecureString AdministratorLoginPassword
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the authentication type
        /// </summary>
        public AuthenticationType AuthenticationType
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the operationStatusLink
        /// </summary>
        public string OperationStatusLink
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the status message returned from the server.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the error message returned from the server.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Copies the model to a new class
        /// </summary>
        internal virtual AzureSqlDatabaseImportExportBaseModel Copy()
        {
            return new AzureSqlDatabaseImportExportBaseModel()
            {
                ResourceGroupName = ResourceGroupName,
                ServerName = ServerName,
                AdministratorLogin = AdministratorLogin,
                AuthenticationType = AuthenticationType,
                DatabaseName = DatabaseName,
                StorageKeyType = StorageKeyType,
                StorageUri = StorageUri
            };
        }
    }
}
