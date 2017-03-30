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
using Microsoft.Azure.Management.Sql.Models;
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
        /// Gets or sets the name of the Failover Group to create.
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The name of the Azure SQL FailoverGroup to create.")]
        [ValidateNotNullOrEmpty]
        public string FailoverGroupName { get; set; }

        /// <summary>
        /// Gets or sets the partner resource group name for Azure SQL Database Failover Group
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The partner resource group name for Azure SQL Database Failover Group.")]
        [ValidateNotNullOrEmpty]
        public string PartnerResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the partner server name for Azure SQL Database Failover Group
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The partner server name for Azure SQL Database Failover Group.")]
        [ValidateNotNullOrEmpty]
        public string PartnerServerName { get; set; }

        /// <summary>
        /// Gets or sets the failover policy without data loss for the Sql Azure Failover Group.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The failover policy without data loss for the failover group.")]
        [ValidateNotNullOrEmpty]
        public FailoverPolicy FailoverPolicy { get; set; }

        /// <summary>
        /// Gets or sets the grace period with data loss for the Sql Azure Failover Group.
        /// </summary>
        [Alias("GracePeriodWithDataLossHour")]
        [Parameter(Mandatory = false,
            HelpMessage = "The window of grace period that we tolerate with data loss during a failover operation for the failover group.")]
        [Obsolete("This parameter is only for backwards compatibility; User should use 'GracePeriodWithDataLossHour' instead.")]
        [ValidateNotNullOrEmpty]
        public int GracePeriodWithDataLossHours { get; set; }

        /// <summary>
        /// Gets or sets the failover policy for read only endpoint of theSql Azure Failover Group.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The failover policy for read only endpoint of the failover group.")]
        [ValidateNotNullOrEmpty]
        public AllowReadOnlyFailoverToPrimary AllowReadOnlyFailoverToPrimary { get; set; }

        /// <summary> 
        /// Gets or sets the tags associated with the Azure SQL Database Failover Group 
        /// </summary> 
        [Parameter(Mandatory = false,
            HelpMessage = "The tags to associate with the Azure SQL Database Failover Group")]
        [Obsolete("This parameter is only for backwards compatibility; User should not need to pass in this parameter.")]
        public Hashtable Tag { get; set; }

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
                    // This is what we want.  We looked and there is no database with this name.
                    return null;
                }

                // Unexpected exception encountered
                throw;
            }

            // The database already exists
            throw new PSArgumentException(
                string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.FailoverGroupNameExists, this.FailoverGroupName, this.ServerName),
                "FailoverGroupName");
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

            newEntity.Add(new AzureSqlFailoverGroupInputModel()
            {
                ResourceGroupName = ResourceGroupName,
                ServerName = ServerName,
                Location = location,
                FailoverGroupName = FailoverGroupName,
                PartnerResourceGroupName = MyInvocation.BoundParameters.ContainsKey("PartnerResourceGroupName") ? PartnerResourceGroupName : ResourceGroupName,
                PartnerServerName = PartnerServerName,
                ReadWriteFailoverPolicy = FailoverPolicy.ToString(),
#pragma warning disable 0618
                FailoverWithDataLossGracePeriodHours = GracePeriodWithDataLossHours,
                ReadOnlyFailoverPolicy = AllowReadOnlyFailoverToPrimary.ToString()
#pragma warning restore 0618
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
                ModelAdapter.UpsertFailoverGroup(entity.First() as AzureSqlFailoverGroupInputModel)
            };
        }
    }
}
