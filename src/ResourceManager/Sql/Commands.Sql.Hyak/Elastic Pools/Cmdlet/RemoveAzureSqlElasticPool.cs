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

using Microsoft.Azure.Commands.Sql.ElasticPool.Model;
using System.Collections.Generic;
using System.Globalization;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ElasticPool.Cmdlet
{
    [Cmdlet(VerbsCommon.Remove, "AzureRmSqlElasticPool",
        SupportsShouldProcess = true)]
    public class RemoveAzureSqlElasticPool : AzureSqlElasticPoolCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the ElasticPool to remove.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The name of the Azure SQL Elastic Pool to remove.")]
        [ValidateNotNullOrEmpty]
        public string ElasticPoolName { get; set; }

        /// <summary>
        /// Defines whether it is ok to skip the requesting of rule removal confirmation
        /// </summary>
        [Parameter(HelpMessage = "Skip confirmation message for performing the action")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlElasticPoolModel> GetEntity()
        {
            return new List<AzureSqlElasticPoolModel>() {
                ModelAdapter.GetElasticPool(this.ResourceGroupName, this.ServerName, this.ElasticPoolName)
            };
        }

        /// <summary>
        /// No user input to apply to model
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlElasticPoolModel> ApplyUserInputToModel(IEnumerable<AzureSqlElasticPoolModel> model)
        {
            return model;
        }

        /// <summary>
        /// No changes to persist to server
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlElasticPoolModel> PersistChanges(IEnumerable<AzureSqlElasticPoolModel> entity)
        {
            ModelAdapter.RemoveElasticPool(this.ResourceGroupName, this.ServerName, this.ElasticPoolName);
            return entity;
        }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (!Force.IsPresent && !ShouldProcess(
               string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.RemoveAzureSqlDatabaseElasticPoolDescription, this.ElasticPoolName, this.ServerName),
               string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.RemoveAzureSqlDatabaseElasticPoolWarning, this.ElasticPoolName, this.ServerName),
               Microsoft.Azure.Commands.Sql.Properties.Resources.ShouldProcessCaption))
            {
                return;
            }

            base.ExecuteCmdlet();
        }
    }
}
