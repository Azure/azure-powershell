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

using Microsoft.Azure.Commands.Sql.InstanceFailoverGroup.Model;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.InstanceFailoverGroup.Cmdlet
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlDatabaseInstanceFailoverGroup"), OutputType(typeof(AzureSqlInstanceFailoverGroupModel))]
    public class GetAzureSqlInstanceFailoverGroup : AzureSqlInstanceFailoverGroupCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the InstanceFailoverGroup to use.
        /// </summary>
        [Parameter(Mandatory = false,
            Position = 2,
            HelpMessage = "The name of the Instance Failover Group to retrieve.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlInstanceFailoverGroupModel> GetEntity()
        {
            ICollection<AzureSqlInstanceFailoverGroupModel> results;

            if (MyInvocation.BoundParameters.ContainsKey("Name")) 
            {
                results = new List<AzureSqlInstanceFailoverGroupModel>();
                results.Add(ModelAdapter.GetInstanceFailoverGroup(this.ResourceGroupName, this.Location, this.Name));
            }
            else
            {
                results = ModelAdapter.ListInstanceFailoverGroups(this.ResourceGroupName, this.Location);
            }

            return results;
        }

        /// <summary>
        /// No user input to apply to model
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlInstanceFailoverGroupModel> ApplyUserInputToModel(IEnumerable<AzureSqlInstanceFailoverGroupModel> model)
        {
            return model;
        }

        /// <summary>
        /// No changes to persist to server
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlInstanceFailoverGroupModel> PersistChanges(IEnumerable<AzureSqlInstanceFailoverGroupModel> entity)
        {
            return entity;
        }
    }
}
