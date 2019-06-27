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
using Microsoft.Azure.Commands.Sql.InstanceFailoverGroup.Model;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.InstanceFailoverGroup.Services;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Sql.InstanceFailoverGroup.Cmdlet
{
    [Cmdlet(VerbsCommon.Switch, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlDatabaseInstanceFailoverGroup",
        DefaultParameterSetName = SwitchIfgDefaultSet,
        SupportsShouldProcess = true),
        OutputType(typeof(AzureSqlInstanceFailoverGroupModel))]
    public class SwitchAzureSqlInstanceFailoverGroup : AzureSqlInstanceFailoverGroupCmdletBase
    {
        /// <summary>
        /// Parameter set name for the default switch.
        /// </summary>
        private const string SwitchIfgDefaultSet = "SwitchInstanceFailoverGroupDefaultSet";

        /// <summary>
        /// Parameter set name for switch with an Input Object.
        /// </summary>
        protected const string SwitchIfgByInputObjectParameterSet =
            "SwitchInstanceFailoverGroupByInputObjectSet";
        
        /// <summary>
        /// Parameter set name for switch with a resource ID.
        /// </summary>
        private const string SwitchIfgByResourceIdSet = "SwitchInstanceFailoverGroupByResourceIdSet";
        
        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(ParameterSetName = SwitchIfgDefaultSet,
            Mandatory = true,
            Position = 0,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the local region to use.
        /// </summary>
        [Parameter(ParameterSetName = SwitchIfgByResourceIdSet,
            Mandatory = true,
            Position = 1,
            HelpMessage = "The name of the Local Region from which to retrieve the Instance Failover Group.")]
        [Parameter(ParameterSetName = SwitchIfgDefaultSet,
            Mandatory = true,
            Position = 1,
            HelpMessage = "The name of the Local Region from which to retrieve the Instance Failover Group.")]
        [LocationCompleter("Microsoft.Sql/locations/instanceFailoverGroups")]
        [ValidateNotNullOrEmpty]
        public override string Location { get; set; }

        /// <summary>
        /// Gets or sets the name of the InstanceFailoverGroup to use.
        /// </summary>
        [Parameter(ParameterSetName = SwitchIfgDefaultSet, 
            Mandatory = true,
            Position = 2,
            HelpMessage = "The name of the Instance Failover Group.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Instance Failover Group object to switch
        /// </summary>
        [Parameter(ParameterSetName = SwitchIfgByInputObjectParameterSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = "The Instance Failover Group object to switch")]
        [ValidateNotNullOrEmpty]
        public Model.AzureSqlInstanceFailoverGroupModel InputObject { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the Instance Failover Group to switch.
        /// </summary>
        [Parameter(ParameterSetName = SwitchIfgByResourceIdSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Resource ID of the Instance Failover Group that will become the new Primary.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Switch parameter indicating whether this failover operation will allow data loss or not.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Complete the failover even if doing so may result in data loss. "
                + "This will allow the failover to proceed even if a primary database is unavailable.")]
        public SwitchParameter AllowDataLoss { get; set; }

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
        /// No user input to apply to model
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlInstanceFailoverGroupModel> ApplyUserInputToModel(IEnumerable<AzureSqlInstanceFailoverGroupModel> model)
        {
            return model;
        }

        /// <summary>
        /// Issue the failover operation
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlInstanceFailoverGroupModel> PersistChanges(IEnumerable<AzureSqlInstanceFailoverGroupModel> entity)
        {
            return new List<AzureSqlInstanceFailoverGroupModel>() {
                ModelAdapter.Failover(
                    this.ResourceGroupName,
                    this.Location,
                    this.Name,
                    this.AllowDataLoss.IsPresent)
           };
        }
    }
}
