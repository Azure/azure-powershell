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

using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.ImportExport.Model;
using Microsoft.Azure.Commands.Sql.ImportExport.Service;
using System;
using System.Management.Automation;
using System.Security;

namespace Microsoft.Azure.Commands.Sql.ImportExport.Cmdlet
{
    public abstract class ImportExportCmdletBase : AzureSqlCmdletBase<AzureSqlDatabaseImportExportBaseModel, ImportExportDatabaseAdapter>
    {
        /// <summary>
        /// Gets or sets the name of the database server to use.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "SQL Database server name.")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the type of the storage key to use.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The type of the storage key")]
        [ValidateNotNullOrEmpty]
        public StorageKeyType StorageKeyType
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the storage key to use.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The storage key")]
        [ValidateNotNullOrEmpty]
        public string StorageKey
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the blob URI of the .bacpac file
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The blob URI of the .bacpac file")]
        [ValidateNotNullOrEmpty]
        public Uri StorageUri
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the name of the SQL administrator
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The Azure SQL Server administrator login username")]
        [ValidateNotNullOrEmpty]
        public string AdministratorLogin
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the password of the SQL administrator
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The Azure SQL Server administrator password")]
        [ValidateNotNullOrEmpty]
        public SecureString AdministratorLoginPassword
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the authentication type
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The authentication type of the SQL administrator. Only available in the latest SQL Database version (V12). Default is Sql")]
        public AuthenticationType AuthenticationType
        {
            get; set;
        }

        /// <summary>
        /// Intializes the model adapter
        /// </summary>
        /// <param name="subscription">The subscription the cmdlets are operation under</param>
        /// <returns>The server adapter</returns>
        protected override ImportExportDatabaseAdapter InitModelAdapter(AzureSubscription subscription)
        {
            return new ImportExportDatabaseAdapter(DefaultProfile.Context);
        }
    }
}
