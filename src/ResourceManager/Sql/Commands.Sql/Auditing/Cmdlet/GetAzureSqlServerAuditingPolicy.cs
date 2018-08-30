﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.Sql.Auditing.Model;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Auditing.Cmdlet
{
    /// <summary>
    /// Returns the auditing policy of a specific database server.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlServerAuditingPolicy", SupportsShouldProcess = true), OutputType(typeof(AuditingPolicyModel))]
    [Alias("Get-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlDatabaseServerAuditingPolicy")]
    [Obsolete("Note that Table auditing is deprecated and this command will be removed in a future release. Please use the 'Get-AzureRmSqlServerAuditing' command to get Blob auditing settings.", false)]
    public class GetAzureSqlServerAuditingPolicy : SqlDatabaseServerAuditingCmdletBase
    {
        /// <summary>
        /// No sending is needed as this is a Get cmdlet
        /// </summary>
        /// <param name="model">The model object with the data to be sent to the REST endpoints</param>
        protected override AuditingPolicyModel PersistChanges(AuditingPolicyModel model)
        {
            return null;
        }
    }
}
