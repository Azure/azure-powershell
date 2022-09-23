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

using Microsoft.Azure.Commands.Sql.Database.Model;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Sql.Database.Services;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Collections;
using System.Globalization;
using System;

namespace Microsoft.Azure.Commands.Sql.Database.Cmdlet
{
    /// <summary>
    /// Cmdlet to create a new Azure Sql Database
    /// </summary>
    [CmdletOutputBreakingChange(
        deprecatedCmdletOutputTypeName: typeof(AzureSqlDatabaseModel),
        deprecateByVersion: "3.0.0",
        DeprecatedOutputProperties = new String[] { "BackupStorageRedundancy" },
        NewOutputProperties = new String[] { "CurrentBackupStorageRedundancy", "RequestedBackupStorageRedundancy" })]
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlDatabase", SupportsShouldProcess = true,ConfirmImpact = ConfirmImpact.Low, DefaultParameterSetName = DtuDatabaseParameterSet), OutputType(typeof(AzureSqlDatabaseModel))]
    public class NewAzureSqlDatabase : AzureSqlDatabaseCmdletBase<AzureSqlDatabaseCreateOrUpdateModel>
    {
        /// <summary>
        /// Gets or sets the name of the database to create.
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The name of the Azure SQL Database to create.")]
        [Alias("Name")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the name of the Azure SQL Database collation to use
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The name of the Azure SQL Database collation to use.")]
        [ValidateNotNullOrEmpty]
        public string CollationName { get; set; }

        /// <summary>
        /// Gets or sets the name of the Azure SQL Database catalog collation to use
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The name of the Azure SQL Database catalog collation to use.")]
        [ValidateNotNullOrEmpty]
        public string CatalogCollation { get; set; }

        /// <summary>
        /// Gets or sets the maximum size of the Azure SQL Database in bytes
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The maximum size of the Azure SQL Database in bytes.")]
        [ValidateNotNullOrEmpty]
        public long MaxSizeBytes { get; set; }

        /// <summary>
        /// Gets or sets the edition to assign to the Azure SQL Database
        /// </summary>
        [Parameter(ParameterSetName = DtuDatabaseParameterSet, Mandatory = false,
            HelpMessage = "The edition to assign to the Azure SQL Database.")]
        [Parameter(ParameterSetName = VcoreDatabaseParameterSet, Mandatory = true,
            HelpMessage = "The edition to assign to the Azure SQL Database.")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("None",
            "Basic",
            "Standard",
            "Premium",
            "DataWarehouse",
            "Free",
            "Stretch",
            "GeneralPurpose",
            "BusinessCritical")]
        public string Edition { get; set; }

        /// <summary>
        /// Gets or sets the name of the service objective to assign to the Azure SQL Database
        /// </summary>
        [Parameter(ParameterSetName = DtuDatabaseParameterSet, Mandatory = false,
            HelpMessage = "The name of the service objective to assign to the Azure SQL Database.")]
        [ValidateNotNullOrEmpty]
        public string RequestedServiceObjectiveName { get; set; }

        /// <summary>
        /// Gets or sets the name of the Elastic Pool to put the database in
        /// </summary>
        [Parameter(ParameterSetName = DtuDatabaseParameterSet, Mandatory = false,
            HelpMessage = "The name of the Elastic Pool to put the database in.")]
        [ResourceNameCompleter("Microsoft.Sql/servers/elasticPools", "ResourceGroupName", "ServerName")]
        [ValidateNotNullOrEmpty]
        public string ElasticPoolName { get; set; }

        /// <summary>
        /// Gets or sets the read scale option to assign to the Azure SQL Database
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "If enabled, connections that have application intent set to readonly in their connection string may be routed to a readonly secondary replica. This property is only settable for Premium and Business Critical databases.")]
        [ValidateNotNullOrEmpty]
        public DatabaseReadScale ReadScale { get; set; }

