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
using Microsoft.Azure.Commands.Sql.InstanceFailoverGroup.Model;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System;
using Microsoft.Azure.Management.Sql.Models;

namespace Microsoft.Azure.Commands.Sql.InstanceFailoverGroup.Cmdlet
{
    /// <summary>
    /// Cmdlet to create a new Azure Sql InstanceFailoverGroup
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmSqlDatabaseInstanceFailoverGroup",
        SupportsShouldProcess = true), OutputType(typeof(AzureSqlInstanceFailoverGroupModel))]
    public class NewAzureSqlInstanceFailoverGroup : AzureSqlInstanceFailoverGroupCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the local region to use.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "The name of the Local Region on which to create the Instance Failover Group.")]
        [LocationCompleter("Microsoft.Sql/locations/instanceFailoverGroups")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the name of the Instance Failover Group to create.
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The name of the Azure SQL Database Failover Group to create.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the partner resource group name for Azure SQL Database Instance Failover Group
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The name of the secondary resource group of the Azure SQL Database Instance Failover Group.")]
        [ValidateNotNullOrEmpty]
        public string PartnerResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the partner region for Azure SQL Database Instance Failover Group
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The name of the secondary server of the Azure SQL Database Instance Failover Group.")]
        [ValidateNotNullOrEmpty]
        public string PartnerRegion { get; set; }
        
        /// <summary>
        /// Gets or sets the name of the Managed Instance on the local region
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The name of the Managed Instance on the local region to be added to the Azure SQL Database Instance Failover Group.")]
        [ValidateNotNullOrEmpty]
        public string PrimaryManagedInstanceName { get; set; }
        
        /// <summary>
        /// Gets or sets the name of the Managed Instance on the partner region
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The name of the Managed Instance on the partner region to be added to the Azure SQL Database Instance Failover Group.")]
        [ValidateNotNullOrEmpty]
        public string PartnerManagedInstanceName { get; set; }

        /// <summary>
        /// Gets or sets the failover policy without data loss for the Sql Azure Instance Failover Group.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The failover policy of the Azure SQL Database Instance Failover Group.")]
        [ValidateNotNullOrEmpty]
        [PSDefaultValue(Help = "Automatic")]
        public FailoverPolicy FailoverPolicy { get; set; }

        /// <summary>
        /// Gets or sets the grace period with data loss for the Sql Azure Instance Failover Group.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Interval before automatic failover is initiated if an outage occurs on the primary server and failover cannot be completed without data loss.")]
        [ValidateNotNullOrEmpty]
        [ValidateRange(1, int.MaxValue/60)]
        [PSDefaultValue(Help = "1")]
        public int GracePeriodWithDataLossHours { get; set; }

        /// <summary>
        /// Gets or sets the failover policy for read only endpoint of the Sql Azure Instance Failover Group.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Whether an outage on the secondary server should trigger automatic failover of the read-only endpoint. This feature is not yet supported.")]
        [ValidateNotNullOrEmpty]
        public AllowReadOnlyFailoverToPrimary AllowReadOnlyFailoverToPrimary { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlInstanceFailoverGroupModel> GetEntity()
        {
            // We try to get the failover group.  Since this is a create, we don't want the failover group to exist
            try
            {
                ModelAdapter.GetInstanceFailoverGroup(this.ResourceGroupName, this.Location, this.Name);
            }
            catch
            {
                return null; 
            }

            // The Failover Group already exists
            throw new PSArgumentException(string.Format(Properties.Resources.FailoverGroupNameExists, this.Name, this.Location), "FailoverGroupName");
        }

        /// <summary>
        /// Create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlInstanceFailoverGroupModel> ApplyUserInputToModel(IEnumerable<AzureSqlInstanceFailoverGroupModel> model)
        {
            string location = Location;
            List<AzureSqlInstanceFailoverGroupModel> newEntity = new List<AzureSqlInstanceFailoverGroupModel>();
            object parameterValue;

            int? gracePeriod = null;
            if (!FailoverPolicy.ToString().Equals("Manual"))
            {
                gracePeriod = (MyInvocation.BoundParameters.TryGetValue("GracePeriodWithDataLossHours", out parameterValue) ? (int)parameterValue : 1);
            }                     

            newEntity.Add(new AzureSqlInstanceFailoverGroupModel()
            {
                ResourceGroupName = ResourceGroupName,
                Location = Location,
                Name = Name,
                PartnerResourceGroupName = MyInvocation.BoundParameters.ContainsKey("PartnerResourceGroupName") ? PartnerResourceGroupName : ResourceGroupName,
                PartnerRegion = new PartnerRegionInfo(location = PartnerRegion),
                PrimaryManagedInstanceName = PrimaryManagedInstanceName,
                PartnerManagedInstanceName = PartnerManagedInstanceName,
                ReadWriteFailoverPolicy = FailoverPolicy.ToString(),
                FailoverWithDataLossGracePeriodHours = gracePeriod,
                ReadOnlyFailoverPolicy = MyInvocation.BoundParameters.ContainsKey("AllowReadOnlyFailoverToPrimary") ? AllowReadOnlyFailoverToPrimary.ToString() : AllowReadOnlyFailoverToPrimary.Disabled.ToString(),
            });
            return newEntity;
        }

        /// <summary>
        /// Create the new Instance Failover Group
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlInstanceFailoverGroupModel> PersistChanges(IEnumerable<AzureSqlInstanceFailoverGroupModel> entity)
        {
            return new List<AzureSqlInstanceFailoverGroupModel>() {
                ModelAdapter.UpsertInstanceFailoverGroup(entity.First())
            };
        }
    }
}
