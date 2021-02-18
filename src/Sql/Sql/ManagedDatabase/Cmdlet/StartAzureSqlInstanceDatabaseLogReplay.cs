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
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.ManagedDatabase.Model;
using Microsoft.Azure.Commands.Sql.Properties;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Sql.ManagedDatabase.Cmdlet
{
    /// <summary>
    /// Cmdlet to start a Azure Sql Managed Database Log Replay
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceDatabaseLogReplay",
        DefaultParameterSetName = LogReplayByNameAndResourceGroupParameterSet,
        SupportsShouldProcess = true),
    OutputType(typeof(AzureSqlManagedDatabaseModel))]
    public class StartAzureSqlInstanceDatabaseLogReplay : AzureSqlManagedDatabaseLogReplayCmdletBase
    {
        /// <summary>
        /// Gets or sets the URI of the storage container to use.
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The storage container URI.")]
        [Alias("Storage")]
        [ValidateNotNullOrEmpty]
        public string StorageContainerUri { get; set; }

        /// <summary>
        /// Gets or sets the Sas token of the storage container.
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The storage container Sas token.")]
        [Alias("SasToken")]
        [ValidateNotNullOrEmpty]
        public string StorageContainerSasToken { get; set; }

        /// <summary>
        /// Gets or sets whether or not to automatically complete restore upon completion.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The indicator whether or not to auto-complete restore upon completion.")]
        public SwitchParameter AutoCompleteRestore { get; set; }

        /// <summary>
        /// Gets or sets the name of the last backup.
        /// </summary>
        [Parameter(Mandatory = false)]
        public string LastBackupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the instance database collation to use
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The collation of the instance database to use.")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("SQL_Latin1_General_CP1_CI_AS", "Latin1_General_100_CS_AS_SC")]
        public string Collation { get; set; }

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
            try
            {
                ModelAdapter.GetManagedDatabase(ResourceGroupName, InstanceName, Name);
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
        /// Updates the given model element with the cmdlet specific operation 
        /// </summary>
        /// <param name="model">An Azure Sql Managed Database model object</param>
        protected override AzureSqlManagedDatabaseModel ApplyUserInputToModel(AzureSqlManagedDatabaseModel model)
        {
            string location = ModelAdapter.GetManagedInstanceLocation(ResourceGroupName, InstanceName);
            model = new AzureSqlManagedDatabaseModel
            {
                Location = location,
                ResourceGroupName = ResourceGroupName,
                ManagedInstanceName = InstanceName,
                Name = Name,
                StorageContainerUri = StorageContainerUri,
                StorageContainerSasToken = StorageContainerSasToken,
                Collation = Collation
            };

            if (AutoCompleteRestore.IsPresent && string.IsNullOrEmpty(LastBackupName))
            {
                throw new ArgumentNullException(nameof(LastBackupName), Resources.StartManagedDatabaseLogReplay_LastBackupName_Warning);
            }

            model.AutoCompleteRestore = AutoCompleteRestore;
            model.LastBackupName = LastBackupName;

            return model;
        }

        protected override AzureSqlManagedDatabaseModel PersistChanges(AzureSqlManagedDatabaseModel entity)
        {
            return ModelAdapter.StartManagedDatabaseLogReplay(entity);
        }
    }
}