        /// <summary>
        /// Gets or sets the tags associated with the Azure Sql Database
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The tags to associate with the Azure Sql Database Server")]
        [Alias("Tag")]
        public Hashtable Tags { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "The name of the sample schema to apply when creating this database.")]
        [ValidateSet("AdventureWorksLT")]
        public string SampleName { get; set; }

        /// <summary>
        /// Gets or sets the zone redundant option to assign to the Azure SQL Database
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The zone redundancy to associate with the Azure Sql Database")]
        public SwitchParameter ZoneRedundant { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Defines whether it is ok to skip the requesting of confirmation
        /// </summary>
        [Parameter(HelpMessage = "Skip confirmation message for performing the action")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Gets or sets the Vcore number for the Azure Sql database
        /// </summary>
        [Parameter(ParameterSetName = VcoreDatabaseParameterSet, Mandatory = true,
            HelpMessage = "The Vcore number for the Azure Sql database")]
        [Alias("Capacity", "MaxVCore", "MaxCapacity")]
        public int VCore { get; set; }

        /// <summary>
        /// Gets or sets the compute generation for the Azure Sql database
        /// </summary>
        [Parameter(ParameterSetName = VcoreDatabaseParameterSet, Mandatory = true,
            HelpMessage = "The compute generation to assign.")]
        [Alias("Family")]
        [PSArgumentCompleter("Gen4", "Gen5")]
        public string ComputeGeneration { get; set; }

        /// <summary>
        /// Gets or sets the license type for the Azure Sql database
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The license type for the Azure Sql database. Possible values are BasePrice (with AHB discount) and LicenseIncluded (without AHB discount).")]
        [PSArgumentCompleter(
            "LicenseIncluded",
            "BasePrice")]
        public string LicenseType { get; set; }

        /// <summary>
        /// Gets or sets the compute model for Azure Sql database
        /// </summary>
        [Parameter(ParameterSetName = VcoreDatabaseParameterSet, Mandatory = false,
            HelpMessage="The compute model for database. Serverless or Provisioned")]
        [PSArgumentCompleter(
            DatabaseComputeModel.Provisioned,
            DatabaseComputeModel.Serverless)]
        public string ComputeModel { get; set; }

        /// <summary>
        /// Gets or sets the Auto Pause delay for Azure Sql Database
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The auto pause delay in minutes for database(serverless only), -1 to opt out from pausing")]
        public int AutoPauseDelayInMinutes { get; set; }

        /// <summary>
        /// Gets or sets the Minimal capacity that database will always have allocated, if not paused
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The Minimal capacity that database will always have allocated, if not paused. For serverless database only.")]
        [Alias("MinVCore", "MinCapacity")]
        public double MinimumCapacity { get; set; }

        /// <summary>
        /// Gets or sets the number of readonly replicas for the Azure Sql database
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The number of readonly secondary replicas associated with the database to which readonly application intent connections may be routed. This property is only settable for Hyperscale edition databases.")]
        [Alias("ReadReplicaCount")]
        public int HighAvailabilityReplicaCount { get; set; }

        /// <summary>
        /// Gets or sets the database backup storage redundancy.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The Backup storage redundancy used to store backups for the SQL Database. Options are: Local, Zone, Geo, and GeoZone.")]
        [ValidateSet("Local", "Zone", "Geo", "GeoZone", IgnoreCase = false)]
        public string BackupStorageRedundancy { get; set; }

        /// <summary>
        /// Gets or sets the secondary type for the database if it is a secondary.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The secondary type of the database if it is a secondary.  Valid values are Geo and Named.")]
        [ValidateSet("Named", "Geo")]
        public string SecondaryType { get; set; }

        /// <summary>
        /// Gets or sets the maintenance configuration id for the database
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The Maintenance configuration id for the SQL Database.")]
        public string MaintenanceConfigurationId { get; set; }

        /// <summary>
        /// Gets or sets the ledger option to assign to the Azure SQL Database
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Creates a ledger database, in which the integrity of all data is protected by the ledger feature. All tables in the ledger database must be ledger tables. Note: the value of this property cannot be changed after the database has been created.")]
        public SwitchParameter EnableLedger { get; set; }

        /// <summary>
        /// Overriding to add warning message
        /// </summary>
        public override void ExecuteCmdlet()
        {
            ModelAdapter = InitModelAdapter();
            string location = ModelAdapter.GetServerLocation(ResourceGroupName, ServerName);
            if (ListOfRegionsToShowWarningMessageForGeoBackupStorage.Contains(location.ToLower()))
            {
                if (this.BackupStorageRedundancy == null)
                {
                    if (!Force.IsPresent && !ShouldContinue(
                        string.Format(CultureInfo.InvariantCulture, Properties.Resources.DoYouWantToProceed, this.DatabaseName),
                        string.Format(CultureInfo.InvariantCulture, Properties.Resources.BackupRedundancyNotChosenTakeGeoWarning)))
                    {
                        return;
                    }
                }
                else if (string.Equals(this.BackupStorageRedundancy, "Geo", System.StringComparison.OrdinalIgnoreCase))
                {
                    WriteWarning(string.Format(CultureInfo.InvariantCulture, Properties.Resources.BackupRedundancyChosenIsGeoWarning));
                }
            }
            base.ExecuteCmdlet();
        }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override AzureSqlDatabaseCreateOrUpdateModel GetEntity()
        {
            // We try to get the database.  Since this is a create, we don't want the database to exist
            try
            {
                ModelAdapter.GetDatabase(this.ResourceGroupName, this.ServerName, this.DatabaseName);
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
                string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.DatabaseNameExists, this.DatabaseName, this.ServerName),
                "DatabaseName");
        }

        /// <summary>
        /// Create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override AzureSqlDatabaseCreateOrUpdateModel ApplyUserInputToModel(AzureSqlDatabaseCreateOrUpdateModel model)
        {
            string location = ModelAdapter.GetServerLocation(ResourceGroupName, ServerName);
            AzureSqlDatabaseCreateOrUpdateModel dbCreateUpdateModel = new AzureSqlDatabaseCreateOrUpdateModel();
            AzureSqlDatabaseModel newDbModel = new AzureSqlDatabaseModel()
            {
                Location = location,
                ResourceGroupName = ResourceGroupName,
                ServerName = ServerName,
                CatalogCollation = CatalogCollation,
                CollationName = CollationName,
                DatabaseName = DatabaseName,
                MaxSizeBytes = MaxSizeBytes,
                Tags = TagsConversionHelper.CreateTagDictionary(Tags, validate: true),
                ElasticPoolName = ElasticPoolName,
                ReadScale = this.IsParameterBound(p => p.ReadScale) ? ReadScale : (DatabaseReadScale?)null,
                ZoneRedundant = this.IsParameterBound(p => p.ZoneRedundant) ? ZoneRedundant.ToBool() : (bool?)null,
                LicenseType = LicenseType, // note: default license type will be LicenseIncluded in SQL RP if not specified
                AutoPauseDelayInMinutes = this.IsParameterBound(p => p.AutoPauseDelayInMinutes) ? AutoPauseDelayInMinutes : (int?)null,
                MinimumCapacity = this.IsParameterBound(p => p.MinimumCapacity) ? MinimumCapacity : (double?)null,
                HighAvailabilityReplicaCount = this.IsParameterBound(p => p.HighAvailabilityReplicaCount) ? HighAvailabilityReplicaCount : (int?)null,
                RequestedBackupStorageRedundancy = BackupStorageRedundancy,
                SecondaryType = SecondaryType,
                MaintenanceConfigurationId = MaintenanceConfigurationId,
                EnableLedger = this.IsParameterBound(p => p.EnableLedger) ? EnableLedger.ToBool() : (bool?)null,
            };

            if (ParameterSetName == DtuDatabaseParameterSet)
            {
                newDbModel.SkuName = string.IsNullOrWhiteSpace(RequestedServiceObjectiveName) ? AzureSqlDatabaseAdapter.GetDatabaseSkuName(Edition) : RequestedServiceObjectiveName;
                newDbModel.Edition = Edition;
            }
            else
            {
                newDbModel.SkuName = AzureSqlDatabaseAdapter.GetDatabaseSkuName(Edition, ComputeModel == DatabaseComputeModel.Serverless);
                newDbModel.Edition = Edition;
                newDbModel.Capacity = VCore;
                newDbModel.Family = ComputeGeneration;
            }

            dbCreateUpdateModel.Database = newDbModel;
            dbCreateUpdateModel.SampleName = SampleName;

            return dbCreateUpdateModel;
        }

        /// <summary>
        /// Create the new database
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override AzureSqlDatabaseCreateOrUpdateModel PersistChanges(AzureSqlDatabaseCreateOrUpdateModel entity)
        {
            // Use AutoRest Sdk
            AzureSqlDatabaseModel upsertedDatabase = ModelAdapter.UpsertDatabaseWithNewSdk(this.ResourceGroupName, this.ServerName, entity);
            
            return new AzureSqlDatabaseCreateOrUpdateModel
            {
                Database = upsertedDatabase
            };
        }

        /// <summary>
        /// Strips away the create or update properties from the model so that just the regular properties
        /// are written to cmdlet output.
        /// </summary>
        protected override object TransformModelToOutputObject(AzureSqlDatabaseCreateOrUpdateModel model)
        {
            return model.Database;
        }
    }
}
