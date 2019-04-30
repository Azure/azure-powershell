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

using System;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Sql.Database.Model;
using Microsoft.Azure.Commands.Sql.Database.Services;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Database.Cmdlet
{
    /// <summary>
    /// Cmdlet to create a new Azure Sql Database
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlDatabase", SupportsShouldProcess = true,ConfirmImpact = ConfirmImpact.Medium, DefaultParameterSetName = UpdateParameterSetName), OutputType(typeof(AzureSqlDatabaseModel))]
    public class SetAzureSqlDatabase : AzureSqlDatabaseCmdletBase<IEnumerable<AzureSqlDatabaseModel>>
    {
        private const string UpdateParameterSetName = "Update";
        private const string RenameParameterSetName = "Rename";

        /// <summary>
        /// Gets or sets the name of the Azure SQL Database
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The name of the Azure SQL Database.")]
        [ResourceNameCompleter("Microsoft.Sql/servers/databases", "ResourceGroupName", "ServerName")]
        [Alias("Name")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the maximum size of the Azure SQL Database in bytes
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The maximum size of the Azure SQL Database in bytes.",
            ParameterSetName = UpdateParameterSetName)]
        [Parameter(Mandatory = false,
            HelpMessage = "The maximum size of the Azure SQL Database in bytes.",
            ParameterSetName = VcoreDatabaseParameterSet)]
        [ValidateNotNullOrEmpty]
        public long MaxSizeBytes { get; set; }

        /// <summary>
        /// Gets or sets the edition to assign to the Azure SQL Database
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The edition to assign to the Azure SQL Database.",
            ParameterSetName = UpdateParameterSetName)]
        [Parameter(Mandatory = false,
            HelpMessage = "The edition to assign to the Azure SQL Database.",
            ParameterSetName = VcoreDatabaseParameterSet)]
        [PSArgumentCompleter("None",
            Management.Sql.Models.DatabaseEdition.Basic,
            Management.Sql.Models.DatabaseEdition.Standard,
            Management.Sql.Models.DatabaseEdition.Premium,
            Management.Sql.Models.DatabaseEdition.DataWarehouse,
            Management.Sql.Models.DatabaseEdition.Free,
            Management.Sql.Models.DatabaseEdition.Stretch,
            "GeneralPurpose", "BusinessCritical")]
        [ValidateNotNullOrEmpty]
        public string Edition { get; set; }

        /// <summary>
        /// Gets or sets the name of the service objective to assign to the Azure SQL Database
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The name of the service objective to assign to the Azure SQL Database.",
            ParameterSetName = UpdateParameterSetName)]
        [ValidateNotNullOrEmpty]
        public string RequestedServiceObjectiveName { get; set; }

        /// <summary>
        /// Gets or sets the name of the Elastic Pool to put the database in
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The name of the Elastic Pool to put the database in.",
            ParameterSetName = UpdateParameterSetName)]
        [ResourceNameCompleter("Microsoft.Sql/servers/elasticPools", "ResourceGroupName", "ServerName")]
        [ValidateNotNullOrEmpty]
        public string ElasticPoolName { get; set; }

        /// <summary>
        /// Gets or sets the read scale option to assign to the Azure SQL Database
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The read scale option to assign to the Azure SQL Database.(Enabled/Disabled)",
            ParameterSetName = UpdateParameterSetName)]
        [Parameter(Mandatory = false,
            HelpMessage = "The read scale option to assign to the Azure SQL Database.(Enabled/Disabled)",
            ParameterSetName = VcoreDatabaseParameterSet)]
        [ValidateNotNullOrEmpty]
        public DatabaseReadScale ReadScale { get; set; }

        /// <summary>
        /// Gets or sets the tags associated with the Azure Sql Database
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The tags to associate with the Azure Sql Database",
            ParameterSetName = UpdateParameterSetName)]
        [Parameter(Mandatory = false,
            HelpMessage = "The tags to associate with the Azure Sql Database",
            ParameterSetName = VcoreDatabaseParameterSet)]
        [Alias("Tag")]
        public Hashtable Tags { get; set; }

        /// <summary>
        /// Gets or sets the zone redundant option to assign to the Azure SQL Database
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The zone redundancy to associate with the Azure Sql Database",
            ParameterSetName = UpdateParameterSetName)]
        [Parameter(Mandatory = false,
            HelpMessage = "The zone redundancy to associate with the Azure Sql Database",
            ParameterSetName = VcoreDatabaseParameterSet)]
        public SwitchParameter ZoneRedundant { get; set; }

        /// <summary>
        /// Gets or sets the new name.
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The new name to rename the database to.",
            ParameterSetName = RenameParameterSetName)]
        public string NewName { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Gets or sets the Vcore number for the Azure Sql database
        /// </summary>
        [Parameter(ParameterSetName = VcoreDatabaseParameterSet, Mandatory = false,
            HelpMessage = "The Vcore number for the Azure Sql database")]
        [Alias("Capacity", "MaxVCore", "MaxCapacity")]
        public int VCore { get; set; }

        /// <summary>
        /// Gets or sets the ComputeGeneration for the Azure Sql database.
        /// </summary>
        [Parameter(ParameterSetName = VcoreDatabaseParameterSet, Mandatory = false,
            HelpMessage = "The compute generation to assign.")]
        [Alias("Family")]
        [PSArgumentCompleter("Gen4", "Gen5")]
        public string ComputeGeneration { get; set; }

        /// <summary>
        /// Gets or sets the license type for the Azure Sql database
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The license type for the Azure Sql database. Possible values are BasePrice (with AHB discount) and LicenseIncluded (without AHB discount).",
            ParameterSetName = UpdateParameterSetName)]
        [Parameter(Mandatory = false,
            HelpMessage = "The license type for the Azure Sql database. Possible values are BasePrice (with AHB discount) and LicenseIncluded (without AHB discount).",
            ParameterSetName = VcoreDatabaseParameterSet)]
        [PSArgumentCompleter(
            Management.Sql.Models.DatabaseLicenseType.LicenseIncluded,
            Management.Sql.Models.DatabaseLicenseType.BasePrice)]
        public string LicenseType { get; set; }

        /// <summary>
        /// Gets or sets the compute model for the Azure Sql Database
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The computed model of database. Serverless or Provisioned",
            ParameterSetName = UpdateParameterSetName)]
        [Parameter(Mandatory = false,
            HelpMessage = "The computed model of database. Serverless or Provisioned",
            ParameterSetName = VcoreDatabaseParameterSet)]
        [PSArgumentCompleter(
            DatabaseComputeModel.Provisioned,
            DatabaseComputeModel.Serverless)]
        public string ComputeModel { get; set; }

        /// <summary>
        /// Gets or sets the auto pause delay for the Azure Sql Database
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The auto pause delay in minutes for database (serverless only), -1 to opt out from pausing",
            ParameterSetName = UpdateParameterSetName)]
        [Parameter(Mandatory = false,
            HelpMessage = "The auto pause delay in minutes for database (serverless only), -1 to opt out from pausing",
            ParameterSetName = VcoreDatabaseParameterSet)]
        public int AutoPauseDelayInMinutes { get; set; }

        /// <summary>
        /// Gets or sets the Minimal capacity that database will always have allocated, if not paused
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The Minimal capacity that database will always have allocated, if not paused. For serverless database only.",
            ParameterSetName = UpdateParameterSetName)]
        [Parameter(Mandatory = false,
            HelpMessage = "The Minimal capacity that database will always have allocated, if not paused. For serverless database only.",
            ParameterSetName = VcoreDatabaseParameterSet)]
        [Alias("MinVCore", "MinCapacity")]
        public double MinimumCapacity { get; set; }

        /// <summary>
        /// Overriding to add warning message
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
        }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlDatabaseModel> GetEntity()
        {
            return new List<AzureSqlDatabaseModel>() {
                ModelAdapter.GetDatabase(this.ResourceGroupName, this.ServerName, this.DatabaseName)
            };
        }

        /// <summary>
        /// Create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlDatabaseModel> ApplyUserInputToModel(IEnumerable<AzureSqlDatabaseModel> model)
        {
            List<Model.AzureSqlDatabaseModel> newEntity = new List<AzureSqlDatabaseModel>();
            AzureSqlDatabaseModel newDbModel = new AzureSqlDatabaseModel()
            {
                ResourceGroupName = ResourceGroupName,
                ServerName = ServerName,
                DatabaseName = DatabaseName,
                MaxSizeBytes = MaxSizeBytes,
                Tags = TagsConversionHelper.ReadOrFetchTags(this, model.FirstOrDefault().Tags),
                ElasticPoolName = ElasticPoolName,
                Location = model.FirstOrDefault().Location,
                ReadScale = ReadScale,
                ZoneRedundant =
                       ZoneRedundant != null
                           ? (bool?)ZoneRedundant.ToBool()
                           : null,
                LicenseType = LicenseType ?? model.FirstOrDefault().LicenseType, // set to original license type
                AutoPauseDelayInMinutes = MyInvocation.BoundParameters.ContainsKey("AutoPauseDelayInMinutes") ? AutoPauseDelayInMinutes : (int?)null,
                MinimumCapacity = MyInvocation.BoundParameters.ContainsKey("MinimumCapacity") ? MinimumCapacity : (double?)null,
            };

            var database = ModelAdapter.GetDatabase(ResourceGroupName, ServerName, DatabaseName);
            Management.Sql.Models.Sku databaseCurrentSku = new Management.Sql.Models.Sku()
            {
                Name = database.SkuName,
                Tier = database.Edition,
                Family = database.Family,
                Capacity = database.Capacity
            };

            // check if current db is serverless
            string databaseCurrentComputeModel = database.CurrentServiceObjectiveName.Contains("_S_") ? DatabaseComputeModel.Serverless : DatabaseComputeModel.Provisioned;

            if (this.ParameterSetName == UpdateParameterSetName)
            {
                newDbModel.SkuName = string.IsNullOrWhiteSpace(RequestedServiceObjectiveName) ? AzureSqlDatabaseAdapter.GetDatabaseSkuName(Edition) : RequestedServiceObjectiveName;
                newDbModel.Edition = Edition;

                newEntity.Add(newDbModel);
            }
            else if(this.ParameterSetName == VcoreDatabaseParameterSet)
            {
                if(!string.IsNullOrWhiteSpace(Edition) ||
                    !string.IsNullOrWhiteSpace(ComputeGeneration) ||
                    MyInvocation.BoundParameters.ContainsKey("VCore"))
                {
                    string skuTier = string.IsNullOrWhiteSpace(Edition) ? databaseCurrentSku.Tier : Edition;
                    string requestedComputeModel = string.IsNullOrWhiteSpace(ComputeModel) ? databaseCurrentComputeModel : ComputeModel;
                    newDbModel.SkuName = AzureSqlDatabaseAdapter.GetDatabaseSkuName(skuTier, requestedComputeModel == DatabaseComputeModel.Serverless);
                    newDbModel.Edition = skuTier;
                    newDbModel.Family = string.IsNullOrWhiteSpace(ComputeGeneration) ? databaseCurrentSku.Family : ComputeGeneration;
                    newDbModel.Capacity = MyInvocation.BoundParameters.ContainsKey("VCore") ? VCore : databaseCurrentSku.Capacity;
                }

                newEntity.Add(newDbModel);
            }

            return newEntity;
        }

        /// <summary>
        /// Update the database
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlDatabaseModel> PersistChanges(IEnumerable<AzureSqlDatabaseModel> entity)
        {
            switch (this.ParameterSetName)
            {
                case UpdateParameterSetName:
                case VcoreDatabaseParameterSet:
                    return new List<AzureSqlDatabaseModel>
                    {
                        ModelAdapter.UpsertDatabaseWithNewSdk(
                            this.ResourceGroupName,
                            this.ServerName,
                            new AzureSqlDatabaseCreateOrUpdateModel
                            {
                                Database = entity.First()
                            })
                    };

                case RenameParameterSetName:
                    ModelAdapter.RenameDatabase(
                        this.ResourceGroupName,
                        this.ServerName,
                        this.DatabaseName,
                        this.NewName);

                    return new List<AzureSqlDatabaseModel>
                    {
                        ModelAdapter.GetDatabase(
                            this.ResourceGroupName,
                            this.ServerName,
                            this.NewName)
                    };

                default:
                    throw new ArgumentException(this.ParameterSetName);
            }
        }
    }
}
