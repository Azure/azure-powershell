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
using Microsoft.Azure.Commands.Sql.Database.Model;
using System.Collections.Generic;
using System.Globalization;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Database.Cmdlet
{
    [Cmdlet("Invoke", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlDatabaseFailover", SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class InvokeAzureSqlDatabaseFailover : AzureSqlDatabaseCmdletBase<IEnumerable<AzureSqlDatabaseModel>>
    {
        /// <summary>
        /// Gets or sets the name of the database to remove.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The name of the Azure SQL Database to failover.")]
        [ResourceNameCompleter("Microsoft.Sql/servers/databases", "ResourceGroupName", "ServerName")]
        [Alias("Name")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Defines whether to failover the readable secondary
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Failover the readable secondary replica instead of the default primary replica")]
        public SwitchParameter ReadableSecondary { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        ///  Defines whether the cmdlets will output a boolean at the end of its execution
        /// </summary>
        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Defines whether it is ok to skip the requesting of failover database confirmation
        /// </summary>
        [Parameter(HelpMessage = "Skip confirmation message for performing the action")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// String to indicate failover on primary replica of database
        /// </summary>
        public const string PrimaryReplica = "Primary";

        /// <summary>
        /// String to indicate failover on readable secondary replica of database
        /// </summary>
        public const string ReadableSecondaryReplica = "ReadableSecondary";

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlDatabaseModel> GetEntity()
        {
            return new List<Model.AzureSqlDatabaseModel>() {
                ModelAdapter.GetDatabase(this.ResourceGroupName, this.ServerName, this.DatabaseName)
            };
        }

        /// <summary>
        /// No user input to apply to model
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlDatabaseModel> ApplyUserInputToModel(IEnumerable<AzureSqlDatabaseModel> model)
        {
            return model;
        }

        /// <summary>
        /// No changes to persist to server
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlDatabaseModel> PersistChanges(IEnumerable<AzureSqlDatabaseModel> entity)
        {
            string replicaType = this.ReadableSecondary.IsPresent ? ReadableSecondaryReplica : PrimaryReplica;
            ModelAdapter.FailoverDatabase(this.ResourceGroupName, this.ServerName, this.DatabaseName, replicaType);
            return entity;
        }

        /// <summary>
        /// Returns false so the model object that was constructed by this cmdlet is not written out
        /// </summary>
        /// <returns>False since the model object should not be written out</returns>
        protected override bool WriteResult() { return false; }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (!Force.IsPresent && !ShouldProcess(
               string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.FailoverAzureSqlDatabaseDescription, this.DatabaseName, this.ServerName),
               string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.FailoverAzureSqlDatabaseWarning, this.DatabaseName, this.ServerName),
               Microsoft.Azure.Commands.Sql.Properties.Resources.ShouldProcessCaption))
            {
                return;
            }

            base.ExecuteCmdlet();

            if (this.PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
    }
}
