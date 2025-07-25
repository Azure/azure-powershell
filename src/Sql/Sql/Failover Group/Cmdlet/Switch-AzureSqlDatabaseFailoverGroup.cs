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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.FailoverGroup.Model;
using Microsoft.Azure.Commands.Sql.FailoverGroup.Services;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.FailoverGroup.Cmdlet
{
    [Cmdlet("Switch", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlDatabaseFailoverGroup",ConfirmImpact = ConfirmImpact.Medium, SupportsShouldProcess = true), OutputType(typeof(AzureSqlFailoverGroupModel))]
    public class SwitchAzureSqlFailoverGroup : AzureSqlFailoverGroupCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the server to use.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "The name of the secondary Azure SQL Database Server of the Failover Group.")]
        [ResourceNameCompleter("Microsoft.Sql/servers", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the FailoverGroup to use.
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The name of the Azure SQL Database Failover Group.")]
        [ValidateNotNullOrEmpty]
        public string FailoverGroupName { get; set; }

        /// <summary>
        /// Switch parameter indicating whether this failover operation will allow data loss or not.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Complete the failover even if doing so may result in data loss. "
                + "This will allow the failover to proceed even if a primary database is unavailable.")]
        public SwitchParameter AllowDataLoss { get; set; }

        /// <summary>
        /// Switch parameter indicating whether this failover operation will try planned before forced failover.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Performs planned failover as first step and if it fails for any reason then forced failover with potential data loss is initiated. "
                + "This will allow the failover to proceed even if a primary database is unavailable.")]
        public SwitchParameter TryPlannedBeforeForcedFailover { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlFailoverGroupModel> GetEntity()
        {
            return new List<AzureSqlFailoverGroupModel>() {
                ModelAdapter.GetFailoverGroup(this.ResourceGroupName, this.ServerName, this.FailoverGroupName)
            };
        }

        /// <summary>
        /// No user input to apply to model
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlFailoverGroupModel> ApplyUserInputToModel(IEnumerable<AzureSqlFailoverGroupModel> model)
        {
            return model;
        }

        /// <summary>
        /// Issue the failover operation
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlFailoverGroupModel> PersistChanges(IEnumerable<AzureSqlFailoverGroupModel> entity)
        {
            return new List<AzureSqlFailoverGroupModel>() {
                ModelAdapter.Failover(
                    this.ResourceGroupName,
                    this.ServerName,
                    this.FailoverGroupName,
                    this.AllowDataLoss.IsPresent,
                    this.TryPlannedBeforeForcedFailover.IsPresent)
           };
        }
    }
}
