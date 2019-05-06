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

using Microsoft.Azure.Commands.Sql.ManagedDatabase.Model;
using Microsoft.Azure.Commands.Sql.ManagedInstance.Model;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ManagedDatabase.Cmdlet
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceDatabaseGeoBackup",
        DefaultParameterSetName = GetByNameAndResourceGroupParameterSet),
        OutputType(typeof(AzureSqlRecoverableManagedDatabaseModel))]
    public class GetAzureSqlInstanceDatabaseGeoBackup : AzureSqlRecoverableManagedDatabaseCmdletBase<IEnumerable<AzureSqlRecoverableManagedDatabaseModel>>
    {
        protected const string GetByNameAndResourceGroupParameterSet =
            "GetInstanceDatabaseFromInputParameters";

        /// <summary>
        /// Gets or sets the name of the instance database to use.
        /// </summary>
        [Parameter(ParameterSetName = GetByNameAndResourceGroupParameterSet,
            Mandatory = false,
            Position = 0,
            HelpMessage = "The name of the instance database to retrieve.")]
        [Alias("RecoverableInstanceDatabaseName")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances/recoverableDatabases", "ResourceGroupName", "InstanceName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the instance
        /// </summary>
        [Parameter(ParameterSetName = GetByNameAndResourceGroupParameterSet,
            Mandatory = true,
            Position = 1,
            HelpMessage = "The name of the instance.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(ParameterSetName = GetByNameAndResourceGroupParameterSet,
            Mandatory = true,
            Position = 2,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlRecoverableManagedDatabaseModel> GetEntity()
        {
            ICollection<AzureSqlRecoverableManagedDatabaseModel> results;

           if (MyInvocation.BoundParameters.ContainsKey("Name") && !WildcardPattern.ContainsWildcardCharacters(Name))
            {
                results = new List<AzureSqlRecoverableManagedDatabaseModel>();
                results.Add(ModelAdapter.GetRecoverableManagedDatabase(this.ResourceGroupName, this.InstanceName, this.Name));
            }
            else
            {
                results = ModelAdapter.ListRecoverableManagedDatabases(this.ResourceGroupName, this.InstanceName);
            }

            return SubResourceWildcardFilter(Name, results);
        }

        /// <summary>
        /// No user input to apply to model
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlRecoverableManagedDatabaseModel> ApplyUserInputToModel(IEnumerable<AzureSqlRecoverableManagedDatabaseModel> model)
        {
            return model;
        }

        /// <summary>
        /// No changes to persist to managed instance
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlRecoverableManagedDatabaseModel> PersistChanges(IEnumerable<AzureSqlRecoverableManagedDatabaseModel> entity)
        {
            return entity;
        }
    }
}
