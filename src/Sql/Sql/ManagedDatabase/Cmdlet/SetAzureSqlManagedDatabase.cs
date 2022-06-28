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

using Microsoft.Azure.Commands.Sql.ManagedDatabase.Model;
using Microsoft.Azure.Commands.Sql.ManagedInstance.Model;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Rest.Azure;
using System.Management.Automation;
using System.Collections;

namespace Microsoft.Azure.Commands.Sql.ManagedDatabase.Cmdlet
{
    /// <summary>
    /// Cmdlet to create a new Azure Sql Managed Database
    /// </summary>
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceDatabase",
        DefaultParameterSetName = SetByNameAndResourceGroupParameterSet,
        SupportsShouldProcess = true),
        OutputType(typeof(AzureSqlManagedDatabaseModel))]
    public class SetAzureSqlManagedDatabase : AzureSqlManagedDatabaseCmdletBase<AzureSqlManagedDatabaseModel>
    {
        protected const string SetByNameAndResourceGroupParameterSet =
            "SetInstanceDatabaseFromInputParameters";

        protected const string SetByInputObjectParameterSet =
            "SetInstanceDatabaseFromAzureSqlManagedDatabaseModel";

        protected const string SetByParentObjectParameterSet =
            "SetInstanceDatabaseFromAzureSqlManagedInstanceModel";

        protected const string SetByResourceIdParameterSet =
            "SetInstanceDatabaseFromAzureResourceId";

        /// <summary>
        /// Gets or sets the name of the instance database to create.
        /// </summary>
        [Parameter(ParameterSetName = SetByNameAndResourceGroupParameterSet,
            Mandatory = true,
            Position = 0,
            HelpMessage = "The name of the managed instance database to update.")]
        [Parameter(ParameterSetName = SetByParentObjectParameterSet)]
        [Alias("InstanceDatabaseName")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances/databases", "ResourceGroupName", "InstanceName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the instance to use
        /// </summary>
        [Parameter(ParameterSetName = SetByNameAndResourceGroupParameterSet,
            Mandatory = true,
            Position = 1,
            HelpMessage = "The name of the managed instance.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(ParameterSetName = SetByNameAndResourceGroupParameterSet,
            Mandatory = true,
            Position = 2,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the tags associated with the instance database
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The tags to associate with the managed instance database")]
        [Alias("Tags")]
        public Hashtable Tag { get; set; }

        /// <summary>
        /// Gets or sets the instance object
        /// </summary>
        [Parameter(ParameterSetName = SetByInputObjectParameterSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = "The database object")]
        [ValidateNotNullOrEmpty]
        [Alias("DatabaseObject")]
        public AzureSqlManagedDatabaseModel InputObject { get; set; }

        /// <summary>
        /// Gets or sets the instance object
        /// </summary>
        [Parameter(ParameterSetName = SetByParentObjectParameterSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = "The managed instance object")]
        [ValidateNotNullOrEmpty]
        [Alias("ParentObject")]
        public AzureSqlManagedInstanceModel InstanceObject { get; set; }

        /// <summary>
        /// Gets or sets the resource id of the instance to get
        /// </summary>
        [Parameter(ParameterSetName = SetByResourceIdParameterSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The instance database resource id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override AzureSqlManagedDatabaseModel GetEntity()
        {
            switch(ParameterSetName)
            {
                case SetByInputObjectParameterSet:
                    ResourceGroupName = InputObject.ResourceGroupName;
                    InstanceName = InputObject.ManagedInstanceName;
                    Name = InputObject.Name;
                    break;
                case SetByResourceIdParameterSet:
                    var resourceInfo = new ResourceIdentifier(ResourceId);

                    ResourceGroupName = resourceInfo.ResourceGroupName;
                    InstanceName = resourceInfo.ParentResource.Substring(resourceInfo.ParentResource.LastIndexOf("/") + 1);
                    Name = resourceInfo.ResourceName;
                    break;
                case SetByParentObjectParameterSet:
                    ResourceGroupName = InstanceObject.ResourceGroupName;
                    InstanceName = InstanceObject.ManagedInstanceName;
                    break;
            }

            return ModelAdapter.GetManagedDatabase(ResourceGroupName, InstanceName, Name);
        }

        /// <summary>
        /// Create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override AzureSqlManagedDatabaseModel ApplyUserInputToModel(AzureSqlManagedDatabaseModel model)
        {
            string location = ModelAdapter.GetManagedInstanceLocation(ResourceGroupName, InstanceName);
            return new AzureSqlManagedDatabaseModel()
            {
                Location = location,
                ResourceGroupName = ResourceGroupName,
                ManagedInstanceName = InstanceName,
                Name = Name,
                Tags = TagsConversionHelper.CreateTagDictionary(Tag, validate: true),
            };
        }

        /// <summary>
        /// Create the new instance database
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override AzureSqlManagedDatabaseModel PersistChanges(AzureSqlManagedDatabaseModel entity)
        {
            return ModelAdapter.UpsertManagedDatabase(ResourceGroupName, InstanceName, entity);
        }
    }
}
