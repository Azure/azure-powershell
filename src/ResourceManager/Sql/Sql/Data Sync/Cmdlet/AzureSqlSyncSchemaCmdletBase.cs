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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Sql.DataSync.Model;
using Microsoft.Azure.Commands.Sql.DataSync.Services;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.Sql.DataSync.Cmdlet
{
    /// <summary>
    /// The base class for cmdlets that get full schema of hub and member database of a sync member 
    /// </summary>
    public abstract class AzureSqlSyncSchemaCmdletBase : AzureSqlDatabaseCmdletBase<IEnumerable<AzureSqlSyncFullSchemaModel>, AzureSqlDataSyncAdapter>
    {
        /// <summary>
        /// Gets or sets the sync group name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "The sync group name.")]
        [ValidateNotNullOrEmpty]
        public string SyncGroupName { get; set; }
        
        /// <summary>
        /// Gets or sets the sync member name
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The sync member name.")]
        public string SyncMemberName { get; set; }

        /// <summary>
        /// Creation and initialization of the ModelAdapter object
        /// </summary>
        /// <param name="subscription">The Azure Subscription in which the current execution is performed</param>
        /// <returns>An initialized and ready to use ModelAdapter object</returns>
        protected override AzureSqlDataSyncAdapter InitModelAdapter(IAzureSubscription subscription)
        {
            return new AzureSqlDataSyncAdapter(DefaultProfile.DefaultContext);
        }
    }
}
