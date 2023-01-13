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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.Sql.ImportExport.Model;
using Microsoft.Azure.Commands.Sql.ImportExport.Service;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ImportExport.Cmdlet
{
    /// <summary>
    /// Defines the AzureRmSqlDatabaseImportExportStatus cmdlet
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlDatabaseImportExportStatus", SupportsShouldProcess = true)]
    [OutputType(typeof(AzureSqlDatabaseImportExportStatusModel))]
    public class GetAzureSqlDatabaseImportExportStatus : AzureRMCmdlet
    {
        /// <summary>
        /// Gets or sets the operation status link
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The operation status link to get the status of import/export operation.")]
        public string OperationStatusLink
        {
            get;
            set;
        }

        /// <summary>
        /// The ModelAdapter object used by this cmdlet
        /// </summary>
        public ImportExportDatabaseAdapter ModelAdapter
        {
            get; internal set;
        }

        /// <summary>
        /// Get the import/export operation status
        /// </summary>
        /// <returns>The Firewall Rule being updated</returns>
        protected AzureSqlDatabaseImportExportStatusModel GetEntity()
        {
            return ModelAdapter.GetStatus(OperationStatusLink);
        }

        /// <summary>
        /// Intializes the model adapter
        /// </summary>
        /// <returns>The server adapter</returns>
        protected ImportExportDatabaseAdapter InitModelAdapter()
        {
            return new ImportExportDatabaseAdapter(DefaultProfile.DefaultContext);
        }

        /// <summary>
        /// Executes the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            ModelAdapter = InitModelAdapter();
            AzureSqlDatabaseImportExportStatusModel model = GetEntity();

            if (model != null)
            {
                this.WriteObject(model, true);
            }
        }
    }
}
