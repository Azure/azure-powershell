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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Sql.ElasticPoolRecommendation.Model;

namespace Microsoft.Azure.Commands.Sql.ElasticPoolRecommendation.Cmdlet
{
    [Cmdlet(VerbsCommon.Get, "AzureSqlElasticPoolRecommendation", 
        ConfirmImpact = ConfirmImpact.None)]
    public class GetAzureSqlElasticPoolRecommendation : AzureSqlElasticPoolRecommendationCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the RecommendedElasticPool to use.
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The name of the Azure SQL Elastic Pool Recommendation to retrieve.")]
        public string ElasticPoolRecommendation { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlElasticPoolRecommendationModel> GetEntity()
        {
            ICollection<AzureSqlElasticPoolRecommendationModel> results;

            if (MyInvocation.BoundParameters.ContainsKey("ElasticPoolRecommendation"))
            {
                results = new List<AzureSqlElasticPoolRecommendationModel>();
                results.Add(ModelAdapter.GetElasticPoolRecommendation(this.ResourceGroupName, this.ServerName, this.ElasticPoolRecommendation));
            }
            else
            {
                results = ModelAdapter.ListElasticPoolRecommendations(this.ResourceGroupName, this.ServerName);
            }

            return results;
        }
    }
}
