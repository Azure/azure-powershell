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


using Microsoft.Azure.Commands.Sql.InstanceFailoverGroup.Model;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System;

namespace Microsoft.Azure.Commands.Sql.InstanceFailoverGroup.Cmdlet
{
    /// <summary>
    /// Cmdlet to create a new Azure Sql Database Instance Failover Group
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmSqlDatabaseInstanceFailoverGroup",
        ConfirmImpact = ConfirmImpact.Medium)]
    public class SetAzureSqlInstanceFailoverGroup : AzureSqlInstanceFailoverGroupCmdletBase
    {
        /// <summary>
        /// Parameter set name for set with an Input Object.
        /// </summary>
        protected const string SetIFGByInputObjectParameterSet =
            "Set a Instance Failover Group from AzureSqlInstanceFailoverGroupModel instance definition";

        /// <summary>
        /// Parameter set name for set with a resource ID.
        /// </summary>
        private const string SetIFGByResourceIdSet = "Set a Instance Failover Group from Resource Id";

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(Mandatory = false,
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
            HelpMessage = "The name of the Local Region from which to retrieve the Instance Failover Group.")]
        [LocationCompleter]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the name of the Azure SQL Database Instance Failover Group
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The name of the Azure SQL Database Instance Failover Group.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
		/// Instance Failover Group object to set
		/// </summary>
		[Parameter(ParameterSetName = SetIFGByInputObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The Instance Failover Group object to set")]
        [ValidateNotNullOrEmpty]
        public Model.AzureSqlInstanceFailoverGroupModel InputObject { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the Instance Failover Group to set.
        /// </summary>
        [Parameter(ParameterSetName = SetIFGByResourceIdSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Resource ID of the Instance Failover Group to set.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

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
        [ValidateRange(0, int.MaxValue)]
        [PSDefaultValue(Help = "1")]
        public int GracePeriodWithDataLossHours { get; set; }

        /// <summary>
        /// Gets or sets the failover policy for read only endpoint of the Sql Azure Instance Failover Group.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Whether outages on the secondary server should trigger automatic failover of the read-only endpoint. This feature is not yet supported.")]
        [ValidateNotNullOrEmpty]
        public AllowReadOnlyFailoverToPrimary AllowReadOnlyFailoverToPrimary { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlInstanceFailoverGroupModel> GetEntity()
        {
            return new List<AzureSqlInstanceFailoverGroupModel>() {
                ModelAdapter.GetInstanceFailoverGroup(this.ResourceGroupName, this.Location, this.Name)
            };
        }

        /// <summary>
        /// Create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlInstanceFailoverGroupModel> ApplyUserInputToModel(IEnumerable<AzureSqlInstanceFailoverGroupModel> model)
        {
            List<AzureSqlInstanceFailoverGroupModel> newEntity = new List<AzureSqlInstanceFailoverGroupModel>();
            AzureSqlInstanceFailoverGroupModel newModel = model.First();

            FailoverPolicy effectivePolicy = FailoverPolicy;
            if (!MyInvocation.BoundParameters.ContainsKey("FailoverPolicy"))
            {
                // If none was provided, use the existing policy.
                Enum.TryParse(newModel.ReadWriteFailoverPolicy, out effectivePolicy);
            }

            newModel.ReadWriteFailoverPolicy = effectivePolicy.ToString();
            newModel.FailoverWithDataLossGracePeriodHours = ComputeEffectiveGracePeriod(effectivePolicy, originalGracePeriod: newModel.FailoverWithDataLossGracePeriodHours);
            newModel.ReadOnlyFailoverPolicy = MyInvocation.BoundParameters.ContainsKey("AllowReadOnlyFailoverToPrimary") ? AllowReadOnlyFailoverToPrimary.ToString() : newModel.ReadOnlyFailoverPolicy;
            newEntity.Add(newModel);

            return newEntity;
        }

        /// <summary>
        /// Update the Failover Group
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
