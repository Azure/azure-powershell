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
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceDatabase",
        DefaultParameterSetName = CreateNewByNameAndResourceGroupParameterSet,
        SupportsShouldProcess = true),
        OutputType(typeof(AzureSqlManagedDatabaseModel))]
    public class NewAzureSqlManagedDatabase : AzureSqlManagedDatabaseCmdletBase<AzureSqlManagedDatabaseModel>
    {
        protected const string CreateNewByNameAndResourceGroupParameterSet =
            "CreateNewInstanceDatabaseFromInputParameters";

        protected const string CreateNewByInputObjectParameterSet =
            "CreateNewInstanceDatabaseFromAzureSqlManagedInstanceModelInstanceDefinition";

        protected const string CreateNewByResourceIdParameterSet =
            "CreateNewInstanceDatabaseFromAzureSqlInstanceResourceId";

        /// <summary>
        /// Gets or sets the name of the instance database to create.
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            HelpMessage = "The name of the instance database to create.")]
        [Alias("InstanceDatabaseName")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances/databases", "ResourceGroupName", "InstanceName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the instance to use
        /// </summary>
        [Parameter(ParameterSetName = CreateNewByNameAndResourceGroupParameterSet,
            Mandatory = true,
            Position = 1,
            HelpMessage = "The name of the instance.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(ParameterSetName = CreateNewByNameAndResourceGroupParameterSet,
            Mandatory = true,
            Position = 2,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the instance database collation to use
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The collation of the instance database to use.")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("SQL_Latin1_General_CP1_CI_AS", "Latin1_General_100_CS_AS_SC")]
        public string Collation { get; set; }

        /// <summary>
        /// Gets or sets the tags associated with the instance database
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The tags to associate with the instance database")]
        [Alias("Tags")]
        public Hashtable Tag { get; set; }

        /// <summary>
        /// Gets or sets the instance object
        /// </summary>
        [Parameter(ParameterSetName = CreateNewByInputObjectParameterSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = "The instance object")]
        [ValidateNotNullOrEmpty]
        [Alias("ParentObject")]
        public AzureSqlManagedInstanceModel InstanceObject { get; set; }

        /// <summary>
        /// Gets or sets the resource id of the instance to get
        /// </summary>
        [Parameter(ParameterSetName = CreateNewByResourceIdParameterSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The instance resource id")]
        [ValidateNotNullOrEmpty]
        [Alias("ParentResourceId")]
        public string InstanceResourceId { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
        }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override AzureSqlManagedDatabaseModel GetEntity()
        {
            if (string.Equals(this.ParameterSetName, CreateNewByInputObjectParameterSet, System.StringComparison.OrdinalIgnoreCase))
            {
                ResourceGroupName = InstanceObject.ResourceGroupName;
                InstanceName = InstanceObject.ManagedInstanceName;
            }
            else if (string.Equals(this.ParameterSetName, CreateNewByResourceIdParameterSet, System.StringComparison.OrdinalIgnoreCase))
            {
                var resourceInfo = new ResourceIdentifier(InstanceResourceId);

                ResourceGroupName = resourceInfo.ResourceGroupName;
                InstanceName = resourceInfo.ResourceName;
            }

            // We try to get the instance database. Since this is a create, we don't want the database to exist
            try
            {
                ModelAdapter.GetManagedDatabase(this.ResourceGroupName, this.InstanceName, this.Name);
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // This is what we want.  We looked and there is no instance database with this name.
                    return null;
                }

                // Unexpected exception encountered
                throw;
            }

            // The instance database already exists
            throw new PSArgumentException(
                string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.DatabaseNameExists, this.Name, this.InstanceName),
                "InstanceDatabaseName");
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
                Collation = Collation,
                Name = Name,
                CreateMode = "Default",
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
            AzureSqlManagedDatabaseModel upsertedManagedDatabase;
            return upsertedManagedDatabase = ModelAdapter.UpsertManagedDatabase(this.ResourceGroupName, this.InstanceName, entity);
        }

        /// <summary>
        /// Strips away the create or update properties from the model so that just the regular properties
        /// are written to cmdlet output.
        /// </summary>
        protected override object TransformModelToOutputObject(AzureSqlManagedDatabaseModel model)
        {
            return model;
        }
    }
}
