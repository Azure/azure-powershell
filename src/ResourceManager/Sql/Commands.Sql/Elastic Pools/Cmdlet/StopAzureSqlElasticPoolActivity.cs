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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ElasticPool.Cmdlet
{
    [Cmdlet(VerbsLifecycle.Stop, "AzureRmSqlElasticPoolActivity", SupportsShouldProcess = true), OutputType(typeof(AzureSqlElasticPoolActivityModel))]
    public class StopAzureSqlElasticPoolActivity : AzureSqlElasticPoolActivityCmdletBase
    {
        /// <summary>
        ///  Defines whether the cmdlets will successfully returned at the end of its execution
        /// </summary>
        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Gets elastic pool activity
        /// </summary>
        /// <returns>List of elastic pool activies</returns>
        protected override IEnumerable<AzureSqlElasticPoolActivityModel> GetEntity()
        {
            return ModelAdapter.GetElasticPoolActivity(this.ResourceGroupName, this.ServerName, this.ElasticPoolName);
        }

        /// <summary>
        /// No user input to apply to model
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlElasticPoolActivityModel> ApplyUserInputToModel(IEnumerable<AzureSqlElasticPoolActivityModel> model)
        {
            return model;
        }

        /// <summary>
        /// No changes to persist to server
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlElasticPoolActivityModel> PersistChanges(IEnumerable<AzureSqlElasticPoolActivityModel> entity)
        {
            return ModelAdapter.CancelElasticPoolActivity(this.ResourceGroupName, this.ServerName, this.ElasticPoolName, this.OperationId);
        }

        /// <summary>
        /// Returns true if the model object that was constructed by this cmdlet should be written out
        /// </summary>
        /// <returns>True if the model object should be written out, False otherwise</returns>
        protected override bool WriteResult() { return PassThru; }
    } 
}