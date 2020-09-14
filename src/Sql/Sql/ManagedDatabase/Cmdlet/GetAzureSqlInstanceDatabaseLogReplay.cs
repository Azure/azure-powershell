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

using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.ManagedDatabase.Model;

namespace Microsoft.Azure.Commands.Sql.ManagedDatabase.Cmdlet
{
    /// <summary>
    /// Cmdlet to get an Azure Sql Managed Database Log Replay status
    /// </summary>
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceDatabaseLogReplay"),
    OutputType(typeof(AzureSqlManagedDatabaseRestoreDetailsResultModel))]
    public class GetAzureSqlInstanceDatabaseLogReplay : AzureSqlManagedDatabaseCmdletBase<AzureSqlManagedDatabaseRestoreDetailsResultModel>
    {
        /// <summary>
        /// Gets or sets the name of the instance database to use.
        /// </summary>
        [Parameter(Mandatory = false,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the instance database to retrieve.")]
        [Alias("InstanceDatabaseName")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances/databases", "ResourceGroupName", "InstanceName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the instance
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the instance.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", "ResourceGroupName")]
        [Alias("ManagedInstanceName")]
        [ValidateNotNullOrEmpty]
        public override string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        protected override AzureSqlManagedDatabaseRestoreDetailsResultModel GetEntity()
        {
            return ModelAdapter.GetManagedDatabaseLogReplay(ResourceGroupName, InstanceName, Name);
        }

        protected override AzureSqlManagedDatabaseRestoreDetailsResultModel PersistChanges(AzureSqlManagedDatabaseRestoreDetailsResultModel entity)
        {
            return entity;
        }
    }
}
