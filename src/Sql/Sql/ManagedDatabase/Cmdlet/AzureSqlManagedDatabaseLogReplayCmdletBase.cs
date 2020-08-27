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

using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.ManagedDatabase.Model;

namespace Microsoft.Azure.Commands.Sql.ManagedDatabase.Cmdlet
{
    /// <summary>
    /// The base class for all log replay related cmdlets
    /// </summary>
    public class AzureSqlManagedDatabaseLogReplayCmdletBase : AzureSqlManagedDatabaseCmdletBase<AzureSqlManagedDatabaseModel>
    {
        protected const string LogReplayByNameAndResourceGroupParameterSet =
            "LogReplayInstanceDatabaseFromInputParameters";

        protected const string LogReplayByInputObjectParameterSet =
            "LogReplayInstanceDatabaseFromAzureSqlManagedDatabaseModelInstanceDefinition";

        /// <summary>
        /// Gets or sets the name of the instance database.
        /// </summary>
        [Parameter(ParameterSetName = LogReplayByNameAndResourceGroupParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            Position = 0,
            HelpMessage = "The name of the instance database.")]
        [Alias("InstanceDatabaseName")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances/databases", "ResourceGroupName", "InstanceName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the instance
        /// </summary>
        [Parameter(ParameterSetName = LogReplayByNameAndResourceGroupParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            Position = 1,
            HelpMessage = "The name of the instance.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", "ResourceGroupName")]
        [Alias("ManagedInstanceName")]
        [ValidateNotNullOrEmpty]
        public override string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(ParameterSetName = LogReplayByNameAndResourceGroupParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            Position = 2,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Instance database object.
        /// </summary>
        [Parameter(ParameterSetName = LogReplayByInputObjectParameterSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = "The instance database object.")]
        [ValidateNotNullOrEmpty]
        [Alias("InstanceDatabase")]
        public AzureSqlManagedDatabaseModel InputObject { get; set; }

        protected override AzureSqlManagedDatabaseModel GetEntity()
        {
            return new AzureSqlManagedDatabaseModel()
            {
                ResourceGroupName = ResourceGroupName,
                ManagedInstanceName = InstanceName,
                Name = Name
            };
        }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (string.Equals(this.ParameterSetName, LogReplayByInputObjectParameterSet, System.StringComparison.OrdinalIgnoreCase))
            {
                ResourceGroupName = InputObject.ResourceGroupName;
                InstanceName = InputObject.ManagedInstanceName;
                Name = InputObject.Name;
            }
            
            base.ExecuteCmdlet();

            if (this.PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
    }
}
