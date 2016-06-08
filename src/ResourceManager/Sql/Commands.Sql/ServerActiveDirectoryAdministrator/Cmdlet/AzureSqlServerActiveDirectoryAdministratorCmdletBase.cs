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
using Microsoft.Azure.Commands.Sql.ServerActiveDirectoryAdministrator.Model;
using Microsoft.Azure.Commands.Sql.ServerActiveDirectoryAdministrator.Services;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ServerActiveDirectoryAdministrator.Cmdlet
{
    public abstract class AzureSqlServerActiveDirectoryAdministratorCmdletBase : AzureSqlCmdletBase<IEnumerable<AzureSqlServerActiveDirectoryAdministratorModel>, AzureSqlServerActiveDirectoryAdministratorAdapter>
    {
        /// <summary>
        /// Gets or sets the name of the Azure SQL Server that contains the Azure Active Directory administrator.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "The name of the Azure SQL Server the Azure Active Directory administrator is in.")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Initializes the adapter
        /// </summary>
        /// <param name="subscription"></param>
        /// <returns></returns>
        protected override AzureSqlServerActiveDirectoryAdministratorAdapter InitModelAdapter(AzureSubscription subscription)
        {
            return new AzureSqlServerActiveDirectoryAdministratorAdapter(DefaultProfile.Context);
        }
    }
}
