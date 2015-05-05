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
    [Cmdlet(VerbsCommon.Get, "AzureSqlElasticPoolRecommendationMetrics", 
        ConfirmImpact = ConfirmImpact.None)]
    public class GetAzureSqlElasticPoolRecommendationMetrics : AzureSqlElasticPoolRecommendationCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the elastic pool recommendation to use.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The name of the Azure SQL elastic pool recommendation to retrieve.")]
        [ValidateNotNullOrEmpty]
        public string ElasticPoolRecommendation { get; set; }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            ModelAdapter = InitModelAdapter(Profile.Context.Subscription);
            WriteObject(ModelAdapter.GetElasticPoolRecommendationMetrics(ResourceGroupName, ServerName, ElasticPoolRecommendation));
        }

        /// <summary>
        /// Not Used.
        /// </summary>
        /// <returns>Not Used</returns>
        protected override IEnumerable<AzureSqlElasticPoolRecommendationModel> GetEntity()
        {
            return null;
        }
    }
}
