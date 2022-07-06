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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.ElasticJobs.Services;
using Microsoft.Azure.Commands.Sql.ElasticJobs.Model;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Sql.ElasticJobs.Cmdlet
{
    /// <summary>
    /// The elastic job step cmdlet base
    /// </summary>
    /// <typeparam name="TInputObject">The input object model</typeparam>
    public abstract class AzureSqlElasticJobStepCmdletBase<TInputObject> : AzureSqlElasticJobsCmdletBase<TInputObject, IEnumerable<AzureSqlElasticJobStepModel>, AzureSqlElasticJobAdapter>
    {
        /// <summary>
        /// Intializes the model adapter
        /// </summary>
        /// <returns>The Azure SQL Database Agent Job adapter</returns>
        protected override AzureSqlElasticJobAdapter InitModelAdapter()
        {
            return new AzureSqlElasticJobAdapter(DefaultContext);
        }

        /// <summary>
        /// Clears job step properties
        /// </summary>
        /// <remarks>
        /// We clear these properties so that during piping scenarios we can ensure we initialize the minimum properties
        /// for either getting, starting, stopping the current job execution.
        /// Resource group name, server name, agent name, job, job execution id, and step name are cleared
        /// so that during the next iteration in list, they will be initialized properly during <see cref="AzureSqlElasticJobsCmdletBase{TInputObject, TModel, TAdapter}.InitializeInputObjectProperties(TInputObject)"/>
        ///
        /// Note: We dont' clear credential name and target group name in case during Set-AzureRmSqlElasticJobStep scenario, client wishes to
        /// update multiple steps with same credential or target group. This is why we only clear the minimum parameters necessary to find the
        /// correct resource to execute on, while supporting InputObject/ParentObject and ResourceId/ParentResourceId parameter types.
        /// </remarks>
        protected void ClearProperties()
        {
            this.ResourceGroupName = null;
            this.ServerName = null;
            this.AgentName = null;
            this.JobName = null;
            this.StepName = null;
            this.Name = null;
        }
    }
}