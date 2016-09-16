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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Advisor.Cmdlet
{
    /// <summary>
    /// Defines the Get-AzureRmSqlElasticPoolAdvisors cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmSqlElasticPoolAdvisor")]
    public class GetAzureSqlElasticPoolAdvisor : AzureSqlElasticPoolAdvisorCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the advisor.
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Azure SQL Elastic Pool Advisor name.")]
        [ValidateNotNullOrEmpty]
        public string AdvisorName { get; set; }

        /// <summary>
        /// Gets or sets the flag indicating that we want to expand recommended actions in the response.
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Expand Recommended Actions of this Advisor in the response.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter ExpandRecommendedActions { get; set; }

        /// <summary>
        /// Gets entities from the service.
        /// </summary>
        /// <returns>A list of entities</returns>
        protected override IEnumerable<AzureSqlElasticPoolAdvisorModel> GetEntity()
        {
            ICollection<AzureSqlElasticPoolAdvisorModel> results;

            if (MyInvocation.BoundParameters.ContainsKey("AdvisorName"))
            {
                results = new List<AzureSqlElasticPoolAdvisorModel>();
                results.Add(ModelAdapter.GetElasticPoolAdvisor(this.ResourceGroupName, this.ServerName, this.ElasticPoolName, this.AdvisorName, this.ExpandRecommendedActions));
            }
            else
            {
                results = ModelAdapter.ListElasticPoolAdvisors(this.ResourceGroupName, this.ServerName, this.ElasticPoolName, this.ExpandRecommendedActions);
            }

            return results;
        }

        /// <summary>
        /// No user input to apply to model
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlElasticPoolAdvisorModel> ApplyUserInputToModel(IEnumerable<AzureSqlElasticPoolAdvisorModel> model)
        {
            return model;
        }

        /// <summary>
        /// No changes to persist to server
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlElasticPoolAdvisorModel> PersistChanges(IEnumerable<AzureSqlElasticPoolAdvisorModel> entity)
        {
            return entity;
        }
    }
}
