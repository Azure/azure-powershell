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
using Microsoft.Azure.Commands.Sql.Replication.Model;
using Microsoft.Azure.Commands.Sql.ReplicationLink.Services;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Replication.Cmdlet
{
    public abstract class AzureSqlDatabaseCopyCmdletBase : AzureSqlCmdletBase<IEnumerable<AzureSqlDatabaseCopyModel>, AzureSqlDatabaseReplicationAdapter>
    {
        /// <summary>
        /// Gets or sets the name of the Azure SQL Server to use.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "The name of the Azure SQL Server the database to be copied is in.")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Initializes the adapter
        /// </summary>
        /// <param name="subscription">The Azure Subscription</param>
        /// <returns>A replication Adapter object</returns>
        protected override AzureSqlDatabaseReplicationAdapter InitModelAdapter(AzureSubscription subscription)
        {
            return new AzureSqlDatabaseReplicationAdapter(DefaultProfile.Context);
        }
    }
}
