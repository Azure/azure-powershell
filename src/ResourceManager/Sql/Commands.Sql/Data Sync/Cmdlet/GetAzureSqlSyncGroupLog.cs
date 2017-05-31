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
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.DataSync.Model;
using Microsoft.Azure.Commands.Sql.DataSync.Services;
using Microsoft.Azure.Management.Sql.LegacySdk.Models;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.Sql.DataSync.Cmdlet
{
    /// <summary>
    /// Cmdlet to get synchronization log of  a specified sync group
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmSqlSyncGroupLog", SupportsShouldProcess = true,
        ConfirmImpact = ConfirmImpact.None)]
    public class GetAzureSqlSyncGroupLog : AzureSqlDatabaseCmdletBase<IEnumerable<AzureSqlSyncGroupLogModel>, AzureSqlDataSyncAdapter>
    {
        /// <summary>
        /// Gets or sets the sync group name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The sync group name.")]
        [ValidateNotNullOrEmpty]
        public string SyncGroupName { get; set; }

        /// <summary>
        /// Gets or sets the start time of logs to query
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The start time of the logs to query.")]
        [ValidateNotNullOrEmpty]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time of logs to query
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The end time of the logs to query.")]
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Gets or sets the type of logs to query
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The type of the logs to query. Valid values are: " 
            + "'Error', 'Warning', 'Success' and 'All'.")]
        [ValidateSet("Error", "Warning", "Success", "All", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string Type { get; set; }

        /// <summary>
        /// Creation and initialization of the ModelAdapter object
        /// </summary>
        /// <param name="subscription">The Azure Subscription in which the current execution is performed</param>
        /// <returns>An initialized and ready to use ModelAdapter object</returns>
        protected override AzureSqlDataSyncAdapter InitModelAdapter(IAzureSubscription subscription)
        {
            return new AzureSqlDataSyncAdapter(DefaultProfile.DefaultContext);
        }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlSyncGroupLogModel> GetEntity()
        {
            return ModelAdapter.ListSyncGroupLogs(this.ResourceGroupName, this.ServerName, this.DatabaseName, new SyncGroupLogGetParameters
            {
                SyncGroupName = this.SyncGroupName,
                StartTime = this.StartTime.ToString(),
                EndTime = MyInvocation.BoundParameters.ContainsKey("EndTime") ? this.EndTime.ToString() : DateTime.Now.ToString(),
                Type = MyInvocation.BoundParameters.ContainsKey("Type") ? this.Type : LogType.All.ToString()
            });
        }

        /// <summary>
        /// No changes to persist to server
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlSyncGroupLogModel> PersistChanges(IEnumerable<AzureSqlSyncGroupLogModel> entity)
        {
            return entity;
        }
    }
}
