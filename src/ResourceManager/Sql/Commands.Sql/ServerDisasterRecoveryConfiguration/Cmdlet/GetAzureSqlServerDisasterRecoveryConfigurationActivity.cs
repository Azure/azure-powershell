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

using Microsoft.Azure.Commands.Sql.ServerDisasterRecoveryConfiguration.Model;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ServerDisasterRecoveryConfiguration.Cmdlet
{
    [Cmdlet(VerbsCommon.Get, "AzureRmSqlServerDisasterRecoveryConfigurationActivity",
        ConfirmImpact = ConfirmImpact.None, SupportsShouldProcess = true)]
    public class GetAzureSqlServerDisasterRecoveryConfigurationActivity : AzureSqlServerDisasterRecoveryConfigurationActivityCmdletBase
    {
        /// <summary>
        /// Gets Server Disaster Recovery Configuration activity
        /// </summary>
        /// <returns>List of Server Disaster Recovery Configuration activities</returns>
        protected override IEnumerable<AzureSqlServerDisasterRecoveryConfigurationActivityModel> GetEntity()
        {
            return ModelAdapter.ListServerDisasterRecoveryConfigurationActivity(this.ResourceGroupName, this.ServerName, this.ServerDisasterRecoveryConfigurationName, this.OperationId);
        }

        /// <summary>
        /// No user input to apply to model
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlServerDisasterRecoveryConfigurationActivityModel> ApplyUserInputToModel(IEnumerable<AzureSqlServerDisasterRecoveryConfigurationActivityModel> model)
        {
            return model;
        }

        /// <summary>
        /// No changes to persist to server
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlServerDisasterRecoveryConfigurationActivityModel> PersistChanges(IEnumerable<AzureSqlServerDisasterRecoveryConfigurationActivityModel> entity)
        {
            return entity;
        }
    }
}
