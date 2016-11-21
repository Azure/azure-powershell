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

using Hyak.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Sql.Properties;
using Microsoft.Azure.Commands.Sql.Replication.Model;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Replication.Cmdlet
{
    /// <summary>
    /// Cmdlet to create a new Azure SQL Database Copy
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmSqlDatabaseCopy",
        ConfirmImpact = ConfirmImpact.Low, SupportsShouldProcess = true)]
    public class NewAzureSqlDatabaseCopy : AzureSqlDatabaseCopyCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the database to be copied.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The name of the Azure SQL Database to be copied.")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the name of the service objective to assign to the Azure SQL Database copy
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The name of the service objective to assign to the Azure SQL Database copy.")]
        [ValidateNotNullOrEmpty]
        public string ServiceObjectiveName { get; set; }

        /// <summary>
        /// Gets or sets the name of the Elastic Pool to put the database copy in
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The name of the Elastic Pool to put the database copy in.")]
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
        [ValidateNotNullOrEmpty]
        public string CopyResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the Azure SQL Server of the copy.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The name of the Azure SQL Server of the copy.")]
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
            List<Model.AzureSqlDatabaseCopyModel> newEntity = new List<AzureSqlDatabaseCopyModel>();
            newEntity.Add(new AzureSqlDatabaseCopyModel()
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
            });
            return newEntity;
        }

        /// <summary>
        /// Create the new database copy
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlDatabaseCopyModel> PersistChanges(IEnumerable<AzureSqlDatabaseCopyModel> entity)
        {
            return new List<AzureSqlDatabaseCopyModel>() {
                ModelAdapter.CopyDatabase(entity.First().CopyResourceGroupName, entity.First().CopyServerName, entity.First())
            };
        }
    }
}
