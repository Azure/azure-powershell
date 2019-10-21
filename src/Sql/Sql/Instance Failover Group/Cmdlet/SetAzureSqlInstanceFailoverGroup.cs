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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System;

namespace Microsoft.Azure.Commands.Sql.InstanceFailoverGroup.Cmdlet
{
    /// <summary>
    /// Cmdlet to create a new Instance Failover Group
    /// </summary>
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlDatabaseInstanceFailoverGroup", DefaultParameterSetName = SetIfgDefaultSet,
        SupportsShouldProcess = true), OutputType(typeof(AzureSqlInstanceFailoverGroupModel))]
    public class SetAzureSqlInstanceFailoverGroup : AzureSqlInstanceFailoverGroupCmdletBase
    {
        /// <summary>
        /// Parameter set name for the default set.
        /// </summary>
        private const string SetIfgDefaultSet = "SetInstanceFailoverGroupDefaultSet";

        /// <summary>
        /// Parameter set name for set with an Input Object.
        /// </summary>
        protected const string SetIfgByInputObjectSet =
            "SetInstanceFailoverGroupByAzureSqlInstanceFailoverGroupModelSet";

        /// <summary>
        /// Parameter set name for set with a resource ID.
        /// </summary>
        private const string SetIfgByResourceIdSet = "SetInstanceFailoverGroupByResourceIdSet";


        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(ParameterSetName = SetIfgDefaultSet,
            Mandatory = true,
            Position = 0,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the local region to use.
        /// </summary>
        [Parameter(ParameterSetName = SetIfgByResourceIdSet,
            Mandatory = true,
            Position = 1,
            HelpMessage = "The name of the Local Region from which to retrieve the Instance Failover Group.")]
        [Parameter(ParameterSetName = SetIfgDefaultSet,
            Mandatory = true,
            Position = 1,
            HelpMessage = "The name of the Local Region from which to retrieve the Instance Failover Group.")]
        [LocationCompleter("Microsoft.Sql/locations/instanceFailoverGroups")]
        [ValidateNotNullOrEmpty]
        public override string Location { get; set; }

        /// <summary>
        /// Gets or sets the name of the Instance Failover Group
        /// </summary>
        [Parameter(ParameterSetName = SetIfgDefaultSet, 
            Mandatory = true,
            Position = 2,
            HelpMessage = "The name of the Instance Failover Group.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
		/// Instance Failover Group object to set
		/// </summary>
		[Parameter(ParameterSetName = SetIfgByInputObjectSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = "The Instance Failover Group object to set")]
        [ValidateNotNullOrEmpty]
        public AzureSqlInstanceFailoverGroupModel InputObject { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the Instance Failover Group to set.
        /// </summary>
        [Parameter(ParameterSetName = SetIfgByResourceIdSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName  = true,
            HelpMessage = "The Resource ID of the Instance Failover Group to set.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the failover policy without data loss for the Sql Azure Instance Failover Group.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The failover policy of the Instance Failover Group.")]
        [ValidateNotNullOrEmpty]
        [PSDefaultValue(Help = "Automatic")]
        [PSArgumentCompleter("Automatic", "Manual")]
        public string FailoverPolicy { get; set; }

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
            HelpMessage = "Whether outages on the secondary server should trigger automatic failover of the read-only endpoint. This feature is not yet supported.")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Enabled", "Disabled")]
        public string AllowReadOnlyFailoverToPrimary { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlInstanceFailoverGroupModel> GetEntity()
        {
            if (InputObject != null)
            {
                Location = InputObject.Location;
                Name = InputObject.Name;
                ResourceGroupName = InputObject.ResourceGroupName;
            }
            else if (!string.IsNullOrWhiteSpace(ResourceId))
            {
                ResourceIdentifier identifier = new ResourceIdentifier(ResourceId);
                identifier = new ResourceIdentifier(identifier.ParentResource);
                Name = identifier.ResourceName;
                ResourceGroupName = identifier.ResourceGroupName;
            }

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
            object parameterValue;
            string effectivePolicy = FailoverPolicy;
            if (!MyInvocation.BoundParameters.ContainsKey("FailoverPolicy"))
            {
                // If none was provided, use the existing policy.
                effectivePolicy = newModel.ReadWriteFailoverPolicy;
            }

            int? gracePeriod = null;
            if (!effectivePolicy.Equals("Manual"))
            {
                int? setDefault = newModel.FailoverWithDataLossGracePeriodHours;
                if (setDefault.Equals(null))
                {
                    setDefault = 1;
                }
                gracePeriod = MyInvocation.BoundParameters.TryGetValue("GracePeriodWithDataLossHours", out parameterValue) ? (int)parameterValue : setDefault;
            }

            newModel.ReadWriteFailoverPolicy = effectivePolicy.ToString();
            newModel.FailoverWithDataLossGracePeriodHours = gracePeriod;
            newModel.ReadOnlyFailoverPolicy = MyInvocation.BoundParameters.ContainsKey("AllowReadOnlyFailoverToPrimary") ? AllowReadOnlyFailoverToPrimary : newModel.ReadOnlyFailoverPolicy;
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
