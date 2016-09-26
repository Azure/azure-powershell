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

using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.RecommendedElasticPools.Services;
using Microsoft.Azure.Management.Sql.Models;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.RecommendedElasticPools.Cmdlet
{
    [Cmdlet(VerbsCommon.Get, "AzureRmSqlElasticPoolRecommendation",
        ConfirmImpact = ConfirmImpact.None, SupportsShouldProcess = true)]
    public class GetAzureSqlElasticPoolRecommendation : AzureSqlCmdletBase<IEnumerable<UpgradeRecommendedElasticPoolProperties>, AzureSqlElasticPoolRecommendationAdapter>
    {

        /// <summary>
        /// Gets or sets the name of the server to use.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "The name of the Azure SQL Server the Elastic Pool Recommendation is in.")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Initializes the adapter
        /// </summary>
        /// <param name="subscription"></param>
        /// <returns></returns>
        protected override AzureSqlElasticPoolRecommendationAdapter InitModelAdapter(AzureSubscription subscription)
        {
            return new AzureSqlElasticPoolRecommendationAdapter(DefaultProfile.Context);
        }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<UpgradeRecommendedElasticPoolProperties> GetEntity()
        {
            return ModelAdapter.ListRecommendedElasticPoolProperties(this.ResourceGroupName, this.ServerName);
        }
    }
}
