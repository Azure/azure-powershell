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

using Hyak.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Sql.FailoverGroup.Model;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System;

namespace Microsoft.Azure.Commands.Sql.FailoverGroup.Cmdlet
{
    /// <summary>
    /// Cmdlet to create a new Azure Sql FailoverGroup
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmSqlDatabaseFailoverGroup")]
    public class NewAzureSqlFailoverGroup : AzureSqlFailoverGroupCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the server to use.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "The name of the primary Azure SQL Database Server of the Failover Group.")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the Failover Group to create.
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The name of the Azure SQL Database Failover Group to create.")]
        [ValidateNotNullOrEmpty]
        public string FailoverGroupName { get; set; }

        /// <summary>
        /// Gets or sets the partner resource group name for Azure SQL Database Failover Group
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The name of the secondary resource group of the Azure SQL Database Failover Group.")]
        [ValidateNotNullOrEmpty]
        public string PartnerResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the partner server name for Azure SQL Database Failover Group
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The name of the secondary server of the Azure SQL Database Failover Group.")]
        [ValidateNotNullOrEmpty]
        public string PartnerServerName { get; set; }

        /// <summary>
        /// Gets or sets the failover policy without data loss for the Sql Azure Failover Group.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The failover policy of the Azure SQL Database Failover Group.")]
        [ValidateNotNullOrEmpty]
        [PSDefaultValue(Help = "Automatic")]
        public FailoverPolicy FailoverPolicy { get; set; }

        /// <summary>
        /// Gets or sets the grace period with data loss for the Sql Azure Failover Group.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Interval before automatic failover is initiated if an outage occurs on the primary server and failover cannot be completed without data loss.")]
        [ValidateNotNullOrEmpty]
        [ValidateRange(0, int.MaxValue)]
        [PSDefaultValue(Help = "1")]
        public int GracePeriodWithDataLossHours { get; set; }

        /// <summary>
        /// Gets or sets the failover policy for read only endpoint of the Sql Azure Failover Group.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Whether an outage on the secondary server should trigger automatic failover of the read-only endpoint. This feature is not yet supported.")]
        [ValidateNotNullOrEmpty]
        public AllowReadOnlyFailoverToPrimary AllowReadOnlyFailoverToPrimary { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlFailoverGroupModel> GetEntity()
        {
            // We try to get the failover group.  Since this is a create, we don't want the failover group to exist
            try
            {
                ModelAdapter.GetFailoverGroup(this.ResourceGroupName, this.ServerName, this.FailoverGroupName);
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // This is what we want.  We looked and there is no Failover Group with this name.
                    return null;
                }

                // Unexpected exception encountered
                throw;
            }

            // The Failover Group already exists
            throw new PSArgumentException(string.Format(Properties.Resources.FailoverGroupNameExists, this.FailoverGroupName, this.ServerName), "FailoverGroupName");
        }

        /// <summary>
        /// Create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlFailoverGroupModel> ApplyUserInputToModel(IEnumerable<AzureSqlFailoverGroupModel> model)
        {
            string location = ModelAdapter.GetServerLocation(ResourceGroupName, ServerName);
            List<AzureSqlFailoverGroupModel> newEntity = new List<AzureSqlFailoverGroupModel>();
            newEntity.Add(new AzureSqlFailoverGroupModel()
            {
                ResourceGroupName = ResourceGroupName,
                ServerName = ServerName,
                Location = location,
                FailoverGroupName = FailoverGroupName,
                PartnerResourceGroupName = MyInvocation.BoundParameters.ContainsKey("PartnerResourceGroupName") ? PartnerResourceGroupName : ResourceGroupName,
                PartnerServerName = PartnerServerName,
                ReadWriteFailoverPolicy = FailoverPolicy.ToString(),
                FailoverWithDataLossGracePeriodHours = ComputeEffectiveGracePeriod(FailoverPolicy, originalGracePeriod: null),
                ReadOnlyFailoverPolicy = MyInvocation.BoundParameters.ContainsKey("AllowReadOnlyFailoverToPrimary") ? AllowReadOnlyFailoverToPrimary.ToString() : AllowReadOnlyFailoverToPrimary.Disabled.ToString(),
            });
            return newEntity;
        }

        /// <summary>
        /// Create the new Failover Group
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlFailoverGroupModel> PersistChanges(IEnumerable<AzureSqlFailoverGroupModel> entity)
        {
            return new List<AzureSqlFailoverGroupModel>() {
                ModelAdapter.UpsertFailoverGroup(entity.First())
            };
        }
    }
}
