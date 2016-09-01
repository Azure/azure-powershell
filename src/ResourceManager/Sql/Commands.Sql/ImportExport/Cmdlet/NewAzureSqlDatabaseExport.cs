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

using Microsoft.Azure.Commands.Sql.ImportExport.Model;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ImportExport.Cmdlet
{
    /// <summary>
    /// Defines the StartAzureSqlDatabaseExport cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmSqlDatabaseExport", SupportsShouldProcess = true)]
    public class NewAzureSqlDatabaseExport : ImportExportCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the database to use.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "SQL Database name.")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Updates the given model element with the cmdlet specific operation 
        /// </summary>
        /// <param name="model">A model object</param>
        protected override AzureSqlDatabaseImportExportBaseModel ApplyUserInputToModel(AzureSqlDatabaseImportExportBaseModel model)
        {
            AzureSqlDatabaseImportExportBaseModel exportRequest = new AzureSqlDatabaseImportExportBaseModel()
            {
                ResourceGroupName = ResourceGroupName,
                AdministratorLogin = AdministratorLogin,
                AdministratorLoginPassword = AdministratorLoginPassword,
                AuthenticationType = AuthenticationType,
                DatabaseName = DatabaseName,
                ServerName = ServerName,
                StorageKey = StorageKey,
                StorageKeyType = StorageKeyType,
                StorageUri = StorageUri
            };
            return exportRequest;
        }

        /// <summary>
        /// Creates a new export request
        /// </summary>
        /// <param name="entity">Import Request Model</param>
        /// <returns>Import Request Response</returns>
        protected override AzureSqlDatabaseImportExportBaseModel PersistChanges(AzureSqlDatabaseImportExportBaseModel entity)
        {
            return ModelAdapter.Export(entity);
        }

        /// <summary>
        /// Get the Firewall Rule to update
        /// </summary>
        /// <returns>The Firewall Rule being updated</returns>
        protected override Model.AzureSqlDatabaseImportExportBaseModel GetEntity()
        {
            return new AzureSqlDatabaseImportExportBaseModel();
        }
    }
}
