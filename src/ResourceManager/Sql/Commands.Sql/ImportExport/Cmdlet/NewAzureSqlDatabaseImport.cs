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
using Microsoft.Azure.Commands.Sql.ImportExport.Model;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ImportExport.Cmdlet
{
    /// <summary>
    /// Defines the AzureRmSqlDatabaseImport cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmSqlDatabaseImport", SupportsShouldProcess = true)]
    public class NewAzureSqlDatabaseImport : ImportExportCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the database to use.
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "SQL Database name.")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the edition of the database
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The edition of the database")]
        [ValidateNotNull]
        public DatabaseEdition Edition
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the name of the service objective to assign to the Azure SQL Database
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The name of the service objective to assign to the Azure SQL Database.")]
        [ValidateNotNullOrEmpty]
        public string ServiceObjectiveName
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the maximum size for the newly imported database
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The maximum size in bytes for the newly imported database")]
        public int DatabaseMaxSizeBytes
        {
            get; set;
        }

        /// <summary>
        /// Get the Firewall Rule to update
        /// </summary>
        /// <returns>The Firewall Rule being updated</returns>
        protected override Model.AzureSqlDatabaseImportExportBaseModel GetEntity()
        {
            return new AzureSqlDatabaseImportModel();
        }

        /// <summary>
        /// Creates a new import request
        /// </summary>
        /// <param name="entity">Import Request Model</param>
        /// <returns>Import Request Response</returns>
        protected override AzureSqlDatabaseImportExportBaseModel PersistChanges(AzureSqlDatabaseImportExportBaseModel entity)
        {
            AzureSqlDatabaseImportModel importModel = entity as AzureSqlDatabaseImportModel;
            if (importModel == null)
            {
                throw new ArgumentNullException("importModel");
            }
            return ModelAdapter.Import(importModel);

        }

        /// <summary>
        /// Updates the given model element with the cmdlet specific operation 
        /// </summary>
        /// <param name="model">A model object</param>
        protected override AzureSqlDatabaseImportExportBaseModel ApplyUserInputToModel(AzureSqlDatabaseImportExportBaseModel model)
        {
            AzureSqlDatabaseImportModel exportRequest = new AzureSqlDatabaseImportModel()
            {
                ResourceGroupName = ResourceGroupName,
                AdministratorLogin = AdministratorLogin,
                AdministratorLoginPassword = AdministratorLoginPassword,
                AuthenticationType = AuthenticationType,
                DatabaseName = DatabaseName,
                ServerName = ServerName,
                StorageKey = StorageKey,
                StorageKeyType = StorageKeyType,
                StorageUri = StorageUri,
                Edition = Edition,
                ServiceObjectiveName = ServiceObjectiveName,
                DatabaseMaxSizeBytes = DatabaseMaxSizeBytes
            };
            return exportRequest;
        }
    }
}
