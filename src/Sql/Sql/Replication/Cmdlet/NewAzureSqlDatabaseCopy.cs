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
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Sql.Properties;
using Microsoft.Azure.Commands.Sql.Replication.Model;
using Microsoft.Azure.Commands.Sql.Database.Services;
using Microsoft.Rest.Azure;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Globalization;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Sql.Replication.Cmdlet
{
    /// <summary>
    /// Cmdlet to create a new Azure SQL Database Copy
    /// </summary>
    [CmdletOutputBreakingChange(
        deprecatedCmdletOutputTypeName: typeof(AzureSqlDatabaseCopyModel),
        deprecateByVersion: "3.0.0",
        DeprecatedOutputProperties = new String[] { "BackupStorageRedundancy" },
        NewOutputProperties = new String[] { "CurrentBackupStorageRedundancy", "RequestedBackupStorageRedundancy" })]
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlDatabaseCopy", ConfirmImpact = ConfirmImpact.Low, SupportsShouldProcess = true, DefaultParameterSetName = DtuDatabaseParameterSet), OutputType(typeof(AzureSqlDatabaseCopyModel))]
    public class NewAzureSqlDatabaseCopy : AzureSqlDatabaseCopyCmdletBase
    {
        private const string DtuDatabaseParameterSet = "DtuBasedDatabase";
        private const string VcoreDatabaseParameterSet = "VcoreBasedDatabase";

        /// <summary>
        /// Gets or sets the name of the database to be copied.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The name of the Azure SQL Database to be copied.")]
        [ResourceNameCompleter("Microsoft.Sql/servers/databases", "ResourceGroupName", "ServerName")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the name of the service objective to assign to the Azure SQL Database copy
        /// </summary>
        [Parameter(ParameterSetName = DtuDatabaseParameterSet, Mandatory = false,
            HelpMessage = "The name of the service objective to assign to the Azure SQL Database copy.")]
        [ValidateNotNullOrEmpty]
        public string ServiceObjectiveName { get; set; }

        /// <summary>
        /// Gets or sets the name of the Elastic Pool to put the database copy in
        /// </summary>
        [Parameter(ParameterSetName = DtuDatabaseParameterSet, Mandatory = false,
            HelpMessage = "The name of the Elastic Pool to put the database copy in.")]
        [ResourceNameCompleter("Microsoft.Sql/servers/elasticPools", "ResourceGroupName", "ServerName")]
        [ValidateNotNullOrEmpty]
        public string ElasticPoolName { get; set; }

        /// <summary>
        /// Gets or sets the tags associated with the Azure SQL Database Copy
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The tags to associate with the Azure SQL Database Copy")]
        [Alias("Tag")]
        public Hashtable Tags { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group of the copy.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The name of the resource group of the copy.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string CopyResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the Azure SQL Server of the copy.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The name of the Azure SQL Server of the copy.")]
        [ResourceNameCompleter("Microsoft.Sql/servers", "CopyResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string CopyServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the source database copy.
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The name of the Azure SQL Database copy.")]
        [ValidateNotNullOrEmpty]
        public string CopyDatabaseName { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Gets or sets the compute generation of the database copy
        /// </summary>
        [Parameter(ParameterSetName = VcoreDatabaseParameterSet, Mandatory = true,
            HelpMessage = "The compute generation to assign to the new copy.")]
        [Alias("Family")]
        [PSArgumentCompleter("Gen4", "Gen5")]
        [ValidateNotNullOrEmpty]
        public string ComputeGeneration { get; set; }

        /// <summary>
        /// Gets or sets the Vcore numbers of the database copy
        /// </summary>
        [Parameter(ParameterSetName = VcoreDatabaseParameterSet, Mandatory = true,
            HelpMessage = "The Vcore numbers of the Azure Sql Database copy.")]
        [Alias("Capacity")]
        [ValidateNotNullOrEmpty]
        public int VCore { get; set; }

        /// <summary>
        /// Gets or sets the license type for the Azure Sql database
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The license type for the Azure Sql database.")]
        [PSArgumentCompleter(
            "LicenseIncluded",
            "BasePrice"
            )]
        public string LicenseType { get; set; }

        /// <summary>
        /// Gets or sets the database backup storage redundancy.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The Backup storage redundancy used to store backups for the SQL Database. Options are: Local, Zone, Geo, GeoZone.")]
        [ValidateSet("Local", "Zone", "Geo", "GeoZone")]
        public string BackupStorageRedundancy { get; set; }

        /// <summary>
        /// Gets or sets the zone redundant option to assign to the Azure SQL Database
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The zone redundancy to associate with the Azure Sql Database. This property is only settable for Hyperscale edition databases.")]
        public SwitchParameter ZoneRedundant { get; set; }

        protected static readonly string[] ListOfRegionsToShowWarningMessageForGeoBackupStorage = { "eastasia", "southeastasia", "brazilsouth", "east asia", "southeast asia", "brazil south" };

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
                    WriteWarning(string.Format(CultureInfo.InvariantCulture, Properties.Resources.BackupRedundancyNotChosenTakeSourceWarning));
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
        protected override IEnumerable<AzureSqlDatabaseCopyModel> GetEntity()
        {
            string copyResourceGroupName = string.IsNullOrWhiteSpace(this.CopyResourceGroupName) ? this.ResourceGroupName : this.CopyResourceGroupName;
            string copyServerName = string.IsNullOrWhiteSpace(this.CopyServerName) ? this.ServerName : this.CopyServerName;

            // We try to get the database.  Since this is a create copy, we don't want the copy database to exist
            try
            {
                ModelAdapter.GetDatabase(copyResourceGroupName, copyServerName, this.CopyDatabaseName);
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
                string.Format(Resources.DatabaseNameExists, this.CopyDatabaseName, copyServerName),
                "CopyDatabaseName");
        }

        /// <summary>
        /// Create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlDatabaseCopyModel> ApplyUserInputToModel(IEnumerable<AzureSqlDatabaseCopyModel> model)
        {
            string copyResourceGroup = string.IsNullOrWhiteSpace(CopyResourceGroupName) ? ResourceGroupName : CopyResourceGroupName;
            string copyServer = string.IsNullOrWhiteSpace(CopyServerName) ? ServerName : CopyServerName;

            string location = ModelAdapter.GetServerLocation(ResourceGroupName, ServerName);
            string copyLocation = copyServer.Equals(ServerName) ? location : ModelAdapter.GetServerLocation(copyResourceGroup, copyServer);
            Database.Model.AzureSqlDatabaseModel sourceDb = ModelAdapter.GetDatabase(ResourceGroupName, ServerName, DatabaseName);
            List<Model.AzureSqlDatabaseCopyModel> newEntity = new List<AzureSqlDatabaseCopyModel>();

            AzureSqlDatabaseCopyModel copyModel = new AzureSqlDatabaseCopyModel()
            {
                Location = location,
                ResourceGroupName = ResourceGroupName,
                ServerName = ServerName,
                DatabaseName = DatabaseName,
                CopyResourceGroupName = copyResourceGroup,
                CopyServerName = copyServer,
                CopyDatabaseName = CopyDatabaseName,
                CopyLocation = copyLocation,
                ServiceObjectiveName = ServiceObjectiveName,
                ElasticPoolName = ElasticPoolName,
                Tags = TagsConversionHelper.CreateTagDictionary(Tags, validate: true),
                LicenseType = LicenseType, // note: default license type is LicenseIncluded
                RequestedBackupStorageRedundancy = BackupStorageRedundancy,
                ZoneRedundant = this.IsParameterBound(p => p.ZoneRedundant) ? ZoneRedundant.ToBool() : (bool?)null,
            };

            if(ParameterSetName == DtuDatabaseParameterSet)
            {
                if (!string.IsNullOrWhiteSpace(ServiceObjectiveName))
                {
                    copyModel.SkuName = ServiceObjectiveName;
                }
                else if(string.IsNullOrWhiteSpace(ElasticPoolName))
                {
                    copyModel.SkuName = sourceDb.CurrentServiceObjectiveName;
                    copyModel.Edition = sourceDb.Edition;
                    copyModel.Capacity = sourceDb.Capacity;
                    copyModel.Family = sourceDb.Family;
                }
            }
            else
            {
                copyModel.SkuName = AzureSqlDatabaseAdapter.GetDatabaseSkuName(sourceDb.Edition);
                copyModel.Edition = sourceDb.Edition;
                copyModel.Capacity = VCore;
                copyModel.Family = ComputeGeneration;
            }

            newEntity.Add(copyModel);
            return newEntity;
        }

        /// <summary>
        /// Create the new database copy
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlDatabaseCopyModel> PersistChanges(IEnumerable<AzureSqlDatabaseCopyModel> entity)
        {
            return new List<AzureSqlDatabaseCopyModel>()
            {
                ModelAdapter.CopyDatabaseWithNewSdk(entity.First().CopyResourceGroupName, entity.First().CopyServerName, entity.First())
            };
        }
    }
}
