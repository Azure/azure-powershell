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

using Microsoft.Azure.Commands.Sql.Advisor.Model;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Advisor.Cmdlet
{
    /// <summary>
    /// Defines the Set-AzureRmSqlElasticPoolAdvisorAutoExecuteStatus cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmSqlElasticPoolAdvisorAutoExecuteStatus",
        SupportsShouldProcess = true)]
    public class SetAzureSqlElasticPoolAdvisorAutoExecuteStatus : AzureSqlElasticPoolAdvisorCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the advisor.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Azure SQL Elastic Pool Advisor name.")]
        [ValidateNotNullOrEmpty]
        public string AdvisorName { get; set; }

        /// <summary>
        /// Gets or sets the new auto-execute status of Azure SQL Elastic Pool Advisor.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The new auto-execute status of Azure SQL Elastic Pool Advisor.")]
        [ValidateNotNullOrEmpty]
        public AdvisorAutoExecuteStatus AutoExecuteStatus { get; set; }

        /// <summary>
        /// Gets entities from the service.
        /// </summary>
        /// <returns>A list of entities</returns>
        protected override IEnumerable<AzureSqlElasticPoolAdvisorModel> GetEntity()
        {
            return new List<AzureSqlElasticPoolAdvisorModel>() {
                ModelAdapter.GetElasticPoolAdvisor(this.ResourceGroupName, this.ServerName, this.ElasticPoolName, this.AdvisorName, expandRecommendedActions: false)
            };
        }

        /// <summary>
        /// Create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlElasticPoolAdvisorModel> ApplyUserInputToModel(IEnumerable<AzureSqlElasticPoolAdvisorModel> model)
        {
            List<AzureSqlElasticPoolAdvisorModel> newEntity = new List<AzureSqlElasticPoolAdvisorModel>();
            newEntity.Add(new AzureSqlElasticPoolAdvisorModel()
            {
                ResourceGroupName = ResourceGroupName,
                ServerName = ServerName,
                ElasticPoolName = ElasticPoolName,
                AdvisorName = AdvisorName,
                AutoExecuteStatus = AutoExecuteStatus.ToString()
            });

            return newEntity;
        }

        /// <summary>
        /// Update the advisor
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlElasticPoolAdvisorModel> PersistChanges(IEnumerable<AzureSqlElasticPoolAdvisorModel> entity)
        {
            return new List<AzureSqlElasticPoolAdvisorModel>() {
                ModelAdapter.UpdateAutoExecuteStatus(entity.Single())
            };
        }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (!ShouldProcess(
                    string.Format(CultureInfo.InvariantCulture, Properties.Resources.SetAdvisorAutoExecuteStatusDescription, this.AdvisorName, this.AutoExecuteStatus),
                    string.Format(CultureInfo.InvariantCulture, Properties.Resources.SetAdvisorAutoExecuteStatusWarning, this.AdvisorName, this.AutoExecuteStatus),
                    Properties.Resources.ShouldProcessCaption))
            {
                return;
            }

            base.ExecuteCmdlet();
        }
    }
}
