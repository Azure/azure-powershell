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
    [Cmdlet(VerbsCommon.New, "AzureRmSqlManagedDatabase",
        SupportsShouldProcess = true),
        OutputType(typeof(AzureSqlManagedDatabaseModel))]
    public class NewAzureSqlManagedDatabase : AzureSqlManagedDatabaseCmdletBase<AzureSqlManagedDatabaseModel>
    {
        protected const string CreateNewByNameAndResourceGroupParameterSet =
            "CreateNewManagedDatabaseFromInputParameters";

        protected const string CreateNewByInputObjectParameterSet =
            "CreateNewManagedDatabaseFromAzureSqlManagedInstanceModelInstanceDefinition";

        protected const string CreateNewByResourceIdParameterSet =
            "CreateNewManagedDatabaseFromAzureSqlManagedInstanceResourceId";

        /// <summary>
        /// Gets or sets the name of the managed database to create.
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            HelpMessage = "The name of the Azure SQL Managed Database to create.")]
        [Alias("ManagedDatabaseName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the Azure Sql Managed instance to use
        /// </summary>
        [Parameter(ParameterSetName = CreateNewByNameAndResourceGroupParameterSet,
            Mandatory = true,
            Position = 1,
            HelpMessage = "The Azure Sql Managed Instance name.")]
        [ValidateNotNullOrEmpty]
        public override string ManagedInstanceName { get; set; }

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
        /// Gets or sets the name of the Azure SQL Managed Database collation to use
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The collation of the Azure SQL Managed Database collation to use.")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("SQL_Latin1_General_CP1_CI_AS", "Latin1_General_100_CS_AS_SC")]
        public string Collation { get; set; }

        /// <summary>
        /// Gets or sets the tags associated with the Azure Sql Managed Database
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The tags to associate with the Azure Sql Managed Database")]
        [Alias("Tags")]
        public Hashtable Tag { get; set; }

        /// <summary>
        /// Gets or sets the Azure Sql Managed Instance object
        /// </summary>
        [Parameter(ParameterSetName = CreateNewByInputObjectParameterSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = "The Azure Sql Managed Instance object")]
        [ValidateNotNullOrEmpty]
        [Alias("InputObject")]
        public AzureSqlManagedInstanceModel ManagedInstanceObject { get; set; }

        /// <summary>
        /// Gets or sets the resource id of the Managed instance to get
        /// </summary>
        [Parameter(ParameterSetName = CreateNewByResourceIdParameterSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Managed Instance resource id")]
        [ValidateNotNullOrEmpty]
        public string ManagedInstanceResourceId { get; set; }

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
                ResourceGroupName = ManagedInstanceObject.ResourceGroupName;
                ManagedInstanceName = ManagedInstanceObject.ManagedInstanceName;
            }
            else if (string.Equals(this.ParameterSetName, CreateNewByResourceIdParameterSet, System.StringComparison.OrdinalIgnoreCase))
            {
                var resourceInfo = new ResourceIdentifier(ManagedInstanceResourceId);

                ResourceGroupName = resourceInfo.ResourceGroupName;
                ManagedInstanceName = resourceInfo.ResourceName;
            }

            // We try to get the managed database. Since this is a create, we don't want the database to exist
            try
            {
                ModelAdapter.GetManagedDatabase(this.ResourceGroupName, this.ManagedInstanceName, this.Name);
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // This is what we want.  We looked and there is no managed database with this name.
                    return null;
                }

                // Unexpected exception encountered
                throw;
            }

            // The managed database already exists
            throw new PSArgumentException(
                string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.DatabaseNameExists, this.Name, this.ManagedInstanceName),
                "ManagedDatabaseName");
        }

        /// <summary>
        /// Create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override AzureSqlManagedDatabaseModel ApplyUserInputToModel(AzureSqlManagedDatabaseModel model)
        {
            string location = ModelAdapter.GetManagedInstanceLocation(ResourceGroupName, ManagedInstanceName);
            return new AzureSqlManagedDatabaseModel()
            {
                Location = location,
                ResourceGroupName = ResourceGroupName,
                ManagedInstanceName = ManagedInstanceName,
                Collation = Collation,
                Name = Name,
                CreateMode = "Default",
                Tags = TagsConversionHelper.CreateTagDictionary(Tag, validate: true),
            };
        }

        /// <summary>
        /// Create the new managed database
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override AzureSqlManagedDatabaseModel PersistChanges(AzureSqlManagedDatabaseModel entity)
        {
            AzureSqlManagedDatabaseModel upsertedManagedDatabase;
            return upsertedManagedDatabase = ModelAdapter.UpsertManagedDatabase(this.ResourceGroupName, this.ManagedInstanceName, entity);
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
