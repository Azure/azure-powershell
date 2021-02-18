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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
<<<<<<< HEAD
using Microsoft.Azure.Commands.Sql.ManagedInstance.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
=======
using Microsoft.Azure.Commands.Sql.Instance_Pools.Model;
using Microsoft.Azure.Commands.Sql.ManagedInstance.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ManagedInstance.Cmdlet
{
    /// <summary>
    /// Defines the Get-AzSqlInstance cmdlet
    /// </summary>
<<<<<<< HEAD
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstance"),
=======
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstance",
        DefaultParameterSetName = DefaultParameterSet),
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        OutputType(typeof(AzureSqlManagedInstanceModel))]
    public class GetAzureSqlManagedInstance : ManagedInstanceCmdletBase
    {
        /// <summary>
<<<<<<< HEAD
        /// Gets or sets the name of the instance.
        /// </summary>
        [Parameter(Mandatory = false,
            Position = 0,
=======
        /// Parameter sets
        /// </summary>
        protected const string DefaultParameterSet = "DefaultParameterSet";
        protected const string ListByInstancePoolParameterSet = "ListByInstancePoolParameterSet";
        protected const string ListByInstancePoolObjectParameterSet = "ListByInstancePoolObjectParameterSet";
        protected const string ListByInstancePoolResourceIdentifierParameterSet = "ListByInstancePoolResourceIdentiferParameterSet";
        protected const string GetByManagedInstanceResourceIdentifierParameterSet = "GetByManagedInstanceResourceIdentifierParameterSet";

        /// <summary>
        /// Gets or sets the instance pool parent object
        /// </summary>
        [Parameter(ParameterSetName = ListByInstancePoolObjectParameterSet,
            Mandatory = true,
            Position = 0,
            HelpMessage = "The instance pool parent object.",
            ValueFromPipeline = true)]
        [Alias("ParentObject")]
        public AzureSqlInstancePoolModel InstancePool { get; set; }

        /// <summary>
        /// Gets or sets the name of the instance pool resource identifier.
        /// </summary>
        [Parameter(ParameterSetName = ListByInstancePoolResourceIdentifierParameterSet,
            Mandatory = true,
            Position = 0,
            HelpMessage = "The instance pool resource identifier.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceIdCompleter("Microsoft.Sql/instancePools")]
        public string InstancePoolResourceId { get; set; }

        /// <summary>
        /// Gets or sets the managed instance resource id
        /// </summary>
        [Parameter(ParameterSetName = GetByManagedInstanceResourceIdentifierParameterSet,
            Mandatory = true,
            Position = 0,
            HelpMessage = "The managed instance resource identifier.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceIdCompleter("Microsoft.Sql/managedInstances")]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the name of the instance.
        /// </summary>
        [Parameter(
            ParameterSetName = DefaultParameterSet,
            Mandatory = false,
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            HelpMessage = "The name of the instance.")]
        [Alias("InstanceName")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Name { get; set; }

        /// <summary>
<<<<<<< HEAD
        /// Gets or sets the name of the resource group.
        /// </summary>
        [Parameter(Mandatory = false,
            Position = 1,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public override string ResourceGroupName { get; set; }

        /// <summary>
=======
        /// Gets or sets the name of the instance pool.
        /// </summary>
        [Parameter(
            ParameterSetName = ListByInstancePoolParameterSet,
            Position = 1,
            Mandatory = true,
            HelpMessage = "The name of the instance pool.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Sql/instancePools", "ResourceGroupName")]
        [SupportsWildcards]
        public string InstancePoolName { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group.
        /// </summary>
        [Parameter(ParameterSetName = DefaultParameterSet,
            Mandatory = false,
            HelpMessage = "The name of the resource group.")]
        [Parameter(ParameterSetName = ListByInstancePoolParameterSet,
            Mandatory = true,
            Position = 0,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.InstancePool))
            {
                this.ResourceGroupName = this.InstancePool.ResourceGroupName;
                this.InstancePoolName = this.InstancePool.InstancePoolName;
            }

            if (this.IsParameterBound(c => c.InstancePoolResourceId))
            {
                var resourceId = new ResourceIdentifier(this.InstancePoolResourceId);
                this.ResourceGroupName = resourceId.ResourceGroupName;
                this.InstancePoolName = resourceId.ResourceName;
            }

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceId = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceId.ResourceGroupName;
                this.Name = resourceId.ResourceName;
            }

            base.ExecuteCmdlet();
        }

        /// <summary>
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        /// Gets an instance from the service.
        /// </summary>
        /// <returns>A single server</returns>
        protected override IEnumerable<AzureSqlManagedInstanceModel> GetEntity()
        {
<<<<<<< HEAD
            ICollection<AzureSqlManagedInstanceModel> results = null;
=======
            ICollection<AzureSqlManagedInstanceModel> results = new List<AzureSqlManagedInstanceModel>();
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

            if (ShouldGetByName(ResourceGroupName, Name))
            {
                results = new List<AzureSqlManagedInstanceModel>();
                results.Add(ModelAdapter.GetManagedInstance(this.ResourceGroupName, this.Name));
            }
            else if (ShouldListByResourceGroup(ResourceGroupName, Name))
            {
<<<<<<< HEAD
                results = ModelAdapter.ListManagedInstancesByResourceGroup(this.ResourceGroupName);
=======
                if (this.InstancePoolName != null)
                {
                    results = ModelAdapter.ListManagedInstancesByInstancePool(this.ResourceGroupName, this.InstancePoolName);
                }
                else
                {
                    results = ModelAdapter.ListManagedInstancesByResourceGroup(this.ResourceGroupName);
                }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            }
            else
            {
                results = ModelAdapter.ListManagedInstances();
            }

            return TopLevelWildcardFilter(ResourceGroupName, Name, results);
        }

        /// <summary>
        /// No changes, thus nothing to persist.
        /// </summary>
        /// <param name="entity">The entity retrieved</param>
        /// <returns>The unchanged entity</returns>
        protected override IEnumerable<AzureSqlManagedInstanceModel> PersistChanges(IEnumerable<AzureSqlManagedInstanceModel> entity)
        {
            return entity;
        }

        /// <summary>
        /// No user input to apply to model.
        /// </summary>
        /// <param name="model">The model to modify</param>
        /// <returns>The input model</returns>
        protected override IEnumerable<AzureSqlManagedInstanceModel> ApplyUserInputToModel(IEnumerable<AzureSqlManagedInstanceModel> model)
        {
            return model;
        }
    }
}
